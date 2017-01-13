using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data;
using MySql.Data.MySqlClient;

/* 11050038 양덕규 데이터베이스 프로젝트 since 15.03.24, Tues
 * 
 * Features list to add or modify
 * AddTodoList.cs 에서 주제를 몇 가지 정해 콤보박스 형식으로 사용? - 새로운 테이블 필요, 원하는 주제 추가 가능, 주제 검색 또한 콤보박스
 * 여러 사용자의 공통된 빈 시간을 알아낼 수 있도록? - 새로운 todolist에 대한 필드 필요, UI 변경, 사용자를 묶는 그룹?
 * 달력을 기본으로 제공하는 걸 쓰는 게 아니라 새로 만들어 더 직관적으로 사용? - 일정이 있는 날 표시 등을 위해 - 디게 어려움
 * 오프라인으로도 작업할 수 있게 처음 한 번만 테이블을 불러온 후 오프라인 작업, 끝날 때 업로드 또는 네트워크 불가시 다음 접속시 업로드
 * 
 * monthCalendar에서 드래그해 여러 날짜를 선택할 경우 그 안의 모든 일정을 출력하도록
 * */
namespace _15_1_DB_Project
{
    public partial class Main : Form
    {
        /* Variables are associated with preparing the program */
        public static MySQLManager sqlManager;
        private ControlsSetup setup;
        public bool initFinishFlag;

        /* Variables are associated with user information */
        public string loginTime;
        public string userName;
        public int userID;
        public string selectDate;

        /* Variables are associated with button_addTodoList_Click event method */
        /* These are even used on AddTodoList.cs and it's source codes */
        public string subjectAddTodoList;
        public string contentAddTodoList;
        public bool isAddedAddTodoList;

        /* This variable is to determine what lists will appear on listView */
        private bool searchFlag;
        private string searchCommand;

        /* User-Defined Methods */
        private string setupListViewSelectQuery()
        {
            return @"select subject, content, memo_use, finish from todolist "
                        + "where member_id=" + userID
                        + " and date='" + selectDate
                        + "';";
        }

