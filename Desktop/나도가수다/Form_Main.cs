using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using System.Diagnostics;
using System.Collections;
using System.Net;
using System.Xml.Linq;
using HundredMilesSoftware.UltraID3Lib;
using kp.Toaster;
using System.Runtime.InteropServices;

namespace 나도가수다
{
    public partial class Form_Main : Form
    {
        #region 환경변수 및 프로퍼티(오디오 관련)

        private string gStrXmlFilePath = "C:\\나도가수다 보관함\\XML" + @"\MusicList.xml";
        private IWavePlayer wavePlayer;
        private AudioFileReader reader;
        private string MusicFile = string.Empty;
        private int index = 0, shuffleindex = -1;
        private int modeNum = 0;

        List<int> randomList = new List<int>();
        Random random = new Random();

        Stream ms = new MemoryStream();

        byte[] buffer = new byte[65536];

        public string SelectMusic
        {
            get;
            set;
        }

        public string PlayingMusic
        {
            get;
            set;
        }

        public IWavePlayer GetWavePlayer
        {
            get;
            set;
        }

        public AudioFileReader GetReader
        {
            get;
            set;
        }

        #endregion

        #region 환경변수 및 프로퍼티(웹클라이언트, 웹브라우저 관련)

        WebPost webPost = new WebPost();

        private WebClient wc = new WebClient();
        String downfileUrl = null;
        private Boolean nowDownloading = false;

        bool is_sec_page = false;

        public bool CheckLogin { get; set; } = false;

        public string LoginId { get; set; }

        public string LoginPassword { get; set; }

        #endregion

        #region 환경변수 및 프로퍼티(폼 관련)

        private const int cGrip = 16;
        private const int cCaption = 32;
        const int wm_nchittest = 0x84;
        const int htclient = 1;
        const int htcaption = 2;

        private bool isMove = false;
        private Point fPt;

        //미니모드
        Form_MiniPlayer form_Mini = null;

        #endregion

        public Form_Main()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            this.Focus();

            form_Mini = new Form_MiniPlayer(this);
            form_Mini.Show();

            btnCheck.Size = new Size(0, 0);

            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(fileDownloadCompleted);

            //이벤트 등록
            form_Mini.btnMMode.Click += new EventHandler(BtnClickMode);
            form_Mini.btnMiniPrevious.Click += new EventHandler(BtnClickPrevious);
            form_Mini.btnMiniNext.Click += new EventHandler(BtnClickNext);
            form_Mini.btnMiniPlay.Click += new EventHandler(BtnClickPlay);
            form_Mini.miniTrackBar.ValueChanged += new EventHandler(MiniTrackChange);
            form_Mini.miniVolumeSlider.ValueChanged += new EventHandler(MiniVolumeChange);

            LoadXml();
        }

        #region 미니폼 이벤트 관련
        
        void BtnClickMode(object sender, EventArgs e)
        {
            btnMode.PerformClick();
        }

        void BtnClickPrevious(object sender, EventArgs e)
        {
            btnPrevious.PerformClick();
        }

        void BtnClickNext(object sender, EventArgs e)
        {
            btnNext.PerformClick();
        }

        void BtnClickPlay(object sender, EventArgs e)
        {
            btnPlay.PerformClick();
        }

        void MiniTrackChange(object sender, EventArgs e)
        {
            if (this.reader != null)
            {
                reader.Position = (form_Mini.miniTrackBar.Value * reader.Length) / musicBar.MaximumValue;
                musicBar.Value = form_Mini.miniTrackBar.Value;
            }
        }

        void MiniVolumeChange(object sender, EventArgs e)
        {
            if (this.reader != null)
            {
                //this.reader.Volume = volumeSlider1.Value/100.0F;
                wavePlayer.Volume = form_Mini.miniVolumeSlider.Value / 100.0F;
                volumeSlider.Value = form_Mini.miniVolumeSlider.Value;
            }
        }

        #endregion

        #region disable screensaver/화면 보호기 방지

