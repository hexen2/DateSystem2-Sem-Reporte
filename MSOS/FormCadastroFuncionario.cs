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

namespace MSOS
{
    public partial class FormCadastroFuncionario : Form
    {
        private string operacao = "";

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
        private int ID_FUNCIONARIO = 0;
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
        Boolean VERIFICADOREDITAR = false;
        public Boolean VerificadorEditar
        {
            get
            {
                return this.VERIFICADOREDITAR;

            }
            set
            {
                this.VERIFICADOREDITAR = value;
            }
        }
        Boolean FORMULARIO = false;
        public Boolean Formulario
        {
            get
            {
                return this.FORMULARIO;

            }
            set
            {
                this.FORMULARIO = value;
            }
        }

        public FormCadastroFuncionario()
        {
            InitializeComponent();
        }

        private void txtDataNascimentoFuncionario_ValueChanged(object sender, EventArgs e)
        {

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaEndereco(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtEnderecoFuncionario.Text))
            {
                errorProviderFuncionario.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFuncionario.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }
        private Boolean validaAbreviacao(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtAbreviacaoFuncionario.Text))
            {
                errorProviderFuncionario.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFuncionario.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }
        private Boolean validaRe(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtReFuncionario.Text))
            {
                errorProviderFuncionario.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFuncionario.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }
        private Boolean validaNumero(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtBairroNumeroFuncionario.Text))
            {
                errorProviderFuncionario.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFuncionario.SetError(textBox, "Endereço Inválido!");
                return false;
            }

        }
        private Boolean validaCelular(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularFuncionario.Text))
            {
                errorProviderFuncionario.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFuncionario.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }
        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeFuncionario.Text))
            {
                errorProviderFuncionario.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFuncionario.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private bool validaSexo()
        {
            // Determine whether the favorite color has a valid value.
            return ((comboBoxSexoFuncionario.SelectedItem != null) &&
                (!comboBoxSexoFuncionario.SelectedItem.ToString().Equals("")));//none
        }
        private void FormCadastroFuncionario_Load(object sender, EventArgs e)
        {
            txtPesquisaREFuncionario.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaREFuncionario.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaREFuncionario.AutoCompleteCustomSource = FormCadastroFuncionario.LoadAutoCompleteReFuncionario();

            txtPesquisaNomeFuncionario.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaNomeFuncionario.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaNomeFuncionario.AutoCompleteCustomSource = FormCadastroFuncionario.LoadAutoCompleteNomeFuncionario();

            panelFuncionario.Enabled = false;

            txtNomeFuncionario.MaxLength = 50;

            txtReFuncionario.MaxLength = 9;

            txtAbreviacaoFuncionario.MaxLength = 20;

            txtEmailFuncionario.MaxLength = 40;

            txtObservacaoFuncionario.MaxLength = 40;
            txtRgFuncionario.MaxLength = 9;

        }

        private void buttonBuscaCepFuncionario_Click(object sender, EventArgs e)
        {
            string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml"
    .Replace("@cep", txtCepFuncionario.Text);
            DataSet ds = new DataSet();
            ds.ReadXml(xml);

            labelConfirmacao.Text = ds.Tables[0].Rows[0][1].ToString();
            //TesteValores.Text = txtCepCliente.Text;

            txtTipo_logradouroFuncionario.Text = ds.Tables[0].Rows[0][5].ToString();
            txtEnderecoFuncionario.Text = ds.Tables[0].Rows[0][6].ToString();
            txtBairroFuncionario.Text = ds.Tables[0].Rows[0][4].ToString();
            txtCidadeFuncionario.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSiglaCidadeFuncionario.Text = ds.Tables[0].Rows[0][2].ToString();
        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra Cliente
            {
                panelFuncionario.Enabled = true;

                txtReFuncionario.Enabled = true;



                checkBoxClienteSituacao.Checked = true;

                checkBoxClienteSituacao.Enabled = false;

                buttonCadastroFuncionario.Enabled = false;
                buttonCancelarFuncionario.Enabled = true;
                buttonEditarFuncionario.Enabled = false;
                ButtonPesquisaFuncionario.Enabled = false;


            }
            if (op == 2)//salvar Cadastro de Cliente
            {
                buttonCadastroFuncionario.Enabled = true;
                ButtonPesquisaFuncionario.Enabled = true;
                buttonVerifica.Enabled = false;
                buttonEditarFuncionario.Enabled = false;
                buttonExcluirFuncionario.Enabled = false;
                buttonCancelarFuncionario.Enabled = true;

            }
            if (op == 3)//Calcelar Cadastro de Cliente
            {

                panelFuncionario.Enabled = false;

                radioButtonOculto.Checked = true;
                

                buttonBuscaFuncionario.Enabled = false;
                buttonVerifica.Enabled = false;
                buttonEditarFuncionario.Enabled = false;
                buttonExcluirFuncionario.Enabled = false;
                buttonCancelarFuncionario.Enabled = true;
                buttonFecharFuncionario.Enabled = true;
                buttonCadastroFuncionario.Enabled = true;
                ButtonPesquisaFuncionario.Enabled = true;
                radioButtonPequisaRE.Enabled = false;
                radioButtonPesquisaNome.Enabled = false;
                txtPesquisaNomeFuncionario.Enabled = false;
                txtReFuncionario.Enabled = false;




            }
            if (op == 4) //  Editar Cadastro de Funcionario
            {
                panelFuncionario.Enabled = true;

                txtReFuncionario.Enabled = false;

                txtCepFuncionario.Enabled = false;

                comboBoxSexoFuncionario.Enabled = false;

                txtCpfFuncionario.Enabled = false;

                txtRgFuncionario.Enabled = false;

                txtDataNascimentoFuncionario.Enabled = false;

                buttonCadastroFuncionario.Enabled = false;
                buttonCancelarFuncionario.Enabled = true;
                buttonEditarFuncionario.Enabled = false;
                buttonVerifica.Enabled = true;

                VERIFICADOREDITAR = true;

            }
            if (op == 5)//txtCadastro de Funcionario que não pode se aberto!
            {
                txtCidadeFuncionario.Enabled = false;

                txtEnderecoFuncionario.Enabled = false;

                txtSiglaCidadeFuncionario.Enabled = false;

                txtTipo_logradouroFuncionario.Enabled = false;

                txtBairroFuncionario.Enabled = false;
            }
            if (op == 6)//Pesquisa de Funcionario Inicializado
            {
                buttonBuscaFuncionario.Enabled = true;

                radioButtonPequisaRE.Enabled = true;

                radioButtonPesquisaNome.Enabled = true;

                buttonCadastroFuncionario.Enabled = false;
            }
            if (op == 7)//Botão Verificar informações Passadas
            {

                txtNomeFuncionario.Enabled = false;

                txtAbreviacaoFuncionario.Enabled = false;

                txtReFuncionario.Enabled = false;

                txtBairroNumeroFuncionario.Enabled = false;

                txtCpfFuncionario.Enabled = false;
                
                txtRgFuncionario.Enabled = false;

                txtDataNascimentoFuncionario.Enabled = false;


                txtEnderecoFuncionario.Enabled = false;

                txtTelefoneFuncionario.Enabled = false;

                txtTelefone2Funcionario.Enabled = false;

                txtCelularFuncionario.Enabled = false;

                txtCelular2Funcionario.Enabled = false;

                txtBairroFuncionario.Enabled = false;

                txtCepFuncionario.Enabled = false;

                txtEmailFuncionario.Enabled = false;

                txtObservacaoFuncionario.Enabled = false;

                buttonBuscaFuncionario.Enabled = false;

                txtComplFuncionario.Enabled = false;
    
            }
            if (op == 8)//Libera Editar e Excluir
            {
                buttonEditarFuncionario.Enabled = true;
                buttonExcluirFuncionario.Enabled = true;
            }
            if (op == 9)//Libera Pesquisa Por MS e Nome.
            {

                buttonCadastroFuncionario.Enabled = false;
                ButtonPesquisaFuncionario.Enabled = false;
                radioButtonPequisaRE.Enabled = true;
                radioButtonPesquisaNome.Enabled = true;


            }
            if (op == 10) //Limpa os textos do txtTodos
            {
                txtNomeFuncionario.Clear();

                txtAbreviacaoFuncionario.Clear();

                txtReFuncionario.Clear();

                txtCepFuncionario.Clear();

                txtBairroNumeroFuncionario.Clear();

                txtTelefoneFuncionario.Clear();

                txtTelefone2Funcionario.Clear();

                txtCelularFuncionario.Clear();

                txtCelular2Funcionario.Clear();

                txtComplFuncionario.Clear();

                txtEmailFuncionario.Clear();

                txtCpfFuncionario.Clear();

                txtRgFuncionario.Clear();

                txtObservacaoFuncionario.Clear();

                txtTipo_logradouroFuncionario.Clear();

                txtEnderecoFuncionario.Clear();

                txtBairroFuncionario.Clear();

                txtCidadeFuncionario.Clear();

                txtSiglaCidadeFuncionario.Clear();
            }
            if (op == 11)//bloqueia Editar e Excluir
            {
                buttonEditarFuncionario.Enabled = false;
                buttonExcluirFuncionario.Enabled = false;
            }

        }

        private void radioButtonPequisaRE_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaREFuncionario.Enabled = true;
            txtPesquisaNomeFuncionario.Enabled = false;
            buttonEditarFuncionario.Enabled = false;
            buttonExcluirFuncionario.Enabled = false;
            txtPesquisaNomeFuncionario.Clear();
            AlteraBotoes(10);
        }

        private void radioButtonPesquisaNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaREFuncionario.Enabled = false;
            txtPesquisaNomeFuncionario.Enabled = true;
            buttonEditarFuncionario.Enabled = false;
            buttonExcluirFuncionario.Enabled = false;
            txtPesquisaREFuncionario.Clear();
            AlteraBotoes(10);
        }

        private void buttonCadastroFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                this.operacao = "inserir";

                buttonVerifica.Enabled = true;

                AlteraBotoes(1);

                AlteraBotoes(5);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Carregar o Salvar! " + ex.Message);
            }
        }

        //BOTÃO PARA EDITAR CADASTRO DE CLIENTE
        private void buttonEditarCliente_Click(object sender, EventArgs e)
        {
            AlteraBotoes(4);

            this.operacao = "Editar";

        }

        //BOTÃO PARA CANCELAR CADASTRO DE CLIENTE
        private void buttonCancelarCliente_Click(object sender, EventArgs e)
        {
            //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS
            FecharTodosFormulario();
        }

        private void FormCadastroClientes_Load(object sender, EventArgs e)
        {
            txtPesquisaREFuncionario.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaREFuncionario.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaREFuncionario.AutoCompleteCustomSource = FormCadastroFuncionario.LoadAutoCompleteReFuncionario();

            txtPesquisaNomeFuncionario.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaNomeFuncionario.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaNomeFuncionario.AutoCompleteCustomSource = FormCadastroFuncionario.LoadAutoCompleteNomeFuncionario();

            panelFuncionario.Enabled = true;

            buttonCadastroFuncionario.Enabled = true;

            txtNomeFuncionario.MaxLength = 50;

            txtReFuncionario.MaxLength = 9;

            txtPesquisaREFuncionario.MaxLength = 9;

            txtEnderecoFuncionario.MaxLength = 50;

            txtComplFuncionario.MaxLength = 20;

            txtBairroFuncionario.MaxLength = 20;

            txtCidadeFuncionario.MaxLength = 20;

            txtEmailFuncionario.MaxLength = 40;



            txtObservacaoFuncionario.MaxLength = 40;



            AlteraBotoes(6);
        }
        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!
        public static void CancelaCadastradoFuncionario(Type frmType)
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
        //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS
        public void FecharTodosFormulario()
        {
            CancelaCadastradoFuncionario(typeof(FormCadastroFuncionario));
        }

        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR MS
        public static DataTable LoadDataTableReFuncionario()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaFuncionarioRe ";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }
        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA RE
        public static AutoCompleteStringCollection LoadAutoCompleteReFuncionario()
        {
            DataTable dt = LoadDataTableReFuncionario();

            AutoCompleteStringCollection stringMS = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringMS.Add(Convert.ToString(row["RE"]));
            }

            return stringMS;
        }
        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR NOME
        public static DataTable LoadDataTableNOMEFuncionario()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaFuncionarioNome; ";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }

        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA NOME Funcionario
        public static AutoCompleteStringCollection LoadAutoCompleteNomeFuncionario()
        {
            DataTable dt = LoadDataTableNOMEFuncionario();

            AutoCompleteStringCollection stringNome = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringNome.Add(Convert.ToString(row["NOME"]));
            }

            return stringNome;
        }

        private void buttonEditarFuncionario_Click(object sender, EventArgs e)
        {
            AlteraBotoes(4);

            this.operacao = "Editar";
        }

        private void buttonExcluirFuncionario_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja Excluir o registro?", "Aviso", MessageBoxButtons.YesNo);

            string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao = new Conexao(strConexao);
            DALCadastro dal = new DALCadastro(conexao);

            if (d.ToString() == "Yes")
            {

                    dal.ExcluirFuncionario(IdFuncionario);
                    //Metodo que fecha Funcionario Fisico e Juridico
                    FecharTodosFormulario();
                    AlteraBotoes(10);
                    txtPesquisaREFuncionario.Clear();
                    txtPesquisaNomeFuncionario.Clear();
            }
        }

        private void buttonCancelarFuncionario_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormCadastroFuncionario cadastracliente = new FormCadastroFuncionario();
            cadastracliente.MdiParent = FormCadastroFuncionario.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            if ((validaNome(txtNomeFuncionario, errorProviderFuncionario) == true) && (validaRe(txtReFuncionario, errorProviderFuncionario) == true) &&
                (validaNumero(txtBairroNumeroFuncionario, errorProviderFuncionario) == true))//(labelConfirmacao.Text).Equals("sucesso - cep completo"))
            {
                try
                {
                    string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
                    Conexao conexao = new Conexao(strConexao);
                    DALCadastro da = new DALCadastro(conexao);
                    Funcionario cadastra = new Funcionario();

                    if ((validaSexo()) && comboBoxSexoFuncionario.SelectedItem.ToString() == "M")
                    {
                                    
                        buttonVerifica.Enabled = false;

                        cadastra.Nome = txtNomeFuncionario.Text;
                        cadastra.IdRe = int.Parse(txtReFuncionario.Text);
                        cadastra.Abreviacao = txtAbreviacaoFuncionario.Text;
                        cadastra.Telefone = txtTelefoneFuncionario.Text;
                        cadastra.Telefone2 = txtTelefone2Funcionario.Text;
                        cadastra.Celular = txtCelularFuncionario.Text;
                        cadastra.Celular2 = txtCelular2Funcionario.Text;
                        cadastra.Situacao = 1;
                        cadastra.Email = txtEmailFuncionario.Text;
                        cadastra.Cpf = txtCpfFuncionario.Text;
                        cadastra.Rg = txtRgFuncionario.Text;
                        cadastra.Sexo = "M";
                        cadastra.Observacao = txtObservacaoFuncionario.Text;
                        cadastra.DataNascimento = txtDataNascimentoFuncionario.Text;

                        if (this.operacao == "inserir")
                        {
                            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

                            SqlConnection conn = new SqlConnection(connectionString);

                            //Verifica Se a MS é Valida no sistema!

                            int RE = int.Parse(txtReFuncionario.Text);

                            SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaReValidar " + RE + ";", conn);

                            DataSet ds2 = new DataSet();
                            da2.Fill(ds2);
                            if (ds2.Tables[0].Rows.Count > 0)

                            {
                                MessageBox.Show("O RE consta no sistema não pode ser Inserido!");
                            }
                            if (!(ds2.Tables[0].Rows.Count > 0))
                            {
                                da.IncluirFuncionario(cadastra);

                                string strConexao1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
                                Conexao conexao1 = new Conexao(strConexao1);
                                DALCadastro da1 = new DALCadastro(conexao1);

                                CepFEcs cadastraCep = new CepFEcs();

                                cadastraCep.idCep = int.Parse(cadastra.IdFuncionario.ToString());
                                cadastraCep.Cepc = int.Parse(txtCepFuncionario.Text);
                                cadastraCep.TipoLogradouro = txtTipo_logradouroFuncionario.Text;
                                cadastraCep.Endereco = txtEnderecoFuncionario.Text;
                                cadastraCep.Numero = int.Parse(txtBairroNumeroFuncionario.Text);
                                cadastraCep.Complemento = txtComplFuncionario.Text;
                                cadastraCep.Bairro = txtBairroFuncionario.Text;
                                cadastraCep.Cidade = txtCidadeFuncionario.Text;
                                cadastraCep.SiglaCidade = txtSiglaCidadeFuncionario.Text;

                                da1.IncluirCepFuncionario(cadastraCep);

                                FecharTodosFormulario();

                                FormCadastroFuncionario cadastracliente = new FormCadastroFuncionario();
                                cadastracliente.MdiParent = FormCadastroFuncionario.ActiveForm;
                                cadastracliente.Show();
                                cadastracliente.Top = 0;
                                cadastracliente.Left = 0;

                                MessageBox.Show("O funcionário foi cadastrado com sucesso!");
                            }
                        }
                    }
                    if ((validaSexo()) && comboBoxSexoFuncionario.SelectedItem.ToString() == "F")
                    {

                        buttonVerifica.Enabled = false;

                        cadastra.Nome = txtNomeFuncionario.Text;
                        cadastra.IdRe = int.Parse(txtReFuncionario.Text);
                        cadastra.Abreviacao = txtAbreviacaoFuncionario.Text;
                        cadastra.Telefone = txtTelefoneFuncionario.Text;
                        cadastra.Telefone2 = txtTelefone2Funcionario.Text;
                        cadastra.Celular = txtCelularFuncionario.Text;
                        cadastra.Celular2 = txtCelular2Funcionario.Text;
                        cadastra.Situacao = 1;
                        cadastra.Email = txtEmailFuncionario.Text;
                        cadastra.Cpf = txtCpfFuncionario.Text;
                        cadastra.Rg = txtRgFuncionario.Text;
                        cadastra.Sexo = "F";
                        cadastra.Observacao = txtObservacaoFuncionario.Text;
                        cadastra.DataNascimento = txtDataNascimentoFuncionario.Text;

                        if (this.operacao == "inserir")
                        {
                            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

                            SqlConnection conn = new SqlConnection(connectionString);

                            //Verifica Se a MS é Valida no sistema!

                            int RE = int.Parse(txtReFuncionario.Text);

                            SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaMsValidar " + RE + ";", conn);

                            DataSet ds2 = new DataSet();
                            da2.Fill(ds2);
                            if (ds2.Tables[0].Rows.Count > 0)

                            {
                                MessageBox.Show("O Ms consta no sistema não pode ser Inserido!");
                            }
                            if (!(ds2.Tables[0].Rows.Count > 0))
                            {
                                da.IncluirFuncionario(cadastra);

                                string strConexao1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
                                Conexao conexao1 = new Conexao(strConexao1);
                                DALCadastro da1 = new DALCadastro(conexao1);

                                CepFEcs cadastraCep = new CepFEcs();

                                cadastraCep.idCep = int.Parse(cadastra.IdFuncionario.ToString());
                                cadastraCep.Cepc = int.Parse(txtCepFuncionario.Text);
                                cadastraCep.TipoLogradouro = txtTipo_logradouroFuncionario.Text;
                                cadastraCep.Endereco = txtEnderecoFuncionario.Text;
                                cadastraCep.Numero = int.Parse(txtBairroNumeroFuncionario.Text);
                                cadastraCep.Complemento = txtComplFuncionario.Text;
                                cadastraCep.Bairro = txtBairroFuncionario.Text;
                                cadastraCep.Cidade = txtCidadeFuncionario.Text;
                                cadastraCep.SiglaCidade = txtSiglaCidadeFuncionario.Text;

                                da1.IncluirCepFuncionario(cadastraCep);

                                FecharTodosFormulario();

                                FormCadastroFuncionario cadastracliente = new FormCadastroFuncionario();
                                cadastracliente.MdiParent = FormCadastroFuncionario.ActiveForm;
                                cadastracliente.Show();
                                cadastracliente.Top = 0;
                                cadastracliente.Left = 0;

                                MessageBox.Show("O funcionário foi cadastrado com sucesso!");

                            }
                        }
                    }
                    if (!validaSexo())
                    {
                        MessageBox.Show("Por favor Digite um Sexo Válido!");
                    }
                }
                    
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de acesso ao banco de Dados-----------------------------------------------------------------------------------------------------------------------------------------. ", ex.Message);
                }
            }
            //-------------------------EDITAR CADASTRATO---------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (this.operacao == "Editar")
            {
                if ((validaNome(txtNomeFuncionario, errorProviderFuncionario) == true) && (validaRe(txtReFuncionario, errorProviderFuncionario) == true) &&
                    (validaNumero(txtBairroNumeroFuncionario, errorProviderFuncionario) == true))//(labelConfirmacao.Text).Equals("sucesso - cep completo"))
                {
                    try
                    {
                        string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
                        Conexao conexao = new Conexao(strConexao);
                        DALCadastro da = new DALCadastro(conexao);

                        Funcionario cadastra = new Funcionario();

                        CepFEcs cadastraCep = new CepFEcs();

                        cadastra.IdFuncionario = IDPESSOA;
                        cadastra.Nome = txtNomeFuncionario.Text;
                        cadastra.Abreviacao = txtAbreviacaoFuncionario.Text;
                        cadastra.Telefone = txtTelefoneFuncionario.Text;
                        cadastra.Telefone2 = txtTelefone2Funcionario.Text;
                        cadastra.Celular = txtCelularFuncionario.Text;
                        cadastra.Celular2 = txtCelular2Funcionario.Text;                      
                        cadastra.Email = txtEmailFuncionario.Text;                       
                        cadastra.Observacao = txtObservacaoFuncionario.Text;
                        if (checkBoxClienteSituacao.Checked == true)
                        {
                            cadastra.Situacao = 1;
                        }
                        else if (checkBoxClienteSituacao.Checked == false)
                        {
                            cadastra.Situacao = 2;
                        }


                        da.AlterarFuncionario(cadastra);

                        string strConexao1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
                        Conexao conexao1 = new Conexao(strConexao1);
                        DALCadastro da1 = new DALCadastro(conexao1);

                        cadastraCep.idCep = IDPESSOA;
                        cadastraCep.Complemento = txtComplFuncionario.Text;

                        da1.AlteraCepFuncionario(cadastraCep);

                        FecharTodosFormulario();

                        FormCadastroFuncionario cadastracliente = new FormCadastroFuncionario();
                        cadastracliente.MdiParent = FormCadastroFuncionario.ActiveForm;
                        cadastracliente.Show();
                        cadastracliente.Top = 0;
                        cadastracliente.Left = 0;

                        //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS


                        AlteraBotoes(2);
                        AlteraBotoes(4);
                        AlteraBotoes(10);

                        MessageBox.Show("As alterações no Cadastrado Cliente Foram Salvas!");

                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro de acesso ao banco de Dados-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------. ", ex.Message);
                    }
                }
            }
        }

        private void buttonBuscaFuncionario_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

            SqlConnection conn = new SqlConnection(connectionString);


            FORMULARIO = true;

            if (radioButtonPequisaRE.Checked)
            {

                if ((txtPesquisaREFuncionario.Text == ""))
                {
                    //Metodo que fecha Funcionario Fisico e Juridico
                    AlteraBotoes(11);
                    AlteraBotoes(10);
                    MessageBox.Show("O RE não pode esta em branco!");
                }

                if (!(txtPesquisaREFuncionario.Text == ""))
                {
                    int RE = int.Parse(this.txtPesquisaREFuncionario.Text);
                    //SELECIONA POR RE
                    SqlDataAdapter da = new SqlDataAdapter("EXEC ConsultaFuncionarioReTxt " + RE + "; ", conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    conn.Open();

                    if ((radioButtonPequisaRE.Checked) && (ds.Tables[0].Rows.Count > 0))
                    {
                        IDPESSOA = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                        if (IDPESSOA != 0)
                        {
                            AlteraBotoes(8);
                        }
                        if (IDPESSOA == 0)
                        {
                            AlteraBotoes(10);

                            txtPesquisaREFuncionario.Clear();

                            txtPesquisaNomeFuncionario.Clear();

                            buttonExcluirFuncionario.Enabled = false;
                            buttonEditarFuncionario.Enabled = false;
                        }

                        try
                        {
                            MessageBox.Show("Valor Passado: " + IDPESSOA);

                            txtReFuncionario.Text = ds.Tables[0].Rows[0][1].ToString();
                            txtNomeFuncionario.Text = ds.Tables[0].Rows[0][2].ToString();
                            txtAbreviacaoFuncionario.Text = ds.Tables[0].Rows[0][3].ToString();
                            txtTelefoneFuncionario.Text = ds.Tables[0].Rows[0][4].ToString();
                            txtTelefone2Funcionario.Text = ds.Tables[0].Rows[0][5].ToString();
                            txtCelularFuncionario.Text = ds.Tables[0].Rows[0][6].ToString();
                            txtCelular2Funcionario.Text = ds.Tables[0].Rows[0][7].ToString();
                            txtEmailFuncionario.Text = ds.Tables[0].Rows[0][9].ToString();
                            txtObservacaoFuncionario.Text = ds.Tables[0].Rows[0][10].ToString();
                            comboBoxSexoFuncionario.Text = ds.Tables[0].Rows[0][11].ToString();
                            txtCpfFuncionario.Text = ds.Tables[0].Rows[0][12].ToString();
                            txtRgFuncionario.Text = ds.Tables[0].Rows[0][13].ToString();
                            txtDataNascimentoFuncionario.Text = ds.Tables[0].Rows[0][14].ToString();
                            int status = int.Parse(ds.Tables[0].Rows[0][7].ToString());
                            if (status == 1)
                            {
                                checkBoxClienteSituacao.Checked = true;
                            }



                            txtCepFuncionario.Text = ds.Tables[0].Rows[0][24].ToString();
                            txtTipo_logradouroFuncionario.Text = ds.Tables[0].Rows[0][17].ToString();
                            txtEnderecoFuncionario.Text = ds.Tables[0].Rows[0][18].ToString();
                            txtBairroNumeroFuncionario.Text = ds.Tables[0].Rows[0][19].ToString();
                            txtComplFuncionario.Text = ds.Tables[0].Rows[0][20].ToString();
                            txtBairroFuncionario.Text = ds.Tables[0].Rows[0][21].ToString();
                            txtCidadeFuncionario.Text = ds.Tables[0].Rows[0][22].ToString();
                            txtSiglaCidadeFuncionario.Text = ds.Tables[0].Rows[0][23].ToString();


                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (!(ds.Tables[0].Rows.Count > 0))
                    {
                        //Metodo que fecha Funcionario Fisico e Juridico
                        AlteraBotoes(11);
                        AlteraBotoes(10);
                        MessageBox.Show("O RE:  " + RE + "  ,não Consta no sistema!");
                    }
                }
            }

            if (radioButtonPesquisaNome.Checked)
            {
                AlteraBotoes(10);

                //SELECIONA POR NOME
                SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaFuncionarioNomeTxt '" + txtPesquisaNomeFuncionario.Text + "'; ", conn);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                if ((txtPesquisaNomeFuncionario.Text == ""))
                {
                    //Metodo que fecha Funcionario Fisico e Juridico
                    AlteraBotoes(11);
                    AlteraBotoes(10);
                    MessageBox.Show("O Nome não pode esta em branco!");
                }

                if (!(txtPesquisaNomeFuncionario.Text == ""))
                {
                    conn.Open();

                    if ((radioButtonPesquisaNome.Checked) && (ds2.Tables[0].Rows.Count > 0))
                    {
                        if (FORMULARIO == true)
                        {
                            //Metodo que fecha Funcionario Fisico e Juridico
                            AlteraBotoes(10);

                            FORMULARIO = false;
                        }

                        IDPESSOA = int.Parse(ds2.Tables[0].Rows[0][0].ToString());

                        if (IDPESSOA != 0)
                        {
                            buttonExcluirFuncionario.Enabled = true;
                            buttonEditarFuncionario.Enabled = true;
                        }
                        if (IDPESSOA == 0)
                        {
                            AlteraBotoes(10);

                            txtPesquisaREFuncionario.Clear();

                            txtPesquisaNomeFuncionario.Clear();

                            buttonExcluirFuncionario.Enabled = false;
                            buttonEditarFuncionario.Enabled = false;
                        }

                        IDPESSOA = int.Parse(ds2.Tables[0].Rows[0][0].ToString());

                        MessageBox.Show("Valor Passado: " + IDPESSOA);
                        try
                        {
                            txtReFuncionario.Text = ds2.Tables[0].Rows[0][1].ToString();
                            txtNomeFuncionario.Text = ds2.Tables[0].Rows[0][2].ToString();
                            txtAbreviacaoFuncionario.Text = ds2.Tables[0].Rows[0][3].ToString();
                            txtTelefoneFuncionario.Text = ds2.Tables[0].Rows[0][4].ToString();
                            txtTelefone2Funcionario.Text = ds2.Tables[0].Rows[0][5].ToString();
                            txtCelularFuncionario.Text = ds2.Tables[0].Rows[0][6].ToString();
                            txtCelular2Funcionario.Text = ds2.Tables[0].Rows[0][7].ToString();
                            txtEmailFuncionario.Text = ds2.Tables[0].Rows[0][9].ToString();
                            txtObservacaoFuncionario.Text = ds2.Tables[0].Rows[0][10].ToString();
                            comboBoxSexoFuncionario.Text = ds2.Tables[0].Rows[0][11].ToString();
                            txtCpfFuncionario.Text = ds2.Tables[0].Rows[0][12].ToString();
                            txtRgFuncionario.Text = ds2.Tables[0].Rows[0][13].ToString();
                            txtDataNascimentoFuncionario.Text = ds2.Tables[0].Rows[0][14].ToString();
                            int status = int.Parse(ds2.Tables[0].Rows[0][7].ToString());
                            if (status == 1)
                            {
                                checkBoxClienteSituacao.Checked = true;
                            }



                            txtCepFuncionario.Text = ds2.Tables[0].Rows[0][24].ToString();
                            txtTipo_logradouroFuncionario.Text = ds2.Tables[0].Rows[0][17].ToString();
                            txtEnderecoFuncionario.Text = ds2.Tables[0].Rows[0][18].ToString();
                            txtBairroNumeroFuncionario.Text = ds2.Tables[0].Rows[0][19].ToString();
                            txtComplFuncionario.Text = ds2.Tables[0].Rows[0][20].ToString();
                            txtBairroFuncionario.Text = ds2.Tables[0].Rows[0][21].ToString();
                            txtCidadeFuncionario.Text = ds2.Tables[0].Rows[0][22].ToString();
                            txtSiglaCidadeFuncionario.Text = ds2.Tables[0].Rows[0][23].ToString();

                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (!(ds2.Tables[0].Rows.Count > 0))
                    {
                        AlteraBotoes(11);
                        AlteraBotoes(10);

                        MessageBox.Show("O nome: " + txtPesquisaNomeFuncionario.Text + " não consta no sistema!");
                    }
                }
            }
            if (!(radioButtonPequisaRE.Checked) && !(radioButtonPesquisaNome.Checked)) MessageBox.Show("Seleciona Ms ou Nome para uma Pesquisa!");


        }
        private void ButtonPesquisaFuncionario_Click_1(object sender, EventArgs e)
        {
            AlteraBotoes(6);
            ButtonPesquisaFuncionario.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = txtDataNascimentoFuncionario.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }
    }
}

