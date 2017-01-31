namespace MSOS
{
    partial class FormPesquisaClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPesquisaNomeCliente = new System.Windows.Forms.TextBox();
            this.txtPesquisaMsCliente = new System.Windows.Forms.TextBox();
            this.buttonPesquisaCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButtonOculto = new System.Windows.Forms.RadioButton();
            this.buttonCancelarOs = new System.Windows.Forms.Button();
            this.buttonFecharOs = new System.Windows.Forms.Button();
            this.radioButtonPesquisarMS = new System.Windows.Forms.RadioButton();
            this.radioButtonPesquisarNome = new System.Windows.Forms.RadioButton();
            this.radioButtonTodos = new System.Windows.Forms.RadioButton();
            this.checkBoxSituacao = new System.Windows.Forms.CheckBox();
            this.dataGridViewPesquisaCliente = new System.Windows.Forms.DataGridView();
            this.CLIENTE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEFONE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEFONE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAX_TELEFONE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEX_TELEFONE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACAO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CP_MUNICIPIO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOME_FISICO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEXO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATA_NASCIMENTO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CELULAR3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CELULAR23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJ3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOME_CONTATO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MS3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEP23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGRADOURO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDERECO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMPLEMENTO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAIRRO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIGLA_CIDADE3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRICAO_ATRIBUIDA3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPesquisaCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPesquisaNomeCliente
            // 
            this.txtPesquisaNomeCliente.Enabled = false;
            this.txtPesquisaNomeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaNomeCliente.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtPesquisaNomeCliente.Location = new System.Drawing.Point(384, 6);
            this.txtPesquisaNomeCliente.Name = "txtPesquisaNomeCliente";
            this.txtPesquisaNomeCliente.Size = new System.Drawing.Size(301, 21);
            this.txtPesquisaNomeCliente.TabIndex = 59;
            this.txtPesquisaNomeCliente.TextChanged += new System.EventHandler(this.txtPesquisaNomeCliente_TextChanged);
            // 
            // txtPesquisaMsCliente
            // 
            this.txtPesquisaMsCliente.Enabled = false;
            this.txtPesquisaMsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaMsCliente.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtPesquisaMsCliente.Location = new System.Drawing.Point(243, 6);
            this.txtPesquisaMsCliente.Name = "txtPesquisaMsCliente";
            this.txtPesquisaMsCliente.Size = new System.Drawing.Size(69, 21);
            this.txtPesquisaMsCliente.TabIndex = 58;
            this.txtPesquisaMsCliente.TextChanged += new System.EventHandler(this.txtPesquisaMsCliente_TextChanged);
            // 
            // buttonPesquisaCliente
            // 
            this.buttonPesquisaCliente.Location = new System.Drawing.Point(691, 7);
            this.buttonPesquisaCliente.Name = "buttonPesquisaCliente";
            this.buttonPesquisaCliente.Size = new System.Drawing.Size(51, 23);
            this.buttonPesquisaCliente.TabIndex = 57;
            this.buttonPesquisaCliente.Text = "Busca";
            this.buttonPesquisaCliente.UseVisualStyleBackColor = true;
            this.buttonPesquisaCliente.Click += new System.EventHandler(this.buttonPesquisaCliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Pesquisa de Cliente:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(908, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 131;
            this.label8.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(927, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 130;
            this.label6.Text = "Quantidade";
            // 
            // radioButtonOculto
            // 
            this.radioButtonOculto.AutoSize = true;
            this.radioButtonOculto.Checked = true;
            this.radioButtonOculto.Enabled = false;
            this.radioButtonOculto.Location = new System.Drawing.Point(995, 202);
            this.radioButtonOculto.Name = "radioButtonOculto";
            this.radioButtonOculto.Size = new System.Drawing.Size(41, 17);
            this.radioButtonOculto.TabIndex = 129;
            this.radioButtonOculto.TabStop = true;
            this.radioButtonOculto.Text = "MS";
            this.radioButtonOculto.UseVisualStyleBackColor = true;
            this.radioButtonOculto.Visible = false;
            // 
            // buttonCancelarOs
            // 
            this.buttonCancelarOs.Location = new System.Drawing.Point(995, 36);
            this.buttonCancelarOs.Name = "buttonCancelarOs";
            this.buttonCancelarOs.Size = new System.Drawing.Size(26, 26);
            this.buttonCancelarOs.TabIndex = 128;
            this.buttonCancelarOs.Text = "C";
            this.buttonCancelarOs.UseVisualStyleBackColor = true;
            this.buttonCancelarOs.Click += new System.EventHandler(this.buttonCancelarOs_Click);
            // 
            // buttonFecharOs
            // 
            this.buttonFecharOs.Location = new System.Drawing.Point(995, 68);
            this.buttonFecharOs.Name = "buttonFecharOs";
            this.buttonFecharOs.Size = new System.Drawing.Size(26, 26);
            this.buttonFecharOs.TabIndex = 126;
            this.buttonFecharOs.Text = "F";
            this.buttonFecharOs.UseVisualStyleBackColor = true;
            this.buttonFecharOs.Click += new System.EventHandler(this.buttonFecharOs_Click);
            // 
            // radioButtonPesquisarMS
            // 
            this.radioButtonPesquisarMS.AutoSize = true;
            this.radioButtonPesquisarMS.Location = new System.Drawing.Point(193, 7);
            this.radioButtonPesquisarMS.Name = "radioButtonPesquisarMS";
            this.radioButtonPesquisarMS.Size = new System.Drawing.Size(44, 17);
            this.radioButtonPesquisarMS.TabIndex = 132;
            this.radioButtonPesquisarMS.TabStop = true;
            this.radioButtonPesquisarMS.Text = "MS:";
            this.radioButtonPesquisarMS.UseVisualStyleBackColor = true;
            this.radioButtonPesquisarMS.CheckedChanged += new System.EventHandler(this.radioButtonPesquisarMS_CheckedChanged);
            // 
            // radioButtonPesquisarNome
            // 
            this.radioButtonPesquisarNome.AutoSize = true;
            this.radioButtonPesquisarNome.Location = new System.Drawing.Point(318, 9);
            this.radioButtonPesquisarNome.Name = "radioButtonPesquisarNome";
            this.radioButtonPesquisarNome.Size = new System.Drawing.Size(60, 17);
            this.radioButtonPesquisarNome.TabIndex = 133;
            this.radioButtonPesquisarNome.TabStop = true;
            this.radioButtonPesquisarNome.Text = "NOME:";
            this.radioButtonPesquisarNome.UseVisualStyleBackColor = true;
            this.radioButtonPesquisarNome.CheckedChanged += new System.EventHandler(this.radioButtonPesquisarNome_CheckedChanged);
            // 
            // radioButtonTodos
            // 
            this.radioButtonTodos.AutoSize = true;
            this.radioButtonTodos.Location = new System.Drawing.Point(121, 7);
            this.radioButtonTodos.Name = "radioButtonTodos";
            this.radioButtonTodos.Size = new System.Drawing.Size(66, 17);
            this.radioButtonTodos.TabIndex = 135;
            this.radioButtonTodos.TabStop = true;
            this.radioButtonTodos.Text = "TODOS:";
            this.radioButtonTodos.UseVisualStyleBackColor = true;
            this.radioButtonTodos.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // checkBoxSituacao
            // 
            this.checkBoxSituacao.AutoSize = true;
            this.checkBoxSituacao.Checked = true;
            this.checkBoxSituacao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSituacao.Location = new System.Drawing.Point(748, 9);
            this.checkBoxSituacao.Name = "checkBoxSituacao";
            this.checkBoxSituacao.Size = new System.Drawing.Size(88, 17);
            this.checkBoxSituacao.TabIndex = 136;
            this.checkBoxSituacao.Text = "Cliente Ativo:";
            this.checkBoxSituacao.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPesquisaCliente
            // 
            this.dataGridViewPesquisaCliente.AllowUserToAddRows = false;
            this.dataGridViewPesquisaCliente.AllowUserToDeleteRows = false;
            this.dataGridViewPesquisaCliente.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewPesquisaCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewPesquisaCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewPesquisaCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPesquisaCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLIENTE1,
            this.TELEFONE1,
            this.TELEFONE2,
            this.FAX_TELEFONE1,
            this.TELEX_TELEFONE2,
            this.EMAIL3,
            this.OBSERVACAO3,
            this.TIPO3,
            this.CP_MUNICIPIO3,
            this.NOME_FISICO3,
            this.SEXO3,
            this.CPF3,
            this.DATA_NASCIMENTO3,
            this.CELULAR3,
            this.CELULAR23,
            this.CNPJ3,
            this.NOME_CONTATO3,
            this.MS3,
            this.CEP23,
            this.LOGRADOURO3,
            this.ENDERECO3,
            this.NUMERO3,
            this.COMPLEMENTO3,
            this.BAIRRO3,
            this.SIGLA_CIDADE3,
            this.DESCRICAO_ATRIBUIDA3});
            this.dataGridViewPesquisaCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridViewPesquisaCliente.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPesquisaCliente.Location = new System.Drawing.Point(12, 36);
            this.dataGridViewPesquisaCliente.MultiSelect = false;
            this.dataGridViewPesquisaCliente.Name = "dataGridViewPesquisaCliente";
            this.dataGridViewPesquisaCliente.RowHeadersVisible = false;
            this.dataGridViewPesquisaCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPesquisaCliente.Size = new System.Drawing.Size(977, 343);
            this.dataGridViewPesquisaCliente.TabIndex = 124;
            this.dataGridViewPesquisaCliente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPesquisaCliente_CellDoubleClick);
            // 
            // CLIENTE1
            // 
            this.CLIENTE1.DataPropertyName = "CLIENTE";
            this.CLIENTE1.HeaderText = "CLIENTE";
            this.CLIENTE1.Name = "CLIENTE1";
            this.CLIENTE1.Width = 60;
            // 
            // TELEFONE1
            // 
            this.TELEFONE1.DataPropertyName = "TELEFONE";
            this.TELEFONE1.HeaderText = "TELEFONE";
            this.TELEFONE1.Name = "TELEFONE1";
            // 
            // TELEFONE2
            // 
            this.TELEFONE2.DataPropertyName = "TELEFONE2";
            this.TELEFONE2.HeaderText = "TELEFONE2";
            this.TELEFONE2.Name = "TELEFONE2";
            // 
            // FAX_TELEFONE1
            // 
            this.FAX_TELEFONE1.DataPropertyName = "FAX_TELEFONE";
            this.FAX_TELEFONE1.HeaderText = "FAX TELEFONE";
            this.FAX_TELEFONE1.Name = "FAX_TELEFONE1";
            this.FAX_TELEFONE1.Width = 150;
            // 
            // TELEX_TELEFONE2
            // 
            this.TELEX_TELEFONE2.DataPropertyName = "TELEX_TELEFONE";
            this.TELEX_TELEFONE2.HeaderText = "TELEX TELEFONE";
            this.TELEX_TELEFONE2.Name = "TELEX_TELEFONE2";
            this.TELEX_TELEFONE2.Width = 150;
            // 
            // EMAIL3
            // 
            this.EMAIL3.DataPropertyName = "EMAIL";
            this.EMAIL3.HeaderText = "EMAIL";
            this.EMAIL3.Name = "EMAIL3";
            this.EMAIL3.Width = 60;
            // 
            // OBSERVACAO3
            // 
            this.OBSERVACAO3.DataPropertyName = "OBSERVACAO";
            this.OBSERVACAO3.HeaderText = "OBSERVACAO";
            this.OBSERVACAO3.Name = "OBSERVACAO3";
            // 
            // TIPO3
            // 
            this.TIPO3.DataPropertyName = "TIPO";
            this.TIPO3.HeaderText = "TIPO";
            this.TIPO3.Name = "TIPO3";
            // 
            // CP_MUNICIPIO3
            // 
            this.CP_MUNICIPIO3.DataPropertyName = "CP_MUNICIPIO";
            this.CP_MUNICIPIO3.HeaderText = "CP MUNICIPIO";
            this.CP_MUNICIPIO3.Name = "CP_MUNICIPIO3";
            // 
            // NOME_FISICO3
            // 
            this.NOME_FISICO3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NOME_FISICO3.DataPropertyName = "NOME_FISICO";
            this.NOME_FISICO3.HeaderText = "NOME PESSOA FISICO";
            this.NOME_FISICO3.Name = "NOME_FISICO3";
            // 
            // SEXO3
            // 
            this.SEXO3.DataPropertyName = "SEXO";
            this.SEXO3.HeaderText = "SEXO";
            this.SEXO3.Name = "SEXO3";
            // 
            // CPF3
            // 
            this.CPF3.DataPropertyName = "CPF";
            this.CPF3.HeaderText = "CPF";
            this.CPF3.Name = "CPF3";
            // 
            // DATA_NASCIMENTO3
            // 
            this.DATA_NASCIMENTO3.DataPropertyName = "DATA_NASCIMENTO";
            this.DATA_NASCIMENTO3.HeaderText = "DATA NASCIMENTO";
            this.DATA_NASCIMENTO3.Name = "DATA_NASCIMENTO3";
            // 
            // CELULAR3
            // 
            this.CELULAR3.DataPropertyName = "CELULAR";
            dataGridViewCellStyle8.Format = "(99) 0000-0000";
            dataGridViewCellStyle8.NullValue = null;
            this.CELULAR3.DefaultCellStyle = dataGridViewCellStyle8;
            this.CELULAR3.HeaderText = "CELULAR";
            this.CELULAR3.Name = "CELULAR3";
            // 
            // CELULAR23
            // 
            this.CELULAR23.DataPropertyName = "CELULAR2";
            dataGridViewCellStyle9.Format = "(00)0000-0000";
            dataGridViewCellStyle9.NullValue = "0000000000";
            this.CELULAR23.DefaultCellStyle = dataGridViewCellStyle9;
            this.CELULAR23.FillWeight = 150F;
            this.CELULAR23.HeaderText = "CELULAR2";
            this.CELULAR23.Name = "CELULAR23";
            // 
            // CNPJ3
            // 
            this.CNPJ3.DataPropertyName = "CNPJ";
            this.CNPJ3.FillWeight = 150F;
            this.CNPJ3.HeaderText = "CNPJ";
            this.CNPJ3.Name = "CNPJ3";
            // 
            // NOME_CONTATO3
            // 
            this.NOME_CONTATO3.DataPropertyName = "NOME_CONTATO";
            this.NOME_CONTATO3.HeaderText = "NOME CONTATO";
            this.NOME_CONTATO3.Name = "NOME_CONTATO3";
            // 
            // MS3
            // 
            this.MS3.DataPropertyName = "MS";
            this.MS3.HeaderText = "MS";
            this.MS3.Name = "MS3";
            // 
            // CEP23
            // 
            this.CEP23.DataPropertyName = "CEP2";
            this.CEP23.HeaderText = "CEP";
            this.CEP23.Name = "CEP23";
            // 
            // LOGRADOURO3
            // 
            this.LOGRADOURO3.DataPropertyName = "LOGRADOURO";
            this.LOGRADOURO3.HeaderText = "LOGRADOURO";
            this.LOGRADOURO3.Name = "LOGRADOURO3";
            // 
            // ENDERECO3
            // 
            this.ENDERECO3.DataPropertyName = "ENDERECO";
            this.ENDERECO3.HeaderText = "ENDEREÇO";
            this.ENDERECO3.Name = "ENDERECO3";
            // 
            // NUMERO3
            // 
            this.NUMERO3.DataPropertyName = "NUMERO";
            this.NUMERO3.HeaderText = "NUMERO";
            this.NUMERO3.Name = "NUMERO3";
            this.NUMERO3.Visible = false;
            // 
            // COMPLEMENTO3
            // 
            this.COMPLEMENTO3.DataPropertyName = "COMPLEMENTO";
            this.COMPLEMENTO3.HeaderText = "COMPLEMENTO";
            this.COMPLEMENTO3.Name = "COMPLEMENTO3";
            // 
            // BAIRRO3
            // 
            this.BAIRRO3.DataPropertyName = "BAIRRO";
            this.BAIRRO3.HeaderText = "BAIRRO";
            this.BAIRRO3.Name = "BAIRRO3";
            // 
            // SIGLA_CIDADE3
            // 
            this.SIGLA_CIDADE3.DataPropertyName = "SIGLA_CIDADE";
            this.SIGLA_CIDADE3.HeaderText = "SIGLA CIDADE";
            this.SIGLA_CIDADE3.Name = "SIGLA_CIDADE3";
            // 
            // DESCRICAO_ATRIBUIDA3
            // 
            this.DESCRICAO_ATRIBUIDA3.DataPropertyName = "DESCRICAO_ATRIBUIDA";
            this.DESCRICAO_ATRIBUIDA3.HeaderText = "DESCRIÇÃO ATRIBUIDA";
            this.DESCRICAO_ATRIBUIDA3.Name = "DESCRICAO_ATRIBUIDA3";
            // 
            // FormPesquisaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 401);
            this.Controls.Add(this.checkBoxSituacao);
            this.Controls.Add(this.radioButtonTodos);
            this.Controls.Add(this.radioButtonPesquisarNome);
            this.Controls.Add(this.radioButtonPesquisarMS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radioButtonOculto);
            this.Controls.Add(this.buttonCancelarOs);
            this.Controls.Add(this.buttonFecharOs);
            this.Controls.Add(this.dataGridViewPesquisaCliente);
            this.Controls.Add(this.txtPesquisaNomeCliente);
            this.Controls.Add(this.txtPesquisaMsCliente);
            this.Controls.Add(this.buttonPesquisaCliente);
            this.Controls.Add(this.label1);
            this.Name = "FormPesquisaClientes";
            this.Text = "FormPesquisaClientes";
            this.Load += new System.EventHandler(this.FormPesquisaClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPesquisaCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPesquisaNomeCliente;
        private System.Windows.Forms.TextBox txtPesquisaMsCliente;
        private System.Windows.Forms.Button buttonPesquisaCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonOculto;
        private System.Windows.Forms.Button buttonCancelarOs;
        private System.Windows.Forms.Button buttonFecharOs;
        private System.Windows.Forms.RadioButton radioButtonPesquisarMS;
        private System.Windows.Forms.RadioButton radioButtonPesquisarNome;
        private System.Windows.Forms.RadioButton radioButtonTodos;
        private System.Windows.Forms.CheckBox checkBoxSituacao;
        private System.Windows.Forms.DataGridView dataGridViewPesquisaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEFONE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEFONE2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAX_TELEFONE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEX_TELEFONE2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL3;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACAO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CP_MUNICIPIO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME_FISICO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEXO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA_NASCIMENTO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CELULAR3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CELULAR23;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJ3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME_CONTATO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MS3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEP23;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGRADOURO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDERECO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPLEMENTO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAIRRO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIGLA_CIDADE3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRICAO_ATRIBUIDA3;
    }
}