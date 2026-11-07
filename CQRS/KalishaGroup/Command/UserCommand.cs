using MediatR;
using UserManagement.CommanFiles.KalishaGroup;
using UserManagement.DTOs.KalishaGroupDTOs.RequestDtos;
using UserManagement.Models.KalishaGroup.RequestModel;

namespace UserManagement.CQRS.KalishaGroup.Command
{
    public class UserLoginCommand : IRequest<LoginResponseDTOs>
    {
        public LoginDto ReqModel { get; set; }
    }
    public class UserRegisterCommand : IRequest<RegisterUserDTOs>
    {
        public RegisterUserDTOs ReqModel { get; set; }
    }
    public class UserLogoutCommand : IRequest<int>
    {
        public string RefreshToken { get; set; }
    }
    public class UserUpdateProfileCommand : IRequest<BaseModel>
    {
        public UpdateUserDTOs ReqModel { get; set; }
    }
    public class UserChangePasswordCommand : IRequest<BaseModel>
    {
        public UpdatePasswordRequestDto ReqModel { get; set; }
    }
    public class UserForgotPasswordCommand : IRequest<BaseModel>
    {
        public ForgotPasswordRequestDto ReqModel { get; set; }
    }
    public class UserResetPasswordCommand : IRequest<BaseModel>
    {
        public ResetPasswordRequestDto ReqModel { get; set; }
    }
    public class UserDeleteAccountCommand : IRequest<BaseModel>
    {
        public User ReqModel { get; set; }
    }
}
