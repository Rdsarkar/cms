using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace CoachingManagementSystem
{
    public partial class Teacher : Form
    {
        private bool isNew = true;
        public Teacher()
        {
            InitializeComponent();
        }

        string email_Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        //page navigation start 
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.Show();
            this.Hide();
        }

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

       
        //end of page navigation
      

        private void Teacher_FormClosing(object sender, FormClosingEventArgs e)
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
            if (rbtnMale.Checked)
            {
                Gender = "Male";
            }
            else if (rbtnFemale.Checked)
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

                if (year < 22)
                {
                    MessageBox.Show("Minimum 22 years required!");
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

            string query = "";
            if (isNew == true)
            {
                query = "insert into Users([name], pass, uType, dob, gender, parentsName, parentsNum, parentsEmail, [address], teacherNum, teacherEmail, [status])"
                        + " values ('" + name + "','" + pass + "', 'teacher', '" + dob + "', '" + Gender + "', '', '', '', '" + address + "','" + num + "','" + temail + "','1')";


            }
            else
            {
                query = "update Users set [name]='" + name + "',pass='" + pass + "',teacherNum='" + num + "',teacherEmail='" + temail + "',[address]='" + address + "' where id=" + txtId.Text + "";
            }

            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Teacher Inserted!!");
                this.New();
                this.LoadTeacher();
            }
            else { return; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void New()
        {
            isNew = true;
            txtId.Text = "";
            txtName.Text = "";
            txtPass.Text = "";
            rbtnMale.Checked = rbtnMale.Checked = false;
            dtpDoB.Text = DateTime.Now.ToString();
            txtnum.Text = "";
            txtmail.Text = "";
            txtAdd.Text = "";
        }

        private void LoadTeacher() 
        {
            string query = "Select * from Users where utype='teacher'";

            if (string.IsNullOrEmpty(txtSearch.Text) == false)
            {
                query = query + " and Users.name like '%" + txtSearch.Text + "%'";
            }


            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvTeacher.AutoGenerateColumns = false;
            dgvTeacher.DataSource = dt;
            dgvTeacher.Refresh();
            dgvTeacher.ClearSelection();
        }

        private void LoadSingleTeacher() 
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
            txtnum.Text = dt.Rows[0]["teacherNum"].ToString();
            txtmail.Text = dt.Rows[0]["teacherEmail"].ToString();
            txtAdd.Text = dt.Rows[0]["address"].ToString(); 
        }



        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            sal.Show();
            this.Hide();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
            dgvTeacher.ClearSelection();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            this.LoadTeacher();
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

                this.LoadTeacher();
            }
        }

        private void dgvTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvTeacher.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtId.Text = id;
                this.LoadSingleTeacher();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadTeacher();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadTeacher();
        }

        private void txtnum_KeyPress(object sender, KeyPressEventArgs e)
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
                query = "select * from Users where uType='teacher' and Users.name like '%" + txtSearch.Text + "%'";
            }
            else
            {
                this.LoadTeacher();
                return;
            }
            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvTeacher.AutoGenerateColumns = false;
            dgvTeacher.DataSource = dt;
            dgvTeacher.Refresh();
            dgvTeacher.ClearSelection();
        }

        
    }
}
