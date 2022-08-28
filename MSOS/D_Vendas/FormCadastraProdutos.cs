using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.IO;
using System.Globalization;
using System.Drawing.Printing;

namespace DateSystem
{
    public partial class FormCadastraProdutos : Form
    {
        DataTable TableProduto;
        DataTable TableMarca;
        DataTable TableCategoria;
        DataTable TableCFornecedor;
        Bitmap bmp;
        Bitmap bmp2;

        private Image IMAGEM = null;
        public Image Imagem
        {
            get
            {
                return this.IMAGEM;

            }
            set
            {
                this.IMAGEM = value;
            }
        }
        private Image IMAGEM2 = null;
        public Image Imagem2
        {
            get
            {
                return this.IMAGEM2;

            }
            set
            {
                this.IMAGEM2 = value;
            }
        }
        private string IMGLOCATION = "";
        public string ImgLocation
        {
            get
            {
                return this.IMGLOCATION;

            }
            set
            {
                this.IMGLOCATION = value;
            }
        }
        private string IMGLOCATION2 = "";
        public string ImgLocation2
        {
            get
            {
                return this.IMGLOCATION2;

            }
            set
            {
                this.IMGLOCATION2 = value;
            }
        }
        private int VALORPESQUISA = 0;
        public int ValorPesquisa
        {
            get
            {
                return this.VALORPESQUISA;

            }
            set
            {
                this.VALORPESQUISA = value;
            }
        }
        private int ID_PRODUTO_IMAGEM = 0;
        public int IdProdutoImagem
        {
            get
            {
                return this.ID_PRODUTO_IMAGEM;

            }
            set
            {
                this.ID_PRODUTO_IMAGEM = value;
            }
        }
        private int IDMARCPRODUTO = 0;
        public int IdMarcaProduto
        {
            get
            {
                return this.IDMARCPRODUTO;

            }
            set
            {
                this.IDMARCPRODUTO = value;
            }
        }
        private int IDMARCAPRODUTOCATEGORIA = 0;
        public int IdMarcaProdutoCategoria
        {
            get
            {
                return this.IDMARCAPRODUTOCATEGORIA;

            }
            set
            {
                this.IDMARCAPRODUTOCATEGORIA = value;
            }
        }
        private int IDMARCFORNECEDOR = 0;
        public int IdMarcaFornecedor
        {
            get
            {
                return this.IDMARCFORNECEDOR;

            }
            set
            {
                this.IDMARCFORNECEDOR = value;
            }
        }
        private int IDORIGEMPRODUTO = 0;
        public int IdOrigemProduto
        {
            get
            {
                return this.IDORIGEMPRODUTO;

            }
            set
            {
                this.IDORIGEMPRODUTO = value;
            }
        }
        private int IDUNIDADEPRODUTO = 0;
        public int IdUnidadeProduto
        {
            get
            {
                return this.IDUNIDADEPRODUTO;

            }
            set
            {
                this.IDUNIDADEPRODUTO = value;
            }
        }
        private int ID_CST_ICMS = 0;
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
        private int ID_CST_PIS = 0;
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
        private int ID_CST_COFINS = 0;
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
        private int ID_CST_IP = 0;
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
        private string TEMP_CUSTO;
        public string TempCusto
        {
            get
            {
                return this.TEMP_CUSTO;

            }
            set
            {
                this.TEMP_CUSTO = value;
            }
        }
        private string TEMP_LUCRO;
        public string TempLucro
        {
            get
            {
                return this.TEMP_LUCRO;

            }
            set
            {
                this.TEMP_LUCRO = value;
            }
        }
        //private string TEMP_MEDIO;
        //public string TempMedio
        //{
        //    get
        //    {
        //        return this.TEMP_MEDIO;

        //    }
        //    set
        //    {
        //        this.TEMP_MEDIO = value;
        //    }
        //}
        private string TEMP_VENDA;
        public string TempVenda
        {
            get
            {
                return this.TEMP_VENDA;

            }
            set
            {
                this.TEMP_VENDA = value;
            }
        }
        private int IDDESCRICAOPRODUTO = 0;
        public int IdDescricaoProduto
        {
            get
            {
                return this.IDDESCRICAOPRODUTO;

            }
            set
            {
                this.IDDESCRICAOPRODUTO = value;
            }
        }
        private int CADASTRAGTIN = 0;
        public int CadastraGtin
        {
            get
            {
                return this.CADASTRAGTIN;

            }
            set
            {
                this.CADASTRAGTIN = value;
            }
        }

        //--------------------------------------------------------
        private string NOMESERVIDOR = "";
        public string NomeServidor
        {
            get
            {
                return this.NOMESERVIDOR;

            }
            set
            {
                this.NOMESERVIDOR = value;
            }
        }
        private string BASE_DADOS = "";
        public string BaseDados
        {
            get
            {
                return this.BASE_DADOS;

            }
            set
            {
                this.BASE_DADOS = value;
            }
        }
        private string NOMEBASEDADOS = "";
        public string NomeBaseDados
        {
            get
            {
                return this.NOMEBASEDADOS;

            }
            set
            {
                this.NOMEBASEDADOS = value;
            }
        }
        private string NOMEUSUARIO = "";
        public string NomeUsuario
        {
            get
            {
                return this.NOMEUSUARIO;

            }
            set
            {
                this.NOMEUSUARIO = value;
            }
        }
        private string SENHABASEDADOS = "";
        public string SenhaBaseDados
        {
            get
            {
                return this.SENHABASEDADOS;

            }
            set
            {
                this.SENHABASEDADOS = value;
            }
        }

