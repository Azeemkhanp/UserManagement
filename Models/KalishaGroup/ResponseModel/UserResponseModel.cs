using UserManagement.Models.KalishaGroup.RequestModel;

namespace UserManagement.Models.KalishaGroup.ResponseModel
{
    public class UserResponseModel: BaseModel
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
