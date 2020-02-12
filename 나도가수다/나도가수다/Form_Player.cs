using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;

namespace 나도가수다
{
    public partial class Form_Player : MetroFramework.Forms.MetroForm
    {
        Form_MusicList fMusicList = new Form_MusicList();
        Form_Browser fBrowser = new Form_Browser();

        private IWavePlayer wavePlayer;
        private AudioFileReader reader;


        public Form_Player()
        {
            InitializeComponent();
            Form_Init();
        }

        public void Form_Init()
        {           
            this.Location = new Point(150, 150);     
            fMusicList.Location = new Point(this.Location.X, this.Location.Y + this.Height);
            fBrowser.Location = new Point(this.Location.X + this.Width, this.Location.Y );

            fMusicList.Owner = this;
            fBrowser.Owner = this;

            fMusicList.Show();
            fBrowser.Show();
        }

        
    }
}
