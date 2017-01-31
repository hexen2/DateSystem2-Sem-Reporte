using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSOS
{
    public partial class FormCadastroClienteFisica : Form
    {
        private int ID_CLIENTE_FISICO = 0;
        public int idClienteFisico
        {
            get
            {
                return this.ID_CLIENTE_FISICO;

            }
            set
            {
                this.ID_CLIENTE_FISICO = value;
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

        public FormCadastroClienteFisica()
        {
            InitializeComponent();
        }
        private string OPERACAO = "";
        public string operacao
        {
            get
            {
                return this.OPERACAO;

            }
            set
            {
                this.OPERACAO = value;
            }
        }

        public void AlteraBotoes(int op)
        {
            if (op == 1)// Liberar Botão de Salvar
            {
                buttonEditarCadastro.Enabled = true;
                buttonEditarCadastro.Visible = true;
            }
            if (op == 2)//Tela De Alteração Bloqueiada!
            {
                txtRgFisica.Enabled = false;
                txtCpfPFisica.Enabled = false;
                txtCelularPFisica.Enabled = false;
                txtCelularPFisica2.Enabled = false;
                txtDataNascimento.Enabled = false;
                comboBoxSexoPFIsica.Enabled = false;

                buttonEditarCadastro.Enabled = false;
                buttonDesvalidarFisica.Enabled = true;
                // ButtonEditarFornecedorFisica.Enabled = true;
            }
            if (op == 3) //Tela Editar Cadastro Fisico!
            {
                txtNomePFisica.Enabled = false;
                txtRgFisica.Enabled = false;
                txtCpfPFisica.Enabled = false;
                txtCelularPFisica.Enabled = true;
                txtCelularPFisica2.Enabled = true;
                comboBoxSexoPFIsica.Enabled = false;
                txtDataNascimento.Enabled = false;

                ButtonValidarPessoaFisica.Enabled = true;
                buttonEditarCadastro.Enabled = false;
                buttonDesvalidarFisica.Enabled = true;
         
            }
            if (op == 4)//Limpa Cadastro
            {
                txtNomePFisica.Clear();
                txtCpfPFisica.Clear();
                txtRgFisica.Clear();
                txtCelularPFisica.Clear();
                txtCelularPFisica2.Clear();
                comboBoxSexoPFIsica.ResetText();
                txtDataNascimento.ResetText();
            }
            if (op == 5)
            {

            }
            if (op == 6)
            {

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
                errorProviderCadastroClienteFisico.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroClienteFisico.SetError(textBox, "Rg Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCpf(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCpfPFisica.Text))
            {
                errorProviderCadastroClienteFisico.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroClienteFisico.SetError(textBox, "Cpf Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private bool validaCelular(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularPFisica.Text))
            {
                errorProviderCadastroClienteFisico.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroClienteFisico.SetError(textBox, "Celular Inválido!");
                return false;
            }
        }
        private bool validaCelular2(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularPFisica2.Text))
            {
                errorProviderCadastroClienteFisico.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastroClienteFisico.SetError(textBox, "Celular Inválido!");
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
        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!

        public FormCadastroClienteFisica(int idCliente, string NOME, string SEXO, string CPF, string RG, string CELULAR, string CELULAR2, String DATANASCIMENTO, Boolean VerificadorEditar)
        {
            InitializeComponent();

            AlteraBotoes(2);

            this.Top = 600;
            this.Left = 0;

            txtRgFisica.MaxLength = 9;
            txtCpfPFisica.MaxLength = 11;
            txtCelularPFisica.MaxLength = 11;
            txtCelularPFisica2.MaxLength = 11;

            txtNomePFisica.Enabled = false;
            idClienteFisico = idCliente;
            txtNomePFisica.Text = NOME;
            comboBoxSexoPFIsica.Text = SEXO;
            txtCpfPFisica.Text = CPF;
            txtRgFisica.Text = RG;
            txtCelularPFisica.Text = CELULAR;
            txtCelularPFisica2.Text = CELULAR2;
            txtDataNascimento.Text = DATANASCIMENTO;
            VERIFICADOREDITAR = VerificadorEditar;
            ButtonValidarPessoaFisica.Enabled = false;
            buttonEditarCadastro.Enabled = true;

        }

        //CHAMA O METODO Fecha Fisica E Juridica QUE FECHA FORMULÁRIOS ABERTOS


        private void ButtonValidarPessoaFisica_Click_1(object sender, EventArgs e)
        {
            if (VerificadorEditar == false)
            {
                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

                Conexao conexao = new Conexao(strConexao);
                DALCadastro dal = new DALCadastro(conexao);

                PessoaFisica PessoaFisica = new PessoaFisica();

                if ((validaSexo()) && comboBoxSexoPFIsica.SelectedItem.ToString() == "M")
                {

                    PessoaFisica.idPessoaFisica = idClienteFisico;
                    PessoaFisica.Nome = txtNomePFisica.Text;
                    PessoaFisica.Sexo = "M";
                    PessoaFisica.Cpf = txtCpfPFisica.Text;
                    PessoaFisica.Rg = txtRgFisica.Text;
                    PessoaFisica.dataNacimento = txtDataNascimento.Text;
                    PessoaFisica.Celular = txtCelularPFisica.Text;
                    PessoaFisica.Celular2 = txtCelularPFisica2.Text;

                    dal.IncluirPessoaFIsica(PessoaFisica);

                    FecharTodosFormulario();

                    FormCadastroClientes CadastraClientes = new FormCadastroClientes();
                    CadastraClientes.MdiParent = FormCadastroClientes.ActiveForm;
                    CadastraClientes.Show();
                    CadastraClientes.Top = 0;
                    CadastraClientes.Left = 0;


                    MessageBox.Show("Cliente Cadastrado!");

                }
                if ((validaSexo()) && comboBoxSexoPFIsica.SelectedItem.ToString() == "F")
                {
                    PessoaFisica.idPessoaFisica = idClienteFisico;
                    PessoaFisica.Sexo = "F";
                    PessoaFisica.Cpf = txtCpfPFisica.Text;
                    PessoaFisica.Rg = txtRgFisica.Text;
                    PessoaFisica.dataNacimento = txtDataNascimento.Text;
                    PessoaFisica.Celular = txtCelularPFisica.Text;
                    PessoaFisica.Celular2 = txtCelularPFisica2.Text;

                    dal.IncluirPessoaFIsica(PessoaFisica);

                    FecharTodosFormulario();

                    MessageBox.Show("Cliente Cadastrado!");

                    FormCadastroClientes CadastraClientes = new FormCadastroClientes();
                    CadastraClientes.MdiParent = FormCadastroClientes.ActiveForm;
                    CadastraClientes.Show();
                    CadastraClientes.Top = 0;
                    CadastraClientes.Left = 0;

                }
                if (!validaSexo())
                {

                    MessageBox.Show("Por favor Digite um Sexo Válido!");

                }

            }
            if (VerificadorEditar == true)
            {
                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

                Conexao conexao = new Conexao(strConexao);
                DALCadastro dal = new DALCadastro(conexao);

                PessoaFisica pessoafisica = new PessoaFisica();
                pessoafisica.idPessoaFisica = idClienteFisico;

                pessoafisica.Celular = txtCelularPFisica.Text;
                pessoafisica.Celular2 = txtCelularPFisica2.Text;

                dal.AlterarClienteFIsica(pessoafisica);

                FecharTodosFormulario();

                MessageBox.Show("As Alterações do Cliente Fisico foram Salvas!");

                MessageBox.Show("idClienteFisico   " + idClienteFisico+  "       e o idPessoaFisica     " + pessoafisica.idPessoaFisica.ToString());

                FormCadastroClientes CadastraClientes = new FormCadastroClientes();
                CadastraClientes.MdiParent = FormCadastroClientes.ActiveForm;
                CadastraClientes.Show();
                CadastraClientes.Top = 0;
                CadastraClientes.Left = 0;            
            }
        }

        private void buttonDesvalidarFisica_Click_1(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormCadastroClientes cadastracliente = new FormCadastroClientes();
            cadastracliente.MdiParent = FormCadastroClientes.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }

        private void FormCadastroClienteFisica_Load(object sender, EventArgs e)
        {
            this.Top = 600;
            this.Left = 0;

            txtRgFisica.MaxLength = 9;
            txtCpfPFisica.MaxLength = 11;
            txtCelularPFisica.MaxLength = 11;
            txtCelularPFisica2.MaxLength = 11;
        }
        public void FecharFormularioFeJ()
        {
            CancelaCadastradoCliente(typeof(FormCadastroClienteFisica));
            CancelaCadastradoCliente(typeof(FormCadastroClienteFisica));
            CancelaCadastradoCliente(typeof(FormCadastroClienteFisica));
            CancelaCadastradoCliente(typeof(FormCadastroClientesJuridico));
            CancelaCadastradoCliente(typeof(FormCadastroClientesJuridico));
        }
        //CHAMA O METODO CancelaCadastradoFornecedor QUE FECHA FORMULÁRIOS ABERTOS
        public void FecharTodosFormulario()
        {
            CancelaCadastradoCliente(typeof(FormCadastroClientes));
            CancelaCadastradoCliente(typeof(FormCadastroClienteFisica));
            CancelaCadastradoCliente(typeof(FormCadastroClienteFisica));
            CancelaCadastradoCliente(typeof(FormCadastroClientesJuridico));
            CancelaCadastradoCliente(typeof(FormCadastroClientesJuridico));
        }
        //Metodo que verifica Formulario Abertos
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
        private void buttonEditarCadastro_Click(object sender, EventArgs e)
        {
            AlteraBotoes(3);
            this.operacao = "Editar";
        }
    }
}
