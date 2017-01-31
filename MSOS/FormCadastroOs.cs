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
using System.Globalization;

namespace MSOS
{
    public partial class FormCadastroOsNovo : Form
    {
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
        private string operacao = "";
        public FormCadastroOsNovo()
        {
            InitializeComponent();


            //Pesquisa de MS e Nome para Cadastro de OS

            txtPesquisaMSCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaMSCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaMSCliente.AutoCompleteCustomSource = FormCadastroClientes.LoadAutoCompleteMSCliente();

            txtPesquisaNomeCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaNomeCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaNomeCliente.AutoCompleteCustomSource = FormCadastroClientes.LoadAutoCompleteNomeCliente();

            txtOrigemChamado.MaxLength = 400;
            txtservicoexecutados.MaxLength = 400;

        }


        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeOS.Text))
            {
                errorProviderOs.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderOs.SetError(textBox, "Nome Inválido!");
                return false;
            }

        }

        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra Cliente campos
            {
                panel1.Enabled = true;
                panel2.Enabled = false;
                panel4.Enabled = true;
                panel6.Enabled = true;


                buttonCadastraOs.Enabled = false;


                buttonVerifica.Enabled = true;
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = true;
                buttonFecharOs.Enabled = true;



            }
            if (op == 2)//salvar Cadastro de Cliente
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
                panel4.Enabled = false;
                panel5.Enabled = false;
                panel6.Enabled = false;

                buttonCadastraOs.Enabled = true;


                buttonVerifica.Enabled = false;
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = false;
                buttonFecharOs.Enabled = true;


            }
            if (op == 3)//Calcelar Cadastro de Cliente
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Enabled = false;
                panel4.Enabled = false;
                panel5.Enabled = false;
                panel6.Enabled = false;

                buttonCadastraOs.Enabled = true;

                buttonVerifica.Enabled = false;
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = false;
                buttonFecharOs.Enabled = true;



            }
            if (op == 4) //  Editar Cadastro de Cliente
            {
                txtMsOs.Enabled = false;

                buttonCadastraOs.Enabled = false;

                buttonVerifica.Enabled = true;
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = true;
                buttonFecharOs.Enabled = true;


            }
            if (op == 5)//Cancela Pesquisa
            {
                txtPesquisaMSCliente.Enabled = false;
                txtPesquisaNomeCliente.Enabled = false;
                buttonPesquisaCliente.Enabled = false;
                radioButtonOculto.Checked = true;
                radioButtonPequisaMS.Enabled = false;
                radioButtonPesquisaNome.Enabled = false;
            }
            if (op == 6)//Pesquisa Com suscesso!
            {
                buttonCadastraOs.Enabled = false;


                buttonVerifica.Enabled = false;
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = true;
                buttonFecharOs.Enabled = true;
            }
            if (op == 7)//Botão Verificar informações Passadas
            {

                txtNomeOS.Enabled = false;
                txtMsOs.Enabled = false;

                txtTipo_logradouro.Enabled = false;
                txtBairroOS.Enabled = false;
                txtBairroNumero.Enabled = false;

                txtTelefoneOs.Enabled = false;

                txtEnderecoOS.Enabled = false;


            }
            if (op == 8)//Libera Pessoa Fisica e Juridica!
            {
                panel1.Enabled = true;
                panel2.Enabled = false;
                panel4.Enabled = true;
                panel6.Enabled = true;


                buttonCadastraOs.Enabled = false;


                buttonVerifica.Enabled = true;
                buttonLimpaOs.Enabled = false;
                buttonCancelarOs.Enabled = true;
                buttonFecharOs.Enabled = true;
            }
            if (op == 9)//Libera Pesquisa Por MS e Nome.
            {

                buttonCadastraOs.Enabled = false;

                buttonCancelarOs.Enabled = true;
                buttonFecharOs.Enabled = true;

            }
            if (op == 10)//limpa textos
            {
                txtMsOs.Clear();
                txtNomeOS.Clear();
                txtEnderecoOS.Clear();
                txtTelefoneOs.Clear();
                txtTipo_logradouro.Clear();
                txtEnderecoOS.Clear();
                txtBairroNumero.Clear();
                txtBairroOS.Clear();
                comboBoxContato.Items.Clear();
                comboBoxFuncionario.Items.Clear();
            }

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
            CancelaCadastradoOs(typeof(FormCadastroOsNovo));
        }
        public FormCadastroOsNovo(int idCliente)
        {
            InitializeComponent();

            AlteraBotoes(2);

            this.Top = 600;
            this.Left = 0;

            buttonCadastraOs.Enabled = false;
            buttonCadastraOsNovo.Enabled = true;

            this.operacao = "Inserir";
            AlteraBotoes(8);

            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

            SqlConnection conn = new SqlConnection(connectionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC ConsultaCadastroNOS ", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (!(ds.Tables[0].Rows.Count > 0))
            {
                IdOs = 1;
                txtNumeroOrdemServico.Text = IdOs.ToString();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                int soma = ds.Tables[0].Rows.Count;
                IdOs = 1 + soma;
                txtNumeroOrdemServico.Text = IdOs.ToString();
            }

            //Pesquisa de MS e Nome para Cadastro de OS

            txtPesquisaMSCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaMSCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaMSCliente.AutoCompleteCustomSource = FormCadastroClientes.LoadAutoCompleteMSCliente();

            txtPesquisaNomeCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPesquisaNomeCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPesquisaNomeCliente.AutoCompleteCustomSource = FormCadastroClientes.LoadAutoCompleteNomeCliente();

            txtOrigemChamado.MaxLength = 40;
        }

        private void buttonFecharCliente_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }

        private void buttonCancelarCliente_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
            buttonLimpaOs.Enabled = false;

            FormCadastroOsNovo cadastracliente = new FormCadastroOsNovo();
            cadastracliente.MdiParent = FormCadastroOsNovo.ActiveForm;
            cadastracliente.Show();
            cadastracliente.Top = 0;
            cadastracliente.Left = 0;
        }

        private void buttonLimpaCliente_Click(object sender, EventArgs e)
        {
            AlteraBotoes(10);
        }

        private void buttonCadastraOs_Click(object sender, EventArgs e)
        {
            this.operacao = "Inserir";
            AlteraBotoes(1);
            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";

            SqlConnection conn = new SqlConnection(connectionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC ConsultaCadastroNOS ", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (!(ds.Tables[0].Rows.Count > 0))
            {
                IdOs = 1;
                txtNumeroOrdemServico.Text = IdOs.ToString();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                int soma = ds.Tables[0].Rows.Count;
                IdOs = 1 + soma;
                txtNumeroOrdemServico.Text = IdOs.ToString();
            }

        }

        private void buttonPesquisaCliente_Click(object sender, EventArgs e)
        {
            AlteraBotoes(10);

            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
            SqlConnection conn = new SqlConnection(connectionString);


            if (radioButtonPequisaMS.Checked)
            {
                if (txtPesquisaMSCliente.Text == "")
                {
                    FecharTodosFormulario();
                    MessageBox.Show("O nome campo MS nao pode esta em branco! ");
                    AlteraBotoes(10);
                }

                if (!(txtPesquisaMSCliente.Text == ""))
                {
                    int MS = int.Parse(this.txtPesquisaMSCliente.Text);
                    //SELECIONA POR MS
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaPessoaMsClienteTxt " + MS + "; ", conn);

                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        IdPessoa = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                        idPessoaTipo = int.Parse(ds1.Tables[0].Rows[0][1].ToString());

                        if (IdPessoa != 0)
                        {
                            panel2.Enabled = true;
                            panel3.Enabled = true;
                            panel4.Enabled = false;
                            panel5.Enabled = true;
                            buttonImprimir.Enabled = true;
                            buttonImprimirOS.Enabled = true;

                            comboBoxContato.Items.Clear();
                            Fill_listBoxContatos();
                            buttonLimpaOs.Enabled = true;

                            comboBoxFuncionario.Items.Clear();

                            Fill_listBoxFuncionario();
                        }
                        if (IdPessoa == 0)
                        {
                            panel2.Enabled = false;
                            panel3.Enabled = false;
                            panel4.Enabled = false;
                            panel5.Enabled = false;
                            buttonImprimir.Enabled = false;
                            buttonImprimirOS.Enabled = false;

                        }

                        try
                        {
                            if (idPessoaTipo == 1)
                            {
                                try
                                {
                                    txtNomeOS.Text = ds1.Tables[0].Rows[0][3].ToString();
                                    txtMsOs.Text = ds1.Tables[0].Rows[0][29].ToString();
                                    txtTelefoneOs.Text = ds1.Tables[0].Rows[0][4].ToString();
                                    txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][32].ToString();
                                    txtEnderecoOS.Text = ds1.Tables[0].Rows[0][33].ToString();
                                    txtBairroNumero.Text = ds1.Tables[0].Rows[0][34].ToString();
                                    txtComplOs.Text = ds1.Tables[0].Rows[0][35].ToString();
                                    txtBairroOS.Text = ds1.Tables[0].Rows[0][36].ToString();
                                    txtCidadeOs.Text = ds1.Tables[0].Rows[0][37].ToString();

                                    conn.Close();

                                    panel2.Enabled = true;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            if (idPessoaTipo == 2)
                            {
                                try
                                {
                                    txtNomeOS.Text = ds1.Tables[0].Rows[0][3].ToString();
                                    txtMsOs.Text = ds1.Tables[0].Rows[0][29].ToString();
                                    txtTelefoneOs.Text = ds1.Tables[0].Rows[0][4].ToString();
                                    txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][32].ToString();
                                    txtEnderecoOS.Text = ds1.Tables[0].Rows[0][33].ToString();
                                    txtBairroNumero.Text = ds1.Tables[0].Rows[0][34].ToString();
                                    txtComplOs.Text = ds1.Tables[0].Rows[0][35].ToString();
                                    txtBairroOS.Text = ds1.Tables[0].Rows[0][36].ToString();
                                    txtCidadeOs.Text = ds1.Tables[0].Rows[0][37].ToString();

                                    conn.Close();

                                    panel2.Enabled = true;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        MessageBox.Show("O ms: " + MS + " não consta no sistema!");
                        buttonImprimir.Enabled = false;
                        buttonImprimirOS.Enabled = false;

                        AlteraBotoes(10);

                    }
                }
            }
            if (radioButtonPesquisaNome.Checked)
            {
                if (txtPesquisaNomeCliente.Text == "")
                {
                    buttonImprimir.Enabled = false;
                    buttonImprimirOS.Enabled = false;
                    FecharTodosFormulario();
                    MessageBox.Show("O nome campo nome nao pode esta em branco! ");
                    panel2.Enabled = false;
                    AlteraBotoes(10);
                }

                if (!(txtPesquisaNomeCliente.Text == ""))
                {

                    //SELECIONA POR Nome
                    SqlDataAdapter da1 = new SqlDataAdapter("EXEC ConsultaPessoaClienteNomeTxt '" + txtPesquisaNomeCliente.Text + "';", conn);

                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    conn.Open();

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        this.IdPessoa = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                        idPessoaTipo = int.Parse(ds1.Tables[0].Rows[0][1].ToString());


                        if (IdPessoa != 0)
                        {
                            panel2.Enabled = true;
                            panel3.Enabled = true;
                            panel5.Enabled = true;
                            buttonImprimir.Enabled = true;
                            buttonImprimirOS.Enabled = true;

                            comboBoxContato.Items.Clear();
                            Fill_listBoxContatos();

                            comboBoxFuncionario.Items.Clear();

                            Fill_listBoxFuncionario();

                            buttonLimpaOs.Enabled = true;

                        }
                        if (IdPessoa == 0)
                        {
                            panel2.Enabled = false;
                            panel3.Enabled = false;
                            panel5.Enabled = false;
                            buttonImprimir.Enabled = false;
                            buttonImprimirOS.Enabled = false;

                        }
                        try
                        {
                            //Cliente Juridica

                            string CNPJ = ds1.Tables[0].Rows[0][26].ToString();
                            string RAZAOSOCIAL = ds1.Tables[0].Rows[0][25].ToString();
                            string INSCSTADUAL = ds1.Tables[0].Rows[0][28].ToString();
                            string NOME = ds1.Tables[0].Rows[0][27].ToString();


                            if (idPessoaTipo == 1)
                            {
                                try
                                {
                                    txtNomeOS.Text = ds1.Tables[0].Rows[0][25].ToString();
                                    txtTelefoneOs.Text = ds1.Tables[0].Rows[0][3].ToString();
                                    txtMsOs.Text = ds1.Tables[0].Rows[0][30].ToString();
                                    txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][33].ToString();
                                    txtEnderecoOS.Text = ds1.Tables[0].Rows[0][34].ToString();
                                    txtBairroNumero.Text = ds1.Tables[0].Rows[0][35].ToString();
                                    txtComplOs.Text = ds1.Tables[0].Rows[0][36].ToString();
                                    txtBairroOS.Text = ds1.Tables[0].Rows[0][37].ToString();
                                    txtCidadeOs.Text = ds1.Tables[0].Rows[0][38].ToString();
                                    conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            if (idPessoaTipo == 2)
                            {
                                try
                                {
                                    txtMsOs.Text = ds1.Tables[0].Rows[0][30].ToString();
                                    txtNomeOS.Text = ds1.Tables[0].Rows[0][25].ToString();
                                    txtEnderecoOS.Text = ds1.Tables[0].Rows[0][8].ToString();
                                    txtTelefoneOs.Text = ds1.Tables[0].Rows[0][4].ToString();

                                    txtNomeOS.Text = ds1.Tables[0].Rows[0][17].ToString();

                                    txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][33].ToString();
                                    txtEnderecoOS.Text = ds1.Tables[0].Rows[0][34].ToString();
                                    txtBairroNumero.Text = ds1.Tables[0].Rows[0][35].ToString();
                                    txtComplOs.Text = ds1.Tables[0].Rows[0][36].ToString();
                                    txtBairroOS.Text = ds1.Tables[0].Rows[0][37].ToString();
                                    txtCidadeOs.Text = ds1.Tables[0].Rows[0][38].ToString();
                                    conn.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    if (!(ds1.Tables[0].Rows.Count > 0))
                    {
                        MessageBox.Show("O Nome: " + txtPesquisaNomeCliente.Text + " não consta no sistema!");
                        buttonImprimir.Enabled = false;
                        buttonImprimirOS.Enabled = false;
                    }
                }
            }
            else if (!(radioButtonPequisaMS.Checked) && !(radioButtonPesquisaNome.Checked)) MessageBox.Show("Seleciona Ms ou Nome para uma Pesquisa!");
        }
        private void radioButtonPequisaMS_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMSCliente.Enabled = true;
            txtPesquisaNomeCliente.Enabled = false;
            AlteraBotoes(10);
        }

        private void radioButtonPesquisaNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaMSCliente.Enabled = false;
            txtPesquisaNomeCliente.Enabled = true;
            AlteraBotoes(10);
        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao = new Conexao(strConexao);
            DALCadastro da = new DALCadastro(conexao);

            Os cadastra = new Os();

            if ((validaNome(txtNomeOS, errorProviderOs) == true)) //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
            {
                try
                {
                    cadastra.IdPessoaCliente = IdPessoa;
                    cadastra.IdContato = IdContato;
                    cadastra.IdFuncionario = IdFuncionario;
                    cadastra.IdServico = 0;
                    cadastra.IdItemServico = 0;
                    cadastra.OrigemChamado = txtOrigemChamado.Text;
                    cadastra.ServicosExecutados = txtservicoexecutados.Text;
                    cadastra.ValorObra = "Desenvolver";
                    cadastra.HorarioInicio = maskedTxtHorarioInicio.Text;
                    cadastra.HorarioFinal = maskedTxtHorarioFInal.Text;

                    cadastra.DataSolicitacao = Convert.ToDateTime(txtDataSolicitacao.Value.Date.ToString("dd/MM/yyyy"));

                    cadastra.Estado = 1;
                    cadastra.Situacao = 1;
                    cadastra.MudancaDataFechamento = 0;


                    if (this.operacao == "Inserir")
                    {
                        if ((this.comboBoxContato.Text == "") && (this.comboBoxFuncionario.Text == ""))
                        {
                            MessageBox.Show("O contato e o Funcionario não pode ser em Branco!");
                        }
                        if (!(this.comboBoxContato.Text == "") && (this.comboBoxFuncionario.Text == ""))
                        {
                            MessageBox.Show("Funcionario não pode ser em Branco!");
                        }
                        if ((this.comboBoxContato.Text == "") && !(this.comboBoxFuncionario.Text == ""))
                        {
                            MessageBox.Show("Contato não pode ser em Branco!");
                        }
                        if (!(this.comboBoxContato.Text == "") && !(this.comboBoxFuncionario.Text == ""))
                        {
                            da.IncluiOS(cadastra);

                            MessageBox.Show("Os Cadastrado com Exito! ");

                            DialogResult dialogResult = MessageBox.Show("Deseja Visualizar ou Imprimir Documento!", "Aviso", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                panel1.Enabled = false;
                                panel2.Enabled = false;
                                panel3.Enabled = false;
                                panel4.Enabled = false;
                                panel5.Enabled = false;
                                panel6.Enabled = false;
                                buttonVerifica.Enabled = false;
                                buttonLimpaOs.Enabled = false;
                                buttonCadastraOs.Enabled = false;
                                buttonFecharOs.Enabled = false;
                                buttonCadastraOsNovo.Enabled = true;
                                buttonImprimirOS.Enabled = true;
                                buttonImprimir.Enabled = true;
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                FecharTodosFormulario();

                                FormCadastroOsNovo ClientesContatos = new FormCadastroOsNovo();
                                ClientesContatos.MdiParent = FormCadastroOsNovo.ActiveForm;
                                ClientesContatos.Show();
                                ClientesContatos.Top = 0;
                                ClientesContatos.Left = 0;
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
        private void buttonImprimirOS_Click(object sender, EventArgs e)
        {
            printPreviewDialogOs.Document = printDocumentOs;
            printPreviewDialogOs.ShowDialog();
        }

        private void printDocumentOs_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.ImagemOs1;
            Image newImagem = bmp;

            e.Graphics.DrawImage(newImagem, 0, 0, newImagem.Width, newImagem.Height);
            e.Graphics.DrawString("" + IdOs.ToString(), new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(592, 40));
            e.Graphics.DrawString("" + txtDataSolicitacao.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(337, 90));
            e.Graphics.DrawString("" + txtNomeOS.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(162, 173));
            e.Graphics.DrawString("" + txtMsOs.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(646, 172));
            e.Graphics.DrawString("" + txtTipo_logradouro.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(162, 198));
            e.Graphics.DrawString("" + txtEnderecoOS.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(225, 198));
            e.Graphics.DrawString("" + txtComplOs.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(420, 198));
            e.Graphics.DrawString("" + txtBairroNumero.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(493, 198));
            e.Graphics.DrawString("" + txtBairroOS.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(523, 198));
            e.Graphics.DrawString("" + txtCidadeOs.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(638, 198));
            e.Graphics.DrawString("" + comboBoxContato.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(162, 222));
            e.Graphics.DrawString("" + txtTelefoneOs.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(162, 245));
            e.Graphics.DrawString("" + comboBoxFuncionario.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(162, 944));
            e.Graphics.DrawString("" + txtOrigemChamado.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(15, 305));

            //e.Graphics.DrawString("" + txtservicoexecutados.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 300));


        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            Caixa_setup.Document = printDocumentOs;
            Caixa_setup.ShowDialog();
        }
        //LISTA OS Contatos da empresa Buscada
        void Fill_listBoxContatos()
        {
            SqlConnection connection = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");

            try
            {
                connection.Open();
                string Query = "EXEC ConsultaCadastroIdFornecedorOS "+ IdPessoa + ";";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(0);
                    comboBoxContato.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //LISTA OS Fucionarios da Empresa
        void Fill_listBoxFuncionario()
        {
            SqlConnection connection = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");

            try
            {
                connection.Open();
                string Query = "EXEC ConsultaTecnicoOs;";


                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(0);
                    comboBoxFuncionario.Items.Add(name);
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Seleciona Contato da empresa
        private void comboBoxContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");

            try
            {
                connection.Open();

                string Query = "EXEC ConsultaCadastroNomeFornecedorOStxt '" + this.comboBoxContato.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                    IdContato = dr.GetInt32(0);
                    comboBoxContato.Text = dr.GetString(1);

                    //MessageBox.Show("O ID do Contato Selecionado foi: " + IdContato);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Seleciona Funcionario da empresa
        private void comboBoxFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;");

            try
            {
                connection.Open();

                string Query = "exec ConsultaTecnicoOsTxT '" + this.comboBoxFuncionario.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                    IdFuncionario = dr.GetInt32(0);
                    comboBoxFuncionario.Text = dr.GetString(1);
                   // MessageBox.Show("O Id Do Funcionario : " + IdFuncionario);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCadastraOsNovo_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormCadastroOsNovo cadastraOs = new FormCadastroOsNovo(1);
            cadastraOs.MdiParent = FormCadastroOsNovo.ActiveForm;
            cadastraOs.Show();
            cadastraOs.Top = 0;
            cadastraOs.Left = 0;
        }

        private void FormCadastroOsNovo_Load(object sender, EventArgs e)
        {
            txtOrigemChamado.MaxLength = 400;
            txtservicoexecutados.MaxLength = 400;
        }

        private void printPreviewDialogOs_Load(object sender, EventArgs e)
        {

        }
    }
}
