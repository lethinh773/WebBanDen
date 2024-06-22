using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial interface IUserRepository
    {
        UserModel Login(string taikhoan, string matkhau);
    }
}
