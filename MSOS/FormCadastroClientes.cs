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
    public partial class FormCadastroClientes : Form
    {
        MSOSEntities MSOS = null;

        private string operacao = "";

        private int ID_PESSOAFISICA = 0;
        public int idPessoaFisica
        {
            get
            {
                return this.ID_PESSOAFISICA;

            }
            set
            {
                this.ID_PESSOAFISICA = value;
            }
        }
        private int ID_PESSOAJURIDICA = 0;
        public int idPessoaJuridica
        {
            get
            {
                return this.ID_PESSOAJURIDICA;

            }
            set
            {
                this.ID_PESSOAJURIDICA = value;
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
        private int IDPESSOA = 0;
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
        public FormCadastroClientes()
        {
            InitializeComponent();

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

        SqlConnection connetionString = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");

        SqlConnection conexao = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
        //private FormCadastroClientesFisica formCadastroClientesFisica;

        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Nome Inválido!");
                return false;
            }

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaMs(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtMsCliente.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "MS Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaEndereco(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtEnderecoCliente.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaTelefone(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtTelefoneCliente.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Telefone Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaBairro(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtBairroCliente.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Bairro Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCep(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCepCliente.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Cep Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCidade(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCidadeCliente.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Cidade Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaEmail(TextBox textBox, ErrorProvider errorProvider)
        {
            string email = txtEmailCliente.Text;
            string modelo = @"[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+";

            if (Regex.IsMatch(email, modelo))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "E-mail Inválido!");
                return false;
            }
        }
        private Boolean validaNumero(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtBairroNumero.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Numero Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean NomePFisica(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomePFisica.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Rg Inválido!");
                return false;
            }
        }


        // VALIDAR ENTRADA COM ERROPROVIDER
        private bool validaSexo()
        {
            // Determine whether the favorite color has a valid value.
            return ((comboBoxSexoPFIsica.SelectedItem != null) &&
                (!comboBoxSexoPFIsica.SelectedItem.ToString().Equals("")));//none
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaRg(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtRgFisica.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Rg Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaNomeFisica(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtBairroNumero.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Numero Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCpf(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCpfPFisica.Text)) 
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Cpf Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private bool validaCelular(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularPFisica.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Celular Inválido!");
                return false;
            }
        }
        private bool validaCelular2(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularPFisica2.Text))
            {
                errorProviderCadastroDeCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroDeCliente.SetError(textBox, "Celular Inválido!");
                return false;
            }
        }

        //BLOQUEIA LETRAS E SÓ POSSÍVEL USAR O BACKSPACE
        private void txtCpfPFisica_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        //BLOQUEIA LETRAS E SÓ POSSÍVEL USAR O BACKSPACE
        private void txtRgFisica_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCnpj(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCnpJTextBox.Text))
            {
                errorProvider.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProvider.SetError(textBox, "Cnpj Inválido!");
                return false;
            }

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaInscricaoStadual(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtiNSCRICAO_STADUALTextBox.Text))
            {
                errorProvider.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProvider.SetError(textBox, "Inscrição Estatual Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaRazãoSocial(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtrAZAO_SOCIALTextBox.Text))
            {
                errorProvider.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProvider.SetError(textBox, "Razão Social Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaNomeContato(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtnOME_CONTATOTextBox.Text))
            {
                errorProvider.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProvider.SetError(textBox, "Nome do Contato Inválido!");
                return false;
            }
        }

        // BOTÃO PARA CADASTRA CLIENTES
        private void buttonCadastroCliente_Click(object sender, EventArgs e)
        {
            try
            {
                this.operacao = "Inserir";

                buttonVerifica.Enabled = true;

                AlteraBotoes(1);


                checkBoxClienteSituacao.Checked = true;

                checkBoxClienteSituacao.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Carregar o Salvar! " + ex.Message);
            }
        }

        //BOTÃO PARA EDITAR CADASTRO DE CLIENTE
        private void buttonEditarCliente_Click(object sender, EventArgs e)
        {
            this.operacao = "Editar";
            AlteraBotoes(4);
        }

        private void FormCadastroClientes_Load(object sender, EventArgs e)
        {
            //txtPesquisaMsCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtPesquisaMsCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtPesquisaMsCliente.AutoCompleteCustomSource = FormCadastroClientes.LoadAutoCompleteMSCliente();

            //txtPesquisaNomeCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtPesquisaNomeCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtPesquisaNomeCliente.AutoCompleteCustomSource = FormCadastroClientes.LoadAutoCompleteNomeCliente();

            panelBotoesCadastroCliente.Enabled = true;

            buttonCadastroCliente.Enabled = true;

            txtNomeCliente.MaxLength = 50;

            txtMsCliente.MaxLength = 9;

            //txtPesquisaMsCliente.MaxLength = 9;

            txtEnderecoCliente.MaxLength = 50;

            txtComplCliente.MaxLength = 20;

            txtBairroCliente.MaxLength = 20;

            txtCidadeCliente.MaxLength = 20;

            txtEmailCliente.MaxLength = 40;

            txtTipoCliente.MaxLength = 20;

            txtCpMunicipalCliente.MaxLength = 20;

            txtMunicipioCliente.MaxLength = 20;

            txtPaisCliente.MaxLength = 19;

            txtDescPaisCliente.MaxLength = 20;

            txtObservacaoCliente.MaxLength = 40;


        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra Cliente campos
            {
                panelCadastroCliente.Enabled = true;

                buttonCadastroCliente.Enabled = false;

                buttonVerifica.Enabled = true;
                buttonEditarCliente.Enabled = false;
                buttonExcluirCliente.Enabled = false;
                buttonLimpaCliente.Enabled = false;
                buttonCancelarCliente.Enabled = true;
                buttonFecharCliente.Enabled = true;

                radioButtonPessoaFisica.Enabled = true;
                radioButtonPessoaJuridica.Enabled = true;
            }
            if (op == 2)//salvar Cadastro de Cliente
            {
                panelCadastroCliente.Enabled = false;

                buttonCadastroCliente.Enabled = true;

                buttonVerifica.Enabled = false;
                buttonEditarCliente.Enabled = false;
                buttonExcluirCliente.Enabled = false;
                buttonLimpaCliente.Enabled = false;
                buttonCancelarCliente.Enabled = false;
                buttonFecharCliente.Enabled = true;


            }
            if (op == 3)//Calcelar Cadastro de Cliente
            {
                panelCadastroCliente.Enabled = false;

                buttonCadastroCliente.Enabled = true;

                buttonVerifica.Enabled = false;
                buttonEditarCliente.Enabled = false;
                buttonExcluirCliente.Enabled = false;
                buttonLimpaCliente.Enabled = false;
                buttonCancelarCliente.Enabled = false;
                buttonFecharCliente.Enabled = true;



            }
            if (op == 4) //  Editar Cadastro de Cliente
            {
                panelCadastroCliente.Enabled = true;

                txtMsCliente.Enabled = false;

                buttonCadastroCliente.Enabled = false;

                buttonVerifica.Enabled = true;
                buttonEditarCliente.Enabled = false;
                buttonExcluirCliente.Enabled = false;
                buttonLimpaCliente.Enabled = false;
                buttonCancelarCliente.Enabled = true;
                buttonFecharCliente.Enabled = true;

                VERIFICADOREDITAR = true;

            }
            if (op == 6)//Pesquisa Com suscesso!
            {
                buttonCadastroCliente.Enabled = false;

                buttonVerifica.Enabled = false;
                buttonEditarCliente.Enabled = true;
                buttonExcluirCliente.Enabled = true;
                buttonLimpaCliente.Enabled = false;
                buttonCancelarCliente.Enabled = true;
                buttonFecharCliente.Enabled = true;
            }
            if (op == 7)//Botão Verificar informações Passadas
            {

                txtNomeCliente.Enabled = false;
                txtMsCliente.Enabled = false;
                txtCepCliente.Enabled = false;
                txtTipo_logradouro.Enabled = false;
                txtBairroCliente.Enabled = false;
                txtBairroNumero.Enabled = false;
                txtTelefone2Cliente.Enabled = false;
                txtTelefoneCliente.Enabled = false;
                txtEmailCliente.Enabled = false;
                txtEnderecoCliente.Enabled = false;
                txtMunicipioCliente.Enabled = false;
                txtPaisCliente.Enabled = false;
                txtComplCliente.Enabled = false;
                txtCpMunicipalCliente.Enabled = false;
                txtFaxTelefoneCliente.Enabled = false;
                txtDescPaisCliente.Enabled = false;
                txtObservacaoCliente.Enabled = false;
                txtTipoCliente.Enabled = false;
                txtTelexTelefoneCliente.Enabled = false;

                buttonBuscaCep.Enabled = false;
            }
            if (op == 8)//Libera Pessoa Fisica e Juridica!
            {

            }
            if (op == 9)//Libera Pesquisa Por MS e Nome.
            {

                buttonCadastroCliente.Enabled = false;
                buttonCancelarCliente.Enabled = true;
                buttonFecharCliente.Enabled = true;

            }
            if (op == 10)//limpa textos
            {
                txtMsCliente.Clear();
                txtNomeCliente.Clear();
                txtEnderecoCliente.Clear();
                txtTelefoneCliente.Clear();
                txtTelefone2Cliente.Clear();
                txtFaxTelefoneCliente.Clear();
                txtTelexTelefoneCliente.Clear();
                txtEmailCliente.Clear();
                txtObservacaoCliente.Clear();
                txtCepCliente.Clear();
                txtTipo_logradouro.Clear();
                txtEnderecoCliente.Clear();
                txtBairroNumero.Clear();
                txtComplCliente.Clear();
                txtBairroCliente.Clear();
                txtCidadeCliente.Clear();
                txtSiglaCidadeCliente.Clear();
                txtCpMunicipalCliente.Clear();
                txtMunicipioCliente.Clear();
                txtPaisCliente.Clear();
                txtDescPaisCliente.Clear();

            }
            if (op == 11)
            {//Pessoa Fisica
                txtNomePFisica.Enabled = true;
                comboBoxSexoPFIsica.Enabled = true;
                txtCpfPFisica.Enabled = true;
                txtRgFisica.Enabled = true;
                txtDataNascimento.Enabled = true;
                txtCelularPFisica.Enabled = true;
                txtCelularPFisica2.Enabled = true;

                txtCnpJTextBox.Enabled = false;
                txtrAZAO_SOCIALTextBox.Enabled = false;
                txtiNSCRICAO_STADUALTextBox.Enabled = false;
                txtnOME_CONTATOTextBox.Enabled = false;

                txtCnpJTextBox.Clear();
                txtrAZAO_SOCIALTextBox.Clear();
                txtiNSCRICAO_STADUALTextBox.Clear();
                txtnOME_CONTATOTextBox.Clear();
            }
            if (op == 12)
            {//Pessoa Juridica

                txtCnpJTextBox.Enabled = true;
                txtrAZAO_SOCIALTextBox.Enabled = true;
                txtiNSCRICAO_STADUALTextBox.Enabled = true;
                txtnOME_CONTATOTextBox.Enabled = true;

                txtNomePFisica.Enabled = false;
                comboBoxSexoPFIsica.Enabled = false;
                txtCpfPFisica.Enabled = false;
                txtRgFisica.Enabled = false;
                txtDataNascimento.Enabled = false;
                txtCelularPFisica.Enabled = false;
                txtCelularPFisica2.Enabled = false;

                txtNomePFisica.Clear();
                txtCpfPFisica.Clear();
                txtRgFisica.Clear();
                txtCelularPFisica.Clear();
                txtCelularPFisica2.Clear();
            }

        }
        /* NÃO ATIVADA
        //METODO QUE SELECIONA CIDADES NO SQL ORDERNADO POR NOME
        public static DataTable LoadDataTableCidade()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "SELECT C.NOME AS CIDADE FROM P_Cidade C INNER JOIN P_Estado E ON C.ID_ESTADO = E.ID_ESTADO ORDER BY C.NOME;";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }*/

        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR NOME
        /* Não utilizado!
                //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA CIDADE
                public static AutoCompleteStringCollection LoadAutoCompleteClidade()
                {
                    DataTable dt = LoadDataTableCidade();

                    AutoCompleteStringCollection stringCidade = new AutoCompleteStringCollection();

                    foreach (DataRow row in dt.Rows)
                    {
                        stringCidade.Add(Convert.ToString(row["CIDADE"]));
                    }

                    return stringCidade;
                }
                */
        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA MS
        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR MS
        public static DataTable LoadDataTableMSCliente()
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
        public static AutoCompleteStringCollection LoadAutoCompleteMSCliente()
        {
            DataTable dt = LoadDataTableMSCliente();

            AutoCompleteStringCollection stringMS = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringMS.Add(Convert.ToString(row["MS"]));
            }

            return stringMS;
        }
        public static DataTable LoadDataTableNOMECliente()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaPessoaClienteNome; ";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }
        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA NOME
        public static AutoCompleteStringCollection LoadAutoCompleteNomeCliente()
        {
            DataTable dt = LoadDataTableNOMECliente();

            AutoCompleteStringCollection stringNome = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringNome.Add(Convert.ToString(row["NOME"]));

            }

            return stringNome;
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Deseja Deletra o Cliente ? ::: ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MSOS.P_ClientePessoa.Remove(pClientePessoaBindingSource.Current as P_ClientePessoa);
                    pClientePessoaBindingSource.RemoveCurrent();
                }
            }
        }
        /*
        //METODO QUE BUSCA AS CIDADES SELECIONADAS PASSANDO O PARAMENTRO DA PESQUISA DA CIDADE DO CLIENTE!
        private void BuscaCidade_Click(object sender, EventArgs e)
        {
            comboBoxEstadoCliente.Items.Clear();
            comboBoxEstadoCliente.Enabled = false;

            SqlDataAdapter da = new SqlDataAdapter("SELECT Count(C.NOME) as CIDADE FROM P_Cidade C INNER JOIN P_Estado E ON C.ID_ESTADO = E.ID_ESTADO WHERE C.NOME = '" + txtPesquisaCidadeCliente.Text + "';", connetionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string quantidadeS = dt.Rows[0][0].ToString();

            int quantidadeI = Convert.ToInt32(quantidadeS);

            try
            {
                ///VERIFICA SE A CIDADE TEM UM ESTADO.
                if (quantidadeI == 1)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM P_Cidade C INNER JOIN P_Estado E ON C.ID_ESTADO = E.ID_ESTADO WHERE C.NOME ='" + txtPesquisaCidadeCliente.Text + "';", connetionString);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    txtCidadeCliente.Text = dt1.Rows[0][3].ToString();
                    txtEstadoCliente.Text = dt1.Rows[0][6].ToString();
                    txtSiglaCidadeCliente.Text = dt1.Rows[0][5].ToString();

                    string idCidade = dt1.Rows[0][0].ToString();
                    this.idCidadeSql = Convert.ToInt32(idCidade);

                }
                //VERIFICA SE A CIDADE TEM MAS QUE UM ESTADO.
                else if (quantidadeI > 1)
                {
                    comboBoxEstadoCliente.Enabled = true;

                    Fill_listBoxEstado();

                }
                else
                {
                    MessageBox.Show("Cadastre cidade completa ! ");
                }
                dt.Clear();
                connetionString.Close();
            }
            catch (Exception ex)
            {
                //comboBoxEstadoCliente.Items.Clear();
                MessageBox.Show("Erro no sistema ! ", ex.Message);
            }
        }
        //LISTA OS ESTADOS QUE TEM O MESMO NOME DE CIDADES NUM COMBOBOX
        void Fill_listBoxEstado()
        {
            SqlConnection connection = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");

            try
            {
                connection.Open();
                string Query = "SELECT * FROM P_Cidade C INNER JOIN P_Estado E ON C.ID_ESTADO = E.ID_ESTADO WHERE C.NOME = '" + this.txtPesquisaCidadeCliente.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(6);
                    comboBoxEstadoCliente.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //PESQUISA OS ESTADOS E GERAM NO COMBOBOX PASSANDO PARA SUA BUSCA O ESTADO CLIENTE  E A CIDADE DE PESQUISA
        private void comboBoxEstadoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");

            try
            {
                connection.Open();

                string Query = "SELECT * FROM P_Cidade C INNER JOIN P_Estado E ON C.ID_ESTADO = E.ID_ESTADO WHERE E.NOME = '" + this.comboBoxEstadoCliente.Text + "'" + "and C.NOME ='" + this.txtPesquisaCidadeCliente.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string idCidade = dr.GetInt32(0).ToString();

                    string cidade = dr.GetString(3);
                    string estado = dr.GetString(6);
                    string sigla = dr.GetString(5);

                    txtCidadeCliente.Text = cidade;
                    txtEstadoCliente.Text = estado;
                    txtSiglaCidadeCliente.Text = sigla;

                    this.idCidadeSql = Convert.ToInt32(idCidade);



                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/


        //CHAMA O FORMULÁRIO CADASTRO DE CLIENTES FISICA
        public void radioButtonPessoaFisica_CheckedChanged_1(object sender, EventArgs e)
        {
            tabControlFisicaJuridica.Enabled = true;
            AlteraBotoes(11);
        }


        //CHAMA O FORMULÁRIO CADASTRO DE CLIENTES JURIDICA
        private void radioButtonPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            tabControlFisicaJuridica.Enabled = true;
            AlteraBotoes(12);

        }
        //BLOQUEIA LETRAS E SÓ POSSÍVEL USAR O BACKSPACE
        private void txtMsCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        //BLOQUEIA LETRAS E SÓ POSSÍVEL USAR O BACKSPACE
        private void txtTelefoneCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        //BLOQUEIA LETRAS E SÓ POSSÍVEL USAR O BACKSPACE
        private void txtTelefone2Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        //BLOQUEIA LETRAS E SÓ POSSÍVEL USAR O BACKSPACE
        private void txtFaxTelefoneCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        //BLOQUEIA LETRAS E SÓ POSSÍVEL USAR O BACKSPACE
        private void txtTelexTelefoneCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        //BLOQUEIA LETRAS E SÓ POSSÍVEL USAR O BACKSPACE
        private void txtCepCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void checkBoxCliente_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void buttonBuscaCep_Click(object sender, EventArgs e)
        {
            string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml"
                .Replace("@cep", txtCepCliente.Text);
            DataSet ds = new DataSet();
            ds.ReadXml(xml);

            labelConfirmacao.Text = ds.Tables[0].Rows[0][1].ToString();
            txtTipo_logradouro.Text = ds.Tables[0].Rows[0][5].ToString();
            txtEnderecoCliente.Text = ds.Tables[0].Rows[0][6].ToString();
            txtBairroCliente.Text = ds.Tables[0].Rows[0][4].ToString();
            txtCidadeCliente.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSiglaCidadeCliente.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void panelCadastroCliente_Paint(object sender, PaintEventArgs e)
        {

        }
        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            if (validaMs(txtMsCliente, errorProviderCadastroDeCliente) == true)
            {
                String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

                SqlConnection conn = new SqlConnection(connectionString);

                //Verifica Se a MS é Valida no sistema!

                int MS = int.Parse(txtMsCliente.Text);

                SqlDataAdapter da3 = new SqlDataAdapter("EXEC ConsultaMsValidar " + MS + ";", conn);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);

                conn.Open();

                if (ds3.Tables[0].Rows.Count > 0)

                {
                    MessageBox.Show("O Ms consta no sistema não pode ser Inserido!");
                }
                if (!(ds3.Tables[0].Rows.Count > 0))
                {
                    if (!(radioButtonPessoaFisica.Checked == true) && !(radioButtonPessoaJuridica.Checked == true))
                    {
                        MessageBox.Show("Seleciona Pessoa Fisíca ou Pessoa Jurídica!");
                    }
                    if (radioButtonPessoaFisica.Checked == true)
                    {
                        if ((validaNome(txtNomeCliente, errorProviderCadastroDeCliente) == true) && (validaNumero(txtBairroNumero, errorProviderCadastroDeCliente) == true))//(labelConfirmacao.Text).Equals("sucesso - cep completo"))
                        {
                            try
                            {
                                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
                                Conexao conexao = new Conexao(strConexao);
                                DALCadastro dal = new DALCadastro(conexao); //cadastra Pessoa

                                string strConexao1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                                Conexao conexao1 = new Conexao(strConexao1);
                                DALCadastro dal1 = new DALCadastro(conexao1);//cadastra Cep

                                string strConexao2 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                                Conexao conexao2 = new Conexao(strConexao2);
                                DALCadastro dal2 = new DALCadastro(conexao2);//cadastra Pesssoa Clientes

                                string strConexao4 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                                Conexao conexao4 = new Conexao(strConexao4);
                                DALCadastro dal4 = new DALCadastro(conexao4);//cadastra Pesssoa Fisica 

                                Pessoa cadastra = new Pessoa();

                                Clientes pessoaCliente = new Clientes();

                                Cep cadastraCep = new Cep();

                                PessoaFisica PessoaFisica = new PessoaFisica();

                                // Dados Pessoa

                                cadastra.IdOs = 0;
                                cadastra.Situacao = 1;
                                cadastra.Nome = txtNomeCliente.Text;
                                cadastra.Telefone = txtTelefoneCliente.Text;
                                cadastra.Telefone2 = txtTelefone2Cliente.Text;
                                cadastra.FaxTelefone = txtFaxTelefoneCliente.Text;
                                cadastra.TelexTelefone = txtTelexTelefoneCliente.Text;
                                cadastra.Email = txtEmailCliente.Text;
                                cadastra.Observacao = txtObservacaoCliente.Text;
                                cadastra.Tipo = txtTipoCliente.Text;
                                cadastra.CpMunicipio = txtCpMunicipalCliente.Text;
                                cadastra.Municipio = txtMunicipioCliente.Text;
                                cadastra.Pais = txtPaisCliente.Text;
                                cadastra.DesPais = txtDescPaisCliente.Text;
                                cadastra.IdPessoaTipo = 2;

                                //Pessoa Fisica
                                PessoaFisica.Nome = txtNomePFisica.Text;
                                PessoaFisica.Cpf = txtCpfPFisica.Text;
                                PessoaFisica.Rg = txtRgFisica.Text;
                                PessoaFisica.dataNacimento = txtDataNascimento.Text;
                                PessoaFisica.Celular = txtCelularPFisica.Text;
                                PessoaFisica.Celular2 = txtCelularPFisica2.Text;

                                //Dados Pessoa Cliente
                                pessoaCliente.IdMs = int.Parse(txtMsCliente.Text);

                                //Dados CEP
                                cadastraCep.Cepc = int.Parse(txtCepCliente.Text);
                                cadastraCep.TipoLogradouro = txtTipo_logradouro.Text;
                                cadastraCep.Endereco = txtEnderecoCliente.Text;
                                cadastraCep.Numero = int.Parse(txtBairroNumero.Text);
                                cadastraCep.Complemento = txtComplCliente.Text;
                                cadastraCep.Bairro = txtBairroCliente.Text;
                                cadastraCep.Cidade = txtCidadeCliente.Text;
                                cadastraCep.SiglaCidade = txtSiglaCidadeCliente.Text;

                                if (!validaSexo())
                                {
                                    MessageBox.Show("Por favor Digite um Sexo Válido!");

                                }
                                if ((NomePFisica(txtNomePFisica, errorProviderCadastroDeCliente) == true) && (validaNomeFisica(txtNomePFisica, errorProviderCadastroDeCliente) == true) && (validaCpf(txtCpfPFisica, errorProviderCadastroDeCliente) == true) &&
                                    (validaRg(txtRgFisica, errorProviderCadastroDeCliente) == true) && (validaCelular(txtCelularPFisica, errorProviderCadastroDeCliente) == true) &&
                                    (validaSexo()) && (comboBoxSexoPFIsica.SelectedItem.ToString() == "M"))
                                //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
                                {
                                    //Pessoa Fisica recebe M
                                    PessoaFisica.Sexo = "M";

                                    //Inserir Pessoa
                                    dal.Incluir(cadastra);

                                    idPessoaFisica = int.Parse(cadastra.idPessoa.ToString());

                                    if (idPessoaFisica > 0)
                                    {
                                        if (this.operacao == "Inserir")
                                        {
                                            //Inserir Pessoa Fisica
                                            PessoaFisica.idPessoaFisica = idPessoaFisica;
                                            dal4.IncluirPessoaFIsica(PessoaFisica);

                                            //Inserir Cliente
                                            pessoaCliente.idPessoa = idPessoaFisica;
                                            dal2.IncluirCliente(pessoaCliente);

                                            //Inserir Cep
                                            cadastraCep.idCep = idPessoaFisica;
                                            dal1.IncluirCep(cadastraCep);

                                            MessageBox.Show("Cliente Cadastrado com sucesso!");

                                            FecharTodosFormulario();

                                            FormCadastroClientes cadastracliente = new FormCadastroClientes();
                                            cadastracliente.MdiParent = FormCadastroClientes.ActiveForm;
                                            cadastracliente.Show();
                                            cadastracliente.Top = 0;
                                            cadastracliente.Left = 0;
                                        }
                                        else if (idPessoaFisica <= 0)
                                        {

                                        }

                                    }

                                    if ((NomePFisica(txtNomePFisica, errorProviderCadastroDeCliente) == true) && (validaNomeFisica(txtNomePFisica, errorProviderCadastroDeCliente) == true) && (validaCpf(txtCpfPFisica, errorProviderCadastroDeCliente) == true) &&
                                        (validaRg(txtRgFisica, errorProviderCadastroDeCliente) == true) && (validaCelular(txtCelularPFisica, errorProviderCadastroDeCliente) == true) &&
                                        (validaSexo()) && (comboBoxSexoPFIsica.SelectedItem.ToString() == "F"))
                                    {
                                        //Pessoa Fisica recebe M
                                        PessoaFisica.Sexo = "F";

                                        //Inserir Pessoa
                                        dal.Incluir(cadastra);

                                        idPessoaFisica = int.Parse(cadastra.idPessoa.ToString());
                                        idPessoaJuridica = int.Parse(cadastra.idPessoa.ToString());

                                        if (idPessoaFisica > 0)
                                        {
                                            if (this.operacao == "Inserir")
                                            {
                                                //Inserir Pessoa Fisica
                                                PessoaFisica.idPessoaFisica = idPessoaFisica;
                                                dal4.IncluirPessoaFIsica(PessoaFisica);

                                                //Inserir Cliente
                                                pessoaCliente.idPessoa = idPessoaFisica;
                                                dal2.IncluirCliente(pessoaCliente);

                                                //Inserir Cep
                                                cadastraCep.idCep = idPessoaFisica;
                                                dal1.IncluirCep(cadastraCep);

                                                MessageBox.Show("Cliente Cadastrado com sucesso!");

                                                FecharTodosFormulario();

                                                FormCadastroClientes cadastracliente = new FormCadastroClientes();
                                                cadastracliente.MdiParent = FormCadastroClientes.ActiveForm;
                                                cadastracliente.Show();
                                                cadastracliente.Top = 0;
                                                cadastracliente.Left = 0;
                                            }
                                            else if (idPessoaFisica <= 0)
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro de acesso ao banco de Dados-----------------------------------------------------------------------------------------------------------------------------------------. ", ex.Message);
                            }
                        }
                    }
                    if (radioButtonPessoaJuridica.Checked == true)
                    {
                        if ((validaNome(txtNomeCliente, errorProviderCadastroDeCliente) == true) && (validaNumero(txtBairroNumero, errorProviderCadastroDeCliente) == true))//(labelConfirmacao.Text).Equals("sucesso - cep completo"))
                        {
                            try
                            {
                                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
                                Conexao conexao = new Conexao(strConexao);
                                DALCadastro dal = new DALCadastro(conexao); //cadastra Pessoa

                                string strConexao1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                                Conexao conexao1 = new Conexao(strConexao1);
                                DALCadastro dal1 = new DALCadastro(conexao1);//cadastra Cep

                                string strConexao2 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                                Conexao conexao2 = new Conexao(strConexao2);
                                DALCadastro dal2 = new DALCadastro(conexao2);//cadastra Pesssoa Clientes

                                string strConexao4 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                                Conexao conexao4 = new Conexao(strConexao4);
                                DALCadastro dal4 = new DALCadastro(conexao4);//cadastra Pesssoa Fisica 

                                string strConexao5 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                                Conexao conexao5 = new Conexao(strConexao5);
                                DALCadastro dal5 = new DALCadastro(conexao5);//cadastra Pesssoa Juridica 


                                Pessoa cadastra = new Pessoa();

                                Clientes pessoaCliente = new Clientes();

                                Cep cadastraCep = new Cep();

                                PessoaFisica PessoaFisica = new PessoaFisica();

                                // Dados Pessoa

                                cadastra.IdOs = 0;
                                cadastra.Situacao = 1;
                                cadastra.Nome = txtNomeCliente.Text;
                                cadastra.Telefone = txtTelefoneCliente.Text;
                                cadastra.Telefone2 = txtTelefone2Cliente.Text;
                                cadastra.FaxTelefone = txtFaxTelefoneCliente.Text;
                                cadastra.TelexTelefone = txtTelexTelefoneCliente.Text;
                                cadastra.Email = txtEmailCliente.Text;
                                cadastra.Observacao = txtObservacaoCliente.Text;
                                cadastra.Tipo = txtTipoCliente.Text;
                                cadastra.CpMunicipio = txtCpMunicipalCliente.Text;
                                cadastra.Municipio = txtMunicipioCliente.Text;
                                cadastra.Pais = txtPaisCliente.Text;
                                cadastra.DesPais = txtDescPaisCliente.Text;
                                cadastra.IdPessoaTipo = 2;

                                //Pessoa Fisica
                                PessoaFisica.Nome = txtNomePFisica.Text;
                                PessoaFisica.Cpf = txtCpfPFisica.Text;
                                PessoaFisica.Rg = txtRgFisica.Text;
                                PessoaFisica.dataNacimento = txtDataNascimento.Text;
                                PessoaFisica.Celular = txtCelularPFisica.Text;
                                PessoaFisica.Celular2 = txtCelularPFisica2.Text;

                                //Pessoa Juridica
                                PessoaJuridica pessoaJuridica = new PessoaJuridica();
                                pessoaJuridica.idPessoaJuridica = idPessoaJuridica;  // Convert.ToInt32(idPesssoaFisica);
                                pessoaJuridica.IdPessoaTipo = 2;
                                pessoaJuridica.Cnpj = txtCnpJTextBox.Text;
                                pessoaJuridica.RazaoSocial = txtrAZAO_SOCIALTextBox.Text;
                                pessoaJuridica.InscricaoStadual = txtiNSCRICAO_STADUALTextBox.Text;
                                pessoaJuridica.NomeContato = txtnOME_CONTATOTextBox.Text;

                                //Dados Pessoa Cliente
                                pessoaCliente.IdMs = int.Parse(txtMsCliente.Text);

                                //Dados CEP
                                cadastraCep.idCep = idPessoaFisica;
                                cadastraCep.Cepc = int.Parse(txtCepCliente.Text);
                                cadastraCep.TipoLogradouro = txtTipo_logradouro.Text;
                                cadastraCep.Endereco = txtEnderecoCliente.Text;
                                cadastraCep.Numero = int.Parse(txtBairroNumero.Text);
                                cadastraCep.Complemento = txtComplCliente.Text;
                                cadastraCep.Bairro = txtBairroCliente.Text;
                                cadastraCep.Cidade = txtCidadeCliente.Text;
                                cadastraCep.SiglaCidade = txtSiglaCidadeCliente.Text;

                                if ((validaCnpj(txtCnpJTextBox, errorProviderCadastroDeCliente) == true) && (validaRazãoSocial(txtrAZAO_SOCIALTextBox, errorProviderCadastroDeCliente) == true) &&
                                    (validaInscricaoStadual(txtiNSCRICAO_STADUALTextBox, errorProviderCadastroDeCliente) == true) && (validaNomeContato(txtnOME_CONTATOTextBox, errorProviderCadastroDeCliente) == true))
                                //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
                                {

                                    if (this.operacao == "Inserir")
                                    {
                                        //Inserir Pessoa
                                        dal.Incluir(cadastra);

                                        idPessoaJuridica = int.Parse(cadastra.idPessoa.ToString());

                                        if (idPessoaJuridica > 0)
                                        {
                                            //Inserir Pessoa Fisica
                                            pessoaJuridica.idPessoaJuridica = idPessoaJuridica;
                                            dal5.IncluirPessoaJuridica(pessoaJuridica);

                                            //Inserir Cliente
                                            pessoaCliente.idPessoa = idPessoaJuridica;
                                            dal2.IncluirCliente(pessoaCliente);

                                            //Inserir Cep
                                            cadastraCep.idCep = idPessoaJuridica;
                                            dal1.IncluirCep(cadastraCep);

                                            MessageBox.Show("Cliente Cadastrado com sucesso!");

                                            FecharTodosFormulario();

                                            FormCadastroClientes cadastracliente = new FormCadastroClientes();
                                            cadastracliente.MdiParent = FormCadastroClientes.ActiveForm;
                                            cadastracliente.Show();
                                            cadastracliente.Top = 0;
                                            cadastracliente.Left = 0;
                                        }
                                        else if (idPessoaFisica <= 0)
                                        {

                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro de acesso ao banco de Dados-----------------------------------------------------------------------------------------------------------------------------------------. ", ex.Message);
                            }
                        }
                    }
                }
            }
        }
        private void buttonExcluirCliente_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja Excluir o registro?", "Aviso", MessageBoxButtons.YesNo);

            string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao = new Conexao(strConexao);
            DALCadastro dal = new DALCadastro(conexao);

            if (d.ToString() == "Yes")
            {
                if (this.ID_TIPO_PESSOA == 1)
                {
                    dal.ExcluirClienteJuridica(IdPessoa);

                    FecharTodosFormulario();

                    FormCadastroClientes cadastracliente = new FormCadastroClientes();
                    cadastracliente.MdiParent = FormCadastroClientes.ActiveForm;
                    cadastracliente.Show();
                    cadastracliente.Top = 0;
                    cadastracliente.Left = 0;
                }
                if (this.ID_TIPO_PESSOA == 2)
                {
                    dal.ExcluirClienteJuridica(IdPessoa);

                    FecharTodosFormulario();

                    FormCadastroClientes cadastracliente = new FormCadastroClientes();
                    cadastracliente.MdiParent = FormCadastroClientes.ActiveForm;
                    cadastracliente.Show();
                    cadastracliente.Top = 0;
                    cadastracliente.Left = 0;
                }
            }
        }

        private void buttonFecharCliente_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }

        private void buttonLimpaCliente_Click(object sender, EventArgs e)
        {
            AlteraBotoes(10);
        }

        private void buttonCancelarCliente_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormCadastroClientes cadastracliente = new FormCadastroClientes();
            cadastracliente.MdiParent = FormCadastroClientes.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }
        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!
        public static void CancelaCadastradoCliente(Type frmType)
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
            CancelaCadastradoCliente(typeof(FormCadastroClientes));
        }
        private void ButtonPesquisa_Click(object sender, EventArgs e)
        {
            AlteraBotoes(9);
        }
    }
}


