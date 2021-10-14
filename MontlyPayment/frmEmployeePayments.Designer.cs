
namespace MontlyPayment
{
    partial class frmEmployeePayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeePayments));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEmployeePayments = new System.Windows.Forms.DataGridView();
            this.PaymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPayed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PayCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEarn = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLastname = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeePayments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "EMPLOYEE PAYMENT LIST";
            // 
            // dgvEmployeePayments
            // 
            this.dgvEmployeePayments.AllowUserToAddRows = false;
            this.dgvEmployeePayments.AllowUserToDeleteRows = false;
            this.dgvEmployeePayments.AllowUserToResizeColumns = false;
            this.dgvEmployeePayments.AllowUserToResizeRows = false;
            this.dgvEmployeePayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeePayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaymentID,
            this.PaymentDate,
            this.BasicSalary,
            this.Bonus,
            this.Discounts,
            this.TotalSalary,
            this.IsPayed,
            this.PayCode});
            this.dgvEmployeePayments.Location = new System.Drawing.Point(12, 119);
            this.dgvEmployeePayments.Name = "dgvEmployeePayments";
            this.dgvEmployeePayments.ReadOnly = true;
            this.dgvEmployeePayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeePayments.Size = new System.Drawing.Size(844, 402);
            this.dgvEmployeePayments.TabIndex = 3;
            // 
            // PaymentID
            // 
            this.PaymentID.DataPropertyName = "PaymentID";
            this.PaymentID.HeaderText = "PaymentID";
            this.PaymentID.Name = "PaymentID";
            this.PaymentID.ReadOnly = true;
            // 
            // PaymentDate
            // 
            this.PaymentDate.DataPropertyName = "PaymentDate";
            this.PaymentDate.HeaderText = "Payment Date";
            this.PaymentDate.Name = "PaymentDate";
            this.PaymentDate.ReadOnly = true;
            // 
            // BasicSalary
            // 
            this.BasicSalary.DataPropertyName = "BasicSalary";
            this.BasicSalary.HeaderText = "Basic Salary";
            this.BasicSalary.Name = "BasicSalary";
            this.BasicSalary.ReadOnly = true;
            // 
            // Bonus
            // 
            this.Bonus.DataPropertyName = "Bonus";
            this.Bonus.HeaderText = "Bonus";
            this.Bonus.Name = "Bonus";
            this.Bonus.ReadOnly = true;
            // 
            // Discounts
            // 
            this.Discounts.DataPropertyName = "Discounts";
            this.Discounts.HeaderText = "Discounts";
            this.Discounts.Name = "Discounts";
            this.Discounts.ReadOnly = true;
            // 
            // TotalSalary
            // 
            this.TotalSalary.DataPropertyName = "TotalSalary";
            this.TotalSalary.HeaderText = "Total Salary";
            this.TotalSalary.Name = "TotalSalary";
            this.TotalSalary.ReadOnly = true;
            // 
            // IsPayed
            // 
            this.IsPayed.DataPropertyName = "IsPayed";
            this.IsPayed.HeaderText = "IsPayed";
            this.IsPayed.Name = "IsPayed";
            this.IsPayed.ReadOnly = true;
            // 
            // PayCode
            // 
            this.PayCode.DataPropertyName = "PayCode";
            this.PayCode.HeaderText = "PayCode";
            this.PayCode.Name = "PayCode";
            this.PayCode.ReadOnly = true;
            this.PayCode.Visible = false;
            // 
            // btnEarn
            // 
            this.btnEarn.Image = ((System.Drawing.Image)(resources.GetObject("btnEarn.Image")));
            this.btnEarn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEarn.Location = new System.Drawing.Point(14, 527);
            this.btnEarn.Name = "btnEarn";
            this.btnEarn.Size = new System.Drawing.Size(75, 37);
            this.btnEarn.TabIndex = 27;
            this.btnEarn.Text = "Get Paid";
            this.btnEarn.UseVisualStyleBackColor = true;
            this.btnEarn.Click += new System.EventHandler(this.btnEarn_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(178, 527);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 37);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(781, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 37);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(781, 86);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(75, 23);
            this.txtBuscar.TabIndex = 32;
            this.txtBuscar.Text = "Search";
            this.txtBuscar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "To:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(298, 85);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(102, 20);
            this.dtpToDate.TabIndex = 30;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(50, 85);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(102, 20);
            this.dtpFromDate.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(197, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Lastname:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(64, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 35;
            this.lblName.Text = "Name";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastname.Location = new System.Drawing.Point(277, 56);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(78, 17);
            this.lblLastname.TabIndex = 36;
            this.lblLastname.Text = "Lastname";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(781, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 37;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmEmployeePayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 569);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblLastname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEarn);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvEmployeePayments);
            this.Controls.Add(this.label1);
            this.Name = "frmEmployeePayments";
            this.Text = "Employee - Pending Pay";
            this.Load += new System.EventHandler(this.frmEmployeePayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeePayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEmployeePayments;
        internal System.Windows.Forms.Button btnEarn;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button txtBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSalary;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPayed;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayCode;
        private System.Windows.Forms.Button btnLogout;
    }
}