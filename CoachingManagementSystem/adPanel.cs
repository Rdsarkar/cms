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
    public partial class adPanel : Form
    {

        public adPanel()
        {
            InitializeComponent();
        
        }
        public adPanel(string data)
        {
            InitializeComponent();
        }

       //page navigation start 
        private void couseToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teacher te = new Teacher();
            te.Show();
            this.Hide();
        }

        //page navigation end

        private void adPanel_Load(object sender, EventArgs e)
        {
            lblName.Text = User.userName;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void adPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            allStudents alls = new allStudents();
            alls.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            allTeachers allt = new allTeachers();
            allt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            allCourses allc = new allCourses();
            allc.Show();
        }

       
       
    }
}
