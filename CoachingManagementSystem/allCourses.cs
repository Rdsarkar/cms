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
    public partial class allCourses : Form
    {
        public allCourses()
        {
            InitializeComponent();
        }

        private void LoadCourses() 
        {
            string query = "Select * from Courses";


            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvACourse.AutoGenerateColumns = false;
            dgvACourse.DataSource = dt;
            dgvACourse.Refresh();
            dgvACourse.ClearSelection();
        }

        private void allCourses_Load(object sender, EventArgs e)
        {
            this.LoadCourses();
        }
    }
}
