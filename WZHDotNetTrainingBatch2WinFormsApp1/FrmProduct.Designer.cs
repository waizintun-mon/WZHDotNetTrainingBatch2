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
            ProductId = new Label();
            txtProductId = new TextBox();
            txtProductName = new TextBox();
            ProductName = new Label();
            txtPrice = new TextBox();
            Price = new Label();
            txtDelete = new TextBox();
            label4 = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // ProductId
            // 
            ProductId.AutoSize = true;
            ProductId.Location = new Point(125, 55);
            ProductId.Name = "ProductId";
            ProductId.Size = new Size(73, 20);
            ProductId.TabIndex = 0;
            ProductId.Text = "ProductId";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(125, 78);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(207, 27);
            txtProductId.TabIndex = 1;
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
            // txtDelete
            // 
            txtDelete.Location = new Point(125, 280);
            txtDelete.Name = "txtDelete";
            txtDelete.Size = new Size(207, 27);
            txtDelete.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(125, 248);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 6;
            label4.Text = "DeleteFlag";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(238, 313);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FrmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(txtDelete);
            Controls.Add(label4);
            Controls.Add(txtPrice);
            Controls.Add(Price);
            Controls.Add(txtProductName);
            Controls.Add(ProductName);
            Controls.Add(txtProductId);
            Controls.Add(ProductId);
            Name = "FrmProduct";
            Text = "FrmProduct";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProductId;
        private TextBox txtProductId;
        private TextBox txtProductName;
        private Label ProductName;
        private TextBox txtPrice;
        private Label Price;
        private TextBox txtDelete;
        private Label label4;
        private Button btnSave;
    }
}