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
    public partial class FormPesquisaCadastraRegistroEditar : Form
    {
        DataTable TableTodos;

        private int NumeroOfItensPorPaginas = 0;

        private Graphics Graphics2 { get; set; }

        private Margins Margins2 { get; set; }

        private PageSettings PageSettings2 { get; set; }

        private PrintPageEventArgs PrintPageEventArgs { get; set; }


        string _texto;

        TextBox TotalLinha = new TextBox();

        string Operacao = "";
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
        private int REGISTROCADASTRA = 0;
        public int RegistroCadastra
        {
            get
            {
                return this.REGISTROCADASTRA;

            }
            set
            {
                this.REGISTROCADASTRA = value;
            }
        }
        private int REGISTROVISUALIZAR = 0;
        public int RegistroVisualizar
        {
            get
            {
                return this.REGISTROVISUALIZAR;

            }
            set
            {
                this.REGISTROVISUALIZAR = value;
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
        private int FINALIZADO = 0;
        public int Finalizado
        {
            get
            {
                return this.FINALIZADO;

            }
            set
            {
                this.FINALIZADO = value;
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
        private string NOMECLIENTE1 = "";
        public string NomeCliente1
        {
            get
            {
                return this.NOMECLIENTE1;

            }
            set
            {
                this.NOMECLIENTE1 = value;
            }
        }
        private string NOMEUSUARIOLOGADO = "";
        public string NomeUsuarioLogado
        {
            get
            {
                return this.NOMEUSUARIOLOGADO;

            }
            set
            {
                this.NOMEUSUARIOLOGADO = value;
            }
        }
        // VALIDAR ENTRADA COM ERROPROVIDER
        private Boolean validaNome(TextBox textBox, ErrorProvider errorProvider)
        {
            if (!String.IsNullOrWhiteSpace(txtNomeRegistro.Text))
            {
                errorProviderCadastraRegistroEditar.SetError(textBox, "");
                return true;
            }
            else
            {
                errorProviderCadastraRegistroEditar.SetError(textBox, "Abreviação Inválido!");
                return false;
            }
        }

        public void Calcular()
        {
            
        }
        public FormPesquisaCadastraRegistroEditar()
        {
            InitializeComponent();
        }
        public FormPesquisaCadastraRegistroEditar(int IDREGISTRO1, int REGISTROVISUALIZAR1, int REGISTROEDITAR1,
                        int REGISTROEXCLUIR1, int IDPESSOLOGADA1, string CONNETIONSTRING1, int CADASTRAREGISTRO1,
                        string NOMEPESSOALOGADA1)
        {
            InitializeComponent();

            this.IdRegistro = IDREGISTRO1;
            this.RegistroVisualizar = REGISTROVISUALIZAR1;
            this.RegistroEditar = REGISTROEDITAR1;
            this.RegistroExcluir = REGISTROEXCLUIR1;
            this.IdPessoaLogada = IDPESSOLOGADA1;
            this.connetionString = CONNETIONSTRING1;
            this.RegistroCadastra = CADASTRAREGISTRO1;
            this.NomeUsuarioLogado = NOMEPESSOALOGADA1;

            txtOrigemRegistro.MaxLength = 1000;

            if (RegistroVisualizar == 0)
            {
                dataGridViewRegistroSub.Enabled = false;
            }
            if (RegistroVisualizar == 1)
            {
                dataGridViewRegistroSub.Enabled = true;
            }
            if (RegistroCadastra == 0)
            {
                buttonCadastraSubRegistro.Enabled = false;
            }
            if (RegistroCadastra == 1)
            {
                buttonCadastraSubRegistro.Enabled = true;
            }

            PesquisaRegistroEditar();
            PesquisaRegistroSubEditar();
        }
        public void PesquisaRegistroEditar()
        {
            SqlConnection conn = new SqlConnection(this.connetionString);

            SqlDataAdapter da = new SqlDataAdapter("EXEC D_R_ConsultaRegistroGeradoNEditartxt " + IdRegistro + ";", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (!(ds.Tables[0].Rows.Count > 0))
            {
                FecharTodosFormulario();
                conn.Close();
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtNumeroDoRegistro.Text = ds.Tables[0].Rows[0][0].ToString();
                txtDataSolicitacaoProcesso.Text = ds.Tables[0].Rows[0][8].ToString();
                txtNomeRegistro.Text = ds.Tables[0].Rows[0][17].ToString();
                txtNumeroRegistro.Text = ds.Tables[0].Rows[0][1].ToString();
                txtTipo_logradouro.Text = ds.Tables[0].Rows[0][45].ToString();
                txtEnderecoRegistro.Text = ds.Tables[0].Rows[0][46].ToString();
                txtComplRegistro.Text = ds.Tables[0].Rows[0][48].ToString();
                txtBairroNumero.Text = ds.Tables[0].Rows[0][47].ToString();
                txtBairroRegistro.Text = ds.Tables[0].Rows[0][49].ToString();
                txtCidadeRegistro.Text = ds.Tables[0].Rows[0][51].ToString();
                txtTelefoneRegistro.Text = ds.Tables[0].Rows[0][17].ToString();
                txtNomeContato.Text = ds.Tables[0].Rows[0][54].ToString();

                this.NomeCliente1 = txtNomeRegistro.Text;

                this.IdPessoa = int.Parse(ds.Tables[0].Rows[0][1].ToString());

                label8.Text = ds.Tables[0].Rows[0][55].ToString();

                if (ds.Tables[0].Rows[0][63].ToString() == "")
                {
                    NomeLogado.Text = "Usuário Criadoo: " + ds.Tables[0].Rows[0][62].ToString();
                }
                if (!(ds.Tables[0].Rows[0][63].ToString() == ""))
                {
                    NomeLogado.Text = "Usuário alterou: " + ds.Tables[0].Rows[0][63].ToString();
                }

                maskedtxtTelefoneContato.Text = ds.Tables[0].Rows[0][56].ToString();


                txtOrigemRegistro.Text = ds.Tables[0].Rows[0][7].ToString();
                txtDataContatoRegistro.Text = ds.Tables[0].Rows[0][9].ToString();

                Situacao = int.Parse(ds.Tables[0].Rows[0][4].ToString());
                if (Situacao == 2)
                {
                    checkBoxSituacao.Checked = false;
                }
                if (Situacao == 1)
                {
                    checkBoxSituacao.Checked = true;
                }
                Finalizado = int.Parse(ds.Tables[0].Rows[0][3].ToString());

                if (Finalizado == 1 || Finalizado == 2)
                {
                    checkBoxFinalizarRegistro.Checked = false;

                    if (RegistroEditar == 0)
                    {
                        buttonCadastraRegistroEditar.Enabled = false;
                    }
                    if (RegistroEditar == 1)
                    {
                        buttonCadastraRegistroEditar.Enabled = true;
                    }
                }
                if (Finalizado == 3)
                {
                    checkBoxFinalizarRegistro.Checked = true;
                    checkBoxFinalizarRegistro.Enabled = false;
                }

                conn.Close();
            }
        }
        private void FormPesquisaCadastraRegistroEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void FormPesquisaCadastraRegistroEditar_Load(object sender, EventArgs e)
        {
            
        }
        private void buttonCancelarRegistro_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();

            FormPesquisaCadastraRegistroEditar CadastraRegistroEditar = new FormPesquisaCadastraRegistroEditar(
            this.IdRegistro, this.RegistroVisualizar, this.RegistroEditar, this.RegistroExcluir, this.IdPessoaLogada,
            this.connetionString, this.RegistroCadastra, this.NomeUsuarioLogado);
            CadastraRegistroEditar.MdiParent = FormPesquisaCadastraRegistroEditar.ActiveForm;
            CadastraRegistroEditar.Show();
            CadastraRegistroEditar.Top = 0;
        }
        public void FecharTodosFormulario()
        {
            CancelaCadastradoRegistro(typeof(FormPesquisaCadastraRegistroEditar));
            CancelaCadastradoRegistro(typeof(FormPesquisaCadastraRegistro));
        }
        public static void CancelaCadastradoRegistro(Type frmType)
        {
            bool bolCtl = false;
            Type a = frmType;
            //foreach (Form form in System.Windows.Forms.Application.OpenForms)
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
        private void buttonFecharRegistro_Click(object sender, EventArgs e)
        {
            FecharTodosFormulario();
        }
        private void PesquisaRegistroSubEditar()
        {
            try
            {
                // TODOS SUB - REGISTRO CADASTRADO
                SqlConnection conn = new SqlConnection(this.connetionString);

                SqlDataAdapter da1 = new SqlDataAdapter("EXEC D_R_ConsultaRegistroGeradoNSEditartxt " + IdRegistro + ";", conn);
                DataSet ds = new DataSet();
                da1.Fill(ds);

                dataGridViewRegistroSub.Refresh();

                label9.Text = dataGridViewRegistroSub.RowCount.ToString();

                conn.Open();

                if (!(ds.Tables[0].Rows.Count > 0))
                {
                    if (dataGridViewRegistroSub.DataSource == null)
                    {
                        dataGridViewRegistroSub.Refresh();
                    }
                    if (!(dataGridViewRegistroSub.DataSource == null))
                    {
                        // dataGridViewPesquisaCliente.Columns.Clear();
                        dataGridViewRegistroSub.Refresh();
                    }
                    label9.Text = dataGridViewRegistroSub.RowCount.ToString();

                    //MessageBox.Show("Não existe sub Registro Cadastrado!");
                    conn.Close();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    conn.Close();

                    dataGridViewPesquisaTodos();
                    label9.Text = dataGridViewRegistroSub.RowCount.ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void dataGridViewPesquisaTodos()
        {
            SqlConnection connection = new SqlConnection(this.connetionString);
            SqlCommand command = new SqlCommand("EXEC D_R_ConsultaRegistroGeradoNSEditartxt " + IdRegistro + ";", connection);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                TableTodos = new DataTable();
                adapter.Fill(TableTodos);
                BindingSource Source = new BindingSource();
                Source.DataSource = TableTodos;
                dataGridViewRegistroSub.DataSource = Source;
                adapter.Update(TableTodos);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void FecharFormulariosFilhos()
        {
            // percorre todos os formulários abertos
            for (int i = System.Windows.Forms.Application.OpenForms.Count - 1; i >= 0; i--)
            {
                i.ToString();
                if (System.Windows.Forms.Application.OpenForms[i].IsMdiChild)
                {
                    // fecha o formulário
                    System.Windows.Forms.Application.OpenForms[1].MdiParent.Close();
                    System.Windows.Forms.Application.OpenForms[i].Close();

                }
            }

        }
        private void buttonCadastraRegistroSub_Click(object sender, EventArgs e)
        {
            CadastraNovoRegistro();
        }
        public void CadastraNovoRegistro()
        {
            try
            {


                if (RegistroCadastra == 0)
                {
                    MessageBox.Show("Acesso não Permitido!");
                }
                if (RegistroCadastra == 1)
                {
                    FecharTodosFormulario();

                    timerRegistroNovo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void timerRegistro_Tick(object sender, EventArgs e)
        {
            timerRegistroNovo.Enabled = false;

            FormCadastraRegistro CadastraRegistro = new FormCadastraRegistro(this.IdPessoaLogada,
            this.connetionString, this.NomeUsuarioLogado);
            CadastraRegistro.MdiParent = FormCadastraRegistro.ActiveForm;
            CadastraRegistro.Show();
            CadastraRegistro.Top = 0;
        }
        private void dataGridViewRegistroSub_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RegistroVisualizar == 0)
            {
                try
                {
                    MessageBox.Show("Acesso não Permitido!");
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            if (RegistroVisualizar == 1)
            {
                try
                {
                    this.IdRegistroSub1 = Convert.ToInt32(dataGridViewRegistroSub["ID_REGISTROGERADOSUB", e.RowIndex].Value);

                    FormCadastraRegistroSubEditar CadastraRegistroEditar = new FormCadastraRegistroSubEditar(this.IdRegistro, this.IdRegistroSub1, this.RegistroEditar,
                    this.RegistroExcluir, this.IdPessoaLogada, this.connetionString);
                    CadastraRegistroEditar.MdiParent = FormCadastraRegistroSubEditar.ActiveForm;
                    CadastraRegistroEditar.Show();
                    CadastraRegistroEditar.Top = 0;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void buttonVerifica_Click(object sender, EventArgs e)
        {
            SalvarAlteracao();
        }
        public void SalvarAlteracao()
        {
            Conexao conexao = new Conexao(this.connetionString);
            DALRegistroGerado da = new DALRegistroGerado(conexao);

            RegistroGerados RegistroGerado = new RegistroGerados();

            if ((validaNome(txtNomeRegistro, errorProviderCadastraRegistroEditar) == true)) //(labelConfirmacao.Text).Equals("sucesso - cep completo"))
            {
                try
                {
                    RegistroGerado.IdGeradoRegistro = this.IdRegistro;

                    RegistroGerado.Estado = 2;

                    if (checkBoxSituacao.Checked == false)
                    {
                        RegistroGerado.Situacao = 2;
                    }
                    if (checkBoxSituacao.Checked == true)
                    {
                        RegistroGerado.Situacao = 1;
                    }

                    RegistroGerado.IdPessoaLogadaAlterada = this.IdPessoaLogada;

                    RegistroGerado.OrigemRegistro = txtOrigemRegistro.Text;

                    if (this.Operacao == "Editar")
                    {

                        if (checkBoxFinalizarRegistro.Checked == true)
                        {
                            DialogResult dialogResult1 = MessageBox.Show("Tem Certeza que deseja finalizar Registro?", "Aviso", MessageBoxButtons.YesNo);

                            if (dialogResult1 == DialogResult.Yes)
                            {
                                FecharTodosFormulario();

                                RegistroGerado.Estado = 3;

                                RegistroGerado.MudancaDataFechamento = Convert.ToDateTime(DateTime.Today.Date.ToString("dd/MM/yyyy"));

                                da.AlterarClienteRegistroGerado(RegistroGerado);
                            }
                            else if (dialogResult1 == DialogResult.No)
                            {
                                FecharTodosFormulario();

                                da.AlterarClienteRegistroGerado(RegistroGerado);

                                MessageBox.Show("Registro alterado com Exito! ");
                            }
                        }
                        if (checkBoxFinalizarRegistro.Checked == false)
                        {
                            da.AlterarClienteRegistroGerado(RegistroGerado);

                            FecharTodosFormulario();

                            MessageBox.Show("Registro alterado com Exito! ");
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro de acesso ao banco de Dados: " + ex.ToString());
                }
            }
        }
        private void buttonCadastraRegistroEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }
        public void Editar()
        {
            if (RegistroEditar == 0)
            {
                MessageBox.Show("Permissão negada!");
            }
            if (RegistroEditar == 1)
            {
                panelDocumentoRegistro.Enabled = true;
                this.Operacao = "Editar";
                buttonVerifica.Enabled = true;
            }
        }

        private void buttonLimpaRegistro_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        public void Limpar()
        {
            txtOrigemRegistro.Clear();
        }

        private void buttonCadastraSubRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (RegistroCadastra == 0)
                {
                    MessageBox.Show("Acesso não Permitido!");
                }
                if (RegistroCadastra == 1)
                {
                    FormCadastraRegistroSub CadastraRegistroSub = new FormCadastraRegistroSub(this.IdRegistro,
                    this.IdPessoa, NomeCliente1, txtNumeroRegistro.Text, this.IdPessoaLogada, NomeUsuarioLogado, this.connetionString);
                    CadastraRegistroSub.Parent = CadastraRegistroSub.MdiParent;
                    CadastraRegistroSub.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Visualiar impressão
        private void buttonImprimirRegistro_Click(object sender, EventArgs e)
        {
            FormRelatorioRegistroSemSubRegistro FormRelatorioRegistroSemSubRegistroR = new FormRelatorioRegistroSemSubRegistro(txtOrigemRegistro.Text);

            FormRelatorioRegistroSemSubRegistroR.Show();

            //printPreviewDialogVisualizar.Document = printDocumentImprimir;

            //_texto = txtOrigemRegistro.Text;

            //printPreviewDialogVisualizar.ShowDialog();
        }
        //Escolher Impressora a Imprimir
        private void buttonEscolherImpressora_Click(object sender, EventArgs e)
        {
            if (printDialogCaixa.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                printDocumentImprimir.PrinterSettings = printDialogCaixa.PrinterSettings;
                printDocumentImprimir.Print();
            }
        }
        
        private void printDocumentImprimir_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Bitmap bmp = Properties.Resources.Registro;
                Image newImagem = bmp;

                e.Graphics.DrawImage(newImagem, 0, 0, newImagem.Width, newImagem.Height);

                int WPos = 20;
                int YPos = 350; //No 370 começa o testo
                int retWPos = 785;
                int retHPos = 770;
                int caracteresNaPagina = 0;

                Rectangle rect = new Rectangle(WPos, YPos, retWPos, retHPos);
                Rectangle rect2 = new Rectangle(WPos, 1300, retWPos, retHPos);

                Font font = new Font("Times New Roman", 16, FontStyle.Regular);

                Brush brush = new SolidBrush(Color.Black);

                Pen blackPen = new Pen(Color.Black, 3);

                float linhasPorPaginaF = rect.Height / font.GetHeight(e.Graphics);

                linhasPorPaginaF.ToString();

                int linhasPorPagina = (int)Math.Round(linhasPorPaginaF);
             
               PointF Inicio = new PointF(20, 360);


                e.Graphics.DrawRectangle(blackPen, rect);

                //e.Graphics.DrawString("" + txtOrigemRegistro.Text, font, brush, new Point(20, 360));


                e.Graphics.MeasureString(_texto, font, new Size(rect.Width,rect.Height - font.Height + 1), StringFormat.GenericTypographic, out caracteresNaPagina, out linhasPorPagina);

                e.Graphics.DrawString(_texto.Substring(0, caracteresNaPagina), font, brush, Inicio);

                _texto = _texto.Substring(caracteresNaPagina);

                if (!string.IsNullOrWhiteSpace(_texto))
                {
                    e.HasMorePages = true;

                    e.Graphics.DrawRectangle(blackPen, rect2);

                    e.HasMorePages = false;
                }

                //e.HasMorePages = !string.IsNullOrWhiteSpace(_texto);





                //e.PageSettings.PaperSize  = new PaperSize("Teste", 627, 968);
                //e.PageSettings.PaperSize  = new PaperSize("Teste", 827, 1169);






                // e.Graphics.DrawString("" + txtOrigemRegistro.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, MarginBounds);

                //e.Graphics.DrawImage(newImagem, 0, 0, newImagem.Width, newImagem.Height);
                //    using (var font = new Font("Times New Roman", 16, FontStyle.Regular))
                //using (var font2 = new Font("Times New Roman", 16, FontStyle.Regular))
                //using (var brush = new SolidBrush(Color.Black))
                //{
                //string linha  = "Campo1   Campo2    Campo3    Campo4    Campo5    Campo6    Campo7    Campo8";



                ////Calcula o número de linhas por página.
                //float linhasPorPagina = e.MarginBounds.Height / font.GetHeight(e.Graphics);



                //// Create rectangle.
                ////Rectangle rect = new Rectangle(0, 0, e.MarginBounds.Width, e.MarginBounds.Height);
                ////Rectangle rect = new Rectangle(20, 370, 780, 770);
                //Rectangle rect2 = new Rectangle(100, 100, 627, 968);
                //// Draw rectangle to screen.
                //e.Graphics.DrawRectangle(blackPen, rect2);

                //float Fonte = font.GetHeight(e.Graphics);
                ////Clacula a altura da fonte
                //float alturaFonte = font.GetHeight(e.Graphics);
                ////Variável para armazenamento de posição vertical.
                //float posY = 0;
                //float i = 0;


                //for(i = 0; i < linhasPorPagina; i++)
                //{
                //    // Desenha a linha.
                //    e.Graphics.DrawString(i.ToString("00") + ":" + linha, font, Brushes.Black, 10, posY, new StringFormat());
                //    //Inrementa posição vertical.
                //    posY = i * alturaFonte;
                //}



                //e.Graphics.DrawString("" + txtOrigemRegistro.Text, font, brush, new Point(20, 1140));


            }
            catch (Exception )
            {

            }


            //Bitmap bmp = Properties.Resources.Registro;
            //Image newImagem = bmp;

            //int caracteres = 0;
            //int linhas = 0;

            //int yPos = 370;

            //int i= 0;

            //// TODOS SUB - REGISTRO CADASTRADO
            //SqlConnection conn = new SqlConnection(this.connetionString);

            //SqlDataAdapter da1 = new SqlDataAdapter("EXEC D_R_ConsultaRegistroGeradoNSEditartxt " + IdRegistro + ";", conn);
            //DataSet ds = new DataSet();
            //da1.Fill(ds);

            //int subRegistro = ds.Tables[0].Rows.Count;

            //string QuantLinhastxtOrigemRegistro = txtOrigemRegistro.Lines.Count().ToString();

            //int InteiroQuantLinhastxtOrigemRegistro = int.Parse(QuantLinhastxtOrigemRegistro) * 15;

            //int PulaLinhaSemSubRegistro = yPos + 30;

            //int PulaLinhaComSubRegistro = yPos + InteiroQuantLinhastxtOrigemRegistro + 15;

            //int PularQuebraLinhaSemSubRegistro = PulaLinhaSemSubRegistro + 30; // InteiroQuantLinhastxtOrigemRegistro + 30;//duas linhas = 30 + InteiroQuantLinhastxtOrigemRegistro;

            //int PularQuebraLinhaComSubRegistro = PulaLinhaComSubRegistro + 30;

            //if (CheckImprimirSUbRegisto.Checked == false)
            //{
            //    Pen blackPen = new Pen(Color.Black, 3);


            //    //Width = 830;
            //    //Height = 1170;

            //    //e.Graphics.DrawRectangle(blackPen, 0, 0, Width, Height);
            //    //e.Graphics.DrawRectangle(blackPen, 0, 0, Width, Height);
            //    //for (i = 1; i < 3; i++)
            //    //{

            //    //    Width = Width - Menos;
            //    //    Height = Height - Menos;



            //    //    e.Graphics.DrawRectangle(blackPen, 0, 0, Width, Height);


            //    //}

            //    //e.Graphics.DrawRectangle(blackPen, 0, 0, Width, Height);




            //    using (var font = new Font("Times New Roman", 16, FontStyle.Regular))
            //    using (var font2 = new Font("Times New Roman", 16, FontStyle.Regular))
            //    using (var brush = new SolidBrush(Color.Black))
            //    {
            //        //e.Graphics.DrawImage(newImagem, 0, 0, newImagem.Width, newImagem.Height);




            //        //e.Graphics.DrawString("" + txtNumeroDoRegistro.Text, font, brush, new Point(592, 40));
            //        //e.Graphics.DrawString("" + txtDataSolicitacaoProcesso.Text, font, brush, new Point(310, 88));
            //        //e.Graphics.DrawString("" + txtNomeRegistro.Text, font, brush, new Point(172, 173));
            //        //e.Graphics.DrawString("" + txtNumeroRegistro.Text, font, brush, new Point(750, 173));
            //        //e.Graphics.DrawString("" + txtEnderecoRegistro.Text + "," + txtBairroNumero.Text + "," + txtComplRegistro.Text + "-" + txtBairroNumero.Text + "-", font, brush, new Point(172, 198));//+ txtTipo_logradouro.Text + ": "
            //        //                                                                                                                                                                                     /*txtTelefoneRegistro.Text*/
            //        //e.Graphics.DrawString("" + "(11)56689175", font, brush, new Point(172, 225));
            //        //e.Graphics.DrawString("" + txtDataContatoRegistro.Text, font, brush, new Point(665, 225));
            //        //e.Graphics.DrawString("" + this.txtNomeContato.Text, font, brush, new Point(172, 250));
            //        //e.Graphics.DrawString("" + "(11)56689175", font, brush, new Point(665, 250));
            //        //e.Graphics.DrawString("" + txtOrigemRegistro.Text, font, brush, new Point(20, 370));

            //        //////int caracteresNaPagina = 0;
            //        //////int linhasPorPagina = 0;

            //        //////PointF Inicio = new PointF(20,1050);

            //        //////e.Graphics.MeasureString(_texto, font, e.MarginBounds.Size, StringFormat.GenericTypographic,
            //        //////    out caracteresNaPagina, out linhasPorPagina);
            //        //////e.Graphics.DrawString(_texto.Substring(0, caracteresNaPagina), font, brush, Inicio);//370

            //        //////e.HasMorePages = _texto.Length > 0;



            //        //while (_texto.Length > 0)
            //        //{
            //        //    e.HasMorePages = _texto.Length > 0;

            //        //    e.Graphics.MeasureString(_texto, font, e.MarginBounds.Size, StringFormat.GenericTypographic,
            //        //    out caracteresNaPagina, out linhasPorPagina);

            //        //    e.Graphics.DrawString(_texto.Substring(0, caracteresNaPagina), font, brush, new PointF(20, 20));

            //        //    _texto = _texto.Substring(caracteresNaPagina);

            //        //    // e.HasMorePages = _texto.Length > 0;


            //        //}


            //        //e.HasMorePages = _texto.Length > 0;
            //    }

            //    //int QuantidadeLinha = 0;
            //    //    int TextoLinha = 0;
            //    //    QuantidadeLinha = txtOrigemRegistro.Lines.Length;
            //    //    TextoLinha = (QuantidadeLinha * 20) + 370;

            //    //    TextoLinha.ToString();
                    

                

            //}
            //if (CheckImprimirSUbRegisto.Checked == true)
            //{
            //    if (ds.Tables[0].Rows.Count == 0)
            //    {

            //        using (var font = new Font("Times New Roman", 16, FontStyle.Regular))
            //        using (var brush = new SolidBrush(Color.Black))
            //        {
            //            e.Graphics.DrawImage(newImagem, 0, 0, newImagem.Width, newImagem.Height);
            //            e.Graphics.DrawString("" + txtNumeroDoRegistro.Text, font, brush, new Point(592, 40));
            //            e.Graphics.DrawString("" + txtDataSolicitacaoProcesso.Text, font, brush, new Point(310, 88));
            //            e.Graphics.DrawString("" + txtNomeRegistro.Text, font, brush, new Point(172, 173));
            //            e.Graphics.DrawString("" + txtNumeroRegistro.Text, font, brush, new Point(750, 173));
            //            e.Graphics.DrawString("" + txtEnderecoRegistro.Text + "," + txtBairroNumero.Text + "," + txtComplRegistro.Text + "-" + txtBairroNumero.Text + "-", font, brush, new Point(172, 198));//+ txtTipo_logradouro.Text + ": "
            //                                                                                                                                                                                                 /*txtTelefoneRegistro.Text*/
            //            e.Graphics.DrawString("" + "(11)56689175", font, brush, new Point(172, 225));
            //            e.Graphics.DrawString("" + txtDataContatoRegistro.Text, font, brush, new Point(665, 225));
            //            e.Graphics.DrawString("" + this.txtNomeContato.Text, font, brush, new Point(172, 250));
            //            e.Graphics.DrawString("" + "(11)56689175", font, brush, new Point(665, 250));
            //            e.Graphics.DrawString("" + txtOrigemRegistro.Text, font, brush, new Point(20, 370));

            //            e.Graphics.MeasureString(_texto, font, new Size(e.MarginBounds.Width, e.MarginBounds.Height - font.Height + 1), StringFormat.GenericTypographic, out caracteres, out linhas);
            //            e.Graphics.DrawString(_texto.Substring(0, caracteres), font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);
            //            _texto = _texto.Substring(caracteres);
            //            //e.HasMorePages = _texto.Length > 0; 

            //            e.HasMorePages = !string.IsNullOrWhiteSpace(_texto);

            //            //_texto = _texto.Substring(caracteres);

            //            //e.HasMorePages = !string.IsNullOrWhiteSpace(_texto);

            //        }
            //        conn.Close();
            //        //e.Graphics.DrawImage(newImagem, 0, 0, newImagem.Width, newImagem.Height);
            //        //e.Graphics.DrawString("" + txtNumeroDoRegistro.Text, new Font("Times New Roman", 22, FontStyle.Italic), Brushes.Black, new Point(592, 40));
            //        //e.Graphics.DrawString("" + txtDataSolicitacaoProcesso.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(310, 88));
            //        //e.Graphics.DrawString("" + txtNomeRegistro.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(172, 173));
            //        //e.Graphics.DrawString("" + txtNumeroRegistro.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(750, 173));
            //        //e.Graphics.DrawString("" + txtEnderecoRegistro.Text + "," + txtBairroNumero.Text + "," + txtComplRegistro.Text + "-" + txtBairroNumero.Text + "-", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(172, 198));//+ txtTipo_logradouro.Text + ": "
            //        //                                                                                                                                                                                                                                           /*txtTelefoneRegistro.Text*/
            //        //e.Graphics.DrawString("" + "(11)56689175", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(172, 225));
            //        //e.Graphics.DrawString("" + txtDataContatoRegistro.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(665, 225));
            //        //e.Graphics.DrawString("" + this.txtNomeContato.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(172, 250));
            //        //e.Graphics.DrawString("" + "(11)56689175", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(665, 250));
            //        //e.Graphics.DrawString("" + txtOrigemRegistro.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(20, 370));

            //        conn.Close();
            //    }
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        using (var font = new Font("Times New Roman", 16, FontStyle.Regular))
            //        using (var brush = new SolidBrush(Color.Black))
            //        {
            //            e.Graphics.DrawImage(newImagem, 0, 0, newImagem.Width, newImagem.Height);
            //            e.Graphics.DrawString("" + txtNumeroDoRegistro.Text, font, brush, new Point(592, 40));
            //            e.Graphics.DrawString("" + txtDataSolicitacaoProcesso.Text, font, brush, new Point(310, 88));
            //            e.Graphics.DrawString("" + txtNomeRegistro.Text, font, brush, new Point(172, 173));
            //            e.Graphics.DrawString("" + txtNumeroRegistro.Text, font, brush, new Point(750, 173));
            //            e.Graphics.DrawString("" + txtEnderecoRegistro.Text + "," + txtBairroNumero.Text + "," + txtComplRegistro.Text + "-" + txtBairroNumero.Text + "-", font, brush, new Point(172, 198));//+ txtTipo_logradouro.Text + ": "
            //                                                                                                                                                                                                 /*txtTelefoneRegistro.Text*/
            //            e.Graphics.DrawString("" + "(11)56689175", font, brush, new Point(172, 225));
            //            e.Graphics.DrawString("" + txtDataContatoRegistro.Text, font, brush, new Point(665, 225));
            //            e.Graphics.DrawString("" + this.txtNomeContato.Text, font, brush, new Point(172, 250));
            //            e.Graphics.DrawString("" + "(11)56689175", font, brush, new Point(665, 250));
            //            e.Graphics.DrawString("" + txtOrigemRegistro.Text, font, brush, new Point(20, 370));

            //            e.Graphics.MeasureString(_texto, font, new Size(e.MarginBounds.Width, e.MarginBounds.Height - font.Height + 1), StringFormat.GenericTypographic, out caracteres, out linhas);

            //            e.Graphics.DrawString(_texto.Substring(0, caracteres), font, brush, e.MarginBounds);

            //            _texto = _texto.Substring(caracteres);

            //            e.HasMorePages = !string.IsNullOrWhiteSpace(_texto);

            //        }
            //        //e.Graphics.DrawImage(newImagem, 0, 0, newImagem.Width, newImagem.Height);
            //        //e.Graphics.DrawString("" + txtNumeroDoRegistro.Text, new Font("Times New Roman", 22, FontStyle.Italic), Brushes.Black, new Point(592, 40));
            //        //e.Graphics.DrawString("" + txtDataSolicitacaoProcesso.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(310, 88));
            //        //e.Graphics.DrawString("" + txtNomeRegistro.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(172, 173));
            //        //e.Graphics.DrawString("" + txtNumeroRegistro.Text, new Font("Times New Roman", 16, FontStyle.Regular), Brushes.Black, new Point(750, 173));
            //        //e.Graphics.DrawString("" + txtEnderecoRegistro.Text + "," + txtBairroNumero.Text + "," + txtComplRegistro.Text + "-" + txtBairroNumero.Text + "-", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(172, 198));//+ txtTipo_logradouro.Text + ": "
            //        //                                                                                                                                                                                                                                           /*txtTelefoneRegistro.Text*/
            //        //e.Graphics.DrawString("" + "(11)56689175", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(172, 225));
            //        //e.Graphics.DrawString("" + txtDataContatoRegistro.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(665, 225));
            //        //e.Graphics.DrawString("" + this.txtNomeContato.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(172, 250));
            //        //e.Graphics.DrawString("" + "(11)56689175", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(665, 250));
            //        //e.Graphics.DrawString("" + txtOrigemRegistro.Text, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(20, yPos));



            //        //if (txtOrigemRegistro.Text == "")
            //        //{
            //        //    e.Graphics.DrawString("--------------Quebra de linha txtOrigemRegistro Branco  ------------", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(60, PulaLinhaSemSubRegistro));

            //        //    for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        //    {
            //        //        e.Graphics.DrawString("N° Sub Registro:\n    " + ds.Tables[0].Rows[i][2].ToString(), new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(20, PularQuebraLinhaComSubRegistro + 15));

            //        //        string Data = ds.Tables[0].Rows[i][10].ToString();

            //        //        e.Graphics.DrawString("Data contato Cliente:\n    " + Data, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(200, PularQuebraLinhaComSubRegistro + 15));
            //        //        e.Graphics.DrawString("Contato  do  Cliente:\n    " + ds.Tables[0].Rows[i][16].ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(400, PularQuebraLinhaComSubRegistro + 15));
            //        //        e.Graphics.DrawString("Documentação Registro:\n " + ds.Tables[0].Rows[i][8].ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(20, PularQuebraLinhaComSubRegistro + 75));


            //        //        e.Graphics.DrawString("------------------------Quebra de linha a Cada Sub Registro-------------------------", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(20, PularQuebraLinhaComSubRegistro + 120));

            //        //        PularQuebraLinhaComSubRegistro.ToString();

            //        //        PularQuebraLinhaComSubRegistro += 120;

            //        //        PularQuebraLinhaComSubRegistro.ToString();
            //        //    }

            //        //}
            //        /*else*/
            //        if (!(txtOrigemRegistro.Text == ""))
            //        {
            //            e.Graphics.DrawString("---------------Quebra de linha txtOrigemRegistro com texto---------------", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(60, PulaLinhaComSubRegistro));

            //            e.Graphics.DrawString("", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(60, PularQuebraLinhaComSubRegistro));

            //            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            //            {
            //                e.Graphics.DrawString("N° Sub Registro:\n    " + ds.Tables[0].Rows[i][2].ToString(), new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(20, PularQuebraLinhaComSubRegistro + 15));

            //                string Data = ds.Tables[0].Rows[i][10].ToString();

            //                e.Graphics.DrawString("Data contato Cliente:\n    " + Data, new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(200, PularQuebraLinhaComSubRegistro + 15));
            //                e.Graphics.DrawString("Contato  do  Cliente:\n    " + ds.Tables[0].Rows[i][16].ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(400, PularQuebraLinhaComSubRegistro + 15));
            //                e.Graphics.DrawString("Documentação Registro:\n " + ds.Tables[0].Rows[i][8].ToString(), new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(20, PularQuebraLinhaComSubRegistro + 75));


            //                e.Graphics.DrawString("------------------------Quebra de linha a Cada Sub Registro--------------------------", new Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(20, PularQuebraLinhaComSubRegistro + 120));

            //                PularQuebraLinhaComSubRegistro.ToString();

            //                PularQuebraLinhaComSubRegistro += 120;

            //                PularQuebraLinhaComSubRegistro.ToString();

            //                if(PularQuebraLinhaComSubRegistro >= 960)
            //                {

            //                }

            //                e.HasMorePages = PularQuebraLinhaComSubRegistro >= 960;
                            
                             

            //            }
            //        }

            //    }
            //}
        }
   

        private void button1_Click(object sender, EventArgs e)
        { 
            //    // Cria um documento com 150 linhas
            //    string[] textoParaImpressao = new string[151];
            //    for (int i = 0; i < 151; i++)
            //    {
            //        //textoParaImpressao[i] = i.ToString();
            //        //textoParaImpressao[i] += " " + txtOrigemRegistro.Text;
            //    }

            //    PrintDocument doc = new ImprimirDocumento(textoParaImpressao);
            //    doc.PrintPage += this.Doc_PrintPage2; 

            //     PrintDialog dialogo = new PrintDialog();
            //    dialogo.Document = doc;

            //    //  Se o usuário clicar em OK , imprime o documento
            //    if (dialogo.ShowDialog() == DialogResult.OK)
            //    {
            //        //verifica se o usuário deseja visualizar a impressao 
            //        if (CheckImprimirSUbRegisto.Checked)
            //        {
            //            PrintPreviewDialog ppdlg = new PrintPreviewDialog();
            //            ppdlg.Document = doc;
            //            ppdlg.ShowDialog();
            //        }
            //        else
            //        {
            //            doc.Print();
            //        }
            //    }
            //}


            //private void Doc_PrintPage(object sender, PrintPageEventArgs e)
            //{
            //    // Recupera o documento que enviou este evento.
            //    ImprimirDocumento doc = (ImprimirDocumento)sender;

            //    // Define a fonte e determina a altura da linha
            //    using (Font fonte = new Font("Verdana", 10))
            //    {
            //        float alturaLinha = fonte.GetHeight(e.Graphics);

            //        // Cria as variáveis para tratar a posição na página
            //        float x = e.MarginBounds.Left;
            //        float y = e.MarginBounds.Top;

            //        // Incrementa o contador de página para refletir 
            //        // a página que esta sendo impressa
            //        doc.NumeroPagina += 1;

            //        // Imprime toda a informação que cabe na página
            //        // O laço termina quando a próxima linha 
            //        // iria passar a borda da margem ou quando não 
            //        // houve mais linhas a imprimir
            //        while ((y + alturaLinha) < e.MarginBounds.Bottom &&
            //          doc.Offset <= doc.Texto.GetUpperBound(0))
            //        {
            //            e.Graphics.DrawString(doc.Texto[doc.Offset], fonte,
            //              Brushes.Black, x, y);

            //            // move para a proxima linha
            //            doc.Offset += 1;

            //            // Move uma linha para baixo (proxima linha)
            //            y += alturaLinha;
            //        }

            //        if (doc.Offset < doc.Texto.GetUpperBound(0))
            //        {
            //            // Havendo ainda pelo menos mais uma página.
            //            // Sinaliza o evento para disparar novamente
            //            e.HasMorePages = true;
            //        }
            //        else
            //        {
            //            // A impressão terminou
            //            doc.Offset = 0;
            //        }
            //    }
        }



        //private void Doc_PrintPage2(object sender, PrintPageEventArgs e)
        //{
        //    // Recupera o documento que enviou este evento.
        //    ImprimirDocumento doc = (ImprimirDocumento)sender;

        //    // Define a fonte e determina a altura da linha
        //    using (Font fonte = new Font("Verdana", 10))
        //    {
        //        float alturaLinha = fonte.GetHeight(e.Graphics);

        //        // Cria as variáveis para tratar a posição na página
        //        float x = e.MarginBounds.Left;
        //        float y = e.MarginBounds.Top;

        //        // Incrementa o contador de página para refletir 
        //        // a página que esta sendo impressa
        //        doc.NumeroPagina += 1;

        //        // Imprime toda a informação que cabe na página
        //        // O laço termina quando a próxima linha 
        //        // iria passar a borda da margem ou quando não 
        //        // houve mais linhas a imprimir
        //        while ((y + alturaLinha) < e.MarginBounds.Bottom &&
        //          doc.Offset <= doc.Texto.GetUpperBound(0))
        //        {
        //            e.Graphics.DrawString(doc.Texto[doc.Offset], fonte,
        //              Brushes.Black, x, y);

        //            // move para a proxima linha
        //            doc.Offset += 1;

        //            // Move uma linha para baixo (proxima linha)
        //            y += alturaLinha;
        //        }

        //        if (doc.Offset < doc.Texto.GetUpperBound(0))
        //        {
        //            // Havendo ainda pelo menos mais uma página.
        //            // Sinaliza o evento para disparar novamente
        //            e.HasMorePages = true;
        //        }
        //        else
        //        {
        //            // A impressão terminou
        //            doc.Offset = 0;
        //        }
        //    }
        //}
        private void txtOrigemRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tamanhoMaximoPorLinha = 105;
            int[] keysLiberadas = { (int)Keys.Enter, (int)Keys.Back };

            int posicaoAtual = txtOrigemRegistro.SelectionStart;
            int linhaAtual = txtOrigemRegistro.GetLineFromCharIndex(posicaoAtual);

            if (txtOrigemRegistro.Lines.Length == 0)
            {
                if (txtOrigemRegistro.Text.Length > tamanhoMaximoPorLinha && !keysLiberadas.Contains((int)e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtOrigemRegistro.Lines[linhaAtual].Length > tamanhoMaximoPorLinha && !keysLiberadas.Contains((int)e.KeyChar))
            {
                e.Handled = true;
            }

            //try
            //{
            //    int line = 0;

            //    while (line < numLines)
            //    {
            //        string a = txtOrigemRegistro.Lines[line];
            //        a.Length.ToString();

            //        int tamanho = a.Length;

            //        a.ToString();
            //        numLines.ToString();
            //        tamanho.ToString();

            //        if( a.Length > 3)
            //        {

            //        }
            //        if (tamanho > 3)
            //        { 
            //            if (!(e.KeyChar == (Char)Keys.Delete || e.KeyChar == (Char)Keys.Enter))
            //            {
            //                e.Handled = true;

            //                //MessageBox.Show("Passo de " + txtOrigemRegistro.Lines[linhaAtual].Length);
            //            }
            //            if (e.KeyChar == (Char)Keys.Delete)
            //            {
            //                e.Handled = false;
            //                a.ToString();
            //            }
            //            if (e.KeyChar == (Char)Keys.Enter)
            //            {
            //                e.Handled = false;
            //                a.ToString();
            //            }
            //            if (e.KeyChar == (Char)Keys.Back)
            //            {
            //                e.Handled = false;
            //                a.ToString();
            //            }
            //            //if ((e.KeyChar == (Char)Keys.Delete) || (e.KeyChar == (Char)Keys.Enter) || (e.KeyChar == (Char)Keys.Back))
            //            //{

            //            //    e.Handled = false;
            //            //}



            //        }

            //        line++;
            //    }



            //if (!(e.KeyChar == 13))
            //{
            //    int tamanhoMaximoPorLinha = 0;
            //    int posicaoAtual = 0;
            //    int linhaAtual = 0;

            //    tamanhoMaximoPorLinha = 120;

            //    posicaoAtual = txtOrigemRegistro.SelectionStart;

            //int GetLineFromCharIndex = txtOrigemRegistro.GetLineFromCharIndex(posicaoAtual);

            //int str = txtOrigemRegistro.GetFirstCharIndexFromLine(1);

            //int[] keysLiberadas = { (int)Keys.Back };

            //linhaAtual = txtOrigemRegistro.GetLineFromCharIndex(posicaoAtual);


            //if (txtOrigemRegistro.Lines[linhaAtual].Length < tamanhoMaximoPorLinha)
            //{

            //}

            //if (txtOrigemRegistro.Lines[linhaAtual].Length > tamanhoMaximoPorLinha)
            //{
            //    if (e.KeyChar == (Char)Keys.Delete || e.KeyChar == (Char)Keys.Back)
            //    {
            //        e.Handled = false;
            //    }
            //    else if (!(e.KeyChar == (Char)Keys.Delete || e.KeyChar == (Char)Keys.Back))
            //    {
            //        e.Handled = true;

            //        //MessageBox.Show("Passo de " + txtOrigemRegistro.Lines[linhaAtual].Length);
            //    }

            //}



            //if (linhaAtual != -1)
            //{

            //    if (txtOrigemRegistro.Lines[linhaAtual].Length < tamanhoMaximoPorLinha)
            //    {

            //    }
            //    if (txtOrigemRegistro.Lines[linhaAtual].Length > tamanhoMaximoPorLinha)
            //    {
            //        if (e.KeyChar == (Char)Keys.Delete || e.KeyChar == (Char)Keys.Back)
            //        {
            //            e.Handled = false;

            //            txtOrigemRegistro.Lines[linhaAtual].Length.ToString();
            //            tamanhoMaximoPorLinha.ToString();
            //        }
            //        else if (!(e.KeyChar == (Char)Keys.Delete || e.KeyChar == (Char)Keys.Back))
            //        {
            //            e.Handled = true;

            //            txtOrigemRegistro.Lines[linhaAtual].Length.ToString();
            //            tamanhoMaximoPorLinha.ToString();

            //            //MessageBox.Show("Passo de " + txtOrigemRegistro.Lines[linhaAtual].Length);
            //        }
            //    }

            //}


            // GetLineFromCharIndex.ToString();


            //if (GetLineFromCharIndex <= tamanhoMaximoPorLinha)
            //{
            //    if (posicaoAtual <= tamanhoMaximoPorLinha /*&& !keysLiberadas.Contains((int)e.KeyChar)*/)
            //    {
            //        GetLineFromCharIndex.ToString();
            //        posicaoAtual.ToString();
            //    }
            //    else if (posicaoAtual > tamanhoMaximoPorLinha /*&& !keysLiberadas.Contains((int)e.KeyChar)*/)
            //    {
            //        e.Handled = true;
            //    }
            //}
            //if (GetLineFromCharIndex > tamanhoMaximoPorLinha)
            //{
            //    e.Handled = true;
            //}
            //}






            //if (linhaAtualS < 0)
            //{
            //    //MessageBox.Show(" Erro na Linha!");
            //    linhaAtualS.ToString();
            //}

            //if (linhaAtualS == 0)
            //{
            //    linhaAtualS.ToString();
            //}
            //if (linhaAtualS > 0)
            //{
            //    linhaAtualS.ToString();
            //}







            //int tamanhoMaximoPorLinha = 0;

            ////int[] keysLiberadas = { (int)Keys.Enter, (int)Keys.Back };
            //int [] keysLiberadas = { (int)Keys.Enter, (int)Keys.Back };

            //int posicaoAtual = 0;
            //int linhaAtual = 0;

            //posicaoAtual = txtOrigemRegistro.SelectionStart;

            //linhaAtual = txtOrigemRegistro.GetLineFromCharIndex(posicaoAtual);

            //tamanhoMaximoPorLinha = 114;

            //if (txtOrigemRegistro.Lines.Length == 0)
            //{
            //    if (txtOrigemRegistro.Text.Length > tamanhoMaximoPorLinha && !keysLiberadas.Contains((int)e.KeyChar))
            //    {
            //        e.Handled = true;
            //    }
            //}
            //if (txtOrigemRegistro.Lines[linhaAtual].Length == tamanhoMaximoPorLinha && !keysLiberadas.Contains((int)e.KeyChar))
            //{
            //    e.Handled = true;
            //    //txtOrigemRegistro.Text = txtOrigemRegistro.Text.Remove(txtOrigemRegistro.Lines[linhaAtual].Length, QuantCaracteristica);
            //}
            //else if (txtOrigemRegistro.Lines[linhaAtual].Length > tamanhoMaximoPorLinha && !keysLiberadas.Contains((int)e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            //tamanhoMaximoPorLinha.ToString();
            //posicaoAtual.ToString();
            //linhaAtual.ToString();
            //keysLiberadas.ToString();




            //}
            //catch (Exception)
            //{
            //    //MessageBox.Show("Erro" + e.ToString());
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {





            //while (line <= numLines)
            //{
            //    string l = txtOrigemRegistro.Lines[line - 1];
            //    l.ToString();
            //    if (l.Substring(0, 1) == "")
            //    {

            //    }

            //    else line++;
            //    if (l.Substring(0, 1) == "a")
            //    {
            //        listBox1.Items.Add(l);
            //        line++;
            //    }
            //    else line++;

            //}

            //int posicaoAtual = txtOrigemRegistro.SelectionStart;
            //int linhaAtual = txtOrigemRegistro.GetLineFromCharIndex(posicaoAtual);

            //QuantCaracteristica = txtOrigemRegistro.Lines[linhaAtual].Length;

            //MessageBox.Show("Quantidade: " + txtOrigemRegistro.Lines[linhaAtual].Length + " Quant: " + QuantCaracteristica);
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
                int QTDE_ESPACO = 100;
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

        private void txtOrigemRegistro_TextChanged(object sender, EventArgs e)
        {
            //numLines = txtOrigemRegistro.Lines.Count();

        }
        public static string InsereQuebraPrincipal(string TEXTO_GRANDE)
        {
            try
            {
                List<string> ListaTexto = new List<string>();

                int QuebraLinha = 110;// QUANTIDADE CARACTERES EM UMA MINHA!

                int i = 0;

                int j = 0;

                int NumeroLetras = 0;

                int n = 0;

                int intTotal = 0;

                int StringRestoTexto = 0;

                int acumuladorTemp = 0; // TEMPORARIO CARACTERES EM UMA MINHA

                string ServicoExecutado2 = "";// TEXTOU A IMPRIMIR

                string RestoTexto = "";

                int quantStringRestoTexto = 0;

                int contatoBranco = 0;

                Boolean finalizar = false;

                int quantString = TEXTO_GRANDE.Length; // QUANTIDADES DE CARACTERES DE UM TEXO

                int total = quantString / 110;

                string StringTeste = TEXTO_GRANDE;

                StringBuilder sb = new StringBuilder(TEXTO_GRANDE);

                string StringTesteTemp = "";





                //NÃO A QUEBRA DE LINHA SE FOR SÓ UMA LINHA
                if (quantString <= QuebraLinha)
                {
                    ServicoExecutado2 = sb.ToString();
                }
                //QUEBRA DE LINHA SE FOR MAS QUE UMA LINHA

                quantString.ToString();


                if (quantString > QuebraLinha)
                {
                    if (StringTeste[QuebraLinha] == ' ')
                    {
                        for (NumeroLetras = QuebraLinha; NumeroLetras < total; i++)
                        {
                            sb.Insert(QuebraLinha, '\n');

                            while ((RestoTexto[0] == ' '))
                            {
                                sb.Remove(0, 1);
                            }



                            sb.Remove(0, QuebraLinha + 1);

                            RestoTexto = sb.ToString();

                            RestoTexto.ToString();

                            quantStringRestoTexto = RestoTexto.Length;

                            //quantStringRestoTexto.ToString();

                            while ((RestoTexto[0] == ' '))
                            {
                                sb.Remove(0, 1);

                                RestoTexto = sb.ToString();

                                RestoTexto.ToString();
                            }
                        }
                    }
                }
                return ServicoExecutado2 = sb.ToString();
            }
            catch (Exception exp)
            {
                return exp.ToString();
            }
        }
        private void richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {


            //int tamanhoMaximoPorLinha = 105;
            //int[] keysLiberadas = { (int)Keys.Enter }; // (int)Keys.Back};

            //int posicaoAtual = richTextBox.SelectionStart;
            //int linhaAtual = richTextBox.GetLineFromCharIndex(posicaoAtual);

            //if (richTextBox.Lines.Length == 0)
            //{
            //    if (richTextBox.Text.Length > tamanhoMaximoPorLinha && !keysLiberadas.Contains((int)e.KeyChar))
            //    {
            //        e.Handled = true;
            //    }
            //}
            //else if (richTextBox.Lines[linhaAtual].Length > tamanhoMaximoPorLinha && !keysLiberadas.Contains((int)e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Draw a shape depending on the page we are printing.
            switch (NumeroOfItensPorPaginas)
            {
                case 0: // Draw an ellipse.
                    using (Pen the_pen = new Pen(Color.Red, 10))
                    {
                        e.Graphics.DrawEllipse(the_pen, e.MarginBounds);
                    }
                    break;
                case 1: // Draw a triangle.
                    using (Pen the_pen = new Pen(Color.Green, 10))
                    {
                        int xmid = (int)(e.MarginBounds.X +
                            e.MarginBounds.Width / 2);
                        Point[] pts =
                        {
                    new Point(xmid, e.MarginBounds.Top),
                    new Point(e.MarginBounds.Right,
                        e.MarginBounds.Bottom),
                    new Point(e.MarginBounds.Left,
                        e.MarginBounds.Bottom),
                };
                        e.Graphics.DrawPolygon(the_pen, pts);
                    }
                    break;
                case 2: // Draw a rectangle.
                    using (Pen the_pen = new Pen(Color.Blue, 10))
                    {
                        e.Graphics.DrawRectangle(the_pen, e.MarginBounds);
                    }
                    break;
                case 3: // Draw a diamond.
                    using (Pen the_pen = new Pen(Color.Orange, 10))
                    {
                        int xmid = (int)(e.MarginBounds.X +
                            e.MarginBounds.Width / 2);
                        int ymid = (int)(e.MarginBounds.Y +
                            e.MarginBounds.Height / 2);
                        Point[] pts =
                        {
                    new Point(xmid, e.MarginBounds.Top),
                    new Point(e.MarginBounds.Right, ymid),
                    new Point(xmid, e.MarginBounds.Bottom),
                    new Point(e.MarginBounds.Left, ymid),
                };
                        e.Graphics.DrawPolygon(the_pen, pts);
                    }
                    break;
            }

            // Draw the page number centered.
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                using (Font the_font = new Font("Times New Roman", 200,
                    FontStyle.Bold))
                {
                    using (Brush the_brush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.DrawString(String.Format("{0}",
                            NumeroOfItensPorPaginas + 1), the_font, the_brush,
                            e.MarginBounds, sf);
                    }
                }
            }

            // Next time print the next page.
            NumeroOfItensPorPaginas += 1;

            // We have more pages if wee have not yet printed page 3.
            e.HasMorePages = (NumeroOfItensPorPaginas <= 3);

            // If we have no more pages, reset for the next time we print.
            if (NumeroOfItensPorPaginas > 3) NumeroOfItensPorPaginas = 0;
        }
    }
}






    //    }
    //}

    //for (i = 0; i < (QuebraLinha + 1); i++)
    //{
    //    if (finalizar == false)
    //    {
    //        //VERIFICAR SE O TEXTO NO  CARACTERES 110 TEM ESPAÇO!
    //        if (StringTeste[QuebraLinha] == ' ')
    //        {
    //            for (j = 0; j < quantString; j++)
    //            {
    //                if (StringTeste[QuebraLinha + j] == ' ')
    //                {

    //                }
    //                sb.Insert(QuebraLinha + 1, '\n');

    //                ServicoExecutado2 = sb.ToString();

    //                sb.Remove(0, QuebraLinha);

    //                RestoTexto = sb.ToString();
    //            }
    //        }

    //        if ((StringTeste[QuebraLinha] == '.'))
    //        {
    //            if ((!(StringTeste[QuebraLinha + 1] == ' ')) || (!(StringTeste[QuebraLinha + 1] == '\n')))
    //            {
    //                for (n = (QuebraLinha); n > 0; n--)
    //                {
    //                    if (StringTeste[n] == ' ')
    //                    {
    //                        sb.Insert(n + 1, '\n');

    //                        ServicoExecutado2 = sb.ToString();

    //                        acumuladorTemp = 110 + QuebraLinha;//n 77

    //                        n = 0;

    //                        if (acumuladorTemp > quantString)
    //                        {
    //                            finalizar = true;
    //                            //REMOVE O INICIO DO CARACTERES EM BRANCO DA ULTIMA LINHA
    //                            for (intTotal = ((total * 110)); intTotal > 0; intTotal--)
    //                            {
    //                                while (ServicoExecutado2[intTotal] == ' ')
    //                                {
    //                                    sb.Remove(intTotal, 1);
    //                                }

    //                                if (!(ServicoExecutado2[intTotal] == ' '))
    //                                {
    //                                    ServicoExecutado2 = sb.ToString();
    //                                    intTotal = 0;
    //                                }
    //                            }
    //                        }
    //                        if (acumuladorTemp < quantString)
    //                        {
    //                            QuebraLinha = acumuladorTemp;
    //                        }
    //                    }
    //                }
    //            }


    //            sb.Insert(QuebraLinha + 1, '\n');

    //            ServicoExecutado2 = sb.ToString();

    //            acumuladorTemp = 77 + QuebraLinha;//acumulador2

    //            if (acumuladorTemp > quantString)
    //            {
    //                finalizar = true;
    //            }
    //            if (acumuladorTemp < quantString)
    //            {
    //                QuebraLinha = acumuladorTemp;

    //            }
    //        }


    //        if (!(StringTeste[QuebraLinha] == ' '))
    //        {
    //            for (n = (QuebraLinha); n > 0; n--)
    //            {
    //                if (StringTeste[n] == ' ')
    //                {
    //                    sb.ToString();
    //                    sb.Insert(n + 1, '\n');

    //                    ServicoExecutado2 = sb.ToString();

    //                    acumuladorTemp = 77 + QuebraLinha;//n

    //                    n = 0;

    //                    if (acumuladorTemp > quantString)
    //                    {
    //                        finalizar = true;
    //                        //REMOVE O INICIO DO CARACTERES EM BRANCO DA ULTIMA LINHA
    //                        for (intTotal = ((total * 77)); intTotal > 0; intTotal--)
    //                        {
    //                            if (ServicoExecutado2[intTotal] == ' ')
    //                            {
    //                                //sb.Remove(intTotal, 5);
    //                                sb.Remove(intTotal, 1);
    //                                ServicoExecutado2 = sb.ToString();

    //                                ServicoExecutado2.ToString();

    //                                intTotal = 0;
    //                            }
    //                        }
    //                    }
    //                    if (acumuladorTemp < quantString)
    //                    {
    //                        QuebraLinha = acumuladorTemp;
    //                        QuebraLinha.ToString();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    //}
