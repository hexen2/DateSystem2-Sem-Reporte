namespace MSOS
{
    partial class FormPesquisaFornecedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonFornecedorPesquisa = new System.Windows.Forms.Button();
            this.txtPesquisaClienteFornecedor = new System.Windows.Forms.TextBox();
            this.radioButtonPesquisaCliente = new System.Windows.Forms.RadioButton();
            this.radioButtonRazaoSocial = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisaMSFornecedor = new System.Windows.Forms.TextBox();
            this.dataGridViewPesquisa = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButtonObservacao = new System.Windows.Forms.RadioButton();
            this.buttonCancelarOs = new System.Windows.Forms.Button();
            this.buttonFecharOs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFornecedorPesquisa
            // 
            this.buttonFornecedorPesquisa.Enabled = false;
            this.buttonFornecedorPesquisa.Location = new System.Drawing.Point(932, 5);
            this.buttonFornecedorPesquisa.Name = "buttonFornecedorPesquisa";
            this.buttonFornecedorPesquisa.Size = new System.Drawing.Size(48, 23);
            this.buttonFornecedorPesquisa.TabIndex = 66;
            this.buttonFornecedorPesquisa.Text = "Busca";
            this.buttonFornecedorPesquisa.UseVisualStyleBackColor = true;
            this.buttonFornecedorPesquisa.Click += new System.EventHandler(this.buttonFornecedorPesquisa_Click);
            // 
            // txtPesquisaClienteFornecedor
            // 
            this.txtPesquisaClienteFornecedor.Enabled = false;
            this.txtPesquisaClienteFornecedor.Location = new System.Drawing.Point(417, 5);
            this.txtPesquisaClienteFornecedor.Name = "txtPesquisaClienteFornecedor";
            this.txtPesquisaClienteFornecedor.Size = new System.Drawing.Size(198, 20);
            this.txtPesquisaClienteFornecedor.TabIndex = 65;
            // 
            // radioButtonPesquisaCliente
            // 
            this.radioButtonPesquisaCliente.AutoSize = true;
            this.radioButtonPesquisaCliente.Enabled = false;
            this.radioButtonPesquisaCliente.Location = new System.Drawing.Point(343, 7);
            this.radioButtonPesquisaCliente.Name = "radioButtonPesquisaCliente";
            this.radioButtonPesquisaCliente.Size = new System.Drawing.Size(73, 17);
            this.radioButtonPesquisaCliente.TabIndex = 64;
            this.radioButtonPesquisaCliente.TabStop = true;
            this.radioButtonPesquisaCliente.Text = "CLIENTE:";
            this.radioButtonPesquisaCliente.UseVisualStyleBackColor = true;
            // 
            // radioButtonRazaoSocial
            // 
            this.radioButtonRazaoSocial.AutoSize = true;
            this.radioButtonRazaoSocial.Enabled = false;
            this.radioButtonRazaoSocial.Location = new System.Drawing.Point(121, 7);
            this.radioButtonRazaoSocial.Name = "radioButtonRazaoSocial";
            this.radioButtonRazaoSocial.Size = new System.Drawing.Size(144, 17);
            this.radioButtonRazaoSocial.TabIndex = 63;
            this.radioButtonRazaoSocial.TabStop = true;
            this.radioButtonRazaoSocial.Text = "RAZÃO SOCIAL(NOME):";
            this.radioButtonRazaoSocial.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Pesquisa de Cliente:";
            // 
            // txtPesquisaMSFornecedor
            // 
            this.txtPesquisaMSFornecedor.Enabled = false;
            this.txtPesquisaMSFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaMSFornecedor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtPesquisaMSFornecedor.Location = new System.Drawing.Point(266, 5);
            this.txtPesquisaMSFornecedor.Name = "txtPesquisaMSFornecedor";
            this.txtPesquisaMSFornecedor.Size = new System.Drawing.Size(69, 21);
            this.txtPesquisaMSFornecedor.TabIndex = 60;
            // 
            // dataGridViewPesquisa
            // 
            this.dataGridViewPesquisa.AllowUserToAddRows = false;
            this.dataGridViewPesquisa.AllowUserToDeleteRows = false;
            this.dataGridViewPesquisa.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewPesquisa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPesquisa.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridViewPesquisa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPesquisa.Location = new System.Drawing.Point(12, 33);
            this.dataGridViewPesquisa.MultiSelect = false;
            this.dataGridViewPesquisa.Name = "dataGridViewPesquisa";
            this.dataGridViewPesquisa.RowHeadersVisible = false;
            this.dataGridViewPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPesquisa.Size = new System.Drawing.Size(977, 337);
            this.dataGridViewPesquisa.TabIndex = 96;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(728, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 20);
            this.textBox1.TabIndex = 98;
            // 
            // radioButtonObservacao
            // 
            this.radioButtonObservacao.AutoSize = true;
            this.radioButtonObservacao.Enabled = false;
            this.radioButtonObservacao.Location = new System.Drawing.Point(621, 7);
            this.radioButtonObservacao.Name = "radioButtonObservacao";
            this.radioButtonObservacao.Size = new System.Drawing.Size(101, 17);
            this.radioButtonObservacao.TabIndex = 97;
            this.radioButtonObservacao.TabStop = true;
            this.radioButtonObservacao.Text = "OBSERVAÇÃO:";
            this.radioButtonObservacao.UseVisualStyleBackColor = true;
            // 
            // buttonCancelarOs
            // 
            this.buttonCancelarOs.Location = new System.Drawing.Point(995, 33);
            this.buttonCancelarOs.Name = "buttonCancelarOs";
            this.buttonCancelarOs.Size = new System.Drawing.Size(26, 26);
            this.buttonCancelarOs.TabIndex = 130;
            this.buttonCancelarOs.Text = "C";
            this.buttonCancelarOs.UseVisualStyleBackColor = true;
            this.buttonCancelarOs.Click += new System.EventHandler(this.buttonCancelarOs_Click);
            // 
            // buttonFecharOs
            // 
            this.buttonFecharOs.Location = new System.Drawing.Point(995, 65);
            this.buttonFecharOs.Name = "buttonFecharOs";
            this.buttonFecharOs.Size = new System.Drawing.Size(26, 26);
            this.buttonFecharOs.TabIndex = 129;
            this.buttonFecharOs.Text = "F";
            this.buttonFecharOs.UseVisualStyleBackColor = true;
            this.buttonFecharOs.Click += new System.EventHandler(this.buttonFecharOs_Click);
            // 
            // FormPesquisaFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 598);
            this.Controls.Add(this.buttonCancelarOs);
            this.Controls.Add(this.buttonFecharOs);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioButtonObservacao);
            this.Controls.Add(this.dataGridViewPesquisa);
            this.Controls.Add(this.buttonFornecedorPesquisa);
            this.Controls.Add(this.txtPesquisaClienteFornecedor);
            this.Controls.Add(this.radioButtonPesquisaCliente);
            this.Controls.Add(this.radioButtonRazaoSocial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPesquisaMSFornecedor);
            this.Name = "FormPesquisaFornecedor";
            this.Text = "FormPesquisaFornecedor";
            this.Load += new System.EventHandler(this.FormPesquisaFornecedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFornecedorPesquisa;
        private System.Windows.Forms.TextBox txtPesquisaClienteFornecedor;
        private System.Windows.Forms.RadioButton radioButtonPesquisaCliente;
        private System.Windows.Forms.RadioButton radioButtonRazaoSocial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisaMSFornecedor;
        private System.Windows.Forms.DataGridView dataGridViewPesquisa;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonObservacao;
        private System.Windows.Forms.Button buttonCancelarOs;
        private System.Windows.Forms.Button buttonFecharOs;
    }
}