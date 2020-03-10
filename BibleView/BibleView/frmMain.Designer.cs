using BibleView.Components;

namespace BibleView
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nmVerse = new System.Windows.Forms.NumericUpDown();
            this.nmChapter = new System.Windows.Forms.NumericUpDown();
            this.pnVerses = new System.Windows.Forms.FlowLayoutPanel();
            this.lblVerseSelected = new System.Windows.Forms.Label();
            this.lblVerse = new System.Windows.Forms.Label();
            this.cbBook = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmChapter)).BeginInit();
            this.pnVerses.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.BackColor = System.Drawing.SystemColors.Window;
            this.cbSearch.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(6, 19);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(748, 29);
            this.cbSearch.TabIndex = 0;
            this.cbSearch.Enter += new System.EventHandler(this.input_Enter);
            this.cbSearch.Leave += new System.EventHandler(this.input_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbSearch);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busca avançada";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.nmVerse);
            this.groupBox2.Controls.Add(this.nmChapter);
            this.groupBox2.Controls.Add(this.pnVerses);
            this.groupBox2.Controls.Add(this.cbBook);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(12, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(797, 306);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecionar versículo";
            // 
            // nmVerse
            // 
            this.nmVerse.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.nmVerse.Location = new System.Drawing.Point(309, 19);
            this.nmVerse.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmVerse.Name = "nmVerse";
            this.nmVerse.Size = new System.Drawing.Size(65, 29);
            this.nmVerse.TabIndex = 6;
            this.nmVerse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmVerse.ValueChanged += new System.EventHandler(this.nmVerse_ValueChanged);
            this.nmVerse.Enter += new System.EventHandler(this.input_Enter);
            this.nmVerse.Leave += new System.EventHandler(this.nmVerse_Leave);
            // 
            // nmChapter
            // 
            this.nmChapter.BackColor = System.Drawing.SystemColors.Window;
            this.nmChapter.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.nmChapter.Location = new System.Drawing.Point(238, 19);
            this.nmChapter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmChapter.Name = "nmChapter";
            this.nmChapter.Size = new System.Drawing.Size(65, 29);
            this.nmChapter.TabIndex = 5;
            this.nmChapter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmChapter.ValueChanged += new System.EventHandler(this.nmChapter_ValueChanged);
            this.nmChapter.Enter += new System.EventHandler(this.input_Enter);
            this.nmChapter.Leave += new System.EventHandler(this.nmChapter_Leave);
            // 
            // pnVerses
            // 
            this.pnVerses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnVerses.AutoScroll = true;
            this.pnVerses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnVerses.Controls.Add(this.lblVerseSelected);
            this.pnVerses.Controls.Add(this.lblVerse);
            this.pnVerses.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pnVerses.Location = new System.Drawing.Point(6, 54);
            this.pnVerses.Name = "pnVerses";
            this.pnVerses.Size = new System.Drawing.Size(785, 246);
            this.pnVerses.TabIndex = 4;
            // 
            // lblVerseSelected
            // 
            this.lblVerseSelected.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblVerseSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVerseSelected.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F);
            this.lblVerseSelected.ForeColor = System.Drawing.Color.White;
            this.lblVerseSelected.Location = new System.Drawing.Point(3, 3);
            this.lblVerseSelected.Margin = new System.Windows.Forms.Padding(3);
            this.lblVerseSelected.Name = "lblVerseSelected";
            this.lblVerseSelected.Padding = new System.Windows.Forms.Padding(1);
            this.lblVerseSelected.Size = new System.Drawing.Size(184, 128);
            this.lblVerseSelected.TabIndex = 7;
            this.lblVerseSelected.Text = resources.GetString("lblVerseSelected.Text");
            this.lblVerseSelected.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVerse
            // 
            this.lblVerse.BackColor = System.Drawing.Color.Black;
            this.lblVerse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVerse.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F);
            this.lblVerse.ForeColor = System.Drawing.Color.White;
            this.lblVerse.Location = new System.Drawing.Point(193, 3);
            this.lblVerse.Margin = new System.Windows.Forms.Padding(3);
            this.lblVerse.Name = "lblVerse";
            this.lblVerse.Padding = new System.Windows.Forms.Padding(1);
            this.lblVerse.Size = new System.Drawing.Size(184, 128);
            this.lblVerse.TabIndex = 8;
            this.lblVerse.Text = resources.GetString("lblVerse.Text");
            this.lblVerse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbBook
            // 
            this.cbBook.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBook.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbBook.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBook.FormattingEnabled = true;
            this.cbBook.Location = new System.Drawing.Point(6, 19);
            this.cbBook.Name = "cbBook";
            this.cbBook.Size = new System.Drawing.Size(226, 29);
            this.cbBook.TabIndex = 1;
            this.cbBook.SelectedIndexChanged += new System.EventHandler(this.cbBook_SelectedIndexChanged);
            this.cbBook.TextChanged += new System.EventHandler(this.cbBook_TextChanged);
            this.cbBook.Enter += new System.EventHandler(this.input_Enter);
            this.cbBook.Leave += new System.EventHandler(this.input_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = global::BibleView.Properties.Resources.search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(760, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(31, 29);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.MouseEnter += new System.EventHandler(this.btnShow_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnShow_MouseLeave);
            // 
            // btnShow
            // 
            this.btnShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShow.BackColor = System.Drawing.Color.Transparent;
            this.btnShow.BackgroundImage = global::BibleView.Properties.Resources.show;
            this.btnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Location = new System.Drawing.Point(356, 398);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(109, 90);
            this.btnShow.TabIndex = 4;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            this.btnShow.MouseEnter += new System.EventHandler(this.btnShow_MouseEnter);
            this.btnShow.MouseLeave += new System.EventHandler(this.btnShow_MouseLeave);
            // 
            // btnHide
            // 
            this.btnHide.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHide.BackColor = System.Drawing.Color.Transparent;
            this.btnHide.BackgroundImage = global::BibleView.Properties.Resources.hide;
            this.btnHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHide.FlatAppearance.BorderSize = 0;
            this.btnHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.btnHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Location = new System.Drawing.Point(356, 398);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(109, 90);
            this.btnHide.TabIndex = 5;
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            this.btnHide.MouseEnter += new System.EventHandler(this.btnShow_MouseEnter);
            this.btnHide.MouseLeave += new System.EventHandler(this.btnShow_MouseLeave);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 497);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnHide);
            this.MinimumSize = new System.Drawing.Size(834, 536);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bible Viewer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmVerse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmChapter)).EndInit();
            this.pnVerses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbBook;
        private System.Windows.Forms.FlowLayoutPanel pnVerses;
        private System.Windows.Forms.NumericUpDown nmVerse;
        private System.Windows.Forms.NumericUpDown nmChapter;
        public System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label lblVerseSelected;
        private System.Windows.Forms.Label lblVerse;
        public System.Windows.Forms.Button btnShow;
        public System.Windows.Forms.Button btnHide;
    }
}