        private string CONNECTIONSTRING = "";
        public string connetionString
        {
            get
            {
                return this.CONNECTIONSTRING;

            }
            set
            {
                this.CONNECTIONSTRING = value;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean DescricaoProduto(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtDescricaoProduto.Text))
            {
                errorProviderCadastroProduto.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroProduto.SetError(textBox, "Descrição Vazia!");
                return false;
            }

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean PrecoCusto(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtPrecoCusto.Text))
            {
                errorProviderCadastroProduto.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroProduto.SetError(textBox, "Custo Vazia!");
                return false;
            }

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean PrecoVenda(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtPrecoVenda.Text))
            {
                errorProviderCadastroProduto.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroProduto.SetError(textBox, "Venda Vazia!");
                return false;
            }

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean MargemLucro(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtMargemLucro.Text))
            {
                errorProviderCadastroProduto.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroProduto.SetError(textBox, "Lucro Vazia!");
                return false;
            }

        }       // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean CustoMedio(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCustoMedio.Text))
            {
                errorProviderCadastroProduto.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroProduto.SetError(textBox, "Custo Medio Vazia!");
                return false;
            }

        }
        private Boolean QuantAtual(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtQuantidadeAtualEstoque.Text))
            {
                errorProviderCadastroProduto.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroProduto.SetError(textBox, "Quantidade M Vazia!");
                return false;
            }

        }
        private Boolean QuantMinima(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtQuantidadeMinimaEstoque.Text))
            {
                errorProviderCadastroProduto.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroProduto.SetError(textBox, "Quantidade minima Vazia!");
                return false;
            }

        }
        public FormCadastraProdutos(string NOMESERVIDOR, string NOMEBASEDADOS, string NOMEUSUARIO, string SENHABASEDADOS)
        {
            InitializeComponent();

            this.NomeServidor = NOMESERVIDOR;

            this.NomeBaseDados = NOMEBASEDADOS;

            this.NomeUsuario = NOMEUSUARIO;

            this.SenhaBaseDados = SENHABASEDADOS;

            label13.Text = "Data do último  \n reajuste de preços:";

            label14.Text = "Quantidade \natual em estoque:";

            label15.Text = "Quantidade \nMínima em estoque:";

            checkBoxnaoImprimir.Text = "Não Imprimir este Produto \nna Tabela de Preços:";

            dateTimePickerUltimoReajuste.Value = DateTime.Now.Date;

            dateTimePickerSolicitacao.Value = DateTime.Now.Date;

            dateTimePickerPrevisaoChegada.Value = DateTime.Now.Date;
            
            this.connetionString = "Data Source=" + this.NomeServidor + ";Initial Catalog=" + this.NomeBaseDados + ";Persist Security Info=True;User ID=" + this.NomeUsuario + ";Password=" + this.SenhaBaseDados + ";";

            AcionarComboBox();

            //Verifica Itens já cadastrados!
            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_V_ConsultaMarcaProdutoConstaTxt '" + txtCadastroMarca.Text + "';", conn);

            DataSet ds = new DataSet();
            da.Fill(ds);
        }

        private void FormCadastraProdutos_Load(object sender, EventArgs e)
        {

        }
        public void ObjetosCadastrados()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);

            if ((radioButtonProduto.Checked ==false) && (radioButtonMarca.Checked == false) && (radioButtonCartegoria.Checked == false) 
                && (radioButtonFornecedor.Checked == false))
            {
                MessageBox.Show("A pesquisa tem que ter um dos itens na parte de cima selecionado");
            }
            if (radioButtonProduto.Checked == true)
            {
                if(txtConsultarItens.Text == "")
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Exec D_V_ConsultaProdutoNomeProduto;", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewObjetosItens.DataSource == null)
                        {
                            dataGridViewObjetosItens.Refresh();
                        }
                        if (!(dataGridViewObjetosItens.DataSource == null))
                        {
                            //dataGridViewPesquisa.Columns.Clear();
                            dataGridViewObjetosItens.Refresh();
                        }
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        MessageBox.Show("Nem um Registro de OS Achado!");

                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ValorPesquisa = 1;
                        dataGridViewPesquisaProdutosNome();
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        conn.Close();
                    }
                }
                if (!(txtConsultarItens.Text == ""))
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Exec D_V_ConsultaProdutoNomeProdutoConstaTxt '" + txtConsultarItens.Text +"';", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewObjetosItens.DataSource == null)
                        {
                            dataGridViewObjetosItens.Refresh();
                        }
                        if (!(dataGridViewObjetosItens.DataSource == null))
                        {
                            //dataGridViewPesquisa.Columns.Clear();
                            dataGridViewObjetosItens.Refresh();
                        }
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        MessageBox.Show("Nem um Registro de OS Achado!");

                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ValorPesquisa = 1;
                        dataGridViewPesquisaProdutosNome();
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        conn.Close();
                    }
                }
            }
            if (radioButtonMarca.Checked == true)
            {
                if (txtConsultarItens.Text == "")
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Exec D_V_ConsultaMarcaProduto;", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewObjetosItens.DataSource == null)
                        {
                            dataGridViewObjetosItens.Refresh();
                        }
                        if (!(dataGridViewObjetosItens.DataSource == null))
                        {
                            //dataGridViewPesquisa.Columns.Clear();
                            dataGridViewObjetosItens.Refresh();
                        }
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        MessageBox.Show("Nem um Registro de OS Achado!");

                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ValorPesquisa = 1;
                        dataGridViewPesquisaMarcasNome();
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        conn.Close();
                    }
                }
                if (!(txtConsultarItens.Text == ""))
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Exec D_V_ConsultaMarcaProdutoConstaTxt '" + txtConsultarItens.Text + "';", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewObjetosItens.DataSource == null)
                        {
                            dataGridViewObjetosItens.Refresh();
                        }
                        if (!(dataGridViewObjetosItens.DataSource == null))
                        {
                            //dataGridViewPesquisa.Columns.Clear();
                            dataGridViewObjetosItens.Refresh();
                        }
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        MessageBox.Show("Nem um Registro de OS Achado!");

                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ValorPesquisa = 1;
                        dataGridViewPesquisaMarcasNome();
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        conn.Close();
                    }
                }
            }
            if (radioButtonCartegoria.Checked == true)
            {
                if (txtConsultarItens.Text == "")
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Exec D_V_ConsultaCategoriaProduto;", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewObjetosItens.DataSource == null)
                        {
                            dataGridViewObjetosItens.Refresh();
                        }
                        if (!(dataGridViewObjetosItens.DataSource == null))
                        {
                            //dataGridViewPesquisa.Columns.Clear();
                            dataGridViewObjetosItens.Refresh();
                        }
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        MessageBox.Show("Nem um Registro de OS Achado!");

                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ValorPesquisa = 1;
                        dataGridViewPesquisaCategoriaNome();
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        conn.Close();
                    }
                }
                if (!(txtConsultarItens.Text == ""))
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Exec D_V_ConsultaCategoriaProdutoConstaTxt '" + txtConsultarItens.Text + "';", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewObjetosItens.DataSource == null)
                        {
                            dataGridViewObjetosItens.Refresh();
                        }
                        if (!(dataGridViewObjetosItens.DataSource == null))
                        {
                            //dataGridViewPesquisa.Columns.Clear();
                            dataGridViewObjetosItens.Refresh();
                        }
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        MessageBox.Show("Nem um Registro de OS Achado!");

                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ValorPesquisa = 1;
                        dataGridViewPesquisaCategoriaNome();
                        label8.Text = dataGridViewObjetosItens.RowCount.ToString();
                        conn.Close();
                    }
                }
            }
            if (radioButtonFornecedor.Checked == true)
            {
                if (txtConsultarItens.Text == "")
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Exec D_V_ConsultaFornecedorCadastroVenda;", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewObjetosItens.DataSource == null)
                        {
                            dataGridViewObjetosItens.Refresh();
                        }
                        if (!(dataGridViewObjetosItens.DataSource == null))
                        {
                            //dataGridViewPesquisa.Columns.Clear();
                            dataGridViewObjetosItens.Refresh();
                        }
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        MessageBox.Show("Nem um Registro de OS Achado!");

                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ValorPesquisa = 1;
                        dataGridViewPesquisaFornecedorNome();
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        conn.Close();
                    }
                }
                if (!(txtConsultarItens.Text == ""))
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Exec D_V_ConsultaFornecedorCadastroVendatxt '" + txtConsultarItens.Text + "';", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewObjetosItens.DataSource == null)
                        {
                            dataGridViewObjetosItens.Refresh();
                        }
                        if (!(dataGridViewObjetosItens.DataSource == null))
                        {
                            //dataGridViewPesquisa.Columns.Clear();
                            dataGridViewObjetosItens.Refresh();
                        }
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        MessageBox.Show("Nem um Registro de OS Achado!");

                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        ValorPesquisa = 1;
                        dataGridViewPesquisaFornecedorNome();
                        label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
                        conn.Close();
                    }
                }
            }

        }
        //PRODUTOS
        void dataGridViewPesquisaProdutosNome()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);
            SqlCommand command = new SqlCommand("Exec D_V_ConsultaProdutoNomeProduto;", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                TableProduto = new DataTable();
                adapter.Fill(TableProduto);
                BindingSource Source = new BindingSource();
                Source.DataSource = TableProduto;
                dataGridViewObjetosItens.DataSource = Source;
                adapter.Update(TableProduto);
                connection.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //MARCAS
        void dataGridViewPesquisaMarcasNome()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);
            SqlCommand command = new SqlCommand("Exec D_V_ConsultaMarcaProduto;", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                TableMarca = new DataTable();
                adapter.Fill(TableMarca);
                BindingSource Source = new BindingSource();
                Source.DataSource = TableMarca;
                dataGridViewObjetosItens.DataSource = Source;
                adapter.Update(TableMarca);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //CATEGORIA
        void dataGridViewPesquisaCategoriaNome()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);
            SqlCommand command = new SqlCommand("Exec D_V_ConsultaCategoriaProduto;", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                TableCategoria = new DataTable();
                adapter.Fill(TableCategoria);
                BindingSource Source = new BindingSource();
                Source.DataSource = TableCategoria;
                dataGridViewObjetosItens.DataSource = Source;
                adapter.Update(TableCategoria);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //FORNECEDOR
        void dataGridViewPesquisaFornecedorNome()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);
            SqlCommand command = new SqlCommand("Exec D_V_ConsultaFornecedorCadastroVenda;", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                TableCFornecedor = new DataTable();
                adapter.Fill(TableCFornecedor);
                BindingSource Source = new BindingSource();
                Source.DataSource = TableCFornecedor;
                dataGridViewObjetosItens.DataSource = Source;
                adapter.Update(TableCFornecedor);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        public void AcionarComboBox()
        {
            comboBoxDescricaoProduto.Items.Clear();

            Fill_listBoxDescricaoProduto();

            comboBoxMarca.Items.Clear();

            Fill_listBoxMarcaProduto();

            comboBoxCartegoria.Items.Clear();

            Fill_listBoxCategoriaProduto();

            comboBoxFornecedor.Items.Clear();

            Fill_listBoxMarcaFornecedor();

            //Fill_listBoxOrigemProduto();

            comboBoxUnidade.Items.Clear();

            Fill_listBoxUnidade();

            comboBoxCstIcms.Items.Clear();

            Fill_listBoxCstIcms();

            comboBoxCstPis.Items.Clear();

            Fill_listBoxCstPis();

            comboBoxCstCofins.Items.Clear();

            Fill_listBoxCstCofins();

            comboBoxCstIpI.Items.Clear();

            Fill_listBoxCstIpi();

        }
        public void AlteraBotoes(int entrada)
        {
            if (entrada == 1)
            {
                txtCodigoProduto.Enabled = false;
                txtNitensCadastrados.Enabled = false;
                //txtDescricaoProduto.Enabled = false;
                comboBoxCartegoria.Enabled = false;
                comboBoxFornecedor.Enabled = false;
                comboBoxMarca.Enabled = false;
                comboBoxDescricaoProduto.Enabled = false;
                PainelFinanceiro.Enabled = false;
                PainelFisico.Enabled = false;
                dateTimePickerSolicitacao.Enabled = false;
                buttonCadastraProdutos.Enabled = false;
                checkBoxnaoImprimir.Enabled = false;
                checkBoxAtivo.Enabled = false;
                txtCodigoInterno.Enabled = false;
                buttonCodigoBusca.Enabled = false;
                buttonMarcaECartegoria.Enabled = false;
                txtObservacao.Enabled = false;
                //txtCstIcms.Enabled = false;
                txtNcm.Enabled = false;
                txtBaseIcms.Enabled = false;
                buttonVerifica.Enabled = false;
                buttonCancelarMarcaECartegoria.Enabled = true;
                panelPesquisaObjetos.Enabled = false;



            }
            if (entrada == 2)
            {
                txtCodigoProduto.Enabled = true;
                txtNitensCadastrados.Enabled = true;
                txtDescricaoProduto.Enabled = true;
                comboBoxCartegoria.Enabled = true;
                comboBoxFornecedor.Enabled = true;
                comboBoxMarca.Enabled = true;
                comboBoxDescricaoProduto.Enabled = true;
                PainelFinanceiro.Enabled = true;
                PainelFisico.Enabled = true;
                dateTimePickerSolicitacao.Enabled = true;
                buttonCadastraProdutos.Enabled = true;
                checkBoxnaoImprimir.Enabled = true;
                checkBoxAtivo.Enabled = true;
                txtCodigoInterno.Enabled = true;
                buttonCodigoBusca.Enabled = true;
                buttonMarcaECartegoria.Enabled = true;
                txtObservacao.Enabled = true;
                //txtCstIcms.Enabled = true;
                txtNcm.Enabled = true;
                txtBaseIcms.Enabled = true;
                buttonVerifica.Enabled = true;
                buttonCancelarMarcaECartegoria.Enabled = false;

                comboBoxDescricaoProduto.Items.Clear();

                Fill_listBoxDescricaoProduto();

                comboBoxMarca.Items.Clear();

                Fill_listBoxMarcaProduto();

                comboBoxCartegoria.Items.Clear();

                Fill_listBoxCategoriaProduto();

            }
            if (entrada == 3)
            {
                txtCadastroMarca.Clear();
                txtCadastroCategoria.Clear();
                txtCadastroDescricaoMarca.Clear();
                txtDescricaoCategoria.Clear();
                txtCadastraProduto.Clear();
                txtDescricaoProduto.Clear();
            }
        
            if (entrada == 4)
            {
                buttonSalvarMarcaCategoria.Enabled = true;
                panelCadastraMarcaECartegiria.Enabled = true;
                buttonVerifica.Enabled = false;
                buttonCancelarcadastrousuario.Enabled = true;
                buttonFecharFuncionario.Enabled = true;
            }
            //button cadastra produto
            if (entrada == 5)
            {
                buttonSalvarMarcaCategoria.Enabled = false;
                panelCadastraMarcaECartegiria.Enabled = false;
                buttonVerifica.Enabled = true;
                buttonCancelarcadastrousuario.Enabled = true;
                buttonFecharFuncionario.Enabled = true;
                buttonCancelaProdutos.Enabled = true;
                panelPesquisaObjetos.Enabled = true;
            }
            if(entrada == 6)
            {
                panelCadastraGtin.Enabled = true;
                buttonCadastraGtin.Enabled = false;
                buttonCancelarGtin.Enabled = true;
                CadastraGtin = 1;
            }
            if (entrada == 7)
            {
                panelCadastraGtin.Enabled = false;
                buttonCadastraGtin.Enabled = true;
                buttonCancelarGtin.Enabled = false;
                CadastraGtin = 0;
                txtCodigoGtin.Clear();
                txtPesoBruto.Clear();
                txtPesoBruto.ClearUndo();
                txtPesoLiquido.Clear();
                txtOrigemProduto.Clear();
            }
        }

        private void buttonMarcaECartegoria_Click(object sender, EventArgs e)
        {
            AlteraBotoes(1);
            AlteraBotoes(3);
            AlteraBotoes(4);
        }

        private void buttonCancelarMarcaECartegoria_Click(object sender, EventArgs e)
        {
            AlteraBotoes(2);
            AlteraBotoes(3);
            AlteraBotoes(5);
        }
        private void buttonSalvarMarcaCategoria_Click(object sender, EventArgs e)
        {
            CadastraObjetosItens();
        }
        public void CadastraObjetosItens()
        {
            //Verifica Se a Marca é Valida no sistema!
            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_V_ConsultaMarcaProdutoConstaTxt '" + txtCadastroMarca.Text + "';", conn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            //Verifica Se a Categoria é Valida no sistema!

            SqlConnection conn2 = new SqlConnection(this.connetionString);

            SqlDataAdapter da2 = new SqlDataAdapter("EXEC D_V_ConsultaCategoriaProdutoConstaTxt '" + txtCadastroCategoria.Text + "';", conn2);

            DataSet ds2 = new DataSet();
            da2.Fill(ds2);

            //Verifica Se a Produto é Valida no sistema!

            SqlConnection conn3 = new SqlConnection(this.connetionString);

            SqlDataAdapter da3 = new SqlDataAdapter("EXEC D_V_ConsultaProdutoNomeProdutoConstaTxt '" + txtCadastraProduto.Text + "';", conn3);

            DataSet ds3 = new DataSet();
            da3.Fill(ds3);

            MarcaECartegoria CadastraMarcaECartegoria = new MarcaECartegoria();

            string Marca = txtCadastroMarca.Text;
            string DescricaoMarca = txtCadastroDescricaoMarca.Text;
            string Categoria = txtCadastroCategoria.Text;
            string DescricaoCategoria = txtDescricaoCategoria.Text;
            string Produto = txtCadastraProduto.Text;
            string DescricaoProduto = txtDescricaoProduto.Text;

            CadastraMarcaECartegoria.Marca = Marca.ToUpper();
            CadastraMarcaECartegoria.DescricaoMarca = DescricaoMarca.ToUpper();
            CadastraMarcaECartegoria.Categoria = Categoria.ToUpper();
            CadastraMarcaECartegoria.DescricaoCategoria = DescricaoCategoria.ToUpper();
            CadastraMarcaECartegoria.Produto = Produto.ToUpper();
            CadastraMarcaECartegoria.DescricaoProduto = DescricaoProduto.ToUpper();

            conn.Open();
            conn2.Open();
            conn3.Open();

            if (txtCadastroMarca.Text == "")
            {
                if (txtCadastroCategoria.Text == "")
                {
                    if (txtCadastraProduto.Text == "")
                    {
                        MessageBox.Show("Não pode ser Inserido sem se o campo Marca, Categoria ou o campo Produto estiverem em branco!");
                    }
                    if (!(txtCadastraProduto.Text == ""))
                    {
                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("O produto consta no sistema e não pode ser Inserido!");
                        }
                        if (ds3.Tables[0].Rows.Count == 0)
                        {
                            Conexao conexao = new Conexao(this.connetionString);
                            DALCadastro2 dal = new DALCadastro2(conexao); //cadastra Produto
                            dal.InserirNomeProduto(CadastraMarcaECartegoria);
                            AlteraBotoes(2);
                            AlteraBotoes(3);
                            AlteraBotoes(5);
                            MessageBox.Show("Dados salvos com sucesso");
                        }
                    }
                }
                if (!(txtCadastroCategoria.Text == ""))
                {
                    if (txtCadastraProduto.Text == "")
                    {
                        if ((ds2.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("A categoria consta no sistema e não pode ser Inserido!");
                        }
                        if (ds2.Tables[0].Rows.Count == 0)
                        {
                            Conexao conexao = new Conexao(this.connetionString);
                            DALCadastro2 dal = new DALCadastro2(conexao); //cadastra Categoria
                            dal.InserirCategoria(CadastraMarcaECartegoria);

                            AlteraBotoes(2);
                            AlteraBotoes(3);
                            AlteraBotoes(5);
                            MessageBox.Show("Dados salvos com sucesso");
                        }
                    }
                    if (!(txtCadastraProduto.Text == ""))
                    {
                        if ((ds2.Tables[0].Rows.Count > 0) && (ds3.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("A categoria e Produto consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds2.Tables[0].Rows.Count > 0) && (ds3.Tables[0].Rows.Count == 0))
                        {
                            MessageBox.Show("A categoria consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds2.Tables[0].Rows.Count == 0) && (ds3.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("O produto consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds2.Tables[0].Rows.Count == 0) && (ds3.Tables[0].Rows.Count == 0))
                        {
                            Conexao conexao = new Conexao(this.connetionString);
                            DALCadastro2 dal = new DALCadastro2(conexao); //cadastra Categoria
                            dal.InserirCategoria(CadastraMarcaECartegoria);

                            Conexao conexao4 = new Conexao(this.connetionString);
                            DALCadastro2 da4 = new DALCadastro2(conexao4); //cadastra Produto
                            da4.InserirNomeProduto(CadastraMarcaECartegoria);

                            AlteraBotoes(2);
                            AlteraBotoes(3);
                            AlteraBotoes(5);
                            MessageBox.Show("Dados salvos com sucesso");
                        }
                    }
                }
            }
            //-------------------------------Inverso-----------------
            if (!(txtCadastroMarca.Text == ""))
            {
                if (txtCadastroCategoria.Text == "")
                {
                    if (txtCadastraProduto.Text == "")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("A marca consta no sistema e não pode ser Inserido!");
                        }
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            Conexao conexao = new Conexao(this.connetionString);
                            DALCadastro2 dal = new DALCadastro2(conexao); //cadastra Produto
                            dal.InserirMarca(CadastraMarcaECartegoria);

                            AlteraBotoes(2);
                            AlteraBotoes(3);
                            AlteraBotoes(5);
                            MessageBox.Show("Dados salvos com sucesso");
                        }
                    }
                    if (!(txtCadastraProduto.Text == ""))
                    {
                        if ((ds.Tables[0].Rows.Count > 0) && (ds3.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("A marca e produto consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds.Tables[0].Rows.Count > 0) && (ds3.Tables[0].Rows.Count == 0))
                        {
                            MessageBox.Show("A marca consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds.Tables[0].Rows.Count == 0) && (ds3.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("A produto consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds.Tables[0].Rows.Count == 0) && (ds3.Tables[0].Rows.Count == 0))
                        {
                            Conexao conexao = new Conexao(this.connetionString);
                            DALCadastro2 dal = new DALCadastro2(conexao); //cadastra Produto
                            dal.InserirMarca(CadastraMarcaECartegoria);

                            Conexao conexao10 = new Conexao(this.connetionString);
                            DALCadastro2 dal10 = new DALCadastro2(conexao10); //cadastra Produto
                            dal10.InserirNomeProduto(CadastraMarcaECartegoria);

                            AlteraBotoes(2);
                            AlteraBotoes(3);
                            AlteraBotoes(5);
                            MessageBox.Show("Dados salvos com sucesso");
                        }
                    }
                }
                if (!(txtCadastroCategoria.Text == ""))
                {
                    if (txtCadastraProduto.Text == "")
                    {
                        if ((ds.Tables[0].Rows.Count > 0) && (ds2.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("A marca e categoria  consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds.Tables[0].Rows.Count > 0) && (ds2.Tables[0].Rows.Count == 0))
                        {
                            MessageBox.Show("A marca e consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds.Tables[0].Rows.Count == 0) && (ds2.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("A categoria e consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds.Tables[0].Rows.Count == 0) && (ds2.Tables[0].Rows.Count == 0))
                        {
                            Conexao conexao8 = new Conexao(this.connetionString);
                            DALCadastro2 dal8 = new DALCadastro2(conexao8); //cadastra categoria
                            dal8.InserirMarca(CadastraMarcaECartegoria);

                            Conexao conexao = new Conexao(this.connetionString);
                            DALCadastro2 dal = new DALCadastro2(conexao); //cadastra categoria
                            dal.InserirCategoria(CadastraMarcaECartegoria);

                            AlteraBotoes(2);
                            AlteraBotoes(3);
                            AlteraBotoes(5);
                            MessageBox.Show("Dados salvos com sucesso");
                        }
                    }
                    if (!(txtCadastraProduto.Text == ""))
                    {
                        if ((ds.Tables[0].Rows.Count > 0) && (ds2.Tables[0].Rows.Count > 0) && (ds3.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("A marca, categoria e Produto consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds.Tables[0].Rows.Count > 0) && (ds2.Tables[0].Rows.Count == 0) && (ds3.Tables[0].Rows.Count == 0))
                        {
                            MessageBox.Show("A marca consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds.Tables[0].Rows.Count > 0) && (ds2.Tables[0].Rows.Count > 0) && (ds3.Tables[0].Rows.Count == 0))
                        {
                            MessageBox.Show("A marca e categoria consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds.Tables[0].Rows.Count > 0) && (ds2.Tables[0].Rows.Count == 0) && (ds3.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("A marca e produto consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds2.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows.Count == 0) && (ds3.Tables[0].Rows.Count == 0))
                        {
                            MessageBox.Show("A categoria consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds2.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows.Count == 0) && (ds3.Tables[0].Rows.Count > 0))
                        {
                            MessageBox.Show("A categoria e produto consta no sistema e não pode ser Inserido!");
                        }
                        if ((ds3.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows.Count == 0) && (ds2.Tables[0].Rows.Count == 0))
                        {
                            MessageBox.Show("O produto consta no sistema e não pode ser Inserido!");
                        }

                        if ((ds.Tables[0].Rows.Count == 0) && (ds2.Tables[0].Rows.Count == 0) && (ds3.Tables[0].Rows.Count == 0))
                        {
                            Conexao conexao6 = new Conexao(this.connetionString);
                            DALCadastro2 dal6 = new DALCadastro2(conexao6); //cadastra marca
                            dal6.InserirMarca(CadastraMarcaECartegoria);

                            Conexao conexao = new Conexao(this.connetionString);
                            DALCadastro2 dal = new DALCadastro2(conexao); //cadastra categoria
                            dal.InserirCategoria(CadastraMarcaECartegoria);

                            Conexao conexao4 = new Conexao(this.connetionString);
                            DALCadastro2 da4 = new DALCadastro2(conexao4); //cadastra Produto
                            da4.InserirNomeProduto(CadastraMarcaECartegoria);

                            AlteraBotoes(2);
                            AlteraBotoes(3);
                            AlteraBotoes(5);

                            MessageBox.Show("Dados salvos com sucesso");
                        }
                    }
                }
            }
            conn.Close();
            conn2.Close();
            conn3.Close();
        }       
        public void QuantidadeProdutoCadastrado()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_V_ConsultaCadastroNProduto ", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (!(ds.Tables[0].Rows.Count > 0))
            {
                txtNitensCadastrados.Text = "Não tem registro de itens cadastrados.";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string numero = ds.Tables[0].Rows[0][0].ToString(); ;

                txtNitensCadastrados.Text = "N° " + numero.ToString() + " de itens cadastrado";
            }
        }
        public void NumeroProdutoCadastrado()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_V_ConsultaCadastroNProdutoProximo ", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int idProduto = 0;

            if (!(ds.Tables[0].Rows.Count > 0))
            {
                idProduto = 1;
                txtCodigoProduto.Text = "Sem Registro!";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                int soma = ds.Tables[0].Rows.Count;

                idProduto = 1 + soma;

                txtCodigoProduto.Text = " N° " + idProduto.ToString() +".";
            }
        }

        private void buttonCadastraProdutos_Click(object sender, EventArgs e)
        {
            panelGeral.Enabled = true;
            buttonCadastraProdutos.Enabled = false;
            AlteraBotoes(5);

            QuantidadeProdutoCadastrado();
            NumeroProdutoCadastrado();

        }

        private void buttonCancelaProdutos_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormCadastraProdutos cadastracliente = new FormCadastraProdutos(this.NomeServidor, this.NomeBaseDados, this.NomeUsuario, this.SenhaBaseDados);
            cadastracliente.MdiParent = FormCadastraProdutos.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }
        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;

            double v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro" + e);
            }
        }
        public static void Moeda2(ref TextBox txt)
        {
            string n = string.Empty;

            double v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:F}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro" + e);
            }
        }
        public static string ConverterValores(string VALORES)
        {
            try
            {
                string ConversaoValores = VALORES;

                Boolean finalizador = false;

                while (finalizador == false)
                {
                    int i = 0;

                    StringBuilder sb = new StringBuilder(VALORES);

                    int quantString = VALORES.Length;

                    string StringTeste = VALORES;


                    //QUEBRA DE LINHA SE FOR MAS QUE UMA LINHA
                    for (i = 0; i <= quantString - 1; i++)
                    {
                        //if (StringTeste[i] == '.')
                        //{
                        //    sb.Remove(i, 1);
                        //    VALORES = sb.ToString();
                        //    finalizador = false;
                        //    break;
                        //}
                        if (StringTeste[i] == '.')
                        {
                            sb.Remove(i, 1);
                            VALORES = sb.ToString();
                            finalizador = false;
                            break;
                        }
                        if (!(StringTeste[i] == '.'))
                        {
                            finalizador = true;
                            ConversaoValores = sb.ToString();
                        }
                    }
                }
                
                return ConversaoValores;
            }

            catch (Exception exp)
            {
                return exp.ToString();
            }
        }
        public static string AdicionadoVZ(string VALORES)
        {
            try
            {

                StringBuilder sb = new StringBuilder(VALORES);

                int quantString = VALORES.Length;

                sb.Insert(2,",00" );

                VALORES = sb.ToString();

                return VALORES;
            }

            catch (Exception exp)
            {
                return exp.ToString();
            }
        }
        private void txtPrecoCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && !(e.KeyChar == ','))
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {

                //string preco = VerificarVirgula(txtPrecoCusto.Text);

                txtCustoMedio.Text = txtPrecoCusto.Text;

                TEMP_CUSTO = txtPrecoCusto.Text;

                txtMargemLucro.Clear();
                txtPrecoVenda.Clear();
            }
        }

        private void txtCustoMedio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }                
        }

        private void txtPrecoVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && !(e.KeyChar == ','))
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
            //Se a tecla digitada não for número
            if (e.KeyChar == 13)
            {
                try
                {
                    if (!(txtPrecoCusto.Text == "") && !(txtPrecoVenda.Text == ""))
                    {
                        string Primeiro = "";
                        string Segundo = "";

                        Segundo = ConverterValores(txtPrecoCusto.Text);
                        Primeiro = ConverterValores(txtPrecoVenda.Text);
                        TempCusto = Segundo;

                        Decimal PrecoVendido = Decimal.Parse(Primeiro);
                        Decimal PrecoCusto = Decimal.Parse(Segundo);

                        if (PrecoVendido > PrecoCusto)
                        {
                            Decimal menos = (PrecoVendido - PrecoCusto);
                            Decimal dividr = (menos / PrecoCusto) * 100;
                            Decimal dividaTemp = dividr;

                            Decimal retorno = Decimal.Parse(dividaTemp.ToString());

                            TempLucro = retorno.ToString();

                            //TempVenda = PrecoVendido;

                            txtMargemLucro.Clear();
                            txtMargemLucro.Text = String.Format("{0:0,0.00}", retorno);

                            TempVenda = String.Format("{0:0,0.00}", Primeiro);

                            Moeda(ref txtMargemLucro);
                        }
                        if ((PrecoVendido == PrecoCusto) || (PrecoVendido < PrecoCusto))
                        {
                            txtMargemLucro.Text = "Valor não aceito!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void txtMargemLucro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
            //Se a tecla digitada não for número
            if (e.KeyChar == 13)
            {
                try
                {
                    if (!(txtPrecoCusto.Text == ""))
                    {
                        Decimal txtPrecoCustoc1 = Decimal.Parse (txtPrecoCusto.Text);
                        Decimal txtMargemLucro1 = Decimal.Parse(txtMargemLucro.Text);
                        Decimal pocent = 0;
                        Decimal calcula = 0;


                        if (txtPrecoCustoc1 > 0)
                        {
                            pocent = txtMargemLucro1 / 100;

                            pocent.ToString();

                            calcula = (txtPrecoCustoc1 * pocent) + txtPrecoCustoc1;

                            TempLucro = txtMargemLucro1.ToString();

                            txtPrecoVenda.Text = String.Format("{0:0,0.00}", calcula);

                            TempVenda = txtPrecoVenda.Text;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void txtQuantidadeAtualEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtQuantidadeMinimaEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtCódigoInterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
            //Se a tecla digitada não for número
            if (e.KeyChar == 13)
            {
                txtNcm.Text = txtCodigoInterno.Text;
            }
        }

        private void txtMargemLucro_TextChanged(object sender, EventArgs e)
        {
            Moeda2(ref txtMargemLucro);
            //txtMargemLucro.Text = VerificarVirgula(txtMargemLucro.Text);

        }
        public static string VerificarVirgula(string ENTRADA)
        {
            try
            {
                string Valores = ENTRADA;
                int cont = 0;

                StringBuilder sb = new StringBuilder(ENTRADA);

                int quantString = ENTRADA.Length;

              for(int i = 0; i < quantString; i++)
                {
                    if(Valores[i] == ',')
                    {
                        cont++;
                    }
                    if(cont > 1)
                    {
                        sb.Remove(i, 1);
                        cont--;
                        ENTRADA = sb.ToString();
                    }
                }

                return ENTRADA;
            }
            catch (Exception exp)
            {
                return exp.ToString();
            }
        }


        private void txtPrecoVenda_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPrecoVenda);
        }
        
        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            SalvaProduto();
        }
        public void SalvaProduto()
        {
            try
            {
                int contador = 0;

                //Verifica Se a Marca é Valida no sistema!
                SqlConnection conn4 = new SqlConnection(this.connetionString);

                SqlDataAdapter da4 = new SqlDataAdapter("EXEC D_V_ConsultaItemCadastradoVendaTxt " + IdDescricaoProduto + ";", conn4);
                IdDescricaoProduto.ToString();
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);
                conn4.Open();

                 IdDescricaoProduto.ToString();
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Já consta produto cadastrado para venda.");
                    contador++;
                    conn4.Close();
                }
                if (!(ds4.Tables[0].Rows.Count > 0))
                {
                    conn4.Close();

                    if ((PrecoCusto(txtPrecoCusto, errorProviderCadastroProduto) == true) && (CustoMedio(txtCustoMedio, errorProviderCadastroProduto) == true) &&
                    (PrecoVenda(txtPrecoVenda, errorProviderCadastroProduto) == true) && (MargemLucro(txtMargemLucro, errorProviderCadastroProduto) == true) &&
                    (QuantAtual(txtQuantidadeAtualEstoque, errorProviderCadastroProduto) == true) && (QuantMinima(txtQuantidadeMinimaEstoque, errorProviderCadastroProduto) == true))
                    {


                        if (comboBoxDescricaoProduto.Text == "")
                        {
                            MessageBox.Show("Selecione uma descrição do produto!");
                            contador++;
                        }
                        if (comboBoxCartegoria.Text == "")
                        {
                            MessageBox.Show("Selecione uma Categoria!");
                            contador++;
                        }
                        if (comboBoxFornecedor.Text == "")
                        {
                            MessageBox.Show("Selecione uma Fornecedor!");
                            contador++;
                        }
                        if (comboBoxMarca.Text == "")
                        {
                            MessageBox.Show("Selecione uma Marca!");
                            contador++;
                        }
                        if (comboBoxUnidade.Text == "")
                        {
                            MessageBox.Show("Selecione uma Unidade!");
                            contador++;
                        }

                        if (!(comboBoxDescricaoProduto.Text == "") && !(comboBoxCartegoria.Text == "") &&
                            !(comboBoxFornecedor.Text == "") && !(comboBoxMarca.Text == "") &&
                            !(comboBoxUnidade.Text == ""))
                        {
                            //Cadastra novo Produto
                            CadastraProdutos CadastraProdutosNovo = new CadastraProdutos();

                            //Combobox ---------------------
                            CadastraProdutosNovo.IdProdutoDescricao = IdDescricaoProduto;
                            CadastraProdutosNovo.IdMarca = IdMarcaProduto;
                            CadastraProdutosNovo.IdCategoriaProduto = IdMarcaProdutoCategoria;
                            CadastraProdutosNovo.IdFornecedor = IdMarcaFornecedor;
                            CadastraProdutosNovo.IdUnidadeProduto = IdUnidadeProduto;

                            //ConverterValores
                            //Paine Geral Esquerda

                            //Painel Financeiro
                            string PrecoCustoS = ConverterValores(txtPrecoCusto.Text);
                            CadastraProdutosNovo.PrecoCusto = decimal.Parse(PrecoCustoS);
                            string PrecoMedioS = ConverterValores(txtCustoMedio.Text);
                            CadastraProdutosNovo.PrecoMedio = decimal.Parse(PrecoMedioS);
                            string PrecoVendaS = ConverterValores(txtPrecoVenda.Text);
                            CadastraProdutosNovo.PrecoVenda = decimal.Parse(PrecoVendaS);
                            string MargemLucroS = ConverterValores(txtMargemLucro.Text);
                            CadastraProdutosNovo.MargemLucro = decimal.Parse(MargemLucroS);

                            CadastraProdutosNovo.DataReajuste = Convert.ToDateTime(dateTimePickerUltimoReajuste.Value.Date.ToString("dd/MM/yyyy"));


                            //Paine Geral parte de baixo
                            CadastraProdutosNovo.Data_Compra = Convert.ToDateTime(dateTimePickerSolicitacao.Value.Date.ToString("dd/MM/yyyy"));

                            //painel Fisico
                            CadastraProdutosNovo.Quant_Estoque = int.Parse(txtQuantidadeAtualEstoque.Text);
                            CadastraProdutosNovo.Quant_Minima = int.Parse(txtQuantidadeMinimaEstoque.Text);
                            CadastraProdutosNovo.QuantComprada = int.Parse(txtQuantidadeAtualEstoque.Text);
                            //Painel Geral direito
                            if (checkBoxnaoImprimir.Checked == true)
                            {
                                CadastraProdutosNovo.ImprimirProduto = 1;
                            }
                            else CadastraProdutosNovo.ImprimirProduto = 2;
                            CadastraProdutosNovo.ImprimirProduto.ToString();

                            if (checkBoxAtivo.Checked == true)
                            {
                                CadastraProdutosNovo.Ativo = 1;
                            }
                            else CadastraProdutosNovo.Ativo = 2;
                            CadastraProdutosNovo.Ativo.ToString();
                            //Verificar codigo do Produto Cadastro
                            if (txtCodigoInterno.Text == "")
                            {
                                CadastraProdutosNovo.CodInterno = 0;
                            }
                            else CadastraProdutosNovo.CodInterno = int.Parse(txtCodigoInterno.Text);

                            //tabControlNiveis Observação
                            CadastraProdutosNovo.Observacao = txtObservacao.Text;

                            //tabControlNiveis Dados Fiscais
                            //id de cadastro
                            if (comboBoxCstIcms.Text == "")
                            {
                                CadastraProdutosNovo.IdCstIcms = 0;
                            }
                            else CadastraProdutosNovo.IdCstIcms = IdCstIcms;

                            if (txtDescricaoCstIcms.Text == "")
                            {
                                CadastraProdutosNovo.DescricaoCstIcms = 0;
                            }
                            if (!(txtDescricaoCstIcms.Text == ""))
                            {
                                string DescricaoCstIcms = ConverterValores(txtDescricaoCstIcms.Text);
                                CadastraProdutosNovo.DescricaoCstIcms = decimal.Parse(DescricaoCstIcms);
                            }
                            if (txtBaseIcms.Text == "")
                            {
                                CadastraProdutosNovo.BaseCalculoIcms = 0;
                            }
                            if (!(txtBaseIcms.Text == ""))
                            {
                                string BaseCalculoIcmsS = ConverterValores(txtBaseIcms.Text);
                                CadastraProdutosNovo.BaseCalculoIcms = decimal.Parse(BaseCalculoIcmsS);
                            }
                            if (comboBoxCstPis.Text == "")
                            {
                                CadastraProdutosNovo.IdCstPis = 0;
                            }
                            else CadastraProdutosNovo.IdCstPis = IdCstPis;

                            if (txtDescricaoCstPis.Text == "")
                            {
                                CadastraProdutosNovo.DescricaoCstPis = 0;
                            }
                            if (!(txtDescricaoCstPis.Text == ""))
                            {
                                string DescricaoCstPis = ConverterValores(txtDescricaoCstPis.Text);
                                CadastraProdutosNovo.DescricaoCstPis = decimal.Parse(DescricaoCstPis);
                            }
                            if (txtPis.Text == "")
                            {
                                CadastraProdutosNovo.ValorPis = 0;
                            }
                            if (!(txtPis.Text == ""))
                            {
                                string CstPisS = ConverterValores(txtPis.Text);
                                CadastraProdutosNovo.ValorPis = decimal.Parse(CstPisS);
                            }
                            if (comboBoxCstCofins.Text == "")
                            {
                                CadastraProdutosNovo.IdCstCofins = 0;
                            }
                            else CadastraProdutosNovo.IdCstCofins = IdCstCofins;


                            if (txtDescricaoCofins.Text == "")
                            {
                                CadastraProdutosNovo.DescricaoCofins = 0;
                            }
                            if (!(txtDescricaoCofins.Text == ""))
                            {
                                string DescricaoCofins = ConverterValores(txtDescricaoCofins.Text);
                                CadastraProdutosNovo.DescricaoCofins = decimal.Parse(DescricaoCofins);
                            }
                            if (txtConfins.Text == "")
                            {
                                CadastraProdutosNovo.ValorCofins = 0;
                            }
                            if (!(txtConfins.Text == ""))
                            {
                                string Confins = ConverterValores(txtConfins.Text);
                                CadastraProdutosNovo.ValorCofins = decimal.Parse(Confins);
                            }
                            if (comboBoxCstIpI.Text == "")
                            {
                                CadastraProdutosNovo.IdCstIpi = 0;
                            }
                            else CadastraProdutosNovo.IdCstIpi = IdCstIpi;

                            if (txtDescricaoIpI.Text == "")
                            {
                                CadastraProdutosNovo.DescricaoCstIpi = 0;
                            }
                            if (!(txtDescricaoIpI.Text == ""))
                            {
                                string DescricaoIpI = ConverterValores(txtDescricaoIpI.Text);
                                CadastraProdutosNovo.DescricaoCstIpi = decimal.Parse(DescricaoIpI);
                            }


                            if (txtIpi.Text == "")
                            {
                                CadastraProdutosNovo.ValorIpi = 0;
                            }
                            if (!(txtIpi.Text == ""))
                            {
                                string Ipi = ConverterValores(txtIpi.Text);
                                CadastraProdutosNovo.ValorIpi = decimal.Parse(Ipi);
                            }
                            if (CadastraGtin == 0)
                            {
                                //tabControlNiveis Outros
                                CadastraProdutosNovo.CodigoGtin = 0;

                                CadastraProdutosNovo.PesoBruto = 0;

                                CadastraProdutosNovo.PesoLiquido = 0;

                                //CadastraProdutosNovo.PrevisaoChegada = DBNull.Value.ToString();
                                CadastraProdutosNovo.OrigemProduto = "";

                            }
                            if (CadastraGtin == 1)
                            {
                                //tabControlNiveis Outros
                                if (txtCodigoGtin.Text == "")
                                {
                                    CadastraProdutosNovo.CodigoGtin = 0;
                                }
                                else CadastraProdutosNovo.CodigoGtin = int.Parse(txtCodigoGtin.Text);


                                if (txtPesoBruto.Text == "")
                                {
                                    CadastraProdutosNovo.PesoBruto = 0;
                                }
                                if (!(txtPesoBruto.Text == ""))
                                {
                                    string PesoBrutoS = ConverterValores(txtPesoBruto.Text);
                                    CadastraProdutosNovo.PesoBruto = decimal.Parse(PesoBrutoS);
                                }

                                if (txtPesoLiquido.Text == "")
                                {
                                    CadastraProdutosNovo.PesoLiquido = 0;
                                }
                                if ((txtPesoLiquido.Text == ""))
                                {
                                    string PesoLiquidoS = ConverterValores(txtPesoLiquido.Text);
                                    CadastraProdutosNovo.PesoLiquido = decimal.Parse(PesoLiquidoS);
                                }

                                CadastraProdutosNovo.PrevisaoChegada = Convert.ToDateTime(dateTimePickerPrevisaoChegada.Value.Date.ToString("dd/MM/yyyy"));
                                CadastraProdutosNovo.OrigemProduto = txtOrigemProduto.Text;
                            }
                            //tabControlNiveis Foto
                            ProdutoImagem ImagemProduto = new ProdutoImagem();
                            ProdutoImagem2 ImagemProduto2 = new ProdutoImagem2();
                            //tabControlNiveis 5

                            if (!TempCusto.Equals(ConverterValores(txtPrecoCusto.Text)))
                            {
                                MessageBox.Show("As informações salvas no campo preço de custo não estão corretas! ");
                                contador++;
                            }
                            if (!TempLucro.Equals(ConverterValores(txtMargemLucro.Text)))
                            {
                                MessageBox.Show("As informações salvas no campo margem de lucro não estão corretas! ");
                                contador++;
                            }
                            if (!TempVenda.Equals(ConverterValores(txtPrecoVenda.Text)))
                            {
                                MessageBox.Show("As informações salvas no campo preço de venda não estão corretas! ");
                                contador++;
                            }
                            if ((CadastraProdutosNovo.Quant_Minima < 0) && (CadastraProdutosNovo.Quant_Estoque < 0))
                            {
                                MessageBox.Show("Quantidade minima e quantidade em estoque não podem ser negativas.");
                            }
                            if (CadastraProdutosNovo.Quant_Minima > CadastraProdutosNovo.Quant_Estoque)
                            {
                                MessageBox.Show("Quantidade minima não pode se maior que a quantidade em estoque.");
                                contador++;
                            }
                            if (contador != 0)
                            {

                            }
                            if (contador == 0)
                            {
                                //Salvar Cadastro de Produto no sistema
                                Conexao conexao = new Conexao(this.connetionString);
                                DALCadastro2 da = new DALCadastro2(conexao);
                                da.InserirProduto(CadastraProdutosNovo);
                                MessageBox.Show("Produto Cadastrado com exito!");

                                ImagemProduto.IdProduto = int.Parse(CadastraProdutosNovo.IdProduto.ToString());
                                ImagemProduto2.IdProduto2 = int.Parse(CadastraProdutosNovo.IdProduto.ToString());

                                //Salvar Imagem em Base de Dados
                                Conexao conexao1 = new Conexao(this.connetionString);
                                DALCadastro2 da1 = new DALCadastro2(conexao1);

                                //Salvar Imagem em Base de Dados 2
                                Conexao conexao2 = new Conexao(this.connetionString);
                                DALCadastro2 da2 = new DALCadastro2(conexao2);

                                if (bmp != null)
                                {
                                    //imagem 1
                                    MemoryStream memory = new MemoryStream();

                                    bmp.Save(memory, ImageFormat.Bmp);

                                    byte[] Foto = memory.ToArray();

                                    ImagemProduto.Imagem = Foto;

                                    da1.IncluirProdutoImagem(ImagemProduto);
                                }
                                if (bmp2 != null)
                                {
                                    //imagem 2
                                    MemoryStream memory2 = new MemoryStream();

                                    bmp2.Save(memory2, ImageFormat.Bmp);

                                    byte[] Foto2 = memory2.ToArray();

                                    ImagemProduto2.Imagem2 = Foto2;

                                    da2.IncluirProdutoImagem2(ImagemProduto2);
                                }
                                FecharTodosFormulario();

                                FormCadastraProdutos cadastraProduto = new FormCadastraProdutos(this.NomeServidor, this.NomeBaseDados, this.NomeUsuario, this.SenhaBaseDados);
                                cadastraProduto.MdiParent = FormCadastraProdutos.ActiveForm;
                                cadastraProduto.Show();
                                cadastraProduto.Top = 0;
                                cadastraProduto.Left = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void txtPesoBruto_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPesoBruto);
        }

        private void txtPesoLiquido_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPesoLiquido);
        }
        private void txtBaseIcms_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtBaseIcms);
        }

        private void txtIpi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtConfins_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtBaseIcms_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtConfins_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtConfins);
        }
        //COMBOBOX PRODUTO, MARCA, CATEGORIA, FORNECEDOR, UNIDADE E ORIGEM DE PRODUTO!
        //Lista Produtos Descrição
        void Fill_listBoxDescricaoProduto()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_V_ConsultaProdutoNomeProduto;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string nome = dr.GetString(1);
                    comboBoxDescricaoProduto.Items.Add(nome);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //SELECINE DESCRICAO DE PRODUTO
        private void comboBoxDescricaoProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                //PROCEDURE NAO EXISTE
                //string Query = "exec D_V_ConsultaProdutoNomeProdutoConstaTxt '" + this.comboBoxDescricaoProduto.Text + "';";
                //MessageBox.Show( this.comboBoxDescricaoProduto.Text.ToString());
                string Query = "SELECT * FROM Pr_ProdutoNome WHERE NOME '" + this.comboBoxDescricaoProduto.Text + "';";
                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    IdDescricaoProduto = dr.GetInt32(0);
                    comboBoxCartegoria.Text = dr.GetString(1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LISTA AS MARCAS CADASTRADA NO SISTEMA
        void Fill_listBoxMarcaProduto()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_V_ConsultaMarcaProduto;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(1);
                    comboBoxMarca.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // SELECIONA A MARCA DE PRODUTO
        private void comboBoxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();

                string Query = "exec D_V_ConsultaMarcaProdutoConstaTxt '" + this.comboBoxMarca.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                    IdMarcaProduto = dr.GetInt32(0);
                    comboBoxMarca.Text = dr.GetString(1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Lista de Categoria Produto
        void Fill_listBoxCategoriaProduto()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_V_ConsultaCategoriaProduto;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(1);
                    comboBoxCartegoria.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBoxCartegoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();

                string Query = "exec D_V_ConsultaCategoriaProdutoConstaTxt '" + this.comboBoxCartegoria.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                    IdMarcaProdutoCategoria = dr.GetInt32(0);
                    comboBoxCartegoria.Text = dr.GetString(1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LISTA AS MARCAS CADASTRADA NO SISTEMA
        void Fill_listBoxMarcaFornecedor()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_V_ConsultaFornecedorNomeCadastroContatos;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(0);
                    comboBoxFornecedor.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                //ESTA PROCEDURE NAO EXISTE
                string Query = "exec D_ConsultaFornecedorNomeCadastroContatostxt '" + this.comboBoxFornecedor.Text + "',1;";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                    IdMarcaFornecedor = dr.GetInt32(0);
                    IdMarcaFornecedor.ToString();
                    comboBoxFornecedor.Text = dr.GetString(2);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Lista de Unidade Produto
        void Fill_listBoxUnidade()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_V_ConsultaUnidadeProduto;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(2);
                    comboBoxUnidade.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //SELECIONAR UNIDADE DE PRODUTO
        private void comboBoxUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();

                string Query = "exec D_V_ConsultaUnidadeProdutoTxt '" + this.comboBoxUnidade.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    IdUnidadeProduto = dr.GetInt32(0);
                    
                    comboBoxUnidade.Text = dr.GetString(2);
                    label47.Text = "Valor: " + dr.GetInt32(1) + " e descrição: " + dr.GetString(3) + ".";
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ////Lista Selecionar Origem Produto
        //void Fill_listBoxOrigemProduto()
        //{
        //    SqlConnection connection = new SqlConnection(this.connetionString);

        //    try
        //    {
        //        connection.Open();
        //        string Query = "EXEC D_V_ConsultaOrigemProduto;";


        //        SqlCommand command = new SqlCommand(Query, connection);
        //        SqlDataReader dr = command.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            string name = dr.GetString(1);
        //            comboBoxOrigemProduto.Items.Add(name);
        //        }
        //        connection.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        ////Lista Selecionar Origem Produto txt
        //private void comboBoxOrigemProduto_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlConnection connection = new SqlConnection(this.connetionString);

        //    try
        //    {
        //        connection.Open();

        //        string Query = "exec D_V_ConsultaOrigemProdutoTxt '" + this.comboBoxOrigemProduto.Text + "';";

        //        SqlCommand command = new SqlCommand(Query, connection);
        //        SqlDataReader dr = command.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            IdOrigemProduto = dr.GetInt32(0);
        //            comboBoxOrigemProduto.Text = dr.GetString(1);
        //        }
        //        connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //COMBOBOX ICMS,IPI E OUTROS--------------------------------

        //Lista de CstIcms Produto
        void Fill_listBoxCstIcms()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_V_ConsultaCstIcms;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int name = dr.GetInt32(1);
                    comboBoxCstIcms.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Selecione CstIcms Produto
        private void comboBoxCstIcms_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();

                //int codigo = int.Parse(comboBoxCstIcms.Text);

                string Query = "exec D_V_ConsultaCstIcmsTxt " + this.comboBoxCstIcms.Text + ";";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    IdCstIcms = dr.GetInt32(0);
                    txtDescricaoCstIcms.Text = dr.GetString(2);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Lista de Pis Produto
        void Fill_listBoxCstPis()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_V_ConsultaCstPis;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int name = dr.GetInt32(1);
                    comboBoxCstPis.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Selecione Pis Produto
        private void comboBoxCstPis_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();

                string Query = "exec D_V_ConsultaCstPisTxt '" + this.comboBoxCstPis.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    IdCstPis = dr.GetInt32(0);
                    txtDescricaoCstPis.Text = dr.GetString(2);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPis_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPis);
        }

        //Lista de Cofins Produto
        void Fill_listBoxCstCofins()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_V_ConsultaCstCofins;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int codigo = dr.GetInt32(1);
                    comboBoxCstCofins.Items.Add(codigo);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Selecine  cofins Produto
        private void comboBoxCstCofins_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();

                string Query = "exec  D_V_ConsultaCstCofinsTxt '" + this.comboBoxCstCofins.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    IdCstCofins = dr.GetInt32(0);
                    txtDescricaoCofins.Text = dr.GetString(2);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Lista de IPI Produto
        void Fill_listBoxCstIpi()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_V_ConsultaCstIpi;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int codigo = dr.GetInt32(1);
                    comboBoxCstIpI.Items.Add(codigo);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Selecine  Ipi Produto
        private void comboBoxCstIpI_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();

                string Query = "exec  D_V_ConsultaCstIpiTxt '" + this.comboBoxCstIpI.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    IdCstIpi = dr.GetInt32(0);
                    txtDescricaoIpI.Text = dr.GetString(2);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtNcm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        private void txtPrecoCusto_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtPrecoCusto);
            //txtPrecoCusto.Text = VerificarVirgula(txtPrecoCusto.Text);
        }

        private void txtCustoMedio_TextChanged(object sender, EventArgs e)
        {
            //Moeda(ref txtCustoMedio);
        }
        //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS
        public void FecharTodosFormulario()
        {
            CancelaCadastradoProdutos(typeof(FormCadastraProdutos));
        }

        private void buttonFecharCliente_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }
        public static void CancelaCadastradoProdutos(Type frmType)
        {
            bool bolCtl = false;
            Type a = frmType;
            foreach (Form form in System.Windows.Forms.Application.OpenForms)
            {
                if (form.GetType().Equals(frmType))
                {

                    form.Close();

                    //MessageBox.Show("Formulario Já foi Fechado.");


                    bolCtl = true;
                    break;
                }
            }

            if (!bolCtl)
            {

            }
        }
        private void buttonCancelarcadastrousuario_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormCadastraProdutos cadastracliente = new FormCadastraProdutos(this.NomeServidor, this.NomeBaseDados, this.NomeUsuario, this.SenhaBaseDados);
            cadastracliente.MdiParent = FormCadastraProdutos.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }
        private void buttonAnexo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPG Files(*.png)|*.png";// all files(*.*) | *.*

            DialogResult dialogResult = MessageBox.Show("Deseja Anexa uma imagem!", "Aviso", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    openFileDialog1.ShowDialog();
                    ImgLocation = openFileDialog1.FileNames.ToString();
                    //label15.Text = Dialog.FileNames.ToString();
                    label49.Text =  openFileDialog1.FileName;
                    pictureBoxImagem.Image = Image.FromFile(openFileDialog1.FileName);
                    bmp = new Bitmap(label49.Text);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Cancelado o Anexo da Imagem!");
            }
        }
        private void buttonAnexo2_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "JPG Files(*.jpg)|*.jpg|JPG Files(*.png)|*.png";// all files(*.*) | *.*

            DialogResult dialogResult = MessageBox.Show("Deseja Anexa uma imagem!", "Aviso", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    openFileDialog2.ShowDialog();
                    ImgLocation2 = openFileDialog2.FileNames.ToString();
                    //label15.Text = Dialog.FileNames.ToString();
                    label50.Text = openFileDialog2.FileName;
                    pictureBoxImagem2.Image = Image.FromFile(openFileDialog2.FileName);
                    bmp2 = new Bitmap(label50.Text);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Cancelado o Anexo da Imagem!");
            }
        }
        private void buttonAbrirAnexo_Click(object sender, EventArgs e)
        {
            //int arruma = 0;
            //SqlConnection conn = new SqlConnection(this.connetionString);
            //SqlCommand comand = new SqlCommand("D_O_ConsultaOsImagemSalva " + arruma + ";", conn);
            //conn.Open();

            //SqlDataReader reader = comand.ExecuteReader();

            //if (reader.Read())
            //{
            //    byte[] Foto = (byte[])reader["IMAGEM"];
            //    MemoryStream ms = new MemoryStream(Foto);
            //    Imagem = Image.FromStream(ms);
            //}
            //if (Imagem == null)
            //{
            //    MessageBox.Show("Não existir Imagem!");
            //}
            //if (Imagem != null)
            //{
            //    pictureBoxImagem.Image = Imagem;
            //}
        }
        private void buttonImprimirImagemOS_Click(object sender, EventArgs e)
        {
            printPreviewDialogImagem.Document = printDocumentImagem;
            printPreviewDialogImagem.ShowDialog();
        }
        private void buttonCadastraGtin_Click(object sender, EventArgs e)
        {
            AlteraBotoes(6);
        }
        private void buttonCancelarGtin_Click(object sender, EventArgs e)
        {
            AlteraBotoes(7);
        }
        private void txtCodigoGtin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtPesoBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        private void txtPesoLiquido_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ObjetosCadastrados();
            }
        }

        private void txtConsultarItens_TextChanged(object sender, EventArgs e)
        {
            if(ValorPesquisa == 1)
            {
                DataView DV = new DataView(TableProduto);
                DV.RowFilter = string.Format("NOME LIKE '%{0}%'", txtConsultarItens.Text);
                dataGridViewObjetosItens.DataSource = DV;
                label48.Text = "Pesquisa Produtos n°: " + dataGridViewObjetosItens.RowCount.ToString();
            }
        }
        private void radioButtonProduto_CheckedChanged(object sender, EventArgs e)
        {
            ValorPesquisa = 0;
        }
        private void radioButtonMarca_CheckedChanged(object sender, EventArgs e)
        {
            ValorPesquisa = 0;
        }
        private void radioButtonCartegoria_CheckedChanged(object sender, EventArgs e)
        {
            ValorPesquisa = 0;
        }
        private void radioButtonFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            ValorPesquisa = 0;
        }

        private void dataGridViewObjetosItens_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dataGridViewObjetosItens.RowCount == 0))
            {
                try
                {
                    if (radioButtonProduto.Checked == true)
                    {
                        this.IdDescricaoProduto = Convert.ToInt32(dataGridViewObjetosItens["ID", e.RowIndex].Value);
                        comboBoxDescricaoProduto.SelectedItem = Convert.ToString(dataGridViewObjetosItens["NOME1", e.RowIndex].Value);
                        
                    }
                    if (radioButtonMarca.Checked == true)
                    {
                        this.IdMarcaProduto = Convert.ToInt32(dataGridViewObjetosItens["ID", e.RowIndex].Value);
                        comboBoxMarca.SelectedItem = Convert.ToString(dataGridViewObjetosItens["NOME1", e.RowIndex].Value);
                    }
                    if (radioButtonCartegoria.Checked == true)
                    {
                        this.IdMarcaProdutoCategoria = Convert.ToInt32(dataGridViewObjetosItens["ID", e.RowIndex].Value);
                        comboBoxCartegoria.SelectedItem = Convert.ToString(dataGridViewObjetosItens["NOME1", e.RowIndex].Value);
                    }
                    if (radioButtonFornecedor.Checked == true)
                    {
                        this.IdMarcaFornecedor = Convert.ToInt32(dataGridViewObjetosItens["ID", e.RowIndex].Value);
                        comboBoxFornecedor.SelectedItem = Convert.ToString(dataGridViewObjetosItens["NOME1", e.RowIndex].Value);
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
        private void buttonFecharFuncionario_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }

        private void FormCadastraProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
        private void buttonImprimirImagem_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                printDialog.PrinterSettings = printDialog.PrinterSettings;
                printDocumentImagem.Print();
            }
        }

        private void buttonImprimirImagem2_Click(object sender, EventArgs e)
        {
            if (printDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                printDialog2.PrinterSettings = printDialog2.PrinterSettings;
                printDocumentImagem2.Print();
            }
        }

        private void buttonImprimirImagemOS2_Click(object sender, EventArgs e)
        {
            printPreviewDialogImagem2.Document = printDocumentImagem2;
            printPreviewDialogImagem2.ShowDialog();
        }
    }
}
            
