
using DAL;
using DataModel;
using System.Reflection;

namespace BLL
{
    public class DonHangBussiness : IDonHangBussiness
    {
        private IDonHangRepository res;

        public DonHangBussiness(IDonHangRepository res)
        {
            this.res = res;
        }

        public bool DuyetDon(int id)
        {
            return res.DuyetDon(id);
        }

        public List<ChiTietDonHangBan> getChiTiet(int id)
        {
            return res.getChiTiet(id);
        }

        public DonHangModel getDonHang(int id)
        {
            return res.getDonHang(id);
        }

        public List<DonHangModel> getDS_DH_chuaXN()
        {
            return res.getDS_DH_chuaXN();
        }

        public List<DonHangModel> getDS_DH_daXN()
        {
            return res.getDS_DH_daXN();
        }

        public bool HuyDon(int id)
        {
            return res.HuyDon(id);
        }
    }
}
