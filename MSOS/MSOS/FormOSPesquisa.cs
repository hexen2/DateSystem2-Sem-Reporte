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
    public partial class FormOSPesquisa : Form
    {
        DataTable Table;
        private int ID_OS = 0;
        public int IdOs
        {
            get
            {
                return this.ID_OS;

            }
            set
            {
                this.ID_OS = value;
            }
        }
        public int ID_FUNCIONARIO = 0;
        public int IdFuncionario
        {
            get
            {
                return this.ID_FUNCIONARIO;

            }
            set
            {
                this.ID_FUNCIONARIO = value;
            }
        }
        public int ID_CONTATO = 0;
        public int IdContato
        {
            get
            {
                return this.ID_CONTATO;

            }
            set
            {
                this.ID_CONTATO = value;
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
        private int ID_ORDEM_SERVICO = 0;
        public int IdOrdemServico
        {
            get
            {
                return this.ID_ORDEM_SERVICO;

            }
            set
            {
                this.ID_ORDEM_SERVICO = value;
            }
        }
        private int id = 0;
        private int idEstado = 0;

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
        public FormOSPesquisa()
        {
            InitializeComponent();
        }

        private void radioButtonPequisaMS_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMSOs.Enabled = true;
            txtPesquisaNomeOs.Enabled = false;
            txtDataSolicitacao.Enabled = false;
            txtDataSolicitacao2.Enabled = false;
            panelEstado.Enabled = true;
            checkBoxTodos.Checked = true;
            checkBoxOs.Enabled = false;
            checkBoxOs.Checked = false;
            txtOrdemServico.Enabled = false;

            txtPesquisaNomeOs.Clear();
            txtPesquisaMSOs.Clear();
            txtOrdemServico.Clear();
        }

        private void radioButtonPesquisaNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMSOs.Enabled = false;
            txtPesquisaNomeOs.Enabled = true;
            txtDataSolicitacao.Enabled = false;
            txtDataSolicitacao2.Enabled = false;
            panelEstado.Enabled = true;
            panelEstado.Enabled = true;
            checkBoxTodos.Checked = true;
            checkBoxOs.Enabled = false;
            checkBoxOs.Checked = false;
            txtOrdemServico.Enabled = false;
            txtPesquisaNomeOs.Clear();
            txtPesquisaMSOs.Clear();
            txtOrdemServico.Clear();
        }

        private void radioButtonPesquisaData_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMSOs.Enabled = false;
            txtPesquisaNomeOs.Enabled = false;
            txtDataSolicitacao.Enabled = true;
            txtDataSolicitacao2.Enabled = true;
            panelEstado.Enabled = true;
            checkBoxTodos.Checked = false;
            checkBoxOs.Enabled = false;
            checkBoxOs.Checked = false;
            txtOrdemServico.Enabled = false;
            txtPesquisaNomeOs.Clear();
            txtPesquisaMSOs.Clear();
            txtOrdemServico.Clear();
        }

        private void buttonPesquisaOS_Click(object sender, EventArgs e)
        {
            radioButtonPequisaMS.Enabled = true;
            radioButtonPesquisaNome.Enabled = true;
            radioButtonPesquisaData.Enabled = true;
            buttonPesquisaCliente.Enabled = true;
            radioButtonTodosClientes.Enabled = true;
        }
        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!
        public static void CancelaCadastradoOs(Type frmType)
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
            CancelaCadastradoOs(typeof(FormOSPesquisa));
        }
        public void FecharFormOSPesquisaEditar()
        {
            CancelaCadastradoOs(typeof(FormOSPesquisaEditar));
        }

        private void buttonFecharOs_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }

        private void buttonCancelarOs_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormOSPesquisa cadastracliente = new FormOSPesquisa();
            cadastracliente.MdiParent = FormOSPesquisa.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }
        private void FormOSPesquisa_Load(object sender, EventArgs e)
        {
            txtDataSolicitacao.Value = DateTime.Now;
            txtDataSolicitacao2.Value = DateTime.Now;

            //PESQUISA TODAS AS OS CADASTRADA

            txtDataSolicitacao.Value.DayOfWeek.ToString();
            txtDataSolicitacao2.Value.DayOfWeek.ToString();

            txtPesquisaMSOs.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaMSOs.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaMSOs.AutoCompleteCustomSource = FormOSPesquisa.LoadAutoCompleteMsOs();

            txtPesquisaNomeOs.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaNomeOs.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaNomeOs.AutoCompleteCustomSource = FormOSPesquisa.LoadAutoCompleteNomeOs();

            txtOrdemServico.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtOrdemServico.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOrdemServico.AutoCompleteCustomSource = FormOSPesquisa.LoadAutoCompleteOs();
        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra Cliente campos
            {

            }
            if (op == 2)//salvar Cadastro de Cliente
            {
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = false;
                buttonFecharOs.Enabled = true;


            }
            if (op == 3)//Calcelar Cadastro de Cliente
            {
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = false;
                buttonFecharOs.Enabled = true;



            }
            if (op == 4) //  Editar Cadastro de Cliente
            {
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = true;
                buttonFecharOs.Enabled = true;


            }
            if (op == 5)//Cancela Pesquisa
            {

                radioButtonOculto.Checked = true;
                radioButtonPequisaMS.Enabled = false;
                radioButtonPesquisaNome.Enabled = false;
            }
            if (op == 6)//Pesquisa Com suscesso!
            {
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = true;
                buttonFecharOs.Enabled = true;
            }
            if (op == 7)//Botão Verificar informações Passadas
            {

            }
            if (op == 8)//Libera Pessoa Fisica e Juridica!
            {

            }
            if (op == 9)//Libera Pesquisa Por MS e Nome.
            {
                buttonCancelarOs.Enabled = true;
                buttonFecharOs.Enabled = true;

            }
            if (op == 10)//limpa textos
            {

            }

        }
        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR NOME
        public static DataTable LoadDataTableNomeOs()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaNomeOs ";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }
        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA NOME
        public static AutoCompleteStringCollection LoadAutoCompleteNomeOs()
        {
            DataTable dt = LoadDataTableNomeOs();

            AutoCompleteStringCollection stringMS = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringMS.Add(Convert.ToString(row["NOME"]));
            }

            return stringMS;
        }
        //METODO QUE SELECIONA MS NO SQL ORDERNADO POR MS
        public static DataTable LoadDataTableMsOs()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaMsOs ";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }
        //METODO QUE SELECIONA OS NO SQL ORDERNADO POR NOME
        public static DataTable LoadDataTableOs()
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "EXEC ConsultaOs ";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command = new SqlCommand(sql, connection);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connection.Close();

            return dt;
        }
        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA NOME
        public static AutoCompleteStringCollection LoadAutoCompleteOs()
        {
            DataTable dt = LoadDataTableOs();

            AutoCompleteStringCollection stringOS = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringOS.Add(Convert.ToString(row["OS"]));
            }

            return stringOS;
        }
        //METODO STATIC QUE FAZ A COLEÇÃO DE DADOS DA STRING DA MS
        public static AutoCompleteStringCollection LoadAutoCompleteMsOs()
        {
            DataTable dt = LoadDataTableMsOs();

            AutoCompleteStringCollection stringMS = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringMS.Add(Convert.ToString(row["MS"]));
            }

            return stringMS;
        }

         
        public int Verificador(int Aberto, int Processo, int Fechado)
        {

            int soma = 0;

            soma = Aberto + Processo + Fechado + soma;

            return soma;
        }
        public int Verificador1(int Todos)
        {

            int soma = 0;

            soma = Todos + soma;

            return soma;
        }
        public int Verificador2(int Os)
        {

            int soma = 0;

            soma = Os + soma;

            return soma;
        }
        private void buttonPesquisaCliente_Click(object sender, EventArgs e)
        {
            int Aberto = 0;
            int Processo = 0;
            int Fechado = 0;
            int Todos = 0;
            int OS = 0;
            if (checkBoxTodos.Checked == true)
            {
                Todos = 1;
            }
            if (checkBoxEstadoA.Checked == true)
            {
                Aberto = 1;
            }
            if (checkBoxEstadoP.Checked == true)
            {
                Processo = 2;
            }
            if (checkBoxEstadoF.Checked == true)
            {
                Fechado = 3;
            }
            if (checkBoxOs.Checked == true)
            {
                OS = 1;
            }
            Verificador1(Todos);
            Verificador(Aberto, Processo, Fechado);

            int operadorA = Verificador1(Todos);
            int operadorB = Verificador(Aberto, Processo, Fechado);
            int operadorC = Verificador2(OS);
            int operadorAB = Verificador(Aberto, Processo, Fechado) + Verificador1(Todos);

            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
            SqlConnection conn = new SqlConnection(connectionString);

            if (!(radioButtonTodosClientes.Checked == true) && !(radioButtonPequisaMS.Checked == true) && !(radioButtonPesquisaNome.Checked == true) &&
                !(radioButtonPesquisaData.Checked == true))
            {
                MessageBox.Show("Seleciona um modo de busca, por MS , Nome , Período de Data!");
            }

            else if (radioButtonTodosClientes.Checked)
            {
                dataGridViewPesquisa.Columns.Clear();
                dataGridViewPesquisa.Refresh();

                if (operadorA == 1 && operadorB == 0)
                {
                    //SELECIONA POR TODOS OS 
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaOstodos; ", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();
                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewPesquisa.DataSource == null)
                        {
                            dataGridViewPesquisa.Refresh();
                        }
                        if (!(dataGridViewPesquisa.DataSource == null))
                        {
                            dataGridViewPesquisa.Columns.Clear();
                            dataGridViewPesquisa.Refresh();
                        }
                        MessageBox.Show("Nem um Registro de OS Achado!");

                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        conn.Close();
                        SqlConnection conn1 = new SqlConnection(connectionString);
                        string sql = "exec ConsultaOstodos";
                        SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                        DataTable ds2 = new DataTable();
                        sda.Fill(ds2);
                        dataGridViewPesquisa.DataSource = ds2;
                        label8.Text = dataGridViewPesquisa.RowCount.ToString();
                        conn1.Close();
                    }
                }
                if (operadorC == 1)
                {
                    if (txtOrdemServico.Text == "")
                    {
                        if (dataGridViewPesquisa.DataSource == null)
                        {
                            dataGridViewPesquisa.Refresh();
                        }
                        if (!(dataGridViewPesquisa.DataSource == null))
                        {
                            dataGridViewPesquisa.Columns.Clear();
                            dataGridViewPesquisa.Refresh();
                        }
                        MessageBox.Show("A os não pode esta em Branco!");
                    }
                    if (!(txtOrdemServico.Text == ""))
                    {
                        int OS1 = int.Parse(txtOrdemServico.Text);

                        //SELECIONA POR TODOS OS 
                        SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaOstxt " + OS1 + "; ", conn);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);

                        conn.Open();

                        if (!(ds1.Tables[0].Rows.Count > 0))
                        {
                            if (dataGridViewPesquisa.DataSource == null)
                            {
                                dataGridViewPesquisa.Refresh();
                            }
                            if (!(dataGridViewPesquisa.DataSource == null))
                            {
                                dataGridViewPesquisa.Columns.Clear();
                                dataGridViewPesquisa.Refresh();
                            }

                            MessageBox.Show("Nem um Registro de OS Achado!");

                            conn.Close();
                        }
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            string sql = "EXEC ConsultaOstxt " + OS1 + "; ";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                            DataTable ds2 = new DataTable();
                            sda.Fill(ds2);
                            dataGridViewPesquisa.DataSource = ds2;
                            label8.Text = dataGridViewPesquisa.RowCount.ToString();
                            conn1.Close();
                        }
                    }
                }
                //Só Pode escolher todos em chexbox não mas nem um!
                if (operadorA == 1 && operadorB > 0)
                {
                    //SELECIONA POR TODOS OS 
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaOstodostxt " + Aberto + "," + Processo + "," + Fechado + ";", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();
                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewPesquisa.DataSource == null)
                        {
                            dataGridViewPesquisa.Refresh();
                        }
                        if (!(dataGridViewPesquisa.DataSource == null))
                        {
                            dataGridViewPesquisa.Columns.Clear();
                            dataGridViewPesquisa.Refresh();
                        }
                        MessageBox.Show("Nem um Registro de OS Achado!");
                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        conn.Close();
                        SqlConnection conn1 = new SqlConnection(connectionString);
                        string sql = "EXEC ConsultaOstodostxt " + Aberto + "," + Processo + "," + Fechado + ";";
                        SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                        DataTable ds2 = new DataTable();
                        sda.Fill(ds2);
                        dataGridViewPesquisa.DataSource = ds2;
                        label8.Text = dataGridViewPesquisa.RowCount.ToString();
                        conn1.Close();
                    }
                }
                if (operadorA == 0 && operadorB > 0)
                {
                    //SELECIONA POR TODOS OS 
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaOstodostxt " + Aberto + "," + Processo + "," + Fechado + ";", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();
                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        MessageBox.Show("Nem um Registro de OS Achado!");
                        dataGridViewPesquisa.Refresh();
                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        conn.Close();
                        SqlConnection conn1 = new SqlConnection(connectionString);
                        string sql = "EXEC ConsultaOstodostxt " + Aberto + "," + Processo + "," + Fechado + ";";
                        SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                        DataTable ds2 = new DataTable();
                        sda.Fill(ds2);
                        dataGridViewPesquisa.DataSource = ds2;
                        label8.Text = dataGridViewPesquisa.RowCount.ToString();
                        conn1.Close();
                    }
                }
                if (operadorA == 0 && operadorB > 0)
                {
                    //SELECIONA POR TODOS OS 
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaOstodostxt " + Aberto + "," + Processo + "," + Fechado + ";", conn);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();
                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        if (dataGridViewPesquisa.DataSource == null)
                        {
                            dataGridViewPesquisa.Refresh();
                        }
                        if (!(dataGridViewPesquisa.DataSource == null))
                        {
                            dataGridViewPesquisa.Columns.Clear();
                            dataGridViewPesquisa.Refresh();
                        }
                        MessageBox.Show("Nem um Registro de OS Achado!");
                        conn.Close();
                    }
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        conn.Close();
                        SqlConnection conn1 = new SqlConnection(connectionString);
                        string sql = "EXEC ConsultaOstodostxt " + Aberto + "," + Processo + "," + Fechado + ";";
                        SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                        DataTable ds2 = new DataTable();
                        sda.Fill(ds2);
                        dataGridViewPesquisa.DataSource = ds2;
                        label8.Text = dataGridViewPesquisa.RowCount.ToString();
                        conn1.Close();
                    }
                }
                if (operadorA == 0 && operadorB == 0 && operadorC == 0)
                {
                    MessageBox.Show("Por Favor Seleciona A ESCOLHA A ou alguma opção de ESCOLHA B!");
                }
            }
            if (radioButtonPequisaMS.Checked)
            {
                if (txtPesquisaMSOs.Text == "")
                {
                    dataGridViewPesquisa.Columns.Clear();
                    dataGridViewPesquisa.Refresh();
                    MessageBox.Show("O Ms não pode esta em Branco!");
                }
                if (!(txtPesquisaMSOs.Text == ""))
                {
                    int MS = int.Parse(txtPesquisaMSOs.Text);

                    if (operadorA == 1 && operadorB == 0)
                    {
                        //SELECIONA POR TODOS OS 
                        SqlDataAdapter da1 = new SqlDataAdapter("exec ConsultaMsOstxt " + MS + ",1,2,3", conn);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);

                        conn.Open();

                        if (!(ds1.Tables[0].Rows.Count > 0))
                        {
                            if (dataGridViewPesquisa.DataSource == null)
                            {
                                dataGridViewPesquisa.Refresh();
                            }
                            if (!(dataGridViewPesquisa.DataSource == null))
                            {
                                dataGridViewPesquisa.Columns.Clear();
                                dataGridViewPesquisa.Refresh();
                            }
                            MessageBox.Show("Nem um Registro de OS Achado!");
                            conn.Close();
                        }
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            string sql = "exec ConsultaMsOstxt " + MS + ",1,2,3";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                            DataTable ds2 = new DataTable();
                            sda.Fill(ds2);
                            dataGridViewPesquisa.DataSource = ds2;
                            label8.Text = dataGridViewPesquisa.RowCount.ToString();
                            conn1.Close();
                        }
                    }
                    //Só Pode escolher todos em chexbox não mas nem um!
                    if (operadorA == 1 && operadorB > 0)
                    {
                        //SELECIONA POR TODOS OS 
                        SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaMsOstxt " + MS + "," + Aberto + "," + Processo + "," + Fechado + ";", conn);
                        DataSet ds1 = new DataSet();
                        da2.Fill(ds1);

                        conn.Open();

                        if (!(ds1.Tables[0].Rows.Count > 0))
                        {
                            if (dataGridViewPesquisa.DataSource == null)
                            {
                                dataGridViewPesquisa.Refresh();
                            }
                            if (!(dataGridViewPesquisa.DataSource == null))
                            {
                                dataGridViewPesquisa.Columns.Clear();
                                dataGridViewPesquisa.Refresh();
                            }
                            MessageBox.Show("Nem um Registro de OS Achado!");

                            conn.Close();
                        }
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            string sql = "EXEC ConsultaMsOstxt " + MS + "," + Aberto + "," + Processo + "," + Fechado + ";";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                            DataTable ds2 = new DataTable();
                            sda.Fill(ds2);
                            dataGridViewPesquisa.DataSource = ds2;
                            label8.Text = dataGridViewPesquisa.RowCount.ToString();
                            conn1.Close();
                        }
                    }
                    if (operadorA == 0 && operadorB == 0)
                    {
                        if (dataGridViewPesquisa.DataSource == null)
                        {
                            dataGridViewPesquisa.Refresh();
                        }
                        if (!(dataGridViewPesquisa.DataSource == null))
                        {
                            dataGridViewPesquisa.Columns.Clear();
                            dataGridViewPesquisa.Refresh();
                        }
                        MessageBox.Show("Por Favor Seleciona pelo menos uma opção!");

                        conn.Close();
                    }
                    if (operadorA == 0 && operadorB > 0)
                    {
                        //SELECIONA POR TODOS OS 
                        SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaMsOstxt " + MS + "," + Aberto + "," + Processo + "," + Fechado + ";", conn);
                        DataSet ds1 = new DataSet();
                        da2.Fill(ds1);

                        conn.Open();

                        if (!(ds1.Tables[0].Rows.Count > 0))
                        {
                            if (dataGridViewPesquisa.DataSource == null)
                            {
                                dataGridViewPesquisa.Refresh();
                            }
                            if (!(dataGridViewPesquisa.DataSource == null))
                            {
                                dataGridViewPesquisa.Columns.Clear();
                                dataGridViewPesquisa.Refresh();
                            }
                            MessageBox.Show("Nem um Registro de OS Achado!");

                            conn.Close();
                        }
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            string sql = "EXEC ConsultaMsOstxt " + MS + "," + Aberto + "," + Processo + "," + Fechado + ";";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                            DataTable ds2 = new DataTable();
                            sda.Fill(ds2);
                            dataGridViewPesquisa.DataSource = ds2;
                            label8.Text = dataGridViewPesquisa.RowCount.ToString();
                            conn1.Close();
                        }
                    }
                }
            }
            if (radioButtonPesquisaNome.Checked)
            {
                if (txtPesquisaNomeOs.Text == "")
                {
                    if (dataGridViewPesquisa.DataSource == null)
                    {
                        dataGridViewPesquisa.Refresh();
                    }
                    if (!(dataGridViewPesquisa.DataSource == null))
                    {
                        dataGridViewPesquisa.Columns.Clear();
                        dataGridViewPesquisa.Refresh();
                    }
                    MessageBox.Show("O Nome não pode esta em Branco!");
                }
                if (!(txtPesquisaNomeOs.Text == ""))
                {
                    if (operadorA == 1 && operadorB == 0)
                    {
                        //SELECIONA POR TODOS OS 
                        SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaNomeOstxt '" + txtPesquisaNomeOs.Text + "',1,2,3 ;", conn);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);

                        conn.Open();

                        if (!(ds1.Tables[0].Rows.Count > 0))
                        {
                            if (dataGridViewPesquisa.DataSource == null)
                            {
                                dataGridViewPesquisa.Refresh();
                            }
                            if (!(dataGridViewPesquisa.DataSource == null))
                            {
                                dataGridViewPesquisa.Columns.Clear();
                                dataGridViewPesquisa.Refresh();
                            }
                            MessageBox.Show("Nem um Registro de OS Achado!");
                            conn.Close();
                        }
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            string sql = "EXEC ConsultaNomeOstxt '" + txtPesquisaNomeOs.Text + "',1,2,3 ;";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                            DataTable ds2 = new DataTable();
                            sda.Fill(ds2);
                            dataGridViewPesquisa.DataSource = ds2;
                            label8.Text = dataGridViewPesquisa.RowCount.ToString();
                            conn1.Close();
                        }
                    }
                    //Só Pode escolher todos em chexbox não mas nem um!
                    if (operadorA == 1 && operadorB > 0)
                    {
                        //SELECIONA POR TODOS OS 
                        SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaNomeOstxt '" + txtPesquisaNomeOs.Text + "'," + Aberto + "," + Processo + "," + Fechado + ";", conn);
                        DataSet ds1 = new DataSet();
                        da2.Fill(ds1);

                        conn.Open();

                        if (!(ds1.Tables[0].Rows.Count > 0))
                        {
                            if (dataGridViewPesquisa.DataSource == null)
                            {
                                dataGridViewPesquisa.Refresh();
                            }
                            if (!(dataGridViewPesquisa.DataSource == null))
                            {
                                dataGridViewPesquisa.Columns.Clear();
                                dataGridViewPesquisa.Refresh();
                            }
                            MessageBox.Show("Nem um Registro de OS Achado!");

                            conn.Close();
                        }
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            string sql = "EXEC ConsultaNomeOstxt '" + txtPesquisaNomeOs.Text + "'," + Aberto + "," + Processo + "," + Fechado + ";";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                            DataTable ds2 = new DataTable();
                            sda.Fill(ds2);
                            dataGridViewPesquisa.DataSource = ds2;
                            label8.Text = dataGridViewPesquisa.RowCount.ToString();
                            conn1.Close();
                        }
                    }
                    if (operadorA == 0 && operadorB == 0)
                    {
                        if (dataGridViewPesquisa.DataSource == null)
                        {
                            dataGridViewPesquisa.Refresh();
                        }
                        if (!(dataGridViewPesquisa.DataSource == null))
                        {
                            dataGridViewPesquisa.Columns.Clear();
                            dataGridViewPesquisa.Refresh();
                        }
                        MessageBox.Show("Por Favor Seleciona pelo menos uma opção!");

                        conn.Close();
                    }
                    if (operadorA == 0 && operadorB > 0)
                    {
                        //SELECIONA POR TODOS OS 
                        SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaNomeOstxt '" + txtPesquisaNomeOs.Text + "," + Aberto + "'," + Processo + "," + Fechado + ";", conn);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);

                        conn.Open();

                        if (!(ds1.Tables[0].Rows.Count > 0))
                        {
                            if (dataGridViewPesquisa.DataSource == null)
                            {
                                dataGridViewPesquisa.Refresh();
                            }
                            if (!(dataGridViewPesquisa.DataSource == null))
                            {
                                dataGridViewPesquisa.Columns.Clear();
                                dataGridViewPesquisa.Refresh();
                            }
                            MessageBox.Show("Nem um Registro de OS Achado!");

                            conn.Close();
                        }
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            string sql = "EXEC ConsultaNomeOstxt '" + txtPesquisaNomeOs.Text + "'," + Aberto + "," + Processo + "," + Fechado + ";";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                            DataTable ds2 = new DataTable();
                            sda.Fill(ds2);
                            dataGridViewPesquisa.DataSource = ds2;
                            label8.Text = dataGridViewPesquisa.RowCount.ToString();
                            conn1.Close();
                        }
                    }
                }
            }
            if (radioButtonPesquisaData.Checked)
            {
                string DataInicial = txtDataSolicitacao.Value.ToShortDateString();

                string DataFinal = txtDataSolicitacao2.Value.ToShortDateString();

                if (txtDataSolicitacao.Value.Date.CompareTo(txtDataSolicitacao2.Value.Date) > 0)
                {
                    if (dataGridViewPesquisa.DataSource == null)
                    {
                        dataGridViewPesquisa.Refresh();
                    }
                    if (!(dataGridViewPesquisa.DataSource == null))
                    {
                        dataGridViewPesquisa.Columns.Clear();
                        dataGridViewPesquisa.Refresh();
                    }
                    MessageBox.Show("Data Inicial não pode Se Maior que Data Final!");
                }
                if (txtDataSolicitacao.Value.Date.CompareTo(txtDataSolicitacao2.Value.Date) <= 0)
                {
                    if (operadorA == 0 && operadorB == 0)
                    {
                        if (dataGridViewPesquisa.DataSource == null)
                        {
                            dataGridViewPesquisa.Refresh();
                        }
                        if (!(dataGridViewPesquisa.DataSource == null))
                        {
                            dataGridViewPesquisa.Columns.Clear();
                            dataGridViewPesquisa.Refresh();
                        }
                        MessageBox.Show("Por Favor Seleciona pelo menos uma opção!");
                        conn.Close();
                    }
                    if (operadorA == 1 && operadorB == 0)
                    {
                        //SELECIONA POR TODOS OS 
                        SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaDataOstxt '" + DataInicial + "','" + DataFinal + "';", conn);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);

                        conn.Open();

                        if (!(ds1.Tables[0].Rows.Count > 0))
                        {
                            if (dataGridViewPesquisa.DataSource == null)
                            {
                                dataGridViewPesquisa.Refresh();
                            }
                            if (!(dataGridViewPesquisa.DataSource == null))
                            {
                                dataGridViewPesquisa.Columns.Clear();
                                dataGridViewPesquisa.Refresh();
                            }
                            MessageBox.Show("Nem um Registro de OS Achado!");
                            conn.Close();
                        }
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            string sql = "EXEC ConsultaDataOstxt '" + DataInicial + "','" + DataFinal + "';";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                            DataTable ds2 = new DataTable();
                            sda.Fill(ds2);
                            dataGridViewPesquisa.DataSource = ds2;
                            label8.Text = dataGridViewPesquisa.RowCount.ToString();
                            conn1.Close();
                        }
                    }
                    if (operadorA == 1 && operadorB > 0)
                    {
                        //SELECIONA POR TODOS OS 
                        SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaDataOsNtxt '" + DataInicial + "','" + DataFinal + "'," + Aberto + "," + Processo + "," + Fechado + ";", conn);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);

                        conn.Open();

                        if (!(ds1.Tables[0].Rows.Count > 0))
                        {
                            if (dataGridViewPesquisa.DataSource == null)
                            {
                                dataGridViewPesquisa.Refresh();
                            }
                            if (!(dataGridViewPesquisa.DataSource == null))
                            {
                                dataGridViewPesquisa.Columns.Clear();
                                dataGridViewPesquisa.Refresh();
                            }
                            MessageBox.Show("Nem um Registro de OS Achado!");
                            conn.Close();
                        }
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            conn.Close();
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            string sql = "EXEC ConsultaDataOsNtxt '" + DataInicial + "','" + DataFinal + "'," + Aberto + "," + Processo + "," + Fechado + ";";
                            SqlDataAdapter sda = new SqlDataAdapter(sql, conn1);
                            DataTable ds2 = new DataTable();
                            sda.Fill(ds2);
                            dataGridViewPesquisa.DataSource = ds2;
                            label8.Text = dataGridViewPesquisa.RowCount.ToString();
                            conn1.Close();
                        }
                    }
                }
            }
        }
        private void radioButtonTodosClientes_CheckedChanged(object sender, EventArgs e)
        {
            panelEstado.Enabled = true;
            txtPesquisaMSOs.Enabled = false;
            txtPesquisaNomeOs.Enabled = false;
            txtDataSolicitacao.Enabled = false;
            txtDataSolicitacao2.Enabled = false;
            radioButtonPequisaMS.Enabled = true;
            radioButtonPesquisaNome.Enabled = true;
            radioButtonPesquisaData.Enabled = true;
            txtDataSolicitacao.Enabled = false;
            txtDataSolicitacao2.Enabled = false;
            checkBoxTodos.Checked = true;
            checkBoxOs.Enabled = true;
            txtPesquisaNomeOs.Clear();
            txtPesquisaMSOs.Clear();
            txtOrdemServico.Clear();
        }

        private void checkBoxOs_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOs.Checked == true)
            {
                txtOrdemServico.Enabled = true;
                checkBoxTodos.Checked = false;
                checkBoxEstadoA.Checked = false;
                checkBoxEstadoP.Checked = false;
                checkBoxEstadoF.Checked = false;
            }
            if (checkBoxOs.Checked == false)
            {
                txtOrdemServico.Enabled = false;
                checkBoxTodos.Checked = false;
                checkBoxEstadoA.Checked = false;
                checkBoxEstadoP.Checked = false;
                checkBoxEstadoF.Checked = false;
                txtOrdemServico.Clear();
            }
        }
        private void dataGridViewPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FecharFormOSPesquisaEditar();

            if (dataGridViewPesquisa.RowCount == 0)
            {
                id = 0;
            }
            if (!(dataGridViewPesquisa.RowCount == 0))
            {
                try
                {
                    id = Convert.ToInt32(dataGridViewPesquisa["ORDEM_SERVIÇO", e.RowIndex].Value);
                    //id = Convert.ToInt32(dataGridViewPesquisa.CurrentRow.Cells[0].Value.ToString());
                    //id = Convert.ToInt32(dataGridViewPesquisa.Rows[e.RowIndex].Cells["ORDEM_SERVIÇO"].Value.ToString());

                    String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                    SqlConnection conn = new SqlConnection(connectionString);
                    string sql = "exec VerificarEstadoOs " + id;
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    String connectionString1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
                    SqlConnection conn1 = new SqlConnection(connectionString1);
                    string sql1 = "exec ConsultaOsEditarTxt " + id;
                    SqlDataAdapter sda1 = new SqlDataAdapter(sql1, conn1);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1);

                    idEstado = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                    string ORDEM_SERVICO = ds1.Tables[0].Rows[0][0].ToString();
                    string SOLICITACAO = ds1.Tables[0].Rows[0][1].ToString();
                    string CLIENTE = ds1.Tables[0].Rows[0][2].ToString();
                    string MS = ds1.Tables[0].Rows[0][5].ToString();
                    string LOGRADOURO = ds1.Tables[0].Rows[0][6].ToString();
                    string ENDERECO = ds1.Tables[0].Rows[0][7].ToString();
                    string COMPLEMENTO = ds1.Tables[0].Rows[0][8].ToString();
                    string NUMERO = ds1.Tables[0].Rows[0][9].ToString();
                    string BAIRRO = ds1.Tables[0].Rows[0][10].ToString();
                    string CIDADE = ds1.Tables[0].Rows[0][11].ToString();
                    string NOME_CONTATO = ds1.Tables[0].Rows[0][12].ToString();
                    string TELEFONE = ds1.Tables[0].Rows[0][13].ToString();
                    string ORIGEM_SERVICO = ds1.Tables[0].Rows[0][14].ToString();
                    string SERVICOS_EXECUTADOS = ds1.Tables[0].Rows[0][15].ToString();
                    string TECNICOS = ds1.Tables[0].Rows[0][16].ToString();
                    string HORARIO_INICIO = ds1.Tables[0].Rows[0][17].ToString();
                    string HORARIO_FINAL = ds1.Tables[0].Rows[0][18].ToString();

                    FormOSPesquisaEditar OSPesquisaE = new FormOSPesquisaEditar(idEstado, ORDEM_SERVICO, SOLICITACAO,CLIENTE, MS, LOGRADOURO, ENDERECO,COMPLEMENTO,
                        NUMERO, BAIRRO, CIDADE, NOME_CONTATO, TELEFONE,ORIGEM_SERVICO,SERVICOS_EXECUTADOS, TECNICOS, HORARIO_INICIO, HORARIO_FINAL);
                    OSPesquisaE.MdiParent = FormOSPesquisaEditar.ActiveForm;
                    OSPesquisaE.Show();
                    //OSPesquisaE.MdiParent = this.MdiParent;
                    //OSPesquisaE.Show();
                    OSPesquisaE.Top = 0;
                    OSPesquisaE.Left = 0;



                }
                catch (Exception ex)
                {
                    ex.ToString();
                }                
            }
        }

        private void txtPesquisaNomeOs_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(Table);
            DV.RowFilter = string.Format("CLIENTE LIKE '%{0}%'", txtPesquisaNomeOs.Text);
            dataGridViewPesquisa.DataSource = DV;
        }

        private void buttonTeste_Click(object sender, EventArgs e)
        {
            string connetionString = ("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command = new SqlCommand("Exec ConsultaNomeOs2txt", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                Table = new DataTable();
                adapter.Fill(Table);
                BindingSource Source = new BindingSource();
                Source.DataSource = Table;
                dataGridViewPesquisa.DataSource = Source;
                adapter.Update(Table);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            DataTable dt = new DataTable();
        }
    }
}
