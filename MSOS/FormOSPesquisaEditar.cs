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
using System.Drawing.Imaging;

namespace MSOS
{
    public partial class FormOSPesquisaEditar : Form
    {
        private string operacao = "";

        Bitmap bmp;

        private int VERIFICADORIMAGEM = 0;
        public int VerficidorImagem
        {
            get
            {
                return this.VERIFICADORIMAGEM;

            }
            set
            {
                this.VERIFICADORIMAGEM = value;
            }
        }

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
        private Image IMAGEM = null ;
        public Image Imagem
        {
            get
            {
                return this.IMAGEM;

            }
            set
            {
                this.IMAGEM = value;
            }
        }
        private string IMGLOCATION = "";
        public string ImgLocation
        {
            get
            {
                return this.IMGLOCATION;

            }
            set
            {
                this.IMGLOCATION = value;
            }
        }
        //CHAMA O METODO CancelaCadastradoCliente QUE FECHA FORMULÁRIOS ABERTOS
        public void FecharFormulario()
        {
            CancelaEditorOs(typeof(FormOSPesquisaEditar));

        }
        //METODO PARA VERIFICA SE O FORMULÁRIO ESTA ABERTO SE TIVER ELE FECHA!
        public static void CancelaEditorOs(Type frmType)
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
        }        private void buttonFecharOs_Click(object sender, EventArgs e)
        {
            FecharFormulario();
        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            buttonAnexo.Enabled = false;
            buttonAnexo.Visible = false;

            //Acessa Banco de Dados e Salvar Alteração da Os
            string strConexao = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao = new Conexao(strConexao);
            DALCadastro da = new DALCadastro(conexao);

            //Acessa Banco de Dados e Salvar Imagem 
            string strConexao1 = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016";
            Conexao conexao1 = new Conexao(strConexao1);
            DALCadastro da1 = new DALCadastro(conexao1);

            Os cadastra = new Os();
            cadastra.IdOs = IdOs;
            cadastra.OrigemChamado = txtOrigemChamado.Text;
            cadastra.ServicosExecutados = txtServicoExecutado.Text;
            cadastra.MudancaDataFechamento = 0;

            //VERIFICA SE IMAGEM CONSTA NO SISTEMA! 
            String connectionString = "Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016;";
            SqlConnection conn = new SqlConnection(connectionString);
           
            SqlDataAdapter da2 = new SqlDataAdapter("EXEC ConsultaOsImagemValidar "+ IdOs +";", conn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            //----------------------------------------------------------------------------------------------

            OsImagem Imagem = new OsImagem();
            Imagem.IdOs = IdOs;

            if(bmp == null)
            {
                VerficidorImagem = 1;
            }
            if(bmp != null)
            {
                MemoryStream memory = new MemoryStream();

                bmp.Save(memory, ImageFormat.Bmp);

                byte[] Foto = memory.ToArray();

                Imagem.Imagem = Foto;
            }
            
            if (operacao == "Editar")
            {
                if ((maskedTxtHorarioInicio.Text == "") && (maskedTxtHorarioFInal.Text == "") && (bmp == null))
                {
                    if (checkBoxFinalizarOS.Checked == false)
                    {
                        FecharFormulario();

                        cadastra.Estado = 1;

                        da.AlteraOS(cadastra);   

                        MessageBox.Show("Alteração da ordem de serviço realizada com sucesso! ");

                    }

                    if (checkBoxFinalizarOS.Checked == true)
                    {
                        MessageBox.Show("A ordem de serviço não pode se finalizada sem o preenchimento de horário inicial e horário final!");
                    }
                }
                if ((maskedTxtHorarioInicio.Text=="") && (maskedTxtHorarioFInal.Text == "") && !(bmp == null))
                {
                    if (checkBoxFinalizarOS.Checked == false)
                    {
                        FecharFormulario();

                        cadastra.Estado = 1;

                        conn.Open();

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            da.AlteraOS(cadastra);
                            da1.AlterarOsImagem(Imagem);
                        }
                        if (!(ds2.Tables[0].Rows.Count > 0))
                        {
                            da.AlteraOS(cadastra);
                            da1.IncluirOsImagem(Imagem);
                        }
                        conn.Close();

                        MessageBox.Show("Alteração da ordem de serviço realizada com sucesso! - Imagem Salvar");
                    }
                    if (checkBoxFinalizarOS.Checked == true)
                    {
                        MessageBox.Show("A ordem de serviço não pode se finalizada sem o preenchimento de horário inicial e horário final!");
                    }
                }
                if ((!(maskedTxtHorarioInicio.Text == "")&& (maskedTxtHorarioFInal.Text == "")) || ((maskedTxtHorarioInicio.Text == "") && !(maskedTxtHorarioFInal.Text == "")))
                {
                    MessageBox.Show("O horário não foi preenchido corretamente! ");
                }
                if (!(maskedTxtHorarioInicio.Text == "") && !(maskedTxtHorarioFInal.Text == "") && (bmp == null))
                {
                    if (checkBoxFinalizarOS.Checked == false)
                    {
                        FecharFormulario();
                        cadastra.Estado = 2;
                        cadastra.HorarioInicio = maskedTxtHorarioInicio.Text;
                        cadastra.HorarioFinal = maskedTxtHorarioFInal.Text;

                        da.AlteraOS(cadastra);

                        MessageBox.Show("Alteração da ordem de serviço realizada com sucesso! - Em Processo!");
                    }
                }
                if (!(maskedTxtHorarioInicio.Text == "") && !(maskedTxtHorarioFInal.Text == "") && !(bmp == null))
                {
                    if (checkBoxFinalizarOS.Checked == false)
                    {
                        FecharFormulario();
                        cadastra.Estado = 2;
                        cadastra.HorarioInicio = maskedTxtHorarioInicio.Text;
                        cadastra.HorarioFinal = maskedTxtHorarioFInal.Text;

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            da.AlteraOS(cadastra);
                            da1.AlterarOsImagem(Imagem);
                        }
                        if (!(ds2.Tables[0].Rows.Count > 0))
                        {
                            da.AlteraOS(cadastra);
                            da1.IncluirOsImagem(Imagem);
                        }

                        MessageBox.Show("Alteração da ordem de serviço realizada com sucesso! - Em Processo! - Imagem Salvar");
                    }
                    if ((checkBoxFinalizarOS.Checked == true) && (bmp == null))
                    {
                        DialogResult dialogResult = MessageBox.Show("Deseja finalizar a ordem de Serviço!", "Aviso", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            FecharFormulario();
                            cadastra.MudancaDataFechamento = 1;
                            cadastra.Estado = 3;
                            cadastra.HorarioInicio = maskedTxtHorarioInicio.Text;
                            cadastra.HorarioFinal = maskedTxtHorarioFInal.Text;

                            panel.Enabled = false;
                            buttonEditarOSe.Enabled = false;
                            buttonVerifica.Enabled = false;

                            da.AlteraOS(cadastra);

                            MessageBox.Show("Alteração da ordem de serviço realizada com sucesso! - Já Finalizada!");

                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                    if ((checkBoxFinalizarOS.Checked == true) && !(bmp == null))
                    {
                        DialogResult dialogResult = MessageBox.Show("Deseja finalizar a ordem de Serviço!", "Aviso", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            FecharFormulario();
                            cadastra.MudancaDataFechamento = 1;
                            cadastra.Estado = 3;
                            cadastra.HorarioInicio = maskedTxtHorarioInicio.Text;
                            cadastra.HorarioFinal = maskedTxtHorarioFInal.Text;

                            panel.Enabled = false;
                            buttonEditarOSe.Enabled = false;
                            buttonVerifica.Enabled = false;

                            conn.Open();

                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                da.AlteraOS(cadastra);
                                da1.AlterarOsImagem(Imagem);
                            }
                            if (!(ds2.Tables[0].Rows.Count > 0))
                            {
                                da.AlteraOS(cadastra);
                                da1.IncluirOsImagem(Imagem);
                            }
                            conn.Close();

                            MessageBox.Show("Alteração da ordem de serviço realizada com sucesso! - Já Finalizada!");

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("Sem Salvar não ocorre alteração!");
                        }
                    }
                }
            }
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
            e.Graphics.DrawString("" + txtNomeContatoCliente.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(162, 222));
            e.Graphics.DrawString("" + txtTelefoneOs.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(162, 245));
            e.Graphics.DrawString("" + txtNomeFuncionario.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(162, 944));
            e.Graphics.DrawString("" + InsereQuebra(txtServicoExecutado.Text), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(12, 488));
        }
        public static string InsereQuebra(string TEXTO_GRANDE)
        {
            try
            {
                //obtendo o texto passado no parametro
                string texto = TEXTO_GRANDE;
                //substituindo qq tipo de aspas por apóstrofe
                texto = Regex.Replace(texto, @"[\u2018\u2019\u201a\u201b\u0022\u201c\u201d\u201e\u201f\u301d\u301e\u301f]", "'", RegexOptions.IgnoreCase);
                //removendo linhas em branco
                texto = Regex.Replace(texto, @"\s+\n", "\n", RegexOptions.IgnoreCase);
                //removendo espaços em branco no começo e no fim do texto
                texto = texto.Trim();
                //declarando variáveis de controle          
                int espaco = 0;
                int indice = 0;
                int inc = 0;

                Match m = Regex.Match(texto, "\n", RegexOptions.IgnoreCase);
                int QTDE_ESPACO = 10;
                if (!m.Success)
                {
                    //removendo espaços em branco
                    texto = Regex.Replace(texto, @"\s\s+", " ");
                    foreach (char c in texto)
                    {
                        indice++;
                        if (char.IsWhiteSpace(c))
                        {
                            espaco++;
                            //Com 120 espacos os paragrafos ficam com cerca de 5 linhas
                            if (espaco % QTDE_ESPACO == 0)
                            {
                                texto = texto.Insert(indice + inc, "\n");
                                inc++;
                            }
                        }
                    }
                }
                return texto;
            }
            catch (Exception exp)
            {
                return "";
            }
        }
        private void FormOSPesquisaEditar_Load(object sender, EventArgs e)
        {
            //InitializeComponent();
        }
        public FormOSPesquisaEditar(int STATUS,string ORDEM_SERVICO,string SOLICITACAO,string CLIENTE,string MS,string LOGRADOURO,string ENDERECO,
            string COMPLEMENTO,string NUMERO,string BAIRRO,string CIDADE,string NOME_CONTATO,string TELEFONE,
            string ORIGEM_SERVICO, string SERVICOS_EXECUTADOS, string TECNICOS,string HORARIO_INICIO,string HORARIO_FINAL)
        {
            InitializeComponent();
            
            this.status = STATUS;

            if (this.status == 1)
            {
                buttonEditarOSe.Enabled = true;
                buttonVerifica.Enabled = false;
            }
            if (this.status == 2)
            {
                buttonEditarOSe.Enabled = true;
                buttonVerifica.Enabled = false;

            }
            if (this.status == 3)
            {
                buttonEditarOSe.Enabled = false;
                buttonVerifica.Enabled = false;
            }
            this.IdOs = int.Parse(ORDEM_SERVICO);
            txtNumeroOrdemServico.Text = ORDEM_SERVICO;
            txtDataSolicitacao.Text = SOLICITACAO;
            txtNomeOS.Text = CLIENTE;
            txtMsOs.Text = MS;
            txtTipo_logradouro.Text = LOGRADOURO;
            txtEnderecoOS.Text = ENDERECO;
            txtComplOs.Text = COMPLEMENTO;
            txtBairroNumero.Text = NUMERO;
            txtBairroOS.Text = BAIRRO;
            txtCidadeOs.Text = CIDADE;
            txtNomeContatoCliente.Text = NOME_CONTATO;
            txtTelefoneOs.Text = TELEFONE;
            txtOrigemChamado.Text = ORIGEM_SERVICO;
            txtServicoExecutado.Text = SERVICOS_EXECUTADOS;
            txtNomeFuncionario.Text = TECNICOS;
            maskedTxtHorarioInicio.Text = HORARIO_INICIO;
            maskedTxtHorarioFInal.Text = HORARIO_FINAL;
        }

