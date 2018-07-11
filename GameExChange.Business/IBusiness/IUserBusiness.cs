using IB = GameExChange.Business.Input.UserBusiness;
using OB = GameExChange.Business.Output.UserBusiness;

namespace GameExChange.Business
{
    public interface IUserBusiness : IBusinessMark
    {
        OB.RegisterOutput Register(IB.RegisterInput input);
        OB.LoginOutput Login(IB.LoginInput input);
        OB.DetailModifyOutput DetailModify(IB.DetailModifyInput input);
        OB.PasswordModifyOutput PasswordModify(IB.PasswordModifyInput input);
    }
}
