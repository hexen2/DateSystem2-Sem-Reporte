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
    public partial class FormClientesContatos : Form
    {
        private string operacao = "";

        private int IDPESSOA = 0;
        public int idPessoa
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
        private int IDCCONTATOS = 0;
        public int idcontatos
        {
            get
            {
                return this.IDCCONTATOS;

            }
            set
            {
                this.IDCCONTATOS = value;
            }
        }
        private int ID_CLIENTE = 0;
        public int IdCliente
        {
            get
            {
                return this.ID_CLIENTE;

            }
            set
            {
                this.ID_CLIENTE = value;
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
        public FormClientesContatos()
        {
            InitializeComponent();
        }

        private void buttonBuscaCContatos_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

            SqlConnection conn = new SqlConnection(connectionString);

            if (radioButtonPesquisaNome.Checked)
            {
                //SELECIONA POR NOME
                SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaClienteContatoNomeTxt '" + txtPesquisaNomeCContatos.Text + "';", conn);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                if ((txtPesquisaNomeCContatos.Text == ""))
                {
                    MessageBox.Show("O Nome não pode esta em branco!");
                }

                if (!(txtPesquisaNomeCContatos.Text == ""))
                {
                    conn.Open();

                    if ((radioButtonPesquisaNome.Checked) && (ds2.Tables[0].Rows.Count > 0))
                    {
                        IDPESSOA = int.Parse(ds2.Tables[0].Rows[0][0].ToString());

                        if (IDPESSOA != 0)
                        {
                            buttonExcluirCContatos.Enabled = true;
                            buttonEditarCContatos.Enabled = true;
                        }
                        if (IDPESSOA == 0)
                        {
                            buttonExcluirCContatos.Enabled = false;
                            buttonEditarCContatos.Enabled = false;
                        }
                        MessageBox.Show("Valor Passado: " + IDPESSOA);
                        try
                        {
                            txtNomeCContatos.Text = ds2.Tables[0].Rows[0][33].ToString();
                            txtAbreviacaoCContatos.Text = ds2.Tables[0].Rows[0][34].ToString();
                            txtTelefoneCContatos.Text = ds2.Tables[0].Rows[0][35].ToString();
                            txtTelefone2CContatos.Text = ds2.Tables[0].Rows[0][36].ToString();
                            txtCelularCContatos.Text = ds2.Tables[0].Rows[0][37].ToString();
                            txtCelular2CContatos.Text = ds2.Tables[0].Rows[0][38].ToString();
                            txtEmailCContatos.Text = ds2.Tables[0].Rows[0][39].ToString();
                            txtObservacaoCContatos.Text = ds2.Tables[0].Rows[0][40].ToString();
                            int status = int.Parse(ds2.Tables[0].Rows[0][32].ToString());
                            if (status == 1)
                            {
                                checkBoxClienteSituacao.Checked = true;
                            }


                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (!(ds2.Tables[0].Rows.Count > 0))
                    {
                        MessageBox.Show("O nome: " + txtPesquisaNomeCContatos.Text + " não consta no sistema!");
                    }
                }
            }
            if (radioButtonPequisaAbreFContatos.Checked)
            {
                //SELECIONA POR NOME
                SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaClienteContatoAbreviacaoTxt '" + txtPesquisaAbreCContatos.Text + "';", conn);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                if ((txtPesquisaAbreCContatos.Text == ""))
                {
                    //Metodo que fecha Funcionario Fisico e Juridico

                    MessageBox.Show("A Abreviacao não pode esta em branco!");
                }

                if (!(txtPesquisaAbreCContatos.Text == ""))
                {
                    conn.Open();

                    if ((radioButtonPequisaAbreFContatos.Checked) && (ds2.Tables[0].Rows.Count > 0))
                    {
                        IDPESSOA = int.Parse(ds2.Tables[0].Rows[0][0].ToString());

                        if (IDPESSOA != 0)
                        {
                            buttonExcluirCContatos.Enabled = true;
                            buttonEditarCContatos.Enabled = true;
                        }
                        if (IDPESSOA == 0)
                        {
                            buttonExcluirCContatos.Enabled = false;
                            buttonEditarCContatos.Enabled = false;
                        }
                        MessageBox.Show("Valor Passado: " + IDPESSOA);
                        try
                        {
                            txtNomeCContatos.Text = ds2.Tables[0].Rows[0][33].ToString();
                            txtAbreviacaoCContatos.Text = ds2.Tables[0].Rows[0][34].ToString();
                            txtTelefoneCContatos.Text = ds2.Tables[0].Rows[0][35].ToString();
                            txtTelefone2CContatos.Text = ds2.Tables[0].Rows[0][36].ToString();
                            txtCelularCContatos.Text = ds2.Tables[0].Rows[0][37].ToString();
                            txtCelular2CContatos.Text = ds2.Tables[0].Rows[0][38].ToString();
                            txtEmailCContatos.Text = ds2.Tables[0].Rows[0][39].ToString();
                            txtObservacaoCContatos.Text = ds2.Tables[0].Rows[0][40].ToString();
                            int status = int.Parse(ds2.Tables[0].Rows[0][32].ToString());
                            if (status == 1)
                            {
                                checkBoxClienteSituacao.Checked = true;
                            }

                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (!(ds2.Tables[0].Rows.Count > 0))
                    {
                        AlteraBotoes(10);

                        MessageBox.Show("A abreviacao: " + txtPesquisaAbreCContatos.Text + " não consta no sistema!");
                    }
                }
            }
            if (!(radioButtonPesquisaNome.Checked) && !(radioButtonPequisaAbreFContatos.Checked)) MessageBox.Show("Seleciona Nome ou Abreviacao para uma Pesquisa!");
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaAbreviacao(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtAbreviacaoCContatos.Text))
            {
                errorProviderCClientes.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCClientes.SetError(textBox, "Abreviação Inválido!");
                return false;
            }
        }
        private Boolean validaCelular(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularCContatos.Text))
            {
                errorProviderCClientes.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCClientes.SetError(textBox, "Celular Inválido!");
                return false;
            }
        }
        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeCContatos.Text))
            {
                errorProviderCClientes.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCClientes.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra Cliente
            {
                panelFContatos.Enabled = true;

                buttonCadastroCContatos.Enabled = false;
                ButtonPesquisaCContatos.Enabled = false;

                buttonVerifica.Enabled = true;
                buttonEditarCContatos.Enabled = false;
                buttonExcluirCContatos.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarCContatos.Enabled = true;
                buttonFecharCContatos.Enabled = false;

            }
            if (op == 2)//salvar Cadastro de Cliente
            {
                panelFContatos.Enabled = false;

                buttonCadastroCContatos.Enabled = true;
                ButtonPesquisaCContatos.Enabled = true;

                buttonVerifica.Enabled = false;
                buttonEditarCContatos.Enabled = false;
                buttonExcluirCContatos.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarCContatos.Enabled = false;
                buttonFecharCContatos.Enabled = true;
            }
            if (op == 3)//Calcelar Cadastro de Cliente
            {
                panelFContatos.Enabled = false;

                buttonCadastroCContatos.Enabled = true;
                ButtonPesquisaCContatos.Enabled = true;

                buttonVerifica.Enabled = false;
                buttonEditarCContatos.Enabled = false;
                buttonExcluirCContatos.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarCContatos.Enabled = false;
                buttonFecharCContatos.Enabled = true;

            }
            if (op == 4) //  Editar Cadastro de Funcionario
            {
                panelFContatos.Enabled = true;

                buttonCadastroCContatos.Enabled = false;
                ButtonPesquisaCContatos.Enabled = false;

                buttonVerifica.Enabled = true;
                buttonEditarCContatos.Enabled = false;
                buttonExcluirCContatos.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarCContatos.Enabled = true;
                buttonFecharCContatos.Enabled = true;

                VERIFICADOREDITAR = true;

            }
            if (op == 5)//Inverte o que o botão Libera
            {
                txtPesquisaNomeCContatos.Enabled = false;
                ButtonPesquisaCContatos.Enabled = false;
                radioButtonOculto.Checked = true;
                radioButtonPesquisaNome.Enabled = false;
            }
            if (op == 6)//Pesquisa de Funcionario Inicializado
            {
                buttonCadastroCContatos.Enabled = false;
                ButtonPesquisaCContatos.Enabled = false;

                buttonVerifica.Enabled = false;
                buttonEditarCContatos.Enabled = true;
                buttonExcluirCContatos.Enabled = true;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarCContatos.Enabled = true;
                buttonFecharCContatos.Enabled = true;
            }
            if (op == 7)//Limpa Campos de Cima
            {
                txtRespostaEmpresa.Clear();
                txtRespostaEmpresa2.Clear();
                txtPesquisaCCadastro1.Clear();
                txtPesquisaMSp1.Clear();
                txtPesquisaAbreCContatos.Clear();
                txtPesquisaNomeCContatos.Clear();

            }
            if (op == 8)//Libera Editar e Excluir
            {
                buttonEditarCContatos.Enabled = true;
                buttonExcluirCContatos.Enabled = true;
            }
            if (op == 9)//Libera Pesquisa Por MS e Nome.
            {

                buttonCadastroCContatos.Enabled = false;
                ButtonPesquisaCContatos.Enabled = false;
                radioButtonPequisaAbreFContatos.Enabled = true;
                radioButtonPesquisaNome.Enabled = true;


            }
            if (op == 10) //Limpa os textos do txtTodos
            {
                txtNomeCContatos.Clear();
                txtAbreviacaoCContatos.Clear();
                txtTelefoneCContatos.Clear();
                txtTelefone2CContatos.Clear();
                txtCelularCContatos.Clear();
                txtCelular2CContatos.Clear();
                txtEmailCContatos.Clear();
                txtObservacaoCContatos.Clear();


                txtPesquisaNomeCContatos.Clear();
                txtPesquisaAbreCContatos.Clear();

                txtRespostaEmpresa.Clear();
                txtRespostaEmpresa2.Clear();
                txtPesquisaCCadastro1.Clear();
                txtPesquisaMSp1.Clear();
            }
            if(op == 11)
            {
                txtNomeCContatos.Clear();
                txtAbreviacaoCContatos.Clear();
                txtTelefoneCContatos.Clear();
                txtTelefone2CContatos.Clear();
                txtCelularCContatos.Clear();
                txtCelular2CContatos.Clear();
                txtEmailCContatos.Clear();
                txtObservacaoCContatos.Clear();


                txtPesquisaNomeCContatos.Clear();
                txtPesquisaAbreCContatos.Clear();

            }
        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao = new Conexao(strConexao);
            DALCadastro da = new DALCadastro(conexao);

            ClientesContatos cadastra = new ClientesContatos();

            if ((validaNome(txtNomeCContatos, errorProviderCClientes) == true)) //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
            {
                try
                {


                    cadastra.IdContatof = idPessoa;
                    cadastra.Nome = txtNomeCContatos.Text;
                    cadastra.Abreviacao = txtAbreviacaoCContatos.Text;
                    cadastra.Telefone = txtTelefoneCContatos.Text;
                    cadastra.Telefone2 = txtTelefone2CContatos.Text;
                    cadastra.Celular = txtCelularCContatos.Text;
                    cadastra.Celular2 = txtCelular2CContatos.Text;
                    cadastra.Situacao = 1;
                    cadastra.Email = txtEmailCContatos.Text;
                    cadastra.Observacao = txtObservacaoCContatos.Text;

                    if (this.operacao == "inserir")
                    {
                        da.IncluirCContatos(cadastra);

                        checkBoxClienteSituacao.Enabled = false;
                        txtPesquisaCCadastro1.Enabled = false;
                        buttonVerifica.Enabled = false;

                        MessageBox.Show("O códígo gerado pelo Cliente Cadastra:  " + idPessoa.ToString());
                        MessageBox.Show("O códígo gerado da Contato Cliente:  " + cadastra.IdFornecedor.ToString());

                        MessageBox.Show("Contato de fornecedor Cadastrado com Exito! ");

                        FecharTodosFormulario();

                        FormClientesContatos ClientesContatos = new FormClientesContatos();
                        ClientesContatos.MdiParent = FormClientesContatos.ActiveForm;
                        ClientesContatos.Show();
                        ClientesContatos.Top = 0;
                        ClientesContatos.Left = 0;

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
                if ((validaNome(txtNomeCContatos, errorProviderCClientes) == true))//(labelConfirmacao.Text).Equals("sucesso - cep completo"))
                {
                    try
                    {
                        cadastra.Nome = txtNomeCContatos.Text;
                        cadastra.Abreviacao = txtAbreviacaoCContatos.Text;
                        cadastra.Telefone = txtTelefoneCContatos.Text;
                        cadastra.Telefone2 = txtTelefone2CContatos.Text;
                        cadastra.Celular = txtCelularCContatos.Text;
                        cadastra.Celular2 = txtCelular2CContatos.Text;
                        cadastra.Email = txtEmailCContatos.Text;
                        cadastra.Observacao = txtObservacaoCContatos.Text;
                        if (checkBoxClienteSituacao.Checked == true)
                        {
                            cadastra.Situacao = 1;
                        }
                        else if (checkBoxClienteSituacao.Checked == false)
                        {
                            cadastra.Situacao = 2;
                        }

                        da.AlterarCContatos(cadastra);

                        //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS

                        MessageBox.Show("As alterações no Cadastrado Fornecedor Contatos Foram Salvas!");

                        FecharTodosFormulario();

                        FormClientesContatos ClientesContatos = new FormClientesContatos();
                        ClientesContatos.MdiParent = FormClientesContatos.ActiveForm;
                        ClientesContatos.Show();
                        ClientesContatos.Top = 0;
                        ClientesContatos.Left = 0;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro de acesso ao banco de Dados-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------. ", ex.Message);
                    }
                }
            }
        }
        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA NOME contato do fornecedor
        public static AutoCompleteStringCollection LoadAutoCompleteNomeCContatos()
        {
            DataTable dt = LoadDataTableNOMECContatos();

            AutoCompleteStringCollection stringNome = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringNome.Add(Convert.ToString(row["NOME"]));
            }

            return stringNome;
        }
        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR NOME do contato do Fornecedor
        public static DataTable LoadDataTableNOMECContatos()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string sql = "EXEC ConsultaClienteContatoNome ";

            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        
        }
        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA ABREVIACAO
        public static AutoCompleteStringCollection LoadAutoCompleteAbreFContatos()
        {
            DataTable dt = LoadDataTableAbreFContatos();

            AutoCompleteStringCollection stringAbreviacao = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringAbreviacao.Add(Convert.ToString(row["ABREVIACAO"]));
            }

            return stringAbreviacao;
        }
        public static DataTable LoadDataTableAbreFContatos()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaClienteContatoAbreviacao; ";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }

        /*---------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA NOME
        public static AutoCompleteStringCollection LoadAutoCompleteNOMECliente()
        {
            DataTable dt = LoadDataTableNOMECliente();

            AutoCompleteStringCollection MS = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                MS.Add(Convert.ToString(row["NOME"]));
            }

            return MS;
        }
        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR MS
        public static DataTable LoadDataTableNOMECliente()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaClienteContatoNome; ";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }

        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA MS
        public static AutoCompleteStringCollection LoadAutoCompleteMsFContatos()
        {
            DataTable dt = LoadDataTableMSFContatos();

            AutoCompleteStringCollection MS = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                MS.Add(Convert.ToString(row["MS"]));
            }

            return MS;
        }
        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR MS
        public static DataTable LoadDataTableMSFContatos()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaPessoaMsCliente; ";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }




/*-------------------------------------------------------------------------------------------------------------------------------------------*/

        private void FormClientesContatos_Load(object sender, EventArgs e)
        {
            //CONSULTA Contato NOME
            txtPesquisaNomeCContatos.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaNomeCContatos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaNomeCContatos.AutoCompleteCustomSource = FormClientesContatos.LoadAutoCompleteNomeCContatos();

            //CONSULTA Contato ABREVIACAO
            txtPesquisaAbreCContatos.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaAbreCContatos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaAbreCContatos.AutoCompleteCustomSource = FormClientesContatos.LoadAutoCompleteAbreFContatos();

            //Consulta Cliente por MS
            txtPesquisaMSp1.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaMSp1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaMSp1.AutoCompleteCustomSource = FormClientesContatos.LoadAutoCompleteMsFContatos();

            //Consulta Cliente por NOME
            txtPesquisaCCadastro1.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaCCadastro1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaCCadastro1.AutoCompleteCustomSource = FormClientesContatos.LoadAutoCompleteNOMECliente();

            panelFContatos.Enabled = false;

            txtNomeCContatos.MaxLength = 50;

            txtAbreviacaoCContatos.MaxLength = 20;

            txtEmailCContatos.MaxLength = 40;

            txtObservacaoCContatos.MaxLength = 40;

            radioButtonOculto.Checked = true;

            radioButtonPequisaAbreFContatos.Enabled = false;
        }
        public static void CancelaCadastradoCContatos(Type frmType)
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
            CancelaCadastradoCContatos(typeof(FormClientesContatos));
        }

        private void radioButtonPesquisaNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaAbreCContatos.Enabled = false;
            txtPesquisaNomeCContatos.Enabled = true;
            buttonEditarCContatos.Enabled = false;
            buttonExcluirCContatos.Enabled = false;
            txtPesquisaAbreCContatos.Clear();
            AlteraBotoes(10);
        }

        private void radioButtonMsFContatos_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaNomeCContatos.Enabled = false;
            txtPesquisaAbreCContatos.Enabled = false;


            txtPesquisaAbreCContatos.Clear();
            txtPesquisaNomeCContatos.Clear();
        }

        private void radioButtonPequisaAbreFContatos_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaNomeCContatos.Enabled = false;
            txtPesquisaAbreCContatos.Enabled = true;

            txtPesquisaAbreCContatos.Clear();
            txtPesquisaNomeCContatos.Clear();
        }

        private void buttonEditarCContatos_Click(object sender, EventArgs e)
        {
            this.operacao = "Editar";

            AlteraBotoes(4);
            checkBoxClienteSituacao.Enabled = true;
        }

        private void buttonExcluirCContatos_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja Excluir o registro?", "Aviso", MessageBoxButtons.YesNo);

            string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao = new Conexao(strConexao);
            DALCadastro dal = new DALCadastro(conexao);

            if (d.ToString() == "Yes")
            {
                dal.ExcluirCcontatos(IDPESSOA);

                FecharTodosFormulario();

                FormClientesContatos FContatos = new FormClientesContatos();
                FContatos.MdiParent = FormClientesContatos.ActiveForm;
                FContatos.Show();
                FContatos.Top = 0;
                FContatos.Left = 0;
            }
        }

        private void buttonLimpaFornecedor_Click(object sender, EventArgs e)
        {
            AlteraBotoes(11);
        }

        private void buttonCancelarCContatos_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormClientesContatos FContatos = new FormClientesContatos();
            FContatos.MdiParent = FormClientesContatos.ActiveForm;
            FContatos.Show();
            FContatos.Top = 0;
            FContatos.Left = 0;
        }

        private void buttonFecharCContatos_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }
        private void ButtonPesquisaCContatos_Click(object sender, EventArgs e)
        {
            radioButtonPesquisaNome.Enabled = true;
            //radioButtonPequisaAbreFContatos.Enabled = true;
            //radioButtonMsFContatos.Enabled = true;
            buttonBuscaCContatos.Enabled = true;
            panelPesquisaEmpresa.Enabled = true;

            buttonCadastroCContatos.Enabled = false;
            ButtonPesquisaCContatos.Enabled = false;
        }

        private void buttonCadastroCContatos_Click(object sender, EventArgs e)
        {
            try
            {
                this.operacao = "inserir";

                //buttonVerifica.Enabled = true;

                radioButtonCNome1.Enabled = true;

                radioButtonMS1.Enabled = true;

                panelPesquisaEmpresa.Enabled = true;

                buttonBuscaEmpresa.Enabled = true;

                buttonEditarCContatos.Enabled = false;

                checkBoxClienteSituacao.Checked = true;

                checkBoxClienteSituacao.Enabled = false;

                buttonCadastroCContatos.Enabled = false;
                ButtonPesquisaCContatos.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Carregar o Salvar! " + ex.Message);
            }
        }

        private void radioButtonAbreviacaoP1_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaCCadastro1.Enabled = true;
            txtPesquisaMSp1.Enabled = false;
            txtPesquisaMSp1.Clear();
            txtRespostaEmpresa.Clear();
            txtRespostaEmpresa2.Clear();
            AlteraBotoes(10);
        }

        private void radioButtonMSP1_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMSp1.Enabled = true;
            txtPesquisaCCadastro1.Enabled = false;
            txtPesquisaCCadastro1.Clear();
            txtRespostaEmpresa.Clear();
            txtRespostaEmpresa2.Clear();
            AlteraBotoes(10);
        }

        private void ButtonPesquisaCContatos_Click_1(object sender, EventArgs e)
        {
            radioButtonPequisaAbreFContatos.Enabled = true;
            radioButtonPesquisaNome.Enabled = true;

            buttonCadastroCContatos.Enabled = false;
            ButtonPesquisaCContatos.Enabled = false;
            buttonBuscaCContatos.Enabled = true;
        }

        private void buttonCadastroCContatos_Click_1(object sender, EventArgs e)
        {
            panelPesquisaEmpresa.Enabled = true;
            radioButtonCNome1.Enabled = true;
            radioButtonMS1.Enabled = true;
            buttonBuscaEmpresa.Enabled = true;

            this.operacao = "inserir";

            buttonCadastroCContatos.Enabled = false;
            ButtonPesquisaCContatos.Enabled = false;

        }

        private void radioButtonCNome1_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaCCadastro1.Enabled = true;
            txtPesquisaMSp1.Enabled = false;
            AlteraBotoes(10);
        }

        private void radioButtonMS1_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaCCadastro1.Enabled = false;
            txtPesquisaMSp1.Enabled = true;
            AlteraBotoes(10);
        }

        private void buttonBuscaEmpresa_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

            SqlConnection conn = new SqlConnection(connectionString);

            if (radioButtonMS1.Checked)
            {
                //SELECIONA POR ABREVIACAO
                int MS = int.Parse(txtPesquisaMSp1.Text);
                SqlDataAdapter da = new SqlDataAdapter("EXEC ConsultaPessoaMsClienteTxt " + MS + "; ", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (!(txtPesquisaMSp1.Text == "") && (ds.Tables[0].Rows.Count > 0))
                {
                    int tipoPessoa = 0;
                    idPessoa = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    tipoPessoa = int.Parse(ds.Tables[0].Rows[0][1].ToString());

                    if ((tipoPessoa == 1) && (ds.Tables[0].Rows.Count > 0))
                    {
                        panelFContatos.Enabled = true;
                        buttonVerifica.Enabled = true;
                        radioButtonMS1.Enabled = false;
                        radioButtonCNome1.Enabled = false;
                        txtPesquisaMSp1.Enabled = false;
                        txtPesquisaCCadastro1.Enabled = false;
                        txtRespostaEmpresa.Text = ds.Tables[0].Rows[0][3].ToString();
                        txtRespostaEmpresa2.Text = ds.Tables[0].Rows[0][16].ToString();
                    }
                    if ((tipoPessoa == 2) && (ds.Tables[0].Rows.Count > 0))
                    {
                        panelFContatos.Enabled = true;
                        buttonVerifica.Enabled = true;
                        radioButtonMS1.Enabled = false;
                        radioButtonCNome1.Enabled = false;
                        txtPesquisaMSp1.Enabled = false;
                        txtPesquisaCCadastro1.Enabled = false;

                        txtRespostaEmpresa.Text = ds.Tables[0].Rows[0][24].ToString();
                        txtRespostaEmpresa2.Text = ds.Tables[0].Rows[0][27].ToString();
                    }


                }
                if (txtPesquisaMSp1.Text == "")
                {
                    MessageBox.Show("Por favor o ms nao pode esta em Branco!");
                    AlteraBotoes(10);
                }
                else if (!(ds.Tables[0].Rows.Count > 0))
                {
                    MessageBox.Show("O Ms  " + txtPesquisaMSp1.Text + " nao consta no sistema! ");
                    AlteraBotoes(10);
                }
            }
            if (radioButtonCNome1.Checked)
            {
                //SELECIONA POR ABREVIACAO
                SqlDataAdapter da = new SqlDataAdapter("EXEC ConsultaPessoaClienteNomeTxt '" + txtPesquisaCCadastro1.Text + "'; ", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (!(txtPesquisaCCadastro1.Text == "") && (ds.Tables[0].Rows.Count > 0))
                {
                    int tipoPessoa = 0;
                    idPessoa = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    tipoPessoa = int.Parse(ds.Tables[0].Rows[0][1].ToString());

                    if ((tipoPessoa == 1) && (ds.Tables[0].Rows.Count > 0))
                    {
                        panelFContatos.Enabled = true;
                        buttonVerifica.Enabled = true;
                        txtRespostaEmpresa.Text = ds.Tables[0].Rows[0][3].ToString();
                        txtRespostaEmpresa2.Text = ds.Tables[0].Rows[0][16].ToString();
                    }
                    if ((tipoPessoa == 2) && (ds.Tables[0].Rows.Count > 0))
                    {
                        panelFContatos.Enabled = true;
                        buttonVerifica.Enabled = true;
                        txtRespostaEmpresa.Text = ds.Tables[0].Rows[0][24].ToString();
                        txtRespostaEmpresa2.Text = ds.Tables[0].Rows[0][27].ToString();
                    }


                }
                if (txtPesquisaCCadastro1.Text == "")
                {
                    MessageBox.Show("Por favor o ms nao pode esta em Branco!");
                    AlteraBotoes(10);
                }
                else if (!(ds.Tables[0].Rows.Count > 0))
                {
                    MessageBox.Show("O Ms  " + txtPesquisaCCadastro1.Text + " nao consta no sistema! ");
                    AlteraBotoes(10);
                }
            }
        }

        private void txtCelular2CContatos_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
