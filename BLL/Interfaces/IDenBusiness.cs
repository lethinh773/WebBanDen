using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial interface IDenBusiness
    {
        DenModel GetChiTietDen(int MaDen);
        bool Create(CreateDenModel model);
        bool Update(CreateDenModel model);
        bool Delete(int id);
        public List<DenModel> Search(int pageIndex, int pageSize, out long total, string ten_den);
    }
}
