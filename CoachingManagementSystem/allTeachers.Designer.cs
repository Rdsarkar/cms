namespace CoachingManagementSystem
{
    partial class allTeachers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(allTeachers));
            this.dgvAteacher = new System.Windows.Forms.DataGridView();
            this.dgvATid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvATname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvATdob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvATnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvATmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvATaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAteacher)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAteacher
            // 
            this.dgvAteacher.AllowUserToAddRows = false;
            this.dgvAteacher.AllowUserToDeleteRows = false;
            this.dgvAteacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAteacher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvATid,
            this.dgvATname,
            this.dgvATdob,
            this.dgvATnum,
            this.dgvATmail,
            this.dgvATaddress});
            this.dgvAteacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAteacher.Location = new System.Drawing.Point(0, 0);
            this.dgvAteacher.Name = "dgvAteacher";
            this.dgvAteacher.ReadOnly = true;
            this.dgvAteacher.RowTemplate.Height = 24;
            this.dgvAteacher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAteacher.Size = new System.Drawing.Size(782, 403);
            this.dgvAteacher.TabIndex = 0;
            // 
            // dgvATid
            // 
            this.dgvATid.DataPropertyName = "id";
            this.dgvATid.HeaderText = "ID";
            this.dgvATid.Name = "dgvATid";
            this.dgvATid.ReadOnly = true;
            this.dgvATid.Width = 50;
            // 
            // dgvATname
            // 
            this.dgvATname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvATname.DataPropertyName = "name";
            this.dgvATname.HeaderText = "Name";
            this.dgvATname.Name = "dgvATname";
            this.dgvATname.ReadOnly = true;
            // 
            // dgvATdob
            // 
            this.dgvATdob.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvATdob.DataPropertyName = "dob";
            this.dgvATdob.HeaderText = "Date of Birth";
            this.dgvATdob.Name = "dgvATdob";
            this.dgvATdob.ReadOnly = true;
            // 
            // dgvATnum
            // 
            this.dgvATnum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvATnum.DataPropertyName = "teacherNum";
            this.dgvATnum.HeaderText = "Contact Number";
            this.dgvATnum.Name = "dgvATnum";
            this.dgvATnum.ReadOnly = true;
            // 
            // dgvATmail
            // 
            this.dgvATmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvATmail.DataPropertyName = "teacherEmail";
            this.dgvATmail.HeaderText = "Contact E-Mail";
            this.dgvATmail.Name = "dgvATmail";
            this.dgvATmail.ReadOnly = true;
            // 
            // dgvATaddress
            // 
            this.dgvATaddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvATaddress.DataPropertyName = "address";
            this.dgvATaddress.HeaderText = "Address";
            this.dgvATaddress.Name = "dgvATaddress";
            this.dgvATaddress.ReadOnly = true;
            // 
            // allTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 403);
            this.Controls.Add(this.dgvAteacher);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "allTeachers";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Teachers";
            this.Load += new System.EventHandler(this.allTeachers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAteacher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAteacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvATid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvATname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvATdob;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvATnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvATmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvATaddress;
    }
}