using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos.Domain.Features
{
    public class StaffService
    {
        public TblStaff?  Register(int code,string name,string email,string position)
        {
            App2DbContext db = new App2DbContext();
           var item = db.TblStaffs.FirstOrDefault(x => x.StaffCode == code);
            return item;
        }
    }
}
