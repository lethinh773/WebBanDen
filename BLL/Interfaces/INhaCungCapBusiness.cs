using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial interface INhaCungCapBusiness
    {
        NhaCungCapModel GetDatabyID(int id);
        bool Create(NhaCungCapModel model);
        bool Update(NhaCungCapModel model);
        bool Delete(int id);
        public List<NhaCungCapModel> Search(int pageIndex, int pageSize, out long total, string ten_ncc, string dia_chi);
    }
}
