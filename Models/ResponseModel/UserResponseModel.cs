using UserManagement.Models.RequestModel;

namespace UserManagement.Models.ResponseModel
{
    public class UserResponseModel
    {
        public UserResponseModel()
        {
            UserRequestModels=new List<UserRequestModel>();
            UserModel=new UserRequestModel();
            UserList=new List<User>();
        }
        public List<UserRequestModel> UserRequestModels { get; set; }
        public UserRequestModel UserModel { get; set; }
        public List<User> UserList { get; set; }
    }
}
