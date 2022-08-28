using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSystem
{
    class MarcaECartegoria
    {
        public MarcaECartegoria()
        {
            this.Marca = "";
            this.DescricaoMarca = "";
            this.Categoria = "";
            this.DescricaoCategoria = "";
            this.Produto = "";
            this.DescricaoProduto = "";

        }
        public MarcaECartegoria(string MARCA, string DESCRICAO_MARCA, string CATEGORIA, string DESCRICAOCATEGORIA, string PRODUTO, string DESCRICAOPRODUTO)
        {
            this.Marca = MARCA;
            this.DescricaoMarca = DESCRICAO_MARCA;
            this.Categoria = CATEGORIA;
            this.DescricaoCategoria = DESCRICAOCATEGORIA;
            this.Produto = PRODUTO;
            this.DescricaoProduto = DESCRICAOPRODUTO;
        }

        private string MARCA;
        public string Marca
        {
            get
            {
                return this.MARCA;

            }
            set
            {
                this.MARCA = value;
            }
        }

        private string DESCRICAO_MARCA;
        public string DescricaoMarca
        {
            get
            {
                return this.DESCRICAO_MARCA;

            }
            set
            {
                this.DESCRICAO_MARCA = value;
            }
        }

        private string CATEGORIA;
        public string Categoria
        {
            get
            {
                return this.CATEGORIA;

            }
            set
            {
                this.CATEGORIA = value;
            }
        }
        private string DESCRICAOCATEGORIA;
        public string DescricaoCategoria
        {
            get
            {
                return this.DESCRICAOCATEGORIA;

            }
            set
            {
                this.DESCRICAOCATEGORIA = value;
            }
        }
        private string PRODUTO;
        public string Produto
        {
            get
            {
                return this.PRODUTO;

            }
            set
            {
                this.PRODUTO = value;
            }
        }
        private string DESCRICAOPRODUTO;
        public string DescricaoProduto
        {
            get
            {
                return this.DESCRICAOPRODUTO;

            }
            set
            {
                this.DESCRICAOPRODUTO = value;
            }
        }
    }
}
