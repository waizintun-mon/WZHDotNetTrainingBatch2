namespace WZHDotNetTrainingBatch2WinFormsApp1
{
    partial class FrmStaff
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            label1 = new Label();
            txtCode = new TextBox();
            txtName = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtMobileNo = new TextBox();
            label6 = new Label();
            cboPosition = new ComboBox();
            dgvData = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colId = new DataGridViewTextBoxColumn();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDeleteFlag = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(175, 394);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 31);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 1;
            label1.Text = "Staff Code";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(57, 54);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(212, 27);
            txtCode.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(57, 116);
            txtName.Name = "txtName";
            txtName.Size = new Size(212, 27);
            txtName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 93);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 3;
            label2.Text = "Staff Name";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(57, 168);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(212, 27);
            txtEmail.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 145);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 5;
            label3.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(57, 232);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(212, 27);
            txtPassword.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 209);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 7;
            label4.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 266);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 9;
            label5.Text = "Position";
            // 
            // txtMobileNo
            // 
            txtMobileNo.Location = new Point(57, 350);
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Size = new Size(212, 27);
            txtMobileNo.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(57, 327);
            label6.Name = "label6";
            label6.Size = new Size(80, 20);
            label6.TabIndex = 11;
            label6.Text = "Mobile No";
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Items.AddRange(new object[] { "--Select one--", "Admin", "Staff" });
            cboPosition.Location = new Point(57, 289);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(212, 28);
            cboPosition.TabIndex = 13;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colId, colCode, colName, colDeleteFlag, colPosition });
            dgvData.Location = new Point(275, 41);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(655, 336);
            dgvData.TabIndex = 14;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 6;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 125;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Width = 125;
            // 
            // colId
            // 
            colId.DataPropertyName = "StaffId";
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colCode
            // 
            colCode.DataPropertyName = "StaffCode";
            colCode.HeaderText = "Staff Code";
            colCode.MinimumWidth = 6;
            colCode.Name = "colCode";
            colCode.ReadOnly = true;
            colCode.Width = 125;
            // 
            // colName
            // 
            colName.DataPropertyName = "StaffName";
            colName.HeaderText = "Staff Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 125;
            // 
            // colDeleteFlag
            // 
            colDeleteFlag.DataPropertyName = "DeleteFlag";
            colDeleteFlag.HeaderText = "DeleteFlag";
            colDeleteFlag.MinimumWidth = 6;
            colDeleteFlag.Name = "colDeleteFlag";
            colDeleteFlag.ReadOnly = true;
            colDeleteFlag.Width = 125;
            // 
            // colPosition
            // 
            colPosition.DataPropertyName = "Position";
            colPosition.HeaderText = "Position";
            colPosition.MinimumWidth = 6;
            colPosition.Name = "colPosition";
            colPosition.ReadOnly = true;
            colPosition.Width = 125;
            // 
            // FrmStaff
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 450);
            Controls.Add(dgvData);
            Controls.Add(cboPosition);
            Controls.Add(txtMobileNo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtCode);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Name = "FrmStaff";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Label label1;
        private TextBox txtCode;
        private TextBox txtName;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtPassword;
        private Label label4;
        private Label label5;
        private TextBox txtMobileNo;
        private Label label6;
        private ComboBox cboPosition;
        private DataGridView dgvData;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDeleteFlag;
        private DataGridViewTextBoxColumn colPosition;
    }
}
