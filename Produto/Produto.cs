using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboPitStop.Produto;

namespace RoboPitStop.Produto
{
    class Produtos
    {
        public List<ProdutoDepartamento> departamento;
        public List<ProdutoSecao> secao;
        public List<ProdutoAtributo> atributo;
        public List<ProdutoPropriedades> produto;
    }

    class ProdutosPost
    {
        public Produtos postproduto;
    }
}