        //http://www.blackwasp.co.uk/DisableScreensaver.aspx
        [DllImport("kernel32.dll")]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
        }

        public static void DisableSaver()
        {
            SetThreadExecutionState(
                EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }

        public static void EnableSaver()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }

        #endregion

        #region 폼 관련

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = (cp.Style | 262144);
                //cp.Style |= 0x40000;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void btnMiniMode_Click(object sender, EventArgs e)
        {
            if (form_Mini.Opacity == 0)
            {
                form_Mini.Location = new Point(this.Location.X + 350, this.Location.Y + 100);//this.Location;
                //this.WindowState = FormWindowState.Minimized;
                this.Opacity = 0;
                this.ShowInTaskbar = false;

                //form_Mini.WindowState = FormWindowState.Normal;
                form_Mini.Opacity = 1.0;
                form_Mini.ShowInTaskbar = true;
                form_Mini.Focus();
            }
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximum_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void lblLogin_Click(object sender, EventArgs e)
        {
            Form_Login form_Login = new Form_Login(this);
            form_Login.ShowDialog();
            if (CheckLogin)
            {
                picLogo.Visible = false;
                lblInfo.Visible = false;
                btnWebBack.Visible = true;
                btnWebForward.Visible = true;
                btnWebRefresh.Visible = true;
                btnWebHome.Visible = true;
                webBrowser1.Dock = DockStyle.Fill;
                webBrowser1.Visible = true;

                webBrowser1.Navigate("http://" + webPost.GetIP + ":8989/webTest/View/login/login.jsp");

                //http://121.143.42.2:8989/WebTest/webTest/View/mainForm/mainForm.jsp
                //http://121.173.78.165:8989/WebTest/webTest/View/mainForm/mainForm.jsp
                //http://121.173.78.165:8989/WebTest/webTest/View/login/index.jsp
                //http://121.173.78.165:8989/WebTest/webTest/View/login/login.jsp?x=197&y=2

                lblLogin.Visible = false;
                lblMember.Visible = true;

                Toast.show(this, "나도 가수다", "나도 가수다에 로그인하셨습니다.", ToastType.INFO, ToastDuration.SHORT);
            }
        }

        private void lblMember_Click(object sender, EventArgs e)
        {
            ctmMember.Show(lblMember, new Point(0, lblMember.Height));
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //WebBrowser 세션 초기화
            webBrowser1.Document.ExecCommand("ClearAuthenticationCache", false, null);

            CheckLogin = false;
            is_sec_page = false;

            picLogo.Visible = true;
            lblInfo.Visible = true;
            btnWebBack.Visible = false;
            btnWebForward.Visible = false;
            btnWebRefresh.Visible = false;
            btnWebHome.Visible = false;
            webBrowser1.Visible = false;

            lblMember.Visible = false;
            lblLogin.Visible = true;

            Toast.show(this, "나도 가수다", "로그아웃되었습니다.", ToastType.INFO, ToastDuration.SHORT);
        }

        private void 받은파일폴더열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\나도가수다 보관함");
        }

        #endregion

        #region Xml 관련

        private void SaveXml()
        {
            XDocument xdoc = new XDocument();
            XElement xroot = new XElement("MusicList");
            xdoc.Add(xroot);
            string[] filenames = new string[lvMusic.Items.Count];

            for (int i = 0; i < lvMusic.Items.Count; i++)
            {
                filenames[i] = lvMusic.Items[i].SubItems[3].Text;
            }

            for (int i = 0; i < lvMusic.Items.Count; i++)
            {
                string item = filenames[i];

                if (item.EndsWith(".mp3"))
                {
                    FileInfo fileInfo = new FileInfo(item);

                    //폴더정보입력
                    if ((File.GetAttributes(item) & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        MessageBox.Show(item);
                    }

                    //파일정보입력
                    if ((File.GetAttributes(item) & FileAttributes.Directory) != FileAttributes.Directory)
                    {
                        string fileName = fileInfo.Name;
                        string fileFolder = fileInfo.Directory.FullName;
                        string baseFolder = Environment.CurrentDirectory; //기준폴더위치
                        Uri relative_Path = new Uri(Environment.CurrentDirectory).MakeRelativeUri(new Uri(fileFolder));
                        fileFolder = relative_Path.ToString();

                        double fileSize = fileInfo.Length;
                        var versionInfo = FileVersionInfo.GetVersionInfo(item);
                        string LastWriteTime = File.GetLastWriteTime(item).ToString(); //파일수정날짜(업데이트기초)
                        string fileVersion = versionInfo.ProductVersion;

                        XElement xel = new XElement("MusicInfo",
                            new XAttribute("Name", fileName),
                            new XElement("MusicPath", item),
                            new XElement("PlayCount", lvMusic.Items[i].SubItems[4].Text)
                            );
                        xroot.Add(xel);
                    }
                }
            }

            if (!System.IO.Directory.Exists("C:\\나도가수다 보관함\\XML"))
            {
                System.IO.Directory.CreateDirectory("C:\\나도가수다 보관함");
                System.IO.Directory.CreateDirectory("C:\\나도가수다 보관함\\XML");
            }

            xdoc.Save(gStrXmlFilePath);
        }

        private void LoadXml()
        {
            if (File.Exists(gStrXmlFilePath))
            {
                XDocument xdoc = XDocument.Load(gStrXmlFilePath);

                IEnumerable<XElement> emps = xdoc.Root.Elements();

                foreach (var emp in emps)
                {
                    string path = emp.Element("MusicPath").Value;
                    int count = 0;
                    string playCount = emp.Element("PlayCount").Value;
                    try
                    {
                        if (path.StartsWith("http"))
                        {
                            ListViewItem lsv = new ListViewItem();
                            lsv.SubItems.Add(path);
                            lsv.SubItems.Add(path);
                            lsv.SubItems.Add(path);
                            lvMusic.Items.Add(lsv);

                            for (int i = 0; i < lvMusic.Items.Count; i++)
                            {
                                lvMusic.Items[i].SubItems[0].Text = (i + 1).ToString();
                            }
                        }
                        else if (path.EndsWith(".mp3"))
                        {
                            Load_Mp3Info(path, lvMusic);
                        }
                        lvMusic.Items[count].SubItems[4].Text = playCount;
                        count++;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            if (lvMusic.Items.Count > 0)
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnPlay.Enabled = true;

                form_Mini.btnMiniPrevious.Enabled = true;
                form_Mini.btnMiniNext.Enabled = true;
                form_Mini.btnMiniPlay.Enabled = true;


                ExtensionClass.shuffleIndex(randomList, lvMusic);
                ExtensionClass.shuffle(randomList);
            }
        }

        #endregion

        #region NAudio 재생관련

        public void PlayMusic(string audioFile)
        {
            MusicFile = audioFile;
            PlayingMusic = audioFile;
            GetWavePlayer = wavePlayer;
            GetReader = reader;

            lblInfo.Visible = false;

            if (MusicFile != string.Empty)
            {
                if (File.Exists(MusicFile))
                {
                    musicBar.Value = 0;

                    Load_MusicInfo();

                    if (this.wavePlayer != null)
                        CleanUp();

                    Debug.Assert(this.wavePlayer == null);

                    this.wavePlayer = new WaveOut();
                    this.reader = new AudioFileReader(MusicFile);
                    //this.reader.Volume = volumeSlider1.Value / 100.0F;
                    wavePlayer.Volume = volumeSlider.Value / 100.0F;
                    this.wavePlayer.Init(reader);
                    this.wavePlayer.PlaybackStopped += wavePlayer_PlaybackStopped;
                    this.wavePlayer.Play();
                    timer1.Enabled = true;

                    //btnPlay.Text = "ll";
                    btnPlay.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
                    form_Mini.btnMiniPlay.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;

                    btnCheck.PerformClick();
                }
                else
                {
                    if (MessageBox.Show("파일을 찾을 수 없습니다. 목록에서 삭제하시겠습니까?\n(파일이 삭제되었거나 다른 위치로 이동되었습니다.)", "나도가수다", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    {
                        switch (modeNum)
                        {
                            case 0:
                                if (index < lvMusic.Items.Count - 1)
                                {
                                    Thread.Sleep(1000);
                                    lvMusic.Items[index].Selected = false;
                                    index++;
                                    lvMusic.Items[index].Selected = true;
                                    PlayMusic(lvMusic.Items[index].SubItems[3].Text);
                                }
                                break;
                            case 1:
                                break;
                            case 2:
                                if (index < lvMusic.Items.Count - 1)
                                {
                                    Thread.Sleep(1000);
                                    lvMusic.Items[index].Selected = false;
                                    index++;
                                    lvMusic.Items[index].Selected = true;
                                    PlayMusic(lvMusic.Items[index].SubItems[3].Text);
                                }
                                else if (index == lvMusic.Items.Count - 1)
                                {
                                    Thread.Sleep(1000);
                                    lvMusic.Items[index].Selected = false;
                                    index = 0;
                                    lvMusic.Items[index].Selected = true;
                                    PlayMusic(lvMusic.Items[index].SubItems[3].Text);
                                }
                                break;
                            case 3:
                                if (shuffleindex == randomList.Count - 1)
                                {
                                    ExtensionClass.shuffle(randomList);
                                    shuffleindex = -1;
                                }
                                else if (shuffleindex < randomList.Count - 1)
                                {
                                    Thread.Sleep(1000);
                                    lvMusic.Items[index].Selected = false;
                                    shuffleindex++;
                                    lvMusic.Items[randomList[shuffleindex]].Selected = true;
                                    index = lvMusic.SelectedItems[0].Index;
                                    PlayMusic(lvMusic.Items[randomList[shuffleindex]].SubItems[3].Text);
                                }
                                break;
                        }
                    }
                    else
                    {
                        lvMusic.Items.RemoveAt(index);
                        ExtensionClass.listView_No(lvMusic);  // 번호 다시 매기기
                        if (index > lvMusic.Items.Count - 1)
                        {
                            index = lvMusic.Items.Count - 1;
                        }
                        if (lvMusic.Items.Count != 0)
                        {
                            lvMusic.Items[index].Selected = true;
                            lvMusic.Items[index].EnsureVisible();
                        }
                        if (this.wavePlayer == null && lvMusic.Items.Count == 0)
                        {
                            btnPrevious.Enabled = false;
                            btnNext.Enabled = false;
                            btnPlay.Enabled = false;
                        }
                    }
                }
            }
        }

        void wavePlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            Debug.Assert(!this.InvokeRequired, "PlaybackStopped on wrong thread");

            CleanUp();
            timer1.Enabled = false;
            lblNowTime.Text = "00:00";

            if (e.Exception != null)
            {
                MessageBox.Show(String.Format("Playback Stopped due to an error {0}", e.Exception.Message));
            }
        }

        private void Load_MusicInfo()
        {
            FileInfo fileInfo = new FileInfo(MusicFile);
            UltraID3 myFile = new UltraID3();

            myFile.Read(fileInfo.FullName);

            Bitmap musicImgBitmap;
            ID3FrameCollection myFrames = myFile.ID3v2Tag.Frames.GetFrames(MultipleInstanceID3v2FrameTypes.ID3v23Picture);

            try
            {
                musicImgBitmap = ((ID3v23PictureFrame)myFrames[0]).Picture;
                picAlbum.Image = musicImgBitmap;
            }
            catch
            {
                picAlbum.Image = null;
            }

            string duration = Getmp3Duration(MusicFile);

            lblTitle.Text = myFile.ID3v2Tag.Title;
            lblArtist.Text = myFile.ID3v2Tag.Artist;
            lblTotalTime.Text = duration;
        }

        private string getFileName(string filePath)
        {
            return System.IO.Path.GetFileName(filePath);
        }

        private void CleanUp()
        {
            if (this.reader != null)
            {
                this.reader.Dispose();
                this.reader = null;
            }
            if (this.wavePlayer != null)
            {
                this.wavePlayer.Dispose();
                this.wavePlayer = null;
            }
        }

        private static string FormatTimeSpan(TimeSpan ts)
        {
            return string.Format("{0:D2}:{1:D2}", (int)ts.TotalMinutes, ts.Seconds);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //index = listView1.SelectedItems[0].Index;
            if (reader != null)
            {
                lblNowTime.Text = FormatTimeSpan(reader.CurrentTime);
                
                musicBar.Value = Math.Min((int)((musicBar.MaximumValue * reader.Position) / reader.Length), musicBar.MaximumValue);

                //미니폼
                form_Mini.lblNowTime.Text = FormatTimeSpan(reader.CurrentTime);
                form_Mini.miniTrackBar.Value = Math.Min((int)((musicBar.MaximumValue * reader.Position) / reader.Length), musicBar.MaximumValue);

                if (FormatTimeSpan(reader.CurrentTime) == FormatTimeSpan(reader.TotalTime))
                {
                    if (lvMusic.Items.Count == 0)
                    {
                        btnPrevious.Enabled = false;
                        btnNext.Enabled = false;
                        btnPlay.Enabled = false;

                        form_Mini.btnMiniPrevious.Enabled = false;
                        form_Mini.btnMiniNext.Enabled = false;
                        form_Mini.btnMiniPlay.Enabled = false;

                        musicBar.Value = 0;
                        lblTotalTime.Text = "00:00";
                        lblTitle.Text = "현재 재생중인 곡이 없습니다.";
                        lblArtist.Text = null;
                        picAlbum.Image = null;

                        btnPlay.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;

                        return;
                    }

                    lvMusic.Items[index].SubItems[4].Text = (Int32.Parse(lvMusic.Items[index].SubItems[4].Text) + 1).ToString();

                    switch (modeNum)
                    {
                        case 0:
                            if (index < lvMusic.Items.Count - 1)
                            {
                                Thread.Sleep(1000);
                                lvMusic.Items[index].Selected = false;
                                index++;
                                lvMusic.Items[index].Selected = true;
                                PlayMusic(lvMusic.Items[index].SubItems[3].Text);
                            }
                            else if (index >= lvMusic.Items.Count - 1)
                            {
                                musicBar.Value = 0;
                                lblTotalTime.Text = "00:00";
                                lblTitle.Text = "현재 재생중인 곡이 없습니다.";
                                lblArtist.Text = null;
                                picAlbum.Image = null;

                                btnPlay.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
                            }
                            break;
                        case 1:
                            Thread.Sleep(1000);
                            PlayMusic(lvMusic.Items[index].SubItems[3].Text);
                            break;
                        case 2:
                            if (index < lvMusic.Items.Count - 1)
                            {
                                Thread.Sleep(1000);
                                lvMusic.Items[index].Selected = false;
                                index++;
                                lvMusic.Items[index].Selected = true;
                                PlayMusic(lvMusic.Items[index].SubItems[3].Text);
                            }
                            else if (index == lvMusic.Items.Count - 1)
                            {
                                Thread.Sleep(1000);
                                lvMusic.Items[index].Selected = false;
                                index = 0;
                                lvMusic.Items[index].Selected = true;
                                PlayMusic(lvMusic.Items[index].SubItems[3].Text);
                            }
                            break;
                        case 3:
                            if (shuffleindex == randomList.Count - 1)
                            {
                                ExtensionClass.shuffle(randomList);
                                shuffleindex = -1;
                            }
                            else if (shuffleindex < randomList.Count - 1)
                            {
                                Thread.Sleep(1000);
                                lvMusic.Items[index].Selected = false;
                                shuffleindex++;
                                lvMusic.Items[randomList[shuffleindex]].Selected = true;
                                index = lvMusic.SelectedItems[0].Index;
                                PlayMusic(lvMusic.Items[randomList[shuffleindex]].SubItems[3].Text);
                            }
                            break;
                    }
                }
            }
            if (this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                DisableSaver();
            }
            else if (this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Paused || this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Stopped)
            {
                EnableSaver();
            }
        }

        public static string Getmp3Duration(string fileName)
        {
            Mp3FileReader mfr = new Mp3FileReader(fileName);
            string TimeLength = string.Format("{0:D2}:{1:D2}", mfr.TotalTime.Minutes, mfr.TotalTime.Seconds);
            return TimeLength;
        }

        #endregion

        #region 리스트뷰(lvMusic)


        private void Load_Mp3Info(string fileName, ListView LV)
        {
            int Number = 0;
            string FileName = Path.GetFileName(fileName);
            string Duration = string.Empty;
            if (fileName.EndsWith(".mp3"))
                Duration = Getmp3Duration(fileName);

            ListViewItem lsv = new ListViewItem(Number.ToString());
            lsv.SubItems.Add(FileName);
            lsv.SubItems.Add(Duration);
            lsv.SubItems.Add(fileName);
            lsv.SubItems.Add("0");
            LV.Items.Add(lsv);

            for (int i = 0; i < LV.Items.Count; i++)
            {
                LV.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void lvMusic_DragDrop(object sender, DragEventArgs e)
        {
            if (btnPlay.Enabled == false || btnPrevious.Enabled == false || btnNext.Enabled == false)
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnPlay.Enabled = true;

                form_Mini.btnMiniPrevious.Enabled = true;
                form_Mini.btnMiniNext.Enabled = true;
                form_Mini.btnMiniPlay.Enabled = true;
            }
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string filename in filenames)
            {
                try
                {
                    Load_Mp3Info(filename, lvMusic);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            ExtensionClass.shuffleIndex(randomList, lvMusic);
            ExtensionClass.shuffle(randomList);
        }

        private void lvMusic_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }


        private void lvMusic_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvMusic.Columns[e.ColumnIndex].Width;
        }

        private void lvMusic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            index = lvMusic.SelectedItems[0].Index;
            PlayMusic(lvMusic.SelectedItems[0].SubItems[3].Text);
        }

        #endregion

        #region 버튼클릭

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (btnMute.IconChar == FontAwesome.Sharp.IconChar.VolumeDown || btnMute.IconChar == FontAwesome.Sharp.IconChar.VolumeOff)
            {
                btnMute.IconChar = FontAwesome.Sharp.IconChar.VolumeMute;

                if (reader != null)
                {
                    wavePlayer.Volume = 0;
                }
            }
            else if (btnMute.IconChar == FontAwesome.Sharp.IconChar.VolumeMute)
            {
                if (volumeSlider.Value == 0)
                {
                    btnMute.IconChar = FontAwesome.Sharp.IconChar.VolumeOff;
                }
                else if (volumeSlider.Value > 0)
                {
                    btnMute.IconChar = FontAwesome.Sharp.IconChar.VolumeDown;
                }

                if (reader != null)
                {
                    wavePlayer.Volume = volumeSlider.Value / 100.0F;
                }
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            if (modeNum < 3)
                modeNum++;
            else
                modeNum = 0;

            switch (modeNum)
            {
                case 0:
                    btnMode.IconChar = FontAwesome.Sharp.IconChar.RedoAlt;
                    form_Mini.btnMMode.IconChar = FontAwesome.Sharp.IconChar.RedoAlt;
                    break;
                case 1:
                    btnMode.IconChar = FontAwesome.Sharp.IconChar.Rev;
                    form_Mini.btnMMode.IconChar = FontAwesome.Sharp.IconChar.Rev;
                    break;
                case 2:
                    btnMode.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
                    form_Mini.btnMMode.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
                    break;
                case 3:
                    btnMode.IconChar = FontAwesome.Sharp.IconChar.Random;
                    form_Mini.btnMMode.IconChar = FontAwesome.Sharp.IconChar.Random;
                    break;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (modeNum == 3)
            {
                lvMusic.Items[index].Selected = false;
                shuffleindex--;
                if (shuffleindex < 0)
                {
                    ExtensionClass.shuffle(randomList);
                    shuffleindex = 0;
                }
                lvMusic.Items[randomList[shuffleindex]].Selected = true;
                index = lvMusic.SelectedItems[0].Index;
                PlayMusic(lvMusic.Items[randomList[shuffleindex]].SubItems[3].Text);
            }
            else
            {
                lvMusic.Items[index].Selected = false;
                index--;
                if (index < 0)
                {
                    index = lvMusic.Items.Count - 1;
                }
                lvMusic.Items[index].Selected = true;
                index = lvMusic.SelectedItems[0].Index;
                PlayMusic(lvMusic.Items[index].SubItems[3].Text);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (modeNum == 3)
            {
                lvMusic.Items[index].Selected = false;
                shuffleindex++;
                if (shuffleindex == randomList.Count)
                {
                    ExtensionClass.shuffle(randomList);
                    shuffleindex = 0;
                }
                lvMusic.Items[randomList[shuffleindex]].Selected = true;
                index = lvMusic.SelectedItems[0].Index;
                PlayMusic(lvMusic.Items[randomList[shuffleindex]].SubItems[3].Text);
            }
            else
            {
                lvMusic.Items[index].Selected = false;
                index++;
                if (index > lvMusic.Items.Count - 1)
                {
                    index = 0;
                }
                lvMusic.Items[index].Selected = true;
                index = lvMusic.SelectedItems[0].Index;
                PlayMusic(lvMusic.Items[index].SubItems[3].Text);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (MusicFile != string.Empty)
            {
                if (this.wavePlayer != null)
                {
                    if (this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                    {
                        this.wavePlayer.Pause();
                        
                        btnPlay.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
                        form_Mini.btnMiniPlay.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
                    }
                    else if (this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                    {
                        this.wavePlayer.Play();
                        
                        btnPlay.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
                        form_Mini.btnMiniPlay.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
                    }
                }
                else
                {
                    PlayMusic(MusicFile);
                }
            }
            else
            {
                lvMusic.Items[0].Selected = true;
                index = lvMusic.SelectedItems[0].Index;
                PlayMusic(lvMusic.SelectedItems[0].SubItems[3].Text);
            }
        }

        #endregion

        #region contextmenustrip, trackbar

        private void ctmLvMusic_Opening(object sender, CancelEventArgs e)
        {
            if (lvMusic.SelectedItems.Count <= 0)
            {
                곡정보보기ToolStripMenuItem.Enabled = false;
                삭제ToolStripMenuItem.Enabled = false;
            }
            else if (lvMusic.SelectedItems.Count == 1)
            {
                곡정보보기ToolStripMenuItem.Enabled = true;
                삭제ToolStripMenuItem.Enabled = true;
            }
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMusic.SelectedItems.Count <= 0)
            {
                MessageBox.Show("선택된 노래가 없습니다");
                return;
            }
            int index = lvMusic.SelectedIndices[0]; // 선택된 첫번째 레코드의 인덱스
            //index = LV.FocusedItem.Index;
            foreach (ListViewItem row in lvMusic.SelectedItems)
            {
                lvMusic.Items.Remove(row);  // 선택한 행 삭제
            }
            ExtensionClass.listView_No(lvMusic);  // 번호 다시 매기기
            if (index > lvMusic.Items.Count - 1)
            {
                index = lvMusic.Items.Count - 1;
            }
            if(lvMusic.Items.Count !=0)
            {
                lvMusic.Items[index].Selected = true;
                lvMusic.Items[index].EnsureVisible();
            }

            if (lvMusic.Items.Count == 0)
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;

                form_Mini.btnMiniPrevious.Enabled = false;
                form_Mini.btnMiniNext.Enabled = false;

                if (this.wavePlayer == null)
                {
                    btnPlay.Enabled = false;

                    form_Mini.btnMiniPlay.Enabled = false;
                }
            }
        }

        private void 전체삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;

            form_Mini.btnMiniPrevious.Enabled = false;
            form_Mini.btnMiniNext.Enabled = false;

            if (this.wavePlayer == null)
            {
                btnPlay.Enabled = false;

                form_Mini.btnMiniPlay.Enabled = false;
            }

            lvMusic.Items.Clear();
        }
        
        private void 곡정보보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectMusic = lvMusic.SelectedItems[0].SubItems[3].Text;
            Form_MusicInfo form_MusicInfo = new Form_MusicInfo(this);
            form_MusicInfo.ShowDialog();
        }

        private void volumeSlider_ValueChanged(object sender, EventArgs e)
        {
            if (this.reader != null)
            {
                //this.reader.Volume = volumeSlider1.Value/100.0F;
                wavePlayer.Volume = volumeSlider.Value / 100.0F;

                form_Mini.miniVolumeSlider.Value = this.volumeSlider.Value;
            }

            if (btnMute.IconChar == FontAwesome.Sharp.IconChar.VolumeDown && volumeSlider.Value == 0)
            {
                btnMute.IconChar = FontAwesome.Sharp.IconChar.VolumeOff;
            }
            else if (btnMute.IconChar == FontAwesome.Sharp.IconChar.VolumeOff && volumeSlider.Value != 0)
            {
                btnMute.IconChar = FontAwesome.Sharp.IconChar.VolumeDown;
            }
            else if (btnMute.IconChar == FontAwesome.Sharp.IconChar.VolumeMute)
            {
                btnMute.PerformClick();
            }
        }

        private void musicBar_ValueChanged(object sender, EventArgs e)
        {
            if (this.reader != null)
            {
                reader.Position = (musicBar.Value * reader.Length) / musicBar.MaximumValue;

                form_Mini.miniTrackBar.Value = this.musicBar.Value;
            }
        }

        #endregion

        #region 웹클라이언트, 웹브라우저

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString().EndsWith(".mp3"))
            {
                if (nowDownloading)
                {
                    e.Cancel = true;
                    Toast.show(this, "나도 가수다", "이미 다운로드중입니다!.", ToastType.ERROR, ToastDuration.SHORT);
                    return;
                }

                e.Cancel = true;
                string webUrl = e.Url.ToString().Trim();
                //webBrowser1.Stop();

                String fileName = String.Format("C:\\나도가수다 보관함\\{0}", System.IO.Path.GetFileName(webUrl));

                // 폴더가 존재하지 않는다면 폴더를 생성한다.
                if (!System.IO.Directory.Exists("C:\\나도가수다 보관함"))
                    System.IO.Directory.CreateDirectory("C:\\나도가수다 보관함");

                try
                {
                    downfileUrl = fileName;
                    //다운로드중임을 표시한다.
                    nowDownloading = true;
                    // C 드라이브 밑의 downloadFiles 폴더에 파일 이름대로 저장한다.
                    wc.DownloadFileAsync(new Uri(webUrl), fileName);

                    Toast.show(this, "나도 가수다", System.IO.Path.GetFileName(downfileUrl) + " 다운로드가 시작되었습니다.", ToastType.INFO, ToastDuration.SHORT);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

               // webBrowser1.GoBack();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //https://stackoverflow.com/questions/19385840/auto-login-on-webbrowser-control
            //웹브라우저 컨트롤해서 자동로그인
            if (is_sec_page == false && CheckLogin == true)
            {
                HtmlDocument doc = webBrowser1.Document;
                HtmlElement id = doc.GetElementById("id");
                HtmlElement password = doc.GetElementById("Password");
                HtmlElement submit = doc.GetElementById("subLogin");
                id.SetAttribute("value", LoginId);
                password.SetAttribute("value", LoginPassword);
                submit.InvokeMember("click");
                is_sec_page = true;
            }
        }

        void fileDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            nowDownloading = false;

            if (btnPlay.Enabled == false || btnPrevious.Enabled == false || btnNext.Enabled == false)
            {
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnPlay.Enabled = true;

                form_Mini.btnMiniPrevious.Enabled = true;
                form_Mini.btnMiniNext.Enabled = true;
                form_Mini.btnMiniPlay.Enabled = true;
            }

            try
            {
                Load_Mp3Info(downfileUrl, lvMusic);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ExtensionClass.shuffleIndex(randomList, lvMusic);
            ExtensionClass.shuffle(randomList);

            Toast.show(this, "나도 가수다", System.IO.Path.GetFileName(downfileUrl) + "의 다운로드가 완료되었습니다.", ToastType.INFO, ToastDuration.SHORT);
            //MessageBox.Show("파일 다운로드 완료!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnWebBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void btnWebForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btnWebRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btnWebHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://file-examples.com/index.php/sample-audio-files/sample-mp3-download/");
        }

        #endregion

        //이벤트 체크를 위한 빈 버튼
        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("나도가수다 를 종료하시겠습니까?", "나도가수다", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                if (lvMusic.Items.Count > 0)
                {
                    SaveXml();
                }
                else if (lvMusic.Items.Count == 0)
                {
                    if (File.Exists(gStrXmlFilePath))
                    {
                        File.Delete(gStrXmlFilePath);
                    }
                }
                CleanUp();
            }
        }

    }

    public static class ExtensionClass
    {
        public static void listView_No(ListView LV)
        {
            // 번호 매기기
            for (int i = 0; i < LV.Items.Count; i++)
            {
                //LV.Items[i].Text = (i + 1).ToString();  // 첫번째 칼럼
                LV.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
            //LV.Columns[1].Width = -2; //Text Column Header 셀 자동 크기
            //SetHeight(LV, 20);
        }

        public static void shuffleIndex(this List<int> musicList, ListView listView)
        {
            musicList.Clear();

            for (int i = 0; i < listView.Items.Count; i++)
            {
                musicList.Add(i);
            }
        }

        public static void shuffle<T>(this IList<T> musicList)
        {
            Random rng = new Random();
            int n = musicList.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = musicList[k];
                musicList[k] = musicList[n];
                musicList[n] = value;
            }
        }
    }
}
