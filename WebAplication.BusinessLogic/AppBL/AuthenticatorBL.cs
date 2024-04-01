﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.BusinessLogic.Core;
using WebAplication.BusinessLogic.Interface;
using WebAplication.BusinessLogics.Core;
using WebAplication.BusinessLogics.Interface;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.AppBL
{
    public class AuthenticatorBL : UserApi, ILogin
    {
        public ULoginResp UserLoginAction(ULoginData data)
        {
            return RLoginUPService(data);
        }

    }
}