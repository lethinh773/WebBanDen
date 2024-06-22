using DAL;
using DataModel;

namespace BLL
{
    public class NhaCungCapBusiness : INhaCungCapBusiness
    {
        private INhaCungCapRepository _res;
        public NhaCungCapBusiness(INhaCungCapRepository res)
        {
            _res = res;
        }
        public NhaCungCapModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(NhaCungCapModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhaCungCapModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public List<NhaCungCapModel> Search(int pageIndex, int pageSize, out long total, string ten_ncc, string dia_chi)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_ncc, dia_chi);
        }
    }
}