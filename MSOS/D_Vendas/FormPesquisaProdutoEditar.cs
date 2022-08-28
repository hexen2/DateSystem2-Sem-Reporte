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
using System.IO;
using System.Drawing.Imaging;
using System.Globalization;
using System.Drawing.Printing;

namespace DateSystem
{
    public partial class FormPesquisaProdutoEditar : Form
    {
        Bitmap bmp;
        Bitmap bmp2;

        Boolean ImagemAnexa = false;
        Boolean ImagemAnexa2 = false;
        Boolean ImagemExiste = false;
        Boolean ImagemExiste2 = false;

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
        private string IMGLOCATION2 = "";
        public string ImgLocation2
        {
            get
            {
                return this.IMGLOCATION2;

            }
            set
            {
                this.IMGLOCATION2 = value;
            }
        }
        private Image IMAGEM = null;
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
        private Image IMAGEM2 = null;
        public Image Imagem2
        {
            get
            {
                return this.IMAGEM2;

            }
            set
            {
                this.IMAGEM2 = value;
            }
        }
        string Editar = "";
        private int IDPRODUTO = 0;
        public int IdProduto
        {
            get
            {
                return this.IDPRODUTO;

            }
            set
            {
                this.IDPRODUTO = value;
            }
        }
        private int PRODUTOEDITAR = 0;
        public int ProdutoEditar
        {
            get
            {
                return this.PRODUTOEDITAR;

            }
            set
            {
                this.PRODUTOEDITAR = value;
            }
        }
        private int PRODUTOEXCLUIR = 0;
        public int ProdutoExcluir
        {
            get
            {
                return this.PRODUTOEXCLUIR;

            }
            set
            {
                this.PRODUTOEXCLUIR = value;
            }
        }
        private string NOMESERVIDOR = "";
        public string NomeServidor
        {
            get
            {
                return this.NOMESERVIDOR;

            }
            set
            {
                this.NOMESERVIDOR = value;
            }
        }
        private string BASE_DADOS = "";
        public string BaseDados
        {
            get
            {
                return this.BASE_DADOS;

            }
            set
            {
                this.BASE_DADOS = value;
            }
        }
        private string NOMEBASEDADOS = "";
        public string NomeBaseDados
        {
            get
            {
                return this.NOMEBASEDADOS;

            }
            set
            {
                this.NOMEBASEDADOS = value;
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
        private string SENHABASEDADOS = "";
        public string SenhaBaseDados
        {
            get
            {
                return this.SENHABASEDADOS;

            }
            set
            {
                this.SENHABASEDADOS = value;
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
        public FormPesquisaProdutoEditar(int ID_PRODUTO,string NomeServidor, string NomeBaseDados, string NomeUsuario,
            string SenhaBaseDados,int PRODUTOEDITAR, int PRODUTOEXCLUIR)
        {
            InitializeComponent();

            this.NomeServidor = NomeServidor;
            this.NomeBaseDados = NomeBaseDados;
            this.NomeUsuario = NomeUsuario;
            this.SenhaBaseDados = SenhaBaseDados;
            this.ProdutoEditar = PRODUTOEDITAR;
            this.ProdutoExcluir = PRODUTOEXCLUIR;

            this.connetionString = "Data Source=" + this.NomeServidor + ";Initial Catalog=" + this.NomeBaseDados + ";Persist Security Info=True;User ID=" + this.NomeUsuario + ";Password=" + this.SenhaBaseDados + ";";

            txtObservacao.MaxLength = 50;
            txtOrigemProduto.MaxLength = 50;

            if (ProdutoEditar == 0)
            {
                buttonProdutoEditar.Enabled = false;
            }
            if (ProdutoEditar == 1)
            {
                buttonProdutoEditar.Enabled = true;
            }


            SqlConnection conn1 = new SqlConnection(this.connetionString);
            string sql1 = "exec D_V_ConsultaEditarProdutoVendaTxt " + ID_PRODUTO;
            SqlDataAdapter sda1 = new SqlDataAdapter(sql1, conn1);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1);

            QuantidadeProdutoCadastrado();

            this.IdProduto = ID_PRODUTO;

            txtCodigoProduto.Text = " N° " + ds1.Tables[0].Rows[0][0].ToString();

            // CODIGO PRODOUTOS
            comboBoxDescricaoProduto.Text = ds1.Tables[0].Rows[0][1].ToString();
            comboBoxMarca.Text = ds1.Tables[0].Rows[0][39].ToString();
            comboBoxCartegoria.Text = ds1.Tables[0].Rows[0][41].ToString();
            comboBoxFornecedor.Text = ds1.Tables[0].Rows[0][43].ToString();
            comboBoxUnidade.Text = ds1.Tables[0].Rows[0][44].ToString();
            txtPrecoCusto.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][7].ToString());
            txtCustoMedio.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][8].ToString());
            txtMargemLucro.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][10].ToString());
            txtPrecoVenda.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][9].ToString());
            dateTimePickerUltimoReajuste.Text = ds1.Tables[0].Rows[0][11].ToString();
            txtQuantidadeAtualEstoque.Text = ds1.Tables[0].Rows[0][13].ToString();
            txtQuantidadeMinimaEstoque.Text = ds1.Tables[0].Rows[0][14].ToString();
            txtQuantidadeComprada.Text = ds1.Tables[0].Rows[0][36].ToString();
            dateTimePickerSolicitacao.Text = ds1.Tables[0].Rows[0][12].ToString();
            txtCodigoInterno.Text = ds1.Tables[0].Rows[0][17].ToString();
            txtObservacao.Text = ds1.Tables[0].Rows[0][18].ToString();
            if (ds1.Tables[0].Rows[0][20].ToString().Equals(""))
            {

            }else txtDescricaoCstIcms.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][20].ToString());
            if (ds1.Tables[0].Rows[0][21].ToString().Equals(""))
            {

            }else txtBaseIcms.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][21].ToString());

            if (ds1.Tables[0].Rows[0][23].ToString().Equals(""))
            {

            }else txtDescricaoCstPis.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][23].ToString());
            if (ds1.Tables[0].Rows[0][24].ToString().Equals(""))
            {

            }else txtPis.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][24].ToString());

            if (ds1.Tables[0].Rows[0][26].ToString().Equals(""))
            {

            }else txtDescricaoCofins.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][26].ToString());
            if (ds1.Tables[0].Rows[0][27].ToString().Equals(""))
            {

            }else txtConfins.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][27].ToString());
            if (ds1.Tables[0].Rows[0][29].ToString().Equals(""))
            {

            }else txtDescricaoIpI.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][29].ToString());
            if (ds1.Tables[0].Rows[0][30].ToString().Equals(""))
            {

            }else txtIpi.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][30].ToString());
            //if ()
            //{

            //}
            //else
            txtCodigoGtin.Text = ds1.Tables[0].Rows[0][31].ToString();
            if (ds1.Tables[0].Rows[0][32].ToString().Equals(""))
            {

            }else txtPesoBruto.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][32].ToString());
            if (ds1.Tables[0].Rows[0][33].ToString().Equals(""))
            {

            }else txtPesoLiquido.Text = AdicionadoVZ(ds1.Tables[0].Rows[0][33].ToString());

            dateTimePickerPrevisaoChegada.Text = ds1.Tables[0].Rows[0][34].ToString();

            txtOrigemProduto.Text = ds1.Tables[0].Rows[0][35].ToString();


            int impressora = 0;
            int status = 0;

            impressora = int.Parse(ds1.Tables[0].Rows[0][15].ToString());
            status = int.Parse(ds1.Tables[0].Rows[0][16].ToString());

            if (impressora == 2)
            {
                checkBoxnaoImprimir.Checked = false;
            }
            if (impressora == 1)
            {
                checkBoxnaoImprimir.Checked = true;
            }

            if (status == 2)
            {
                checkBoxAtivo.Checked = false;
            }
            if (status == 1)
            {
                checkBoxAtivo.Checked = true;
            }
            ImagemProduto();
            ImagemProduto2();
        }
        private void FormPesquisaProdutoEditar_Load_1(object sender, EventArgs e)
        {

        }
        public void QuantidadeProdutoCadastrado()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_V_ConsultaCadastroNProduto ", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (!(ds.Tables[0].Rows.Count > 0))
            {
                txtNitensCadastrados.Text = "Não tem registro de itens cadastrados.";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                string numero = ds.Tables[0].Rows[0][0].ToString(); ;

                txtNitensCadastrados.Text = "N° " + numero.ToString() + " de itens cadastrado";
            }
        }
        public void ImagemProduto()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);
            SqlCommand comand = new SqlCommand("D_V_ConsultaImagemProduto " + this.IdProduto + ";", conn);
            conn.Open();

            SqlDataReader reader = comand.ExecuteReader();

            if (reader.Read())
            {
                byte[] Foto = (byte[])reader["IMAGEM"];
                MemoryStream ms = new MemoryStream(Foto);
                Imagem = Image.FromStream(ms);
            }
            //if (Imagem == null)
            //{
            //    MessageBox.Show("Não existir Imagem!");
            //}
            if (Imagem != null)
            {
                pictureBoxImagem.Image = Imagem;
                ImagemExiste = true;
            }
        }
        public void ImagemProduto2()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);
            SqlCommand comand = new SqlCommand("D_V_ConsultaImagemProduto2 " + this.IdProduto + ";", conn);
            conn.Open();

            SqlDataReader reader = comand.ExecuteReader();

            if (reader.Read())
            {
                byte[] Foto = (byte[])reader["IMAGEM2"];
                MemoryStream ms = new MemoryStream(Foto);
                Imagem2 = Image.FromStream(ms);
            }
            //if (Imagem == null)
            //{
            //    MessageBox.Show("Não existir Imagem!");
            //}
            if (Imagem2 != null)
            {
                pictureBoxImagem2.Image = Imagem2;
                ImagemExiste2 = true;
            }
        }
        public void AlterarBotao(int botao)
        {
            if(botao == 1)
            {
                panelGeral.Enabled = true;
                buttonProdutoEditar.Enabled = false;
                buttonProdutoSalvar.Enabled = true;
                Editar = "Editar";
            }
            if (botao == 2)
            {

            }
        }
        public static void Moeda(ref TextBox txt)
        {
            string n = string.Empty;

            double v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro" + e);
            }
        }
        public static void Moeda2(ref TextBox txt)
        {
            string n = string.Empty;

            double v = 0;

            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                    n = "";
                n = n.PadLeft(3, '0');
                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);
                v = Convert.ToDouble(n) / 100;
                txt.Text = string.Format("{0:F}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro" + e);
            }
        }
        public static string AdicionadoVZ(string VALORES)
        {
            try
            {
                Boolean vigula = false;

                StringBuilder sb = new StringBuilder(VALORES);

                int quantString = VALORES.Length;

                for (int i = 0; i < quantString; i++)
                {
                    if(VALORES[i] == ',')
                    {
                        vigula = true;
                        break;
                    }
                    
                }
                if(vigula == false)
                {
                    sb.Insert(quantString, ",00");
                    VALORES = sb.ToString();
                }
                return VALORES;
            }

            catch (Exception exp)
            {
                return exp.ToString();
            }
        }
        private void buttonProdutoEditar_Click(object sender, EventArgs e)
        {
            AlterarBotao(1);
        }

        private void buttonProdutoSalvar_Click(object sender, EventArgs e)
        {
            ProdutoSalvar();
        }
        public void ProdutoSalvar()
        {
            if(Editar == "Editar")
            {
                CadastraProdutos AltercaoProdutos = new CadastraProdutos();
                AltercaoProdutos.IdProduto = this.IdProduto;

                AltercaoProdutos.Observacao = txtObservacao.Text;

                if (checkBoxnaoImprimir.Checked == false)
                {
                    AltercaoProdutos.ImprimirProduto = 2;
                }
                if (checkBoxnaoImprimir.Checked == true)
                {
                    AltercaoProdutos.ImprimirProduto = 1;
                }

                //Salvar Cadastro de Produto no sistema
                Conexao conexao = new Conexao(this.connetionString);
                DALCadastro2 da = new DALCadastro2(conexao);

                da.AlterarProduto(AltercaoProdutos);
                MessageBox.Show("Produto Cadastrado com exito!");

                //Salvar Imagem em Base de Dados
                Conexao conexao1 = new Conexao(this.connetionString);
                DALCadastro2 da1 = new DALCadastro2(conexao1);
                //Salvar Imagem em Base de Dados 2
                Conexao conexao2 = new Conexao(this.connetionString);
                DALCadastro2 da2 = new DALCadastro2(conexao2);

                ProdutoImagem ImagemProduto = new ProdutoImagem();
                ProdutoImagem2 ImagemProduto2 = new ProdutoImagem2();

                ImagemProduto.IdProduto = this.IdProduto;
                ImagemProduto2.IdProduto2 = this.IdProduto;

                FecharTodosFormulario();

                if (ImagemAnexa == true)
                {
                    //imagem 1
                    MemoryStream memory = new MemoryStream();

                    bmp.Save(memory, ImageFormat.Bmp);

                    byte[] Foto = memory.ToArray();

                    ImagemProduto.Imagem = Foto;

                    if(ImagemExiste == true)
                    {
                        da1.AlterarProdutoImagem(ImagemProduto);
                    }
                    if(ImagemExiste == false)
                    {
                        da1.IncluirProdutoImagem(ImagemProduto);
                    }
                    
                }
                if (ImagemAnexa2 == true)
                {
                    //imagem 2
                    MemoryStream memory2 = new MemoryStream();

                    bmp2.Save(memory2, ImageFormat.Bmp);

                    byte[] Foto2 = memory2.ToArray();

                    ImagemProduto2.Imagem2 = Foto2;

                    if (ImagemExiste2 == true)
                    {
                        da1.AlterarProdutoImagem2(ImagemProduto2);
                    }
                    if (ImagemExiste2 == false)
                    {
                        da1.IncluirProdutoImagem2(ImagemProduto2);
                    }
                }
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
            CancelaPesquisaCliente(typeof(FormPesquisaProdutoEditar));
        }

        private void buttonProdutoFechar_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }

        private void buttonAnexo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPG Files(*.png)|*.png";// all files(*.*) | *.*

            DialogResult dialogResult = MessageBox.Show("Deseja Anexa uma imagem!", "Aviso", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    openFileDialog1.ShowDialog();
                    ImgLocation = openFileDialog1.FileNames.ToString();
                    //label15.Text = Dialog.FileNames.ToString();
                    label49.Text = openFileDialog1.FileName;
                    pictureBoxImagem.Image = Image.FromFile(openFileDialog1.FileName);
                    bmp = new Bitmap(label49.Text);
                    ImagemAnexa = true;
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

        private void buttonAnexo2_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "JPG Files(*.jpg)|*.jpg|JPG Files(*.png)|*.png";// all files(*.*) | *.*

            DialogResult dialogResult = MessageBox.Show("Deseja Anexa uma imagem!", "Aviso", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    openFileDialog2.ShowDialog();
                    ImgLocation2 = openFileDialog2.FileNames.ToString();
                    //label15.Text = Dialog.FileNames.ToString();
                    label49.Text = openFileDialog2.FileName;
                    pictureBoxImagem2.Image = Image.FromFile(openFileDialog2.FileName);
                    bmp2 = new Bitmap(label49.Text);
                    ImagemAnexa2 = true;
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
    }
}
