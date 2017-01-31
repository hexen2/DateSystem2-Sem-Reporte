namespace MSOS
{
    partial class FormCadastroClientesJuridico
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
            System.Windows.Forms.Label cNPJLabel;
            System.Windows.Forms.Label iNSCRICAO_STADUALLabel;
            System.Windows.Forms.Label rAZAO_SOCIALLabel;
            System.Windows.Forms.Label nOME_CONTATOLabel;
            this.panelJuridico = new System.Windows.Forms.Panel();
            this.buttonDesvalidarJuridica = new System.Windows.Forms.Button();
            this.ButtonValidarPessoaJuridica = new System.Windows.Forms.Button();
            this.txtnOME_CONTATOTextBox = new System.Windows.Forms.TextBox();
            this.p_ClientePessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtrAZAO_SOCIALTextBox = new System.Windows.Forms.TextBox();
            this.txtiNSCRICAO_STADUALTextBox = new System.Windows.Forms.TextBox();
            this.txtCnpJTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProviderClienteJuridica = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonEditarClienteJuridico = new System.Windows.Forms.Button();
            cNPJLabel = new System.Windows.Forms.Label();
            iNSCRICAO_STADUALLabel = new System.Windows.Forms.Label();
            rAZAO_SOCIALLabel = new System.Windows.Forms.Label();
            nOME_CONTATOLabel = new System.Windows.Forms.Label();
            this.panelJuridico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_ClientePessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClienteJuridica)).BeginInit();
            this.SuspendLayout();
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
            // iNSCRICAO_STADUALLabel
            // 
            iNSCRICAO_STADUALLabel.AutoSize = true;
            iNSCRICAO_STADUALLabel.Location = new System.Drawing.Point(5, 58);
            iNSCRICAO_STADUALLabel.Name = "iNSCRICAO_STADUALLabel";
            iNSCRICAO_STADUALLabel.Size = new System.Drawing.Size(121, 13);
            iNSCRICAO_STADUALLabel.TabIndex = 70;
            iNSCRICAO_STADUALLabel.Text = "INSCRICAO STADUAL:";
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
            // nOME_CONTATOLabel
            // 
            nOME_CONTATOLabel.AutoSize = true;
            nOME_CONTATOLabel.Location = new System.Drawing.Point(10, 84);
            nOME_CONTATOLabel.Name = "nOME_CONTATOLabel";
            nOME_CONTATOLabel.Size = new System.Drawing.Size(97, 13);
            nOME_CONTATOLabel.TabIndex = 73;
            nOME_CONTATOLabel.Text = "NOME CONTATO:";
            // 
            // panelJuridico
            // 
            this.panelJuridico.Controls.Add(this.buttonEditarClienteJuridico);
            this.panelJuridico.Controls.Add(this.buttonDesvalidarJuridica);
            this.panelJuridico.Controls.Add(this.ButtonValidarPessoaJuridica);
            this.panelJuridico.Controls.Add(nOME_CONTATOLabel);
            this.panelJuridico.Controls.Add(this.txtnOME_CONTATOTextBox);
            this.panelJuridico.Controls.Add(rAZAO_SOCIALLabel);
            this.panelJuridico.Controls.Add(this.txtrAZAO_SOCIALTextBox);
            this.panelJuridico.Controls.Add(iNSCRICAO_STADUALLabel);
            this.panelJuridico.Controls.Add(this.txtiNSCRICAO_STADUALTextBox);
            this.panelJuridico.Controls.Add(cNPJLabel);
            this.panelJuridico.Controls.Add(this.txtCnpJTextBox);
            this.panelJuridico.Controls.Add(this.label1);
            this.panelJuridico.Location = new System.Drawing.Point(3, 7);
            this.panelJuridico.Name = "panelJuridico";
            this.panelJuridico.Size = new System.Drawing.Size(439, 110);
            this.panelJuridico.TabIndex = 9;
            this.panelJuridico.Paint += new System.Windows.Forms.PaintEventHandler(this.panelJuridico_Paint);
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
            this.buttonDesvalidarJuridica.Click += new System.EventHandler(this.buttonDesvalidarJuridica_Click);
            // 
            // ButtonValidarPessoaJuridica
            // 
            this.ButtonValidarPessoaJuridica.BackgroundImage = global::MSOS.Properties.Resources.SalvarDadosClientes;
            this.ButtonValidarPessoaJuridica.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButtonValidarPessoaJuridica.Location = new System.Drawing.Point(346, 0);
            this.ButtonValidarPessoaJuridica.Name = "ButtonValidarPessoaJuridica";
            this.ButtonValidarPessoaJuridica.Size = new System.Drawing.Size(26, 26);
            this.ButtonValidarPessoaJuridica.TabIndex = 0;
            this.ButtonValidarPessoaJuridica.UseVisualStyleBackColor = true;
            this.ButtonValidarPessoaJuridica.Click += new System.EventHandler(this.ButtonValidarPessoaJuridica_Click);
            // 
            // txtnOME_CONTATOTextBox
            // 
            this.txtnOME_CONTATOTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.p_ClientePessoaBindingSource, "P_Juridica.NOME_CONTATO", true));
            this.txtnOME_CONTATOTextBox.Location = new System.Drawing.Point(113, 81);
            this.txtnOME_CONTATOTextBox.Name = "txtnOME_CONTATOTextBox";
            this.txtnOME_CONTATOTextBox.Size = new System.Drawing.Size(306, 20);
            this.txtnOME_CONTATOTextBox.TabIndex = 4;
            // 
            // p_ClientePessoaBindingSource
            // 
            this.p_ClientePessoaBindingSource.DataSource = typeof(MSOS.P_ClientePessoa);
            // 
            // txtrAZAO_SOCIALTextBox
            // 
            this.txtrAZAO_SOCIALTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.p_ClientePessoaBindingSource, "P_Juridica.RAZAO_SOCIAL", true));
            this.txtrAZAO_SOCIALTextBox.Location = new System.Drawing.Point(240, 29);
            this.txtrAZAO_SOCIALTextBox.Name = "txtrAZAO_SOCIALTextBox";
            this.txtrAZAO_SOCIALTextBox.Size = new System.Drawing.Size(179, 20);
            this.txtrAZAO_SOCIALTextBox.TabIndex = 2;
            // 
            // txtiNSCRICAO_STADUALTextBox
            // 
            this.txtiNSCRICAO_STADUALTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.p_ClientePessoaBindingSource, "P_Juridica.INSCRICAO_STADUAL", true));
            this.txtiNSCRICAO_STADUALTextBox.Location = new System.Drawing.Point(132, 55);
            this.txtiNSCRICAO_STADUALTextBox.Name = "txtiNSCRICAO_STADUALTextBox";
            this.txtiNSCRICAO_STADUALTextBox.Size = new System.Drawing.Size(287, 20);
            this.txtiNSCRICAO_STADUALTextBox.TabIndex = 3;
            // 
            // txtCnpJTextBox
            // 
            this.txtCnpJTextBox.Location = new System.Drawing.Point(40, 29);
            this.txtCnpJTextBox.Name = "txtCnpJTextBox";
            this.txtCnpJTextBox.Size = new System.Drawing.Size(100, 20);
            this.txtCnpJTextBox.TabIndex = 1;
            this.txtCnpJTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCnpJTextBox_KeyPress);
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
            // errorProviderClienteJuridica
            // 
            this.errorProviderClienteJuridica.ContainerControl = this;
            // 
            // buttonEditarClienteJuridico
            // 
            this.buttonEditarClienteJuridico.Location = new System.Drawing.Point(378, 0);
            this.buttonEditarClienteJuridico.Name = "buttonEditarClienteJuridico";
            this.buttonEditarClienteJuridico.Size = new System.Drawing.Size(26, 26);
            this.buttonEditarClienteJuridico.TabIndex = 74;
            this.buttonEditarClienteJuridico.Text = "E";
            this.buttonEditarClienteJuridico.UseVisualStyleBackColor = true;
            this.buttonEditarClienteJuridico.Click += new System.EventHandler(this.buttonEditarClienteJuridico_Click);
            // 
            // FormCadastroClientesJuridico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 128);
            this.ControlBox = false;
            this.Controls.Add(this.panelJuridico);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroClientesJuridico";
            this.Text = "FormCadastroClientesJuridico";
            this.Load += new System.EventHandler(this.FormCadastroClientesJuridico_Load);
            this.panelJuridico.ResumeLayout(false);
            this.panelJuridico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_ClientePessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClienteJuridica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelJuridico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtrAZAO_SOCIALTextBox;
        private System.Windows.Forms.BindingSource p_ClientePessoaBindingSource;
        private System.Windows.Forms.TextBox txtiNSCRICAO_STADUALTextBox;
        private System.Windows.Forms.TextBox txtCnpJTextBox;
        private System.Windows.Forms.TextBox txtnOME_CONTATOTextBox;
        private System.Windows.Forms.ErrorProvider errorProviderClienteJuridica;
        private System.Windows.Forms.Button buttonDesvalidarJuridica;
        private System.Windows.Forms.Button ButtonValidarPessoaJuridica;
        private System.Windows.Forms.Button buttonEditarClienteJuridico;
    }
}