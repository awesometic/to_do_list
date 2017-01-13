namespace _15_1_DB_Project
{
    partial class Login
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
            this.label_name = new System.Windows.Forms.Label();
            this.textBox_nameToLogin = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.textBox_passwordToLogin = new System.Windows.Forms.TextBox();
            this.button_join = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(12, 9);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(29, 12);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "이름";
            // 
            // textBox_nameToLogin
            // 
            this.textBox_nameToLogin.Location = new System.Drawing.Point(71, 6);
            this.textBox_nameToLogin.Name = "textBox_nameToLogin";
            this.textBox_nameToLogin.Size = new System.Drawing.Size(209, 21);
            this.textBox_nameToLogin.TabIndex = 1;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(12, 36);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(53, 12);
            this.label_password.TabIndex = 0;
            this.label_password.Text = "비밀번호";
            // 
            // textBox_passwordToLogin
            // 
            this.textBox_passwordToLogin.Location = new System.Drawing.Point(71, 33);
            this.textBox_passwordToLogin.Name = "textBox_passwordToLogin";
            this.textBox_passwordToLogin.Size = new System.Drawing.Size(209, 21);
            this.textBox_passwordToLogin.TabIndex = 2;
            // 
            // button_join
            // 
            this.button_join.Location = new System.Drawing.Point(12, 60);
            this.button_join.Name = "button_join";
            this.button_join.Size = new System.Drawing.Size(75, 23);
            this.button_join.TabIndex = 3;
            this.button_join.Text = "가입";
            this.button_join.UseVisualStyleBackColor = true;
            this.button_join.Click += new System.EventHandler(this.button_join_Click);
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(205, 60);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "로그인";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 90);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.button_join);
            this.Controls.Add(this.textBox_passwordToLogin);
            this.Controls.Add(this.textBox_nameToLogin);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_name);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textBox_nameToLogin;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textBox_passwordToLogin;
        private System.Windows.Forms.Button button_join;
        private System.Windows.Forms.Button button_login;
    }
}