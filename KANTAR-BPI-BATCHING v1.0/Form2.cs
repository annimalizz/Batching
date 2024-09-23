using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace KANTAR_BPI_BATCHING_v1._0
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        public static string User_Name { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            ConnectDB connectDB = new ConnectDB();
            string username = usernameTextbox.Text;
            string password = password_Txtfld.Text;
            if (username == "")
            {
                MessageBox.Show("Username is Empty", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(password ==""){
                MessageBox.Show("Password is Empty", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);   
            }
            else
            {
                connectDB.Connect();
                if (connectDB.isUserExist(username, password))
                {
                    Form1 form1 = new Form1();
                    User_Name = username;
                    this.Hide();
                    connectDB.DisconnectDb();
                    form1.Show();
                }
                else
                {
                    Form3 form3 = new Form3();
                    form3.ShowDialog();;
                }

                connectDB.DisconnectDb();
            }
            

        }

     

        private void shw_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (shw_pass.Checked)
            {
                password_Txtfld.UseSystemPasswordChar = false;
            }
            else
            {
                password_Txtfld.UseSystemPasswordChar=true;
            }

        }

        private void password_Txtfld_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_Txtfld_KeyDown(object sender, KeyEventArgs e)
        {
            ConnectDB connectDB = new ConnectDB();
            
            if (e.KeyCode == Keys.Enter)
            {              
                string username = usernameTextbox.Text;
                string password = password_Txtfld.Text;
                if (username == "")
                {
                    MessageBox.Show("Username is Empty", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (password == "")
                {
                    MessageBox.Show("Password is Empty", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    connectDB.Connect();
                    if (connectDB.isUserExist(username, password)) 
                    {
                        Form1 form1 = new Form1();
                        User_Name = username;
                        this.Hide();
                        connectDB.DisconnectDb();
                        form1.Show();
                    }
                    else
                    {
                        Form3 form3 = new Form3();
                        this.Hide();
                        form3.Show();
                    }

                    connectDB.DisconnectDb();
                }
            }

        }

        private void usernameTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                e.Handled = true;
                password_Txtfld.Focus();
            }
            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.SuppressKeyPress = true;
                password_Txtfld.Focus();
            }
        }

        private void password_Txtfld_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                e.Handled = true;
                usernameTextbox.Focus();
            }
        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
