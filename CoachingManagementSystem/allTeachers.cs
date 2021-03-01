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
    public partial class allTeachers : Form
    {
        public allTeachers()
        {
            InitializeComponent();
        }

        private void LoadTeacher()
        {
            string query = "Select * from Users where utype='teacher'";


            DataTable dt = DataAccess.GetData(query);

            if (dt == null) { return; }

            dgvAteacher.AutoGenerateColumns = false;
            dgvAteacher.DataSource = dt;
            dgvAteacher.Refresh();
            dgvAteacher.ClearSelection();
        }

        private void allTeachers_Load(object sender, EventArgs e)
        {
            this.LoadTeacher();
        }
    }
}
