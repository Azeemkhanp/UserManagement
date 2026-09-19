using System;
using System.Threading.Tasks;
using UserManagement.Interface;
using UserManagement.Models.RequestModel;
using UserManagement.Models.ResponseModel;

namespace UserManagement.Services
{
    public class UserRepo : IUser
    {
        public async Task<UserResponseModel> CreateUser(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseModel> GetUser(UserRequestModel userRequestModel)
        {
            var response = new UserResponseModel
            {
                UserModel = new UserRequestModel
                {
                    UserName = "azeemkhan",
                    Email = "azeemkhan@gmail.com",
                    FirstName = "Azeem",
                    LastName = "Khan",
                    PhoneNumber = "1234567890",
                    Address = "123 Main St, City, Country"
                }
            };

            return Task.FromResult(response);
        }

        public async  Task<UserResponseModel> UpdateUser(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> DeleteUser(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetAllUser(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserById(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserByEmail(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserByPhone(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserByUsername(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }

        public async  Task<UserResponseModel> GetUserByRole(UserRequestModel userRequestModel)
        {
            throw new NotImplementedException();
        }
    }
}
