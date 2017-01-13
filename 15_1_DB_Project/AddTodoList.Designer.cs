namespace _15_1_DB_Project
{
    partial class AddTodoList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_subject = new System.Windows.Forms.TextBox();
            this.button_addTodoListItem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "일정 주제";
            // 
            // textBox_subject
            // 
            this.textBox_subject.Location = new System.Drawing.Point(75, 12);
            this.textBox_subject.Name = "textBox_subject";
            this.textBox_subject.Size = new System.Drawing.Size(336, 21);
            this.textBox_subject.TabIndex = 1;
            // 
            // button_addTodoListItem
            // 
            this.button_addTodoListItem.Location = new System.Drawing.Point(336, 81);
            this.button_addTodoListItem.Name = "button_addTodoListItem";
            this.button_addTodoListItem.Size = new System.Drawing.Size(75, 23);
            this.button_addTodoListItem.TabIndex = 2;
            this.button_addTodoListItem.Text = "추가";
            this.button_addTodoListItem.UseVisualStyleBackColor = true;
            this.button_addTodoListItem.Click += new System.EventHandler(this.button_addTodoListItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "일정 내용";
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(14, 51);
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(397, 21);
            this.textBox_content.TabIndex = 1;
            // 
            // AddTodoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 116);
            this.Controls.Add(this.button_addTodoListItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_content);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_subject);
            this.Name = "AddTodoList";
            this.Text = "AddTodoList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_subject;
        private System.Windows.Forms.Button button_addTodoListItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_content;
    }
}