namespace MSOS
{
    partial class FormCadastroFornecedorJuridica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nOME_CONTATOLabel;
            System.Windows.Forms.Label rAZAO_SOCIALLabel;
            System.Windows.Forms.Label iNSCRICAO_STADUALLabel;
            System.Windows.Forms.Label cNPJLabel;
            this.panelJuridico = new System.Windows.Forms.Panel();
            this.buttonEditarFonecedor = new System.Windows.Forms.Button();
            this.buttonDesvalidarJuridica = new System.Windows.Forms.Button();
            this.ButtonValidarFornecedorJuridica = new System.Windows.Forms.Button();
            this.txtNomeContato = new System.Windows.Forms.TextBox();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.txtInscStatual = new System.Windows.Forms.TextBox();
            this.txtCnpj = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProviderFornecedorJuridico = new System.Windows.Forms.ErrorProvider(this.components);
            nOME_CONTATOLabel = new System.Windows.Forms.Label();
            rAZAO_SOCIALLabel = new System.Windows.Forms.Label();
            iNSCRICAO_STADUALLabel = new System.Windows.Forms.Label();
            cNPJLabel = new System.Windows.Forms.Label();
            this.panelJuridico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFornecedorJuridico)).BeginInit();
            this.SuspendLayout();
            // 
            // nOME_CONTATOLabel
            // 
            nOME_CONTATOLabel.AutoSize = true;
            nOME_CONTATOLabel.Location = new System.Drawing.Point(10, 84);
            nOME_CONTATOLabel.Name = "nOME_CONTATOLabel";
            nOME_CONTATOLabel.Size = new System.Drawing.Size(97, 13);
            nOME_CONTATOLabel.TabIndex = 73;
            nOME_CONTATOLabel.Text = "NOME CONTATO:";
            // 
            // rAZAO_SOCIALLabel
            // 
            rAZAO_SOCIALLabel.AutoSize = true;
            rAZAO_SOCIALLabel.Location = new System.Drawing.Point(146, 32);
            rAZAO_SOCIALLabel.Name = "rAZAO_SOCIALLabel";
            rAZAO_SOCIALLabel.Size = new System.Drawing.Size(88, 13);
            rAZAO_SOCIALLabel.TabIndex = 72;
            rAZAO_SOCIALLabel.Text = "RAZAO SOCIAL:";
            // 
            // iNSCRICAO_STADUALLabel
            // 
            iNSCRICAO_STADUALLabel.AutoSize = true;
            iNSCRICAO_STADUALLabel.Location = new System.Drawing.Point(5, 58);
            iNSCRICAO_STADUALLabel.Name = "iNSCRICAO_STADUALLabel";
            iNSCRICAO_STADUALLabel.Size = new System.Drawing.Size(121, 13);
            iNSCRICAO_STADUALLabel.TabIndex = 70;
            iNSCRICAO_STADUALLabel.Text = "INSCRICAO STADUAL:";
            // 
            // cNPJLabel
            // 
            cNPJLabel.AutoSize = true;
            cNPJLabel.Location = new System.Drawing.Point(4, 32);
            cNPJLabel.Name = "cNPJLabel";
            cNPJLabel.Size = new System.Drawing.Size(37, 13);
            cNPJLabel.TabIndex = 66;
            cNPJLabel.Text = "CNPJ:";
            // 
            // panelJuridico
            // 
            this.panelJuridico.Controls.Add(this.buttonEditarFonecedor);
            this.panelJuridico.Controls.Add(this.buttonDesvalidarJuridica);
            this.panelJuridico.Controls.Add(this.ButtonValidarFornecedorJuridica);
            this.panelJuridico.Controls.Add(nOME_CONTATOLabel);
            this.panelJuridico.Controls.Add(this.txtNomeContato);
            this.panelJuridico.Controls.Add(rAZAO_SOCIALLabel);
            this.panelJuridico.Controls.Add(this.txtRazaoSocial);
            this.panelJuridico.Controls.Add(iNSCRICAO_STADUALLabel);
            this.panelJuridico.Controls.Add(this.txtInscStatual);
            this.panelJuridico.Controls.Add(cNPJLabel);
            this.panelJuridico.Controls.Add(this.txtCnpj);
            this.panelJuridico.Controls.Add(this.label1);
            this.panelJuridico.Location = new System.Drawing.Point(12, 12);
            this.panelJuridico.Name = "panelJuridico";
            this.panelJuridico.Size = new System.Drawing.Size(439, 110);
            this.panelJuridico.TabIndex = 10;
            // 
            // buttonEditarFonecedor
            // 
            this.buttonEditarFonecedor.Enabled = false;
            this.buttonEditarFonecedor.Location = new System.Drawing.Point(381, 1);
            this.buttonEditarFonecedor.Name = "buttonEditarFonecedor";
            this.buttonEditarFonecedor.Size = new System.Drawing.Size(26, 26);
            this.buttonEditarFonecedor.TabIndex = 74;
            this.buttonEditarFonecedor.Text = "E";
            this.buttonEditarFonecedor.UseVisualStyleBackColor = true;
            this.buttonEditarFonecedor.Click += new System.EventHandler(this.buttonEditarFonecedor_Click);
            // 
            // buttonDesvalidarJuridica
            // 
            this.buttonDesvalidarJuridica.Image = global::MSOS.Properties.Resources.cancelarCliente;
            this.buttonDesvalidarJuridica.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonDesvalidarJuridica.Location = new System.Drawing.Point(410, 0);
            this.buttonDesvalidarJuridica.Name = "buttonDesvalidarJuridica";
            this.buttonDesvalidarJuridica.Size = new System.Drawing.Size(26, 26);
            this.buttonDesvalidarJuridica.TabIndex = 0;
            this.buttonDesvalidarJuridica.Text = "button1";
            this.buttonDesvalidarJuridica.UseVisualStyleBackColor = true;
            this.buttonDesvalidarJuridica.Click += new System.EventHandler(this.buttonDesvalidarJuridica_Click_1);
            // 
            // ButtonValidarFornecedorJuridica
            // 
            this.ButtonValidarFornecedorJuridica.BackgroundImage = global::MSOS.Properties.Resources.SalvarDadosClientes;
            this.ButtonValidarFornecedorJuridica.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButtonValidarFornecedorJuridica.Location = new System.Drawing.Point(350, 2);
            this.ButtonValidarFornecedorJuridica.Name = "ButtonValidarFornecedorJuridica";
            this.ButtonValidarFornecedorJuridica.Size = new System.Drawing.Size(26, 26);
            this.ButtonValidarFornecedorJuridica.TabIndex = 0;
            this.ButtonValidarFornecedorJuridica.UseVisualStyleBackColor = true;
            this.ButtonValidarFornecedorJuridica.Click += new System.EventHandler(this.ButtonValidarFornecedorJuridica_Click);
            // 
            // txtNomeContato
            // 
            this.txtNomeContato.Location = new System.Drawing.Point(113, 81);
            this.txtNomeContato.Name = "txtNomeContato";
            this.txtNomeContato.Size = new System.Drawing.Size(306, 20);
            this.txtNomeContato.TabIndex = 4;
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Location = new System.Drawing.Point(240, 29);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(179, 20);
            this.txtRazaoSocial.TabIndex = 2;
            // 
            // txtInscStatual
            // 
            this.txtInscStatual.Location = new System.Drawing.Point(132, 55);
            this.txtInscStatual.Name = "txtInscStatual";
            this.txtInscStatual.Size = new System.Drawing.Size(287, 20);
            this.txtInscStatual.TabIndex = 3;
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(40, 29);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(100, 20);
            this.txtCnpj.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cadastro de Pessoa Juridica:";
            // 
            // errorProviderFornecedorJuridico
            // 
            this.errorProviderFornecedorJuridico.ContainerControl = this;
            // 
            // FormCadastroFornecedorJuridica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 140);
            this.Controls.Add(this.panelJuridico);
            this.Name = "FormCadastroFornecedorJuridica";
            this.Text = "FormCadastroFornecedorJuridica";
            this.Load += new System.EventHandler(this.FormCadastroFornecedorJuridica_Load);
            this.panelJuridico.ResumeLayout(false);
            this.panelJuridico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFornecedorJuridico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelJuridico;
        private System.Windows.Forms.Button buttonDesvalidarJuridica;
        private System.Windows.Forms.Button ButtonValidarFornecedorJuridica;
        private System.Windows.Forms.TextBox txtNomeContato;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.TextBox txtInscStatual;
        private System.Windows.Forms.TextBox txtCnpj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProviderFornecedorJuridico;
        private System.Windows.Forms.Button buttonEditarFonecedor;
    }
}