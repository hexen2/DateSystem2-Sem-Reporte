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
namespace DateSystem
{
    public partial class FormCadastraRegistroSubEditar : Form
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
        private int ID_REGISTROSUB1 = 0;
        public int IdRegistroSub1
        {
            get
            {
                return this.ID_REGISTROSUB1;

            }
            set
            {
                this.ID_REGISTROSUB1 = value;
            }
        }
        private int REGISTROEDITAR = 0;
        public int RegistroEditar
        {
            get
            {
                return this.REGISTROEDITAR;

            }
            set
            {
                this.REGISTROEDITAR = value;
            }
        }
        private int REGISTROEXCLUIR = 0;
        public int RegistroExcluir
        {
            get
            {
                return this.REGISTROEXCLUIR;

            }
            set
            {
                this.REGISTROEXCLUIR = value;
            }
        }
        private int IDPESSOALOGADA = 0;
        public int IdPessoaLogada
        {
            get
            {
                return this.IDPESSOALOGADA;

            }
            set
            {
                this.IDPESSOALOGADA = value;
            }
        }
        private string CONNETIONSTRING = "";
        public string connetionString
        {
            get
            {
                return this.CONNETIONSTRING;

            }
            set
            {
                this.CONNETIONSTRING = value;
            }
        }
        private int SITUACAO = 0;
        public int Situacao
        {
            get
            {
                return this.SITUACAO;

            }
            set
            {
                this.SITUACAO = value;
            }
        }
        string Operacao = "";
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean txtOrigemRegistroa(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtOrigemRegistro.Text))
            {
                errorProviderCadastraRegistroSubEditar.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastraRegistroSubEditar.SetError(textBox, "Nome Inválido!");
                return false;
            }
        }
        public FormCadastraRegistroSubEditar()
        {
            InitializeComponent();
        }
        public FormCadastraRegistroSubEditar(int IdRegistro, int IdRegistroSub1, int RegistroEditar,
                        int RegistroExcluir, int IdPessoaLogada, string connetionString)
        {
            InitializeComponent();

            this.IdRegistro = IdRegistro;
            this.IdRegistroSub1 = IdRegistroSub1;
            this.RegistroEditar = RegistroEditar;
            this.RegistroExcluir = RegistroExcluir;
            this.IdPessoaLogada = IdPessoaLogada;
            this.connetionString = connetionString;

            txtOrigemRegistro.MaxLength = 1000;

            CadastraRegistroSubEditar();
        }
        void CadastraRegistroSubEditar()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_R_ConsultaRegistroGeradoSubNSEditartxt " + IdRegistroSub1 + ";", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Open();

            txtNumeroRegistro.Text = IdRegistro.ToString();
            txtNumeroSubRegistro.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDataSolicitacaoProcesso.Text = ds.Tables[0].Rows[0][9].ToString();
            txtNomeRegistro.Text = ds.Tables[0].Rows[0][12].ToString();
            txtNumeroCadastroCliente.Text = ds.Tables[0].Rows[0][11].ToString();
            txtNomeContato.Text = ds.Tables[0].Rows[0][16].ToString();
            label8.Text = ds.Tables[0].Rows[0][17].ToString();
            txtOrigemRegistro.Text = ds.Tables[0].Rows[0][8].ToString();
            txtDataContatoRegistro.Text = ds.Tables[0].Rows[0][10].ToString();

            Situacao = int.Parse(ds.Tables[0].Rows[0][5].ToString());

            if (Situacao == 0)
            {
                checkBoxSituacao.Checked = false;
            }
            if (Situacao == 1)
            {
                checkBoxSituacao.Checked = true;
            }
            if (RegistroEditar == 1)
            {
                buttonEditar.Enabled = true;
            }
            conn.Close();
            //ds.Tables[0].Rows[0][0].ToString();
        }

        private void FormCadastraRegistroSubEditar_Load(object sender, EventArgs e)
        {

        }
        public void FecharTodosFormulario()
        {
            CancelaCadastradoProposta(typeof(FormCadastraRegistroSubEditar));
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

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }
        public void Editar()
        {
            if(REGISTROEDITAR == 0 || Situacao == 0)
            {
                MessageBox.Show("Acesso negado!");
            }
            if (REGISTROEDITAR == 1 && (Situacao == 1))
            {
                panelDocumentoRegistro.Enabled = true;

            }
        }

        private void buttonCancelarRegistro_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
        public void Cancelar()
        {
            FecharTodosFormulario();
            FormCadastraRegistroSubEditar CadastraRegistroEditar = new FormCadastraRegistroSubEditar(this.IdRegistro, this.IdRegistroSub1, this.RegistroEditar,
            this.RegistroExcluir, this.IdPessoaLogada, this.connetionString);
            CadastraRegistroEditar.MdiParent = FormCadastraRegistroSubEditar.ActiveForm;
            CadastraRegistroEditar.Show();
            CadastraRegistroEditar.Top = 0;
        }

        private void buttonFecharRegistro_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            SalvarAlteracao();
        }
        public void SalvarAlteracao()
        {
            Conexao conexao = new Conexao(this.connetionString);
            DALRegistroGerado da = new DALRegistroGerado(conexao);

            RegistroGeradoSub RegistroGeradoSub = new RegistroGeradoSub();

            if ((txtOrigemRegistroa(txtNomeRegistro, errorProviderCadastraRegistroSubEditar) == true)) //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
            {
                try
                {
                    RegistroGeradoSub.IdRegistroSub = this.IdRegistroSub1;

                    if (checkBoxSituacao.Checked == false)
                    {
                        RegistroGeradoSub.Situacao = 2;
                    }
                    if (checkBoxSituacao.Checked == true)
                    {
                        RegistroGeradoSub.Situacao = 1;
                    }

                    RegistroGeradoSub.IdPessoaLogadaAlterada = this.IdPessoaLogada;

                    RegistroGeradoSub.OrigemRegistro = txtOrigemRegistro.Text;

                    if (this.Operacao == "Editar")
                    {
                        da.AlterarClienteRegistroGeradoSub(RegistroGeradoSub);                        
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro de acesso ao banco de Dados: " + ex.ToString());
                }
            }
        }

        private void buttonCadastraRegistro_Click(object sender, EventArgs e)
        {

        }

        private void FormCadastraRegistroSubEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}
