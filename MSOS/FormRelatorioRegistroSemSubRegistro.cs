using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSystem
{
    public partial class FormRelatorioRegistroSemSubRegistro : Form
    {
        public FormRelatorioRegistroSemSubRegistro(string nome)
        {
            try
            {
                InitializeComponent();
                reportViewerRelatorioSemSubRegistro.LocalReport.DataSources.Clear();

                reportViewerRelatorioSemSubRegistro.LocalReport.ReportEmbeddedResource = "DateSystem.ReportRelatorioSemSubRegistro.rdlc";

                Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[1];
                p[0] = new Microsoft.Reporting.WinForms.ReportParameter("Nome", nome);

                reportViewerRelatorioSemSubRegistro.LocalReport.SetParameters(p);
                reportViewerRelatorioSemSubRegistro.LocalReport.Refresh();
                reportViewerRelatorioSemSubRegistro.RefreshReport();

            }
            catch(Exception e)
            {
                e.InnerException.ToString();
            }


        }

        private void FormRelatorioRegistroSemSubRegistro_Load(object sender, EventArgs e)
        {

            this.reportViewerRelatorioSemSubRegistro.RefreshReport();
        }

        private void reportViewerRelatorioSemSubRegistro_Load(object sender, EventArgs e)
        {

        }
    }
}
