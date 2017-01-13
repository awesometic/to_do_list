namespace _15_1_DB_Project
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.groupBox_userInfo = new System.Windows.Forms.GroupBox();
            this.label_today = new System.Windows.Forms.Label();
            this.label_busyRank = new System.Windows.Forms.Label();
            this.label_monthFinishRate = new System.Windows.Forms.Label();
            this.label_weekFinishRate = new System.Windows.Forms.Label();
            this.label_totalFinishRate = new System.Windows.Forms.Label();
            this.label_undoneTodolistsCount = new System.Windows.Forms.Label();
            this.label_leftTodolistsCount = new System.Windows.Forms.Label();
            this.label_finishedTodolistsCount = new System.Windows.Forms.Label();
            this.label_totalTodolistsCount = new System.Windows.Forms.Label();
            this.label_userName = new System.Windows.Forms.Label();
            this.groupBox_search = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_searchHelp = new System.Windows.Forms.Label();
            this.textBox_searchLastDate = new System.Windows.Forms.TextBox();
            this.textBox_searchFirstDate = new System.Windows.Forms.TextBox();
            this.label_searchLastDate = new System.Windows.Forms.Label();
            this.label_searchStartDate = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_memoSearch = new System.Windows.Forms.TextBox();
            this.textBox_subjectSearch = new System.Windows.Forms.TextBox();
            this.label_memoContent = new System.Windows.Forms.Label();
            this.label_subject = new System.Windows.Forms.Label();
            this.comboBox_day = new System.Windows.Forms.ComboBox();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.groupBox_memo = new System.Windows.Forms.GroupBox();
            this.label_saveMemoDate = new System.Windows.Forms.Label();
            this.button_saveMemo = new System.Windows.Forms.Button();
            this.textBox_showMemo = new System.Windows.Forms.TextBox();
            this.button_deleteTodoList = new System.Windows.Forms.Button();
            this.button_addTodoList = new System.Windows.Forms.Button();
            this.button_showMyAllTodoList = new System.Windows.Forms.Button();
            this.listView_todoList = new System.Windows.Forms.ListView();
            this.button_complete = new System.Windows.Forms.Button();
            this.button_leftTodoLists = new System.Windows.Forms.Button();
            this.button_thisMonth = new System.Windows.Forms.Button();
            this.button_thisWeek = new System.Windows.Forms.Button();
            this.groupBox_userInfo.SuspendLayout();
            this.groupBox_search.SuspendLayout();
            this.groupBox_memo.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.monthCalendar.Location = new System.Drawing.Point(563, 12);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowWeekNumbers = true;
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // groupBox_userInfo
            // 
            this.groupBox_userInfo.Controls.Add(this.label_today);
            this.groupBox_userInfo.Controls.Add(this.label_busyRank);
            this.groupBox_userInfo.Controls.Add(this.label_monthFinishRate);
            this.groupBox_userInfo.Controls.Add(this.label_weekFinishRate);
            this.groupBox_userInfo.Controls.Add(this.label_totalFinishRate);
            this.groupBox_userInfo.Controls.Add(this.label_undoneTodolistsCount);
            this.groupBox_userInfo.Controls.Add(this.label_leftTodolistsCount);
            this.groupBox_userInfo.Controls.Add(this.label_finishedTodolistsCount);
            this.groupBox_userInfo.Controls.Add(this.label_totalTodolistsCount);
            this.groupBox_userInfo.Controls.Add(this.label_userName);
            this.groupBox_userInfo.Location = new System.Drawing.Point(644, 323);
            this.groupBox_userInfo.Name = "groupBox_userInfo";
            this.groupBox_userInfo.Size = new System.Drawing.Size(381, 136);
            this.groupBox_userInfo.TabIndex = 1;
            this.groupBox_userInfo.TabStop = false;
            this.groupBox_userInfo.Text = "사용자 정보";
            // 
            // label_today
            // 
            this.label_today.AutoSize = true;
            this.label_today.Location = new System.Drawing.Point(184, 41);
            this.label_today.Name = "label_today";
            this.label_today.Size = new System.Drawing.Size(51, 12);
            this.label_today.TabIndex = 3;
            this.label_today.Text = "오늘은? ";
            // 
            // label_busyRank
            // 
            this.label_busyRank.AutoSize = true;
            this.label_busyRank.Location = new System.Drawing.Point(184, 22);
            this.label_busyRank.Name = "label_busyRank";
            this.label_busyRank.Size = new System.Drawing.Size(65, 12);
            this.label_busyRank.TabIndex = 2;
            this.label_busyRank.Text = "바쁜 순위: ";
            // 
            // label_monthFinishRate
            // 
            this.label_monthFinishRate.AutoSize = true;
            this.label_monthFinishRate.Location = new System.Drawing.Point(184, 83);
            this.label_monthFinishRate.Name = "label_monthFinishRate";
            this.label_monthFinishRate.Size = new System.Drawing.Size(121, 12);
            this.label_monthFinishRate.TabIndex = 1;
            this.label_monthFinishRate.Text = "지난 한 달 완료율   : ";
            // 
            // label_weekFinishRate
            // 
            this.label_weekFinishRate.AutoSize = true;
            this.label_weekFinishRate.Location = new System.Drawing.Point(184, 62);
            this.label_weekFinishRate.Name = "label_weekFinishRate";
            this.label_weekFinishRate.Size = new System.Drawing.Size(121, 12);
            this.label_weekFinishRate.TabIndex = 1;
            this.label_weekFinishRate.Text = "지난 일주일 완료율 : ";
            // 
            // label_totalFinishRate
            // 
            this.label_totalFinishRate.AutoSize = true;
            this.label_totalFinishRate.Location = new System.Drawing.Point(184, 104);
            this.label_totalFinishRate.Name = "label_totalFinishRate";
            this.label_totalFinishRate.Size = new System.Drawing.Size(121, 12);
            this.label_totalFinishRate.TabIndex = 1;
            this.label_totalFinishRate.Text = "총 일정 완료율       : ";
            // 
            // label_undoneTodolistsCount
            // 
            this.label_undoneTodolistsCount.AutoSize = true;
            this.label_undoneTodolistsCount.Location = new System.Drawing.Point(8, 104);
            this.label_undoneTodolistsCount.Name = "label_undoneTodolistsCount";
            this.label_undoneTodolistsCount.Size = new System.Drawing.Size(97, 12);
            this.label_undoneTodolistsCount.TabIndex = 0;
            this.label_undoneTodolistsCount.Text = "못한 일정 수    : ";
            // 
            // label_leftTodolistsCount
            // 
            this.label_leftTodolistsCount.AutoSize = true;
            this.label_leftTodolistsCount.Location = new System.Drawing.Point(8, 83);
            this.label_leftTodolistsCount.Name = "label_leftTodolistsCount";
            this.label_leftTodolistsCount.Size = new System.Drawing.Size(97, 12);
            this.label_leftTodolistsCount.TabIndex = 0;
            this.label_leftTodolistsCount.Text = "남은 일정 수    : ";
            // 
            // label_finishedTodolistsCount
            // 
            this.label_finishedTodolistsCount.AutoSize = true;
            this.label_finishedTodolistsCount.Location = new System.Drawing.Point(8, 62);
            this.label_finishedTodolistsCount.Name = "label_finishedTodolistsCount";
            this.label_finishedTodolistsCount.Size = new System.Drawing.Size(97, 12);
            this.label_finishedTodolistsCount.TabIndex = 0;
            this.label_finishedTodolistsCount.Text = "완료한 일정 수 : ";
            // 
            // label_totalTodolistsCount
            // 
            this.label_totalTodolistsCount.AutoSize = true;
            this.label_totalTodolistsCount.Location = new System.Drawing.Point(8, 41);
            this.label_totalTodolistsCount.Name = "label_totalTodolistsCount";
            this.label_totalTodolistsCount.Size = new System.Drawing.Size(97, 12);
            this.label_totalTodolistsCount.TabIndex = 0;
            this.label_totalTodolistsCount.Text = "총 일정 수       : ";
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_userName.Location = new System.Drawing.Point(8, 17);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(97, 12);
            this.label_userName.TabIndex = 0;
            this.label_userName.Text = "이름               : ";
            // 
            // groupBox_search
            // 
            this.groupBox_search.Controls.Add(this.label1);
            this.groupBox_search.Controls.Add(this.label_searchHelp);
            this.groupBox_search.Controls.Add(this.textBox_searchLastDate);
            this.groupBox_search.Controls.Add(this.textBox_searchFirstDate);
            this.groupBox_search.Controls.Add(this.label_searchLastDate);
            this.groupBox_search.Controls.Add(this.label_searchStartDate);
            this.groupBox_search.Controls.Add(this.button_search);
            this.groupBox_search.Controls.Add(this.textBox_memoSearch);
            this.groupBox_search.Controls.Add(this.textBox_subjectSearch);
            this.groupBox_search.Controls.Add(this.label_memoContent);
            this.groupBox_search.Controls.Add(this.label_subject);
            this.groupBox_search.Controls.Add(this.comboBox_day);
            this.groupBox_search.Controls.Add(this.comboBox_month);
            this.groupBox_search.Location = new System.Drawing.Point(791, 12);
            this.groupBox_search.Name = "groupBox_search";
            this.groupBox_search.Size = new System.Drawing.Size(234, 162);
            this.groupBox_search.TabIndex = 1;
            this.groupBox_search.TabStop = false;
            this.groupBox_search.Text = "검색";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "날짜 선택:";
            // 
            // label_searchHelp
            // 
            this.label_searchHelp.AutoSize = true;
            this.label_searchHelp.Location = new System.Drawing.Point(6, 138);
            this.label_searchHelp.Name = "label_searchHelp";
            this.label_searchHelp.Size = new System.Drawing.Size(137, 12);
            this.label_searchHelp.TabIndex = 7;
            this.label_searchHelp.Text = "모든 조합이 가능합니다.";
            // 
            // textBox_searchLastDate
            // 
            this.textBox_searchLastDate.Location = new System.Drawing.Point(128, 106);
            this.textBox_searchLastDate.Name = "textBox_searchLastDate";
            this.textBox_searchLastDate.Size = new System.Drawing.Size(100, 21);
            this.textBox_searchLastDate.TabIndex = 6;
            this.textBox_searchLastDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_searchLastDate_KeyPress);
            // 
            // textBox_searchFirstDate
            // 
            this.textBox_searchFirstDate.Location = new System.Drawing.Point(128, 67);
            this.textBox_searchFirstDate.Name = "textBox_searchFirstDate";
            this.textBox_searchFirstDate.Size = new System.Drawing.Size(100, 21);
            this.textBox_searchFirstDate.TabIndex = 5;
            this.textBox_searchFirstDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_searchFirstDate_KeyPress);
            // 
            // label_searchLastDate
            // 
            this.label_searchLastDate.AutoSize = true;
            this.label_searchLastDate.Location = new System.Drawing.Point(126, 91);
            this.label_searchLastDate.Name = "label_searchLastDate";
            this.label_searchLastDate.Size = new System.Drawing.Size(41, 12);
            this.label_searchLastDate.TabIndex = 4;
            this.label_searchLastDate.Text = "종료일";
            // 
            // label_searchStartDate
            // 
            this.label_searchStartDate.AutoSize = true;
            this.label_searchStartDate.Location = new System.Drawing.Point(126, 52);
            this.label_searchStartDate.Name = "label_searchStartDate";
            this.label_searchStartDate.Size = new System.Drawing.Size(41, 12);
            this.label_searchStartDate.TabIndex = 4;
            this.label_searchStartDate.Text = "시작일";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(153, 133);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 3;
            this.button_search.Text = "검색";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_memoSearch
            // 
            this.textBox_memoSearch.Location = new System.Drawing.Point(8, 106);
            this.textBox_memoSearch.Name = "textBox_memoSearch";
            this.textBox_memoSearch.Size = new System.Drawing.Size(114, 21);
            this.textBox_memoSearch.TabIndex = 2;
            this.textBox_memoSearch.Click += new System.EventHandler(this.textBox_memoSearch_Click);
            // 
            // textBox_subjectSearch
            // 
            this.textBox_subjectSearch.Location = new System.Drawing.Point(8, 67);
            this.textBox_subjectSearch.Name = "textBox_subjectSearch";
            this.textBox_subjectSearch.Size = new System.Drawing.Size(114, 21);
            this.textBox_subjectSearch.TabIndex = 2;
            this.textBox_subjectSearch.Click += new System.EventHandler(this.textBox_subjectSearch_Click);
            // 
            // label_memoContent
            // 
            this.label_memoContent.AutoSize = true;
            this.label_memoContent.Location = new System.Drawing.Point(6, 91);
            this.label_memoContent.Name = "label_memoContent";
            this.label_memoContent.Size = new System.Drawing.Size(57, 12);
            this.label_memoContent.TabIndex = 1;
            this.label_memoContent.Text = "메모 내용";
            // 
            // label_subject
            // 
            this.label_subject.AutoSize = true;
            this.label_subject.Location = new System.Drawing.Point(6, 52);
            this.label_subject.Name = "label_subject";
            this.label_subject.Size = new System.Drawing.Size(57, 12);
            this.label_subject.TabIndex = 1;
            this.label_subject.Text = "일정 주제";
            // 
            // comboBox_day
            // 
            this.comboBox_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_day.FormattingEnabled = true;
            this.comboBox_day.Location = new System.Drawing.Point(119, 14);
            this.comboBox_day.Name = "comboBox_day";
            this.comboBox_day.Size = new System.Drawing.Size(40, 20);
            this.comboBox_day.TabIndex = 0;
            this.comboBox_day.SelectedIndexChanged += new System.EventHandler(this.comboBox_day_SelectedIndexChanged);
            // 
            // comboBox_month
            // 
            this.comboBox_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Location = new System.Drawing.Point(73, 14);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(40, 20);
            this.comboBox_month.TabIndex = 0;
            this.comboBox_month.SelectedIndexChanged += new System.EventHandler(this.comboBox_month_SelectedIndexChanged);
            // 
            // groupBox_memo
            // 
            this.groupBox_memo.Controls.Add(this.label_saveMemoDate);
            this.groupBox_memo.Controls.Add(this.button_saveMemo);
            this.groupBox_memo.Controls.Add(this.textBox_showMemo);
            this.groupBox_memo.Location = new System.Drawing.Point(563, 180);
            this.groupBox_memo.Name = "groupBox_memo";
            this.groupBox_memo.Size = new System.Drawing.Size(462, 137);
            this.groupBox_memo.TabIndex = 1;
            this.groupBox_memo.TabStop = false;
            this.groupBox_memo.Text = "메모";
            // 
            // label_saveMemoDate
            // 
            this.label_saveMemoDate.AutoSize = true;
            this.label_saveMemoDate.Location = new System.Drawing.Point(8, 113);
            this.label_saveMemoDate.Name = "label_saveMemoDate";
            this.label_saveMemoDate.Size = new System.Drawing.Size(133, 12);
            this.label_saveMemoDate.TabIndex = 2;
            this.label_saveMemoDate.Text = "마지막 메모 저장 날짜: ";
            // 
            // button_saveMemo
            // 
            this.button_saveMemo.Location = new System.Drawing.Point(381, 108);
            this.button_saveMemo.Name = "button_saveMemo";
            this.button_saveMemo.Size = new System.Drawing.Size(75, 23);
            this.button_saveMemo.TabIndex = 1;
            this.button_saveMemo.Text = "저장";
            this.button_saveMemo.UseVisualStyleBackColor = true;
            this.button_saveMemo.Click += new System.EventHandler(this.button_saveMemo_Click);
            // 
            // textBox_showMemo
            // 
            this.textBox_showMemo.Location = new System.Drawing.Point(6, 20);
            this.textBox_showMemo.Multiline = true;
            this.textBox_showMemo.Name = "textBox_showMemo";
            this.textBox_showMemo.Size = new System.Drawing.Size(450, 82);
            this.textBox_showMemo.TabIndex = 0;
            // 
            // button_deleteTodoList
            // 
            this.button_deleteTodoList.Location = new System.Drawing.Point(12, 436);
            this.button_deleteTodoList.Name = "button_deleteTodoList";
            this.button_deleteTodoList.Size = new System.Drawing.Size(50, 23);
            this.button_deleteTodoList.TabIndex = 3;
            this.button_deleteTodoList.Text = "삭제";
            this.button_deleteTodoList.UseVisualStyleBackColor = true;
            this.button_deleteTodoList.Click += new System.EventHandler(this.button_deleteTodoList_Click);
            // 
            // button_addTodoList
            // 
            this.button_addTodoList.Location = new System.Drawing.Point(401, 436);
            this.button_addTodoList.Name = "button_addTodoList";
            this.button_addTodoList.Size = new System.Drawing.Size(75, 23);
            this.button_addTodoList.TabIndex = 4;
            this.button_addTodoList.Text = "추가";
            this.button_addTodoList.UseVisualStyleBackColor = true;
            this.button_addTodoList.Click += new System.EventHandler(this.button_addTodoList_Click);
            // 
            // button_showMyAllTodoList
            // 
            this.button_showMyAllTodoList.Location = new System.Drawing.Point(563, 436);
            this.button_showMyAllTodoList.Name = "button_showMyAllTodoList";
            this.button_showMyAllTodoList.Size = new System.Drawing.Size(75, 23);
            this.button_showMyAllTodoList.TabIndex = 5;
            this.button_showMyAllTodoList.Text = "모든 일정";
            this.button_showMyAllTodoList.UseVisualStyleBackColor = true;
            this.button_showMyAllTodoList.Click += new System.EventHandler(this.button_showAllMyTodoList_Click);
            // 
            // listView_todoList
            // 
            this.listView_todoList.Location = new System.Drawing.Point(12, 12);
            this.listView_todoList.MultiSelect = false;
            this.listView_todoList.Name = "listView_todoList";
            this.listView_todoList.Size = new System.Drawing.Size(545, 418);
            this.listView_todoList.TabIndex = 6;
            this.listView_todoList.UseCompatibleStateImageBehavior = false;
            this.listView_todoList.View = System.Windows.Forms.View.Details;
            this.listView_todoList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_todoList_ColumnWidthChanging);
            this.listView_todoList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_todoList_ItemSelectionChanged);
            // 
            // button_complete
            // 
            this.button_complete.Location = new System.Drawing.Point(482, 436);
            this.button_complete.Name = "button_complete";
            this.button_complete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_complete.Size = new System.Drawing.Size(75, 23);
            this.button_complete.TabIndex = 7;
            this.button_complete.Text = "완료";
            this.button_complete.UseVisualStyleBackColor = true;
            this.button_complete.Click += new System.EventHandler(this.button_complete_Click);
            // 
            // button_leftTodoLists
            // 
            this.button_leftTodoLists.Location = new System.Drawing.Point(563, 407);
            this.button_leftTodoLists.Name = "button_leftTodoLists";
            this.button_leftTodoLists.Size = new System.Drawing.Size(75, 23);
            this.button_leftTodoLists.TabIndex = 8;
            this.button_leftTodoLists.Text = "남은 일정";
            this.button_leftTodoLists.UseVisualStyleBackColor = true;
            this.button_leftTodoLists.Click += new System.EventHandler(this.button_leftTodoLists_Click);
            // 
            // button_thisMonth
            // 
            this.button_thisMonth.Location = new System.Drawing.Point(563, 378);
            this.button_thisMonth.Name = "button_thisMonth";
            this.button_thisMonth.Size = new System.Drawing.Size(75, 23);
            this.button_thisMonth.TabIndex = 9;
            this.button_thisMonth.Text = "이번 달";
            this.button_thisMonth.UseVisualStyleBackColor = true;
            this.button_thisMonth.Click += new System.EventHandler(this.button_thisMonth_Click);
            // 
            // button_thisWeek
            // 
            this.button_thisWeek.Location = new System.Drawing.Point(563, 349);
            this.button_thisWeek.Name = "button_thisWeek";
            this.button_thisWeek.Size = new System.Drawing.Size(75, 23);
            this.button_thisWeek.TabIndex = 9;
            this.button_thisWeek.Text = "이번 주";
            this.button_thisWeek.UseVisualStyleBackColor = true;
            this.button_thisWeek.Click += new System.EventHandler(this.button_thisWeek_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 471);
            this.Controls.Add(this.button_thisWeek);
            this.Controls.Add(this.button_thisMonth);
            this.Controls.Add(this.button_leftTodoLists);
            this.Controls.Add(this.button_complete);
            this.Controls.Add(this.listView_todoList);
            this.Controls.Add(this.button_showMyAllTodoList);
            this.Controls.Add(this.button_addTodoList);
            this.Controls.Add(this.button_deleteTodoList);
            this.Controls.Add(this.groupBox_memo);
            this.Controls.Add(this.groupBox_userInfo);
            this.Controls.Add(this.groupBox_search);
            this.Controls.Add(this.monthCalendar);
            this.Name = "Main";
            this.Text = "11050038 양덕규 데이터베이스 프로젝트 To Do List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox_userInfo.ResumeLayout(false);
            this.groupBox_userInfo.PerformLayout();
            this.groupBox_search.ResumeLayout(false);
            this.groupBox_search.PerformLayout();
            this.groupBox_memo.ResumeLayout(false);
            this.groupBox_memo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_userInfo;
        private System.Windows.Forms.GroupBox groupBox_search;
        private System.Windows.Forms.GroupBox groupBox_memo;
        private System.Windows.Forms.Label label_memoContent;
        private System.Windows.Forms.Label label_subject;
        public System.Windows.Forms.Button button_search;
        public System.Windows.Forms.MonthCalendar monthCalendar;
        public System.Windows.Forms.ComboBox comboBox_month;
        public System.Windows.Forms.ComboBox comboBox_day;
        public System.Windows.Forms.TextBox textBox_memoSearch;
        public System.Windows.Forms.TextBox textBox_subjectSearch;
        public System.Windows.Forms.TextBox textBox_showMemo;
        public System.Windows.Forms.Button button_saveMemo;
        private System.Windows.Forms.Button button_deleteTodoList;
        private System.Windows.Forms.Button button_showMyAllTodoList;
        public System.Windows.Forms.ListView listView_todoList;
        private System.Windows.Forms.Button button_complete;
        public System.Windows.Forms.Button button_addTodoList;
        private System.Windows.Forms.Label label_saveMemoDate;
        private System.Windows.Forms.Label label_userName;
        public System.Windows.Forms.Label label_undoneTodolistsCount;
        public System.Windows.Forms.Label label_leftTodolistsCount;
        public System.Windows.Forms.Label label_finishedTodolistsCount;
        public System.Windows.Forms.Label label_totalTodolistsCount;
        public System.Windows.Forms.Label label_totalFinishRate;
        public System.Windows.Forms.Label label_monthFinishRate;
        public System.Windows.Forms.Label label_weekFinishRate;
        public System.Windows.Forms.Label label_busyRank;
        public System.Windows.Forms.Label label_today;
        private System.Windows.Forms.Button button_leftTodoLists;
        private System.Windows.Forms.Button button_thisMonth;
        private System.Windows.Forms.Button button_thisWeek;
        private System.Windows.Forms.TextBox textBox_searchLastDate;
        private System.Windows.Forms.TextBox textBox_searchFirstDate;
        private System.Windows.Forms.Label label_searchStartDate;
        private System.Windows.Forms.Label label_searchLastDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_searchHelp;



    }
}