        private int getSelectedItemID()
        {
            try
            {
                if (listView_todoList.SelectedItems.Count > 0)
                {
                    List<Dictionary<string, string>> tempTable = new List<Dictionary<string, string>>();
                    int selectedItemIndex = listView_todoList.Items.IndexOf(listView_todoList.SelectedItems[0]);
                    int selectedItemID;

                    if (listView_todoList.Columns.Count == 6) // initListView 후의 상태, Column 수가 6개(날짜 포함)
                    {
                        tempTable = sqlManager.commandMySQL(@"select todolist_id from todolist "
                            + "where subject='" + listView_todoList.Items[selectedItemIndex].SubItems[2].Text
                            + "' and content='" + listView_todoList.Items[selectedItemIndex].SubItems[3].Text
                            + "' and member_id=" + userID
                            + " and date='" + listView_todoList.Items[selectedItemIndex].SubItems[1].Text
                            + "';");
                        if (tempTable.Count > 1)
                        {
                            MessageBox.Show("작업을 수행할 수 없습니다!\n적용할 수 있는 대상이 두 개 이상 있습니다");
                            return -1;
                        }
                        selectedItemID = Int32.Parse(((Dictionary<string, string>)tempTable[0])["todolist_id+0"]);
                        if (selectedItemID == 0)
                        {
                            return -1;
                        }
                    }
                    else // setupListView 후의 상태, Column 수가 5개
                    {
                        selectDate = monthCalendar.SelectionStart.ToString("yyyy-MM-dd");

                        tempTable = sqlManager.commandMySQL(@"select todolist_id from todolist "
                            + "where list_number=" + (selectedItemIndex + 1)
                            + " and member_id=" + userID
                            + " and date='" + selectDate
                            + "';");
                        selectedItemID = Int32.Parse(((Dictionary<string, string>)tempTable[0])["todolist_id+0"]);
                        if (selectedItemID == 0)
                        {
                            return -1;
                        }
                    }
                    return selectedItemID;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return -1;
            }
        }

        private bool updateOrDelete(string mode)
        {
            try
            {
                if (listView_todoList.SelectedItems.Count > 0)
                {
                    string query;
                    int selectedItemIndex = listView_todoList.Items.IndexOf(listView_todoList.SelectedItems[0]);
                    int selectedItemID = getSelectedItemID();
                    if (selectedItemID == -1)
                    {
                        return false;
                    }

                    if (mode == "update")
                    {
                        if ((listView_todoList.Columns.Count == 6 && listView_todoList.Items[selectedItemIndex].SubItems[5].Text == "O")
                            || (listView_todoList.Columns.Count == 5 && listView_todoList.Items[selectedItemIndex].SubItems[4].Text == "O"))
                            query = @"update todolist set finish=0 where todolist_id=";
                        else
                            query = @"update todolist set finish=1 where todolist_id=";
                    }
                    else if (mode == "delete")
                    {
                        query = @"delete from todolist where todolist_id=";
                    }
                    else
                    {
                        return false;
                    }

                    sqlManager.commandMySQL(query + selectedItemID + ";");

                    if (searchFlag)
                    {
                        List<Dictionary<string, string>> tempTable = new List<Dictionary<string, string>>();

                        setup.initListView(searchCommand);
                    }
                    else
                    {
                        if (listView_todoList.Columns.Count == 6) // initListView 후의 상태, Column 수가 6개(날짜 포함)
                        {
                            setup.initListView(null);
                        }
                        else // setupListView 후의 상태, Column 수가 5개
                        {
                            setup.setupListView(setupListViewSelectQuery());
                        }
                    }
                }

                setup.labelSet();
            
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }

        /* Events */
        public Main()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;

            textBox_showMemo.MaxLength = 200;
            textBox_subjectSearch.MaxLength = 20;
            textBox_memoSearch.MaxLength = 20;
            textBox_searchFirstDate.MaxLength = 10;
            textBox_searchLastDate.MaxLength = 10;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            sqlManager = new MySQLManager();
            Login loginForm = new Login(this);
            loginForm.ShowDialog();

            setup = new ControlsSetup(this);

            initFinishFlag = setup.initUsedControls();
            if (!initFinishFlag)
            {
                MessageBox.Show("구성요소 초기화에 오류가 발생했습니다!");
                Application.Exit();
            }

            label_userName.Text += userName;
            setup.labelSet();
            
            label_saveMemoDate.Text = "마지막 메모 저장 날짜: 메모 없음";

            if (listView_todoList.Items.Count == 0)
            {
                MessageBox.Show("날짜를 선택한 후 새로운 일정을 추가하세요!");
            }
        }

        private void comboBox_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            setup.comboBoxDateSetup();
        }

        private void comboBox_day_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_subjectSearch.Text = "";
            textBox_memoSearch.Text = "";
            textBox_searchFirstDate.Text = "";
            textBox_searchLastDate.Text = "";

