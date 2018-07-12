
using GameExChange.Business.Input.UserBusiness;
using GameExChange.Business.Output.UserBusiness;
using GameExChange.Entity;
using GameExChange.Repository.Contract;
using System.Linq;
using GameExChange.Infrastructure.Interface;

namespace GameExChange.Business
{

    //内部判断逻辑移动到仓储中？？？
    public class UserBusiness :  IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserBusiness(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public DetailModifyOutput DetailModify(DetailModifyInput input)
        {
            User user = _userRepository.GetByID(input.Id);
            if(!string.IsNullOrEmpty(input.UserName))
            {
                var tempuser = _userRepository.Get(x => x.UserName == input.UserName);
                if(tempuser != null)
                {
                    return new DetailModifyOutput()
                    {
                        IsSuccess = false,
                        ErrMessage = "用户名已被使用",
                    };
                }
                user.UserName = input.UserName;
            }
            if(!string.IsNullOrEmpty(input.Email))
            {
                var tempuser = _userRepository.Get(x => x.Email == input.Email);
                if (tempuser != null)
                {
                    return new DetailModifyOutput()
                    {
                        IsSuccess = false,
                        ErrMessage = "邮箱已被使用",
                    };
                }
                user.Email = input.Email;
            }
            if (!string.IsNullOrEmpty(input.Phone))
            {
                var tempuser = _userRepository.Get(x => x.Phone == input.Phone);
                if (tempuser != null)
                {
                    return new DetailModifyOutput()
                    {
                        IsSuccess = false,
                        ErrMessage = "手机号已被使用",
                    };
                }
                user.Phone = input.Phone;
            }
            if (!string.IsNullOrEmpty(input.QQ))
            {
                var tempuser = _userRepository.Get(x => x.QQ == input.QQ);
                if (tempuser != null)
                {
                    return new DetailModifyOutput()
                    {
                        IsSuccess = false,
                        ErrMessage = "QQ号已被使用",
                    };
                }
                user.QQ = input.QQ;
            }
            _userRepository.Update(user);
            _unitOfWork.Commit();
            return new DetailModifyOutput()
            {
                IsSuccess = true,
                //ErrMessage = "原密码错误",
            };
        }

        public PasswordModifyOutput PasswordModify(PasswordModifyInput input)
        {
            User user = _userRepository.GetByID(input.Id);
            if(user.Password != input.OldPwd)
            {
                return new PasswordModifyOutput()
                {
                    IsSuccess = false,
                    ErrMessage = "原密码错误",
                };
            }
            user.Password = input.NewPwd;

            _userRepository.Update(user);
            _unitOfWork.Commit();
            return new PasswordModifyOutput()
            {
                IsSuccess = true,
                //ErrMessage = "原密码错误",
            };
        }
        public LoginOutput Login(LoginInput input)
        {
            var user =
            _userRepository.Get(x =>
                (x.UserName == input.UserName || x.Phone == input.Mobile || x.Email == input.Email) && 
                x.Password == input.Password
            );
            if(user != null && user.Id > 0)
            {
                return new LoginOutput()
                {
                    IsSuccess = true,
                    //ErrMessage = "指定的用户不存在"
                    UserId = user.Id,
                    UserName = user.UserName
                };
            }
            else
            {
                return new LoginOutput()
                {
                    IsSuccess = false,
                    ErrMessage = "指定的用户不存在"
                };
            }

        }

        public RegisterOutput Register(RegisterInput input)
        {
            //this is sample!!!!
            var user = new User()
            {
                Address = string.Empty,
                UserName = input.Mobile,
                Phone = input.Mobile,
                Password = input.Password,
                City = string.Empty,
                Email = string.Empty,
                Nationality = string.Empty,
                Province = string.Empty,
                QQ = string.Empty
            };
            _userRepository.Add(user);
            _unitOfWork.Commit();

            return new RegisterOutput()
            {
                IsSuccess = true,
                Name = user.UserName,
                UserID = user.Id
            };
        }

    }
}
