using MediatR;
using UserManagement.Models.RequestModel;
using UserManagement.Models.ResponseModel;

namespace UserManagement.CQRS.Command
{
    public class UserLoginCommand : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
    public class UserRegisterCommand : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
    public class UserLogoutCommand : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
    public class UserUpdateProfileCommand : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
    public class UserChangePasswordCommand : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
    public class UserForgotPasswordCommand : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
    public class UserResetPasswordCommand : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
    public class UserDeleteAccountCommand : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
}