            if (!initFinishFlag) return;
            else
            {
                string[] separator = { ":" };
                string[] tempSplitted = label_saveMemoDate.Text.Split(separator, StringSplitOptions.None);

                setup.comboBoxSetupCalendar();
                selectDate = monthCalendar.SelectionStart.ToString("yyyy-MM-dd");
                setup.setupListView(setupListViewSelectQuery());

                label_saveMemoDate.Text = tempSplitted[0] + ": 메모 없음";
                textBox_showMemo.Text = "";
                searchFlag = false;
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            // 여기서 comboBox_day_SelectedIndexChanged 이벤트 실행 - 자연스럽게 setupListView() 호출
            setup.monthCalendarSetupComboBox(e);
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if (textBox_subjectSearch.Text == "" && textBox_memoSearch.Text == "" && textBox_searchFirstDate.Text == "" && textBox_searchLastDate.Text == "")
            {
                MessageBox.Show("검색할 문자열을 입력하세요");
                return;
            }
            else {
                List<Dictionary<string, string>> tempTable = new List<Dictionary<string, string>>();
                searchCommand = @"select todolist.date, subject, todolist.content, memo_use, finish ";

                if (textBox_searchFirstDate.Text != "" || textBox_searchLastDate.Text != "")
                {
                    if (textBox_searchFirstDate.Text == "" && textBox_searchLastDate.Text != "")
                    {
                        textBox_searchFirstDate.Text = textBox_searchLastDate.Text;
                    }
                    if (textBox_searchFirstDate.Text != "" && textBox_searchLastDate.Text == "")
                    {
                        textBox_searchLastDate.Text = textBox_searchFirstDate.Text;
                    }

                    string searchFirstDate = textBox_searchFirstDate.Text;
                    string searchLastDate = textBox_searchLastDate.Text;

                    if (searchFirstDate[4] != '-' || searchFirstDate[7] != '-' || searchLastDate[4] != '-' || searchLastDate[7] != '-')
                    {
                        MessageBox.Show("날짜의 형식이 잘못되었습니다");
                        textBox_searchFirstDate.Text = "";
                        textBox_searchLastDate.Text = "";
                        return;
                    }
                    if (DateTime.Parse(searchFirstDate + "T00:00:00.0000000").Date.DayOfYear - DateTime.Parse(searchLastDate + "T00:00:00.0000000").Date.DayOfYear > 0)
                    {
                        MessageBox.Show("날짜를 잘못 입력하셨습니다");
                        textBox_searchFirstDate.Text = "";
                        textBox_searchLastDate.Text = "";
                        return;
                    }

                    if (textBox_subjectSearch.Text != "" && textBox_memoSearch.Text == "")
                    {
                        string searchText = textBox_subjectSearch.Text;
                        searchCommand += @"from todolist"
                            + " where todolist.member_id=" + userID
                            + " and todolist.date between '" + searchFirstDate + "' and '" + searchLastDate + "'"
                            + " and todolist.subject like '%" + searchText + "%'"
                            + " group by todolist.date, subject, todolist.content"
                            + " order by todolist.date desc;";

                        setup.initListView(searchCommand);
                    }
                    else if (textBox_subjectSearch.Text == "" && textBox_memoSearch.Text != "")
                    {
                        string searchText = textBox_memoSearch.Text;
                        searchCommand += @"from todolist, memo" 
                            + " where todolist.member_id=" + userID
                            + " and todolist.date between '" + searchFirstDate + "' and '" + searchLastDate + "'"
                            + " and todolist.todolist_id=memo.todolist_id"
                            + " and memo.content like '%" + searchText + "%'"
                            + " group by todolist.date, subject, todolist.content"
                            + " order by todolist.date desc;";

                        setup.initListView(searchCommand);
                    }
                    else if (textBox_subjectSearch.Text != "" && textBox_memoSearch.Text != "")
                    {
                        string searchSubjectText = textBox_subjectSearch.Text;
                        string searchMemoText = textBox_memoSearch.Text;
                        searchCommand += @"from todolist, memo" 
                            + " where todolist.member_id=" + userID
                            + " and todolist.date between '" + searchFirstDate + "' and '" + searchLastDate + "'"
                            + " and todolist.todolist_id=memo.todolist_id"
                            + " and todolist.subject like '%" + searchSubjectText + "%'"
                            + " and memo.content like '%" + searchMemoText + "%'"
                            + " group by todolist.date, subject, todolist.content"
                            + " order by todolist.date desc;";

                        setup.initListView(searchCommand);
                    }
                    else
                    {
                        searchCommand += @"from todolist" 
                            + " where todolist.member_id=" + userID
                            + " and todolist.date between '" + searchFirstDate + "' and '" + searchLastDate + "'"
                            + " group by todolist.date, subject, todolist.content"
                            + " order by todolist.date desc;";

                        setup.initListView(searchCommand);

                    }
                }
                else
                {
                    if (textBox_subjectSearch.Text != "" && textBox_memoSearch.Text == "")
                    {
                        string searchText = textBox_subjectSearch.Text;
                        searchCommand += @"from todolist" 
                            + " where todolist.member_id=" + userID
                            + " and todolist.subject like '%" + searchText + "%'"
                            + " group by todolist.date, subject, todolist.content"
                            + " order by todolist.date desc;";

                        setup.initListView(searchCommand);
                    }
                    else if (textBox_subjectSearch.Text == "" && textBox_memoSearch.Text != "")
                    {
                        string searchText = textBox_memoSearch.Text;
                        searchCommand += @"from todolist, memo" 
                            + " where todolist.member_id=" + userID
                            + " and memo.content like '%" + searchText + "%'"
                            + " and todolist.todolist_id=memo.todolist_id"
                            + " group by todolist.date, subject, todolist.content"
                            + " order by todolist.date desc;";

                        setup.initListView(searchCommand);
                    }
                    else
                    {
                        string searchSubjectText = textBox_subjectSearch.Text;
                        string searchMemoText = textBox_memoSearch.Text;
                        searchCommand += @"from todolist, memo" 
                            + " where todolist.member_id=" + userID
                            + " and todolist.subject like '%" + searchSubjectText + "%'"
                            + " and todolist.todolist_id=memo.todolist_id"
                            + " and memo.content like '%" + searchMemoText + "%'"
                            + " group by todolist.date, subject, todolist.content"
                            + " order by todolist.date desc;";

                        setup.initListView(searchCommand);
                    }
                }
            }

            searchFlag = true;
            label_saveMemoDate.Text = "마지막 메모 저장 날짜: 메모 없음";
            textBox_showMemo.Text = "";
        }

