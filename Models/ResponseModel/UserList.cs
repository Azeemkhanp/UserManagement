namespace UserManagement.Models.ResponseModel
{
    public class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string UserImage { get; set; }
        public string UserSpeciality { get; set; }
    }
}
