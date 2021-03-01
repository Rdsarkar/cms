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

namespace CoachingManagementSystem
{
    public partial class Salary : Form
    {

        private bool isNew = true;
        public Salary()
        {
            InitializeComponent();
        }


        public Salary(string Data)
        {
            InitializeComponent();
        }

        //page navigation start 
     
        private void adminPanelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            adPanel ad = new adPanel();
            ad.Show();
            this.Hide();
        }

        private void couseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Course cr = new Course();
            cr.Show();
            this.Hide();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.Show();
            this.Hide();
        }

        private void teacherToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Teacher te = new Teacher();
            te.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
        //end of page navigation


        private void LoadTeacher() 
        {
            string query = "select id, name from Users where uType = 'teacher'";

            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            cmbId.DataSource = dt;
            cmbId.DisplayMember = "id";
            cmbId.ValueMember = "id";
        }



        private void Salary_Load(object sender, EventArgs e)
        {
            lblName.Text = User.userName;
            this.LoadTeacher();
            this.LoadSalary();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string query = "select name from Users where id='"+cmbId.Text+"'";

            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid ID");
                return;
            }
        
            txtName.Text = dt.Rows[0]["name"].ToString();
        }

        

        private void Save()
        {
            string id = cmbId.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("ID required!!");
                cmbId.Focus();
                return;
            }

            string name = txtName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("ID Should be load to show the name of Teacher!!");
                txtName.Focus();
                return;
            }

            string sal = txtSalary.Text;
            if (string.IsNullOrEmpty(sal))
            {
                MessageBox.Show("Salary Required!!");
                txtSalary.Focus();
                return;
            }

            string alw = txtAllow.Text;
            if (string.IsNullOrEmpty(alw))
            {
                MessageBox.Show("Allowance Required!!");
                txtAllow.Focus();
                return;
            }
           // int id = Convert.ToInt32(cmbId.Text);
            
               
            string query = "";
            if (isNew == true)
            {
                query = "insert into salary(s_id,salary,allowance) values ('" + id + "','" + sal + "','" + alw + "')";
            }
            else 
            {
                query = "update salary set salary='"+txtSalary.Text+"',allowance='"+txtAllow.Text+"' where s_id="+cmbId.Text+"";
            }

            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Salary Inserted/Updated");
                this.LoadSalary();
            }
            else { return; }
        }

        private void LoadSalary() 
        {
            string query = "select salary.*,Users.name from salary,Users where salary.s_id= Users.id";

            if (string.IsNullOrEmpty(txtSearch.Text) == false)
            {
                query = query + " and Users.name like '%" + txtSearch.Text + "%'";
            }

            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvSal.AutoGenerateColumns = false;
            dgvSal.DataSource = dt;
            dgvSal.Refresh();
            dgvSal.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
            this.New();
        }

        private void LoadSingleSalary() 
        {
            String query = "select * from salary where s_id=" + cmbId.Text + "";
            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid ID");
                return;
            }

            isNew = false;

            
            cmbId.Text=dt.Rows[0]["s_id"].ToString();
            //txtName.Text = dt.Rows[0]["name"].ToString();
            txtSalary.Text=dt.Rows[0]["salary"].ToString();
            txtAllow.Text=dt.Rows[0]["allowance"].ToString();
            
        }
        private void dgvSal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvSal.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbId.Text = id;
                this.LoadSingleSalary();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.New();
            txtSearch.Text = "";
            this.LoadSalary();
        }

        private void New() 
        {
            isNew = true;
            cmbId.Text = "";
            txtName.Text = "";
            txtSalary.Text = "";
            txtAllow.Text = "";
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

      

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadSalary();
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtAllow_KeyPress(object sender, KeyPressEventArgs e)
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
                
                query ="select salary.*,Users.name from salary,Users where salary.s_id= Users.id"
                + " and Users.name like '%" + txtSearch.Text + "%'";
            }
            else
            {
                this.LoadSalary();
                return;
            }
            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvSal.AutoGenerateColumns = false;
            dgvSal.DataSource = dt;
            dgvSal.Refresh();
            dgvSal.ClearSelection();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                MessageBox.Show("Please Load Existing Data");
            }
            string query = "delete from salary where s_id="+cmbId.Text+"";

            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Deleted");
                this.New();

                this.LoadSalary();
            }
        }


    }
}
