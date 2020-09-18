namespace 나도가수다
{
    partial class Form_MiniPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MiniPlayer));
            this.panel_Top = new System.Windows.Forms.Panel();
            this.btnMiniMode = new FontAwesome.Sharp.IconButton();
            this.btnMinimum = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.picMiniAlbum = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.lblNowTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.miniTrackBar = new Bunifu.Framework.UI.BunifuSlider();
            this.miniVolumeSlider = new Bunifu.Framework.UI.BunifuSlider();
            this.btnMiniPlay = new FontAwesome.Sharp.IconButton();
            this.btnMMode = new FontAwesome.Sharp.IconButton();
            this.btnMiniNext = new FontAwesome.Sharp.IconButton();
            this.btnMiniPrevious = new FontAwesome.Sharp.IconButton();
            this.btnVolume = new FontAwesome.Sharp.IconButton();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMiniAlbum)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Top.Controls.Add(this.btnMiniMode);
            this.panel_Top.Controls.Add(this.btnMinimum);
            this.panel_Top.Controls.Add(this.btnClose);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(300, 30);
            this.panel_Top.TabIndex = 0;
            this.panel_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseDown);
            this.panel_Top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseMove);
            this.panel_Top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseUp);
            // 
            // btnMiniMode
            // 
            this.btnMiniMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiniMode.FlatAppearance.BorderSize = 0;
            this.btnMiniMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiniMode.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMiniMode.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMiniMode.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMiniMode.IconSize = 16;
            this.btnMiniMode.Location = new System.Drawing.Point(192, 0);
            this.btnMiniMode.Name = "btnMiniMode";
            this.btnMiniMode.Rotation = 0D;
            this.btnMiniMode.Size = new System.Drawing.Size(36, 30);
            this.btnMiniMode.TabIndex = 64;
            this.btnMiniMode.TabStop = false;
            this.btnMiniMode.UseVisualStyleBackColor = true;
            this.btnMiniMode.Click += new System.EventHandler(this.btnMiniMode_Click);
            // 
            // btnMinimum
            // 
            this.btnMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimum.FlatAppearance.BorderSize = 0;
            this.btnMinimum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimum.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMinimum.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimum.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMinimum.IconSize = 16;
            this.btnMinimum.Location = new System.Drawing.Point(228, 0);
            this.btnMinimum.Name = "btnMinimum";
            this.btnMinimum.Rotation = 0D;
            this.btnMinimum.Size = new System.Drawing.Size(36, 30);
            this.btnMinimum.TabIndex = 63;
            this.btnMinimum.TabStop = false;
            this.btnMinimum.UseVisualStyleBackColor = true;
            this.btnMinimum.Click += new System.EventHandler(this.btnMinimum_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.IconSize = 16;
            this.btnClose.Location = new System.Drawing.Point(264, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Rotation = 0D;
            this.btnClose.Size = new System.Drawing.Size(36, 30);
            this.btnClose.TabIndex = 62;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picMiniAlbum
            // 
            this.picMiniAlbum.Location = new System.Drawing.Point(0, 36);
            this.picMiniAlbum.Name = "picMiniAlbum";
            this.picMiniAlbum.Size = new System.Drawing.Size(100, 50);
            this.picMiniAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMiniAlbum.TabIndex = 65;
            this.picMiniAlbum.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 115);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "현재 재생중인 곡이 없습니다.";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArtist
            // 
            this.lblArtist.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblArtist.Location = new System.Drawing.Point(100, 140);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(100, 20);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotalTime.Location = new System.Drawing.Point(247, 266);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(33, 12);
            this.lblTotalTime.TabIndex = 58;
            this.lblTotalTime.Text = "00:00";
            // 
            // lblNowTime
            // 
            this.lblNowTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNowTime.AutoSize = true;
            this.lblNowTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNowTime.Location = new System.Drawing.Point(20, 266);
            this.lblNowTime.Name = "lblNowTime";
            this.lblNowTime.Size = new System.Drawing.Size(33, 12);
            this.lblNowTime.TabIndex = 57;
            this.lblNowTime.Text = "00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // miniTrackBar
            // 
            this.miniTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.miniTrackBar.BackgroudColor = System.Drawing.Color.DarkGray;
            this.miniTrackBar.BorderRadius = 0;
            this.miniTrackBar.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.miniTrackBar.Location = new System.Drawing.Point(20, 235);
            this.miniTrackBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.miniTrackBar.MaximumValue = 300;
            this.miniTrackBar.Name = "miniTrackBar";
            this.miniTrackBar.Size = new System.Drawing.Size(255, 28);
            this.miniTrackBar.TabIndex = 66;
            this.miniTrackBar.Value = 0;
            this.miniTrackBar.ValueChanged += new System.EventHandler(this.miniTrackBar_ValueChanged);
            // 
            // miniVolumeSlider
            // 
            this.miniVolumeSlider.BackColor = System.Drawing.Color.Transparent;
            this.miniVolumeSlider.BackgroudColor = System.Drawing.Color.DarkGray;
            this.miniVolumeSlider.BorderRadius = 0;
            this.miniVolumeSlider.IndicatorColor = System.Drawing.Color.Silver;
            this.miniVolumeSlider.Location = new System.Drawing.Point(18, 156);
            this.miniVolumeSlider.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.miniVolumeSlider.MaximumValue = 100;
            this.miniVolumeSlider.Name = "miniVolumeSlider";
            this.miniVolumeSlider.Size = new System.Drawing.Size(150, 28);
            this.miniVolumeSlider.TabIndex = 0;
            this.miniVolumeSlider.Value = 10;
            this.miniVolumeSlider.ValueChanged += new System.EventHandler(this.miniVolumeSlider_ValueChanged);
            // 
            // btnMiniPlay
            // 
            this.btnMiniPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiniPlay.Enabled = false;
            this.btnMiniPlay.FlatAppearance.BorderSize = 0;
            this.btnMiniPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiniPlay.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMiniPlay.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            this.btnMiniPlay.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.btnMiniPlay.IconSize = 55;
            this.btnMiniPlay.Location = new System.Drawing.Point(125, 185);
            this.btnMiniPlay.Name = "btnMiniPlay";
            this.btnMiniPlay.Rotation = 0D;
            this.btnMiniPlay.Size = new System.Drawing.Size(50, 50);
            this.btnMiniPlay.TabIndex = 67;
            this.btnMiniPlay.TabStop = false;
            this.btnMiniPlay.UseVisualStyleBackColor = true;
            this.btnMiniPlay.Click += new System.EventHandler(this.btnMiniPlay_Click);
            // 
            // btnMMode
            // 
            this.btnMMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMMode.FlatAppearance.BorderSize = 0;
            this.btnMMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMMode.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMMode.IconChar = FontAwesome.Sharp.IconChar.RedoAlt;
            this.btnMMode.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.btnMMode.IconSize = 30;
            this.btnMMode.Location = new System.Drawing.Point(237, 190);
            this.btnMMode.Name = "btnMMode";
            this.btnMMode.Rotation = 0D;
            this.btnMMode.Size = new System.Drawing.Size(40, 40);
            this.btnMMode.TabIndex = 70;
            this.btnMMode.TabStop = false;
            this.btnMMode.UseVisualStyleBackColor = true;
            this.btnMMode.Click += new System.EventHandler(this.btnMMode_Click);
            // 
            // btnMiniNext
            // 
            this.btnMiniNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiniNext.Enabled = false;
            this.btnMiniNext.FlatAppearance.BorderSize = 0;
            this.btnMiniNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiniNext.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMiniNext.IconChar = FontAwesome.Sharp.IconChar.StepForward;
            this.btnMiniNext.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.btnMiniNext.IconSize = 30;
            this.btnMiniNext.Location = new System.Drawing.Point(191, 190);
            this.btnMiniNext.Name = "btnMiniNext";
            this.btnMiniNext.Rotation = 0D;
            this.btnMiniNext.Size = new System.Drawing.Size(35, 35);
            this.btnMiniNext.TabIndex = 69;
            this.btnMiniNext.TabStop = false;
            this.btnMiniNext.UseVisualStyleBackColor = true;
            this.btnMiniNext.Click += new System.EventHandler(this.btnMiniNext_Click);
            // 
            // btnMiniPrevious
            // 
            this.btnMiniPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiniPrevious.Enabled = false;
            this.btnMiniPrevious.FlatAppearance.BorderSize = 0;
            this.btnMiniPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiniPrevious.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMiniPrevious.IconChar = FontAwesome.Sharp.IconChar.StepBackward;
            this.btnMiniPrevious.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.btnMiniPrevious.IconSize = 30;
            this.btnMiniPrevious.Location = new System.Drawing.Point(75, 190);
            this.btnMiniPrevious.Name = "btnMiniPrevious";
            this.btnMiniPrevious.Rotation = 0D;
            this.btnMiniPrevious.Size = new System.Drawing.Size(35, 35);
            this.btnMiniPrevious.TabIndex = 68;
            this.btnMiniPrevious.TabStop = false;
            this.btnMiniPrevious.UseVisualStyleBackColor = true;
            this.btnMiniPrevious.Click += new System.EventHandler(this.btnMiniPrevious_Click);
            // 
            // btnVolume
            // 
            this.btnVolume.FlatAppearance.BorderSize = 0;
            this.btnVolume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolume.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnVolume.IconChar = FontAwesome.Sharp.IconChar.VolumeUp;
            this.btnVolume.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.btnVolume.IconSize = 30;
            this.btnVolume.Location = new System.Drawing.Point(18, 190);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Rotation = 0D;
            this.btnVolume.Size = new System.Drawing.Size(35, 35);
            this.btnVolume.TabIndex = 71;
            this.btnVolume.TabStop = false;
            this.btnVolume.UseVisualStyleBackColor = true;
            this.btnVolume.Click += new System.EventHandler(this.btnVolume_Click);
            // 
            // Form_MiniPlayer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.btnVolume);
            this.Controls.Add(this.btnMMode);
            this.Controls.Add(this.btnMiniNext);
            this.Controls.Add(this.btnMiniPrevious);
            this.Controls.Add(this.btnMiniPlay);
            this.Controls.Add(this.miniVolumeSlider);
            this.Controls.Add(this.miniTrackBar);
            this.Controls.Add(this.picMiniAlbum);
            this.Controls.Add(this.lblTotalTime);
            this.Controls.Add(this.lblNowTime);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form_MiniPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "미니플레이어";
            this.Load += new System.EventHandler(this.Form_MiniPlayer_Load);
            this.panel_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMiniAlbum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picMiniAlbum;
        public System.Windows.Forms.Label lblNowTime;
        private FontAwesome.Sharp.IconButton btnMiniMode;
        private FontAwesome.Sharp.IconButton btnMinimum;
        private FontAwesome.Sharp.IconButton btnClose;
        public Bunifu.Framework.UI.BunifuSlider miniTrackBar;
        public Bunifu.Framework.UI.BunifuSlider miniVolumeSlider;
        public FontAwesome.Sharp.IconButton btnMiniPlay;
        public FontAwesome.Sharp.IconButton btnMMode;
        public FontAwesome.Sharp.IconButton btnMiniNext;
        public FontAwesome.Sharp.IconButton btnMiniPrevious;
        private FontAwesome.Sharp.IconButton btnVolume;
    }
}