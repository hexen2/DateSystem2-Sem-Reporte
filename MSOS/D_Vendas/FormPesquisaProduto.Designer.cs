namespace DateSystem
{
    partial class FormPesquisaProduto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkBoxSituacao = new System.Windows.Forms.CheckBox();
            this.radioButtonTodos = new System.Windows.Forms.RadioButton();
            this.radioButtonPesquisarNome = new System.Windows.Forms.RadioButton();
            this.radioButtonPesquisarRegistro = new System.Windows.Forms.RadioButton();
            this.radioButtonOculto = new System.Windows.Forms.RadioButton();
            this.buttonCancelarOs = new System.Windows.Forms.Button();
            this.buttonFecharOs = new System.Windows.Forms.Button();
            this.dataGridViewPesquisaProdutos = new System.Windows.Forms.DataGridView();
            this.CADASTRADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTIDADE_ESTOQUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIGLA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPesquisaNomeProduto = new System.Windows.Forms.TextBox();
            this.txtPesquisaRegistroProduto = new System.Windows.Forms.TextBox();
            this.buttonPesquisaCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPesquisaProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxSituacao
            // 
            this.checkBoxSituacao.AutoSize = true;
            this.checkBoxSituacao.Checked = true;
            this.checkBoxSituacao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSituacao.Location = new System.Drawing.Point(805, 9);
            this.checkBoxSituacao.Name = "checkBoxSituacao";
            this.checkBoxSituacao.Size = new System.Drawing.Size(88, 17);
            this.checkBoxSituacao.TabIndex = 161;
            this.checkBoxSituacao.Text = ":Cliente Ativo";
            this.checkBoxSituacao.UseVisualStyleBackColor = true;
            // 
            // radioButtonTodos
            // 
            this.radioButtonTodos.AutoSize = true;
            this.radioButtonTodos.Location = new System.Drawing.Point(121, 7);
            this.radioButtonTodos.Name = "radioButtonTodos";
            this.radioButtonTodos.Size = new System.Drawing.Size(66, 17);
            this.radioButtonTodos.TabIndex = 160;
            this.radioButtonTodos.TabStop = true;
            this.radioButtonTodos.Text = "TODOS:";
            this.radioButtonTodos.UseVisualStyleBackColor = true;
            this.radioButtonTodos.CheckedChanged += new System.EventHandler(this.radioButtonTodos_CheckedChanged);
            // 
            // radioButtonPesquisarNome
            // 
            this.radioButtonPesquisarNome.AutoSize = true;
            this.radioButtonPesquisarNome.Location = new System.Drawing.Point(375, 9);
            this.radioButtonPesquisarNome.Name = "radioButtonPesquisarNome";
            this.radioButtonPesquisarNome.Size = new System.Drawing.Size(60, 17);
            this.radioButtonPesquisarNome.TabIndex = 159;
            this.radioButtonPesquisarNome.TabStop = true;
            this.radioButtonPesquisarNome.Text = "NOME:";
            this.radioButtonPesquisarNome.UseVisualStyleBackColor = true;
            this.radioButtonPesquisarNome.CheckedChanged += new System.EventHandler(this.radioButtonPesquisarNome_CheckedChanged);
            // 
            // radioButtonPesquisarRegistro
            // 
            this.radioButtonPesquisarRegistro.AutoSize = true;
            this.radioButtonPesquisarRegistro.Location = new System.Drawing.Point(193, 7);
            this.radioButtonPesquisarRegistro.Name = "radioButtonPesquisarRegistro";
            this.radioButtonPesquisarRegistro.Size = new System.Drawing.Size(107, 17);
            this.radioButtonPesquisarRegistro.TabIndex = 158;
            this.radioButtonPesquisarRegistro.TabStop = true;
            this.radioButtonPesquisarRegistro.Text = "Numero Registro:";
            this.radioButtonPesquisarRegistro.UseVisualStyleBackColor = true;
            this.radioButtonPesquisarRegistro.CheckedChanged += new System.EventHandler(this.radioButtonPesquisarRegistro_CheckedChanged);
            // 
            // radioButtonOculto
            // 
            this.radioButtonOculto.AutoSize = true;
            this.radioButtonOculto.Checked = true;
            this.radioButtonOculto.Enabled = false;
            this.radioButtonOculto.Location = new System.Drawing.Point(818, 205);
            this.radioButtonOculto.Name = "radioButtonOculto";
            this.radioButtonOculto.Size = new System.Drawing.Size(41, 17);
            this.radioButtonOculto.TabIndex = 157;
            this.radioButtonOculto.TabStop = true;
            this.radioButtonOculto.Text = "MS";
            this.radioButtonOculto.UseVisualStyleBackColor = true;
            this.radioButtonOculto.Visible = false;
            // 
            // buttonCancelarOs
            // 
            this.buttonCancelarOs.Location = new System.Drawing.Point(818, 48);
            this.buttonCancelarOs.Name = "buttonCancelarOs";
            this.buttonCancelarOs.Size = new System.Drawing.Size(26, 26);
            this.buttonCancelarOs.TabIndex = 156;
            this.buttonCancelarOs.Text = "C";
            this.buttonCancelarOs.UseVisualStyleBackColor = true;
            this.buttonCancelarOs.Click += new System.EventHandler(this.buttonCancelarOs_Click);
            // 
            // buttonFecharOs
            // 
            this.buttonFecharOs.Location = new System.Drawing.Point(818, 80);
            this.buttonFecharOs.Name = "buttonFecharOs";
            this.buttonFecharOs.Size = new System.Drawing.Size(26, 26);
            this.buttonFecharOs.TabIndex = 155;
            this.buttonFecharOs.Text = "F";
            this.buttonFecharOs.UseVisualStyleBackColor = true;
            this.buttonFecharOs.Click += new System.EventHandler(this.buttonFecharOs_Click);
            // 
            // dataGridViewPesquisaProdutos
            // 
            this.dataGridViewPesquisaProdutos.AllowUserToAddRows = false;
            this.dataGridViewPesquisaProdutos.AllowUserToDeleteRows = false;
            this.dataGridViewPesquisaProdutos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewPesquisaProdutos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPesquisaProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewPesquisaProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPesquisaProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CADASTRADO,
            this.PRODUTO,
            this.DESCRICAO,
            this.QUANTIDADE_ESTOQUE,
            this.SIGLA});
            this.dataGridViewPesquisaProdutos.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridViewPesquisaProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewPesquisaProdutos.Location = new System.Drawing.Point(12, 48);
            this.dataGridViewPesquisaProdutos.MultiSelect = false;
            this.dataGridViewPesquisaProdutos.Name = "dataGridViewPesquisaProdutos";
            this.dataGridViewPesquisaProdutos.RowHeadersVisible = false;
            this.dataGridViewPesquisaProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPesquisaProdutos.Size = new System.Drawing.Size(800, 343);
            this.dataGridViewPesquisaProdutos.TabIndex = 154;
            this.dataGridViewPesquisaProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPesquisaProdutos_CellDoubleClick);
            // 
            // CADASTRADO
            // 
            this.CADASTRADO.DataPropertyName = "CADASTRADO";
            this.CADASTRADO.HeaderText = "CADASTRADO";
            this.CADASTRADO.Name = "CADASTRADO";
            // 
            // PRODUTO
            // 
            this.PRODUTO.DataPropertyName = "PRODUTO";
            this.PRODUTO.HeaderText = "PRODUTO";
            this.PRODUTO.Name = "PRODUTO";
            this.PRODUTO.Width = 320;
            // 
            // DESCRICAO
            // 
            this.DESCRICAO.DataPropertyName = "DESCRICAO";
            this.DESCRICAO.HeaderText = "DESCRICAO";
            this.DESCRICAO.Name = "DESCRICAO";
            this.DESCRICAO.Width = 150;
            // 
            // QUANTIDADE_ESTOQUE
            // 
            this.QUANTIDADE_ESTOQUE.DataPropertyName = "QUANTIDADE_ESTOQUE";
            this.QUANTIDADE_ESTOQUE.HeaderText = "QUANTIDADE ESTOQUE";
            this.QUANTIDADE_ESTOQUE.Name = "QUANTIDADE_ESTOQUE";
            this.QUANTIDADE_ESTOQUE.Width = 130;
            // 
            // SIGLA
            // 
            this.SIGLA.DataPropertyName = "SIGLA";
            this.SIGLA.HeaderText = "SIGLA";
            this.SIGLA.Name = "SIGLA";
            // 
            // txtPesquisaNomeProduto
            // 
            this.txtPesquisaNomeProduto.Enabled = false;
            this.txtPesquisaNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaNomeProduto.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtPesquisaNomeProduto.Location = new System.Drawing.Point(441, 6);
            this.txtPesquisaNomeProduto.Name = "txtPesquisaNomeProduto";
            this.txtPesquisaNomeProduto.Size = new System.Drawing.Size(301, 21);
            this.txtPesquisaNomeProduto.TabIndex = 153;
            this.txtPesquisaNomeProduto.TextChanged += new System.EventHandler(this.txtPesquisaNomeProduto_TextChanged);
            this.txtPesquisaNomeProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesquisaNomeProduto_KeyPress);
            // 
            // txtPesquisaRegistroProduto
            // 
            this.txtPesquisaRegistroProduto.Enabled = false;
            this.txtPesquisaRegistroProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaRegistroProduto.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtPesquisaRegistroProduto.Location = new System.Drawing.Point(300, 6);
            this.txtPesquisaRegistroProduto.Name = "txtPesquisaRegistroProduto";
            this.txtPesquisaRegistroProduto.Size = new System.Drawing.Size(69, 21);
            this.txtPesquisaRegistroProduto.TabIndex = 152;
            this.txtPesquisaRegistroProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesquisaRegistroProduto_KeyPress);
            // 
            // buttonPesquisaCliente
            // 
            this.buttonPesquisaCliente.Location = new System.Drawing.Point(748, 7);
            this.buttonPesquisaCliente.Name = "buttonPesquisaCliente";
            this.buttonPesquisaCliente.Size = new System.Drawing.Size(51, 23);
            this.buttonPesquisaCliente.TabIndex = 151;
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
            this.label1.TabIndex = 150;
            this.label1.Text = "Pesquisa de Cliente:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(752, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 162;
            this.label8.Text = "0";
            // 
            // FormPesquisaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 402);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBoxSituacao);
            this.Controls.Add(this.radioButtonTodos);
            this.Controls.Add(this.radioButtonPesquisarNome);
            this.Controls.Add(this.radioButtonPesquisarRegistro);
            this.Controls.Add(this.radioButtonOculto);
            this.Controls.Add(this.buttonCancelarOs);
            this.Controls.Add(this.buttonFecharOs);
            this.Controls.Add(this.dataGridViewPesquisaProdutos);
            this.Controls.Add(this.txtPesquisaNomeProduto);
            this.Controls.Add(this.txtPesquisaRegistroProduto);
            this.Controls.Add(this.buttonPesquisaCliente);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPesquisaProduto";
            this.Text = "Pesquisa produtos Cadastrados - Itens para venda";
            this.Load += new System.EventHandler(this.FormPesquisaProduto_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormPesquisaProduto_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPesquisaProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSituacao;
        private System.Windows.Forms.RadioButton radioButtonTodos;
        private System.Windows.Forms.RadioButton radioButtonPesquisarNome;
        private System.Windows.Forms.RadioButton radioButtonPesquisarRegistro;
        private System.Windows.Forms.RadioButton radioButtonOculto;
        private System.Windows.Forms.Button buttonCancelarOs;
        private System.Windows.Forms.Button buttonFecharOs;
        private System.Windows.Forms.DataGridView dataGridViewPesquisaProdutos;
        private System.Windows.Forms.TextBox txtPesquisaNomeProduto;
        private System.Windows.Forms.TextBox txtPesquisaRegistroProduto;
        private System.Windows.Forms.Button buttonPesquisaCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn CADASTRADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTIDADE_ESTOQUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIGLA;
    }
}