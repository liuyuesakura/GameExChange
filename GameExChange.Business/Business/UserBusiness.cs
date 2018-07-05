
using GameExChange.Business.Input.UserBusiness;
using GameExChange.Business.Output.UserBusiness;
using GameExChange.Domain.Model;
using GameExChange.Domain.Repos;

namespace GameExChange.Business
{
    public class UserBusiness : ApplicationService, IBusiness.IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IRepositoryContext context, IUserRepository userRepository) : base(context)
        {
            _userRepository = userRepository;
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
