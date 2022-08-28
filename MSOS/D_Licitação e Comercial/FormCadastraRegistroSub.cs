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

namespace DateSystem
{
    public partial class FormCadastraRegistroSub : Form
    {
        private int ID_REGISTRO = 0;
        public int IdRegistro
        {
            get
            {
                return this.ID_REGISTRO;

            }
            set
            {
                this.ID_REGISTRO = value;
            }
        }
        private int IDPESSOA = 0;
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
        private int IDCONTATOCLIENTE = 0;
        public int IdContatoCliente
        {
            get
            {
                return this.IDCONTATOCLIENTE;

            }
            set
            {
                this.IDCONTATOCLIENTE = value;
            }
        }
        public int ID_PESSOA_LOGADA = 0;
        public int IdPessoaLogada
        {
            get
            {
                return this.ID_PESSOA_LOGADA;

            }
            set
            {
                this.ID_PESSOA_LOGADA = value;
            }
        }
        private int NUMERO_GERADO_SUB_REGISTRO = 0;
        public int NumeroGeradoSUbRegistro
        {
            get
            {
                return this.NUMERO_GERADO_SUB_REGISTRO;

            }
            set
            {
                this.NUMERO_GERADO_SUB_REGISTRO = value;
            }
        }
        private int NUMERO_GERADO_SUB_REGISTRO_SALVA = 0;
        public int NumeroGeradoSUbRegistroSalva
        {
            get
            {
                return this.NUMERO_GERADO_SUB_REGISTRO_SALVA;

            }
            set
            {
                this.NUMERO_GERADO_SUB_REGISTRO_SALVA = value;
            }
        }
        private string CONNECTIONSTRING = "";
        public string connetionString
        {
            get
            {
                return this.CONNECTIONSTRING;

            }
            set
            {
                this.CONNECTIONSTRING = value;
            }
        }
        private string NUMEROCLIENTE = "";
        public string NumeroCliente
        {
            get
            {
                return this.NUMEROCLIENTE;

            }
            set
            {
                this.NUMEROCLIENTE = value;
            }
        }
        private string COMBOBOXABREVIACAO = "";
        public string ComboBoxAbreviacao
        {
            get
            {
                return this.COMBOBOXABREVIACAO;

            }
            set
            {
                this.COMBOBOXABREVIACAO = value;
            }
        }
        private string NOMEUSUARIO = "";
        public string NomeUsuario
        {
            get
            {
                return this.NOMEUSUARIO;

            }
            set
            {
                this.NOMEUSUARIO = value;
            }
        }
        private string NOMECLIENTE = "";
        public string NomeCliente
        {
            get
            {
                return this.NOMECLIENTE;

            }
            set
            {
                this.NOMECLIENTE = value;
            }
        }

        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtOrigemRegistro.Text))
            {
                errorProviderCadastraRegistroSub.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastraRegistroSub.SetError(textBox, "Documentação Inválido!");
                return false;
            }

        }
        private string operacao = "";
        public FormCadastraRegistroSub()
        {
            InitializeComponent();
        }
        public FormCadastraRegistroSub(int IDREGISTRO, int IDPESSOA, string NOMECLIENTE,string NUMEROCLIENTE,
           int IDPESSOALOGADA,string NOMEUSARIOLOAGADO, string CONNETIONSTRING)
        {
            InitializeComponent();

            this.IdRegistro = IDREGISTRO;
            this.IdPessoa = IDPESSOA;
            this.NomeCliente = NOMECLIENTE;
            this.NumeroCliente = NUMEROCLIENTE;
            this.IdPessoaLogada = IDPESSOALOGADA;
            this.NomeUsuario = NOMEUSARIOLOAGADO;
            NomeLogado.Text = "NOME: " + NOMEUSARIOLOAGADO;
            this.connetionString = CONNETIONSTRING;

            this.txtDataSolicitacaoProcesso.Value = DateTime.Now.Date;

            this.txtDataContatoRegistro.Value = DateTime.Now.Date;

            txtOrigemRegistro.MaxLength = 1000;
        }
        private void FormCadastraRegistroSub_Load(object sender, EventArgs e)
        {

        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            CadastraRegistroSub();
        }
        
        public void CadastraRegistroSub()
        {
            Conexao conexao = new Conexao(this.connetionString);
            DALRegistroGerado da = new DALRegistroGerado(conexao);

            RegistroGeradoSub RegistroGeradoSubs = new RegistroGeradoSub();

            if ((validaNome(txtOrigemRegistro, errorProviderCadastraRegistroSub) == true)) //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
            {
                try
                {
                    RegistroGeradoSubs.IdRegistro = IdRegistro;                  

                    RegistroGeradoSubs.IdClienteRegistro = this.IdPessoa;

                    RegistroGeradoSubs.IdContato = this.IdContatoCliente;

                    RegistroGeradoSubs.Situacao = 1;

                    RegistroGeradoSubs.IdPessoaLogada = this.IdPessoaLogada;

                    RegistroGeradoSubs.IdPessoaLogadaAlterada = 0;

                    RegistroGeradoSubs.OrigemRegistro = txtOrigemRegistro.Text;

                    RegistroGeradoSubs.DataCriadoRegistrado = Convert.ToDateTime(txtDataSolicitacaoProcesso.Value.Date.ToString("dd/MM/yyyy"));

                    RegistroGeradoSubs.DataContato = Convert.ToDateTime(txtDataContatoRegistro.Value.Date.ToString("dd/MM/yyyy"));


                    if (this.operacao == "Inserir")
                    {
                        if (this.comboBoxContato.Text == "")
                        {
                            MessageBox.Show("Selecione um contato para Cadastrado no sistema!");
                        }
                        if (!(this.comboBoxContato.Text == ""))
                        {
                            NumeroGeradoSubRegistroSalva();

                            if (this.NumeroGeradoSUbRegistro == this.NumeroGeradoSUbRegistroSalva)
                            {
                                RegistroGeradoSubs.IdRegistroSub = this.NumeroGeradoSUbRegistroSalva;

                                da.IncluirClienteRegistroGeradoSub(RegistroGeradoSubs);

                                MessageBox.Show("Registro Gerado Cadastrado com Exito! \n O número de Sub registro é " + NumeroGeradoSUbRegistro + " !");

                                DialogResult dialogResult = MessageBox.Show("Deseja criar um Sub Registro?", "Aviso", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    FecharTodosFormulario();

                                    timerRegistroSubNovo.Enabled = true;

                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    FecharTodosFormulario();
                                }
                            }
                            if (this.NumeroGeradoSUbRegistro != this.NumeroGeradoSUbRegistroSalva)
                            {
                                RegistroGeradoSubs.IdRegistroSub = this.NumeroGeradoSUbRegistroSalva;

                                da.IncluirClienteRegistroGeradoSub(RegistroGeradoSubs);

                                MessageBox.Show("O número de Sub registro foi alterado gerado novo número salvo: " + NumeroGeradoSUbRegistroSalva + " ! \n Registro Gerado Cadastrado com Exito!");

                                DialogResult dialogResult = MessageBox.Show("Deseja criar um Sub Registro?", "Aviso", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    FecharTodosFormulario();

                                    FormCadastraRegistroSub CadastraRegistroSub = new FormCadastraRegistroSub(this.IdRegistro, this.IdPessoa,
                                        this.NomeCliente, this.NumeroCliente, this.IdPessoaLogada, this.NomeUsuario, this.connetionString);
                                    CadastraRegistroSub.MdiParent = FormCadastraRegistroSub.ActiveForm;
                                    CadastraRegistroSub.Show();
                                    CadastraRegistroSub.Top = 0;
                                    CadastraRegistroSub.Left = 0;
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    FecharTodosFormulario();
                                }
                            }
                        }
                    }
                }                            

                catch (Exception ex)
                {
                    MessageBox.Show("Erro de acesso ao banco de Dados: " + ex.ToString());
                }
            }

            FormPesquisaCadastraRegistroEditar ChamaDataGrid = new FormPesquisaCadastraRegistroEditar();

            ChamaDataGrid.dataGridViewPesquisaTodos();
        }
        public void NumeroGeradoSubRegistroSalva()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_R_ConsultaCadastroNRegistroSub " + IdRegistro + ";", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (!(ds.Tables[0].Rows.Count > 0))
            {
                NumeroGeradoSUbRegistroSalva = 1;
                txtNumeroSubRegistro.Text = " N° " + NumeroGeradoSUbRegistroSalva.ToString();

                NumeroGeradoSUbRegistroSalva = 1;
                conn.Close();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                int soma = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                NumeroGeradoSUbRegistroSalva = 1 + soma;
                txtNumeroSubRegistro.Text = " N° " + NumeroGeradoSUbRegistroSalva.ToString();
                conn.Close();
            }
        }
        private void FormCadastraRegistroSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void buttonCancelarRegistro_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
    
        }

        private void buttonFecharRegistro_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }

        private void buttonCadastraRegistro_Click(object sender, EventArgs e)
        {
            this.operacao = "Inserir";
  
            txtOrigemRegistro.MaxLength = 1000;

            txtNomeRegistro.Text = NomeCliente;

            txtNumeroCadastroCliente.Text = NumeroCliente;

            AlteraBotoes(1);

            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_R_ConsultaCadastroNRegistroSub " + IdRegistro + ";", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            txtNumeroRegistro.Text = " N° " + IdRegistro.ToString();

            if (!(ds.Tables[0].Rows.Count > 0))
            {
                NumeroGeradoSUbRegistro = 1;
                txtNumeroSubRegistro.Text = " N° " + NumeroGeradoSUbRegistro.ToString();
                NumeroGeradoSUbRegistro = 1;
                conn.Close();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                int soma = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                NumeroGeradoSUbRegistro = 1 + soma;
                txtNumeroSubRegistro.Text = " N° " + NumeroGeradoSUbRegistro.ToString();

                NumeroGeradoSUbRegistro = 1 + soma;

                conn.Close();
            }

            this.txtDataSolicitacaoProcesso.Value = DateTime.Now.Date;

            this.txtDataContatoRegistro.Value = DateTime.Now.Date;

            Fill_listBoxContatos();
        }

        private void buttonCancelarRegistro1_Click(object sender, EventArgs e)
        {
            CancelarCadastroRegistroSub();
        }
        public void CancelarCadastroRegistroSub()
        {
            FecharTodosFormulario();

            FormCadastraRegistroSub CadastraRegistroSub = new FormCadastraRegistroSub(this.IdRegistro, this.IdPessoa,
            this.NomeCliente, this.NumeroCliente, this.IdPessoaLogada, this.NomeUsuario, this.connetionString);
            CadastraRegistroSub.MdiParent = FormCadastraRegistroSub.ActiveForm;
            CadastraRegistroSub.Show();
            CadastraRegistroSub.Top = 0;
        }
        public void FecharTodosFormulario()
        {
            CancelaCadastradoProposta(typeof(FormCadastraRegistroSub));
            //CancelaCadastradoProposta(typeof(FormCadastraRegistroSub));
        }
        public static void CancelaCadastradoProposta(Type frmType)
        {
            bool bolCtl = false;
            Type a = frmType;
            foreach (Form form in System.Windows.Forms.Application.OpenForms)
            {
                if (form.GetType().Equals(frmType))
                {

                    form.Close();

                    bolCtl = true;
                    break;
                }
            }

            if (!bolCtl)
            {

            }
        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Cadastra Registro campos
            {
                buttonCadastraRegistro.Enabled = false;
                buttonCancelarRegistro.Enabled = true;

                buttonLimpaRegistro.Enabled = true;
                buttonCancelarRegistro1.Enabled = true;
                buttonFecharRegistro.Enabled = true;
                buttonVerifica.Enabled = true;

                panelDadosCliente.Enabled = true;

                panelDocumentoRegistro.Enabled = true;

                checkBoxSituacao.Checked = true;
            }
        }
        void Fill_listBoxContatos()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();
                string Query = "EXEC D_R_ConsultaCadastroIdRegistro " + IdPessoa + ";";


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
        private void comboBoxContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(this.connetionString);

            try
            {
                connection.Open();

                string Query = " SELECT ID_PESSOA_CONTATO, ABREVIACAO FROM P_Contatos WHERE Nome = '" + this.comboBoxContato.Text + "';";

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {

                    this.IdContatoCliente = dr.GetInt32(0);
                    comboBoxContato.Text = dr.GetString(1);
                    label8.Text = dr.GetString(1);
                    this.ComboBoxAbreviacao = dr.GetString(1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLimpaRegistro_Click(object sender, EventArgs e)
        {
            txtOrigemRegistro.Clear();
        }
        private void timerRegistroSubNovo_Tick(object sender, EventArgs e)
        {
            

            FormCadastraRegistroSub CadastraRegistroSub = new FormCadastraRegistroSub(this.IdRegistro, this.IdPessoa,
            this.NomeCliente, this.NumeroCliente, this.IdPessoaLogada, this.NomeUsuario, this.connetionString);
            CadastraRegistroSub.MdiParent = FormCadastraRegistroSub.ActiveForm;
            CadastraRegistroSub.Show();
            CadastraRegistroSub.Top = 0;
            CadastraRegistroSub.Left = 0;

            timerRegistroSubNovo.Enabled = false;
        }
    }
}
