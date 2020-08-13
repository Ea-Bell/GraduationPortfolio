using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 나도가수다
{
    public partial class Form_Login : Form
    {
        Form_Main mainForm;
        private bool isMove = false;
        private Point fPt;

        WebPost webPost = new WebPost();

        public Form_Login(Form_Main mF)
        {
            InitializeComponent();
            mainForm = mF;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            WebPost webPost = new WebPost();

            String code = webPost.HttpLogin(txtID.Text, txtPW.Text);

            if (code == "0")
            {
                mainForm.CheckLogin = true;
                mainForm.LoginId = txtID.Text;
                mainForm.LoginPassword = txtPW.Text;

                this.Close();
            }
            else if (code == "-1")
            {
                MessageBox.Show("연결이 실패 되었습니다.");
            }
            else if (code.Equals("1"))
            {
                MessageBox.Show("아이디를 입력하세요.");
            }
            else if (code.Equals("2"))
            {
                MessageBox.Show("비밀번호를 입력하세요.");
            }
            else if (code.Equals("3"))
            {
                MessageBox.Show("아이디 또는 비밀번호를 확인해주세요.");
            }
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            Process.Start("http://" + webPost.GetIP + ":8989/webTest/View/login/index.jsp");
        }

        #region 폼이동

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
