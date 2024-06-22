using DAL;
using DataModel;
using System.Reflection;

namespace BLL
{
    public class DenBusiness : IDenBusiness
    {
        private IDenRepository _res;
        public DenBusiness(IDenRepository res)
        {
            _res = res;
        }
        public DenModel GetChiTietDen(int MaDen)
        {
            return _res.GetChiTietDen(MaDen);
        }
        public bool Create(CreateDenModel model)
        {
            return _res.Create(model);
        }
        public bool Update(CreateDenModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public List<DenModel> Search(int pageIndex, int pageSize, out long total, string ten_den)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_den);
        }
    }
}