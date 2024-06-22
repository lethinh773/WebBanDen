using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial interface IKhachRepository
    {
        KhachModel GetDatabyID(int id);
        bool Create(KhachModel model);
        bool Update(KhachModel model);
        bool Delete(int id);
        public List<KhachModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi);
    }
}
