using HundredMilesSoftware.UltraID3Lib;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 나도가수다
{
    public partial class Form_MiniPlayer : Form
    {
        Form_Main form_main;
        private bool isMove = false;
        private Point fPt;

        private string mainMusic;

        public Form_MiniPlayer(Form_Main form_M)
        {
            InitializeComponent();
            form_main = form_M;
            //this.WindowState = FormWindowState.Minimized;
            this.Opacity = 0;
            this.ShowInTaskbar = false;
        }

        private void Form_MiniPlayer_Load(object sender, EventArgs e)
        {
            form_main.btnCheck.Click += new EventHandler(Playing);
            //픽쳐박스 위의 컨트롤 배경을 투명으로 하는 법
            picMiniAlbum.Dock = DockStyle.Fill;
            picMiniAlbum.SendToBack();
            panel_Top.BackColor = Color.Transparent;
            panel_Top.Parent = picMiniAlbum;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Parent = picMiniAlbum;
            lblArtist.BackColor = Color.Transparent;
            lblArtist.Parent = picMiniAlbum;
            btnMMode.BackColor = Color.Transparent;
            btnMMode.Parent = picMiniAlbum;
            btnVolume.BackColor = Color.Transparent;
            btnVolume.Parent = picMiniAlbum;
            btnMiniPrevious.BackColor = Color.Transparent;
            btnMiniPrevious.Parent = picMiniAlbum;
            btnMiniPlay.BackColor = Color.Transparent;
            btnMiniPlay.Parent = picMiniAlbum;
            btnMiniNext.BackColor = Color.Transparent;
            btnMiniNext.Parent = picMiniAlbum;
            lblNowTime.BackColor = Color.Transparent;
            lblNowTime.Parent = picMiniAlbum;
            lblTotalTime.BackColor = Color.Transparent;
            lblTotalTime.Parent = picMiniAlbum;
            miniTrackBar.BackColor = Color.Transparent;
            miniTrackBar.Parent = picMiniAlbum;
            miniVolumeSlider.BackColor = Color.Transparent;
            miniVolumeSlider.Parent = picMiniAlbum;

            miniVolumeSlider.Visible = false;
        }

        #region 폼관련
        
        //Alt+Tap에서 숨기기
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void btnMiniMode_Click(object sender, EventArgs e)
        {
            if (form_main.Opacity == 0)
            {
                form_main.Location = new Point(this.Location.X - 350, this.Location.Y - 100);//this.Location;
                //this.WindowState = FormWindowState.Minimized;
                this.Opacity = 0;
                this.ShowInTaskbar = false;

                //form_main.WindowState = FormWindowState.Normal;
                form_main.Opacity = 1.0;
                form_main.ShowInTaskbar = true;
                form_main.Focus();
            }
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            form_main.Close();
        }
        
        private void panel_Top_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            //마우스 눌렀을 때 위치 저장
            fPt = new Point(e.X, e.Y);
        }

        private void panel_Top_MouseMove(object sender, MouseEventArgs e)
        {
            //마우스 왼쪽버튼을 눌렀을 경우에만
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (fPt.X - e.X), this.Top - (fPt.Y - e.Y));
        }

        private void panel_Top_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        #endregion

        //픽쳐박스 투명도 조절
        public Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            Graphics graphics = Graphics.FromImage(bmp);

            ColorMatrix colormatrix = new ColorMatrix();

            colormatrix.Matrix33 = opacityvalue;

            ImageAttributes imgAttribute = new ImageAttributes();

            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);

            graphics.Dispose();

            return bmp;
        }

        //메인폼의 체크버튼이 눌러지면 발동하는 이벤트, 현재 재생중인 음원 정보들 가져오기
        public void Playing(object sender, EventArgs e)
        {
            mainMusic = form_main.PlayingMusic;

            //MessageBox.Show(mainMusic);

            Load_MusicInfo();

            if (picMiniAlbum.Image != null)
            {
                picMiniAlbum.Image = ChangeOpacity(picMiniAlbum.Image, 0.8f);
            }
        }

        #region 음악정보

        private void Load_MusicInfo()
        {
            FileInfo fileInfo = new FileInfo(mainMusic);
            UltraID3 myFile = new UltraID3();

            myFile.Read(fileInfo.FullName);

            Bitmap musicImgBitmap;
            ID3FrameCollection myFrames = myFile.ID3v2Tag.Frames.GetFrames(MultipleInstanceID3v2FrameTypes.ID3v23Picture);

            try
            {
                musicImgBitmap = ((ID3v23PictureFrame)myFrames[0]).Picture;
                picMiniAlbum.Image = musicImgBitmap;
            }
            catch
            {
                picMiniAlbum.Image = null;
            }

            string duration = Getmp3Duration(mainMusic);

            lblTitle.Text = myFile.ID3v2Tag.Title;
            lblArtist.Text = myFile.ID3v2Tag.Artist;
            lblTotalTime.Text = duration;
        }

        public static string Getmp3Duration(string fileName)
        {
            Mp3FileReader mfr = new Mp3FileReader(fileName);
            string TimeLength = string.Format("{0:D2}:{1:D2}", mfr.TotalTime.Minutes, mfr.TotalTime.Seconds);
            return TimeLength;
        }

        #endregion

        //볼륨 visible 조절
        private void btnVolume_Click(object sender, EventArgs e)
        {
            if (miniVolumeSlider.Visible == false)
            {
                miniVolumeSlider.Visible = true;
            }
            else if (miniVolumeSlider.Visible == true)
            {
                miniVolumeSlider.Visible = false;
            }
        }

        #region 비어있는 이벤트
        //이벤트 메서드
        public void received(string music)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnMMode_Click(object sender, EventArgs e)
        {

        }

        private void btnMiniPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnMiniPlay_Click(object sender, EventArgs e)
        {

        }

        private void btnMiniNext_Click(object sender, EventArgs e)
        {

        }

        private void miniTrackBar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void miniVolumeSlider_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
