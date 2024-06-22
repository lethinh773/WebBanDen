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
    public class LoaiDenController : ControllerBase
    {
        private ILoaiDenBusiness _loaidenBusiness;
        //private string _path;
        //private IWebHostEnvironment _env;
        public LoaiDenController(ILoaiDenBusiness loaidenBusiness)
        {
            _loaidenBusiness = loaidenBusiness;
        }

        //public string CreatePathFile(string RelativePathFileName)
        //{
        //    try
        //    {
        //        string serverRootPathFolder = _path;
        //        string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
        //        string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
        //        if (!Directory.Exists(fullPathFolder))
        //            Directory.CreateDirectory(fullPathFolder);
        //        return fullPathFile;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        //[Route("upload")]
        //[HttpPost, DisableRequestSizeLimit]
        //public async Task<IActionResult> Upload(IFormFile file)
        //{
        //    try
        //    {
        //        if (file.Length > 0)
        //        {
        //            string filePath = $"upload/{file.FileName}";
        //            var fullPath = CreatePathFile(filePath);
        //            using (var fileStream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(fileStream);
        //            }
        //            return Ok(new { filePath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Không tìm thây");
        //    }
        //}

        //[Route("download")]
        //[HttpPost]
        //public IActionResult DownloadData([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {
        //        var webRoot = _env.ContentRootPath;
        //        string exportPath = Path.Combine(webRoot + @"\Export\DM.xlsx");
        //        var stream = new FileStream(exportPath, FileMode.Open, FileAccess.Read);
        //        return File(stream, "application/octet-stream");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[AllowAnonymous]
        [Route("get-all-loaiden")]
        [HttpGet]
        public List<LoaiDenModel> GetAllLoaiDen()
        {
            return _loaidenBusiness.GetAllLoaiDen();
        }

        [Route("get-by-id-loaiden/{id}")]
        [HttpGet]
        public LoaiDenModel GetDatabyID(int id)
        {
            return _loaidenBusiness.GetLoaiDen(id);
        }
        [Route("create-loaiden")]
        [HttpPost]
        public LoaiDenModel CreateItem([FromBody] LoaiDenModel model)
        {
            _loaidenBusiness.Create(model);
            return model;
        }
        [Route("update-loaiden")]
        [HttpPost]
        public LoaiDenModel UpdateItem([FromBody] LoaiDenModel model)
        {
            _loaidenBusiness.Update(model);
            return model;
        }
        [Route("delete-loaiden/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _loaidenBusiness.Delete(id);
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_loai = "";
                if (formData.Keys.Contains("ten_loai") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_loai"]))) { ten_loai = Convert.ToString(formData["ten_loai"]); }

                long total = 0;
                var data = _loaidenBusiness.Search(page, pageSize, out total, ten_loai);
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

