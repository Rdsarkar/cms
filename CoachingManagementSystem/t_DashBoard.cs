using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CoachingManagementSystem
{
    public partial class t_DashBoard : Form
    {
        public t_DashBoard()
        {
            InitializeComponent();
        }
        public t_DashBoard(string Adminid)
        {
            InitializeComponent();
            lblName.Text = Adminid;
        }

        string email_Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        private void t_DashBoard_Load(object sender, EventArgs e)
        {
            lblName.Text = User.userName;
            labelName.Text = User.userName;
            lblId.Text = User.userId;
            lblPass.Text = User.u_pass;
            lblAdd.Text = User.u_address;
            lblNum.Text = User.t_Num;
            lblEmail.Text = User.t_Email;
            lblSal.Text = User.t_salary;
            lblAllow.Text = User.t_allowance;
        }

        private void Validation() 
        {
            string name = txtName.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name required");
                txtName.Focus();
                return;
            }

            string pass = txtPass.Text;

            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Password required");
                txtPass.Focus();
                return;
            }

            if (pass.Length < 8)
            {
                MessageBox.Show("minimum 8 character required");
                txtPass.Focus();
                return;
            }
            string num = txtnum.Text;

            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("Phone Number required");
                txtnum.Focus();
                return;
            }

            if (num.Substring(0, 2) != "01")
            {
                MessageBox.Show("Number start with 01");
                txtnum.Focus();
                return;
            }

            if (num.Length != 11)
            {
                MessageBox.Show("phone number 11 character required");
                txtnum.Focus();
                return;
            }

            string temail = txtmail.Text;
            if (string.IsNullOrEmpty(temail))
            {
                MessageBox.Show("Email Required");
                txtmail.Focus();
                return;
            }

            if (Regex.IsMatch(txtmail.Text, email_Pattern) == false)
            {
                MessageBox.Show("Invalid Email");
                txtmail.Focus();
                return;
            }

            string address = txtAdd.Text;

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address required");
                txtAdd.Focus();
                return;
            }
        }


        private void Update() 
        {
            string query = "update Users set name='"+txtName.Text+"',pass='"+txtPass.Text+"', [address]='"+txtAdd.Text+"',"
                +"teacherNum='"+txtnum.Text+"',teacherEmail='"+txtmail.Text+"' where id="+User.userId+"";

            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Your Info Updated");
            }
            else 
            {
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Validation();
            this.Update();
            this.Refresh();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void t_DashBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtShow_MouseHover(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0';
        }

        private void txtShow_MouseLeave(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }


    }
}
