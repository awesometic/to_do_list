using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace _15_1_DB_Project
{
    class ControlsSetup
    {
        private Main mainForm;
        private int selectMonth;
        private int selectDay;
        private List<Dictionary<string, string>> resultTable;

        public ControlsSetup(Main main)
        {
            this.mainForm = main;
        }

        public bool initUsedControls()
        {
            try
            {
                mainForm.loginTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

                initComboBox();
                initListView(null);

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }

        public bool initComboBox()
        {
            try
            {
                int numberOfDaysAtCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

                mainForm.monthCalendar.ShowWeekNumbers = true;

                mainForm.comboBox_month.DropDownStyle = ComboBoxStyle.DropDownList;
                mainForm.comboBox_day.DropDownStyle = ComboBoxStyle.DropDownList;

                for (int i = 0; i < 12; i++)
                {
                    mainForm.comboBox_month.Items.Add(i + 1);
                }

                // Main.cs 의
                // comboBox_month_SelectedIndexChanged() 이벤트와
                // comboBox_day_SelectedIndexChanged() 이벤트 발생
                mainForm.comboBox_month.SelectedIndex = DateTime.Now.Month - 1;
                mainForm.comboBox_day.SelectedIndex = DateTime.Now.Day - 1;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }

        public bool comboBoxDateSetup()
        {
            try
            {
                mainForm.comboBox_day.Items.Clear();

                for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, mainForm.comboBox_month.SelectedIndex + 1); i++)
                {
                    mainForm.comboBox_day.Items.Add(i + 1);
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }

        public bool comboBoxSetupCalendar()
        {
            try
            {
                // 올해(지금 2015년) 말곤 지원을 안 함
                DateTime selectDate = new DateTime(DateTime.Now.Year, mainForm.comboBox_month.SelectedIndex + 1, mainForm.comboBox_day.SelectedIndex + 1);
                mainForm.monthCalendar.SetDate(selectDate);
                mainForm.monthCalendar.Focus();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }

        public bool monthCalendarSetupComboBox(DateRangeEventArgs e)
        {
            try
            {
                selectMonth = e.Start.Month;
                selectDay = e.Start.Day;

                mainForm.comboBox_month.SelectedIndex = selectMonth - 1;
                comboBoxDateSetup();
                mainForm.comboBox_day.SelectedIndex = selectDay - 1;

                return true;
            }
            catch (Exception _e)
            {
                MessageBox.Show(_e.Message);

                return false;
            }
        }

        public void labelSet()
        {
            labelSetTotalTodoListsCount();
            labelSetFinishedTodoListsCount();
            labelSetLeftTodoListsCount();
            labelSetUndoneTodoListsCount();
            labelSetLastWeekFinishRate();
            labelSetLastMonthFinishRate();
            labelSetTotalFinishRate();
            labelSetBusyRank();
            labelSetToday();
        }

        public void labelSetTotalTodoListsCount()
        {
            try
            {
                string[] separator = { ":" };
                string[] tempSplitted = mainForm.label_totalTodolistsCount.Text.Split(separator, StringSplitOptions.None);
                string tempLabelText = tempSplitted[0];
                int count;
                Main.sqlManager.myCommand.CommandText = @"select count(*) from todolist "
                    + "where member_id=" + mainForm.userID
                    + ";";
                count = Convert.ToInt32(Main.sqlManager.myCommand.ExecuteScalar());
                mainForm.label_totalTodolistsCount.Text = tempLabelText + ": " + count;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return;
            }
        }

        public void labelSetFinishedTodoListsCount()
        {
            try
            {
                string[] separator = { ":" };
                string[] tempSplitted = mainForm.label_finishedTodolistsCount.Text.Split(separator, StringSplitOptions.None);
                string tempLabelText = tempSplitted[0];
                int count;
                Main.sqlManager.myCommand.CommandText = @"select count(*) from todolist "
                    + "where member_id=" + mainForm.userID
                    + " and finish=1"
                    + ";";
                count = Convert.ToInt32(Main.sqlManager.myCommand.ExecuteScalar());
                mainForm.label_finishedTodolistsCount.Text = tempLabelText + ": " + count;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return;
            }
        }

        public void labelSetLeftTodoListsCount()
        {
            try
            {
                string[] separator = { ":" };
                string[] tempSplitted = mainForm.label_leftTodolistsCount.Text.Split(separator, StringSplitOptions.None);
                string tempLabelText = tempSplitted[0];
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                int count;
                Main.sqlManager.myCommand.CommandText = @"select count(*) from todolist "
                    + "where member_id=" + mainForm.userID
                    + " and finish=0"
                    + " and date >= '" + currentDate
                    + "';";
                count = Convert.ToInt32(Main.sqlManager.myCommand.ExecuteScalar());
                mainForm.label_leftTodolistsCount.Text = tempLabelText + ": " + count;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return;
            }
        }

        public void labelSetUndoneTodoListsCount()
        {
            try
            {
                string[] separator = { ":" };
                string[] tempSplitted = mainForm.label_undoneTodolistsCount.Text.Split(separator, StringSplitOptions.None);
                string tempLabelText = tempSplitted[0];
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                int count;
                Main.sqlManager.myCommand.CommandText = @"select count(*) from todolist "
                    + "where member_id=" + mainForm.userID
                    + " and finish=0"
                    + " and date < '" + currentDate
                    + "';";
                count = Convert.ToInt32(Main.sqlManager.myCommand.ExecuteScalar());
                mainForm.label_undoneTodolistsCount.Text = tempLabelText + ": " + count;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return;
            }
        }

        public void labelSetLastWeekFinishRate()
        {
            string[] separator = { ":" };
            string[] tempSplitted = mainForm.label_weekFinishRate.Text.Split(separator, StringSplitOptions.None);
            string tempLabelText = tempSplitted[0];
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string lastOneWeekDate = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");
            int count;
            double rate = 0;

            Main.sqlManager.myCommand.CommandText = @"select count(*) from todolist "
                + "where member_id=" + mainForm.userID
                + ";";
            count = Convert.ToInt32(Main.sqlManager.myCommand.ExecuteScalar());

            if (count != 0)
            {
                Main.sqlManager.myCommand.CommandText = @"select avg(finish)*100 as lastOneWeekRate from todolist "
                    + "where member_id=" + mainForm.userID
                    + " and date between '" + lastOneWeekDate + "' and '" + currentDate + "';";
                rate = Convert.ToDouble(Main.sqlManager.myCommand.ExecuteScalar());
            }
            mainForm.label_weekFinishRate.Text = tempLabelText + ": " + rate + " %";
        }

        public void labelSetLastMonthFinishRate()
        {
            string[] separator = { ":" };
            string[] tempSplitted = mainForm.label_monthFinishRate.Text.Split(separator, StringSplitOptions.None);
            string tempLabelText = tempSplitted[0];
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string lastOneMonthDate = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            int count;
            double rate = 0;

            Main.sqlManager.myCommand.CommandText = @"select count(*) from todolist "
                + "where member_id=" + mainForm.userID
                + ";";
            count = Convert.ToInt32(Main.sqlManager.myCommand.ExecuteScalar());

            if (count != 0)
            {
                Main.sqlManager.myCommand.CommandText = @"select avg(finish)*100 as lastOneMonthRate from todolist "
                    + "where member_id=" + mainForm.userID
                    + " and date between '" + lastOneMonthDate + "' and '" + currentDate + "';";

                rate = Convert.ToDouble(Main.sqlManager.myCommand.ExecuteScalar());
            }
            mainForm.label_monthFinishRate.Text = tempLabelText + ": " + rate + " %";
        }

        public void labelSetTotalFinishRate()
        {
            string[] separator = { ":" };
            string[] tempSplitted = mainForm.label_totalFinishRate.Text.Split(separator, StringSplitOptions.None);
            string tempLabelText = tempSplitted[0];
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            int count;
            double rate = 0;

            Main.sqlManager.myCommand.CommandText = @"select count(*) from todolist "
                + "where member_id=" + mainForm.userID
                + ";";
            count = Convert.ToInt32(Main.sqlManager.myCommand.ExecuteScalar());

            if (count != 0)
            {
                Main.sqlManager.myCommand.CommandText = @"select avg(finish)*100 as totalRate from todolist "
                    + "where member_id=" + mainForm.userID
                    + ";";
                rate = Convert.ToDouble(Main.sqlManager.myCommand.ExecuteScalar());
            }
            mainForm.label_totalFinishRate.Text = tempLabelText + ": " + rate + " %";
        }

        public void labelSetBusyRank()
        {
            try
            {
                string[] separator = { ":" };
                string[] tempSplitted = mainForm.label_busyRank.Text.Split(separator, StringSplitOptions.None);
                string tempLabelText = tempSplitted[0];
                int rank = 0;

                Main.sqlManager.myCommand.CommandText = @"set @nums=0; "
                    + "select rank "
                    + "from ("
                    + "select member_id, count, @nums:=@nums+1 as rank "
                    + "from ("
                    + "select member_id, count(todolist_id) as count "
                    + "from todolist "
                    + "natural join member "
                    + "group by member_id) as membersCount "
                    + "order by count desc) as membersRank "
                    + "where member_id=" + mainForm.userID + ";";

                Main.sqlManager.myReader = Main.sqlManager.myCommand.ExecuteReader();

                while (Main.sqlManager.myReader.Read())
                {
                    rank += Convert.ToInt32(Main.sqlManager.myReader[0]);
                }

                if (rank == 0)
                {
                    mainForm.label_busyRank.Text = tempLabelText + ": 아직 일정이 없습니다";
                }
                else
                {
                    mainForm.label_busyRank.Text = tempLabelText + ": " + rank + " 위!";
                }
                Main.sqlManager.myReader.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            catch (Exception _e)
            {
                MessageBox.Show(_e.Message);
                return;
            }
        }

        public void labelSetToday()
        {
            string[] separator = { "?" };
            string[] tempSplitted = mainForm.label_today.Text.Split(separator, StringSplitOptions.None);
            string tempLabelText = tempSplitted[0];
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            int todolistCount;

            Main.sqlManager.myCommand.CommandText = @"select count(*) "
                + "from todolist "
                + "where member_id=" + mainForm.userID + " "
                + "and finish=0 "
                + "and date='" + currentDate + "';";
            todolistCount = Convert.ToInt32(Main.sqlManager.myCommand.ExecuteScalar());

            switch (todolistCount)
            {
                case 0:
                    mainForm.label_today.Text = tempLabelText + "?  잉여네요!";
                    break;
                case 1:
                case 2:
                case 3:
                    mainForm.label_today.Text = tempLabelText + "?  할 게 좀 있네요";
                    break;
                case 4:
                case 5:
                case 6:
                    mainForm.label_today.Text = tempLabelText + "?  지금 놀 때가 아닙니다";
                    break;
                default:
                    mainForm.label_today.Text = tempLabelText + "?  !!!!!";
                    break;
            }
        }

        public bool initListView(string query)
        {
            try
            {
                mainForm.listView_todoList.Columns.Clear();

                ColumnHeader listNumberColumn = new ColumnHeader();
                ColumnHeader dateColumn = new ColumnHeader();
                ColumnHeader subjectColumn = new ColumnHeader();
                ColumnHeader contentColumn = new ColumnHeader();
                ColumnHeader memoColumn = new ColumnHeader();
                ColumnHeader finishColumn = new ColumnHeader();
                listNumberColumn.Text = "#";
                listNumberColumn.TextAlign = HorizontalAlignment.Left;
                listNumberColumn.Width = 20;
                dateColumn.Text = "날짜";
                dateColumn.TextAlign = HorizontalAlignment.Center;
                dateColumn.Width = 80;
                subjectColumn.Text = "일정 주제";
                subjectColumn.TextAlign = HorizontalAlignment.Center;
                subjectColumn.Width = 100;
                contentColumn.Text = "일정 내용";
                contentColumn.TextAlign = HorizontalAlignment.Left;
                contentColumn.Width = 261;
                memoColumn.Text = "메모";
                memoColumn.TextAlign = HorizontalAlignment.Center;
                memoColumn.Width = 40;
                finishColumn.Text = "완료";
                finishColumn.TextAlign = HorizontalAlignment.Center;
                finishColumn.Width = 40;
                mainForm.listView_todoList.Columns.Add(listNumberColumn);
                mainForm.listView_todoList.Columns.Add(dateColumn);
                mainForm.listView_todoList.Columns.Add(subjectColumn);
                mainForm.listView_todoList.Columns.Add(contentColumn);
                mainForm.listView_todoList.Columns.Add(memoColumn);
                mainForm.listView_todoList.Columns.Add(finishColumn);

                mainForm.listView_todoList.View = View.Details;
                mainForm.listView_todoList.FullRowSelect = true;

                mainForm.button_addTodoList.Enabled = false;

                if (query == null)
                {
                    resultTable = Main.sqlManager.commandMySQL(@"select date, subject, content, memo_use, finish from todolist "
                        + "where member_id=" + mainForm.userID
                        + " order by date desc"
                        + ";");
                }
                else
                {
                    resultTable = Main.sqlManager.commandMySQL(query);
                }
                if (resultTable == null)
                {
                    return false;
                }
                else
                {
                    addItemToListView();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }

        public bool setupListView(string query)
        {
            try
            {
                mainForm.listView_todoList.Columns.Clear();

                ColumnHeader listNumberColumn = new ColumnHeader();
                ColumnHeader subjectColumn = new ColumnHeader();
                ColumnHeader contentColumn = new ColumnHeader();
                ColumnHeader memoColumn = new ColumnHeader();
                ColumnHeader finishColumn = new ColumnHeader();
                listNumberColumn.Text = "#";
                listNumberColumn.TextAlign = HorizontalAlignment.Left;
                listNumberColumn.Width = 20;
                subjectColumn.Text = "일정 주제";
                subjectColumn.TextAlign = HorizontalAlignment.Center;
                subjectColumn.Width = 100;
                contentColumn.Text = "일정 내용";
                contentColumn.TextAlign = HorizontalAlignment.Left;
                contentColumn.Width = 341;
                memoColumn.Text = "메모";
                memoColumn.TextAlign = HorizontalAlignment.Center;
                memoColumn.Width = 40;
                finishColumn.Text = "완료";
                finishColumn.TextAlign = HorizontalAlignment.Center;
                finishColumn.Width = 40;
                mainForm.listView_todoList.Columns.Add(listNumberColumn);
                mainForm.listView_todoList.Columns.Add(subjectColumn);
                mainForm.listView_todoList.Columns.Add(contentColumn);
                mainForm.listView_todoList.Columns.Add(memoColumn);
                mainForm.listView_todoList.Columns.Add(finishColumn);

                mainForm.listView_todoList.View = View.Details;
                mainForm.listView_todoList.FullRowSelect = true;

                mainForm.button_addTodoList.Enabled = true;

                switch (query.Substring(0, 6))
                {
                    case "select":
                        resultTable = Main.sqlManager.commandMySQL(query);
                        addItemToListView();
                        break;
                    case "insert":
                    case "delete":
                    case "update":
                        Main.sqlManager.commandMySQL(query);
                        break;
                    default:
                        MessageBox.Show("지원하지 않는 쿼리");
                        break;
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
        }

        public bool addItemToListView()
        {
            try
            {
                mainForm.listView_todoList.BeginUpdate();
                mainForm.listView_todoList.Items.Clear();

                if (resultTable == null)
                {
                    return false;
                }
                else
                {
                    int itemNumber = resultTable.Count;

                    for (int i = 0; i < itemNumber; i++)
                    {
                        int newItemIndex = mainForm.listView_todoList.Items.Count + 1;
                        ListViewItem newItem = new ListViewItem(newItemIndex.ToString());

                        for (int j = 0; j < resultTable.Count; j++)
                        {
                            foreach (KeyValuePair<string, string> temp in resultTable[j])
                            {
                                string[] tempSplitted = temp.Key.Split('+');
                                if (Int32.Parse(tempSplitted[1]) != i) continue;
                                if (temp.Key.Contains("memo_use") || temp.Key.Contains("finish"))
                                {
                                    if (temp.Key.Substring(0, 8) == "memo_use" || temp.Key.Substring(0, 6) == "finish")
                                    {
                                        if (Boolean.Parse(temp.Value) == false)
                                            newItem.SubItems.Add("");
                                        else if (Boolean.Parse(temp.Value) == true)
                                            newItem.SubItems.Add("O");
                                        else
                                            newItem.SubItems.Add("UNKNOWN");
                                    }
                                }
                                else
                                {
                                    newItem.SubItems.Add(temp.Value);
                                }
                            }
                        }
                        mainForm.listView_todoList.Items.Add(newItem);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
            finally
            {
                mainForm.listView_todoList.EndUpdate();
                mainForm.listView_todoList.Refresh();
            }
        }

        public bool addItemToListView(List<Dictionary<string, string>> table)
        {
            try
            {
                mainForm.listView_todoList.BeginUpdate();
                mainForm.listView_todoList.Items.Clear();

                if (table == null)
                {
                    return false;
                }
                else
                {
                    int itemNumber = table.Count;

                    for (int i = 0; i < itemNumber; i++)
                    {
                        int newItemIndex = mainForm.listView_todoList.Items.Count + 1;
                        ListViewItem newItem = new ListViewItem(newItemIndex.ToString());

                        for (int j = 0; j < table.Count; j++)
                        {
                            foreach (KeyValuePair<string, string> temp in table[j])
                            {
                                string[] tempSplitted = temp.Key.Split('+');
                                if (Int32.Parse(tempSplitted[1]) != i) continue;
                                if (temp.Key.Contains("memo_use") || temp.Key.Contains("finish"))
                                {
                                    if (temp.Key.Substring(0, 8) == "memo_use" || temp.Key.Substring(0, 6) == "finish")
                                    {
                                        if (Boolean.Parse(temp.Value) == false)
                                            newItem.SubItems.Add("");
                                        else if (Boolean.Parse(temp.Value) == true)
                                            newItem.SubItems.Add("O");
                                        else
                                            newItem.SubItems.Add("UNKNOWN");
                                    }
                                }
                                else
                                {
                                    newItem.SubItems.Add(temp.Value);
                                }
                            }
                        }
                        mainForm.listView_todoList.Items.Add(newItem);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                return false;
            }
            finally
            {
                mainForm.listView_todoList.EndUpdate();
                mainForm.listView_todoList.Refresh();
            }
        }
    }
}