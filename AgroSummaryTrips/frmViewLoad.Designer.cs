namespace AgroSummaryTrips
{
    partial class frmViewLoad
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtComTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTReq = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtINV = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDwell = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtTruckOut = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dtDocRec = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFLoad = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dtFCheck = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtSLoad = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtSCheck = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtChecklist = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtTruckIn = new System.Windows.Forms.DateTimePicker();
            this.lblTripNum = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Commitment Time:";
            // 
            // dtComTime
            // 
            this.dtComTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtComTime.Enabled = false;
            this.dtComTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtComTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtComTime.Location = new System.Drawing.Point(103, 3);
            this.dtComTime.Name = "dtComTime";
            this.dtComTime.Size = new System.Drawing.Size(122, 20);
            this.dtComTime.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cases:";
            // 
            // txtLN
            // 
            this.txtLN.Enabled = false;
            this.txtLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLN.Location = new System.Drawing.Point(103, 60);
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(125, 20);
            this.txtLN.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Truck Req:";
            // 
            // txtTReq
            // 
            this.txtTReq.Enabled = false;
            this.txtTReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTReq.Location = new System.Drawing.Point(178, 33);
            this.txtTReq.Name = "txtTReq";
            this.txtTReq.Size = new System.Drawing.Size(47, 20);
            this.txtTReq.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Invoice # / CDN";
            // 
            // txtINV
            // 
            this.txtINV.Enabled = false;
            this.txtINV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtINV.Location = new System.Drawing.Point(7, 99);
            this.txtINV.Multiline = true;
            this.txtINV.Name = "txtINV";
            this.txtINV.Size = new System.Drawing.Size(221, 83);
            this.txtINV.TabIndex = 15;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(231, 163);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 13);
            this.label23.TabIndex = 261;
            this.label23.Text = "Dwell Time";
            // 
            // txtDwell
            // 
            this.txtDwell.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDwell.Enabled = false;
            this.txtDwell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDwell.Location = new System.Drawing.Point(301, 160);
            this.txtDwell.Name = "txtDwell";
            this.txtDwell.Size = new System.Drawing.Size(69, 20);
            this.txtDwell.TabIndex = 260;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(373, 122);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 259;
            this.label19.Text = "Truck Out";
            // 
            // dtTruckOut
            // 
            this.dtTruckOut.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtTruckOut.Enabled = false;
            this.dtTruckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTruckOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTruckOut.Location = new System.Drawing.Point(376, 138);
            this.dtTruckOut.Name = "dtTruckOut";
            this.dtTruckOut.Size = new System.Drawing.Size(136, 20);
            this.dtTruckOut.TabIndex = 251;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(231, 122);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 13);
            this.label18.TabIndex = 258;
            this.label18.Text = "Document Received";
            // 
            // dtDocRec
            // 
            this.dtDocRec.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtDocRec.Enabled = false;
            this.dtDocRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDocRec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDocRec.Location = new System.Drawing.Point(234, 138);
            this.dtDocRec.Name = "dtDocRec";
            this.dtDocRec.Size = new System.Drawing.Size(136, 20);
            this.dtDocRec.TabIndex = 250;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(373, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 257;
            this.label5.Text = "Finish Loading";
            // 
            // dtFLoad
            // 
            this.dtFLoad.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtFLoad.Enabled = false;
            this.dtFLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFLoad.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFLoad.Location = new System.Drawing.Point(376, 99);
            this.dtFLoad.Name = "dtFLoad";
            this.dtFLoad.Size = new System.Drawing.Size(136, 20);
            this.dtFLoad.TabIndex = 249;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(373, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 256;
            this.label17.Text = "Finish Checking";
            // 
            // dtFCheck
            // 
            this.dtFCheck.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtFCheck.Enabled = false;
            this.dtFCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFCheck.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFCheck.Location = new System.Drawing.Point(376, 60);
            this.dtFCheck.Name = "dtFCheck";
            this.dtFCheck.Size = new System.Drawing.Size(136, 20);
            this.dtFCheck.TabIndex = 247;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(231, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 255;
            this.label9.Text = "Start Loading";
            // 
            // dtSLoad
            // 
            this.dtSLoad.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtSLoad.Enabled = false;
            this.dtSLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSLoad.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSLoad.Location = new System.Drawing.Point(234, 99);
            this.dtSLoad.Name = "dtSLoad";
            this.dtSLoad.Size = new System.Drawing.Size(136, 20);
            this.dtSLoad.TabIndex = 248;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(231, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 254;
            this.label8.Text = "Start Checking";
            // 
            // dtSCheck
            // 
            this.dtSCheck.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtSCheck.Enabled = false;
            this.dtSCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSCheck.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSCheck.Location = new System.Drawing.Point(234, 60);
            this.dtSCheck.Name = "dtSCheck";
            this.dtSCheck.Size = new System.Drawing.Size(136, 20);
            this.dtSCheck.TabIndex = 246;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(373, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 253;
            this.label7.Text = "Checklist";
            // 
            // dtChecklist
            // 
            this.dtChecklist.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtChecklist.Enabled = false;
            this.dtChecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtChecklist.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChecklist.Location = new System.Drawing.Point(376, 21);
            this.dtChecklist.Name = "dtChecklist";
            this.dtChecklist.Size = new System.Drawing.Size(136, 20);
            this.dtChecklist.TabIndex = 245;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(231, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 252;
            this.label6.Text = "Truck In";
            // 
            // dtTruckIn
            // 
            this.dtTruckIn.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtTruckIn.Enabled = false;
            this.dtTruckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTruckIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTruckIn.Location = new System.Drawing.Point(234, 21);
            this.dtTruckIn.Name = "dtTruckIn";
            this.dtTruckIn.Size = new System.Drawing.Size(136, 20);
            this.dtTruckIn.TabIndex = 244;
            // 
            // lblTripNum
            // 
            this.lblTripNum.AutoSize = true;
            this.lblTripNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTripNum.Location = new System.Drawing.Point(96, 65);
            this.lblTripNum.Name = "lblTripNum";
            this.lblTripNum.Size = new System.Drawing.Size(0, 13);
            this.lblTripNum.TabIndex = 262;
            this.lblTripNum.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 263;
            this.label10.Text = "Load Number:";
            // 
            // frmViewLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(518, 185);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTripNum);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtDwell);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dtTruckOut);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dtDocRec);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFLoad);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dtFCheck);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtSLoad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtSCheck);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtChecklist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtTruckIn);
            this.Controls.Add(this.txtINV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTReq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtComTime);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Details";
            this.Load += new System.EventHandler(this.frmViewLoad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtComTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTReq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtINV;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtDwell;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtTruckOut;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtDocRec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtFLoad;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtFCheck;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtSLoad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtSCheck;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtChecklist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtTruckIn;
        public System.Windows.Forms.Label lblTripNum;
        private System.Windows.Forms.Label label10;
    }
}