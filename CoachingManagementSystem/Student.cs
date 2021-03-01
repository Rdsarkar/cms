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
    public partial class Student : Form
    {

        private bool isNew = true;
        public Student()
        {
            InitializeComponent();
        }

        public Student(string Adminid)
        {
            InitializeComponent();
        }

       

        string email_Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        //page navigation start
        private void couseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Course cr = new Course();
            cr.Show();
            this.Hide();
        }
        
        private void adminPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adPanel ad = new adPanel();
            ad.Show();
            this.Hide();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teacher te = new Teacher();
            te.Show();
            this.Hide();
        }
        //end of page navigation
        private void Student_FormClosing(object sender, FormClosingEventArgs e)
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


        private void Save() 
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
            string Gender = "";
            if (rbtnMale.Checked == true)
            {
                Gender = "Male";
            }
            else if (rbtnFemale.Checked == true)
            {
                Gender = "Female";
            }
            else
            {
                MessageBox.Show("Please Select gender!");
                rbtnMale.Focus();
                rbtnMale.Checked = false;
                return;
            }
            DateTime dob;
            try
            {
                dob = Convert.ToDateTime(dtpDoB.Text);
                int year = (DateTime.Now - dob).Days / 365;

                if (year < 15)
                {
                    MessageBox.Show("Minimum 15 years required!");
                    dtpDoB.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid DOB!");
                dtpDoB.Focus();
                return;
            }



            string pname = txtPname.Text;

            if (string.IsNullOrEmpty(pname))
            {
                MessageBox.Show("Parents Name required");
                txtPname.Focus();
                return;
            }

            string pnum = txtPnum.Text;

            if (string.IsNullOrEmpty(pnum))
            {
                MessageBox.Show("Parents Phone Number required");
                txtPnum.Focus();
                return;
            }

            if (pnum.Substring(0, 2) != "01")
            {
                MessageBox.Show("Number start with 01");
                txtPnum.Focus();
                return;
            }

            if (pnum.Length != 11)
            {
                MessageBox.Show("phone number 11 character required");
                txtPnum.Focus();
                return;
            }

            string email = txtPmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Parents Email required");
                txtPmail.Focus();
                return;
            }

            if (Regex.IsMatch(txtPmail.Text, email_Pattern) == false)
            {
                MessageBox.Show("Invalid Email");
                txtPmail.Focus();
                return;
            }

            string address = txtAdd.Text;

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address required");
                txtAdd.Focus();
                return;
            }

            string query = "";
            if (isNew == true)
            {
                query = "insert into Users([name], pass, uType, dob, gender, parentsName, parentsNum, parentsEmail, [address], teacherNum, teacherEmail, [status])"
                    + " values ('" + name + "','" + pass + "', 'student', '" + dob + "', '" + Gender + "', '" + pname + "', '" + pnum + "', '" + email + "', '" + address + "','','','1') ";


            }
            else
            {
                query = "update Users set [name]='" + name + "', pass='" + pass + "',parentsName='" + pname + "',parentsNum='" + pnum + "',parentsEmail='" + email + "',[address]='" + address + "' where id='" + txtId.Text + "'";
            }

            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Student Inserted/Updated");
                this.New();
                this.LoadStudent();
            }
            else 
            {
                return;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            this.Save();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
            dgvStudent.ClearSelection();
        }

        private void New() 
        {
            isNew = true;
            txtId.Text = "";
            txtName.Text = "";
            txtPass.Text = "";
            rbtnMale.Checked = rbtnMale.Checked = false;
            dtpDoB.Text = DateTime.Now.ToString();
            txtPname.Text = "";
            txtPnum.Text = "";
            txtPmail.Text = "";
            txtAdd.Text = "";
            
        }


        private void LoadStudent()
        {
            string query = "Select * from Users where utype='student'";

            if (string.IsNullOrEmpty(txtSearch.Text) == false)
            {
                query = query + " and Users.name like '%"+txtSearch.Text+"%'";
            }


            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvStudent.AutoGenerateColumns = false;
            dgvStudent.DataSource = dt;
            dgvStudent.Refresh();
            dgvStudent.ClearSelection();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            lblName.Text = User.userName;
            this.LoadStudent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        private void LoadSingleStudent()
        {
            String query = "select * from Users where id=" + txtId.Text + "";
            DataTable dt = DataAccess.GetData(query);
            

            if (dt == null) { return; }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid ID");
                return;
            }

            isNew = false;

            txtName.Text = dt.Rows[0]["name"].ToString();
            txtPass.Text = dt.Rows[0]["pass"].ToString();
            string Gender = dt.Rows[0]["gender"].ToString();
            if (Gender == "Male") 
            {
                rbtnMale.Checked = true;
            }
            else if (Gender == "Female")
            {
                rbtnFemale.Checked = true;
            }

            dtpDoB.Text = dt.Rows[0]["dob"].ToString(); 
            txtPname.Text = dt.Rows[0]["parentsName"].ToString(); 
            txtPnum.Text = dt.Rows[0]["parentsNum"].ToString(); 
            txtPmail.Text = dt.Rows[0]["parentsEmail"].ToString(); 
            txtAdd.Text = dt.Rows[0]["address"].ToString(); 

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                MessageBox.Show("Please Load Existing Data");
            }
            string query = "delete from Users where id=" + txtId.Text + "";

            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Deleted");
                this.New();

                this.LoadStudent();
            }
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtId.Text = id;
                this.LoadSingleStudent();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadStudent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

       

        private void txtPnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            if (string.IsNullOrEmpty(txtSearch.Text) == false)
            {
                query = "select * from Users where uType='student' and Users.name like '%" + txtSearch.Text + "%'";
            }
            else
            {
                this.LoadStudent();
                return;
            }
            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvStudent.AutoGenerateColumns = false;
            dgvStudent.DataSource = dt;
            dgvStudent.Refresh();
            dgvStudent.ClearSelection();
        }

    }
}
