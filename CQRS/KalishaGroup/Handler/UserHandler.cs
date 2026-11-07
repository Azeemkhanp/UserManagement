using MediatR;
using UserManagement.CommanFiles.KalishaGroup;
using UserManagement.CQRS.KalishaGroup.Command;
using UserManagement.DTOs.KalishaGroupDTOs.RequestDtos;
using UserManagement.Interface.KalishaGroup;

namespace UserManagement.CQRS.KalishaGroup.Handler
{
    public class UserLoginHandler : IRequestHandler<UserLoginCommand, LoginResponseDTOs>
    {
        private readonly IUser _user;
        public UserLoginHandler(IUser user)
        {
            _user = user;
        }
        public async Task<LoginResponseDTOs> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            return await _user.Login(request.ReqModel);
        }
    }

    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, RegisterUserDTOs>
    {
        private readonly IUser _user;
        public UserRegisterHandler(IUser user)
        {
            _user = user;
        }
        public async Task<RegisterUserDTOs> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            return await _user.CreateUser(request.ReqModel);
        }
    }

    public class UserLogoutHandler : IRequestHandler<UserLogoutCommand, int>
    {
        private readonly IUser _user;
        public UserLogoutHandler(IUser user)
        {
            _user = user;
        }
        public async Task<int> Handle(UserLogoutCommand request, CancellationToken cancellationToken)
        {
            return await _user.LogoutUser(request.RefreshToken);
        }
    }

    public class UserUpdateHandler : IRequestHandler<UserUpdateProfileCommand, BaseModel>
    {
        private readonly IUser _user;
        public UserUpdateHandler(IUser user)
        {
            _user = user;
        }
        public async Task<BaseModel> Handle(UserUpdateProfileCommand request, CancellationToken cancellationToken)
        {
            return await _user.UpdateUser(request.ReqModel);
        }
    }

    public class UserChangePasswordHandler : IRequestHandler<UserChangePasswordCommand, BaseModel>
    {
        private readonly IUser _user;
        public UserChangePasswordHandler(IUser user)
        {
            _user = user;
        }
        public async Task<BaseModel> Handle(UserChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _user.ChangePassword(request.ReqModel);
        }
    }

    public class UserForgotPasswordHandler : IRequestHandler<UserForgotPasswordCommand, BaseModel>
    {
        private readonly IUser _user;
        public UserForgotPasswordHandler(IUser user)
        {
            _user = user;
        }
        public async Task<BaseModel> Handle(UserForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _user.ForgotPassword(request.ReqModel);
        }
    }

    public class UserResetPasswordHandler : IRequestHandler<UserResetPasswordCommand, BaseModel>
    {
        private readonly IUser _user;
        public UserResetPasswordHandler(IUser user)
        {
            _user = user;
        }
        public async Task<BaseModel> Handle(UserResetPasswordCommand   request, CancellationToken cancellationToken)
        {
            return await _user.ResetPassword(request.ReqModel);
        }
    }

    public class UserDeleteAccountHandler : IRequestHandler<UserDeleteAccountCommand, BaseModel>
    {
        private readonly IUser _user;
        public UserDeleteAccountHandler(IUser user)
        {
            _user = user;
        }
        public async Task<BaseModel> Handle(UserDeleteAccountCommand request, CancellationToken cancellationToken)
        {
            return await _user.DeleteUser(request.ReqModel);
        }
    }

}