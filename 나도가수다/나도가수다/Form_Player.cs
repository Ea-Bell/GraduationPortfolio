using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 나도가수다
{
    public partial class Form_Player : MetroFramework.Forms.MetroForm
    {
        Form_MusicList fMusicList = new Form_MusicList();
        Form_Browser fBrowser = new Form_Browser();

        public Form_Player()
        {
            InitializeComponent();
            Form_Init();
        }

        public void Form_Init()
        {
            this.Size = new Size(250, 250);
            fMusicList.Size = new Size(250, 300);
            fBrowser.Size = new Size(300, 300);
            
            this.Location = new Point(150, 150);     
            fMusicList.Location = new Point(this.Location.X, this.Location.Y + this.Height);
            fBrowser.Location = new Point(this.Location.X + this.Width, this.Location.Y );

            fMusicList.Owner = this;
            fBrowser.Owner = this;

            fMusicList.Show();
            fBrowser.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void Form_Player_MouseMove(object sender, MouseEventArgs e)
        {
            Point curMousePos = PointToScreen(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left)
            {
                //MessageBox.Show("d");
                this.Focus();
                this.Location = curMousePos;    
                fMusicList.Location = new Point(this.Location.X, this.Location.Y + this.Height);
                fBrowser.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            }
        }

        private void Form_Player_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form_Player_Move(object sender, EventArgs e)
        {
           
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