        private void buttonEditarOSe_Click(object sender, EventArgs e)
        {
   
            this.operacao = "Editar";

            buttonAnexo.Enabled = true;
            buttonAnexo.Visible = true;


            if (this.status == 1)
            {
                AlteraBotoes(1);
            }
            if (this.status == 2)
            {
                AlteraBotoes(2);
            }
            if (this.status == 3)
            {
                AlteraBotoes(3);
            }
        }
        public void AlteraBotoes(int op)
        {
            if (op == 1)// Editar
            {
                this.panel.Enabled = true;
                this.buttonEditarOSe.Enabled = false;
                this.buttonVerifica.Enabled = true;

                this.txtOrigemChamado.Enabled = true;
                this.txtServicoExecutado.Enabled = true;
                this.maskedTxtHorarioInicio.Enabled = true;
                this.maskedTxtHorarioFInal.Enabled = true;
                this.checkBoxFinalizarOS.Enabled = true;
            }
            if (op == 2)//Tela De Alteração Bloqueiada!
            {
                this.panel.Enabled = true;
                this.buttonEditarOSe.Enabled = false;
                this.buttonVerifica.Enabled = true;

                this.txtOrigemChamado.Enabled = true;
                this.txtServicoExecutado.Enabled = true;
                this.maskedTxtHorarioInicio.Enabled = false;
                this.maskedTxtHorarioFInal.Enabled = false;
                this.checkBoxFinalizarOS.Enabled = true;

                // ButtonEditarFornecedorFisica.Enabled = true;
            }
            if (op == 3) //Tela Editar Cadastro Fisico!
            {
                this.panel.Enabled = false;
                this.buttonEditarOSe.Enabled = false;
                this.buttonVerifica.Enabled = false;

                this.txtOrigemChamado.Enabled = false;
                this.txtServicoExecutado.Enabled = false;
                this.maskedTxtHorarioInicio.Enabled = false;
                this.maskedTxtHorarioFInal.Enabled = false;
                this.checkBoxFinalizarOS.Enabled = false;

            }
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            Caixa_setup.Document = printDocumentOs;
            Caixa_setup.ShowDialog();
        }