        private void button_saveMemo_Click(object sender, EventArgs e)
        {
            string[] separator = { ":" };
            string[] tempSplitted = label_saveMemoDate.Text.Split(separator, StringSplitOptions.None);
            string tempLabelText = tempSplitted[0];

            tempSplitted[1] = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            if (listView_todoList.SelectedItems.Count > 0)
            {
                List<Dictionary<string, string>> tempTable = new List<Dictionary<string, string>>();
                int selectedItemID = getSelectedItemID();
                if (selectedItemID == -1)
                {
                    return;
                }
                else
                {
                    tempTable = sqlManager.commandMySQL(@"select count(*) from memo where todolist_id=" + selectedItemID + ";");

                    if (textBox_showMemo.Text == "")
                    {
                        sqlManager.commandMySQL(@"delete from memo where todolist_id=" + selectedItemID + ";");
                        sqlManager.commandMySQL(@"update todolist set memo_use=0 where todolist_id=" + selectedItemID + ";");

                        label_saveMemoDate.Text = tempSplitted[0] + ": 메모 없음";
                    }
                    else if (tempTable != null)
                    {
                        sqlManager.commandMySQL(@"update memo set "
                            + "date='" + tempSplitted[1] + "', content='" + textBox_showMemo.Text
                            + "' where todolist_id=" + selectedItemID + ";");

                        label_saveMemoDate.Text = tempSplitted[0] + ": " + tempSplitted[1];
                    }
                    else if (tempTable == null)
                    {
                        sqlManager.commandMySQL(@"update todolist set memo_use=1 where todolist_id=" + selectedItemID + ";");
                        sqlManager.commandMySQL(@"insert into memo ("
                            + "todolist_id, date, content"
                            + ") values (" + selectedItemID + ", '" + tempSplitted[1] + "', '" + textBox_showMemo.Text
                            + "');");

                        label_saveMemoDate.Text = tempSplitted[0] + ": " + tempSplitted[1];
                    }
                    else
                    {
                        MessageBox.Show(@"데이터베이스 memo 테이블 내에 오류가 있습니다!"
                            + "\n"
                            + "todolist_id=" + selectedItemID + " 에 대한 레코드 수: " + tempTable.Count);
                    }

                    if (searchFlag)
                    {
                        tempTable = sqlManager.commandMySQL(searchCommand);
                        setup.addItemToListView(tempTable);
                    }
                    else
                    {
                        if (listView_todoList.Columns.Count == 6) // initListView 후의 상태, Column 수가 6개(날짜 포함)
                        {
                            setup.initListView(null);
                        }
                        else // setupListView 후의 상태, Column 수가 5개
                        {
                            setup.setupListView(setupListViewSelectQuery());
                        }
                    }
                }
            }
        }

