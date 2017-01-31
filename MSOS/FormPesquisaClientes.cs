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
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;


namespace MSOS
{
    public partial class FormPesquisaClientes : Form
    {
        DataTable TableNome;
        DataTable TableMs;
        DataTable TableTodos;
        private int ID_PESSOA = 0;
        public int IdPessoa
        {
            get
            {
                return this.ID_PESSOA;

            }
            set
            {
                this.ID_PESSOA = value;
            }
        }
        private int ID_PESSOA_TIPO = 0;
        public int IdPessoaTipo
        {
            get
            {
                return this.ID_PESSOA_TIPO;

            }
            set
            {
                this.ID_PESSOA_TIPO = value;
            }
        }


        public FormPesquisaClientes()
        {
            InitializeComponent();
            radioButtonOculto.Checked = true;
        }
        private void FormPesquisaClientes_Load(object sender, EventArgs e)
        {
            
        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra Cliente campos
            {

            }
            if (op == 2)//salvar Cadastro de Cliente
            {



            }
            if (op == 3)//Calcelar Cadastro de Cliente
            {

            }
            if (op == 4) //  Editar Cadastro de Cliente
            {

            }
            if (op == 5)//Cancela Pesquisa
            {
                txtPesquisaMsCliente.Enabled = false;
                txtPesquisaNomeCliente.Enabled = false;
                buttonPesquisaCliente.Enabled = false;
                radioButtonOculto.Checked = true;

                radioButtonPesquisarNome.Enabled = false;

            }
            if (op == 6)//Pesquisa Com suscesso!
            {

            }
            if (op == 7)//Botão Verificar informações Passadas
            {

            }
            if (op == 8)//Libera Pessoa Fisica e Juridica!
            {

            }
            if (op == 9)//Libera Pesquisa Por MS e Nome.
            {

                radioButtonPesquisarNome.Enabled = true;
                buttonPesquisaCliente.Enabled = true;

            }
            if (op == 10)//limpa textos
            {
                txtPesquisaMsCliente.Clear();
                txtPesquisaNomeCliente.Clear();
            }

        }
        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!
        public static void CancelaPesquisaCliente(Type frmType)
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
            CancelaPesquisaCliente(typeof(FormPesquisaClientes));
        }
        public void FecharCadastroCliente()
        {
            CancelaPesquisaCliente(typeof(FormPesquisaClientesEditar));
        }
        private void buttonPesquisaCliente_Click(object sender, EventArgs e)
        {
            int situacao = 0;

            if(checkBoxSituacao.Checked == true)
            {
                situacao = 1;
            }
            if (checkBoxSituacao.Checked == false)
            {
                situacao = 2;
            }

            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
            SqlConnection conn = new SqlConnection(connectionString);

            if (!(radioButtonPesquisarMS.Checked == true) && !(radioButtonPesquisarNome.Checked == true) && !(radioButtonTodos.Checked == true))
            {
                MessageBox.Show("Seleciona um modo de busca, por MS ou Nome ");
            }
            if (radioButtonTodos.Checked)
            {

               // dataGridViewPesquisaCliente.Columns.Clear();
                dataGridViewPesquisaCliente.Refresh();

                label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();


                //SELECIONA POR TODOS OS 
                SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaTodosCliente " + situacao, conn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                conn.Open();

                if (!(ds1.Tables[0].Rows.Count > 0))
                {
                    if (dataGridViewPesquisaCliente.DataSource == null)
                    {
                        dataGridViewPesquisaCliente.Refresh();
                    }
                    if (!(dataGridViewPesquisaCliente.DataSource == null))
                    {
                       // dataGridViewPesquisaCliente.Columns.Clear();
                        dataGridViewPesquisaCliente.Refresh();
                    }
                    label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();

                    MessageBox.Show("Nem um Registro de MS Achado!");
                    conn.Close();
                }
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    conn.Close();

                    dataGridViewPesquisaTodos();
                    label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();
                }
                
            }
            if (radioButtonPesquisarMS.Checked)
            {
                if (txtPesquisaMsCliente.Text == "")
                {
                    //dataGridViewPesquisaCliente.Columns.Clear();
                    dataGridViewPesquisaCliente.Refresh();

                    label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();

                    MessageBox.Show("O Ms não pode esta em Branco!");
                }
                if (!(txtPesquisaMsCliente.Text == ""))
                {
                    //SELECIONA POR TODOS OS 
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaPessoaMsClienteTxt '" + txtPesquisaMsCliente.Text + "',"+situacao+";", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewPesquisaCliente.DataSource == null)
                        {
                            dataGridViewPesquisaCliente.Refresh();
                        }
                        if (!(dataGridViewPesquisaCliente.DataSource == null))
                        {
                            //dataGridViewPesquisaCliente.Columns.Clear();
                            dataGridViewPesquisaCliente.Refresh();
                        }
                        label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();

                        MessageBox.Show("Nem um Registro de MS Achado!");
                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        conn.Close();

                        dataGridViewPesquisaMS();
                        label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();
                    }
                }
            }
            if (radioButtonPesquisarNome.Checked)
            {
                if (txtPesquisaNomeCliente.Text == "")
                {
                    //dataGridViewPesquisaCliente.Columns.Clear();
                    dataGridViewPesquisaCliente.Refresh();

                    label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();

                    MessageBox.Show("O Ms não pode esta em Branco!");
                }
                if (!(txtPesquisaNomeCliente.Text == ""))
                {
                    //SELECIONA POR TODOS OS 
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaPessoaClienteNomeTxt '" + txtPesquisaNomeCliente.Text + "'," + situacao + ";", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewPesquisaCliente.DataSource == null)
                        {
                            dataGridViewPesquisaCliente.Refresh();
                        }
                        if (!(dataGridViewPesquisaCliente.DataSource == null))
                        {
                           // dataGridViewPesquisaCliente.Columns.Clear();
                            dataGridViewPesquisaCliente.Refresh();
                        }
                        label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();

                        MessageBox.Show("Nem um Registro de nome Achado!");
                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        conn.Close();

                        dataGridViewPesquisaNome();
                        label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();
                    }
                }
            }
        }
        void dataGridViewPesquisaTodos()
        {
            int situacao = 0;

            if (checkBoxSituacao.Checked == true)
            {
                situacao = 1;
            }
            if (checkBoxSituacao.Checked == false)
            {
                situacao = 2;
            }
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command = new SqlCommand("Exec ConsultaTodosCliente "+situacao+";", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                TableTodos = new DataTable();
                adapter.Fill(TableTodos);
                BindingSource Source = new BindingSource();
                Source.DataSource = TableTodos;
                dataGridViewPesquisaCliente.DataSource = Source;
                adapter.Update(TableTodos);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            //DataTable dt = new DataTable();
        }
        void dataGridViewPesquisaMS()
        {
            int situacao = 0;

            if (checkBoxSituacao.Checked == true)
            {
                situacao = 1;
            }
            if (checkBoxSituacao.Checked == false)
            {
                situacao = 2;
            }
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command = new SqlCommand("Exec ConsultaPessoaMsClienteTxt '"+ txtPesquisaMsCliente.Text + "'," + situacao + ";", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                TableMs = new DataTable();
                adapter.Fill(TableMs);
                BindingSource Source = new BindingSource();
                Source.DataSource = TableMs;
                dataGridViewPesquisaCliente.DataSource = Source;
                adapter.Update(TableMs);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            //DataTable dt = new DataTable();
        }
        void dataGridViewPesquisaNome()
        {
            int situacao = 0;

            if (checkBoxSituacao.Checked == true)
            {
                situacao = 1;
            }
            if (checkBoxSituacao.Checked == false)
            {
                situacao = 2;
            }
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command = new SqlCommand("Exec ConsultaPessoaClienteNomeTxt '" +txtPesquisaNomeCliente.Text+ "'," + situacao + ";", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                TableNome = new DataTable();
                adapter.Fill(TableNome);
                BindingSource Source = new BindingSource();
                Source.DataSource = TableNome;
                dataGridViewPesquisaCliente.DataSource = Source;
                adapter.Update(TableNome);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            //DataTable dt = new DataTable();
        }
        private void radioButtonPesquisarNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMsCliente.Enabled = false;
            txtPesquisaNomeCliente.Enabled = true;
            txtPesquisaMsCliente.Clear();
            txtPesquisaNomeCliente.Clear();
            AlteraBotoes(10);
        }

        private void radioButtonPesquisarMS_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMsCliente.Enabled = true;
            txtPesquisaNomeCliente.Enabled = false;
            txtPesquisaMsCliente.Clear();
            txtPesquisaNomeCliente.Clear();
            AlteraBotoes(10);
        }

        private void buttonCancelarOs_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormPesquisaClientes cadastracliente = new FormPesquisaClientes();
            cadastracliente.MdiParent = FormPesquisaClientes.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }

        private void buttonFecharOs_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMsCliente.Enabled = false;
            txtPesquisaNomeCliente.Enabled = false;
            txtPesquisaMsCliente.Clear();
            txtPesquisaNomeCliente.Clear();
        }

        private void dataGridViewPesquisaCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // FecharCadastroCliente();

            if (dataGridViewPesquisaCliente.RowCount == 0)
            {
                IdPessoa = 0;
            }
            if (!(dataGridViewPesquisaCliente.RowCount == 0))
            {
                try
                {
                    IdPessoa = Convert.ToInt32(dataGridViewPesquisaCliente["ID_PESSOA1", e.RowIndex].Value);
                    FormPesquisaClientesEditar ClientePesquisaE = new FormPesquisaClientesEditar(IdPessoa);
                    ClientePesquisaE.MdiParent = FormPesquisaClientesEditar.ActiveForm;
                    ClientePesquisaE.Show();
                    //OSPesquisaE.MdiParent = this.MdiParent;
                    //OSPesquisaE.Show();
                    ClientePesquisaE.Top = 0;
                    ClientePesquisaE.Left = 0;

                    //FormPesquisaClientesEditar ClientePesquisaE = new FormPesquisaClientesEditar();
                    //ClientePesquisaE.MdiParent = FormPesquisaClientesEditar.ActiveForm;
                    //ClientePesquisaE.Show();
                    ////OSPesquisaE.MdiParent = this.MdiParent;
                    ////OSPesquisaE.Show();
                    //ClientePesquisaE.Top = 0;
                    //ClientePesquisaE.Left = 0;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void txtPesquisaMsCliente_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TableMs);
            DV.RowFilter = string.Format("MS LIKE '%{0}%'", txtPesquisaMsCliente.Text);
            dataGridViewPesquisaCliente.DataSource = DV;
            label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();
        }

        private void txtPesquisaNomeCliente_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(TableNome);
            DV.RowFilter = string.Format("CLIENTE LIKE '%{0}%'", txtPesquisaNomeCliente.Text);
            dataGridViewPesquisaCliente.DataSource = DV;
            label8.Text = dataGridViewPesquisaCliente.RowCount.ToString();
        }

        private void buttonLimpaOs_Click(object sender, EventArgs e)
        {

        }
    }
}
