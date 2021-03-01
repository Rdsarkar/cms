using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoachingManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtShow_MouseHover(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0';
        }

        private void txtShow_MouseLeave(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("ID required");
                txtId.Focus();
                return;
            }

            string password = txtPass.Text;

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password required");
                txtPass.Focus();
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("minimum 8 character required");
                txtPass.Focus();
                return;
            }

            
            string query = "select * from Users where id = '"+txtId.Text+"' and pass='"+txtPass.Text+"'";

            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            if (dt.Rows.Count != 1) 
            { 
                MessageBox.Show("Invalid Username Or Password");
                return;
            }

            string uType = dt.Rows[0]["uType"].ToString();

            if (uType == "admin")
            {
                adPanel ad = new adPanel(txtId.Text);
                User.userId = txtId.Text;

                query = "select * from Users where id="+txtId.Text+"";

                dt = DataAccess.GetData(query);

                User.userName = dt.Rows[0]["name"].ToString();

                ad.Show();
                this.Hide();
            }

            else if (uType == "teacher") 
            {
                t_DashBoard tDash = new t_DashBoard(txtId.Text);
                User.userId = txtId.Text;

                query = "select Users.id,[name],pass,dob,[address],teacherNum,teacherEmail,salary.salary,allowance "
                        + "from salary,Users where Users.id=" + txtId.Text + " and salary.s_id= Users.id";

                dt = DataAccess.GetData(query);

                User.userName = dt.Rows[0]["name"].ToString();
                User.u_pass = dt.Rows[0]["pass"].ToString();
                User.u_dob = dt.Rows[0]["dob"].ToString();
                User.u_address = dt.Rows[0]["address"].ToString();
                User.t_Num = dt.Rows[0]["teacherNum"].ToString();
                User.t_Email = dt.Rows[0]["teacherEmail"].ToString();
                User.t_salary = dt.Rows[0]["salary"].ToString();
                User.t_allowance = dt.Rows[0]["allowance"].ToString();


                tDash.Show();
                this.Hide();

            }
            else if(uType == "student"){}

            else
            {
                MessageBox.Show("Invalid Users!!");
                return;
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

    }
}
