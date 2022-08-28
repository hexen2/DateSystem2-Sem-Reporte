namespace DateSystem
{
    partial class FormRelatorioRegistroSemSubRegistro
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
            this.reportViewerRelatorioSemSubRegistro = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerRelatorioSemSubRegistro
            // 
            this.reportViewerRelatorioSemSubRegistro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerRelatorioSemSubRegistro.LocalReport.ReportEmbeddedResource = "DateSystem.ReportRelatorioSemSubRegistro.rdlc";
            this.reportViewerRelatorioSemSubRegistro.Location = new System.Drawing.Point(0, 0);
            this.reportViewerRelatorioSemSubRegistro.Name = "reportViewerRelatorioSemSubRegistro";
            this.reportViewerRelatorioSemSubRegistro.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewerRelatorioSemSubRegistro.Size = new System.Drawing.Size(737, 614);
            this.reportViewerRelatorioSemSubRegistro.TabIndex = 0;
            this.reportViewerRelatorioSemSubRegistro.Load += new System.EventHandler(this.reportViewerRelatorioSemSubRegistro_Load);
            // 
            // FormRelatorioRegistroSemSubRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 614);
            this.Controls.Add(this.reportViewerRelatorioSemSubRegistro);
            this.Name = "FormRelatorioRegistroSemSubRegistro";
            this.Text = "FormRelatorioRegistroSemSubRegistro";
            this.Load += new System.EventHandler(this.FormRelatorioRegistroSemSubRegistro_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerRelatorioSemSubRegistro;
    }
}