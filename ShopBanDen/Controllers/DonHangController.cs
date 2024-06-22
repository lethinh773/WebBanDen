using BLL;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopBanDen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private IDonHangBussiness bus;

        public DonHangController(IDonHangBussiness bus)
        {
            this.bus = bus;
        }
        [Route("get-dsdh-chuaduyet")]
        [HttpGet]
        public List<DonHangModel> getDS_DH_chuaXN()
        {
            return bus.getDS_DH_chuaXN();
        }
        [Route("duyet-don-hang/{id}")]
        [HttpPost]
        public bool DuyetDon(int id)
        {
            return bus.DuyetDon(id);
        }
        [Route("get-chiTiet-dh/{id}")]
        [HttpGet]
        public List<ChiTietDonHangBan> getChiTiet(int id)
        {
            return bus.getChiTiet(id);
        }


        [Route("get-dsdh-daduyet")]
        [HttpGet]
        public List<DonHangModel> getDS_DH_daXN()
        {
            return bus.getDS_DH_daXN();
        }
        [Route("huy-don-hang/{id}")]
        [HttpPost]
        public bool HuyDon(int id)
        {
            return bus.HuyDon(id);
        }
        [Route("get-don-hang/{id}")]
        [HttpPost]
        public DonHangModel getDonHang(int id)
        {
            return bus.getDonHang(id);
        }

    }
}
