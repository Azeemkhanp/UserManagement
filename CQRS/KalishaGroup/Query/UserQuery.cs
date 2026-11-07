using MediatR;
using UserManagement.Models.KalishaGroup.RequestModel;
using UserManagement.Models.KalishaGroup.ResponseModel;

namespace UserManagement.CQRS.KalishaGroup.Query
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
        