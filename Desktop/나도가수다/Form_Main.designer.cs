namespace 나도가수다
{
    partial class Form_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.ctmLvMusic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.상세정보보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.곡정보보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.전체삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_Top = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblMember = new System.Windows.Forms.Label();
            this.btnMiniMode = new FontAwesome.Sharp.IconButton();
            this.btnMinimum = new FontAwesome.Sharp.IconButton();
            this.btnMaximum = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblArtist = new System.Windows.Forms.Label();
            this.picAlbum = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnVolUP = new FontAwesome.Sharp.IconButton();
            this.btnMute = new FontAwesome.Sharp.IconButton();
            this.volumeSlider = new Bunifu.Framework.UI.BunifuSlider();
            this.musicBar = new Bunifu.Framework.UI.BunifuSlider();
            this.btnMode = new FontAwesome.Sharp.IconButton();
            this.btnNext = new FontAwesome.Sharp.IconButton();
            this.btnPrevious = new FontAwesome.Sharp.IconButton();
            this.btnPlay = new FontAwesome.Sharp.IconButton();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.lblNowTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvMusic = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.running = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnWebHome = new FontAwesome.Sharp.IconButton();
            this.btnWebForward = new FontAwesome.Sharp.IconButton();
            this.btnWebRefresh = new FontAwesome.Sharp.IconButton();
            this.btnWebBack = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctmMember = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.로그아웃ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.받은파일폴더열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmLvMusic.SuspendLayout();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbum)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ctmMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctmLvMusic
            // 
            this.ctmLvMusic.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctmLvMusic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상세정보보기ToolStripMenuItem,
            this.삭제ToolStripMenuItem,
            this.전체삭제ToolStripMenuItem});
            this.ctmLvMusic.Name = "contextMenuStrip1";
            this.ctmLvMusic.Size = new System.Drawing.Size(174, 76);
            this.ctmLvMusic.Opening += new System.ComponentModel.CancelEventHandler(this.ctmLvMusic_Opening);
            // 
            // 상세정보보기ToolStripMenuItem
            // 
            this.상세정보보기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.곡정보보기ToolStripMenuItem});
            this.상세정보보기ToolStripMenuItem.Name = "상세정보보기ToolStripMenuItem";
            this.상세정보보기ToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.상세정보보기ToolStripMenuItem.Text = "상세정보 보기";
            // 
            // 곡정보보기ToolStripMenuItem
            // 
            this.곡정보보기ToolStripMenuItem.Name = "곡정보보기ToolStripMenuItem";
            this.곡정보보기ToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.곡정보보기ToolStripMenuItem.Text = "곡 정보 보기";
            this.곡정보보기ToolStripMenuItem.Click += new System.EventHandler(this.곡정보보기ToolStripMenuItem_Click);
            // 
            // 삭제ToolStripMenuItem
            // 
            this.삭제ToolStripMenuItem.Name = "삭제ToolStripMenuItem";
            this.삭제ToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.삭제ToolStripMenuItem.Text = "삭제";
            this.삭제ToolStripMenuItem.Click += new System.EventHandler(this.삭제ToolStripMenuItem_Click);
            // 
            // 전체삭제ToolStripMenuItem
            // 
            this.전체삭제ToolStripMenuItem.Name = "전체삭제ToolStripMenuItem";
            this.전체삭제ToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.전체삭제ToolStripMenuItem.Text = "전체삭제";
            this.전체삭제ToolStripMenuItem.Click += new System.EventHandler(this.전체삭제ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Top.Controls.Add(this.picIcon);
            this.panel_Top.Controls.Add(this.lblMember);
            this.panel_Top.Controls.Add(this.btnMiniMode);
            this.panel_Top.Controls.Add(this.btnMinimum);
            this.panel_Top.Controls.Add(this.btnMaximum);
            this.panel_Top.Controls.Add(this.btnClose);
            this.panel_Top.Controls.Add(this.lblLogin);
            this.panel_Top.Controls.Add(this.btnCheck);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(900, 30);
            this.panel_Top.TabIndex = 3;
            this.panel_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseDown);
            this.panel_Top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseMove);
            this.panel_Top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseUp);
            // 
            // picIcon
            // 
            this.picIcon.Image = global::나도가수다.Properties.Resources.logo;
            this.picIcon.Location = new System.Drawing.Point(0, 0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(60, 30);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 63;
            this.picIcon.TabStop = false;
            // 
            // lblMember
            // 
            this.lblMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMember.AutoSize = true;
            this.lblMember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMember.Location = new System.Drawing.Point(692, 9);
            this.lblMember.Name = "lblMember";
            this.lblMember.Size = new System.Drawing.Size(49, 15);
            this.lblMember.TabIndex = 62;
            this.lblMember.Text = "메뉴▼";
            this.lblMember.Visible = false;
            this.lblMember.Click += new System.EventHandler(this.lblMember_Click);
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
            this.btnMiniMode.Location = new System.Drawing.Point(759, 0);
            this.btnMiniMode.Name = "btnMiniMode";
            this.btnMiniMode.Rotation = 0D;
            this.btnMiniMode.Size = new System.Drawing.Size(36, 30);
            this.btnMiniMode.TabIndex = 61;
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
            this.btnMinimum.Location = new System.Drawing.Point(793, 0);
            this.btnMinimum.Name = "btnMinimum";
            this.btnMinimum.Rotation = 0D;
            this.btnMinimum.Size = new System.Drawing.Size(36, 30);
            this.btnMinimum.TabIndex = 60;
            this.btnMinimum.TabStop = false;
            this.btnMinimum.UseVisualStyleBackColor = true;
            this.btnMinimum.Click += new System.EventHandler(this.btnMinimum_Click);
            // 
            // btnMaximum
            // 
            this.btnMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximum.FlatAppearance.BorderSize = 0;
            this.btnMaximum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximum.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMaximum.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.btnMaximum.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMaximum.IconSize = 16;
            this.btnMaximum.Location = new System.Drawing.Point(827, 0);
            this.btnMaximum.Name = "btnMaximum";
            this.btnMaximum.Rotation = 0D;
            this.btnMaximum.Size = new System.Drawing.Size(36, 30);
            this.btnMaximum.TabIndex = 59;
            this.btnMaximum.TabStop = false;
            this.btnMaximum.UseVisualStyleBackColor = true;
            this.btnMaximum.Click += new System.EventHandler(this.btnMaximum_Click);
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
            this.btnClose.Location = new System.Drawing.Point(862, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Rotation = 0D;
            this.btnClose.Size = new System.Drawing.Size(36, 30);
            this.btnClose.TabIndex = 58;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogin.AutoSize = true;
            this.lblLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLogin.Location = new System.Drawing.Point(692, 9);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(55, 15);
            this.lblLogin.TabIndex = 6;
            this.lblLogin.Text = "Login▼";
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(0, 0);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(40, 30);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "button1";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblArtist);
            this.panel1.Controls.Add(this.picAlbum);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btnVolUP);
            this.panel1.Controls.Add(this.btnMute);
            this.panel1.Controls.Add(this.volumeSlider);
            this.panel1.Controls.Add(this.musicBar);
            this.panel1.Controls.Add(this.btnMode);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Controls.Add(this.lblTotalTime);
            this.panel1.Controls.Add(this.lblNowTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 80);
            this.panel1.TabIndex = 1;
            // 
            // lblArtist
            // 
            this.lblArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblArtist.Location = new System.Drawing.Point(359, 34);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(180, 20);
            this.lblArtist.TabIndex = 67;
            this.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAlbum
            // 
            this.picAlbum.Location = new System.Drawing.Point(0, 0);
            this.picAlbum.Name = "picAlbum";
            this.picAlbum.Size = new System.Drawing.Size(80, 80);
            this.picAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAlbum.TabIndex = 66;
            this.picAlbum.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTitle.Location = new System.Drawing.Point(309, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 20);
            this.lblTitle.TabIndex = 63;
            this.lblTitle.Text = "현재 재생중인 곡이 없습니다.";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVolUP
            // 
            this.btnVolUP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolUP.Enabled = false;
            this.btnVolUP.FlatAppearance.BorderSize = 0;
            this.btnVolUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolUP.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnVolUP.IconChar = FontAwesome.Sharp.IconChar.VolumeUp;
            this.btnVolUP.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVolUP.IconSize = 25;
            this.btnVolUP.Location = new System.Drawing.Point(785, 47);
            this.btnVolUP.Name = "btnVolUP";
            this.btnVolUP.Rotation = 0D;
            this.btnVolUP.Size = new System.Drawing.Size(25, 25);
            this.btnVolUP.TabIndex = 62;
            this.btnVolUP.UseVisualStyleBackColor = true;
            // 
            // btnMute
            // 
            this.btnMute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMute.FlatAppearance.BorderSize = 0;
            this.btnMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMute.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMute.IconChar = FontAwesome.Sharp.IconChar.VolumeDown;
            this.btnMute.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMute.IconSize = 25;
            this.btnMute.Location = new System.Drawing.Point(630, 47);
            this.btnMute.Name = "btnMute";
            this.btnMute.Rotation = 0D;
            this.btnMute.Size = new System.Drawing.Size(25, 25);
            this.btnMute.TabIndex = 61;
            this.btnMute.TabStop = false;
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // volumeSlider
            // 
            this.volumeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeSlider.BackColor = System.Drawing.Color.Transparent;
            this.volumeSlider.BackgroudColor = System.Drawing.Color.DarkGray;
            this.volumeSlider.BorderRadius = 0;
            this.volumeSlider.IndicatorColor = System.Drawing.Color.Silver;
            this.volumeSlider.Location = new System.Drawing.Point(655, 47);
            this.volumeSlider.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.volumeSlider.MaximumValue = 100;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(130, 33);
            this.volumeSlider.TabIndex = 60;
            this.volumeSlider.Value = 10;
            this.volumeSlider.ValueChanged += new System.EventHandler(this.volumeSlider_ValueChanged);
            // 
            // musicBar
            // 
            this.musicBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.musicBar.BackColor = System.Drawing.Color.Transparent;
            this.musicBar.BackgroudColor = System.Drawing.Color.DarkGray;
            this.musicBar.BorderRadius = 0;
            this.musicBar.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.musicBar.Location = new System.Drawing.Point(315, 47);
            this.musicBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.musicBar.MaximumValue = 300;
            this.musicBar.Name = "musicBar";
            this.musicBar.Size = new System.Drawing.Size(255, 33);
            this.musicBar.TabIndex = 59;
            this.musicBar.Value = 0;
            this.musicBar.ValueChanged += new System.EventHandler(this.musicBar_ValueChanged);
            // 
            // btnMode
            // 
            this.btnMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMode.FlatAppearance.BorderSize = 0;
            this.btnMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMode.IconChar = FontAwesome.Sharp.IconChar.RedoAlt;
            this.btnMode.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.btnMode.IconSize = 30;
            this.btnMode.Location = new System.Drawing.Point(633, 10);
            this.btnMode.Name = "btnMode";
            this.btnMode.Rotation = 0D;
            this.btnMode.Size = new System.Drawing.Size(44, 41);
            this.btnMode.TabIndex = 58;
            this.btnMode.TabStop = false;
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Enabled = false;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNext.IconChar = FontAwesome.Sharp.IconChar.StepForward;
            this.btnNext.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.btnNext.IconSize = 30;
            this.btnNext.Location = new System.Drawing.Point(745, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Rotation = 0D;
            this.btnNext.Size = new System.Drawing.Size(45, 45);
            this.btnNext.TabIndex = 57;
            this.btnNext.TabStop = false;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPrevious.IconChar = FontAwesome.Sharp.IconChar.StepBackward;
            this.btnPrevious.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.btnPrevious.IconSize = 30;
            this.btnPrevious.Location = new System.Drawing.Point(694, 10);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Rotation = 0D;
            this.btnPrevious.Size = new System.Drawing.Size(45, 45);
            this.btnPrevious.TabIndex = 56;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Enabled = false;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPlay.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            this.btnPlay.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(230)))), ((int)(((byte)(0)))));
            this.btnPlay.IconSize = 70;
            this.btnPlay.Location = new System.Drawing.Point(810, 0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Rotation = 0D;
            this.btnPlay.Size = new System.Drawing.Size(90, 80);
            this.btnPlay.TabIndex = 7;
            this.btnPlay.TabStop = false;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotalTime.Location = new System.Drawing.Point(580, 53);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(44, 15);
            this.lblTotalTime.TabIndex = 48;
            this.lblTotalTime.Text = "00:00";
            // 
            // lblNowTime
            // 
            this.lblNowTime.AutoSize = true;
            this.lblNowTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNowTime.Location = new System.Drawing.Point(260, 53);
            this.lblNowTime.Name = "lblNowTime";
            this.lblNowTime.Size = new System.Drawing.Size(44, 15);
            this.lblNowTime.TabIndex = 47;
            this.lblNowTime.Text = "00:00";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 110);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 390F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 390F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 390F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(900, 390);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lvMusic);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(650, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 390);
            this.panel2.TabIndex = 0;
            // 
            // lvMusic
            // 
            this.lvMusic.AllowDrop = true;
            this.lvMusic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lvMusic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMusic.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.fileName,
            this.running,
            this.filePath,
            this.playCount});
            this.lvMusic.ContextMenuStrip = this.ctmLvMusic;
            this.lvMusic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMusic.ForeColor = System.Drawing.Color.Silver;
            this.lvMusic.FullRowSelect = true;
            this.lvMusic.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvMusic.HideSelection = false;
            this.lvMusic.Location = new System.Drawing.Point(0, 0);
            this.lvMusic.Name = "lvMusic";
            this.lvMusic.Scrollable = false;
            this.lvMusic.Size = new System.Drawing.Size(248, 388);
            this.lvMusic.TabIndex = 49;
            this.lvMusic.TabStop = false;
            this.lvMusic.UseCompatibleStateImageBehavior = false;
            this.lvMusic.View = System.Windows.Forms.View.Details;
            this.lvMusic.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvMusic_ColumnWidthChanging);
            this.lvMusic.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvMusic_DragDrop);
            this.lvMusic.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvMusic_DragEnter);
            this.lvMusic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvMusic_MouseDoubleClick);
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 30;
            // 
            // fileName
            // 
            this.fileName.Text = "파일명";
            this.fileName.Width = 150;
            // 
            // running
            // 
            this.running.Text = "시간";
            this.running.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.running.Width = 80;
            // 
            // filePath
            // 
            this.filePath.Text = "filePath";
            this.filePath.Width = 0;
            // 
            // playCount
            // 
            this.playCount.Text = "playCount";
            this.playCount.Width = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(650, 390);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.picLogo);
            this.panel5.Controls.Add(this.webBrowser1);
            this.panel5.Controls.Add(this.lblInfo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 40);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(650, 350);
            this.panel5.TabIndex = 2;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picLogo.Image = global::나도가수다.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(220, 50);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 67;
            this.picLogo.TabStop = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, -1);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(124, 92);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblInfo.Font = new System.Drawing.Font("함초롬바탕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(165, 258);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(360, 63);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "로그인을 하지 않은 이용자분들은 \r\n기본 플레이어 기능만 이용가능합니다.";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnWebHome);
            this.panel4.Controls.Add(this.btnWebForward);
            this.panel4.Controls.Add(this.btnWebRefresh);
            this.panel4.Controls.Add(this.btnWebBack);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(650, 40);
            this.panel4.TabIndex = 1;
            // 
            // btnWebHome
            // 
            this.btnWebHome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnWebHome.FlatAppearance.BorderSize = 0;
            this.btnWebHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebHome.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnWebHome.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.btnWebHome.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWebHome.IconSize = 30;
            this.btnWebHome.Location = new System.Drawing.Point(150, 0);
            this.btnWebHome.Name = "btnWebHome";
            this.btnWebHome.Rotation = 0D;
            this.btnWebHome.Size = new System.Drawing.Size(40, 40);
            this.btnWebHome.TabIndex = 3;
            this.btnWebHome.UseVisualStyleBackColor = true;
            this.btnWebHome.Visible = false;
            this.btnWebHome.Click += new System.EventHandler(this.btnWebHome_Click);
            // 
            // btnWebForward
            // 
            this.btnWebForward.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnWebForward.FlatAppearance.BorderSize = 0;
            this.btnWebForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebForward.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnWebForward.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnWebForward.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWebForward.IconSize = 30;
            this.btnWebForward.Location = new System.Drawing.Point(50, 0);
            this.btnWebForward.Name = "btnWebForward";
            this.btnWebForward.Rotation = 0D;
            this.btnWebForward.Size = new System.Drawing.Size(40, 40);
            this.btnWebForward.TabIndex = 2;
            this.btnWebForward.UseVisualStyleBackColor = true;
            this.btnWebForward.Visible = false;
            this.btnWebForward.Click += new System.EventHandler(this.btnWebForward_Click);
            // 
            // btnWebRefresh
            // 
            this.btnWebRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnWebRefresh.FlatAppearance.BorderSize = 0;
            this.btnWebRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebRefresh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnWebRefresh.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.btnWebRefresh.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWebRefresh.IconSize = 30;
            this.btnWebRefresh.Location = new System.Drawing.Point(100, 0);
            this.btnWebRefresh.Name = "btnWebRefresh";
            this.btnWebRefresh.Rotation = 0D;
            this.btnWebRefresh.Size = new System.Drawing.Size(40, 40);
            this.btnWebRefresh.TabIndex = 1;
            this.btnWebRefresh.UseVisualStyleBackColor = true;
            this.btnWebRefresh.Visible = false;
            this.btnWebRefresh.Click += new System.EventHandler(this.btnWebRefresh_Click);
            // 
            // btnWebBack
            // 
            this.btnWebBack.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnWebBack.FlatAppearance.BorderSize = 0;
            this.btnWebBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebBack.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnWebBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnWebBack.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWebBack.IconSize = 30;
            this.btnWebBack.Location = new System.Drawing.Point(10, 0);
            this.btnWebBack.Name = "btnWebBack";
            this.btnWebBack.Rotation = 0D;
            this.btnWebBack.Size = new System.Drawing.Size(40, 40);
            this.btnWebBack.TabIndex = 0;
            this.btnWebBack.UseVisualStyleBackColor = true;
            this.btnWebBack.Visible = false;
            this.btnWebBack.Click += new System.EventHandler(this.btnWebBack_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel_Top, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 530);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 500);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(900, 30);
            this.panel3.TabIndex = 2;
            // 
            // ctmMember
            // 
            this.ctmMember.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctmMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그아웃ToolStripMenuItem,
            this.받은파일폴더열기ToolStripMenuItem});
            this.ctmMember.Name = "ctmMember";
            this.ctmMember.Size = new System.Drawing.Size(214, 52);
            // 
            // 로그아웃ToolStripMenuItem
            // 
            this.로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            this.로그아웃ToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.로그아웃ToolStripMenuItem.Text = "로그아웃";
            this.로그아웃ToolStripMenuItem.Click += new System.EventHandler(this.로그아웃ToolStripMenuItem_Click);
            // 
            // 받은파일폴더열기ToolStripMenuItem
            // 
            this.받은파일폴더열기ToolStripMenuItem.Name = "받은파일폴더열기ToolStripMenuItem";
            this.받은파일폴더열기ToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.받은파일폴더열기ToolStripMenuItem.Text = "받은 파일 폴더 열기";
            this.받은파일폴더열기ToolStripMenuItem.Click += new System.EventHandler(this.받은파일폴더열기ToolStripMenuItem_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 530);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 530);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "나도가수다";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ctmLvMusic.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbum)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ctmMember.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip ctmLvMusic;
        private System.Windows.Forms.ToolStripMenuItem 삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 전체삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상세정보보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 곡정보보기ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblNowTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvMusic;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader running;
        private System.Windows.Forms.ColumnHeader filePath;
        private System.Windows.Forms.ColumnHeader playCount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblLogin;
        private FontAwesome.Sharp.IconButton btnPlay;
        private FontAwesome.Sharp.IconButton btnNext;
        private FontAwesome.Sharp.IconButton btnPrevious;
        private FontAwesome.Sharp.IconButton btnMiniMode;
        private FontAwesome.Sharp.IconButton btnMinimum;
        private FontAwesome.Sharp.IconButton btnMaximum;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnMode;
        private System.Windows.Forms.Label lblMember;
        private Bunifu.Framework.UI.BunifuSlider volumeSlider;
        private Bunifu.Framework.UI.BunifuSlider musicBar;
        private FontAwesome.Sharp.IconButton btnVolUP;
        private FontAwesome.Sharp.IconButton btnMute;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picAlbum;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox picLogo;
        private FontAwesome.Sharp.IconButton btnWebBack;
        private FontAwesome.Sharp.IconButton btnWebHome;
        private FontAwesome.Sharp.IconButton btnWebForward;
        private FontAwesome.Sharp.IconButton btnWebRefresh;
        private System.Windows.Forms.ContextMenuStrip ctmMember;
        private System.Windows.Forms.ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.ToolStripMenuItem 받은파일폴더열기ToolStripMenuItem;
    }
}

