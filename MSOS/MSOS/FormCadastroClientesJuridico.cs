using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MSOS
{
    public partial class FormCadastroClientesJuridico : Form
    {
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
        public FormCadastroClientesJuridico()
        {
            InitializeComponent();

        }
        public FormCadastroClientesJuridico(int idCliente, string CNPJ, string RAZAOSOCIAL, string INSCRSTADUAL, string NOME, Boolean VerificadorEditar)
        {
            InitializeComponent();
            AlteraBotoes(2);
            this.Top = 600;
            this.Left = 0;

            txtCnpJTextBox.MaxLength = 14;
            txtiNSCRICAO_STADUALTextBox.MaxLength = 20;
            txtrAZAO_SOCIALTextBox.MaxLength = 40;
            txtnOME_CONTATOTextBox.MaxLength = 20;

            idPessoaJuridica = idCliente;
            txtCnpJTextBox.Text = CNPJ;
            txtrAZAO_SOCIALTextBox.Text = RAZAOSOCIAL;
            txtiNSCRICAO_STADUALTextBox.Text = INSCRSTADUAL;
            txtnOME_CONTATOTextBox.Text = NOME;
            VERIFICADOREDITAR = VerificadorEditar;
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
        //METODO Fecha todos os FIsicos e Juridico!
        public void FecharFormularioFeJ()
        {
            //CHAMA O METODO CancelaCadastradoForncedor QUE FECHA FORMULÁRIOS ABERTOS
            CancelaCadastradoCliente(typeof(FormFornecedores));
            CancelaCadastradoCliente(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoCliente(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoCliente(typeof(FormCadastroFornecedorJuridica));
            CancelaCadastradoCliente(typeof(FormCadastroFornecedorJuridica));
        }
        //METODO Fecha todos os Formulario!
        public void FecharTodosFormulario()
        {
            //CHAMA O METODO CancelaCadastradoFornecedor QUE FECHA FORMULÁRIOS ABERTOS
            CancelaCadastradoCliente(typeof(FormCadastroClientes));
            CancelaCadastradoCliente(typeof(FormCadastroClienteFisica));
            CancelaCadastradoCliente(typeof(FormCadastroClienteFisica));
            CancelaCadastradoCliente(typeof(FormCadastroClientesJuridico));
            CancelaCadastradoCliente(typeof(FormCadastroClientesJuridico));
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
        private void FormCadastroClientesJuridico_Load(object sender, EventArgs e)
        {
            this.Top = 600;
            this.Left = 0;
            txtCnpJTextBox.MaxLength = 14;
            txtiNSCRICAO_STADUALTextBox.MaxLength = 20;
            txtrAZAO_SOCIALTextBox.MaxLength = 40;
            txtnOME_CONTATOTextBox.MaxLength = 20;

        }
        private void panelJuridico_Paint(object sender, PaintEventArgs e)
        {

        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Liberar Botão de Salvar
            {
                ButtonValidarPessoaJuridica.Enabled = true;
                ButtonValidarPessoaJuridica.Visible = true;
            }
            if (op == 2)//Tela De Alteração Bloqueiada!
            {
                txtCnpJTextBox.Enabled = false;
                txtrAZAO_SOCIALTextBox.Enabled = false;
                txtiNSCRICAO_STADUALTextBox.Enabled = false;
                txtnOME_CONTATOTextBox.Enabled = false;


                ButtonValidarPessoaJuridica.Enabled = false;
                buttonDesvalidarJuridica.Enabled = true;
                buttonEditarClienteJuridico.Enabled = true;
            }
            if (op == 3) //Tela Editar Cadastro Fisico!
            {
                txtnOME_CONTATOTextBox.Enabled = true;

                ButtonValidarPessoaJuridica.Enabled = true;
                buttonDesvalidarJuridica.Enabled = true;
                buttonEditarClienteJuridico.Enabled = false;

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

        private void ButtonValidarPessoaJuridica_Click(object sender, EventArgs e)
        {
            if(VERIFICADOREDITAR == false)
            {
                PessoaJuridica pessoaJuridica = new PessoaJuridica();
                pessoaJuridica.idPessoaJuridica = idPessoaJuridica;  // Convert.ToInt32(idPesssoaFisica);
                pessoaJuridica.IdPessoaTipo = 2;
                pessoaJuridica.Cnpj = txtCnpJTextBox.Text;
                pessoaJuridica.RazaoSocial = txtrAZAO_SOCIALTextBox.Text;
                pessoaJuridica.InscricaoStadual = txtiNSCRICAO_STADUALTextBox.Text;
                pessoaJuridica.NomeContato = txtnOME_CONTATOTextBox.Text;

                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                Conexao conexao = new Conexao(strConexao);
                DALCadastro dal = new DALCadastro(conexao);

                if ((validaCnpj(txtCnpJTextBox, errorProviderClienteJuridica) == true) && (validaRazãoSocial(txtrAZAO_SOCIALTextBox, errorProviderClienteJuridica) == true)
                 && (validaRazãoSocial(txtrAZAO_SOCIALTextBox, errorProviderClienteJuridica) == true) && (validaNomeContato(txtnOME_CONTATOTextBox, errorProviderClienteJuridica) == true))
                {
                    dal.IncluirPessoaJuridica(pessoaJuridica);

                    FecharTodosFormulario();

                    FormCadastroClientes CadastraClientes = new FormCadastroClientes();
                    CadastraClientes.MdiParent = FormCadastroClientes.ActiveForm;
                    CadastraClientes.Show();
                    CadastraClientes.Top = 0;
                    CadastraClientes.Left = 0;
                }
            }
            if(VERIFICADOREDITAR == true)
            {
                PessoaJuridica pessoaJuridica = new PessoaJuridica();
                pessoaJuridica.idPessoaJuridica = idPessoaJuridica;

                pessoaJuridica.NomeContato = txtnOME_CONTATOTextBox.Text;

                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                Conexao conexao = new Conexao(strConexao);
                DALCadastro dal = new DALCadastro(conexao);

                if ((validaCnpj(txtCnpJTextBox, errorProviderClienteJuridica) == true) && (validaRazãoSocial(txtrAZAO_SOCIALTextBox, errorProviderClienteJuridica) == true) &&
                    (validaNomeContato(txtnOME_CONTATOTextBox, errorProviderClienteJuridica) == true))
                {
                    dal.AlterarClienteJuridica(pessoaJuridica);

                    FecharTodosFormulario();

                    MessageBox.Show("Cadastro de Cliente Juridico Salvo!");

                    FormCadastroClientes CadastraClientes = new FormCadastroClientes();
                    CadastraClientes.MdiParent = FormCadastroClientes.ActiveForm;
                    CadastraClientes.Show();
                    CadastraClientes.Top = 0;
                    CadastraClientes.Left = 0;

                   
                }
            }
        }

        private void buttonDesvalidarJuridica_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormCadastroClientes cadastracliente = new FormCadastroClientes();
            cadastracliente.MdiParent = FormCadastroClientes.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }

        private void buttonEditarClienteJuridico_Click(object sender, EventArgs e)
        {
            AlteraBotoes(3);
        }
    }
}
