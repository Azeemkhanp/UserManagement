using MediatR;
using UserManagement.Models.RequestModel;
using UserManagement.Models.ResponseModel;

namespace UserManagement.CQRS.Query
{
    public class UserQuery : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
    public class UserProfileQuery : IRequest<UserResponseModel>
    {
        public UserRequestModel ReqModel { get; set; }
    }
}
        