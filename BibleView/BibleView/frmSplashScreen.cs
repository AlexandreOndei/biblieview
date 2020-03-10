using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibleView
{
    public partial class frmSplashScreen : Form
    {
        private delegate void UpdateStatus(string text);
        private delegate void UpdateProgressBarMaximum(int maximum);
        private delegate void UpdateProgressBar();
        private delegate void CloseForm();

        public frmSplashScreen()
        {
            InitializeComponent();

            lblStatus.Text = string.Empty;
        }

        private void CloseSplash()
        {
            if (InvokeRequired)
                Invoke(new CloseForm(CloseSplash));
            else
                Close();
        }

        private void UpdateProgress()
        {
            if (prbStatus.InvokeRequired)
                prbStatus.Invoke(new UpdateProgressBar(UpdateProgress));
            else
                prbStatus.Increment(10);
        }

        private void ReportStatus(string text)
        {
            if (lblStatus.InvokeRequired)
                lblStatus.Invoke(new UpdateStatus(ReportStatus), text);
            else
                lblStatus.Text = text + "...";
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

        private void EndProcess()
        {
            ReportStatus("Carregando preferências...");

            Program.FrmMain.SelectedVersion = Program.FrmMain.Data.FirstOrDefault();

            Program.FrmMain.LoadBooks(Program.FrmMain.Data.FirstOrDefault());

            CloseSplash();
        }

        private void frmSplashScreen_Shown(object sender, EventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                ReportStatus("Carregando versões...");

                Program.FrmMain.Data = Request.Data.GetData((text) =>
                {
                    ReportStatus("Carregando a versão " + text);
                    IncrementProgressBar();
                }, (maximum) =>
                {
                    SetMaximumProgressBar(maximum);
                });

                EndProcess();
            }));
            thread.Start();
        }

        private void frmSplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.FrmMain.Show();
            Program.FrmMain.cbSearch.Focus();
        }
    }
}
