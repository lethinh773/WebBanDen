﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial interface IUserBusiness
    {
        UserModel Login(string email, string matkhau);
        bool Create(UserModel model);
        bool Update(UserModel model);
        bool Delete(int id);
    }
}

