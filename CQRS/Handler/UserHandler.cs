using MediatR;
using UserManagement.CQRS.Command;
using UserManagement.CQRS.Query;
using UserManagement.Interface;
using UserManagement.Models.ResponseModel;

namespace UserManagement.CQRS.Handler
{
    public class UserLoginHandler : IRequestHandler<UserLoginCommand, UserResponseModel>
    {
        private readonly IUser _user;
        public UserLoginHandler(IUser user)
        {
            _user = user;
        }
        public async Task<UserResponseModel> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            return await _user.GetUser(request.ReqModel);
        }
    }

    public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, UserResponseModel>
    {
        private readonly IUser _user;
        public UserRegisterHandler(IUser user)
        {
            _user = user;
        }
        public async Task<UserResponseModel> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            return await _user.GetUser(request.ReqModel);
        }
    }

    public class UserLogoutHandler : IRequestHandler<UserLogoutCommand, UserResponseModel>
    {
        private readonly IUser _user;
        public UserLogoutHandler(IUser user)
        {
            _user = user;
        }
        public async Task<UserResponseModel> Handle(UserLogoutCommand request, CancellationToken cancellationToken)
        {
            return await _user.GetUser(request.ReqModel);
        }
    }

    public class UserUpdateHandler : IRequestHandler<UserUpdateProfileCommand, UserResponseModel>
    {
        private readonly IUser _user;
        public UserUpdateHandler(IUser user)
        {
            _user = user;
        }
        public async Task<UserResponseModel> Handle(UserUpdateProfileCommand request, CancellationToken cancellationToken)
        {
            return await _user.GetUser(request.ReqModel);
        }
    }

    public class UserChangePasswordHandler : IRequestHandler<UserChangePasswordCommand, UserResponseModel>
    {
        private readonly IUser _user;
        public UserChangePasswordHandler(IUser user)
        {
            _user = user;
        }
        public async Task<UserResponseModel> Handle(UserChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _user.GetUser(request.ReqModel);
        }
    }

    public class UserForgotPasswordHandler : IRequestHandler<UserForgotPasswordCommand, UserResponseModel>
    {
        private readonly IUser _user;
        public UserForgotPasswordHandler(IUser user)
        {
            _user = user;
        }
        public async Task<UserResponseModel> Handle(UserForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _user.GetUser(request.ReqModel);
        }
    }

    public class UserResetPasswordHandler : IRequestHandler<UserResetPasswordCommand, UserResponseModel>
    {
        private readonly IUser _user;
        public UserResetPasswordHandler(IUser user)
        {
            _user = user;
        }
        public async Task<UserResponseModel> Handle(UserResetPasswordCommand   request, CancellationToken cancellationToken)
        {
            return await _user.GetUser(request.ReqModel);
        }
    }

    public class UserDeleteAccountHandler : IRequestHandler<UserDeleteAccountCommand, UserResponseModel>
    {
        private readonly IUser _user;
        public UserDeleteAccountHandler(IUser user)
        {
            _user = user;
        }
        public async Task<UserResponseModel> Handle(UserDeleteAccountCommand request, CancellationToken cancellationToken)
        {
            return await _user.GetUser(request.ReqModel);
        }
    }

}