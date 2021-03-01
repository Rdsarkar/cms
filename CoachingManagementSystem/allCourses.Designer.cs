namespace CoachingManagementSystem
{
    partial class allCourses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(allCourses));
            this.dgvACourse = new System.Windows.Forms.DataGridView();
            this.dgvACid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvACname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvACbatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvACtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvACday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvACfees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvACourse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvACourse
            // 
            this.dgvACourse.AllowUserToAddRows = false;
            this.dgvACourse.AllowUserToDeleteRows = false;
            this.dgvACourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvACourse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvACid,
            this.dgvACname,
            this.dgvACbatch,
            this.dgvACtime,
            this.dgvACday,
            this.dgvACfees});
            this.dgvACourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvACourse.Location = new System.Drawing.Point(0, 0);
            this.dgvACourse.Name = "dgvACourse";
            this.dgvACourse.ReadOnly = true;
            this.dgvACourse.RowTemplate.Height = 24;
            this.dgvACourse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvACourse.Size = new System.Drawing.Size(782, 403);
            this.dgvACourse.TabIndex = 0;
            // 
            // dgvACid
            // 
            this.dgvACid.DataPropertyName = "c_id";
            this.dgvACid.HeaderText = "Course ID";
            this.dgvACid.Name = "dgvACid";
            this.dgvACid.ReadOnly = true;
            this.dgvACid.Width = 70;
            // 
            // dgvACname
            // 
            this.dgvACname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvACname.DataPropertyName = "name";
            this.dgvACname.HeaderText = "Name";
            this.dgvACname.Name = "dgvACname";
            this.dgvACname.ReadOnly = true;
            // 
            // dgvACbatch
            // 
            this.dgvACbatch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvACbatch.DataPropertyName = "batch";
            this.dgvACbatch.HeaderText = "Batch";
            this.dgvACbatch.Name = "dgvACbatch";
            this.dgvACbatch.ReadOnly = true;
            // 
            // dgvACtime
            // 
            this.dgvACtime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvACtime.DataPropertyName = "time";
            this.dgvACtime.HeaderText = "Class Time ";
            this.dgvACtime.Name = "dgvACtime";
            this.dgvACtime.ReadOnly = true;
            // 
            // dgvACday
            // 
            this.dgvACday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvACday.DataPropertyName = "day";
            this.dgvACday.HeaderText = "Days";
            this.dgvACday.Name = "dgvACday";
            this.dgvACday.ReadOnly = true;
            // 
            // dgvACfees
            // 
            this.dgvACfees.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvACfees.DataPropertyName = "fees";
            this.dgvACfees.HeaderText = "Course Fee";
            this.dgvACfees.Name = "dgvACfees";
            this.dgvACfees.ReadOnly = true;
            // 
            // allCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.dgvACourse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "allCourses";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Courses";
            this.Load += new System.EventHandler(this.allCourses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvACourse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvACourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvACid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvACname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvACbatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvACtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvACday;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvACfees;
    }
}