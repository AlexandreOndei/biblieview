using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibleView.Request.Extensions;

namespace BibleView
{
    public partial class frmMain : Form
    {
        public List<Request.Models.Version> Data { get; set; }
        public Request.Models.Version SelectedVersion { get; set; }
        public List<Request.Models.BookView> BookList { get; set; }
        public Request.Models.BookView SelectedBook { get; set; }
        public Request.Models.Chapter SelectedChapter { get; set; }
        public Request.Models.Verse SelectedVerse { get; set; }

        public frmMain()
        {
            InitializeComponent();

            pnVerses.Controls.Clear();
            btnShow.Show();
            btnHide.Hide();

            Program.FrmMain = this;
            Program.FrmVerseView = new frmVerseView();

            Hide();

            var frmSplashScreen = new frmSplashScreen();
            frmSplashScreen.ShowDialog();
        }

        public void LoadBooks(Request.Models.Version version)
        {
            cbBook.DataSource = GetBooks(version);
            cbBook.DisplayMember = cbBook.ValueMember = "Name";
            cbBook.SelectedIndex = 0;
        }

        public List<Request.Models.BookView> GetBooks(Request.Models.Version version)
        {
            return version.BooksList.Select(book => new Request.Models.BookView
            {
                Name = book.Name,
                ChapterList = book.ChaptersList.Select(chapter => new
                {
                    chapter.Number,
                    VersesCount = chapter.VersesList.Count()
                }).ToDictionary(key => key.Number, value => value.VersesCount)
            }).ToList();
        }

        private void SelectBook()
        {
            SelectedBook = (Request.Models.BookView)cbBook.SelectedItem;
        }

        private void LoadChapterView()
        {
            pnVerses.Controls.Clear();

            foreach (var verse in SelectedChapter.VersesList)
            {
                pnVerses.Controls.Add(GetVerseView(verse));
            }
        }

        private Label GetVerseView(Request.Models.Verse verse)
        {
            var lblVerseView = new Label
            {
                BackColor = lblVerse.BackColor,
                Cursor = lblVerse.Cursor,
                Font = lblVerse.Font,
                ForeColor = lblVerse.ForeColor,
                Location = lblVerse.Location,
                Margin = lblVerse.Margin,
                Name = $"lblVerse_{verse.Number}",
                Padding = lblVerse.Padding,
                Size = lblVerse.Size,
                TabIndex = lblVerse.TabIndex,
                Text = $"{SelectedBook.Name.ToUpper()} {SelectedChapter.Number}:{verse.Number}\r\n{verse.Text}",
                TextAlign = lblVerse.TextAlign,
                Tag = verse.Number
            };
            lblVerseView.Click += (object sender, EventArgs e) =>
            {
                var selectedLbl = sender as Label;

                ChangeVerse(Convert.ToInt32(selectedLbl.Tag));
            };

            return lblVerseView;
        }

        private void SelectVerse(int verseNumber)
        {
            SelectedVerse = SelectedChapter.VersesList.FirstOrDefault(verse => verse.Number == verseNumber);
        }

        private void SelectVerseView(Label lblVerse)
        {
            foreach (var lbl in pnVerses.Controls.Cast<Label>())
            {
                lbl.BackColor = Color.Black;
            }

            lblVerse.BackColor = Color.DarkSlateBlue;

            pnVerses.ScrollControlIntoView(lblVerse);
        }

        private Label GetVerseView(int verseNumber)
        {
            return pnVerses.Controls.Cast<Label>().FirstOrDefault(lbl => Convert.ToInt32(lbl.Tag) == verseNumber);
        }

        private void ChangeVerse(int verseNumber)
        {
            var lblView = GetVerseView(verseNumber);

            SelectVerse(verseNumber);

            SelectVerseView(lblView);

            Program.FrmVerseView.SelectVerse(Data.FirstOrDefault().Name, SelectedBook.Name, SelectedChapter.Number, SelectedVerse);
        }

        private void SelectChapter(int chapterNumber)
        {
            SelectedChapter = Data.GetChapter(SelectedVersion.Name, SelectedBook.Name, chapterNumber);

            LoadChapterView();

            SelectVerse(1);
        }

        private void ChangeChapter()
        {
            int selectedChapter = Convert.ToInt32(nmChapter.Value);

            nmVerse.Maximum = SelectedBook.ChapterList[selectedChapter];

            SelectChapter(selectedChapter);

            ChangeVerse(1);
        }

        private void ChangeColor(Control control, bool focused)
        {
            control.BackColor = focused ? SystemColors.GradientInactiveCaption : SystemColors.Window;
        }

        private void OpenVerseViewer()
        {
            var frmVerseView = Program.FrmVerseView;
            var secondaryScreen = Screen.AllScreens.LastOrDefault();

            frmVerseView.StartPosition = FormStartPosition.Manual;
            frmVerseView.Bounds = secondaryScreen.Bounds;
            frmVerseView.MinimumSize = secondaryScreen.Bounds.Size;
            frmVerseView.Location = secondaryScreen.WorkingArea.Location;

            frmVerseView.SelectVerse(Data.FirstOrDefault().Name, SelectedBook.Name, SelectedChapter.Number, SelectedVerse);

            frmVerseView.Show();
        }

        private void CloseVerseViewer()
        {
            Program.FrmVerseView.Hide();
        }

        private void cbBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectBook();

            nmChapter.Maximum = SelectedBook.ChapterList.Count;

            ChangeChapter();
        }

        private void nmChapter_ValueChanged(object sender, EventArgs e)
        {
            ChangeChapter();
        }

        private void nmChapter_Leave(object sender, EventArgs e)
        {
            ChangeChapter();

            ChangeColor(sender as Control, false);
        }

        private void cbBook_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbBook.DisplayMember))
                return;

            var text = cbBook.Text.ToUpper().RemoveAccents();
            var filteredList = (from book in cbBook.DataSource as List<Request.Models.BookView>
                                where book.Name.ToUpper().RemoveAccents().StartsWith(text)
                                select book).FirstOrDefault();
            
            //if (filteredList.Count() > 0)
            //{
            //    cbBook.SelectionStart = text.Length;
            //    cbBook.SelectionLength = cbBook.Items[0].ToString().Length - text.Length;
            //}

            return;
        }

        private void nmVerse_ValueChanged(object sender, EventArgs e)
        {
            ChangeVerse(Convert.ToInt32(nmVerse.Value));
        }

        private void nmVerse_Leave(object sender, EventArgs e)
        {
            ChangeVerse(Convert.ToInt32(nmVerse.Value));

            ChangeColor(sender as Control, false);
        }

        private void input_Enter(object sender, EventArgs e)
        {
            ChangeColor(sender as Control, true);
        }

        private void input_Leave(object sender, EventArgs e)
        {
            ChangeColor(sender as Control, false);
        }

        private void btnShow_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).FlatAppearance.BorderSize = 1;
        }

        private void btnShow_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).FlatAppearance.BorderSize = 0;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Hide();
            btnHide.Show();

            OpenVerseViewer();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            btnHide.Hide();
            btnShow.Show();

            CloseVerseViewer();
        }
    }
}
