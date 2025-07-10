using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WZHDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

namespace WZHDotNetTrainingBatch2.WinFormsApp1
{
    public partial class FrmProduct : Form
    {
        private readonly AppDbContext _db;
        private int _editId;
        public FrmProduct()
        {
            InitializeComponent();
            _db = new AppDbContext();
            dgvData.AutoGenerateColumns = false;

        }

        private void BindData()
        {
            try
            {
                dgvData.DataSource = _db.TblProducts.Where(x => x.DeleteFlag == false).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

     
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_editId == 0)
            {
                try
                {

                    _db.TblProducts.Add(new TblProduct
                    {
                        ProductName = txtProductName.Text.Trim(),
                        Price = Convert.ToDecimal(txtPrice.Text.Trim()),
                        DeleteFlag = false
                    });
                    int result = _db.SaveChanges();
                    string message = result > 0 ? "saving successful" : "failed";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtPrice.Clear();
                    txtProductName.Clear();

                    txtProductName.Focus();
                    BindData();
                }
                catch (Exception)
                {

                    throw;
                }
            } else
            {
                var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == _editId && x.DeleteFlag == false);
                if (item == null) return;
                item.ProductName = txtProductName.Text.Trim();
                item.Price =Convert.ToDecimal( txtPrice.Text.Trim());
                int result = _db.SaveChanges();
                string message = result > 0 ? "updating successful" : "failed";
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindData();
                txtProductName.Clear() ;
                txtPrice.Clear();
                txtProductName.Focus() ;
            }
        }


        private void dgvData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

          //  if (e.ColumnIndex == 0)  this is constant
          if(e.ColumnIndex == dgvData.Columns["colEdit"].Index)
            { 
                int id =Convert.ToInt32( dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString());
                var item = _db.TblProducts.FirstOrDefault(x=>x.ProductId == id && x.DeleteFlag == false);
                if (item == null) return;
                txtPrice.Text = item.Price.ToString();
                txtProductName.Text = item.ProductName;
                _editId = id;
            }
            else if (e.ColumnIndex == dgvData.Columns["colDelete"].Index)
            {
               var confirm = MessageBox.Show("Are you sure want to delete? ","", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return;
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString());
                var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id && x.DeleteFlag == false);
                if (item == null) return;
                item.DeleteFlag = true;
                var result = _db.SaveChanges();
                MessageBox.Show(result > 0 ? "Deleting successful":"failed");
                BindData();
            }
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
