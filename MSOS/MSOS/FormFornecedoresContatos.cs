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
    public partial class FormFornecedoresContatos : Form
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
        private int ID_TIPO_PESSOA = 0;
        public int IdTipoPessoa
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




        public FormFornecedoresContatos()
        {
            InitializeComponent();
        }
        public FormFornecedoresContatos(int a)
        {
            if((1 == a))
            {
                InitializeComponent();

                //buttonBuscaFContatos
                txtPesquisaNomeFContatos.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtPesquisaNomeFContatos.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPesquisaNomeFContatos.AutoCompleteCustomSource = FormFornecedoresContatos.LoadAutoCompleteNomeFContatos();


                panelFContatos.Enabled = false;

                txtNomeFContatos.MaxLength = 50;

                txtAbreviacaoFContatos.MaxLength = 20;

                txtEmailFContatos.MaxLength = 40;

                txtObservacaoFContatos.MaxLength = 40;

                radioButtonOculto.Checked = true;
            }
            
            
        }

        private void txtDataNascimentoFuncionario_ValueChanged(object sender, EventArgs e)
        {

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaAbreviacao(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtAbreviacaoFContatos.Text))
            {
                errorProviderFContatos.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFContatos.SetError(textBox, "Abreviação Inválido!");
                return false;
            }
        }
        private Boolean validaCelular(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularFContatos.Text))
            {
                errorProviderFContatos.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFContatos.SetError(textBox, "Celular Inválido!");
                return false;
            }
        }
        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeFContatos.Text))
            {
                errorProviderFContatos.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFContatos.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }

        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra Cliente
            {
                panelFContatos.Enabled = true;

                buttonCadastroFContatos.Enabled = false;
                ButtonPesquisaFContatos.Enabled = false;

                buttonVerifica.Enabled = true;
                buttonEditarFContatos.Enabled = false;
                buttonExcluirFContatos.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFContatos.Enabled = true;
                buttonFecharFContatos.Enabled = false;




            }
            if (op == 2)//salvar Cadastro de Cliente
            {
                panelFContatos.Enabled = false;

                buttonCadastroFContatos.Enabled = true;
                ButtonPesquisaFContatos.Enabled = true;

                buttonVerifica.Enabled = false;
                buttonEditarFContatos.Enabled = false;
                buttonExcluirFContatos.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFContatos.Enabled = false;
                buttonFecharFContatos.Enabled = true;
            }
            if (op == 3)//Calcelar Cadastro de Cliente
            {
                panelFContatos.Enabled = false;

                buttonCadastroFContatos.Enabled = true;
                ButtonPesquisaFContatos.Enabled = true;

                buttonVerifica.Enabled = false;
                buttonEditarFContatos.Enabled = false;
                buttonExcluirFContatos.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFContatos.Enabled = false;
                buttonFecharFContatos.Enabled = true;

            }
            if (op == 4) //  Editar Cadastro de Funcionario
            {
                panelFContatos.Enabled = true;

                buttonCadastroFContatos.Enabled = false;
                ButtonPesquisaFContatos.Enabled = false;

                buttonVerifica.Enabled = true;
                buttonEditarFContatos.Enabled = false;
                buttonExcluirFContatos.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFContatos.Enabled = true;
                buttonFecharFContatos.Enabled = true;

                VERIFICADOREDITAR = true;

            }
            if (op == 5)//Inverte o que o botão Libera
            {
                txtPesquisaNomeFContatos.Enabled = false;
                ButtonPesquisaFContatos.Enabled = false;
                radioButtonOculto.Checked = true;
                radioButtonPesquisaNome.Enabled = false;
            }
            if (op == 6)//Pesquisa de Funcionario Inicializado
            {
                buttonCadastroFContatos.Enabled = false;
                ButtonPesquisaFContatos.Enabled = false;

                buttonVerifica.Enabled = false;
                buttonEditarFContatos.Enabled = true;
                buttonExcluirFContatos.Enabled = true;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFContatos.Enabled = true;
                buttonFecharFContatos.Enabled = true;
            }
            if (op == 7)//Limpa Campos de Cima
            {
                txtRespostaEmpresa.Clear();
                txtRespostaEmpresa2.Clear();
                txtPesquisaNomeCadastro.Clear();
                txtPesquisaMSp1.Clear();
                txtPesquisaAbreFContatos.Clear();
                txtPesquisaMSFContatos.Clear();
                txtPesquisaNomeFContatos.Clear();

            }
            if (op == 8)//Libera Editar e Excluir
            {
                buttonEditarFContatos.Enabled = true;
                buttonExcluirFContatos.Enabled = true;
            }
            if (op == 9)//Libera Pesquisa Por MS e Nome.
            {

                buttonCadastroFContatos.Enabled = false;
                ButtonPesquisaFContatos.Enabled = false;
                radioButtonPequisaAbreFContatos.Enabled = true;
                radioButtonPesquisaNome.Enabled = true;


            }
            if (op == 10) //Limpa os textos do txtTodos
            {
                txtNomeFContatos.Clear();
                txtAbreviacaoFContatos.Clear();
                txtTelefoneFContatos.Clear();
                txtTelefone2FContatos.Clear();
                txtCelularFContatos.Clear();
                txtCelular2FContatos.Clear();
                txtEmailFContatos.Clear();
                txtObservacaoFContatos.Clear();


                txtPesquisaNomeFContatos.Clear();
                txtPesquisaAbreFContatos.Clear();
                txtPesquisaMSFContatos.Clear();

                txtRespostaEmpresa.Clear();
                txtRespostaEmpresa2.Clear();
                txtPesquisaNomeCadastro.Clear();
                txtPesquisaMSp1.Clear();
            }
            if(op == 11)
            {
                radioButtonFNomeCadastro1.Enabled = true;

                radioButtonMSP1.Enabled = true;

                panelPesquisaEmpresa.Enabled = true;

                buttonBuscaEmpresa.Enabled = true;

                buttonEditarFContatos.Enabled = false;

                buttonLimpaFornecedor.Enabled = true;

                buttonCancelarFContatos.Enabled = true;

                checkBoxClienteSituacao.Checked = true;

                checkBoxClienteSituacao.Enabled = false;

                buttonCadastroFContatos.Enabled = false;
                ButtonPesquisaFContatos.Enabled = false;
            }
        }


        private void radioButtonPequisaRE_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaAbreFContatos.Enabled = true;
            txtPesquisaNomeFContatos.Enabled = false;
            buttonEditarFContatos.Enabled = false;
            buttonExcluirFContatos.Enabled = false;
            txtPesquisaNomeFContatos.Clear();
            AlteraBotoes(10);
        }

        private void radioButtonPesquisaNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaAbreFContatos.Enabled = false;
            txtPesquisaNomeFContatos.Enabled = true;
            buttonEditarFContatos.Enabled = false;
            buttonExcluirFContatos.Enabled = false;
            txtPesquisaAbreFContatos.Clear();
            AlteraBotoes(10);
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


        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!
        public static void CancelaCadastradoFContatos(Type frmType)
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
            CancelaCadastradoFContatos(typeof(FormFornecedoresContatos));
        }


        //METODO QUE SELECIONA NOME NO SQL ORDERNADO POR NOME  do contato do Fornecedor
        public static DataTable LoadDataTableNOMEFornecedor()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string sql = "EXEC ConsultaFornecedorNomeCadastroContatos; ";

            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }

        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA Nome
        public static AutoCompleteStringCollection LoadAutoCompleteNomeFornecedor()
        {
            DataTable dt = LoadDataTableNOMEFornecedor();

            AutoCompleteStringCollection stringNome = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringNome.Add(Convert.ToString(row["NOME"]));
            }

            return stringNome;
        }



        //METODO QUE SELECIONA ABREVIACAO NO SQL ORDERNADO POR ABREVIACAO do contato do Fornecedor
        public static DataTable LoadDataTableABREVIACAOFornecedor()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string sql = "EXEC ConsultaContatosFornecedorAbreviacao; ";

            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }

        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA ABREVIACAO
        public static AutoCompleteStringCollection LoadAutoCompleteABREVIACAOeFornecedor()
        {
            DataTable dt = LoadDataTableABREVIACAOFornecedor();

            AutoCompleteStringCollection stringNome = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringNome.Add(Convert.ToString(row["ABREVIACAO"]));
            }

            return stringNome;
        }
        //METODO QUE SELECIONA NOME NO SQL ORDERNADO POR NOME do contato do Fornecedor
        public static DataTable LoadDataTableNOMEFContatos()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string sql = "EXEC ConsultaContatosFornecedorNome; ";

            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }

        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA NOME contato do fornecedor
        public static AutoCompleteStringCollection LoadAutoCompleteNomeFContatos()
        {
            DataTable dt = LoadDataTableNOMEFContatos();

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

        }

        private void buttonCancelarFuncionario_Click(object sender, EventArgs e)
        {
            AlteraBotoes(3);
            AlteraBotoes(10);
        }


        private void ButtonPesquisaFuncionario_Click_1(object sender, EventArgs e)
        {
            AlteraBotoes(6);
            radioButtonPesquisaNome.Enabled = false;
        }
        private void FormFornecedoresContatos_Load(object sender, EventArgs e)
        {
            //USADO PARA CADASTRA CONTATOS NO FORNECEDOR
            txtPesquisaNomeCadastro.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaNomeCadastro.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaNomeCadastro.AutoCompleteCustomSource = FormFornecedoresContatos.LoadAutoCompleteNomeFornecedor();
          
            //USADO PARA PESQUISA CONTATOS DO FORNECEDOR - NOME
            //buttonBuscaFContatos
            txtPesquisaNomeFContatos.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaNomeFContatos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaNomeFContatos.AutoCompleteCustomSource = FormFornecedoresContatos.LoadAutoCompleteNomeFContatos();

            //USADO PARA PESQUISA CONTATOS DO FORNECEDOR - ABREVIACAO
            //buttonBuscaFContatos
            txtPesquisaAbreFContatos.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaAbreFContatos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaAbreFContatos.AutoCompleteCustomSource = FormFornecedoresContatos.LoadAutoCompleteABREVIACAOeFornecedor();



            panelFContatos.Enabled = false;

            txtNomeFContatos.MaxLength = 50;

            txtAbreviacaoFContatos.MaxLength = 20;

            txtEmailFContatos.MaxLength = 40;

            txtObservacaoFContatos.MaxLength = 40;

            radioButtonOculto.Checked = true;

            radioButtonPequisaAbreFContatos.Enabled = false;
            radioButtonMsFContatos.Enabled = false;

        }

        private void buttonCadastroFContatos_Click(object sender, EventArgs e)
        {
            try
            {
                this.operacao = "inserir";

                //buttonVerifica.Enabled = true;

                AlteraBotoes(11);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Carregar o Salvar! " + ex.Message);
            }
        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao = new Conexao(strConexao);
            DALCadastro da = new DALCadastro(conexao);

            FornecedorContatos cadastra = new FornecedorContatos();

            if ((validaNome(txtNomeFContatos, errorProviderFContatos) == true)) //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
            {
                try
                {
                    cadastra.IdFornecedor = idPessoa;
                    cadastra.Nome = txtNomeFContatos.Text;
                    cadastra.Abreviacao = txtAbreviacaoFContatos.Text;
                    cadastra.Telefone = txtTelefoneFContatos.Text;
                    cadastra.Telefone2 = txtTelefone2FContatos.Text;
                    cadastra.Celular = txtCelularFContatos.Text;
                    cadastra.Celular2 = txtCelular2FContatos.Text;
                    cadastra.Situacao = 1;
                    cadastra.Email = txtEmailFContatos.Text;
                    cadastra.Observacao = txtObservacaoFContatos.Text;

                    if (this.operacao == "inserir")
                    {
                        da.IncluirFContatos(cadastra);


                        txtPesquisaNomeCadastro.Enabled = false;
                        buttonVerifica.Enabled = false;

                        MessageBox.Show("Contato de fornecedor Cadastrado com Exito! ");

                        FecharTodosFormulario();

                        FormFornecedoresContatos FornecedorContatos = new FormFornecedoresContatos(1);
                        FornecedorContatos.MdiParent = FormFornecedoresContatos.ActiveForm;
                        FornecedorContatos.Show();
                        FornecedorContatos.Top = 0;
                        FornecedorContatos.Left = 0;

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
                if ((validaNome(txtNomeFContatos, errorProviderFContatos) == true))//(labelConfirmacao.Text).Equals("sucesso - cep completo"))
                {
                    try
                    {
                        string strConexao1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
                        Conexao conexao1 = new Conexao(strConexao1);
                        DALCadastro da1 = new DALCadastro(conexao1);

                        FornecedorContatos cadastra1 = new FornecedorContatos();

                        cadastra1.IdFornecedor = IDPESSOA;
                        cadastra1.Nome = txtNomeFContatos.Text;
                        cadastra1.Abreviacao = txtAbreviacaoFContatos.Text;
                        cadastra1.Telefone = txtTelefoneFContatos.Text;
                        cadastra1.Telefone2 = txtTelefone2FContatos.Text;
                        cadastra1.Celular = txtCelularFContatos.Text;
                        cadastra1.Celular2 = txtCelular2FContatos.Text;
                        cadastra1.Email = txtEmailFContatos.Text;
                        cadastra1.Observacao = txtObservacaoFContatos.Text;
                        if (checkBoxClienteSituacao.Checked == true)
                        {
                            cadastra.Situacao = 1;
                        }
                        else if (checkBoxClienteSituacao.Checked == false)
                        {
                            cadastra.Situacao = 2;
                        }


                        da1.AlterarFContatos(cadastra1);

                        //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS

                        MessageBox.Show("As alterações no Cadastrado Fornecedor Contatos Foram Salvas!");

                        FecharTodosFormulario();

                        FormFornecedoresContatos FornecedorContatos = new FormFornecedoresContatos(1);
                        FornecedorContatos.MdiParent = FormFornecedoresContatos.ActiveForm;
                        FornecedorContatos.Show();
                        FornecedorContatos.Top = 0;
                        FornecedorContatos.Left = 0;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro de acesso ao banco de Dados-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------. ", ex.Message);
                    }
                }
            }
        }

        private void buttonBuscaFContatos_Click(object sender, EventArgs e)
        {

            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

            SqlConnection conn = new SqlConnection(connectionString);

            if (radioButtonPesquisaNome.Checked)
            {
                SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaContatosFornecedorNomeTxT '" + txtPesquisaNomeFContatos.Text + "';", conn);


                DataSet ds2 = new DataSet();

                da2.Fill(ds2);

                if ((txtPesquisaNomeFContatos.Text == ""))
                {

                    MessageBox.Show("O Nome não pode esta em branco!");
                }

                if (!(txtPesquisaNomeFContatos.Text == ""))
                {
                    conn.Open();

                    if ((radioButtonPesquisaNome.Checked) && (ds2.Tables[0].Rows.Count > 0))
                    {
                        idPessoa = int.Parse(ds2.Tables[0].Rows[0][0].ToString());
                        IdTipoPessoa = int.Parse(ds2.Tables[0].Rows[0][1].ToString());

                        if (idPessoa != 0)
                        {
                            panelFContatos.Enabled = false;
                            buttonExcluirFContatos.Enabled = true;
                            buttonEditarFContatos.Enabled = true;
                        }
                        if (idPessoa == 0)
                        {
                            panelFContatos.Enabled = false;
                            buttonExcluirFContatos.Enabled = false;
                            buttonEditarFContatos.Enabled = false;
                        }
                        MessageBox.Show("Valor Passado: " + idPessoa);
                        try
                        {
                            if (IdTipoPessoa == 1)
                            {
                                buttonVerifica.Enabled = true;

                                txtRespostaEmpresa.Text = ds2.Tables[0].Rows[0][9].ToString();
                                txtRespostaEmpresa2.Text = ds2.Tables[0].Rows[0][10].ToString();
                            }
                            if (IdTipoPessoa == 2)
                            {
                                buttonVerifica.Enabled = true;

                                txtRespostaEmpresa.Text = ds2.Tables[0].Rows[0][11].ToString();
                                txtRespostaEmpresa2.Text = ds2.Tables[0].Rows[0][12].ToString();
                            }

                            txtNomeFContatos.Text = ds2.Tables[0].Rows[0][1].ToString();
                            txtAbreviacaoFContatos.Text = ds2.Tables[0].Rows[0][2].ToString();
                            txtTelefoneFContatos.Text = ds2.Tables[0].Rows[0][3].ToString();
                            txtTelefone2FContatos.Text = ds2.Tables[0].Rows[0][4].ToString();
                            txtCelularFContatos.Text = ds2.Tables[0].Rows[0][5].ToString();
                            txtCelular2FContatos.Text = ds2.Tables[0].Rows[0][6].ToString();
                            txtEmailFContatos.Text = ds2.Tables[0].Rows[0][7].ToString();
                            txtObservacaoFContatos.Text = ds2.Tables[0].Rows[0][8].ToString();
                            int status = int.Parse(ds2.Tables[0].Rows[0][7].ToString());
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

                        MessageBox.Show("O nome: " + txtPesquisaNomeFContatos.Text + " não consta no sistema!");
                    }
                }
            }
            if (radioButtonPequisaAbreFContatos.Checked)
            {
                SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaContatosFornecedorAbreviacaoTxT '" + txtPesquisaAbreFContatos.Text + "';", conn);


                DataSet ds2 = new DataSet();

                da2.Fill(ds2);

                if ((txtPesquisaAbreFContatos.Text == ""))
                {

                    MessageBox.Show("A Abreviacao não pode esta em branco!");
                }

                if (!(txtPesquisaAbreFContatos.Text == ""))
                {
                    conn.Open();

                    if ((radioButtonPequisaAbreFContatos.Checked) && (ds2.Tables[0].Rows.Count > 0))
                    {
                        idPessoa = int.Parse(ds2.Tables[0].Rows[0][0].ToString());
                        IdTipoPessoa = int.Parse(ds2.Tables[0].Rows[0][13].ToString());

                        if (idPessoa != 0)
                        {
                            panelFContatos.Enabled = false;
                            buttonExcluirFContatos.Enabled = true;
                            buttonEditarFContatos.Enabled = true;
                        }
                        if (idPessoa == 0)
                        {
                            panelFContatos.Enabled = false;
                            buttonExcluirFContatos.Enabled = false;
                            buttonEditarFContatos.Enabled = false;
                        }
                        MessageBox.Show("Valor Passado: " + idPessoa);
                        try
                        {
                            if (IdTipoPessoa == 1)
                            {
                                buttonVerifica.Enabled = true;

                                txtRespostaEmpresa.Text = ds2.Tables[0].Rows[0][9].ToString();
                                txtRespostaEmpresa2.Text = ds2.Tables[0].Rows[0][10].ToString();
                            }
                            if (IdTipoPessoa == 2)
                            {
                                buttonVerifica.Enabled = true;

                                txtRespostaEmpresa.Text = ds2.Tables[0].Rows[0][11].ToString();
                                txtRespostaEmpresa2.Text = ds2.Tables[0].Rows[0][12].ToString();
                            }

                            txtNomeFContatos.Text = ds2.Tables[0].Rows[0][1].ToString();
                            txtAbreviacaoFContatos.Text = ds2.Tables[0].Rows[0][2].ToString();
                            txtTelefoneFContatos.Text = ds2.Tables[0].Rows[0][3].ToString();
                            txtTelefone2FContatos.Text = ds2.Tables[0].Rows[0][4].ToString();
                            txtCelularFContatos.Text = ds2.Tables[0].Rows[0][5].ToString();
                            txtCelular2FContatos.Text = ds2.Tables[0].Rows[0][6].ToString();
                            txtEmailFContatos.Text = ds2.Tables[0].Rows[0][7].ToString();
                            txtObservacaoFContatos.Text = ds2.Tables[0].Rows[0][8].ToString();
                            int status = int.Parse(ds2.Tables[0].Rows[0][7].ToString());
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

                        MessageBox.Show("A Abreviacao: " + txtPesquisaAbreFContatos.Text + " não consta no sistema!");
                    }
                }
            }
            if (!(radioButtonPesquisaNome.Checked)&& !(radioButtonPequisaAbreFContatos.Checked)) MessageBox.Show("Seleciona Nome ou Abreviacao para uma Pesquisa!");
        }

        private void radioButtonPequisaAbreFContatos_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaNomeFContatos.Enabled = false;
            txtPesquisaAbreFContatos.Enabled = true;
            txtPesquisaMSFContatos.Enabled = false;

            txtPesquisaAbreFContatos.Clear();
            txtPesquisaMSFContatos.Clear();
            txtPesquisaNomeFContatos.Clear();
            AlteraBotoes(10);
        }

        private void radioButtonMsFContatos_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaNomeFContatos.Enabled = false;
            txtPesquisaAbreFContatos.Enabled = false;
            txtPesquisaMSFContatos.Enabled = true;

            txtPesquisaAbreFContatos.Clear();
            txtPesquisaMSFContatos.Clear();
            txtPesquisaNomeFContatos.Clear();
        }

        private void radioButtonPesquisaNome_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPesquisaNomeFContatos.Enabled = true;
            txtPesquisaAbreFContatos.Enabled = false;
            txtPesquisaMSFContatos.Enabled = false;

            txtPesquisaAbreFContatos.Clear();
            txtPesquisaMSFContatos.Clear();
            txtPesquisaNomeFContatos.Clear();
            AlteraBotoes(10);
        }

        private void buttonBuscaEmpresa_Click(object sender, EventArgs e)
        {
            buttonCancelarFContatos.Enabled = true;

            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

            SqlConnection conn = new SqlConnection(connectionString);

            if (radioButtonFNomeCadastro1.Checked)
            {
                //SELECIONA POR ABREVIACAO
                SqlDataAdapter da = new SqlDataAdapter("EXEC ConsultaFornecedorNomeCadastroContatostxt '" + txtPesquisaNomeCadastro.Text + "';", conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (!(txtPesquisaNomeCadastro.Text == "") && (ds.Tables[0].Rows.Count > 0))
                {
                    idPessoa = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    IdTipoPessoa = int.Parse(ds.Tables[0].Rows[0][1].ToString());

                    if ((IdTipoPessoa == 1)&& (ds.Tables[0].Rows.Count > 0))
                    {
                        panelFContatos.Enabled = true;
                        buttonVerifica.Enabled = true;
                        txtRespostaEmpresa.Text = ds.Tables[0].Rows[0][3].ToString();
                        txtRespostaEmpresa2.Text = ds.Tables[0].Rows[0][16].ToString();
                    }
                    if ((IdTipoPessoa == 2) && (ds.Tables[0].Rows.Count > 0))
                    {
                        panelFContatos.Enabled = true;
                        buttonVerifica.Enabled = true;
                        txtRespostaEmpresa.Text = ds.Tables[0].Rows[0][24].ToString();
                        txtRespostaEmpresa2.Text = ds.Tables[0].Rows[0][3].ToString();
                    }


                }
                if (txtPesquisaNomeCadastro.Text == "")
                {
                    MessageBox.Show("Por favor Nome nao pode esta em Branco!");
                    AlteraBotoes(10);
                }
                else if (!(ds.Tables[0].Rows.Count > 0))
                {
                    MessageBox.Show("O Fornecedor  " + txtPesquisaNomeCadastro.Text + " nao consta no sistema! ");
                    AlteraBotoes(10);
                    AlteraBotoes(3);
                }
            }

        }

        private void radioButtonMSP1_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMSp1.Enabled = true;
            txtPesquisaNomeCadastro.Enabled = false;
            txtPesquisaNomeCadastro.Clear();
            txtRespostaEmpresa.Clear();
            txtRespostaEmpresa2.Clear();
            AlteraBotoes(10);
        }

        private void radioButtonAbreviacaoP1_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaNomeCadastro.Enabled = true;
            txtPesquisaMSp1.Enabled = false;
            txtPesquisaMSp1.Clear();
            txtRespostaEmpresa.Clear();
            txtRespostaEmpresa2.Clear();
            AlteraBotoes(10);

        }

        private void buttonCancelarFContatos_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormFornecedoresContatos FornecedorContatos = new FormFornecedoresContatos(1);
            FornecedorContatos.MdiParent = FormFornecedoresContatos.ActiveForm;
            FornecedorContatos.Show();
            FornecedorContatos.Top = 0;
            FornecedorContatos.Left = 0;

        }

        private void buttonFecharFContatos_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }

        private void ButtonPesquisaFContatos_Click(object sender, EventArgs e)
        {
            ButtonPesquisaFContatos.Enabled = false;
            radioButtonPequisaAbreFContatos.Enabled = true;
            radioButtonPesquisaNome.Enabled = true;
            //radioButtonPequisaAbreFContatos.Enabled = true;
            //radioButtonMsFContatos.Enabled = true;
            buttonBuscaFContatos.Enabled = true;

            buttonLimpaFornecedor.Enabled = true;
            buttonCancelarFContatos.Enabled = true;

            buttonCadastroFContatos.Enabled = false;
        }

        private void buttonEditarFContatos_Click(object sender, EventArgs e)
        {
            this.operacao = "Editar";

            AlteraBotoes(4);
        }

        private void buttonExcluirFContatos_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja Excluir o registro?", "Aviso", MessageBoxButtons.YesNo);

            string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao = new Conexao(strConexao);
            DALCadastro dal = new DALCadastro(conexao);

            if (d.ToString() == "Yes")
            {
                dal.ExcluirFcontatos(idPessoa);

                FecharTodosFormulario();

                FormFornecedoresContatos FContatos = new FormFornecedoresContatos();
                FContatos.MdiParent = FormFornecedoresContatos.ActiveForm;
                FContatos.Show();
                FContatos.Top = 0;
                FContatos.Left = 0;
            }
        }

        private void buttonLimpaFornecedor_Click(object sender, EventArgs e)
        {
            AlteraBotoes(10);
        }
    }
}
