using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSystem
{
    class CadastraProdutos
    {
        public CadastraProdutos()
        {
            this.IdProduto = 0;
            this.IdProdutoDescricao = 0;
            this.IdEstoque = 0;
            this.IdItemVenda = 0;
            this.IdFornecedor = 0;
            this.IdMarca = 0;
            this.IdCategoriaProduto = 0;
            this.PrecoCusto = 0;
            DateTime Data_Compra = DateTime.Now;
            string Data_CompraFormato = Data_Compra.ToString("MM/dd/yyyy");
            this.Data_Compra = Data_Compra;
            this.Ativo = 0;
            this.ImprimirProduto = 0;
            this.Unidade = 0;
            this.Quant_Estoque = 0;
            this.Quant_Minima = 0;
            this.Observacao = "";
            this.CodInterno = 0;
            this.Cts_Csosn = 0;
            this.Cest = 0;
            this.Aliquota_Icms = 0;
            this.BaseCalculoIcms = 0;
            this.Ncm = 0;
            this.IdAliquotaIpi = 0;
            this.ValorUnitario = 0;
            this.Versao = 0;
            this.PrecoVenda = 0;
            this.MargemLucro = 0;
            DateTime DataReajuste = DateTime.Now;
            string DataReajusteFormato = DataReajuste.ToString("MM/dd/yyyy");
            this.DataReajuste = DataReajuste;
            this.CodigoGtin = 0;
            this.PesoBruto = 0;
            this.PesoLiquido = 0;
            DateTime PrevisaoChegada = DateTime.Now;
            string PrevisaoChegadaFormato = PrevisaoChegada.ToString("MM/dd/yyyy");
            this.PrevisaoChegada = PrevisaoChegada;
            this.OrigemProduto = "";
            this.IdUnidadeProduto = 0;
            this.ValorIcms = 0;
            this.ValorPis = 0;
            this.ValorCofins = 0;
            this.DescricaoCstIcms = 0;
            this.DescricaoCstPis = 0;
            this.DescricaoCofins = 0;
            this.DescricaoCstIpi = 0;
            this.QuantComprada = 0;

        }
        public CadastraProdutos(int ID_PRODUTO, int ID_ESTOQUE, int ID_ITEM_VENDA, int ID_FORNECEDOR, int ID_MARCA, int ID_CATEGORIA_PRODUTO, int ID_PRODUTO_DESCRICAO, decimal PRECO_CUSTO,
            DateTime DATA_COMPRA, int ATIVO, int IMPRIMIR_PRODUTO, int UNIDADE, int QUANT_ESTOQUE, int QUANT_MINIMA, string OBSERVACAO, int CODIGO_INTERNO, decimal CST_CSOSN, decimal CEST,
            decimal ALIQUOTA_ICMS, decimal BASE_CALCULO_ICMS, int NCM, decimal ID_ALIQUOTA_IPI, decimal VALOR_UNITARIO, float VERSAO, decimal PRECO_VENDA, decimal MARGEM_LUCRO, DateTime DATA_REAJUSTE,
             int CODIGO_GTIN, decimal PESO_BRUTO, decimal PESO_LIQUIDO ,DateTime PREVISAO_CHEGADA, string ORIGEM_PRODUTO, int IDUNIDADE_PRODUTO, decimal VALOR_ICMS, decimal VALOR_PIS, decimal COFINS, 
             decimal DESCRICAO_CST_ICMS, decimal DESCRICAO_CST_PIS,decimal DESCRICAO_CST_COFINS,decimal DESCRICAO_CST_IPI, int QUANTIDADE_COMPRADA)
        {

            this.IdProduto = ID_PRODUTO;
            this.IdProdutoDescricao = ID_PRODUTO_DESCRICAO;
            this.IdEstoque = ID_ESTOQUE;
            this.IdItemVenda = ID_ITEM_VENDA;
            this.IdFornecedor = ID_FORNECEDOR;
            this.IdMarca = ID_MARCA;
            this.IdCategoriaProduto = ID_CATEGORIA_PRODUTO;
            this.PrecoCusto = PRECO_CUSTO;
            this.Data_Compra = DATA_COMPRA;
            this.Ativo = ATIVO;
            this.ImprimirProduto = IMPRIMIR_PRODUTO;
            this.Unidade = UNIDADE;
            this.Quant_Estoque = QUANT_ESTOQUE;
            this.Quant_Minima = QUANT_MINIMA;
            this.Observacao = OBSERVACAO;
            this.CodInterno = CODIGO_INTERNO;
            this.Cts_Csosn = CST_CSOSN;
            this.Cest = CEST;
            this.Aliquota_Icms = ALIQUOTA_ICMS;
            this.BaseCalculoIcms = BASE_CALCULO_ICMS;
            this.Ncm = NCM;
            this.IdAliquotaIpi = ID_ALIQUOTA_IPI;
            this.ValorUnitario = VALOR_UNITARIO;
            this.Versao = VERSAO;
            this.PrecoVenda = PRECO_VENDA;
            this.MargemLucro = MARGEM_LUCRO;
            this.DataReajuste = DATA_REAJUSTE;
            this.CodigoGtin = CODIGO_GTIN;
            this.PesoBruto = PESO_BRUTO;
            this.PesoLiquido = PESO_LIQUIDO;
            this.PrevisaoChegada = PREVISAO_CHEGADA;
            this.OrigemProduto = ORIGEM_PRODUTO;
            this.IdUnidadeProduto = IDUNIDADE_PRODUTO;
            this.ValorIcms = VALOR_ICMS;
            this.ValorPis = VALOR_PIS;
            this.ValorCofins = COFINS;
            this.DescricaoCstIcms = DESCRICAO_CST_ICMS;
            this.DescricaoCstPis = DESCRICAO_CST_PIS;
            this.DescricaoCofins = DESCRICAO_CST_COFINS;
            this.DescricaoCstIpi = DESCRICAO_CST_IPI;
            this.QuantComprada = QUANTIDADE_COMPRADA;
        }

        private int ID_PRODUTO;
        public int IdProduto
        {
            get
            {
                return this.ID_PRODUTO;

            }
            set
            {
                this.ID_PRODUTO = value;
            }
        }

        private int ID_ESTOQUE;
        public int IdEstoque
        {
            get
            {
                return this.ID_ESTOQUE;

            }
            set
            {
                this.ID_ESTOQUE = value;
            }
        }
        private int ID_ITEM_VENDA;
        public int IdItemVenda
        {
            get
            {
                return this.ID_ITEM_VENDA;

            }
            set
            {
                this.ID_ITEM_VENDA = value;
            }
        }
        private int ID_FORNECEDOR;
        public int IdFornecedor
        {
            get
            {
                return this.ID_FORNECEDOR;

            }
            set
            {
                this.ID_FORNECEDOR = value;
            }
        }
        private int ID_MARCA;
        public int IdMarca
        {
            get
            {
                return this.ID_MARCA;

            }
            set
            {
                this.ID_MARCA = value;
            }
        }
        private int ID_CATEGORIA_PRODUTO;
        public int IdCategoriaProduto
        {
            get
            {
                return this.ID_CATEGORIA_PRODUTO;

            }
            set
            {
                this.ID_CATEGORIA_PRODUTO = value;
            }
        }
        private int ID_PRODUTO_DESCRICAO;
        public int IdProdutoDescricao
        {
            get
            {
                return this.ID_PRODUTO_DESCRICAO;

            }
            set
            {
                this.ID_PRODUTO_DESCRICAO = value;
            }
        }
        private decimal PRECO_CUSTO;
        public decimal PrecoCusto
        {
            get
            {
                return this.PRECO_CUSTO;

            }
            set
            {
                this.PRECO_CUSTO = value;
            }
        }

        private DateTime DATA_COMPRA;
        public DateTime Data_Compra
        {
            get
            {
                return this.DATA_COMPRA;

            }
            set
            {
                this.DATA_COMPRA = value;
            }
        }
        private int ATIVO;
        public int Ativo
        {
            get
            {
                return this.ATIVO;

            }
            set
            {
                this.ATIVO = value;
            }
        }

        private string OBSERVACAO;
        public string Observacao
        {
            get
            {
                return this.OBSERVACAO;

            }
            set
            {
                this.OBSERVACAO = value;
            }
        }

        private int IMPRIMIR_PRODUTO;
        public int ImprimirProduto
        {
            get
            {
                return this.IMPRIMIR_PRODUTO;

            }
            set
            {
                this.IMPRIMIR_PRODUTO = value;
            }

        }

        private int UNIDADE;
        public int Unidade
        {
            get
            {
                return this.UNIDADE;

            }
            set
            {
                this.UNIDADE = value;
            }
        }

        private int QUANT_ESTOQUE;
        public int Quant_Estoque
        {
            get
            {
                return this.QUANT_ESTOQUE;

            }
            set
            {
                this.QUANT_ESTOQUE = value;
            }
        }

        private int QUANT_MINIMA;
        public int Quant_Minima
        {
            get
            {
                return this.QUANT_MINIMA;

            }
            set
            {
                this.QUANT_MINIMA = value;
            }
        }

        private int CODIGO_INTERNO;
        public int CodInterno
        {
            get
            {
                return this.CODIGO_INTERNO;

            }
            set
            {
                this.CODIGO_INTERNO = value;
            }
        }

        private decimal CST_CSOSN;
        public decimal Cts_Csosn
        {
            get
            {
                return this.CST_CSOSN;

            }
            set
            {
                this.CST_CSOSN = value;
            }
        }

        private decimal CEST;
        public decimal Cest
        {
            get
            {
                return this.CEST;

            }
            set
            {
                this.CEST = value;
            }
        }

        private decimal ALIQUOTA_ICMS;
        public decimal Aliquota_Icms
        {
            get
            {
                return this.ALIQUOTA_ICMS;

            }
            set
            {
                this.ALIQUOTA_ICMS = value;
            }
        }
        private decimal BASE_CALCULO_ICMS;
        public decimal BaseCalculoIcms
        {
            get
            {
                return this.BASE_CALCULO_ICMS;

            }
            set
            {
                this.BASE_CALCULO_ICMS = value;
            }
        }
        private int NCM;
        public int Ncm
        {
            get
            {
                return this.NCM;

            }
            set
            {
                this.NCM = value;
            }
        }
        private decimal ID_ALIQUOTA_IPI;
        public decimal IdAliquotaIpi
        {
            get
            {
                return this.ID_ALIQUOTA_IPI;

            }
            set
            {
                this.ID_ALIQUOTA_IPI = value;
            }
        }
        private decimal VALOR_UNITARIO;
        public decimal ValorUnitario
        {
            get
            {
                return this.VALOR_UNITARIO;

            }
            set
            {
                this.VALOR_UNITARIO = value;
            }
        }
        private float VERSAO;
        public float Versao
        {
            get
            {
                return this.VERSAO;

            }
            set
            {
                this.VERSAO = value;
            }
        }
        private decimal PRECO_VENDA;
        public decimal PrecoVenda
        {
            get
            {
                return this.PRECO_VENDA;

            }
            set
            {
                this.PRECO_VENDA = value;
            }
        }
        private decimal MARGEM_LUCRO;
        public decimal MargemLucro
        {
            get
            {
                return this.MARGEM_LUCRO;

            }
            set
            {
                this.MARGEM_LUCRO = value;
            }
        }
        private DateTime DATAREAJUSTE;
        public DateTime DataReajuste
        {
            get
            {
                return this.DATAREAJUSTE;

            }
            set
            {
                this.DATAREAJUSTE = value;
            }
        }
        private int CODIGO_GTIN;
        public int CodigoGtin
        {
            get
            {
                return this.CODIGO_GTIN;

            }
            set
            {
                this.CODIGO_GTIN = value;
            }
        }
        private decimal PESO_BRUTO;
        public decimal PesoBruto
        {
            get
            {
                return this.PESO_BRUTO;

            }
            set
            {
                this.PESO_BRUTO = value;
            }
        }
        private decimal PESO_LIQUIDO;
        public decimal PesoLiquido
        {
            get
            {
                return this.PESO_LIQUIDO;

            }
            set
            {
                this.PESO_LIQUIDO = value;
            }
        }
        private DateTime PREVISAO_CHEGADA;
        public DateTime PrevisaoChegada
        {
            get
            {
                return this.PREVISAO_CHEGADA;

            }
            set
            {
                this.PREVISAO_CHEGADA = value;
            }
        }
        private string ORIGEM_PRODUTO;
        public string OrigemProduto
        {
            get
            {
                return this.ORIGEM_PRODUTO;

            }
            set
            {
                this.ORIGEM_PRODUTO = value;
            }
        }
        private int IDUNIDADE_PRODUTO;
        public int IdUnidadeProduto
        {
            get
            {
                return this.IDUNIDADE_PRODUTO;

            }
            set
            {
                this.IDUNIDADE_PRODUTO = value;
            }
        }
        private int ID_CST_ICMS;
        public int IdCstIcms
        {
            get
            {
                return this.ID_CST_ICMS;

            }
            set
            {
                this.ID_CST_ICMS = value;
            }
        }
        private int ID_CST_PIS;
        public int IdCstPis
        {
            get
            {
                return this.ID_CST_PIS;

            }
            set
            {
                this.ID_CST_PIS = value;
            }
        }
        private int ID_CST_COFINS;
        public int IdCstCofins
        {
            get
            {
                return this.ID_CST_COFINS;

            }
            set
            {
                this.ID_CST_COFINS = value;
            }
        }
        private int ID_CST_IP;
        public int IdCstIpi
        {
            get
            {
                return this.ID_CST_IP;

            }
            set
            {
                this.ID_CST_IP = value;
            }
        }
        private decimal VALOR_ICMS;
        public decimal ValorIcms
        {
            get
            {
                return this.VALOR_ICMS;

            }
            set
            {
                this.VALOR_ICMS = value;
            }
        }
        private decimal VALOR_PIS;
        public decimal ValorPis
        {
            get
            {
                return this.VALOR_PIS;

            }
            set
            {
                this.VALOR_PIS = value;
            }
        }
        private decimal VALOR_COFINS;
        public decimal ValorCofins
        {
            get
            {
                return this.VALOR_COFINS;

            }
            set
            {
                this.VALOR_COFINS = value;
            }
        }
        private decimal PRECO_MEDIO;
        public decimal PrecoMedio
        {
            get
            {
                return this.PRECO_MEDIO;

            }
            set
            {
                this.PRECO_MEDIO = value;
            }
        }
        private decimal DESCRICAO_CST_ICMS;
        public decimal DescricaoCstIcms
        {
            get
            {
                return this.DESCRICAO_CST_ICMS;

            }
            set
            {
                this.DESCRICAO_CST_ICMS = value;
            }
        }
        private decimal DESCRICAO_CST_PIS;
        public decimal DescricaoCstPis
        {
            get
            {
                return this.DESCRICAO_CST_PIS;

            }
            set
            {
                this.DESCRICAO_CST_PIS = value;
            }
        }
        private decimal DESCRICAO_CST_COFINS;
        public decimal DescricaoCofins
        {
            get
            {
                return this.DESCRICAO_CST_COFINS;

            }
            set
            {
                this.DESCRICAO_CST_COFINS = value;
            }
        }
        private decimal DESCRICAO_CST_IPI;
        public decimal DescricaoCstIpi
        {
            get
            {
                return this.DESCRICAO_CST_IPI;

            }
            set
            {
                this.DESCRICAO_CST_IPI = value;
            }
        }
        private decimal VALOR_IPI;
        public decimal ValorIpi
        {
            get
            {
                return this.VALOR_IPI;

            }
            set
            {
                this.VALOR_IPI = value;
            }
        }
        private int QUANTIDADE_COMPRADA;
        public int QuantComprada
        {
            get
            {
                return this.QUANTIDADE_COMPRADA;

            }
            set
            {
                this.QUANTIDADE_COMPRADA = value;
            }
        }
    }
}