        private void buttonImprimirOS_Click(object sender, EventArgs e)
        {
            printPreviewDialogOs.Document = printDocumentOs;
            printPreviewDialogOs.ShowDialog();
        }

        private void buttonAnexo_Click(object sender, EventArgs e)
        {
             openFileDialog.Filter = "JPG Files(*.jpg)|*.jpg|JPG Files(*.png)|*.png";// all files(*.*) | *.*

            DialogResult dialogResult = MessageBox.Show("Deseja Anexa uma imagem!", "Aviso", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    openFileDialog.ShowDialog();
                    ImgLocation = openFileDialog.FileNames.ToString();
                    //label15.Text = Dialog.FileNames.ToString();
                    label15.Text = openFileDialog.FileName;

                    pictureBoxImagem.Image = Image.FromFile(openFileDialog.FileName);

                    bmp = new Bitmap(label15.Text);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }


            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Cancelado o Anexo da Imagem!");
            }
        }

        private void buttonAbrirAnexo_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=PROGRAMAS;Initial Catalog=MSOS;Persist Security Info=True;User ID=sa;Password=dellm@ster2016");
            SqlCommand comand = new SqlCommand("ConsultaOsImagemSalva "+ IdOs+";", conn);
            conn.Open();

            SqlDataReader reader = comand.ExecuteReader();

            if (reader.Read())
            {
                byte[] Foto = (byte[])reader["IMAGEM"];
                MemoryStream ms = new MemoryStream(Foto);
                Imagem = Image.FromStream(ms);
            }
            if (Imagem == null)
            {
                MessageBox.Show("Não existir Imagem!");
            }
            if (Imagem != null)
            {
                pictureBoxImagem.Image = Imagem;
            }
        }
        private void buttonImprimirAnexo_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Caixa_setupImagem.Document = printDocumentImagem;
            Caixa_setupImagem.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialogOs.Document = printDocumentImagem;
            printPreviewDialogOs.ShowDialog();
        }

        private void printDocumentImagem_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (Imagem == null)
            {
                MessageBox.Show("Carrega a Foto Antes dese Impresso!");
            }
            if (Imagem != null)
            {
                Point p = new Point(0, 0);
                e.Graphics.DrawImage(Imagem, p);
            }
        }
    }
}
