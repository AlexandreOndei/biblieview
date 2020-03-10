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
    public partial class frmVerseView : Form
    {
        public frmVerseView()
        {
            InitializeComponent();
        }

        public void SelectVerse(string version, string bookName, int chapterNumber, Request.Models.Verse verse)
        {
            lblTitle.Text = $"{bookName} {chapterNumber}:{verse.Number}";
            lblVerse.Text = verse.Text;
            lblVersion.Text = version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.FrmMain.btnHide.Hide();
            Program.FrmMain.btnShow.Show();

            Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
