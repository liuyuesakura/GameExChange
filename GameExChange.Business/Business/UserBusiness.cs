using System;
using System.Collections.Generic;
using System.Text;

using GameExChange.Business.Input.UserBusiness;
using GameExChange.Business.Output.UserBusiness;
using GameExChange.Repository.EntityRepos;
using GameExChange.Domain.Repos;
using GameExChange.Domain.Model;

namespace GameExChange.Business
{
    public class UserBusiness : IBusiness.IUserBusiness
    {

        private readonly IUserRepository _userRepository;

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
            return new RegisterOutput()
            {
                IsSuccess = true,
                Name = user.UserName,
                UserID = user.ID
            };
        }
    }
}
