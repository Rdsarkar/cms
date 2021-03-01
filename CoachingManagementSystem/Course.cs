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
    public partial class Course : Form
    {

        private bool isNew = true;
        public Course()
        {
            InitializeComponent();
        }

        public Course(string data)
        {
            InitializeComponent();
        }

        //page navigation start 
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.Show();
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
        //page navigation end
        private void Course_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void Save() 
        {
            string course = txtCourse.Text;
            if (string.IsNullOrEmpty(course))
            {
                MessageBox.Show("Course required");
                txtCourse.Focus();
                return;
            }

            string batch = txtBatch.Text;
            if(string.IsNullOrEmpty(batch))
            {
                MessageBox.Show("Batch required");
                txtBatch.Focus();
                return;
            }

            string time = cmbTime.Text;
            if (string.IsNullOrEmpty(time))
            {
                MessageBox.Show("Time required");
                cmbTime.Focus();
                return;
            }

            string day = cmbDay.Text;
            if (string.IsNullOrEmpty(day))
            {
                MessageBox.Show("Day required");
                cmbDay.Focus();
                return;
            }


            string fees = txtFees.Text;
            if (string.IsNullOrEmpty(fees))
            {
                MessageBox.Show("Fees required");
                txtFees.Focus();
                return;
            }


            string query = "";

            if (isNew == true)
            {
             query = "insert into Courses([name], batch,[time],[day],fees)" +
                      "values('" + course + "','" + batch + "','" + time + "','" + day + "','" + fees + "') ";
            }

            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Course Inserted!!");
                this.LoadCourses();
            }
        }

        private void LoadCourses() 
        {
            string query = "Select * from Courses";

            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            this.New();

            dgvCourses.AutoGenerateColumns = false;
            dgvCourses.DataSource = dt;
            dgvCourses.Refresh();
            dgvCourses.ClearSelection();
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvCourses.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtId.Text = id;
                this.LoadSingleCourse();
            }
        }

        private void Course_Load(object sender, EventArgs e)
        {
            lblName.Text=User.userName ;
            this.LoadCourses();
        }

        private void LoadSingleCourse() 
        {
            String query = "Select * from Courses where c_id=" + txtId.Text + "";

            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid ID");
                return;
            }

            isNew = false;

            txtId.Text = dt.Rows[0]["c_id"].ToString();
            txtCourse.Text = dt.Rows[0]["name"].ToString();
            txtBatch.Text = dt.Rows[0]["batch"].ToString();
            cmbTime.Text = dt.Rows[0]["time"].ToString();
            cmbDay.Text = dt.Rows[0]["day"].ToString();
            txtFees.Text = dt.Rows[0]["fees"].ToString();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
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
                query = "select * from Courses where name like '%" + txtSearch.Text + "%'";
            }
            else
            {
                this.LoadCourses();
                return;
            }
            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvCourses.AutoGenerateColumns = false;
            dgvCourses.DataSource = dt;
            dgvCourses.Refresh();
            dgvCourses.ClearSelection();
        }

        private void New() 
        {
            isNew = true;
            txtId.Text = "";
            txtCourse.Text = "";
            txtBatch.Text = "";
            cmbTime.Text = "";
            cmbDay.Text = "";
            txtFees.Text = "";
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                MessageBox.Show("Please Load Existing Data");
            }
            string query = "delete from Courses where c_id="+txtId.Text+"";

            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Deleted");
                this.New();

                this.LoadCourses();
            }
        }
       
    }
}




//extra


//query = "select * from Courses";

//DataTable dt = DataAccess.GetData(query);

//for (int i=0; i < dt.Rows.Count; i++)
//{
//    string cbatch = dt.Rows[i]["batch"].ToString();
//    string ctime = dt.Rows[i]["time"].ToString();
//    string cday = dt.Rows[i]["day"].ToString();

//    if( cbatch != "hsc" || cbatch != "ssc"){
//        MessageBox.Show("Batch value should be hsc or ssc!!");

//    }


//    if (cday != cmbDay.Text)
//    {

//        query = "insert into Courses([name], batch,[time],[day],fees)" +
//        " values('" + course + "','" + batch + "','" + time + "','" + day + "','" + fees + "') ";

//        if (DataAccess.ExecuteQuery(query) == true)
//        {
//            MessageBox.Show("Course Inserted!!");
//        }
//    }


//    if (ctime != cmbTime.Text)
//    {

//        query = "insert into Courses([name], batch,[time],[day],fees)" +
//        " values('" + course + "','" + batch + "','" + time + "','" + day + "','" + fees + "') ";

//        if (DataAccess.ExecuteQuery(query) == true)
//        {
//            MessageBox.Show("Course Inserted!!");
//        }
//    }


//    if (cday != cmbDay.Text && ctime == cmbTime.Text)
//    {

//        query = "insert into Courses([name], batch,[time],[day],fees)" +
//        " values('" + course + "','" + batch + "','" + time + "','" + day + "','" + fees + "') ";

//        if (DataAccess.ExecuteQuery(query) == true)
//        {
//            MessageBox.Show("Course Inserted!!");
//        }
//    }

//    if (cday == cmbDay.Text && ctime != cmbTime.Text)
//    {

//        query = "insert into Courses([name], batch,[time],[day],fees)" +
//        " values('" + course + "','" + batch + "','" + time + "','" + day + "','" + fees + "') ";

//        if (DataAccess.ExecuteQuery(query) == true)
//        {
//            MessageBox.Show("Course Inserted!!");
//        }
//    }


//    if((cbatch == txtBatch.Text ) && (ctime == cmbTime.Text) && (cday == cmbDay.Text))
//    {

//         MessageBox.Show("data already esisted.");


//    }   
//    else if ((cbatch == txtBatch.Text ) && (ctime == cmbTime.Text) && (cday == cmbDay.Text)){

//        MessageBox.Show("data already esisted.");

//    }else{

//        query = "insert into Courses([name], batch,[time],[day],fees)" +
//        " values('" + course + "','" + batch + "','" + time + "','" + day + "','" + fees + "') ";

//        if (DataAccess.ExecuteQuery(query) == true)
//        {
//            MessageBox.Show("Course Inserted!!");
//        }
//    }






















//    if((cbatch == txtBatch.Text ) && (ctime == cmbTime.Text) && (cday == cmbDay.Text))
//    {

//        MessageBox.Show("All input values are matched. please check the exixting data");

//    }else if((cbatch == txtBatch.Text ) && (ctime == cmbTime.Text) && (cday == cmbDay.Text)){

//        MessageBox.Show("All input values are matched. please check the exixting data");
//    }

//}