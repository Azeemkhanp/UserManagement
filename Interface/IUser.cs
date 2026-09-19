using UserManagement.Models.RequestModel;
using UserManagement.Models.ResponseModel;

namespace UserManagement.Interface
{
    public interface IUser
    {
        public Task<UserResponseModel> CreateUser(UserRequestModel userRequestModel);
        public Task<UserResponseModel> GetUser(UserRequestModel userRequestModel);
        public Task<UserResponseModel> UpdateUser(UserRequestModel userRequestModel);
        public Task<UserResponseModel> DeleteUser(UserRequestModel userRequestModel);
        public Task<UserResponseModel> GetAllUser(UserRequestModel userRequestModel);
        public Task<UserResponseModel> GetUserById(UserRequestModel userRequestModel);
        public Task<UserResponseModel> GetUserByEmail(UserRequestModel userRequestModel);
        public Task<UserResponseModel> GetUserByPhone(UserRequestModel userRequestModel);
        public Task<UserResponseModel> GetUserByUsername(UserRequestModel userRequestModel);
        public Task<UserResponseModel> GetUserByRole(UserRequestModel userRequestModel);
    }
}
