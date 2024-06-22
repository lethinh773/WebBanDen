using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial interface ILoaiDenBusiness
    {
        public List<LoaiDenModel> GetAllLoaiDen();
        LoaiDenModel GetLoaiDen(int MaLoai);
        bool Create(LoaiDenModel model);
        bool Update(LoaiDenModel model);
        bool Delete(int id);
        public List<LoaiDenModel> Search(int pageIndex, int pageSize, out long total, string ten_loai);
    }
}