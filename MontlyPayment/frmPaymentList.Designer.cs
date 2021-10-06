
namespace MontlyPayment
{
    partial class frmPaymentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentList));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewPayment = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "PAYMENT LIST";
            // 
            // dgvPayments
            // 
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Observations});
            this.dgvPayments.Location = new System.Drawing.Point(12, 109);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.Size = new System.Drawing.Size(844, 478);
            this.dgvPayments.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Payment Date";
            this.Column4.Name = "Column4";
            // 
            // Observations
            // 
            this.Observations.HeaderText = "Observations";
            this.Observations.Name = "Observations";
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(781, 594);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 37);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNewPayment
            // 
            this.btnNewPayment.Image = ((System.Drawing.Image)(resources.GetObject("btnNewPayment.Image")));
            this.btnNewPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewPayment.Location = new System.Drawing.Point(12, 594);
            this.btnNewPayment.Name = "btnNewPayment";
            this.btnNewPayment.Size = new System.Drawing.Size(79, 37);
            this.btnNewPayment.TabIndex = 8;
            this.btnNewPayment.Text = "New Payment";
            this.btnNewPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewPayment.UseVisualStyleBackColor = true;
            this.btnNewPayment.Click += new System.EventHandler(this.btnNewPayment_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(97, 594);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 37);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(781, 66);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(75, 23);
            this.txtBuscar.TabIndex = 22;
            this.txtBuscar.Text = "Search";
            this.txtBuscar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "To:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(296, 65);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(102, 20);
            this.dtpToDate.TabIndex = 20;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(48, 65);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(102, 20);
            this.dtpFromDate.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "From:";
            // 
            // frmPaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 643);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnNewPayment);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.label1);
            this.Name = "frmPaymentList";
            this.Text = "HHRR - PaymentList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEmployeeList_FormClosed);
            this.Load += new System.EventHandler(this.frmEmployeeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPayments;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnNewPayment;
        internal System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observations;
        private System.Windows.Forms.Button txtBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label4;
    }
}