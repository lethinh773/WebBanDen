using BLL;
using DataModel;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopBanDen.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private INhaCungCapBusiness _nhacungcapBusiness;

        public NhaCungCapController(INhaCungCapBusiness nhacungcapBusiness)
        {
            _nhacungcapBusiness = nhacungcapBusiness;
        }
        [NonAction]

        //[AllowAnonymous]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public NhaCungCapModel GetDatabyID(int id)
        {
            return _nhacungcapBusiness.GetDatabyID(id);
        }
        [Route("create-ncc")]
        [HttpPost]
        public NhaCungCapModel CreateItem([FromBody] NhaCungCapModel model)
        {
            _nhacungcapBusiness.Create(model);
            return model;
        }
        [Route("update-ncc")]
        [HttpPost]
        public NhaCungCapModel UpdateItem([FromBody] NhaCungCapModel model)
        {
            _nhacungcapBusiness.Update(model);
            return model;
        }
        [Route("delete-ncc/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _nhacungcapBusiness.Delete(id);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_ncc = "";
                if (formData.Keys.Contains("ten_ncc") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_ncc"]))) { ten_ncc = Convert.ToString(formData["ten_ncc"]); }
                string dia_chi = "";
                if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { dia_chi = Convert.ToString(formData["dia_chi"]); }
                long total = 0;
                var data = _nhacungcapBusiness.Search(page, pageSize, out total, ten_ncc, dia_chi);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
