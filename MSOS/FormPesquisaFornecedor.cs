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
    public partial class FormPesquisaFornecedor : Form
    {
        public FormPesquisaFornecedor()
        {
            InitializeComponent();
        }

        private void buttonFornecedorPesquisa_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelarOs_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormPesquisaFornecedor cadastraFornecedor = new FormPesquisaFornecedor();
            cadastraFornecedor.MdiParent = FormOSPesquisa.ActiveForm;
            cadastraFornecedor.Show();
            cadastraFornecedor.Top = 0;
            cadastraFornecedor.Left = 0;
        }

        private void FormPesquisaFornecedor_Load(object sender, EventArgs e)
        {

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
            CancelaCadastradoCliente(typeof(FormPesquisaFornecedor));
        }

        private void buttonFecharOs_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }
    }
}
