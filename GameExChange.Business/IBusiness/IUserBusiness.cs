using System;
using System.Collections.Generic;
using System.Text;
using IB = GameExChange.Business.Input.UserBusiness;
using OB = GameExChange.Business.Output.UserBusiness;

namespace GameExChange.Business.IBusiness
{
    public interface IUserBusiness
    {
        OB.RegisterOutput Register(IB.RegisterInput input);
    }
}
