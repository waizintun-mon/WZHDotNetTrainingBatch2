using Microsoft.Identity.Client;
using WZHDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

namespace WZHDotNetTrainingBatch2WinFormsApp1
{
    public partial class FrmStaff : Form
    {
        private readonly AppDbContext _db;
        private int _editId;
        public FrmStaff()
        {
            InitializeComponent();
            _db = new AppDbContext();
            dgvData.AutoGenerateColumns=false;
        }
        private void BindData()
        {
            try
            {
                AppDbContext db = new AppDbContext();
                dgvData.DataSource = db.TblStaffs.Where(x=> x.DeleteFlag==false).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
           
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (_editId == 0)
                {
                    _db.TblStaffs.Add(new TblStaff
                {
                    Email = txtEmail.Text.Trim(),
                    DeleteFlag = false,
                    MobileNo = txtMobileNo.Text.Trim(),
                    Position = cboPosition.Text.Trim(),
                    StaffCode = txtCode.Text.Trim(),
                    StaffName = txtName.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                });
                    int result = _db.SaveChanges();
                    string message = result > 0 ? "saving successful" : "failed";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCode.Clear();
                    txtMobileNo.Clear();
                    txtName.Clear();
                    cboPosition.Text = "";
                    txtEmail.Clear();
                    txtPassword.Clear();

                    txtCode.Focus();

                    BindData();
                }
                else
                {
                    var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == _editId && x.DeleteFlag == false);
                    if (item is null)// someone delete data
                    {
                        return;
                    }


                    item.Email = txtEmail.Text.Trim();
                    item.DeleteFlag = false;
                    item.MobileNo = txtMobileNo.Text.Trim();
                    item.Position = cboPosition.Text.Trim();
                    item.StaffCode = txtCode.Text.Trim();
                    item.StaffName = txtName.Text.Trim();
                    item.Password = txtPassword.Text.Trim();
                    
                    int result = _db.SaveChanges();
                    string message = result > 0 ? "updating successful" : "failed";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCode.Clear();
                    txtMobileNo.Clear();
                    txtName.Clear();
                    cboPosition.Text = "";
                    txtEmail.Clear();
                    txtPassword.Clear();

                    txtCode.Focus();

                    BindData();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


     public void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

           // if (e.ColumnIndex == 0) constant index can change any place
                if (e.ColumnIndex == dgvData.Columns["colEdit"].Index)// best practice
                {
                int id =Convert.ToInt32( dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString());

                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id && x.DeleteFlag == false);
                if (item is null)// someone delete data
                {
                    return;
                }
                txtCode.Text = item.StaffCode;
                txtEmail.Text = item.Email;
                txtName.Text = item.StaffName;
                cboPosition.Text = item.Position;
                txtMobileNo.Text = item.MobileNo;
                txtPassword.Text = item.Password;

              _editId = id;
            }
            else if(e.ColumnIndex == dgvData.Columns["colDelete"].Index)
            {
                var confirm = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return;

                //Delete Process

                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString());

                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id && x.DeleteFlag == false);
                if (item is null)// someone delete data
                {
                    return;
                }
                //        _db.TblStaffs.Remove(item);
                item.DeleteFlag = true;
                int result = _db.SaveChanges();

                string message = result > 0 ? "Deleting successful" : "failed";
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindData();
            }
        }
           
    }
}
