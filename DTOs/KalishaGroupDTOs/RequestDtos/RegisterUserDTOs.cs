using UserManagement.CommanFiles.KalishaGroup;

namespace UserManagement.DTOs.KalishaGroupDTOs.RequestDtos
{
    public class RegisterUserDTOs:BaseModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string  Phone { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
        public string CreatedDate { get; set; }
    }

    public class UpdateUserDTOs:BaseModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
        public string UpdatedDate { get; set; }
    }
    public class  forgetpasswordDtos
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class ResetPasswordDTOs
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NewPassword { get; set; }
    }

    public class ConfirmPasswordDTOs
    {
        public int  UserId  { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }




}
