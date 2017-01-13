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
    public partial class JoinMember : Form
    {
        public Login loginForm;

        public JoinMember(Login loginForm)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox_joinName.MaxLength = 20;
            textBox_joinPassword.MaxLength = 20;
            textBox_joinPassword.PasswordChar = '*';
            this.loginForm = loginForm;
        }

        private void button_join_Click(object sender, EventArgs e)
        {
            if (textBox_joinName.Text == "")
            {
                MessageBox.Show("이름을 입력하세요!");
            }
            else if (textBox_joinPassword.Text == "")
            {
                MessageBox.Show("비밀번호를 입력하세요!");
            }
            else
            {
                if (Main.sqlManager.joinToMySQL(textBox_joinName.Text, textBox_joinPassword.Text))
                {
                    MessageBox.Show("가입되었습니다!\n환영합니다 " + textBox_joinName.Text.ToString() + " 님!");
                    Close();
                }
                else
                {
                    MessageBox.Show("가입에 실패했습니다!\n서버와 연결이 원활하지 않을 수 있습니다.");
                }
            }
        }
    }
}
