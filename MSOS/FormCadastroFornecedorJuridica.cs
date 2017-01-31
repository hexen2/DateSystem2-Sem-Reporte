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
    public partial class FormCadastroFornecedorJuridica : Form
    {
        private int ID_FORNECEDOR_JURIDICA = 0;
        public int idFornecedorJuridica
        {
            get
            {
                return this.ID_FORNECEDOR_JURIDICA;

            }
            set
            {
                this.ID_FORNECEDOR_JURIDICA = value;
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
        public FormCadastroFornecedorJuridica()
        {
            InitializeComponent();

        }
        public FormCadastroFornecedorJuridica(int idCliente, string CNPJ, string RAZAOSOCIAL, string INSCRSTADUAL, string NOME, Boolean VerificadorEditar)
        {
            InitializeComponent();
            AlteraBotoes(2);
            this.Top = 600;
            this.Left = 0;

            txtCnpj.MaxLength = 14;
            txtInscStatual.MaxLength = 20;
            txtRazaoSocial.MaxLength = 40;
            txtNomeContato.MaxLength = 20;

            idFornecedorJuridica = idCliente;
            txtCnpj.Text = CNPJ;
            txtRazaoSocial.Text = RAZAOSOCIAL;
            txtInscStatual.Text = INSCRSTADUAL;
            txtNomeContato.Text = NOME;
            VERIFICADOREDITAR = VerificadorEditar;
        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Liberar Botão de Salvar
            {
                ButtonValidarFornecedorJuridica.Enabled = true;
                ButtonValidarFornecedorJuridica.Visible = true;
            }
            if (op == 2)//Tela De Alteração Bloqueiada!
            {
                txtCnpj.Enabled = false;
                txtRazaoSocial.Enabled = false;
                txtInscStatual.Enabled = false;
                txtNomeContato.Enabled = false;


                ButtonValidarFornecedorJuridica.Enabled = false;
                buttonDesvalidarJuridica.Enabled = true;
                buttonEditarFonecedor.Enabled = true;
            }
            if (op == 3) //Tela Editar Cadastro Fisico!
            {
                txtNomeContato.Enabled = true;

                ButtonValidarFornecedorJuridica.Enabled = true;
                buttonDesvalidarJuridica.Enabled = true;
                buttonEditarFonecedor.Enabled = false;

            }
            if (op == 4)
            {

            }
            if (op == 5)
            {

            }
            if (op == 6)
            {

            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCnpj(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCnpj.Text))
            {
                errorProviderFornecedorJuridico.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedorJuridico.SetError(textBox, "Cnpj Inválido!");
                return false;
            }

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaInscricaoStadual(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtInscStatual.Text))
            {
                errorProviderFornecedorJuridico.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedorJuridico.SetError(textBox, "Inscrição Estatual Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaRazãoSocial(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtRazaoSocial.Text))
            {
                errorProviderFornecedorJuridico.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedorJuridico.SetError(textBox, "Razão Social Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaNomeContato(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeContato.Text))
            {
                errorProviderFornecedorJuridico.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedorJuridico.SetError(textBox, "Nome do Contato Inválido!");
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

        private void p_ClientePessoaBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }



        private void buttonDesvalidarJuridica_Click(object sender, EventArgs e)
        {
            //Metodo que verifica Formulario Abertos
            FecharTodosFormulario();
        }
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

        private void FormCadastroFornecedorJuridica_Load(object sender, EventArgs e)
        {
            this.Top = 600;
            this.Left = 0;
            txtCnpj.MaxLength = 14;
            txtInscStatual.MaxLength = 20;
            txtRazaoSocial.MaxLength = 40;
            txtNomeContato.MaxLength = 20;
        }


        private void ButtonValidarFornecedorJuridica_Click(object sender, EventArgs e)
        {

            if (VERIFICADOREDITAR == false)
            {
                FornecedorJuridica FonecedorJuridica = new FornecedorJuridica();
                FonecedorJuridica.idFornecedorJuridica = idFornecedorJuridica;  // Convert.ToInt32(idPesssoaFisica);
                FonecedorJuridica.Cnpj = txtCnpj.Text;
                FonecedorJuridica.RazaoSocial = txtRazaoSocial.Text;
                FonecedorJuridica.InscricaoStadual = txtInscStatual.Text;
                FonecedorJuridica.NomeContato = txtNomeContato.Text;

                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                Conexao conexao = new Conexao(strConexao);
                DALCadastro dal = new DALCadastro(conexao);

                if ((validaCnpj(txtCnpj, errorProviderFornecedorJuridico) == true) && (validaRazãoSocial(txtRazaoSocial, errorProviderFornecedorJuridico) == true)
                 && (validaRazãoSocial(txtRazaoSocial, errorProviderFornecedorJuridico) == true) && (validaNomeContato(txtNomeContato, errorProviderFornecedorJuridico) == true))
                {
                    dal.IncluirPessoaJuridica(FonecedorJuridica);

                    //Metodo que verifica Formulario Abertos
                    FecharTodosFormulario();
                    MessageBox.Show("Fornecedor Cadastrado");

                    FormFornecedores Fornecedor = new FormFornecedores();
                    Fornecedor.MdiParent = FormFornecedores.ActiveForm;
                    Fornecedor.Show();
                    Fornecedor.Top = 0;
                    Fornecedor.Left = 0;
                }
            }
            if (VERIFICADOREDITAR == true)
            {
                FornecedorJuridica FonecedorJuridica = new FornecedorJuridica();
                FonecedorJuridica.idFornecedorJuridica = idFornecedorJuridica;


                FonecedorJuridica.NomeContato = txtNomeContato.Text;

                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                Conexao conexao = new Conexao(strConexao);
                DALCadastro dal = new DALCadastro(conexao);

                if ((validaCnpj(txtCnpj, errorProviderFornecedorJuridico) == true) && (validaRazãoSocial(txtRazaoSocial, errorProviderFornecedorJuridico) == true) &&
                    (validaNomeContato(txtNomeContato, errorProviderFornecedorJuridico) == true))
                {
                    dal.IncluirPessoaJuridica(FonecedorJuridica);

                    //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS
                    FecharTodosFormulario();

                    FormFornecedores Fornecedores = new FormFornecedores();
                    Fornecedores.MdiParent = FormFornecedores.ActiveForm;
                    Fornecedores.Show();
                    Fornecedores.Top = 0;
                    Fornecedores.Left = 0;
                }
            }
        }

        private void buttonDesvalidarJuridica_Click_1(object sender, EventArgs e)
        {
            //Metodo que verifica Formulario Abertos
            FecharTodosFormulario();

            FormFornecedores Fornecedores = new FormFornecedores();
            Fornecedores.MdiParent = FormFornecedores.ActiveForm;
            Fornecedores.Show();
            Fornecedores.Top = 0;
            Fornecedores.Left = 0;
        }
        //CHAMA O METODO Fecha Fisica E Juridica QUE FECHA FORMULÁRIOS ABERTOS
        public void FecharFormularioFeJ()
        {
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorJuridica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorJuridica));
        }
        //CHAMA O METODO CancelaCadastradoFornecedor QUE FECHA FORMULÁRIOS ABERTOS
        public void FecharTodosFormulario()
        {
            CancelaCadastradoFornecedor(typeof(FormFornecedores));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorJuridica));
            CancelaCadastradoFornecedor(typeof(FormCadastroFornecedorJuridica));
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

        private void buttonEditarFonecedor_Click(object sender, EventArgs e)
        {
            AlteraBotoes(3);
        }
    }
}