        private void textBox_subjectSearch_Click(object sender, EventArgs e)
        {
            textBox_subjectSearch.Text = "";
        }

        private void textBox_memoSearch_Click(object sender, EventArgs e)
        {
            textBox_memoSearch.Text = "";
        }

        private void button_addTodoList_Click(object sender, EventArgs e)
        {
            textBox_subjectSearch.Text = "";
            textBox_memoSearch.Text = "";
            textBox_searchFirstDate.Text = "";
            textBox_searchLastDate.Text = "";

            subjectAddTodoList = null;
            contentAddTodoList = null;
            isAddedAddTodoList = false;
            int newItemIndex = listView_todoList.Items.Count + 1;
            AddTodoList addTodoListForm = new AddTodoList(this);
            addTodoListForm.ShowDialog();

            if (isAddedAddTodoList == true)
            {
                selectDate = monthCalendar.SelectionStart.ToString("yyyy-MM-dd");

                setup.setupListView(@"insert into todolist ("
                    + "member_id, date, list_number, subject, content, memo_use, finish"
                    + ") values (" + userID + ", '" + selectDate + "', " + newItemIndex
                    + ", '" + subjectAddTodoList + "', '" + contentAddTodoList + "', " + 0 + ", " + 0 + ");");

                setup.setupListView(setupListViewSelectQuery());

                setup.labelSet();
            }
            else
            {
                return;
            }
        }

        private void button_showAllMyTodoList_Click(object sender, EventArgs e)
        {
            setup.initListView(null);

            textBox_subjectSearch.Text = "";
            textBox_memoSearch.Text = "";
            textBox_searchFirstDate.Text = "";
            textBox_searchLastDate.Text = "";
            label_saveMemoDate.Text = "마지막 메모 저장 날짜: 메모 없음";
            textBox_showMemo.Text = "";
            searchFlag = false;
        }

        private void button_leftTodoLists_Click(object sender, EventArgs e)
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            searchCommand = @"select date, subject, content, memo_use, finish from todolist "
                        + "where member_id=" + userID
                        + " and date >= '" + currentDate
                        + "' and finish=0"
                        + " order by todolist.date desc"
                        + ";";
            setup.initListView(searchCommand);

            textBox_subjectSearch.Text = "";
            textBox_memoSearch.Text = "";
            textBox_searchFirstDate.Text = "";
            textBox_searchLastDate.Text = "";
            label_saveMemoDate.Text = "마지막 메모 저장 날짜: 메모 없음";
            textBox_showMemo.Text = "";
            searchFlag = true;
        }

