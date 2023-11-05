namespace housework
{
    partial class music
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(music));
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.playlist = new System.Windows.Forms.ListBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.timeEnd = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeStart = new System.Windows.Forms.Label();
            this.listClear = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.PictureBox();
            this.btnLoop = new System.Windows.Forms.PictureBox();
            this.btnRUNAndSTOP = new System.Windows.Forms.PictureBox();
            this.bg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnContinue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRUNAndSTOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.BackColor = System.Drawing.Color.Black;
            this.btnOpenFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFiles.ForeColor = System.Drawing.Color.Lime;
            this.btnOpenFiles.Location = new System.Drawing.Point(32, 479);
            this.btnOpenFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(597, 44);
            this.btnOpenFiles.TabIndex = 0;
            this.btnOpenFiles.Text = "Import music files";
            this.btnOpenFiles.UseVisualStyleBackColor = false;
            this.btnOpenFiles.Click += new System.EventHandler(this.OpenFiles_Click);
            // 
            // playlist
            // 
            this.playlist.BackColor = System.Drawing.Color.Black;
            this.playlist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.playlist.ForeColor = System.Drawing.Color.Lime;
            this.playlist.FormattingEnabled = true;
            this.playlist.ItemHeight = 25;
            this.playlist.Location = new System.Drawing.Point(566, 18);
            this.playlist.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.playlist.Name = "playlist";
            this.playlist.Size = new System.Drawing.Size(401, 375);
            this.playlist.TabIndex = 1;
            this.playlist.SelectedIndexChanged += new System.EventHandler(this.listData_SelectedIndexChanged);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(986, 12);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar.Size = new System.Drawing.Size(56, 422);
            this.trackBar.TabIndex = 2;
            this.trackBar.Value = 50;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // timeEnd
            // 
            this.timeEnd.BackColor = System.Drawing.Color.Black;
            this.timeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.timeEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.timeEnd.Location = new System.Drawing.Point(778, 396);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Size = new System.Drawing.Size(156, 38);
            this.timeEnd.TabIndex = 4;
            this.timeEnd.Text = "0 : 00";
            this.timeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(168, 441);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(766, 20);
            this.progressBar.TabIndex = 5;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeStart
            // 
            this.timeStart.BackColor = System.Drawing.Color.Black;
            this.timeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.timeStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timeStart.Location = new System.Drawing.Point(80, 431);
            this.timeStart.Name = "timeStart";
            this.timeStart.Size = new System.Drawing.Size(82, 39);
            this.timeStart.TabIndex = 7;
            this.timeStart.Text = "0 : 00";
            this.timeStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listClear
            // 
            this.listClear.BackColor = System.Drawing.Color.Black;
            this.listClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listClear.ForeColor = System.Drawing.Color.Lime;
            this.listClear.Location = new System.Drawing.Point(635, 479);
            this.listClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listClear.Name = "listClear";
            this.listClear.Size = new System.Drawing.Size(299, 44);
            this.listClear.TabIndex = 8;
            this.listClear.Text = "Clear the playlist";
            this.listClear.UseVisualStyleBackColor = false;
            this.listClear.Click += new System.EventHandler(this.listClear_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.Image = global::housework.Properties.Resources._continue;
            this.btnContinue.InitialImage = null;
            this.btnContinue.Location = new System.Drawing.Point(986, 433);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(39, 39);
            this.btnContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnContinue.TabIndex = 11;
            this.btnContinue.TabStop = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnLoop
            // 
            this.btnLoop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoop.Image = global::housework.Properties.Resources.loop;
            this.btnLoop.InitialImage = global::housework.Properties.Resources.loop;
            this.btnLoop.Location = new System.Drawing.Point(986, 484);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(39, 39);
            this.btnLoop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLoop.TabIndex = 10;
            this.btnLoop.TabStop = false;
            this.btnLoop.Click += new System.EventHandler(this.loop_Click);
            // 
            // btnRUNAndSTOP
            // 
            this.btnRUNAndSTOP.BackColor = System.Drawing.Color.White;
            this.btnRUNAndSTOP.Image = global::housework.Properties.Resources.OIP;
            this.btnRUNAndSTOP.Location = new System.Drawing.Point(35, 431);
            this.btnRUNAndSTOP.Name = "btnRUNAndSTOP";
            this.btnRUNAndSTOP.Size = new System.Drawing.Size(39, 39);
            this.btnRUNAndSTOP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRUNAndSTOP.TabIndex = 3;
            this.btnRUNAndSTOP.TabStop = false;
            this.btnRUNAndSTOP.Click += new System.EventHandler(this.btnRUNAndStop_Click);
            // 
            // bg
            // 
            this.bg.Image = global::housework.Properties.Resources.imgbg;
            this.bg.InitialImage = global::housework.Properties.Resources.test;
            this.bg.Location = new System.Drawing.Point(-2, -3);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(969, 536);
            this.bg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg.TabIndex = 9;
            this.bg.TabStop = false;
            // 
            // music
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1043, 547);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnLoop);
            this.Controls.Add(this.listClear);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.btnRUNAndSTOP);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.playlist);
            this.Controls.Add(this.btnOpenFiles);
            this.Controls.Add(this.bg);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "music";
            this.Text = "music";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnContinue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRUNAndSTOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.ListBox playlist;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.PictureBox btnRUNAndSTOP;
        private System.Windows.Forms.Label timeEnd;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeStart;
        private System.Windows.Forms.Button listClear;
        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.PictureBox btnLoop;
        private System.Windows.Forms.PictureBox btnContinue;
    }
}

