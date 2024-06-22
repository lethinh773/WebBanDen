using BLL;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopBanDen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        //[AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _userBusiness.Login(model.Email, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.TenTaiKhoan, email = user.Email, token = user.token });
        }

        [Route("create-User")]
        [HttpPost]
        public UserModel CreateItem([FromBody] UserModel model)
        {
            _userBusiness.Create(model);
            return model;
        }
        //----------------------
        [Route("update-User")]
        [HttpPost]
        public UserModel UpdateItem([FromBody] UserModel model)
        {
            _userBusiness.Update(model);
            return model;
        }
        //-----------------
        [Route("delete-User/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _userBusiness.Delete(id);
        }
    }
}
