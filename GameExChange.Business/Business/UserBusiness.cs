
using GameExChange.Business.Input.UserBusiness;
using GameExChange.Business.Output.UserBusiness;
using GameExChange.Domain.Model;
using GameExChange.Domain.Repos;
using System.Linq;

namespace GameExChange.Business
{
    public class UserBusiness : ApplicationService, IBusiness.IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IRepositoryContext context, IUserRepository userRepository) : base(context)
        {
            _userRepository = userRepository;
        }

        public DetailModifyOutput DetailModify(DetailModifyInput input)
        {
            User user = _userRepository.GetByKey(input.Id);
            if(!string.IsNullOrEmpty(input.UserName))
            {
                var users = _userRepository.GetAll(x => x.UserName == input.UserName, SortOrder.Ascending).ToList();
                if(users.Count >= 0)
                {
                    return new DetailModifyOutput()
                    {
                        IsSuccess = false,
                        ErrMessage = "�û����ѱ�ʹ��",
                    };
                }
                user.UserName = input.UserName;
            }
            if(!string.IsNullOrEmpty(input.Email))
            {
                var users = _userRepository.GetAll(x => x.Email == input.Email, SortOrder.Ascending).ToList();
                if (users.Count >= 0)
                {
                    return new DetailModifyOutput()
                    {
                        IsSuccess = false,
                        ErrMessage = "�����ѱ�ʹ��",
                    };
                }
                user.Email = input.Email;
            }
            if (!string.IsNullOrEmpty(input.Phone))
            {
                var users = _userRepository.GetAll(x => x.Phone == input.Phone, SortOrder.Ascending).ToList();
                if (users.Count >= 0)
                {
                    return new DetailModifyOutput()
                    {
                        IsSuccess = false,
                        ErrMessage = "�ֻ����ѱ�ʹ��",
                    };
                }
                user.Phone = input.Phone;
            }
            if (!string.IsNullOrEmpty(input.QQ))
            {
                var users = _userRepository.GetAll(x => x.QQ == input.QQ, SortOrder.Ascending).ToList();
                if (users.Count >= 0)
                {
                    return new DetailModifyOutput()
                    {
                        IsSuccess = false,
                        ErrMessage = "QQ���ѱ�ʹ��",
                    };
                }
                user.QQ = input.QQ;
            }
            _userRepository.Update(user);
            return new DetailModifyOutput()
            {
                IsSuccess = true,
                //ErrMessage = "ԭ�������",
            };
        }

        public PasswordModifyOutput PasswordModify(PasswordModifyInput input)
        {
            User user = _userRepository.GetByKey(input.Id);
            if(user.Password != input.OldPwd)
            {
                return new PasswordModifyOutput()
                {
                    IsSuccess = false,
                    ErrMessage = "ԭ�������",
                };
            }
            user.Password = input.NewPwd;

            _userRepository.Update(user);

            return new PasswordModifyOutput()
            {
                IsSuccess = true,
                //ErrMessage = "ԭ�������",
            };
        }
        public LoginOutput Login(LoginInput input)
        {
            var user =
            _userRepository.GetByExpression(x =>
                (x.UserName == input.UserName || x.Phone == input.Mobile || x.Email == input.Email) && 
                x.Password == input.Password
            );
            if(user != null && user.ID > 0)
            {
                return new LoginOutput()
                {
                    IsSuccess = true,
                    //ErrMessage = "ָ�����û�������"
                    UserId = user.ID,
                    UserName = user.UserName
                };
            }
            else
            {
                return new LoginOutput()
                {
                    IsSuccess = false,
                    ErrMessage = "ָ�����û�������"
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
            this.RepositoryContext.Commit();

            return new RegisterOutput()
            {
                IsSuccess = true,
                Name = user.UserName,
                UserID = user.ID
            };
        }

    }
}
