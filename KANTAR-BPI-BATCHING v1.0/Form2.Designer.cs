namespace KANTAR_BPI_BATCHING_v1._0
{
    partial class Form2
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
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password_Txtfld = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.shw_pass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Login";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.usernameTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameTextbox.Location = new System.Drawing.Point(30, 103);
            this.usernameTextbox.MaxLength = 4;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(183, 32);
            this.usernameTextbox.TabIndex = 2;
            this.usernameTextbox.TextChanged += new System.EventHandler(this.usernameTextbox_TextChanged);
            this.usernameTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTextbox_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // password_Txtfld
            // 
            this.password_Txtfld.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.password_Txtfld.Location = new System.Drawing.Point(30, 176);
            this.password_Txtfld.MaxLength = 4;
            this.password_Txtfld.Name = "password_Txtfld";
            this.password_Txtfld.Size = new System.Drawing.Size(183, 32);
            this.password_Txtfld.TabIndex = 4;
            this.password_Txtfld.UseSystemPasswordChar = true;
            this.password_Txtfld.TextChanged += new System.EventHandler(this.password_Txtfld_TextChanged);
            this.password_Txtfld.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_Txtfld_KeyDown);
            this.password_Txtfld.KeyUp += new System.Windows.Forms.KeyEventHandler(this.password_Txtfld_KeyUp);
            // 
            // login_btn
            // 
            this.login_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.login_btn.Location = new System.Drawing.Point(81, 261);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(84, 39);
            this.login_btn.TabIndex = 5;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // shw_pass
            // 
            this.shw_pass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.shw_pass.AutoSize = true;
            this.shw_pass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shw_pass.Location = new System.Drawing.Point(30, 224);
            this.shw_pass.Name = "shw_pass";
            this.shw_pass.Size = new System.Drawing.Size(135, 22);
            this.shw_pass.TabIndex = 6;
            this.shw_pass.Text = "show password";
            this.shw_pass.UseVisualStyleBackColor = true;
            this.shw_pass.CheckedChanged += new System.EventHandler(this.shw_pass_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(271, 322);
            this.Controls.Add(this.shw_pass);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.password_Txtfld);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Login";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password_Txtfld;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.CheckBox shw_pass;
        public System.Windows.Forms.TextBox usernameTextbox;
    }
}