using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibleImport
{
    public partial class frmMain : Form
    {
        private System.Threading.Thread threadImportar;
        private delegate void UpdateStatus(string text);
        private delegate void UpdateProgressBarMaximum(int maximum);
        private delegate void UpdateProgressBar();

        public frmMain()
        {
            InitializeComponent();
        }

        private void ReportStatus(string text)
        {
            if (txtStatus.InvokeRequired)
                txtStatus.Invoke(new UpdateStatus(ReportStatus), text);
            else
            {
                txtStatus.AppendText(text + "...\n");
                txtStatus.ScrollToCaret();
            }
        }

        private void SetMaximumProgressBar(int maximum)
        {
            if (prbStatus.InvokeRequired)
                prbStatus.Invoke(new UpdateProgressBarMaximum(SetMaximumProgressBar), maximum);
            else
                prbStatus.Maximum = maximum;
        }

        private void IncrementProgressBar()
        {
            if (prbStatus.Maximum > 0)
            {
                if (prbStatus.InvokeRequired)
                    prbStatus.Invoke(new UpdateProgressBar(IncrementProgressBar));
                else
                    prbStatus.Increment(1);
            }
        }

        private void Importar()
        {
            try
            {
                BibleView.Request.Request.ImportBibles((text) =>
                {
                    ReportStatus(text);
                    IncrementProgressBar();
                }, (maximum) =>
                {
                    SetMaximumProgressBar(maximum);
                });

                MessageBox.Show("Bíblias importadas com sucesso!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao importar. Erro: {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            btnImportar.Enabled = false;

            threadImportar = new System.Threading.Thread(new System.Threading.ThreadStart(Importar));
            threadImportar.Start();
        }
    }
}
