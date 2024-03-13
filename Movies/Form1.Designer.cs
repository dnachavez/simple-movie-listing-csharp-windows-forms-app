namespace Movies
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.movieTitleLabel = new System.Windows.Forms.Label();
            this.movieTitle = new System.Windows.Forms.TextBox();
            this.movieDescriptionLabel = new System.Windows.Forms.Label();
            this.movieDescription = new System.Windows.Forms.TextBox();
            this.movieCategoryLabel = new System.Windows.Forms.Label();
            this.movieCategory = new System.Windows.Forms.ComboBox();
            this.movieDateLaunchedLabel = new System.Windows.Forms.Label();
            this.movieDateDay = new System.Windows.Forms.TextBox();
            this.movieDateMonth = new System.Windows.Forms.TextBox();
            this.movieDateYear = new System.Windows.Forms.TextBox();
            this.movieDateDayDivider = new System.Windows.Forms.Label();
            this.movieDateMonthDivider = new System.Windows.Forms.Label();
            this.movieOriginLabel = new System.Windows.Forms.Label();
            this.movieOrigin = new System.Windows.Forms.TextBox();
            this.saveMovieBtn = new System.Windows.Forms.Button();
            this.movieListLabel = new System.Windows.Forms.Label();
            this.movieList = new System.Windows.Forms.ListView();
            this.searchMovieBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // movieTitleLabel
            // 
            this.movieTitleLabel.AutoSize = true;
            this.movieTitleLabel.Location = new System.Drawing.Point(12, 18);
            this.movieTitleLabel.Name = "movieTitleLabel";
            this.movieTitleLabel.Size = new System.Drawing.Size(73, 16);
            this.movieTitleLabel.TabIndex = 0;
            this.movieTitleLabel.Text = "Movie Title";
            // 
            // movieTitle
            // 
            this.movieTitle.Location = new System.Drawing.Point(12, 37);
            this.movieTitle.Name = "movieTitle";
            this.movieTitle.Size = new System.Drawing.Size(374, 22);
            this.movieTitle.TabIndex = 1;
            // 
            // movieDescriptionLabel
            // 
            this.movieDescriptionLabel.AutoSize = true;
            this.movieDescriptionLabel.Location = new System.Drawing.Point(12, 62);
            this.movieDescriptionLabel.Name = "movieDescriptionLabel";
            this.movieDescriptionLabel.Size = new System.Drawing.Size(115, 16);
            this.movieDescriptionLabel.TabIndex = 2;
            this.movieDescriptionLabel.Text = "Movie Description";
            // 
            // movieDescription
            // 
            this.movieDescription.Location = new System.Drawing.Point(12, 81);
            this.movieDescription.Multiline = true;
            this.movieDescription.Name = "movieDescription";
            this.movieDescription.Size = new System.Drawing.Size(374, 185);
            this.movieDescription.TabIndex = 3;
            // 
            // movieCategoryLabel
            // 
            this.movieCategoryLabel.AutoSize = true;
            this.movieCategoryLabel.Location = new System.Drawing.Point(12, 269);
            this.movieCategoryLabel.Name = "movieCategoryLabel";
            this.movieCategoryLabel.Size = new System.Drawing.Size(102, 16);
            this.movieCategoryLabel.TabIndex = 4;
            this.movieCategoryLabel.Text = "Movie Category";
            // 
            // movieCategory
            // 
            this.movieCategory.FormattingEnabled = true;
            this.movieCategory.Location = new System.Drawing.Point(12, 288);
            this.movieCategory.Name = "movieCategory";
            this.movieCategory.Size = new System.Drawing.Size(374, 24);
            this.movieCategory.TabIndex = 5;
            // 
            // movieDateLaunchedLabel
            // 
            this.movieDateLaunchedLabel.AutoSize = true;
            this.movieDateLaunchedLabel.Location = new System.Drawing.Point(12, 315);
            this.movieDateLaunchedLabel.Name = "movieDateLaunchedLabel";
            this.movieDateLaunchedLabel.Size = new System.Drawing.Size(138, 16);
            this.movieDateLaunchedLabel.TabIndex = 6;
            this.movieDateLaunchedLabel.Text = "Movie Date Launched";
            // 
            // movieDateDay
            // 
            this.movieDateDay.Location = new System.Drawing.Point(12, 334);
            this.movieDateDay.Name = "movieDateDay";
            this.movieDateDay.Size = new System.Drawing.Size(100, 22);
            this.movieDateDay.TabIndex = 7;
            // 
            // movieDateMonth
            // 
            this.movieDateMonth.Location = new System.Drawing.Point(147, 334);
            this.movieDateMonth.Name = "movieDateMonth";
            this.movieDateMonth.Size = new System.Drawing.Size(100, 22);
            this.movieDateMonth.TabIndex = 8;
            // 
            // movieDateYear
            // 
            this.movieDateYear.Location = new System.Drawing.Point(286, 334);
            this.movieDateYear.Name = "movieDateYear";
            this.movieDateYear.Size = new System.Drawing.Size(100, 22);
            this.movieDateYear.TabIndex = 9;
            // 
            // movieDateDayDivider
            // 
            this.movieDateDayDivider.AutoSize = true;
            this.movieDateDayDivider.Location = new System.Drawing.Point(123, 337);
            this.movieDateDayDivider.Name = "movieDateDayDivider";
            this.movieDateDayDivider.Size = new System.Drawing.Size(11, 16);
            this.movieDateDayDivider.TabIndex = 10;
            this.movieDateDayDivider.Text = "/";
            // 
            // movieDateMonthDivider
            // 
            this.movieDateMonthDivider.AutoSize = true;
            this.movieDateMonthDivider.Location = new System.Drawing.Point(262, 337);
            this.movieDateMonthDivider.Name = "movieDateMonthDivider";
            this.movieDateMonthDivider.Size = new System.Drawing.Size(11, 16);
            this.movieDateMonthDivider.TabIndex = 11;
            this.movieDateMonthDivider.Text = "/";
            // 
            // movieOriginLabel
            // 
            this.movieOriginLabel.AutoSize = true;
            this.movieOriginLabel.Location = new System.Drawing.Point(12, 359);
            this.movieOriginLabel.Name = "movieOriginLabel";
            this.movieOriginLabel.Size = new System.Drawing.Size(82, 16);
            this.movieOriginLabel.TabIndex = 12;
            this.movieOriginLabel.Text = "Movie Origin";
            // 
            // movieOrigin
            // 
            this.movieOrigin.Location = new System.Drawing.Point(12, 378);
            this.movieOrigin.Name = "movieOrigin";
            this.movieOrigin.Size = new System.Drawing.Size(374, 22);
            this.movieOrigin.TabIndex = 13;
            // 
            // saveMovieBtn
            // 
            this.saveMovieBtn.Location = new System.Drawing.Point(12, 406);
            this.saveMovieBtn.Name = "saveMovieBtn";
            this.saveMovieBtn.Size = new System.Drawing.Size(75, 23);
            this.saveMovieBtn.TabIndex = 14;
            this.saveMovieBtn.Text = "Save";
            this.saveMovieBtn.UseVisualStyleBackColor = true;
            this.saveMovieBtn.Click += new System.EventHandler(this.saveMovieBtn_Click);
            // 
            // movieListLabel
            // 
            this.movieListLabel.AutoSize = true;
            this.movieListLabel.Location = new System.Drawing.Point(432, 33);
            this.movieListLabel.Name = "movieListLabel";
            this.movieListLabel.Size = new System.Drawing.Size(67, 16);
            this.movieListLabel.TabIndex = 16;
            this.movieListLabel.Text = "Movie List";
            // 
            // movieList
            // 
            this.movieList.HideSelection = false;
            this.movieList.Location = new System.Drawing.Point(435, 52);
            this.movieList.Name = "movieList";
            this.movieList.Size = new System.Drawing.Size(353, 363);
            this.movieList.TabIndex = 17;
            this.movieList.UseCompatibleStateImageBehavior = false;
            this.movieList.DoubleClick += new System.EventHandler(this.movieList_DoubleClick);
            // 
            // searchMovieBtn
            // 
            this.searchMovieBtn.Location = new System.Drawing.Point(93, 406);
            this.searchMovieBtn.Name = "searchMovieBtn";
            this.searchMovieBtn.Size = new System.Drawing.Size(75, 23);
            this.searchMovieBtn.TabIndex = 15;
            this.searchMovieBtn.Text = "Search";
            this.searchMovieBtn.UseVisualStyleBackColor = true;
            this.searchMovieBtn.Click += new System.EventHandler(this.searchMovieBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchMovieBtn);
            this.Controls.Add(this.movieList);
            this.Controls.Add(this.movieListLabel);
            this.Controls.Add(this.saveMovieBtn);
            this.Controls.Add(this.movieOrigin);
            this.Controls.Add(this.movieOriginLabel);
            this.Controls.Add(this.movieDateMonthDivider);
            this.Controls.Add(this.movieDateDayDivider);
            this.Controls.Add(this.movieDateYear);
            this.Controls.Add(this.movieDateMonth);
            this.Controls.Add(this.movieDateDay);
            this.Controls.Add(this.movieDateLaunchedLabel);
            this.Controls.Add(this.movieCategory);
            this.Controls.Add(this.movieCategoryLabel);
            this.Controls.Add(this.movieDescription);
            this.Controls.Add(this.movieDescriptionLabel);
            this.Controls.Add(this.movieTitle);
            this.Controls.Add(this.movieTitleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Movies";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label movieTitleLabel;
        private System.Windows.Forms.TextBox movieTitle;
        private System.Windows.Forms.Label movieDescriptionLabel;
        private System.Windows.Forms.TextBox movieDescription;
        private System.Windows.Forms.Label movieCategoryLabel;
        private System.Windows.Forms.ComboBox movieCategory;
        private System.Windows.Forms.Label movieDateLaunchedLabel;
        private System.Windows.Forms.TextBox movieDateDay;
        private System.Windows.Forms.TextBox movieDateMonth;
        private System.Windows.Forms.TextBox movieDateYear;
        private System.Windows.Forms.Label movieDateDayDivider;
        private System.Windows.Forms.Label movieDateMonthDivider;
        private System.Windows.Forms.Label movieOriginLabel;
        private System.Windows.Forms.TextBox movieOrigin;
        private System.Windows.Forms.Button saveMovieBtn;
        private System.Windows.Forms.Label movieListLabel;
        private System.Windows.Forms.ListView movieList;
        private System.Windows.Forms.Button searchMovieBtn;
    }
}

