
namespace MontlyPayment
{
    partial class frmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(346, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "PAYMENT";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Lastname,
            this.Column3,
            this.Pay});
            this.dgvEmployees.Location = new System.Drawing.Point(12, 104);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(817, 428);
            this.dgvEmployees.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(754, 538);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 37);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(673, 538);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 37);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaymentDate.Location = new System.Drawing.Point(86, 62);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(100, 20);
            this.dtpPaymentDate.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Date:";
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(538, 61);
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(256, 20);
            this.txtObservation.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Observations:";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UserID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FirstName";
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            // 
            // Lastname
            // 
            this.Lastname.DataPropertyName = "LastName";
            this.Lastname.HeaderText = "Lastname";
            this.Lastname.Name = "Lastname";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Salary";
            this.Column3.HeaderText = "Salary";
            this.Column3.Name = "Column3";
            // 
            // Pay
            // 
            this.Pay.HeaderText = "Pay";
            this.Pay.Name = "Pay";
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 587);
            this.Controls.Add(this.txtObservation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.label1);
            this.Name = "frmPayment";
            this.Text = "HHRR - Payment";
            this.Load += new System.EventHandler(this.frmEmployeeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEmployees;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pay;
    }
}