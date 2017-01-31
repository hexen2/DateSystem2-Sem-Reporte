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
    public partial class FormPesquisaClientesEditar : Form
    {
        public FormPesquisaClientesEditar()
        {
            InitializeComponent();        
        }
        string OPERACAO = "";
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
        private int STATUS = 0;
        public int status
        {
            get
            {
                return this.STATUS;

            }
            set
            {
                this.STATUS = value;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                errorProviderEditarCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderEditarCliente.SetError(textBox, "Nome Inválido!");
                return false;
            }

        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaMs(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtMsCliente.Text))
            {
                errorProviderEditarCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderEditarCliente.SetError(textBox, "MS Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaEndereco(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtEnderecoCliente.Text))
            {
                errorProviderEditarCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderEditarCliente.SetError(textBox, "Endereço Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaTelefone(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtTelefoneCliente.Text))
            {
                errorProviderEditarCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderEditarCliente.SetError(textBox, "Telefone Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaBairro(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtBairroCliente.Text))
            {
                errorProviderEditarCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderEditarCliente.SetError(textBox, "Bairro Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCep(MaskedTextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCepCliente.Text))
            {
                errorProviderEditarCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderEditarCliente.SetError(textBox, "Cep Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaCidade(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtCidadeCliente.Text))
            {
                errorProviderEditarCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderEditarCliente.SetError(textBox, "Cidade Inválido!");
                return false;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaEmail(TextBox textBox, ErrorProvider errorProvider)
        {
            string email = txtEmailCliente.Text;
            string modelo = @"[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+";

            if (Regex.IsMatch(email, modelo))
            {
                errorProviderEditarCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderEditarCliente.SetError(textBox, "E-mail Inválido!");
                return false;
            }
        }
        private Boolean validaNumero(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtBairroNumero.Text))
            {
                errorProviderEditarCliente.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderEditarCliente.SetError(textBox, "Numero Inválido!");
                return false;
            }
        }
        private void FormPesquisaClientesEditar_Load(object sender, EventArgs e)
        {
        }
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
        public FormPesquisaClientesEditar(int idPessoa)
        {
            InitializeComponent();

            //IdPessoa = Convert.ToInt32(dataGridViewPesquisaCliente["ID_PESSOA", e.RowIndex].Value);
            ////id = Convert.ToInt32(dataGridViewPesquisa.CurrentRow.Cells[0].Value.ToString());
            ////id = Convert.ToInt32(dataGridViewPesquisa.Rows[e.RowIndex].Cells["ORDEM_SERVIÇO"].Value.ToString());

            String connectionString1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
            SqlConnection conn1 = new SqlConnection(connectionString1);
            string sql1 = "exec ConsultaClienteEditarTxt " + idPessoa;
            SqlDataAdapter sda1 = new SqlDataAdapter(sql1, conn1);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1);

            IdPessoaTipo = int.Parse(ds1.Tables[0].Rows[0][1].ToString());
            status = int.Parse(ds1.Tables[0].Rows[0][2].ToString());

            if (IdPessoaTipo == 1)
            {
                //Cliente Fisico 
                txtNomePFisica.Text = ds1.Tables[0].Rows[0][15].ToString();
                comboBoxSexoPFIsica.Text = ds1.Tables[0].Rows[0][16].ToString();
                txtCpfPFisica.Text = ds1.Tables[0].Rows[0][17].ToString();
                txtRgFisica.Text = ds1.Tables[0].Rows[0][18].ToString();
                txtCelularPFisica.Text = ds1.Tables[0].Rows[0][20].ToString();
                txtCelularPFisica2.Text = ds1.Tables[0].Rows[0][21].ToString();
                txtDataNascimento.Text = ds1.Tables[0].Rows[0][19].ToString();

                string MS = ds1.Tables[0].Rows[0][28].ToString();
                txtNomeCliente.Text = ds1.Tables[0].Rows[0][3].ToString();
                txtTelefoneCliente.Text = ds1.Tables[0].Rows[0][4].ToString();
                txtTelefone2Cliente.Text = ds1.Tables[0].Rows[0][5].ToString();
                txtFaxTelefoneCliente.Text = ds1.Tables[0].Rows[0][6].ToString();
                txtTelexTelefoneCliente.Text = ds1.Tables[0].Rows[0][7].ToString();
                txtEmailCliente.Text = ds1.Tables[0].Rows[0][8].ToString();
                txtObservacaoCliente.Text = ds1.Tables[0].Rows[0][9].ToString();
                txtCepCliente.Text = ds1.Tables[0].Rows[0][41].ToString();
                txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][31].ToString();
                txtEnderecoCliente.Text = ds1.Tables[0].Rows[0][32].ToString();
                txtBairroNumero.Text = ds1.Tables[0].Rows[0][33].ToString();
                txtComplCliente.Text = ds1.Tables[0].Rows[0][34].ToString();
                txtBairroCliente.Text = ds1.Tables[0].Rows[0][35].ToString();
                txtCidadeCliente.Text = ds1.Tables[0].Rows[0][36].ToString();
                txtSiglaCidadeCliente.Text = ds1.Tables[0].Rows[0][37].ToString();
                txtCpMunicipalCliente.Text = ds1.Tables[0].Rows[0][10].ToString();
                txtMunicipioCliente.Text = ds1.Tables[0].Rows[0][11].ToString();
                txtPaisCliente.Text = ds1.Tables[0].Rows[0][12].ToString();
                txtDescPaisCliente.Text = ds1.Tables[0].Rows[0][13].ToString();
                txtTipoCliente.Text = ds1.Tables[0].Rows[0][10].ToString();

                if (status == 1)
                {
                    checkBoxClienteSituacao.Checked = true;
                }
                
            }
            if (IdPessoaTipo == 2)
            {
                //Cliente Juridica
                txtrAZAO_SOCIALTextBox.Text = ds1.Tables[0].Rows[0][1].ToString();
                txtCnpJTextBox.Text = ds1.Tables[0].Rows[0][2].ToString();
                txtnOME_CONTATOTextBox.Text = ds1.Tables[0].Rows[0][3].ToString();
                txtiNSCRICAO_STADUALTextBox.Text = ds1.Tables[0].Rows[0][4].ToString();

                string MS = ds1.Tables[0].Rows[0][28].ToString();
                txtNomeCliente.Text = ds1.Tables[0].Rows[0][3].ToString();
                txtTelefoneCliente.Text = ds1.Tables[0].Rows[0][4].ToString();
                txtTelefone2Cliente.Text = ds1.Tables[0].Rows[0][5].ToString();
                txtFaxTelefoneCliente.Text = ds1.Tables[0].Rows[0][6].ToString();
                txtTelexTelefoneCliente.Text = ds1.Tables[0].Rows[0][7].ToString();
                txtEmailCliente.Text = ds1.Tables[0].Rows[0][8].ToString();
                txtObservacaoCliente.Text = ds1.Tables[0].Rows[0][9].ToString();
                txtCepCliente.Text = ds1.Tables[0].Rows[0][41].ToString();
                txtTipo_logradouro.Text = ds1.Tables[0].Rows[0][31].ToString();
                txtEnderecoCliente.Text = ds1.Tables[0].Rows[0][32].ToString();
                txtBairroNumero.Text = ds1.Tables[0].Rows[0][33].ToString();
                txtComplCliente.Text = ds1.Tables[0].Rows[0][34].ToString();
                txtBairroCliente.Text = ds1.Tables[0].Rows[0][35].ToString();
                txtCidadeCliente.Text = ds1.Tables[0].Rows[0][36].ToString();
                txtSiglaCidadeCliente.Text = ds1.Tables[0].Rows[0][37].ToString();
                txtCpMunicipalCliente.Text = ds1.Tables[0].Rows[0][10].ToString();
                txtMunicipioCliente.Text = ds1.Tables[0].Rows[0][11].ToString();
                txtPaisCliente.Text = ds1.Tables[0].Rows[0][12].ToString();
                txtDescPaisCliente.Text = ds1.Tables[0].Rows[0][13].ToString();
                txtTipoCliente.Text = ds1.Tables[0].Rows[0][10].ToString();

                if (status == 1)
                {
                    checkBoxClienteSituacao.Checked = true;
                }
            }
        }

        private void buttonEditarCliente_Click(object sender, EventArgs e)
        {
            this.OPERACAO = "Editar";
            panelCadastroCliente.Enabled = true;
            tabControlFisicaJuridica.Enabled = true;
            buttonVerifica.Enabled = true;

            if (IdPessoaTipo == 1)
            {
                //Pessoa Fisica
                panelJuridico.Enabled = false;
                panelFisica.Enabled = true;

                txtNomePFisica.Enabled = false;
                comboBoxSexoPFIsica.Enabled = false;
                txtCpfPFisica.Enabled = false;
                txtRgFisica.Enabled = false;
                txtCelularPFisica.Enabled = true;
                txtCelularPFisica2.Enabled = true;
                txtDataNascimento.Enabled = false;

                panelJuridico.Enabled = false;
                panelCadastroCliente.Enabled = true;
                tabControlFisicaJuridica.Enabled = true;
                

            }
            if (IdPessoaTipo == 2)
            {
                //Pessoa Juridica
                panelJuridico.Enabled = true;
                panelFisica.Enabled = false;

                txtrAZAO_SOCIALTextBox.Enabled = false;
                txtCnpJTextBox.Enabled = false;
                txtnOME_CONTATOTextBox.Enabled = true;
                txtiNSCRICAO_STADUALTextBox.Enabled = false;
            }

        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            int idPessoaFisica = 0;
            int idPessoaJuridica = 0;
            //-------------------------EDITAR CADASTRATO---------------------------------------------------------------------------------------------------------------------------------------------------------------
            if ((validaNome(txtNomeCliente, errorProviderEditarCliente) == true) && (validaMs(txtMsCliente, errorProviderEditarCliente) == true) &&
                    (validaNumero(txtBairroNumero, errorProviderEditarCliente) == true))//(labelConfirmacao.Text).Equals("sucesso - cep completo"))
            {
                try
                {
                    string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
                    Conexao conexao = new Conexao(strConexao);
                    DALCadastro dal = new DALCadastro(conexao);

                    Pessoa cadastra = new Pessoa();

                    cadastra.idPessoa = IdPessoa;
                    cadastra.Nome = txtNomeCliente.Text;
                    cadastra.Telefone = txtTelefoneCliente.Text;
                    cadastra.Telefone2 = txtTelefone2Cliente.Text;
                    cadastra.FaxTelefone = txtFaxTelefoneCliente.Text;
                    cadastra.TelexTelefone = txtTelexTelefoneCliente.Text;
                    cadastra.Email = txtEmailCliente.Text;
                    cadastra.Observacao = txtObservacaoCliente.Text;
                    cadastra.Tipo = txtTipoCliente.Text;
                    cadastra.CpMunicipio = txtCpMunicipalCliente.Text;
                    cadastra.Municipio = txtMunicipioCliente.Text;
                    cadastra.Pais = txtPaisCliente.Text;
                    cadastra.DesPais = txtDescPaisCliente.Text;
                    if (checkBoxClienteSituacao.Checked == true)
                    {
                        cadastra.Situacao = 1;
                    }
                    else if (checkBoxClienteSituacao.Checked == false)
                    {
                        cadastra.Situacao = 2;
                    }



                    if (this.OPERACAO == "Editar")
                    {
                        buttonVerifica.Enabled = false;

                        dal.Alterar(cadastra);

                        MessageBox.Show("As alterações no Cadastrado Cliente Foram Salvas!");


                        idPessoaFisica = int.Parse(cadastra.idPessoa.ToString());
                        idPessoaJuridica = int.Parse(cadastra.idPessoa.ToString());

                        FecharTodosFormulario();

                        FormPesquisaClientesEditar cadastracliente = new FormPesquisaClientesEditar();
                        cadastracliente.MdiParent = FormPesquisaClientesEditar.ActiveForm;
                        cadastracliente.Show();
                        cadastracliente.Top = 0;
                        cadastracliente.Left = 0;

                        string strConexao1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";

                        Conexao conexao1 = new Conexao(strConexao1);
                        DALCadastro dal1 = new DALCadastro(conexao1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de acesso ao banco de Dados-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------. ", ex.Message);
                }
            }
        }

        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
