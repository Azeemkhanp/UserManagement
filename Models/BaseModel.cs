namespace UserManagement.Models
{
    public class BaseModel
    {
        public int UserId { get; set; }
        public int Status { get; set; }
        public string UserRole { get; set; }
        public bool Success { get; set; }
        public string  Message { get; set; }
        public int  UserRoleId { get; set; }
        public string  UserFirstName { get; set; }
        public string  UserLastName { get; set; }
        public string  UserAddress { get; set; }
        public string UserType { get; set; }
        public int UserTypeId { get; set; }
    }
}
