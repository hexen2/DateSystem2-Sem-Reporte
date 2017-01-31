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
    public partial class FormFornecedores : Form
    {
        //MSOSEntities MSOS = null;

        private string operacao = "";

        //private int idCidadeSql = 0;

        private int ID_FORNECEDORFISICA = 0;
        public int IdFornecedorFisica
        {
            get
            {
                return this.ID_FORNECEDORFISICA;

            }
            set
            {
                this.ID_FORNECEDORFISICA = value;
            }
        }
        private int ID_FORNECEDORJURIDICA = 0;
        public int IdFornecedorJuridica
        {
            get
            {
                return this.ID_FORNECEDORJURIDICA;

            }
            set
            {
                this.ID_FORNECEDORJURIDICA = value;
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

        public FormFornecedores()
        {
            InitializeComponent();

        }
        SqlConnection connetionString = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");

        SqlConnection conexao = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");


        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeFornecedor.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Nome Inválido!");
                return false;
            }
        }
        /*
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
*/
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaEndereco(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtEnderecoFornecedor.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaTelefone(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtTelefoneFornecedor.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Telefone Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaBairro(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtBairroFornecedor.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Bairro Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCep(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCepFornecedor.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Cep Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCidade(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCidadeFornecedor.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Cidade Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaEmail(TextBox textBox, ErrorProvider errorProvider)
        {
            string email = txtEmailFornecedor.Text;
            string modelo = @"[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+";

            if (Regex.IsMatch(email, modelo))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "E-mail Inválido!");
                return false;
            }
        }
        private Boolean validaNumero(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtBairroFornecedor.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Numero Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCnpj(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCnpj.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Cnpj Inválido!");
                return false;
            }

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaInscricaoStadual(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtInscStatual.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Inscrição Estatual Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaRazãoSocial(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtRazaoSocial.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Razão Social Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaNomeContato(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeContato.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Nome do Contato Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private bool validaSexo()
        {
            // Determine whether the favorite color has a valid value.
            return ((comboBoxSexoFFIsica.SelectedItem != null) &&
                (!comboBoxSexoFFIsica.SelectedItem.ToString().Equals("")));//none
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaRg(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtRgFisica.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Rg Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCpf(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCpfFFisica.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Cpf Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private bool validaCelular(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularFFisica.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Celular Inválido!");
                return false;
            }
        }
        private bool validaCelular2(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularFFisica2.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Celular Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validanomefisica(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomePFisica.Text))
            {
                errorProviderFornecedor.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedor.SetError(textBox, "Cnpj Inválido!");
                return false;
            }

        }
        private void panelJuridico_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCnpJTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        public void FecharFormularioFeJ()
        {
            //CHAMA O METODO CancelaCadastradoForncedor QUE FECHA FORMULÁRIOS ABERTOS
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorJuridica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorJuridica));
        }
        public void FecharTodosFormulario()
        {
            //CHAMA O METODO CancelaCadastradoFornecedor QUE FECHA FORMULÁRIOS ABERTOS
            CancelaCadastradoFornecedor(typeof(FormFornecedores));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorJuridica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorJuridica));
        }
        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR NOME
        public static DataTable LoadDataTableNOME()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaPessoaFornecedorNome;";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }

        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA NOME
        public static AutoCompleteStringCollection LoadAutoCompleteNome()
        {
            DataTable dt = LoadDataTableNOME();

            AutoCompleteStringCollection stringNome = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringNome.Add(Convert.ToString(row["NOME"]));
            }

            return stringNome;
        }

        private void FormFornecedores_Load(object sender, EventArgs e)
        {
            txtPesquisaNomeFornecedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaNomeFornecedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaNomeFornecedor.AutoCompleteCustomSource = FormFornecedores.LoadAutoCompleteNome();

            txtNomeFornecedor.MaxLength = 50;

            txtEnderecoFornecedor.MaxLength = 50;
            txtEnderecoFornecedor.Enabled = false;

            txtComplFornecedor.MaxLength = 20;

            txtBairroFornecedor.MaxLength = 20;
            txtBairroFornecedor.Enabled = false;

            txtCidadeFornecedor.MaxLength = 20;
            txtCidadeFornecedor.Enabled = false;

            txtEmailFornecedor.MaxLength = 40;

            txtTipoFornecedor.MaxLength = 20;

            txtCpMunicipioFornecedor.MaxLength = 20;

            txtMunicipioFornecedor.MaxLength = 20;

            txtPaisFornecedor.MaxLength = 20;

            txtDesPaisFornecedor.MaxLength = 20;

            txtObservacaoFornecedor.MaxLength = 40;

            txtNomeContatoFornecedor.MaxLength = 30;

            radioButtonOculto.Checked = true;
        }

        //Cadastrar Fornecedor
        private void buttonCadastraFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                this.operacao = "Inserir";

                AlteraBotoes(1);

                checkBoxClienteSituacao.Checked = true;

                checkBoxClienteSituacao.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Carregar o Salvar! " + ex.Message);
            }
        }
        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!
        public static void CancelaCadastradoFornecedor(Type frmType)
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

        //Botão que Cancelar FOrmulario de Cadastro de Fornecedor
        private void buttonCancelarFornecedor_Click(object sender, EventArgs e)
        {
            //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS
            FecharTodosFormulario();

            FormFornecedores Fornecedores = new FormFornecedores();
            Fornecedores.MdiParent = FormFornecedores.ActiveForm;
            Fornecedores.Show();
            Fornecedores.Top = 0;
            Fornecedores.Left = 0;
        }
        //Botão que Verifica Fornecedor
        private void buttonVerificarFornecedor_Click(object sender, EventArgs e)
        {
            if ((validaNome(txtNomeFornecedor, errorProviderFornecedor) == true) && (validaNumero(txtBairroNumeroFornecedor, errorProviderFornecedor) == true))//(labelConfirmacao.Text).Equals("sucesso - cep completo"))
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
                    DALCadastro dal2 = new DALCadastro(conexao2);//cadastra Pesssoa Fornecedor

                    string strConexao3 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                    Conexao conexao3 = new Conexao(strConexao3);
                    DALCadastro dal3 = new DALCadastro(conexao3);//cadastra Pesssoa Fisica 

                    string strConexao4 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                    Conexao conexao4 = new Conexao(strConexao4);
                    DALCadastro dal4 = new DALCadastro(conexao4);//cadastra Pesssoa Juridica 

                    //Dados Pessoa
                    Pessoa cadastra = new Pessoa();
                    cadastra.IdOs = 0;
                    cadastra.IdPessoaTipo = 2;
                    cadastra.Situacao = 1;
                    cadastra.Nome = txtNomeFornecedor.Text;
                    cadastra.Telefone = txtTelefoneFornecedor.Text;
                    cadastra.Telefone2 = txtTelefone2Fornecedor.Text;
                    cadastra.FaxTelefone = txtFaxTelefoneFornecedor.Text;
                    cadastra.TelexTelefone = txtTelexTelefoneFornecedor.Text;
                    cadastra.Email = txtEmailFornecedor.Text;
                    cadastra.Observacao = txtObservacaoFornecedor.Text;
                    cadastra.Tipo = txtTipoFornecedor.Text;
                    cadastra.CpMunicipio = txtCpMunicipioFornecedor.Text;
                    cadastra.Municipio = txtMunicipioFornecedor.Text;
                    cadastra.Pais = txtPaisFornecedor.Text;
                    cadastra.DesPais = txtDesPaisFornecedor.Text;

                    //Dados Fornecedor
                    Fornecedor pessoaFornecedor = new Fornecedor();
                    pessoaFornecedor.idFornecedor = int.Parse(cadastra.idPessoa.ToString());
                    pessoaFornecedor.CargoContato = txtCargoContatoFornecedor.Text;
                    pessoaFornecedor.NomeContato = txtNomeContatoFornecedor.Text;


                    //Dados Fornecedor Juridica
                    FornecedorJuridica FonecedorJuridica = new FornecedorJuridica();
                    FonecedorJuridica.idFornecedorJuridica = IdFornecedorJuridica;  // Convert.ToInt32(idPesssoaFisica);
                    FonecedorJuridica.Cnpj = txtCnpj.Text;
                    FonecedorJuridica.RazaoSocial = txtRazaoSocial.Text;
                    FonecedorJuridica.InscricaoStadual = txtInscStatual.Text;
                    FonecedorJuridica.NomeContato = txtNomeContato.Text;

                    //Dados Fornecedor Fisica
                    FornecedorFisica FonecedorFisica = new FornecedorFisica();
                    FonecedorFisica.IdFornecedorTipo = 1;
                    FonecedorFisica.Cpf = txtCpfFFisica.Text;
                    FonecedorFisica.Rg = txtRgFisica.Text;
                    FonecedorFisica.dataNacimento = txtDataNascimentoFFisica.Text;
                    FonecedorFisica.Celular = txtCelularFFisica.Text;
                    FonecedorFisica.Celular2 = txtCelularFFisica2.Text;
                    FonecedorFisica.Nome = txtNomePFisica.Text;


                    //Dados Cep
                    Cep cadastraCep = new Cep();
                    cadastraCep.idCep = int.Parse(cadastra.idPessoa.ToString());
                    cadastraCep.Cepc = int.Parse(txtCepFornecedor.Text);
                    cadastraCep.TipoLogradouro = txtTipoFornecedor.Text;
                    cadastraCep.Endereco = txtEnderecoFornecedor.Text;
                    cadastraCep.Numero = int.Parse(txtBairroNumeroFornecedor.Text);
                    cadastraCep.Complemento = txtComplFornecedor.Text;
                    cadastraCep.Bairro = txtBairroFornecedor.Text;
                    cadastraCep.Cidade = txtCidadeFornecedor.Text;
                    cadastraCep.SiglaCidade = txtSiglaCidadeFornecedor.Text;

                    if (this.operacao == "Inserir")
                    {
                        if (!(radioButtonFornecedorFisica.Checked == true) && !(radioButtonFornecedorJuridica.Checked == true))
                        {
                            MessageBox.Show("Selecione Um Fonecedor Fisíca ou Jurídica");

                        }
                        if (radioButtonFornecedorFisica.Checked == true)
                        {
                            if (!validaSexo())
                            {
                                MessageBox.Show("Por favor Digite um Sexo Válido!");

                            }
                            if ((validanomefisica(txtNomePFisica, errorProviderFornecedor) == true) && (validaCpf(txtCpfFFisica, errorProviderFornecedor) == true) &&
                                (validaRg(txtRgFisica, errorProviderFornecedor) == true) && (validaCelular(txtCelularFFisica, errorProviderFornecedor) == true) &&
                                (validaSexo()) && (comboBoxSexoFFIsica.SelectedItem.ToString() == "M"))
                            //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
                            {
                                //Pessoa Fisica recebe M
                                FonecedorFisica.Sexo = "M";

                                //Inserir Pessoa
                                dal.Incluir(cadastra);

                                IdFornecedorFisica = int.Parse(cadastra.idPessoa.ToString());

                                if (IdFornecedorFisica > 0)
                                {
                                    //Inserir Pessoa Fisica
                                    FonecedorFisica.idFornecedorFisica = IdFornecedorFisica;
                                    dal3.IncluirPessoaFIsica(FonecedorFisica);

                                    //Inserir Cep
                                    cadastraCep.idCep = IdFornecedorFisica;
                                    dal1.IncluirCep(cadastraCep);

                                    //Inserir Fornecedor
                                    pessoaFornecedor.idFornecedor = IdFornecedorFisica;
                                    dal2.IncluirF(pessoaFornecedor);


                                    MessageBox.Show("Fornecedor Cadastrado com sucesso!");

                                    FecharTodosFormulario();

                                    FormFornecedores cadastraFornecedor = new FormFornecedores();
                                    cadastraFornecedor.MdiParent = FormFornecedores.ActiveForm;
                                    cadastraFornecedor.Show();
                                    cadastraFornecedor.Top = 0;
                                    cadastraFornecedor.Left = 0;
                                }
                                else if (IdFornecedorFisica <= 0)
                                {

                                }

                            }
                        }
                        if ((validanomefisica(txtNomePFisica, errorProviderFornecedor) == true) && (validaCpf(txtCpfFFisica, errorProviderFornecedor) == true) &&
                            (validaRg(txtRgFisica, errorProviderFornecedor) == true) && (validaCelular(txtCelularFFisica, errorProviderFornecedor) == true) &&
                            (validaSexo()) && (comboBoxSexoFFIsica.SelectedItem.ToString() == "F"))
                        {
                            //Pessoa Fisica recebe M
                            FonecedorFisica.Sexo = "M";
                            //Inserir Pessoa
                            dal.Incluir(cadastra);

                            IdFornecedorFisica = int.Parse(cadastra.idPessoa.ToString());

                            if (IdFornecedorFisica > 0)
                            {
                                //Inserir Pessoa Fisica
                                FonecedorFisica.idFornecedorFisica = IdFornecedorFisica;
                                dal3.IncluirPessoaFIsica(FonecedorFisica);

                                //Inserir Cep
                                cadastraCep.idCep = IdFornecedorFisica;
                                dal1.IncluirCep(cadastraCep);

                                //Inserir Fornecedor
                                pessoaFornecedor.idFornecedor = IdFornecedorFisica;
                                dal2.IncluirF(pessoaFornecedor);


                                MessageBox.Show("Fornecedor Cadastrado com sucesso!");

                                FecharTodosFormulario();

                                FormFornecedores cadastraFornecedor = new FormFornecedores();
                                cadastraFornecedor.MdiParent = FormFornecedores.ActiveForm;
                                cadastraFornecedor.Show();
                                cadastraFornecedor.Top = 0;
                                cadastraFornecedor.Left = 0;
                            }
                            else if (IdFornecedorFisica <= 0)
                            {

                            }
                        }
                    }

                    if (radioButtonFornecedorJuridica.Checked == true)
                    {
                        if ((validaCnpj(txtCnpj, errorProviderFornecedor) == true) && (validaRazãoSocial(txtRazaoSocial, errorProviderFornecedor) == true)
                            && (validaRazãoSocial(txtRazaoSocial, errorProviderFornecedor) == true) && (validaNomeContato(txtNomeContato, errorProviderFornecedor) == true))
                        {
                            //Pessoa Fisica recebe M
                            FonecedorFisica.Sexo = "M";

                            //Inserir Pessoa
                            dal.Incluir(cadastra);

                            IdFornecedorJuridica = int.Parse(cadastra.idPessoa.ToString());

                            if (IdFornecedorJuridica > 0)
                            {

                                //Inserir Pessoa Juridica
                                FonecedorJuridica.idFornecedorJuridica = IdFornecedorJuridica;
                                dal4.IncluirPessoaJuridica(FonecedorJuridica);

                                //Inserir Cep
                                cadastraCep.idCep = IdFornecedorJuridica;
                                dal1.IncluirCep(cadastraCep);

                                //Inserir Fornecedor
                                pessoaFornecedor.idFornecedor = IdFornecedorJuridica;
                                dal2.IncluirF(pessoaFornecedor);


                                MessageBox.Show("Fornecedor Cadastrado com sucesso!");

                                FecharTodosFormulario();

                                FormFornecedores cadastraFornecedor = new FormFornecedores();
                                cadastraFornecedor.MdiParent = FormFornecedores.ActiveForm;
                                cadastraFornecedor.Show();
                                cadastraFornecedor.Top = 0;
                                cadastraFornecedor.Left = 0;
                            }
                            else if (IdFornecedorFisica <= 0)
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
        
        //Metodo que altera Botões e outras funções
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra Cliente
            {
                panelCadastraFornecedor.Enabled = true;

                buttonCadastraFornecedor.Enabled = false;

                buttonVerificarFornecedor.Enabled = true;
                buttonExcluirFornecedor.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFornecedor.Enabled = true;
                buttonFecharFornecedor.Enabled = true;

                radioButtonFornecedorFisica.Enabled = true;
                radioButtonFornecedorJuridica.Enabled = true;
            }
            if (op == 2)//salvar Cadastro de Cliente
            {
                panelCadastraFornecedor.Enabled = false;

                buttonCadastraFornecedor.Enabled = true;

                buttonVerificarFornecedor.Enabled = false;
                buttonExcluirFornecedor.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFornecedor.Enabled = false;
                buttonFecharFornecedor.Enabled = true;

            }
            if (op == 3)//Calcelar Cadastro de Cliente
            {
                panelCadastraFornecedor.Enabled = false;

                buttonCadastraFornecedor.Enabled = true;

                buttonVerificarFornecedor.Enabled = false;
                buttonExcluirFornecedor.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFornecedor.Enabled = false;
                buttonFecharFornecedor.Enabled = true;

            }
            if (op == 4) //  Editar Cadastro de Cliente
            {
                panelCadastraFornecedor.Enabled = true;

                buttonCadastraFornecedor.Enabled = false;

                buttonVerificarFornecedor.Enabled = true;
                buttonExcluirFornecedor.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFornecedor.Enabled = true;
                buttonFecharFornecedor.Enabled = true;
                tabControlFornedor.Enabled = true;

            }
            if (op == 5)//Cancela Pesquisa
            {
                txtPesquisaMSFornecedor.Enabled = false;
                txtPesquisaMSFornecedor.Enabled = false;
                radioButtonOculto.Checked = true;
                radioButtonPequisaMS.Enabled = false;
                radioButtonPesquisaNome.Enabled = false;
            }
            if (op == 6)//Cadastro de Cliente Inicializado
            {
                buttonCadastraFornecedor.Enabled = false;

                buttonVerificarFornecedor.Enabled = true;
                buttonExcluirFornecedor.Enabled = true;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFornecedor.Enabled = true;
                buttonFecharFornecedor.Enabled = true;
            }
            if (op == 7)//Botão Verificar informações Passadas
            {
                txtNomeContatoFornecedor.Enabled = false;
                txtNomeFornecedor.Enabled = false;
                txtCargoContatoFornecedor.Enabled = false;
                txtCepFornecedor.Enabled = false;
                txtTipo_logradouro.Enabled = false;
                txtBairroFornecedor.Enabled = false;
                txtBairroNumeroFornecedor.Enabled = false;
                txtTelefone2Fornecedor.Enabled = false;
                txtTelefoneFornecedor.Enabled = false;
                txtTelexTelefoneFornecedor.Enabled = false;
                txtEmailFornecedor.Enabled = false;
                txtEnderecoFornecedor.Enabled = false;
                txtMunicipioFornecedor.Enabled = false;
                txtPaisFornecedor.Enabled = false;
                txtComplFornecedor.Enabled = false;
                txtCpMunicipioFornecedor.Enabled = false;
                txtFaxTelefoneFornecedor.Enabled = false;
                txtDesPaisFornecedor.Enabled = false;
                txtObservacaoFornecedor.Enabled = false;
                txtTipoFornecedor.Enabled = false;
  

                ButtonBuscaCep.Enabled = false;
            }
            if (op == 8)//Libera Pessoa Fisica e Juridica!
            {
                radioButtonFornecedorFisica.Enabled = true;
                radioButtonFornecedorJuridica.Enabled = true;
                buttonVerificarFornecedor.Enabled = false;
                buttonExcluirFornecedor.Enabled = false;
                buttonLimpaFornecedor.Enabled = false;
                buttonCancelarFornecedor.Enabled = false;
                buttonFecharFornecedor.Enabled = false;
            }
            if (op == 9)//Libera Pesquisa Por MS e Nome.
            {

                buttonCadastraFornecedor.Enabled = false;
                radioButtonPequisaMS.Enabled = true;
                radioButtonPesquisaNome.Enabled = true;
                buttonFornecedorPesquisa.Enabled = true;
                //buttonPesquisaFornecedor.Enabled = true;
                //buttonEditarCliente.Enabled = true;
            }
            if (op == 10)
            {
                txtNomeContatoFornecedor.Clear();
                txtCargoContatoFornecedor.Clear();
                txtNomeFornecedor.Clear();
                txtEnderecoFornecedor.Clear();
                txtTelefoneFornecedor.Clear();
                txtTelefone2Fornecedor.Clear();
                txtFaxTelefoneFornecedor.Clear();
                txtTelexTelefoneFornecedor.Clear();
                txtEmailFornecedor.Clear();
                txtObservacaoFornecedor.Clear();
                txtCepFornecedor.Clear();
                txtTipoFornecedor.Clear();
                txtBairroFornecedor.Clear();
                txtComplFornecedor.Clear();
                txtBairroNumeroFornecedor.Clear();
                txtCidadeFornecedor.Clear();
                txtSiglaCidadeFornecedor.Clear();
                txtMunicipioFornecedor.Clear();
                txtCpMunicipioFornecedor.Clear();
                txtPaisFornecedor.Clear();
                txtDesPaisFornecedor.Clear();
                txtTipo_logradouro.Clear();
                txtPesquisaMSFornecedor.Clear();
                txtPesquisaNomeFornecedor.Clear();

            }
            if (op == 11)
            {//Pessoa Fisica
                txtNomePFisica.Enabled = true;
                comboBoxSexoFFIsica.Enabled = true;
                txtCpfFFisica.Enabled = true;
                txtRgFisica.Enabled = true;
                txtDataNascimentoFFisica.Enabled = true;
                txtCelularFFisica.Enabled = true;
                txtCelularFFisica2.Enabled = true;

                txtCnpj.Enabled = false;
                txtRazaoSocial.Enabled = false;
                txtInscStatual.Enabled = false;
                txtNomeContato.Enabled = false;


                txtCnpj.Clear();
                txtRazaoSocial.Clear();
                txtInscStatual.Clear();
                txtNomeContato.Clear();


            }
            if (op == 12)
            {//Pessoa Juridica

                txtCnpj.Enabled = true;
                txtRazaoSocial.Enabled = true;
                txtInscStatual.Enabled = true;
                txtNomeContato.Enabled = true;

                txtNomePFisica.Enabled = false;
                comboBoxSexoFFIsica.Enabled = false;
                txtCpfFFisica.Enabled = false;
                txtRgFisica.Enabled = false;
                txtDataNascimentoFFisica.Enabled = false;
                txtCelularFFisica.Enabled = false;
                txtCelularFFisica2.Enabled = false;

                txtNomePFisica.Clear();

                txtCpfFFisica.Clear();
                txtRgFisica.Clear();

                txtCelularFFisica.Clear();
                txtCelularFFisica2.Clear();
            }
        }
        private void ButtonBuscaCep_Click_1(object sender, EventArgs e)
        {
            string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml"
            .Replace("@cep", txtCepFornecedor.Text);
            DataSet ds = new DataSet();
            ds.ReadXml(xml);

            labelConfirmacao.Text = ds.Tables[0].Rows[0][1].ToString();
            //TesteValores.Text = txtCepCliente.Text;

            txtTipo_logradouro.Text = ds.Tables[0].Rows[0][5].ToString();
            txtEnderecoFornecedor.Text = ds.Tables[0].Rows[0][6].ToString();
            txtBairroFornecedor.Text = ds.Tables[0].Rows[0][4].ToString();
            txtCidadeFornecedor.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSiglaCidadeFornecedor.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void buttonEditarFornecedor_Click(object sender, EventArgs e)
        {
            AlteraBotoes(4);

            this.operacao = "Editar";

        }

        private void buttonExcluirFornecedor_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja Excluir o registro?", "Aviso", MessageBoxButtons.YesNo);

            string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao = new Conexao(strConexao);
            DALCadastro dal = new DALCadastro(conexao);

            if (d.ToString() == "Yes")
            {
                if (this.ID_TIPO_PESSOA == 1)
                {
                    dal.ExcluirFornecedorFisico(IdPessoa);

                    FecharTodosFormulario();

                    FormFornecedores Fornecedor = new FormFornecedores();
                    Fornecedor.MdiParent = FormFornecedores.ActiveForm;
                    Fornecedor.Show();
                    Fornecedor.Top = 0;
                    Fornecedor.Left = 0;
                }
                if (this.ID_TIPO_PESSOA == 2)
                {
                    dal.ExcluirFornecedorJuridica(IdPessoa);

                    FecharTodosFormulario();

                    FormFornecedores Fornecedor = new FormFornecedores();
                    Fornecedor.MdiParent = FormFornecedores.ActiveForm;
                    Fornecedor.Show();
                    Fornecedor.Top = 0;
                    Fornecedor.Left = 0;
                }
            }
        }
        
        private void ButtonPesquisa_Click(object sender, EventArgs e)
        {
            AlteraBotoes(9);

            radioButtonFornecedorFisica.Enabled = true;

            radioButtonFornecedorJuridica.Enabled = true;
        }

        private void radioButtonPequisaMS_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMSFornecedor.Enabled = true;
            txtPesquisaNomeFornecedor.Enabled = false;
            txtPesquisaNomeFornecedor.Clear();
            AlteraBotoes(10);
        }

        private void radioButtonPesquisaNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMSFornecedor.Enabled = false;
            txtPesquisaNomeFornecedor.Enabled = true;
            txtPesquisaNomeFornecedor.Clear();
            AlteraBotoes(10);
        }

        private void p_ClientePessoaBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void radioButtonFornecedorFisica_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Passado Fisica: " + IdFornecedorFisica);
            radioButtonFornecedorJuridica.Enabled = false;
            FormCadastroFornecedorFisica fisica = new FormCadastroFornecedorFisica();
            fisica.MdiParent = this.MdiParent;
            fisica.Show();
            fisica.IdfornecedorFisica = IdFornecedorFisica;

        }

        private void radioButtonFornecedorJuridica_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Valor PassadoJuridica: " + IdFornecedorJuridica);
            radioButtonFornecedorFisica.Enabled = false;
            FormCadastroFornecedorJuridica Juridica = new FormCadastroFornecedorJuridica();
            Juridica.MdiParent = this.MdiParent;
            Juridica.Show();
            Juridica.idFornecedorJuridica = IdFornecedorJuridica;

        }

        private void buttonPesquisaFornecedor_Click(object sender, EventArgs e)
        {

        }

        private void buttonFornecedorPesquisa_Click(object sender, EventArgs e)
        {
            if (radioButtonPesquisaNome.Checked)
            {
                String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

                SqlConnection conn = new SqlConnection(connectionString);

                FORMULARIO = true;

                if (!(txtPesquisaNomeFornecedor.Text == ""))
                {
                    //SELECIONA POR NOME
                    SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaPessoaFornecedorNome1Txt '" + txtPesquisaNomeFornecedor.Text + "'", conn);

                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);

                    conn.Open();

                    if ((radioButtonPesquisaNome.Checked) && (ds2.Tables[0].Rows.Count > 0))
                    {
                        if (FORMULARIO == true)
                        {
                            FecharFormularioFeJ();

                            FORMULARIO = false;
                        }
                        IDPESSOA = int.Parse(ds2.Tables[0].Rows[0][0].ToString());

                        ID_TIPO_PESSOA = int.Parse(ds2.Tables[0].Rows[0][1].ToString());

                        if (IDPESSOA != 0)
                        {
                            buttonExcluirFornecedor.Enabled = true;
                        }
                        if (IDPESSOA == 0)
                        {
                            buttonExcluirFornecedor.Enabled = false;
                        }

                        //Cliente Fisico             
                        string NOME1 = ds2.Tables[0].Rows[0][16].ToString();
                        string SEXO = ds2.Tables[0].Rows[0][17].ToString();
                        string CPF = ds2.Tables[0].Rows[0][18].ToString();
                        string RG = ds2.Tables[0].Rows[0][19].ToString();
                        string CELULAR = ds2.Tables[0].Rows[0][21].ToString();
                        String CELULAR2 = ds2.Tables[0].Rows[0][22].ToString();
                        string DATANASCIMENTO = ds2.Tables[0].Rows[0][20].ToString();

                        //Cliente Juridica

                        string CNPJ = ds2.Tables[0].Rows[0][25].ToString();
                        string RAZAOSOCIAL = ds2.Tables[0].Rows[0][24].ToString();
                        string INSCSTADUAL = ds2.Tables[0].Rows[0][27].ToString();
                        string NOME = ds2.Tables[0].Rows[0][26].ToString();

                        if (ID_TIPO_PESSOA == 1)
                        {
                            try
                            {
                                MessageBox.Show("Valor Passado: " + IDPESSOA);

                                radioButtonFornecedorFisica.Enabled = false;
                                radioButtonFornecedorJuridica.Enabled = false;

                                FormCadastroFornecedorFisica fisica = new FormCadastroFornecedorFisica(IDPESSOA, NOME1, SEXO, CPF, RG, CELULAR, CELULAR2, DATANASCIMENTO, true);
                                fisica.MdiParent = this.MdiParent;
                                fisica.Show();

                                txtNomeFornecedor.Text = ds2.Tables[0].Rows[0][3].ToString();
                                txtNomeContatoFornecedor.Text = ds2.Tables[0].Rows[0][38].ToString();
                                txtCargoContatoFornecedor.Text = ds2.Tables[0].Rows[0][39].ToString();
                                txtTelefoneFornecedor.Text = ds2.Tables[0].Rows[0][4].ToString();
                                txtTelefone2Fornecedor.Text = ds2.Tables[0].Rows[0][5].ToString();
                                txtFaxTelefoneFornecedor.Text = ds2.Tables[0].Rows[0][6].ToString();
                                txtTelexTelefoneFornecedor.Text = ds2.Tables[0].Rows[0][7].ToString();
                                txtEmailFornecedor.Text = ds2.Tables[0].Rows[0][8].ToString();
                                txtObservacaoFornecedor.Text = ds2.Tables[0].Rows[0][9].ToString();
                                txtCepFornecedor.Text = ds2.Tables[0].Rows[0][40].ToString();
                                txtTipoFornecedor.Text = ds2.Tables[0].Rows[0][10].ToString();
                                txtEnderecoFornecedor.Text = ds2.Tables[0].Rows[0][31].ToString();
                                txtBairroNumeroFornecedor.Text = ds2.Tables[0].Rows[0][32].ToString();
                                txtComplFornecedor.Text = ds2.Tables[0].Rows[0][33].ToString();
                                txtBairroFornecedor.Text = ds2.Tables[0].Rows[0][34].ToString();
                                txtCidadeFornecedor.Text = ds2.Tables[0].Rows[0][35].ToString();
                                txtSiglaCidadeFornecedor.Text = ds2.Tables[0].Rows[0][36].ToString();
                                txtCpMunicipioFornecedor.Text = ds2.Tables[0].Rows[0][11].ToString();
                                txtMunicipioFornecedor.Text = ds2.Tables[0].Rows[0][12].ToString();
                                txtPaisFornecedor.Text = ds2.Tables[0].Rows[0][13].ToString();
                                txtDesPaisFornecedor.Text = ds2.Tables[0].Rows[0][14].ToString();
                                txtTipo_logradouro.Text = ds2.Tables[0].Rows[0][30].ToString();
                                int status = int.Parse(ds2.Tables[0].Rows[0][2].ToString());
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
                        if (ID_TIPO_PESSOA == 2)
                        {
                            try
                            {
                                MessageBox.Show("Valor Passado: " + IDPESSOA);

                                radioButtonFornecedorFisica.Enabled = false;
                                radioButtonFornecedorJuridica.Enabled = false;

                                FormCadastroFornecedorJuridica juridico = new FormCadastroFornecedorJuridica(IDPESSOA, CNPJ, RAZAOSOCIAL, INSCSTADUAL, NOME, true);

                                juridico.MdiParent = this.MdiParent;
                                juridico.Show();

                                txtNomeFornecedor.Text = ds2.Tables[0].Rows[0][3].ToString();
                                txtNomeContatoFornecedor.Text = ds2.Tables[0].Rows[0][38].ToString();
                                txtCargoContatoFornecedor.Text = ds2.Tables[0].Rows[0][39].ToString();
                                txtTelefoneFornecedor.Text = ds2.Tables[0].Rows[0][4].ToString();
                                txtTelefone2Fornecedor.Text = ds2.Tables[0].Rows[0][5].ToString();
                                txtFaxTelefoneFornecedor.Text = ds2.Tables[0].Rows[0][6].ToString();
                                txtTelexTelefoneFornecedor.Text = ds2.Tables[0].Rows[0][7].ToString();
                                txtEmailFornecedor.Text = ds2.Tables[0].Rows[0][8].ToString();
                                txtObservacaoFornecedor.Text = ds2.Tables[0].Rows[0][9].ToString();
                                txtCepFornecedor.Text = ds2.Tables[0].Rows[0][40].ToString();
                                txtTipoFornecedor.Text = ds2.Tables[0].Rows[0][10].ToString();
                                txtEnderecoFornecedor.Text = ds2.Tables[0].Rows[0][31].ToString();
                                txtBairroNumeroFornecedor.Text = ds2.Tables[0].Rows[0][32].ToString();
                                txtComplFornecedor.Text = ds2.Tables[0].Rows[0][33].ToString();
                                txtBairroFornecedor.Text = ds2.Tables[0].Rows[0][34].ToString();
                                txtCidadeFornecedor.Text = ds2.Tables[0].Rows[0][35].ToString();
                                txtSiglaCidadeFornecedor.Text = ds2.Tables[0].Rows[0][36].ToString();
                                txtCpMunicipioFornecedor.Text = ds2.Tables[0].Rows[0][11].ToString();
                                txtMunicipioFornecedor.Text = ds2.Tables[0].Rows[0][12].ToString();
                                txtPaisFornecedor.Text = ds2.Tables[0].Rows[0][13].ToString();
                                txtDesPaisFornecedor.Text = ds2.Tables[0].Rows[0][14].ToString();
                                txtTipo_logradouro.Text = ds2.Tables[0].Rows[0][30].ToString();
                                int status = int.Parse(ds2.Tables[0].Rows[0][2].ToString());
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
                    }
                    if (!(ds2.Tables[0].Rows.Count > 0))
                    {
                        MessageBox.Show("O nome: " + txtPesquisaNomeFornecedor.Text + " não consta no sistema!");
                         FecharFormularioFeJ();
                    }
                }
                if ((txtPesquisaNomeFornecedor.Text == ""))
                {
                    MessageBox.Show("O Nome não pode esta em branco!");
                    FecharFormularioFeJ();
                }

            }
            else if (!(radioButtonPequisaMS.Checked) && !(radioButtonPesquisaNome.Checked)) MessageBox.Show("Seleciona Ms ou Nome para uma Pesquisa!");
            //AlteraBotoes(10);

        }

        private void txtBairroNumeroFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLimpaFornecedor_Click(object sender, EventArgs e)
        {
            AlteraBotoes(10);
        }

        private void buttonFecharFornecedor_Click(object sender, EventArgs e)
        {
            //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS
            FecharTodosFormulario();

        }

        private void radioButtonFornecedorFisica_CheckedChanged_1(object sender, EventArgs e)
        {
            tabControlFornedor.Enabled = true;
            AlteraBotoes(11);
        }

        private void radioButtonFornecedorJuridica_CheckedChanged_1(object sender, EventArgs e)
        {
            tabControlFornedor.Enabled = true;
            AlteraBotoes(12);
        }

        private void buttonDesvalidarJuridica_Click_1(object sender, EventArgs e)
        {

        }

        private void ButtonValidarFornecedorJuridica_Click(object sender, EventArgs e)
        {

        }
    }
}
