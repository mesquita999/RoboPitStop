using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoboPitStop.Produto;
using RoboPitStop.Pedido;
using RoboPitStop.Estoque;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RoboPitStop
{
    public partial class Form1 : Form
    {
        private ProdutoIndex index = new ProdutoIndex();
        public Form1()
        {
            InitializeComponent();
            //this.dataDe.Value = new DateTime(2020, 09, 01);
        }

        private void btnImportarProdutos_Click(object sender, EventArgs e)
        {
            if (txtFile.TextLength == 0)
            {
                MessageBox.Show("Selecione o arquivo que será importado!");
                return;
            }

            if (!File.Exists(txtFile.Text))
            {
                MessageBox.Show("O arquivo selecionado não existe!");
                return;
            }

            this.txtLog.Text = "";
            txtLog.AppendText("Iniciando importação");
            txtLog.AppendText(Environment.NewLine);
            this.lerArquivoCsv(this.txtFile.Text);
            txtLog.AppendText("Fim da importação");
        }

        private void lerArquivoCsv(string file)
        {
            string log = "";
            string logJson = "";

            using (StreamReader reader = new StreamReader(@file))
            {
                string linha = reader.ReadLine();
                string[] data = null;
                
                while (reader.Peek() != -1)
                {
                    linha = reader.ReadLine();
                    data = linha.Split(';');

                    if (data[index.Depto] == "depto" || data[index.Depto].Length == 0) continue;

                    string json = this.getJson(data);
                    string response = this.postProduto(json);

                    this.txtLog.AppendText(String.Concat(data[index.Codint], "-", data[index.Descrica], Environment.NewLine, response, Environment.NewLine, Environment.NewLine));

                    logJson = String.Concat(logJson, json, Environment.NewLine);

                    log = String.Concat(
                        log,
                        data[index.Codint],
                        "|",
                        data[index.Descrica],
                        Environment.NewLine,
                        response,
                        Environment.NewLine,
                        Environment.NewLine
                    );
                }
            }

            if (log.Length > 0)
            {
                string fileName = String.Concat(ConfigurationManager.AppSettings["LogCsvPath"], Util.fileUniqueName(), ".txt");
                File.WriteAllText(@fileName, String.Concat(logJson, Environment.NewLine, Environment.NewLine, log));
            }                
        }

        private string getPedidos()
        {
            string queryData = "&datainicio=" + this.dataDe.Value.ToString("yyyy-MM-dd") + "&datafim=" + this.dataAte.Value.ToString("yyyy-MM-dd");
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://comercializacaoapi.pitstop.com.br/wsintegracao/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("GetPedido?token=" + ConfigurationManager.AppSettings["token"] + "&login=" + ConfigurationManager.AppSettings["login"] + queryData).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
        }

        private string postProduto(string jsonBody)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://comercializacaoapi.pitstop.com.br/wsintegracao/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var contentString = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PostAsync("PostProduto?token=" + ConfigurationManager.AppSettings["token"] + "&login=" + ConfigurationManager.AppSettings["login"], contentString).Result;
                string resultContent = response.Content.ReadAsStringAsync().Result;
                return resultContent;
            }
        }

        private string getJson(string[] produtos)
        {
            var produtoJson = new ProdutosPost
            {
                postproduto = new Produtos
                {
                    departamento = new List<ProdutoDepartamento>()
                    {
                         new ProdutoDepartamento()
                         {
                            nome = produtos[index.DeptoDesc].Trim(),
                            codigo = produtos[index.Depto].Trim()
                         }
                    },
                    secao = new List<ProdutoSecao>()
                    {
                         new ProdutoSecao()
                         {
                            nome = produtos[index.SecaoDesc].Trim(),
                            codigo = produtos[index.Secao].Trim(),
                            codigodepartamento = produtos[index.Depto].Trim()
                         }
                    },
                    atributo = new List<ProdutoAtributo>()
                    {
                         new ProdutoAtributo()
                         {
                            nome = produtos[index.Cdatributo].Trim(),
                            atributoid = produtos[index.Atributo].Trim()
                         }
                    },
                    produto = new List<ProdutoPropriedades>()
                    {
                        new ProdutoPropriedades
                        {
                            nomeproduto = produtos[index.Descrica].Trim(),
                            codigoproduto = produtos[index.Codint].Trim(),
                            SKU = produtos[index.Sku].Trim(),
                            fabricante = produtos[index.Fornecedor].Trim(),
                            descricaoproduto = produtos[index.Descricao].Trim(),
                            peso = produtos[index.Peso].Replace('.', ',').Trim(),
                            largura = produtos[index.Largura].Replace('.', ',').Trim(),
                            altura = produtos[index.Altura].Replace('.', ',').Trim(),
                            profundidade = produtos[index.Profundidade].Replace('.', ',').Trim(),
                            preco = produtos[index.Preco].Replace('.', ',').Trim(),
                            precopromocao = produtos[index.Preco].Replace('.', ',').Trim(),
                            imagem = produtos[index.Imagem].Trim(),
                            prazoentrega = produtos[index.Prazo].Trim(),
                            prazogarantia = produtos[index.Garantia].Trim(),
                            ativo = produtos[index.Ativo].Trim(),
                            local = new ProdutoLocal
                            {
                                codepto = produtos[index.Cddepto].Trim(),
                                codsecao = produtos[index.Ccdsecao].Trim()

                            },
                            modelo = new ProdutoModelo
                            {
                                item = produtos[index.Sku].Trim(),
                                codigoprodutomodelo = "99" + produtos[index.Sku].Trim(),
                                estoque = produtos[index.Estoque].Trim()
                            }
                        }
                    }
                }
            };
            
            return JsonConvert.SerializeObject(produtoJson);
        }

        private void btnGetPedidos_Click(object sender, EventArgs e)
        {
            this.txtLog.Text = "";
            this.txtLog.Text = "Baixando pedidos...";
            var pedidos = Newtonsoft.Json.Linq.JObject.Parse(this.getPedidos());
            string cabecalho = Pedido.Pedido.getCabecalho();
            string content = "";
            string items = "";
            string fileUniqueName = Util.fileUniqueName();
            List<string> listPedidos = new List<string>();

            if (pedidos["dados_adicionais"].ToString().Length == 0)
            {
                this.txtLog.Text = "Nenhum pedido encontrado para o filtro.";
                return;
            }

            foreach (JObject item in pedidos["dados_adicionais"])
            {
                if (!listPedidos.Contains(item["getpedido"]["pedido"]["order_id"].ToString()))
                {
                    content = string.Concat(content, this.parsePedidoCsv(item), Environment.NewLine);
                    listPedidos.Add(item["getpedido"]["pedido"]["order_id"].ToString());

                    items = string.Concat(items, this.parsePedidoItem(item));
                }
            }

            this.txtLog.AppendText(String.Concat(cabecalho, Environment.NewLine, content));

            if (content.Length > 0)
            {
                string fileLogName = String.Concat(ConfigurationManager.AppSettings["LogCsvPath"], "pedido-", fileUniqueName, ".txt");
                File.WriteAllText(@fileLogName, String.Concat(pedidos.ToString(), Environment.NewLine, Environment.NewLine, content));
            }

            string fileName = String.Concat(@ConfigurationManager.AppSettings["PedidoCsvPath"], "pedido-", fileUniqueName, ".csv");
            File.WriteAllText(fileName, String.Concat(cabecalho, Environment.NewLine, content));

            string fileItemName = String.Concat(@ConfigurationManager.AppSettings["PedidoCsvPath"], "item-pedido-", fileUniqueName, ".csv");
            File.WriteAllText(fileItemName, String.Concat(Pedido.Pedido.getCabecalhoItem(), Environment.NewLine, items));
        }

        private string parsePedidoCsv(JObject node)
        {
            List<string> content = new List<string>();
            
            JToken pedido = node["getpedido"]["pedido"];
            JToken cliente = node["cliente"];
            JToken endereco = node["endereco"];

            int tipoPessoa = (cliente["tipopessoa"].ToString() == "Pessoa Física") ? 1 : 2;

            content.Add(pedido["order_id"].ToString()); //ID_PEDIDO
            content.Add(pedido["datavenda"].ToString()); //DT_PEDIDO
            content.Add(""); //PEDIDO
            content.Add(pedido["formaPagamento"].ToString()); //CONDICAO
            content.Add(pedido["transportadora"].ToString()); //TRANSPORTA
            content.Add(cliente["cpfcnpj"].ToString());//C_CPFCNPJ
            content.Add(cliente["inscrg"].ToString()); //C_RGIE
            content.Add(tipoPessoa.ToString()); //C_TP
            content.Add(cliente["clientenome"].ToString()); //C_NOME
            content.Add(cliente["email"].ToString()); //C_EMAIL
            content.Add(endereco["DDDres"].ToString() + endereco["foneres"].ToString()); //C_FONE
            content.Add(endereco["cep"].ToString()); //CE_CEP
            content.Add(endereco["endereco"].ToString()); //CE_LOGR
            content.Add(endereco["numero"].ToString()); //CE_NUMERO
            content.Add(endereco["complemento"].ToString()); //CE_COMP
            content.Add(endereco["bairro"].ToString()); //CE_BAIRRO
            content.Add(endereco["cidade"].ToString()); //CE_CIDADE
            content.Add(endereco["uf"].ToString()); //CE_UF
            content.Add(""); //PI_SKU
            content.Add(""); //PI_QTD
            content.Add(""); //PI_VRUNIT

            string strContent = "";

            foreach (string item in content)
            {
                if (strContent.Length > 0)
                {
                    strContent = string.Concat(strContent, ";");                    
                }
                        
                strContent = string.Concat(strContent, item);
            };

            return strContent;
        }

        private string parsePedidoItem(JObject node)
        {
            JToken items = node["itempedidos"];
            List<string> listItems = new List<string>();
            string strItems = "";

            foreach (var item in items)
            {
                if (node["getpedido"]["pedido"]["order_id"].ToString() == "9000909")
                {
                    this.txtLog.AppendText("passou aqui");
                    this.txtLog.AppendText(Environment.NewLine);
                }

                listItems.Add(node["getpedido"]["pedido"]["order_id"].ToString());
                listItems.Add(node["getpedido"]["pedido"]["datavenda"].ToString());
                listItems.Add("");
                listItems.Add(item["codigoproduto"].ToString());
                listItems.Add(item["qtde"].ToString());
                listItems.Add(item["valorunitario"].ToString());

                string strLine = "";

                foreach (string field in listItems)
                {
                    if (strLine.Length > 0)
                    {
                        strLine = string.Concat(strLine, ";");
                    }

                    strLine = string.Concat(strLine, field);
                }

                strItems = string.Concat(strItems, strLine, Environment.NewLine);
                listItems.Clear();
            }

            return strItems;
        }

        private void FileDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.txtFile.Text = this.FileDialog.FileName;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            this.FileDialog.InitialDirectory = @ConfigurationManager.AppSettings["produtoCsvPath"];
            this.FileDialog.Filter = "CSV files (*.csv)|*.csv|Excel Files|*.xls;*.xlsx";
            this.FileDialog.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtEstoque.TextLength == 0)
            {
                MessageBox.Show("Selecione o arquivo que será importado!");
                return;
            }

            if (!File.Exists(txtEstoque.Text))
            {
                MessageBox.Show("O arquivo selecionado não existe!");
                return;
            }

            this.txtLog.Text = "";
            this.txtLog.Text = "Importando estoque...";
            this.lerArquivoCsvEstoque(this.txtEstoque.Text);
            txtLog.AppendText("Fim da importação do estoque");
        }

        private string postEstoque(string json)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://comercializacaoapi.pitstop.com.br/wsintegracao/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var contentString = new StringContent(json, Encoding.UTF8, "application/json");
                contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

               HttpResponseMessage response = client.PostAsync("PostEstoque?token=" + ConfigurationManager.AppSettings["token"] + "&login=" + ConfigurationManager.AppSettings["login"], contentString).Result;
               string resultContent = response.Content.ReadAsStringAsync().Result;
               return resultContent;
            }
        }

        private string getJsonEstoque(string[] estoque)
        {
            return "{" +
                "   \"postestoque\": [" +
                "       {" +
                "           \"SKU\": \"" + estoque[0] + "\"," +
                "           \"estoque\": \"" + estoque[1] + "\"" +
                "       }" +
                "   ]" +
                "}";
        }

        private void lerArquivoCsvEstoque(string file)
        {
            string log = "";
            string logJson = "";

            using (StreamReader reader = new StreamReader(@file))
            {
                string linha = reader.ReadLine();
                string[] data = null;

                while (reader.Peek() != -1)
                {
                    linha = reader.ReadLine();
                    data = linha.Split(';');

                    if (data[0] == "sku" || data[0].Length == 0) continue;

                    string json = this.getJsonEstoque(data);
                    string response = this.postEstoque(json);

                    this.txtLog.AppendText(String.Concat(data[0], "-", data[1], Environment.NewLine, response, Environment.NewLine, Environment.NewLine));

                    logJson = String.Concat(logJson, json, Environment.NewLine);

                    log = String.Concat(
                        log,
                        data[0],
                        "|",
                        data[1],
                        Environment.NewLine,
                        response,
                        Environment.NewLine,
                        Environment.NewLine
                    );
                }
            }

            if (log.Length > 0)
            {
                string fileName = String.Concat(ConfigurationManager.AppSettings["LogCsvPath"], Util.fileUniqueName(), "-estoque.txt");
                File.WriteAllText(@fileName, String.Concat(logJson, Environment.NewLine, Environment.NewLine, log));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.EstoqueDialog.InitialDirectory = @ConfigurationManager.AppSettings["estoqueCsvPath"];
            this.EstoqueDialog.Filter = "CSV files (*.csv)|*.csv|Excel Files|*.xls;*.xlsx";
            this.EstoqueDialog.ShowDialog();
        }

        private void EstoqueDialog_FileOk(object sender, CancelEventArgs e)
        {
            this.txtEstoque.Text = this.EstoqueDialog.FileName;
        }
    }
}
