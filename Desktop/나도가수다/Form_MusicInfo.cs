using HundredMilesSoftware.UltraID3Lib;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 나도가수다
{
    public partial class Form_MusicInfo : Form
    {
        private bool isMove = false;
        private Point fPt;
        Form_Main form_main;
        private string SMusic;
        private string fileFolder;

        public Form_MusicInfo(Form_Main form_M)
        {
            InitializeComponent();
            form_main = form_M;
        }

        private void Form_MusicInfo_Load(object sender, EventArgs e)
        {
            SMusic = form_main.SelectMusic;
            Load_MusicInfo();
        }

        private void Load_MusicInfo()
        {
            FileInfo fileInfo = new FileInfo(SMusic);
            UltraID3 myFile = new UltraID3();

            myFile.Read(fileInfo.FullName);

            Bitmap musicImgBitmap;
            ID3FrameCollection myFrames = myFile.ID3v2Tag.Frames.GetFrames(MultipleInstanceID3v2FrameTypes.ID3v23Picture);

            try
            {
                musicImgBitmap = ((ID3v23PictureFrame)myFrames[0]).Picture;
                pictureBox1.Image = musicImgBitmap;
            }
            catch
            {
                pictureBox1.Image = null;
            }

            string fileName = fileInfo.Name;

            double fileSize = fileInfo.Length;

            string duration = Getmp3Duration(SMusic);

            fileFolder = fileInfo.Directory.FullName;
            lblTitle.Text = myFile.ID3v2Tag.Title;
            lblArtist.Text = myFile.ID3v2Tag.Artist;
            lblAlbum.Text = myFile.ID3v2Tag.Album;
            lblPlayTIme.Text = duration;
            lblMemory.Text = ((fileSize/1024)/1024).ToString("N2") + "MB";
        }

        public static string Getmp3Duration(string fileName)
        {
            Mp3FileReader mfr = new Mp3FileReader(fileName);
            string TimeLength = string.Format("{0:D2}:{1:D2}:{2:D2}", mfr.TotalTime.Hours, mfr.TotalTime.Minutes, mfr.TotalTime.Seconds);
            return TimeLength;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(fileFolder);
        }

        #region 폼 이동

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            //마우스 눌렀을 때 위치 저장
            fPt = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //마우스 왼쪽버튼을 눌렀을 경우에만
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
        }

        #endregion
    }
}
