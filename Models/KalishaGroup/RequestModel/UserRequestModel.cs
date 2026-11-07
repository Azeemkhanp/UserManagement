using UserManagement.CommanFiles.KalishaGroup;

namespace UserManagement.Models.KalishaGroup.RequestModel
{
    public class UserRequestModel: BaseModel
    {
        public  string? UserName { get; set; }
        public string? Email { get; set; }   
        
        public string? Password { get; set; }
        public string? HashPassword { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Token { get; set; }

        public int IsActive { get; set; }

    }
}
