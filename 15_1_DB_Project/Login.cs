using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15_1_DB_Project
{
    public partial class Login : Form
    {
        private Main mainForm;
        private bool connectionFlag;
        private bool loginFlag;

        public Login(Main mainForm)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox_nameToLogin.MaxLength = 20;
            textBox_passwordToLogin.MaxLength = 20;
            textBox_passwordToLogin.PasswordChar = '*';

            try
            {
                this.mainForm = mainForm;
                connectionFlag = false;
                loginFlag = false;

                if (!Main.sqlManager.initMySQL())
                {
                    MessageBox.Show("Failed to connect to database server.");

                    Application.Exit();
                }
                else
                {
                    connectionFlag = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (textBox_nameToLogin.Text == "")
            {
                MessageBox.Show("이름을 입력하세요!");
            }
            else if (textBox_passwordToLogin.Text == "")
            {
                MessageBox.Show("비밀번호를 입력하세요!");
            }
            else
            {
                int userID = Main.sqlManager.loginNameCheck(textBox_nameToLogin.Text, textBox_passwordToLogin.Text);
                if (userID == 0 || userID == -1)
                {
                    MessageBox.Show("로그인에 실패하였습니다!\n이름이 없거나 비밀번호가 틀립니다.");
                }
                else
                {
                    loginFlag = true;

                    mainForm.userName = textBox_nameToLogin.Text;
                    mainForm.userID = userID;

                    this.Close();
                }
            }
        }

        private void button_join_Click(object sender, EventArgs e)
        {
            JoinMember joinMember = new JoinMember(this);
            joinMember.ShowDialog();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connectionFlag == false || loginFlag == false)
                Application.Exit();
        }
    }
}
