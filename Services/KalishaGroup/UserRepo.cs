using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;
using UserManagement.DBManagementFiles.KalishaGroup;
using UserManagement.Interface;
using UserManagement.Interface.KalishaGroup;
using UserManagement.Models.KalishaGroup.RequestModel;
using UserManagement.Models.KalishaGroup.ResponseModel;

namespace UserManagement.Services.KalishaGroup
{
    public class UserRepo : IUser
    {
        private readonly IDbService _Db;
        public UserRepo(IDbService DbService)
        {
            _Db = DbService;
        }
        public async Task<UserResponseModel> CreateUser(UserRequestModel userRequestModel)
        {
            UserResponseModel ResMlodel = new UserResponseModel();

            return  ResMlodel;
        }

        public Task<UserResponseModel> GetUser(UserRequestModel userRequestModel)
        {
            var response = new UserResponseModel();

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
