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
        bool Create(UserModel model);
        bool Update(UserModel model);
        bool Delete(int id);
    }
}