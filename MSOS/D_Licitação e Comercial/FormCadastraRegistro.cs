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
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace DateSystem
{
    public partial class FormCadastraRegistro : Form
    {
        DataTable TableCliente;

        private int ID_PESSOA_LOGADA = 0;
        public int IdPessoaLogada
        {
            get
            {
                return this.ID_PESSOA_LOGADA;

            }
            set
            {
                this.ID_PESSOA_LOGADA = value;
            }
        }

        private int IDCONTATOCLIENTE = 0;
        public int IdContatoCliente 
        {
            get
            {
                return this.IDCONTATOCLIENTE;

            }
            set
            {
                this.IDCONTATOCLIENTE = value;
            }
        }
        private int NUMERO_OS_LIVRE = 0;
        public int NumeroOsLivre
        {
            get
            {
                return this.NUMERO_OS_LIVRE;

            }
            set
            {
                this.NUMERO_OS_LIVRE = value;
            }
        }
        private int CADASTRA_REGISTRON = 0;
        public int CadastraRegistroN
        {
            get
            {
                return this.CADASTRA_REGISTRON;

            }
            set
            {
                this.CADASTRA_REGISTRON = value;
            }
        }

        private int ID_REGISTRO = 0;
        public int IdRegistro
        {
            get
            {
                return this.ID_REGISTRO;

            }
            set
            {
                this.ID_REGISTRO = value;
            }
        }
        private int ID_REGISTROSALVA = 0;
        public int IdRegistroSalva
        {
            get
            {
                return this.ID_REGISTROSALVA;

            }
            set
            {
                this.ID_REGISTROSALVA = value;
            }
        }
        public int ID_FUNCIONARIO = 0;
        public int IdFuncionario
        {
            get
            {
                return this.ID_FUNCIONARIO;

            }
            set
            {
                this.ID_FUNCIONARIO = value;
            }
        }

        private int ID_TIPO_PESSOA = 0;
        public int idPessoaTipo
        {
            get
            {
                return this.ID_TIPO_PESSOA;

            }
            set
            {
                this.ID_TIPO_PESSOA = value;
            }
        }
        private int IDPESSOA = 0;
        public int IdPessoa
        {
            get
            {
                return this.IDPESSOA;

            }
            set
            {
                this.IDPESSOA = value;
            }
        }
        //Strings endereços
        private string TIPO_LOGRADOURO = "";
        public string Tipologradouro
        {
            get
            {
                return this.TIPO_LOGRADOURO;

            }
            set
            {
                this.TIPO_LOGRADOURO = value;
            }
        }
        private string ENDERECOOS = "";
        public string EnderecoOS
        {
            get
            {
                return this.ENDERECOOS;

            }
            set
            {
                this.ENDERECOOS = value;
            }
        }
        private string COMPLEMENTOS = "";
        public string Complementos
        {
            get
            {
                return this.COMPLEMENTOS;

            }
            set
            {
                this.COMPLEMENTOS = value;
            }
        }
        private string BAIRRONUMERO = "";
        public string BairroNumero
        {
            get
            {
                return this.BAIRRONUMERO;

            }
            set
            {
                this.BAIRRONUMERO = value;
            }
        }
        private string BAIRRO = "";
        public string Bairro
        {
            get
            {
                return this.BAIRRO;

            }
            set
            {
                this.BAIRRO = value;
            }
        }
        private string CIDADE = "";
        public string Cidade
        {
            get
            {
                return this.CIDADE;

            }
            set
            {
                this.CIDADE = value;
            }
        }
        private string SERVICOEXECUTADO = "";
        public string ServicoExecutado
        {
            get
            {
                return this.SERVICOEXECUTADO;

            }
            set
            {
                this.SERVICOEXECUTADO = value;
            }
        }
        private string COMBOBOXABREVIACAO = "";
        public string ComboBoxAbreviacao
        {
            get
            {
                return this.COMBOBOXABREVIACAO;

            }
            set
            {
                this.COMBOBOXABREVIACAO = value;
            }
        }

        private string ORIGEM_SERVICO = "";
        public string OrigemServico
        {
            get
            {
                return this.ORIGEM_SERVICO;

            }
            set
            {
                this.ORIGEM_SERVICO = value;
            }
        }
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
        private string NOMEACESSO = "";
        public string NomeAcesso
        {
            get
            {
                return this.NOMEACESSO;

            }
            set
            {
                this.NOMEACESSO = value;
            }
        }
        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtOrigemRegistro.Text))
            {
                errorProviderCadastraRegistro.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastraRegistro.SetError(textBox, "Documentação Inválido!");
                return false;
            }

        }
        private string operacao = "";
        public FormCadastraRegistro()
        {
            InitializeComponent();
        }

        private void radioButtonPequisaNumero_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaNomeCliente.Enabled = false;
            txtPesquisaNumeroCliente.Enabled = true;
            txtPesquisaNumeroCliente.Clear();
            txtPesquisaNomeCliente.Clear();
        }

        private void radioButtonPesquisaNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaNomeCliente.Enabled = true;
            txtPesquisaNumeroCliente.Enabled = false;
            txtPesquisaNumeroCliente.Clear();
            txtPesquisaNomeCliente.Clear();
        }

        private void txtPesquisaNomeCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscaCliente();
            }
        }

        private void txtPesquisaNumeroCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscaCliente();
            }
        }

        private void buttonPesquisaCliente_Click(object sender, EventArgs e)
        {
            BuscaCliente();
        }
        private void BuscaCliente()
        {
            //String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
            SqlConnection conn = new SqlConnection(this.connetionString);

            if (radioButtonPequisaNumero.Checked)
            {
                if (txtPesquisaNumeroCliente.Text == "")
                {
                    FecharTodosFormulario();
                    MessageBox.Show("O Número não pode esta em branco! ");
                }

                if (!(txtPesquisaNumeroCliente.Text == ""))
                {
                    int NUMERO = int.Parse(this.txtPesquisaNumeroCliente.Text);
                    //SELECIONA POR MS
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC D_R_ConsultaPessoaNumeroClienteRegistroTxt " + NUMERO + ",1; ", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        IdPessoa = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                        idPessoaTipo = int.Parse(ds1.Tables[0].Rows[0][1].ToString());

                        if (IdPessoa != 0)
                        {
                            buttonLimpaRegistro.Enabled = true;

                            dataGridViewPesquisa.Enabled = true;

                            panelDocumentoRegistro.Enabled = true;

                            buttonCancelarRegistro.Enabled = true;

                            buttonFecharRegistro.Enabled = true;

                            buttonVerifica.Enabled = true;

                            comboBoxContato.Items.Clear();
                            Fill_listBoxContatos();

                            panelDadosCliente.Enabled = true;
                        }
                        if (IdPessoa == 0)
                        {
                            MessageBox.Show("O Número não constra no sitema! ");
                        }

                        try
                        {
                            if (idPessoaTipo == 1)
                            {
                                try
                                {
                                    txtNomeRegistro.Text = ds1.Tables[0].Rows[0][3].ToString();
                                    txtNumeroRegistro.Text = ds1.Tables[0].Rows[0][0].ToString();
                                    txtTelefoneRegistro.Text = ds1.Tables[0].Rows[0][4].ToString();
                                    //txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][32].ToString();
                                    txtEnderecoRegistro.Text = ds1.Tables[0].Rows[0][38].ToString();
                                    txtBairroNumero.Text = ds1.Tables[0].Rows[0][39].ToString();
                                    txtComplRegistro.Text = ds1.Tables[0].Rows[0][40].ToString();
                                    txtBairroRegistro.Text = ds1.Tables[0].Rows[0][41].ToString();
                                    txtCidadeRegistro.Text = ds1.Tables[0].Rows[0][42].ToString();

                                    conn.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            if (idPessoaTipo == 2)
                            {
                                try
                                {
                                    txtNomeRegistro.Text = ds1.Tables[0].Rows[0][3].ToString();
                                    txtNumeroRegistro.Text = ds1.Tables[0].Rows[0][0].ToString();
                                    txtTelefoneRegistro.Text = ds1.Tables[0].Rows[0][4].ToString();
                                    //txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][32].ToString();
                                    txtEnderecoRegistro.Text = ds1.Tables[0].Rows[0][38].ToString();
                                    txtBairroNumero.Text = ds1.Tables[0].Rows[0][39].ToString();
                                    txtComplRegistro.Text = ds1.Tables[0].Rows[0][40].ToString();
                                    txtBairroRegistro.Text = ds1.Tables[0].Rows[0][41].ToString();
                                    txtCidadeRegistro.Text = ds1.Tables[0].Rows[0][42].ToString();

                                    conn.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        MessageBox.Show("O número de registro: " + NUMERO + " não consta no sistema!");

                        conn.Close();

                    }
                }
            }
            if (radioButtonPesquisaNome.Checked)
            {
                if (txtPesquisaNomeCliente.Text == "")
                {
                    //dataGridViewPesquisaCliente.Columns.Clear();
                    dataGridViewPesquisa.Refresh();

                    label1.Text = dataGridViewPesquisa.RowCount.ToString();

                    MessageBox.Show("O nome não pode esta em Branco!");
                }
                if (!(txtPesquisaNomeCliente.Text == ""))
                {
                    //SELECIONA POR TODOS OS 
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC D_R_ConsultaPessoaClienteRegistroNomeTxt '" + txtPesquisaNomeCliente.Text + "',1;", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewPesquisa.DataSource == null)
                        {
                            dataGridViewPesquisa.Refresh();
                        }
                        if (!(dataGridViewPesquisa.DataSource == null))
                        {
                            dataGridViewPesquisa.Refresh();
                        }
                        label1.Text = dataGridViewPesquisa.RowCount.ToString();

                        MessageBox.Show("Nem um Registro de nome Achado!");
                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dataGridViewPesquisaCliente();
                        dataGridViewPesquisa.RowCount.ToString();
                        buttonVerifica.Enabled = true;
                        conn.Close();
                    }
                }
            }
            else if (!(radioButtonPequisaNumero.Checked) && !(radioButtonPesquisaNome.Checked)) MessageBox.Show("Seleciona Número ou Nome para uma Pesquisa!");
            {
                
            }
        }
        private void buttonFecharRegistro_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }
        private void buttonCancelarRegistro_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormCadastraRegistro cadastracliente = new FormCadastraRegistro(this.IdPessoaLogada, this.NomeAcesso,
                this.NomeServidor, this.NomeBaseDados, this.NomeUsuario, this.SenhaBaseDados);
            cadastracliente.MdiParent = FormCadastraRegistro.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }
        public void FecharTodosFormulario()
        {
            CancelaCadastradoProposta(typeof(FormCadastraRegistro));
        }
        public static void CancelaCadastradoProposta(Type frmType)
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
        private void buttonCancelarRegistro1_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }
        public void CancelarCadastroRegistro()
        {
            FecharTodosFormulario();
            FormCadastraRegistro cadastracliente = new FormCadastraRegistro(this.IdPessoaLogada, this.NomeAcesso,
                this.NomeServidor, this.NomeBaseDados, this.NomeUsuario, this.SenhaBaseDados);
            cadastracliente.MdiParent = FormCadastraRegistro.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }
        private void buttonCadastraRegistro_Click(object sender, EventArgs e)
        {
            CadastraRegistro();
        }
        private void CadastraRegistro()
        {
            this.operacao = "Inserir";

            checkBoxSituacao.Checked = true;

            txtOrigemRegistro.MaxLength = 1000;

            dataGridViewPesquisa.Enabled = true;

            AlteraBotoes(1);

            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_R_ConsultaCadastroNRegistro ", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (!(ds.Tables[0].Rows.Count > 0))
            {
                IdRegistro = 1;
                txtNumeroDoRegistro.Text = " N° " + IdRegistro.ToString();
                conn.Close();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                int soma = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                IdRegistro = 1 + soma;
                txtNumeroDoRegistro.Text = " N° " + IdRegistro.ToString();
                conn.Close();
            }

            comboBoxContato.Items.Clear();
            Fill_listBoxContatos();

            this.txtDataSolicitacaoProcesso.Value = DateTime.Now.Date;

            this.txtDataContatoRegistro.Value = DateTime.Now.Date;
        }
        public void GeraRegistroSalva()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_R_ConsultaCadastroNRegistro ", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (!(ds.Tables[0].Rows.Count > 0))
            {
                IdRegistroSalva = 1;
                txtNumeroDoRegistro.Text = " N° " + IdRegistroSalva.ToString();
                conn.Close();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                int soma = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                IdRegistroSalva = 1 + soma;
                txtNumeroDoRegistro.Text = " N° " + IdRegistroSalva.ToString();
                conn.Close();
            }
        }
        //LISTA OS Contatos da empresa Buscada
        void Fill_listBoxContatos()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_R_ConsultaCadastroIdRegistro " + IdPessoa + ";";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(0);
                    comboBoxContato.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBoxContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();

                string Query = " SELECT ID_PESSOA_CONTATO, ABREVIACAO FROM P_Contatos WHERE Nome = '" + this.comboBoxContato.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                    this.IdContatoCliente = dr.GetInt32(0);
                    comboBoxContato.Text = dr.GetString(1);
                    label8.Text = dr.GetString(1);
                    this.ComboBoxAbreviacao = dr.GetString(1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void dataGridViewPesquisaCliente()
        {
            string connetionString = (this.connetionString);
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command = new SqlCommand("EXEC D_R_ConsultaPessoaClienteRegistroNomeTxt '" + txtPesquisaNomeCliente.Text + "',1;", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                TableCliente = new DataTable();
                adapter.Fill(TableCliente);
                BindingSource Source = new BindingSource();
                Source.DataSource = TableCliente;
                dataGridViewPesquisa.DataSource = Source;
                adapter.Update(TableCliente);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            //DataTable dt = new DataTable();
        }
        private void dataGridViewPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPesquisa.RowCount == 0)
            {
                IdPessoa = 0;
            }
            if (!(dataGridViewPesquisa.RowCount == 0))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(this.connetionString);

                    IdPessoa = Convert.ToInt32(dataGridViewPesquisa["ID_PESSOA", e.RowIndex].Value);

                    //SELECIONA POR TODOS OS 
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC D_R_ConsultaClienteRegistroEditarTxt " + IdPessoa + ";", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        IdPessoa = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                        idPessoaTipo = int.Parse(ds1.Tables[0].Rows[0][1].ToString());

                        if (IdPessoa != 0)
                        {

                            comboBoxContato.Items.Clear();
                            Fill_listBoxContatos();
                            buttonLimpaRegistro.Enabled = true;
                            panelDocumentoRegistro.Enabled = true;
                            comboBoxContato.Enabled = true;

                            panelDadosCliente.Enabled = true;

                        }
                        if (IdPessoa == 0)
                        {

                        }

                        try
                        {
                            if (idPessoaTipo == 1)
                            {
                                try
                                {
                                    txtNomeRegistro.Text = ds1.Tables[0].Rows[0][3].ToString();
                                    txtNumeroRegistro.Text = ds1.Tables[0].Rows[0][0].ToString();
                                    txtTelefoneRegistro.Text = ds1.Tables[0].Rows[0][4].ToString();
                                    //txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][32].ToString();
                                    txtEnderecoRegistro.Text = ds1.Tables[0].Rows[0][38].ToString();
                                    txtBairroNumero.Text = ds1.Tables[0].Rows[0][39].ToString();
                                    txtComplRegistro.Text = ds1.Tables[0].Rows[0][40].ToString();
                                    txtBairroRegistro.Text = ds1.Tables[0].Rows[0][41].ToString();
                                    txtCidadeRegistro.Text = ds1.Tables[0].Rows[0][42].ToString();

                                    conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    ex.ToString();
                                }
                            }
                            if (idPessoaTipo == 2)
                            {
                                try
                                {
                                    txtNomeRegistro.Text = ds1.Tables[0].Rows[0][3].ToString();
                                    txtNumeroRegistro.Text = ds1.Tables[0].Rows[0][0].ToString();
                                    txtTelefoneRegistro.Text = ds1.Tables[0].Rows[0][4].ToString();
                                    //txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][32].ToString();
                                    txtEnderecoRegistro.Text = ds1.Tables[0].Rows[0][38].ToString();
                                    txtBairroNumero.Text = ds1.Tables[0].Rows[0][39].ToString();
                                    txtComplRegistro.Text = ds1.Tables[0].Rows[0][40].ToString();
                                    txtBairroRegistro.Text = ds1.Tables[0].Rows[0][41].ToString();
                                    txtCidadeRegistro.Text = ds1.Tables[0].Rows[0][42].ToString();

                                    conn.Close();

                                }
                                catch (Exception ex)
                                {
                                    ex.ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }
                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        MessageBox.Show("O cliente não consta no sistema!");

                        AlteraBotoes(10);
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra OS campos
            {
                panelBuscaInformacao.Enabled = true;


                buttonCadastraRegistro.Enabled = false;
                buttonCancelarRegistro.Enabled = true;


                buttonVerifica.Enabled = false;
                buttonLimpaRegistro.Enabled = false;
                buttonCancelarRegistro1.Enabled = true;
                buttonFecharRegistro.Enabled = true;
            }
        }

        private void FormCadastraRegistro_Load(object sender, EventArgs e)
        {

        }
        public FormCadastraRegistro(int ID_PESSOA_LOGADA, string NomeAcesso, string NomeServidor, string NomeBaseDados, string NomeUsuario, string SenhaBaseDados)
        {
            InitializeComponent();

            txtOrigemRegistro.MaxLength = 1000;

            this.txtDataSolicitacaoProcesso.Value = DateTime.Now.Date;

            this.txtDataContatoRegistro.Value = DateTime.Now.Date;

            this.IdPessoaLogada = ID_PESSOA_LOGADA;
            this.NomeAcesso = NomeAcesso;
            NomeLogado.Text = "NOME:" + NomeAcesso;

            this.NomeServidor = NomeServidor;
            this.NomeBaseDados = NomeBaseDados;
            this.NomeUsuario = NomeUsuario;
            this.SenhaBaseDados = SenhaBaseDados;
            this.connetionString = "Data Source=" + this.NomeServidor + ";Initial Catalog=" + this.NomeBaseDados + ";Persist Security Info=True;User ID=" + this.NomeUsuario + ";Password=" + this.SenhaBaseDados + ";";
        }
        public FormCadastraRegistro(int ID_PESSOA_LOGADA, string connetionString,string NomeAcesso)
        {
            InitializeComponent();

            txtOrigemRegistro.MaxLength = 1000;

            this.txtDataSolicitacaoProcesso.Value = DateTime.Now.Date;

            this.txtDataContatoRegistro.Value = DateTime.Now.Date;

            this.IdPessoaLogada = ID_PESSOA_LOGADA;

            this.NomeAcesso = NomeAcesso;
            NomeLogado.Text = "NOME:" + NomeAcesso;

            this.connetionString = connetionString;
        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            CadastroRegistro();
        }
        public void CadastroRegistro()
        {
            Conexao conexao = new Conexao(this.connetionString);
            DALRegistroGerado da = new DALRegistroGerado(conexao);

            RegistroGerados RegistroGerado = new RegistroGerados();

            if ((validaNome(txtOrigemRegistro, errorProviderCadastraRegistro) == false)) //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
            {
                try
                {
                    RegistroGerado.IdClienteRegistro = this.IdPessoa;

                    RegistroGerado.IdContato = this.IdContatoCliente;

                    RegistroGerado.Estado = 1;

                    RegistroGerado.Situacao = 1;

                    RegistroGerado.IdPessoaLogada = this.IdPessoaLogada;

                    RegistroGerado.OrigemRegistro = txtOrigemRegistro.Text;

                    RegistroGerado.DataCriadoRegistrado = Convert.ToDateTime(txtDataSolicitacaoProcesso.Value.Date.ToString("dd/MM/yyyy"));

                    RegistroGerado.DataContato = Convert.ToDateTime(txtDataContatoRegistro.Value.Date.ToString("dd/MM/yyyy"));

                    string NomeCliente = txtNomeRegistro.Text;
                    string NumeroCadastro = txtNumeroRegistro.Text;
                    string NomedoIdLogado = NomeLogado.Text;


                    if (this.operacao == "Inserir")
                    {
                        if (this.comboBoxContato.Text == "")
                        {
                            MessageBox.Show("Selecione um contato para Cadastrado no sistema!");
                        }
                        if (!(this.comboBoxContato.Text == ""))
                        {
                            GeraRegistroSalva();

                            this.IdRegistro.ToString();

                            this.IdRegistroSalva.ToString();

                            if (IdRegistro == IdRegistroSalva)
                            {
                                da.IncluirClienteRegistroGerado(RegistroGerado);

                                MessageBox.Show("Registro Gerado Cadastrado com Exito! ");

                                DialogResult dialogResult = MessageBox.Show("Deseja criar um Sub Registro?", "Aviso", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    FecharTodosFormulario();

                                    FormCadastraRegistroSub CadastraRegistroSub = new FormCadastraRegistroSub(this.IdRegistroSalva,
                                        this.IdPessoa, NomeCliente, NumeroCadastro, this.IdPessoaLogada, NomedoIdLogado, this.connetionString);
                                    CadastraRegistroSub.MdiParent = FormCadastraRegistroSub.ActiveForm;
                                    CadastraRegistroSub.Show();
                                    CadastraRegistroSub.Top = 0;
                                    CadastraRegistroSub.Left = 0;
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    FecharTodosFormulario();
                                }
                            }
                            if (IdRegistro != IdRegistroSalva)
                            {
                                da.IncluirClienteRegistroGerado(RegistroGerado);

                                MessageBox.Show("Novo número de registro N ° " + IdRegistroSalva  + " \n Registro Gerado Cadastrado com Exito! ");

                                DialogResult dialogResult = MessageBox.Show("Deseja criar um Sub Registro?", "Aviso", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    FecharTodosFormulario();

                                    FormCadastraRegistroSub CadastraRegistroSub = new FormCadastraRegistroSub(this.IdRegistroSalva,
                                        this.IdPessoa, NomeCliente, NumeroCadastro, this.IdPessoaLogada, NomedoIdLogado, this.connetionString);
                                    CadastraRegistroSub.MdiParent = FormCadastraRegistroSub.ActiveForm;
                                    CadastraRegistroSub.Show();
                                    CadastraRegistroSub.Top = 0;
                                    CadastraRegistroSub.Left = 0;
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    FecharTodosFormulario();
                                    FormCadastraRegistro CadastraRegistro = new FormCadastraRegistro(this.IdPessoaLogada, this.NomeAcesso, this.NomeServidor,
                                    this.NomeBaseDados, this.NomeUsuario, this.SenhaBaseDados);
                                    CadastraRegistro.MdiParent = this;
                                    CadastraRegistro.Show();
                                    CadastraRegistro.Top = 0;
                                    CadastraRegistro.Left = 0;
                                }
                            }
                        }
                    }
                }

                catch (Exception  ex )
                {
                    MessageBox.Show("Erro de acesso ao banco de Dados: " + ex.ToString() );
                }
            }
        }
        private void FormCadastraRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void buttonLimpaRegistro_Click(object sender, EventArgs e)
        {
            txtOrigemRegistro.Clear();
        }
    }
}
