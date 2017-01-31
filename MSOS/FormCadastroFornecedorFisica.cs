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
    public partial class FormCadastroFornecedorFisica : Form
    {
        public Form MDiParent { get; internal set; }

        private int ID_FORNECEDOR_FISICA = 0;
        public int IdfornecedorFisica
        {
            get
            {
                return this.ID_FORNECEDOR_FISICA;

            }
            set
            {
                this.ID_FORNECEDOR_FISICA = value;
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

        public FormCadastroFornecedorFisica()
        {
            InitializeComponent();
        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Liberar Botão de Salvar
            {
                ButtonEditarFornecedorFisica.Enabled = true;
                ButtonEditarFornecedorFisica.Visible = true;
            }
            if (op == 2)//Tela De Alteração Bloqueiada!
            {
                txtRgFisica.Enabled = false;
                txtCpfFFisica.Enabled = false;
                txtCelularFFisica.Enabled = false;
                txtCelularFFisica2.Enabled = false;
                txtDataNascimentoFFisica.Enabled = false;
                comboBoxSexoFFIsica.Enabled = false;

                ButtonEditarFornecedorFisica.Enabled = false;
                buttonDesvalidarFisica.Enabled = true;
                ButtonEditarFornecedorFisica.Enabled = true;
            }
            if (op == 3) //Tela Editar Cadastro Fisico!
            {
                txtRgFisica.Enabled = false;
                txtCpfFFisica.Enabled = false;
                txtCelularFFisica.Enabled = true;
                txtCelularFFisica2.Enabled = true;
                comboBoxSexoFFIsica.Enabled = false;
                txtDataNascimentoFFisica.Enabled = false;

                ButtonEditarFornecedorFisica.Enabled = true;
                buttonDesvalidarFisica.Enabled = true;
                ButtonEditarFornecedorFisica.Enabled = false;

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
                errorProviderFornecedorFisica.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedorFisica.SetError(textBox, "Rg Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCpf(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCpfFFisica.Text))
            {
                errorProviderFornecedorFisica.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedorFisica.SetError(textBox, "Cpf Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private bool validaCelular(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularFFisica.Text))
            {
                errorProviderFornecedorFisica.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedorFisica.SetError(textBox, "Celular Inválido!");
                return false;
            }
        }
        private bool validaCelular2(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCelularFFisica2.Text))
            {
                errorProviderFornecedorFisica.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderFornecedorFisica.SetError(textBox, "Celular Inválido!");
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
        private void ButtonValidarPessoaFisica_Click(object sender, EventArgs e)
        {

        }

        private void buttonDesvalidarFisica_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CancelaCadastradoCliente(typeof(FormFornecedores));
            CancelaCadastradoCliente(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoCliente(typeof(FormCadastroFornecedorFisica));
            CancelaCadastradoCliente(typeof(FormCadastroFornecedorJuridica));
            CancelaCadastradoCliente(typeof(FormCadastroFornecedorJuridica));

            FormCadastroClientes Cliente = new FormCadastroClientes();
            Cliente.MdiParent = this.MdiParent;
            //cpfDados = fisica.getCpf();
            Cliente.Show();
        }
        private void FormCadastroFornecedorFisica_Load(object sender, EventArgs e)
        {
            this.Top = 600;
            this.Left = 0;

            txtRgFisica.MaxLength = 9;
            txtCpfFFisica.MaxLength = 11;
            txtCelularFFisica.MaxLength = 11;
            txtCelularFFisica2.MaxLength = 11;
        }
        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!
     
        public FormCadastroFornecedorFisica(int idCliente, string NOME, string SEXO, string CPF, string RG, string CELULAR, string CELULAR2, String DATANASCIMENTO, Boolean VerificadorEditar)
        {
            InitializeComponent();

            AlteraBotoes(2);

            this.Top = 600;
            this.Left = 0;

            txtRgFisica.MaxLength = 9;
            txtCpfFFisica.MaxLength = 11;
            txtCelularFFisica.MaxLength = 11;
            txtCelularFFisica2.MaxLength = 11;

            IdfornecedorFisica = idCliente;
            txtNomePFisica.Text = NOME;
            comboBoxSexoFFIsica.Text = SEXO;
            txtCpfFFisica.Text = CPF;
            txtRgFisica.Text = RG;
            txtCelularFFisica.Text = CELULAR;
            txtCelularFFisica2.Text = CELULAR2;
            txtDataNascimentoFFisica.Text = DATANASCIMENTO;
            VERIFICADOREDITAR = VerificadorEditar;
        }

        private void ButtonValidarForncedorFisica_Click(object sender, EventArgs e)
        {
            if (VERIFICADOREDITAR == false)
            {
                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

                Conexao conexao = new Conexao(strConexao);
                DALCadastro dal = new DALCadastro(conexao);
                FornecedorFisica fornecedorFisica = new FornecedorFisica();

                if ((validaSexo()) && comboBoxSexoFFIsica.SelectedItem.ToString() == "M")
                {

                    fornecedorFisica.idFornecedorFisica = IdfornecedorFisica;
                    fornecedorFisica.IdFornecedorTipo = 1;
                    fornecedorFisica.Sexo = "M";
                    fornecedorFisica.Cpf = txtCpfFFisica.Text;
                    fornecedorFisica.Rg = txtRgFisica.Text;
                    fornecedorFisica.dataNacimento = txtDataNascimentoFFisica.Text;
                    fornecedorFisica.Celular = txtCelularFFisica.Text;
                    fornecedorFisica.Celular2 = txtCelularFFisica2.Text;
                    fornecedorFisica.Nome = txtNomePFisica.Text;

                    dal.IncluirPessoaFIsica(fornecedorFisica);

                    //Chama Metodo e Fecha todos os formularios abertos
                    FecharTodosFormulario();

                    MessageBox.Show("Fornecedor Cadastrado!");

                    FormFornecedores Fornecedor = new FormFornecedores();
                    Fornecedor.MdiParent = FormFornecedores.ActiveForm;
                    Fornecedor.Show();
                    Fornecedor.Top = 0;
                    Fornecedor.Left = 0;

                }
                if ((validaSexo()) && comboBoxSexoFFIsica.SelectedItem.ToString() == "F")
                {
                    fornecedorFisica.idFornecedorFisica = IdfornecedorFisica;
                    fornecedorFisica.IdFornecedorTipo = 1;
                    fornecedorFisica.Sexo = "F";
                    fornecedorFisica.Cpf = txtCpfFFisica.Text;
                    fornecedorFisica.Rg = txtRgFisica.Text;
                    fornecedorFisica.dataNacimento = txtDataNascimentoFFisica.Text;
                    fornecedorFisica.Celular = txtCelularFFisica.Text;
                    fornecedorFisica.Celular2 = txtCelularFFisica2.Text;
                    fornecedorFisica.Nome = txtNomePFisica.Text;

                    dal.IncluirPessoaFIsica(fornecedorFisica);

                    //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS
                    FecharTodosFormulario();

                    FormFornecedores Fornecedores = new FormFornecedores();
                    Fornecedores.MdiParent = FormFornecedores.ActiveForm;
                    Fornecedores.Show();
                    Fornecedores.Top = 0;
                    Fornecedores.Left = 0;



                    /*
                    FormCadastroClientesFisica fisica = new FormCadastroClientesFisica();
                    fisica.MdiParent = this.MdiParent;

                    fisica.Show();
                    */
                }
                if (!validaSexo())
                {

                    MessageBox.Show("Por favor Digite um Sexo Válido!");

                }

            }
            if (VERIFICADOREDITAR == true)
            {

                string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

                Conexao conexao = new Conexao(strConexao);
                DALCadastro dal = new DALCadastro(conexao);
                FornecedorFisica fornecedorFisica = new FornecedorFisica();
                fornecedorFisica.idFornecedorFisica = IdfornecedorFisica;
                fornecedorFisica.Celular = txtCelularFFisica.Text;
                fornecedorFisica.Celular2 = txtCelularFFisica2.Text;

                dal.AlterarFornecedorFIsica(fornecedorFisica);

                //Chama Metodo e Fecha todos os formularios abertos
                FecharTodosFormulario();

                MessageBox.Show("As Alterações do fornecedor Fisico foram Salvas!");

                FormFornecedores Fornecedor = new FormFornecedores();
                Fornecedor.MdiParent = FormFornecedoresContatos.ActiveForm;
                Fornecedor.Show();
                Fornecedor.Top = 0;
                Fornecedor.Left = 0;


            }
        }

        private void ButtonEditarFornecedorFisica_Click(object sender, EventArgs e)
        {
            AlteraBotoes(3);
        }

        private void buttonDesvalidarFisica_Click_1(object sender, EventArgs e)
        {
            //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS
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
    }
}