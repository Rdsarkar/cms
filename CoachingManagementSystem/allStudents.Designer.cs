namespace CoachingManagementSystem
{
    partial class allStudents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(allStudents));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAStudent = new System.Windows.Forms.DataGridView();
            this.dgvASid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvASname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvASdob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvASparentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvASparentNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvASaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAStudent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 403);
            this.panel1.TabIndex = 0;
            // 
            // dgvAStudent
            // 
            this.dgvAStudent.AllowUserToAddRows = false;
            this.dgvAStudent.AllowUserToDeleteRows = false;
            this.dgvAStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvASid,
            this.dgvASname,
            this.dgvASdob,
            this.dgvASparentName,
            this.dgvASparentNum,
            this.dgvASaddress});
            this.dgvAStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAStudent.Location = new System.Drawing.Point(0, 0);
            this.dgvAStudent.Name = "dgvAStudent";
            this.dgvAStudent.ReadOnly = true;
            this.dgvAStudent.RowTemplate.Height = 24;
            this.dgvAStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAStudent.Size = new System.Drawing.Size(782, 403);
            this.dgvAStudent.TabIndex = 0;
            // 
            // dgvASid
            // 
            this.dgvASid.DataPropertyName = "id";
            this.dgvASid.HeaderText = "ID";
            this.dgvASid.Name = "dgvASid";
            this.dgvASid.ReadOnly = true;
            this.dgvASid.Width = 50;
            // 
            // dgvASname
            // 
            this.dgvASname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvASname.DataPropertyName = "name";
            this.dgvASname.HeaderText = "Name";
            this.dgvASname.Name = "dgvASname";
            this.dgvASname.ReadOnly = true;
            // 
            // dgvASdob
            // 
            this.dgvASdob.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvASdob.DataPropertyName = "dob";
            this.dgvASdob.HeaderText = "Date of Birth";
            this.dgvASdob.Name = "dgvASdob";
            this.dgvASdob.ReadOnly = true;
            // 
            // dgvASparentName
            // 
            this.dgvASparentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvASparentName.DataPropertyName = "parentsName";
            this.dgvASparentName.HeaderText = "Parents Name";
            this.dgvASparentName.Name = "dgvASparentName";
            this.dgvASparentName.ReadOnly = true;
            // 
            // dgvASparentNum
            // 
            this.dgvASparentNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvASparentNum.DataPropertyName = "parentsNum";
            this.dgvASparentNum.HeaderText = "Gurdians Number";
            this.dgvASparentNum.Name = "dgvASparentNum";
            this.dgvASparentNum.ReadOnly = true;
            // 
            // dgvASaddress
            // 
            this.dgvASaddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvASaddress.DataPropertyName = "address";
            this.dgvASaddress.HeaderText = "Address";
            this.dgvASaddress.Name = "dgvASaddress";
            this.dgvASaddress.ReadOnly = true;
            // 
            // allStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "allStudents";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Students";
            this.Load += new System.EventHandler(this.allStudents_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAStudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvASid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvASname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvASdob;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvASparentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvASparentNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvASaddress;
    }
}