        private void button_thisWeek_Click(object sender, EventArgs e)
        {
            DateTime dateToday = DateTime.Today;
            string thisWeekStartDate = dateToday.AddDays(Convert.ToInt32(DayOfWeek.Sunday) - Convert.ToInt32(dateToday.DayOfWeek)).ToString("yyyy-MM-dd");
            string thisWeekLastDate = dateToday.AddDays(Convert.ToInt32(DayOfWeek.Saturday) - Convert.ToInt32(dateToday.DayOfWeek)).ToString("yyyy-MM-dd");
            searchCommand = @"select date, subject, content, memo_use, finish from todolist "
                        + "where member_id=" + userID
                        + " and date between '" + thisWeekStartDate + "' and '" + thisWeekLastDate
                        + "' order by date desc"
                        + ";";
            setup.initListView(searchCommand);

            textBox_subjectSearch.Text = "";
            textBox_memoSearch.Text = "";
            textBox_searchFirstDate.Text = thisWeekStartDate;
            textBox_searchLastDate.Text = thisWeekLastDate;
            label_saveMemoDate.Text = "마지막 메모 저장 날짜: 메모 없음";
            textBox_showMemo.Text = "";
            searchFlag = true;
        }

        private void button_thisMonth_Click(object sender, EventArgs e)
        {
            DateTime dateToday = DateTime.Today;
            string thisMonthStartDate = dateToday.AddDays(1 - dateToday.Day).ToString("yyyy-MM-dd");
            string thisMonthLastDate = dateToday.AddMonths(1).AddDays(0 - dateToday.Day).ToString("yyyy-MM-dd");
            searchCommand = @"select date, subject, content, memo_use, finish from todolist "
                        + "where member_id=" + userID
                        + " and date between '" + thisMonthStartDate + "' and '" + thisMonthLastDate
                        + "' order by date desc"
                        + ";";

            setup.initListView(searchCommand);
            textBox_subjectSearch.Text = "";
            textBox_memoSearch.Text = "";
            textBox_searchFirstDate.Text = thisMonthStartDate;
            textBox_searchLastDate.Text = thisMonthLastDate;
            label_saveMemoDate.Text = "마지막 메모 저장 날짜: 메모 없음";
            textBox_showMemo.Text = "";
            searchFlag = true;
        }

        private void button_complete_Click(object sender, EventArgs e)
        {
            updateOrDelete("update");
        }

        private void button_deleteTodoList_Click(object sender, EventArgs e)
        {
            updateOrDelete("delete");
        }

        private void listView_todoList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            string[] separator = { ":" };
            string[] tempSplitted = label_saveMemoDate.Text.Split(separator, StringSplitOptions.None);
            string tempLabelText = tempSplitted[0];
            List<Dictionary<string, string>> tempTable = new List<Dictionary<string, string>>();
            int selectedItemID = getSelectedItemID();
            if (selectedItemID == -1)
            {
                return;
            }
            else
            {
                int rowCount;
                sqlManager.myCommand.CommandText = @"select count(*) from memo where todolist_id=" + selectedItemID + ";";
                rowCount = Convert.ToInt32(sqlManager.myCommand.ExecuteScalar());

                if (rowCount == 1)
                {
                    tempTable = sqlManager.commandMySQL(@"select date, content from memo where todolist_id=" + selectedItemID + ";");

                    label_saveMemoDate.Text = tempSplitted[0] + ": " + ((Dictionary<string, string>)tempTable[0])["date+0"];
                    textBox_showMemo.Text = ((Dictionary<string, string>)tempTable[0])["content+0"];
                }
                else if (rowCount == 0)
                {
                    label_saveMemoDate.Text = tempSplitted[0] + ": 메모 없음";
                    textBox_showMemo.Text = "";
                }
                else
                {
                    label_saveMemoDate.Text = tempSplitted[0] + ": 메모 없음";
                    textBox_showMemo.Text = "";
                    MessageBox.Show(@"데이터베이스 memo 테이블 내에 오류가 있습니다!"
                        + "\n"
                        + "todolist_id=" + selectedItemID + " 에 대한 레코드 수: " + tempTable.Count);
                }
            }
        }

        private void listView_todoList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = listView_todoList.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void textBox_searchFirstDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToInt32(Keys.Back) || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox_searchLastDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToInt32(Keys.Back) || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlManager.closeMySQL();
        }
    }
}
