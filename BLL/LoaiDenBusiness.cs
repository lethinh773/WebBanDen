using DAL;
using DataModel;

namespace BLL
{
    public class LoaiDenBusiness : ILoaiDenBusiness
    {
        private ILoaiDenRepository _res;
        public LoaiDenBusiness(ILoaiDenRepository res)
        {
            _res = res;
        }
        public List<LoaiDenModel> GetAllLoaiDen()
        {
            return _res.GetAllLoaiDen(); 
        }

        public LoaiDenModel GetLoaiDen(int MaLoai)
        {
            return _res.GetLoaiDen(MaLoai);
        }
        public bool Create(LoaiDenModel model)
        {
            return _res.Create(model);
        }
        public bool Update(LoaiDenModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public List<LoaiDenModel> Search(int pageIndex, int pageSize, out long total, string ten_loai)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_loai);
        }
    }
}