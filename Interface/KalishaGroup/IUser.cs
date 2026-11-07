using UserManagement.CommanFiles.KalishaGroup;
using UserManagement.DTOs.KalishaGroupDTOs.RequestDtos;
using UserManagement.Models.KalishaGroup.RequestModel;
namespace UserManagement.Interface.KalishaGroup
{
    public interface IUser
    {
        public Task<RegisterUserDTOs> CreateUser(RegisterUserDTOs userRequestModel);
        public Task<LoginResponseDTOs> Login(LoginDto userRequestModel);
        public Task<BaseModel> UpdateUser(UpdateUserDTOs userRequestModel);

        public Task<BaseModel> ChangePassword(UpdatePasswordRequestDto userRequestModel);
        public Task<BaseModel> ForgotPassword(ForgotPasswordRequestDto userRequestModel);
        public Task<BaseModel> ResetPassword(ResetPasswordRequestDto userRequestModel);

        public Task<BaseModel> DeleteUser(User userRequestModel);
        public Task<List<GetUserDtoBasedOnLogin>> GetAllUser(UserDtoBasedOnLoginRequest userRequestModel);
        public Task<GetUserDtoBasedOnLogin> GetUserById(UserDtoBasedOnLoginRequest userRequestModel);
        public Task<GetUserDtoBasedOnLogin> GetUserByEmail(UserDtoBasedOnLoginRequest userRequestModel);
        public Task<GetUserDtoBasedOnLogin> GetUserByPhone(UserDtoBasedOnLoginRequest userRequestModel);
        public Task<GetUserDtoBasedOnLogin> GetUserByUsername(UserDtoBasedOnLoginRequest userRequestModel);
        public Task<List<GetUserDtoBasedOnLogin>> GetUserByRole(UserDtoBasedOnLoginRequest userRequestModel);
        public Task<int> LogoutUser(string refreshToken);
    }
}
