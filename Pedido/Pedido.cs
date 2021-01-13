using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboPitStop.Pedido
{
    class Pedido
    {
        public static string getCabecalho()
        {
            List<string> cabecalho = new List<string>();
            cabecalho.Add("ID_PEDIDO");
            cabecalho.Add("DT_PEDIDO");
            cabecalho.Add("PEDIDO");
            cabecalho.Add("CONDICAO");
            cabecalho.Add("TRANSPORTA");
            cabecalho.Add("C_CPFCNPJ");
            cabecalho.Add("C_RGIE");
            cabecalho.Add("C_TP");
            cabecalho.Add("C_NOME");
            cabecalho.Add("C_EMAIL");
            cabecalho.Add("C_FONE");
            cabecalho.Add("CE_CEP");
            cabecalho.Add("CE_LOGR");
            cabecalho.Add("CE_NUMERO");
            cabecalho.Add("CE_COMP");
            cabecalho.Add("CE_BAIRRO");
            cabecalho.Add("CE_CIDADE");
            cabecalho.Add("CE_UF");
            cabecalho.Add("PI_SKU");
            cabecalho.Add("PI_QTD");
            cabecalho.Add("PI_VRUNIT");

            string strCabecalho = "";

            foreach (string item in cabecalho)
            {
                if (strCabecalho.Length > 0)
                {
                    strCabecalho = string.Concat(strCabecalho, ";");
                }

                strCabecalho = string.Concat(strCabecalho, item);
            }

            return strCabecalho;
        }

        public static string getCabecalhoItem()
        {
            List<string> cabecalho = new List<string>();
            cabecalho.Add("ID_PEDIDO");
            cabecalho.Add("DT_PEDIDO");
            cabecalho.Add("PEDIDO");
            cabecalho.Add("PI_SKU");
            cabecalho.Add("PI_QTD");
            cabecalho.Add("PI_VRUNIT");

            string strCabecalho = "";

            foreach (string item in cabecalho)
            {
                if (strCabecalho.Length > 0)
                {
                    strCabecalho = string.Concat(strCabecalho, ";");
                }

                strCabecalho = string.Concat(strCabecalho, item);
            }

            return strCabecalho;
        }
    }
}
