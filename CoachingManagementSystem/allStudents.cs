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
    public partial class allStudents : Form
    {
        public allStudents()
        {
            InitializeComponent();
        }

        private void LoadStudent()
        {
            string query = "Select * from Users where utype='student'";

            
            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvAStudent.AutoGenerateColumns = false;
            dgvAStudent.DataSource = dt;
            dgvAStudent.Refresh();
            dgvAStudent.ClearSelection();
        }

        private void allStudents_Load(object sender, EventArgs e)
        {
            this.LoadStudent();
        }
    }
}
