namespace 나도가수다
{
    partial class Form_Player
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
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroScrollBar1 = new MetroFramework.Controls.MetroScrollBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(8, 78);
            this.metroTrackBar1.Maximum = 9999;
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(192, 46);
            this.metroTrackBar1.TabIndex = 12;
            this.metroTrackBar1.Text = "metroTrackBar1";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(225, -4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(36, 23);
            this.metroButton1.TabIndex = 13;
            this.metroButton1.Text = "X";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Teal;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(8, 34);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(38, 38);
            this.metroButton2.TabIndex = 15;
            this.metroButton2.Text = "|◀";
            this.metroButton2.UseSelectable = true;
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(67, 34);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(38, 38);
            this.metroButton3.TabIndex = 16;
            this.metroButton3.Text = "▷||";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton4.Location = new System.Drawing.Point(126, 34);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(38, 38);
            this.metroButton4.TabIndex = 17;
            this.metroButton4.Text = "■";
            this.metroButton4.UseSelectable = true;
            // 
            // metroButton5
            // 
            this.metroButton5.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton5.Location = new System.Drawing.Point(183, 34);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(38, 38);
            this.metroButton5.TabIndex = 18;
            this.metroButton5.Text = "▶|";
            this.metroButton5.UseSelectable = true;
            // 
            // metroScrollBar1
            // 
            this.metroScrollBar1.LargeChange = 10;
            this.metroScrollBar1.Location = new System.Drawing.Point(225, 78);
            this.metroScrollBar1.Maximum = 100;
            this.metroScrollBar1.Minimum = 0;
            this.metroScrollBar1.MouseWheelBarPartitions = 10;
            this.metroScrollBar1.Name = "metroScrollBar1";
            this.metroScrollBar1.Orientation = MetroFramework.Controls.MetroScrollOrientation.Vertical;
            this.metroScrollBar1.ScrollbarSize = 10;
            this.metroScrollBar1.Size = new System.Drawing.Size(10, 46);
            this.metroScrollBar1.TabIndex = 20;
            this.metroScrollBar1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroScrollBar1.UseSelectable = true;
            this.metroScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroScrollBar1_Scroll);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(224, 118);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(15, 20);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "-";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(221, 57);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(19, 20);
            this.metroLabel2.TabIndex = 22;
            this.metroLabel2.Text = "+";
            // 
            // metroButton7
            // 
            this.metroButton7.Location = new System.Drawing.Point(8, 122);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(65, 22);
            this.metroButton7.TabIndex = 23;
            this.metroButton7.Text = "폴더추가";
            this.metroButton7.UseSelectable = true;
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(80, 123);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(0, 0);
            this.metroLabel3.TabIndex = 24;
            // 
            // Form_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 150);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroButton7);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroScrollBar1);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroTrackBar1);
            this.Name = "Form_Player";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form_Player_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Player_MouseMove);
            this.Move += new System.EventHandler(this.Form_Player_Move);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroScrollBar metroScrollBar1;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton7;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}

