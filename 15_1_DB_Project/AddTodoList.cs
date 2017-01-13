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
    public partial class AddTodoList : Form
    {
        Main mainForm;

        public AddTodoList(Main mainForm)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox_subject.MaxLength = 20;
            textBox_content.MaxLength = 100;
            this.mainForm = mainForm;
        }

        private void button_addTodoListItem_Click(object sender, EventArgs e)
        {
            if (textBox_subject.Text == "")
            {
                MessageBox.Show("일정 주제를 입력하세요!");
                return;
            }
            if (textBox_content.Text == "")
            {
                MessageBox.Show("일정 내용을 입력하세요!");
                return;
            }

            mainForm.subjectAddTodoList = textBox_subject.Text;
            mainForm.contentAddTodoList = textBox_content.Text;
            mainForm.isAddedAddTodoList = true;
            this.Close();
        }
    }
}
