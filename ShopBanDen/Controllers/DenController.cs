using BLL;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopBanDen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenController: ControllerBase
    {
        private IDenBusiness _DenBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public DenController(IDenBusiness DenBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _DenBusiness = DenBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;

        }
        [NonAction]
        public string CreatePathFile(string RelativePathFileName)
        {
            try
            {
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                return fullPathFile;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("upload")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string filePath = $"upload/{file.FileName}";
                    var fullPath = CreatePathFile(filePath);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Không tìm thây");
            }
        }

        [Route("download")]
        [HttpPost]
        public IActionResult DownloadData([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var webRoot = _env.ContentRootPath;
                string exportPath = Path.Combine(webRoot + @"\Export\DM.xlsx");
                var stream = new FileStream(exportPath, FileMode.Open, FileAccess.Read);
                return File(stream, "application/octet-stream");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //--------------------------------
        //[AllowAnonymous]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public DenModel GetDatabyID(int id)
        {
            return _DenBusiness.GetChiTietDen(id);
        }

        //--------------------------------------------------
        [Route("create-Den")]
        [HttpPost]
        public CreateDenModel CreateItem([FromBody] CreateDenModel model)
        {
            _DenBusiness.Create(model);
            return model;
        }
        //----------------------
        [Route("update-Den")]
        [HttpPost]
        public CreateDenModel UpdateItem([FromBody] CreateDenModel model)
        {
            _DenBusiness.Update(model);
            return model;
        }
        //-----------------
        [Route("delete-Den/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _DenBusiness.Delete(id);
        }
        //------
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_den = "";
                if (formData.Keys.Contains("ten_den") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_den"]))) { ten_den = Convert.ToString(formData["ten_den"]); }

                long total = 0;
                var data = _DenBusiness.Search(page, pageSize, out total, ten_den);
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
