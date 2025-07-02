using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZHDotNetTrainingBatch2.MiniPos.DataBase.App2DbContextModels;

namespace WZHDotNetTrainingBatch2.MiniPos.Domain.Features
{
    internal class StaffRegisteration
    {
        public TblStaff?  FindStaff(int code)
        {
            App2DbContext db = new App2DbContext();
           var item = db.TblStaffs.FirstOrDefault(x => x.StaffCode == code);
            return item;
        }
    }
}
