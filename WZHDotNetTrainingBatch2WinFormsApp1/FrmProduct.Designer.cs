namespace WZHDotNetTrainingBatch2.WinFormsApp1
{
    partial class FrmProduct
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
            txtProductName = new TextBox();
            ProductName = new Label();
            txtPrice = new TextBox();
            Price = new Label();
            btnSave = new Button();
            dgvData = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colDeleteFlag = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(125, 144);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(207, 27);
            txtProductName.TabIndex = 3;
            // 
            // ProductName
            // 
            ProductName.AutoSize = true;
            ProductName.Location = new Point(125, 121);
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(104, 20);
            ProductName.TabIndex = 2;
            ProductName.Text = "Product Name";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(125, 207);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(207, 27);
            txtPrice.TabIndex = 5;
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Location = new Point(125, 184);
            Price.Name = "Price";
            Price.Size = new Size(41, 20);
            Price.TabIndex = 4;
            Price.Text = "Price";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(238, 253);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colId, colProductName, colPrice, colDeleteFlag });
            dgvData.Location = new Point(390, 94);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(536, 188);
            dgvData.TabIndex = 9;
            dgvData.CellContentClick += dgvData_CellContentClick_1;
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
            colId.DataPropertyName = "ProductId";
            colId.HeaderText = "Product Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colProductName
            // 
            colProductName.DataPropertyName = "ProductName";
            colProductName.HeaderText = "Product Name";
            colProductName.MinimumWidth = 6;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            colProductName.Width = 125;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Price";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Width = 125;
            // 
            // colDeleteFlag
            // 
            colDeleteFlag.DataPropertyName = "DeleteFlag";
            colDeleteFlag.HeaderText = "Delete Flag";
            colDeleteFlag.MinimumWidth = 6;
            colDeleteFlag.Name = "colDeleteFlag";
            colDeleteFlag.ReadOnly = true;
            colDeleteFlag.Visible = false;
            colDeleteFlag.Width = 125;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 450);
            Controls.Add(dgvData);
            Controls.Add(btnSave);
            Controls.Add(txtPrice);
            Controls.Add(Price);
            Controls.Add(txtProductName);
            Controls.Add(ProductName);
            Name = "FrmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmProduct";
            Load += FrmProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtProductName;
        private Label ProductName;
        private TextBox txtPrice;
        private Label Price;
        private Button btnSave;
        private DataGridView dgvData;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colDeleteFlag;
    }
}