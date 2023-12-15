namespace ClientGUI_v3.UI
{
    partial class UserUI
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
            this.btnListUsers = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnSetUser = new System.Windows.Forms.Button();
            this.btnListDatabases = new System.Windows.Forms.Button();
            this.btnGetCurrentUser = new System.Windows.Forms.Button();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrentUser = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListUsers
            // 
            this.btnListUsers.Location = new System.Drawing.Point(6, 80);
            this.btnListUsers.Name = "btnListUsers";
            this.btnListUsers.Size = new System.Drawing.Size(86, 52);
            this.btnListUsers.TabIndex = 1;
            this.btnListUsers.Text = "List Users";
            this.btnListUsers.UseVisualStyleBackColor = true;
            this.btnListUsers.Click += new System.EventHandler(this.btnListUsers_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(290, 80);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(80, 52);
            this.btnCreateUser.TabIndex = 2;
            this.btnCreateUser.Text = "Create New User";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateNewUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "User";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(98, 22);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(100, 23);
            this.tbUser.TabIndex = 4;
            this.tbUser.Text = "b_dev1";
            this.tbUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnExist);
            this.groupBox1.Controls.Add(this.btnSetUser);
            this.groupBox1.Controls.Add(this.btnListDatabases);
            this.groupBox1.Controls.Add(this.btnGetCurrentUser);
            this.groupBox1.Controls.Add(this.rtbConsole);
            this.groupBox1.Controls.Add(this.btnListUsers);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCurrentUser);
            this.groupBox1.Controls.Add(this.btnCreateUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbUser);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 452);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(321, 420);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(49, 26);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExist
            // 
            this.btnExist.Location = new System.Drawing.Point(290, 25);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(80, 52);
            this.btnExist.TabIndex = 9;
            this.btnExist.Text = "Exist";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // btnSetUser
            // 
            this.btnSetUser.Location = new System.Drawing.Point(204, 25);
            this.btnSetUser.Name = "btnSetUser";
            this.btnSetUser.Size = new System.Drawing.Size(80, 52);
            this.btnSetUser.TabIndex = 8;
            this.btnSetUser.Text = "Set User";
            this.btnSetUser.UseVisualStyleBackColor = true;
            this.btnSetUser.Click += new System.EventHandler(this.btnSetUser_Click);
            // 
            // btnListDatabases
            // 
            this.btnListDatabases.Location = new System.Drawing.Point(98, 80);
            this.btnListDatabases.Name = "btnListDatabases";
            this.btnListDatabases.Size = new System.Drawing.Size(100, 52);
            this.btnListDatabases.TabIndex = 6;
            this.btnListDatabases.Text = "List Databases";
            this.btnListDatabases.UseVisualStyleBackColor = true;
            this.btnListDatabases.Click += new System.EventHandler(this.btnListDatabases_Click);
            // 
            // btnGetCurrentUser
            // 
            this.btnGetCurrentUser.Location = new System.Drawing.Point(204, 80);
            this.btnGetCurrentUser.Name = "btnGetCurrentUser";
            this.btnGetCurrentUser.Size = new System.Drawing.Size(80, 52);
            this.btnGetCurrentUser.TabIndex = 7;
            this.btnGetCurrentUser.Text = "Get Current User";
            this.btnGetCurrentUser.UseVisualStyleBackColor = true;
            this.btnGetCurrentUser.Click += new System.EventHandler(this.btnGetCurrentUser_Click);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Location = new System.Drawing.Point(6, 138);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(364, 308);
            this.rtbConsole.TabIndex = 7;
            this.rtbConsole.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current User";
            // 
            // tbCurrentUser
            // 
            this.tbCurrentUser.Enabled = false;
            this.tbCurrentUser.Location = new System.Drawing.Point(98, 51);
            this.tbCurrentUser.Name = "tbCurrentUser";
            this.tbCurrentUser.Size = new System.Drawing.Size(100, 23);
            this.tbCurrentUser.TabIndex = 5;
            this.tbCurrentUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UserUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 476);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserUI";
            this.Text = "UserUI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnListUsers;
        private Button btnCreateUser;
        private Label label1;
        private TextBox tbUser;
        private GroupBox groupBox1;
        private RichTextBox rtbConsole;
        private Label label2;
        private TextBox tbCurrentUser;
        private Button btnListDatabases;
        private Button btnGetCurrentUser;
        private Button btnSetUser;
        private Button btnExist;
        private Button btnDelete;
    }
}