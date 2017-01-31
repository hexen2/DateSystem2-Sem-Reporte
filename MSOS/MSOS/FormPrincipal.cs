using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSOS
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sistemaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String S = "Desenvolvido por Hexen Alvares! \n " + "Ano de 2016 \n" + " Versão 1.0 :)";
            MessageBox.Show(S, "Agradeço a Todos pelo o Apoio!");

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void desenvolvimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String S = "Desenvolvido por Hexen Alvares! \n " + "Ano de 2016 \n" + " Versão 1.0 :)";
            MessageBox.Show(S, "Agradeço a Todos pelo o Apoio!");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!
        public static void FechatodosOsFormularios(Type frmType)
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
            FechatodosOsFormularios(typeof(FormCadastroClientes));
            FechatodosOsFormularios(typeof(FormCadastroClienteFisica));
            FechatodosOsFormularios(typeof(FormCadastroClientesJuridico));
            FechatodosOsFormularios(typeof(FormClientesContatos));
            FechatodosOsFormularios(typeof(FormFornecedores));
            FechatodosOsFormularios(typeof(FormCadastroFornecedorFisica));
            FechatodosOsFormularios(typeof(FormCadastroFornecedorJuridica));
            FechatodosOsFormularios(typeof(FormFornecedoresContatos));
            FechatodosOsFormularios(typeof(FormCadastroFuncionario));
            FechatodosOsFormularios(typeof(FormCadastroOsNovo));
            FechatodosOsFormularios(typeof(FormOSPesquisa));
            FechatodosOsFormularios(typeof(FormOSPesquisaEditar));
        }

        public void CadastroCliente2()
        {
            FormCadastroClientes FormClientesCadastro = new FormCadastroClientes();
            // Set the Parent Form of the Child window.
            FormClientesCadastro.MdiParent = this;
            // Display the new form.
            FormClientesCadastro.Show();
            FormClientesCadastro.Top = 50;
            FormClientesCadastro.Left = 0;

        }
        public void CadastroClienteFisica()
        {
            FormCadastroClienteFisica CadastroFisica = new FormCadastroClienteFisica();
            // Set the Parent Form of the Child window.
            CadastroFisica.MdiParent = this;
            // Display the new form.
            CadastroFisica.Show();
        }
        public void CadastroClienteJuridico()
        {
            FormCadastroClientesJuridico FormClientesCadastroJuridico = new FormCadastroClientesJuridico();
            // Set the Parent Form of the Child window.
            FormClientesCadastroJuridico.MdiParent = this;
            // Display the new form.
            FormClientesCadastroJuridico.Show();
            FormClientesCadastroJuridico.Visible = false;
        }
        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void teste1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormOSPesquisaEditar Juridica = new FormOSPesquisaEditar(1,3);
            //Juridica.MdiParent = this.MdiParent;
            ////cpfDados = fisica.getCpf();
            //Juridica.Show();
        }

        private void funcionarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormCadastroFuncionario Funcionario = new FormCadastroFuncionario();
            Funcionario.MdiParent = this;
            Funcionario.Show();
            Funcionario.Top = 0;
            Funcionario.Left = 0;
        }

        private void fornecedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormFornecedores Fornecedor = new FormFornecedores();
            Fornecedor.MdiParent = this;
            Fornecedor.Show();
            Fornecedor.Top = 0;
            Fornecedor.Left = 0;
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void contatosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormFornecedoresContatos FornecedorContatos = new FormFornecedoresContatos();
            FornecedorContatos.MdiParent = this;
            FornecedorContatos.Show();
            FornecedorContatos.Top = 0;
            FornecedorContatos.Left = 0;
        }

        private void contatosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormClientesContatos ClientesContatos = new FormClientesContatos();
            ClientesContatos.MdiParent = this;
            ClientesContatos.Show();
            ClientesContatos.Top = 0;
            ClientesContatos.Left = 0;
        }

        private void lançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void osToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormCadastroOsNovo CadastraOs = new FormCadastroOsNovo();
            CadastraOs.MdiParent = this;
            CadastraOs.Show();
            CadastraOs.Top = 0;
            CadastraOs.Left = 0;
        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormOSPesquisa OsPesquisa = new FormOSPesquisa();
            OsPesquisa.MdiParent = this;
            OsPesquisa.Show();
            OsPesquisa.Top = 0;
            OsPesquisa.Left = 0;
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormCadastroClientes FormClientesCadastro = new FormCadastroClientes();
            // Set the Parent Form of the Child window.
            FormClientesCadastro.MdiParent = this;
            // Display the new form.
            FormClientesCadastro.Show();
            FormClientesCadastro.Top = 0;
            FormClientesCadastro.Left = 0;
        }

        private void pesquisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            FormCadastroClientes FormClientesCadastro = new FormCadastroClientes();
            // Set the Parent Form of the Child window.
            FormClientesCadastro.MdiParent = this;
            // Display the new form.
            FormClientesCadastro.Show();
            FormClientesCadastro.Top = 0;
            FormClientesCadastro.Left = 0;
        }
    }
}
