using System.ComponentModel.DataAnnotations;
using UserManagement.CommanFiles.KalishaGroup;
using UserManagement.Models.KalishaGroup.RequestModel;

namespace UserManagement.DTOs.KalishaGroupDTOs.RequestDtos
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LogoutRequestDto
    {
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class LoginResponseDTOs: BaseModel
    {
        public LoginResponseDTOs()
        {
            Role = new List<Roles>();
        }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

            // JWT Tokens
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? AccessTokenExpiresAt { get; set; }
            // Safe User Details
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Roles> Role { get; set; } = new List<Roles>();

    }
    public class LogoutResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class RegisterResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string Username { get; set; } = string.Empty;
    }

    public class UpdatePasswordRequestDto
    {
        [Required(ErrorMessage = "Current password is required.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "New password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("NewPassword", ErrorMessage = "New passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }

    public class ForgotPasswordRequestDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;
    }

    public class ResetPasswordRequestDto
    {
        [Required(ErrorMessage = "Reset token is required.")]
        public string Token { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "New password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }

    public class PasswordActionResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class RefreshTokenRequestDto
    {
        [Required(ErrorMessage = "Access token is required.")]
        public string AccessToken { get; set; } = string.Empty;

        [Required(ErrorMessage = "Refresh token is required.")]
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class RefreshTokenResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? AccessTokenExpiresAt { get; set; }
    }

    public class UserProfileResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public System.Collections.Generic.List<string> Roles { get; set; } = new();
    }

    public class MenuResponseModel
    {
        public int MenuId { get; set; }
        public string MenuText { get; set; }
        public int? ParentId { get; set; }

        // Used to organize permissions (e.g., "Admin", "Sales", "Inventory")
        public string ModuleName { get; set; }

        // The physical path in React Router (e.g., "/dashboard", "/users/list")
        public string Url { get; set; }

        // Optional: The name of the React Component to render (if doing dynamic component loading)
        public string ComponentName { get; set; }

        public string IconClass { get; set; }
        public string BusinessObjectCode { get; set; }
        public int DASHBOARD { get; set; }

        // The recursive list for sub-menus
        public List<MenuResponseModel> LstMenu { get; set; } = new List<MenuResponseModel>();
    }

    public class GetUserDtoBasedOnLogin: BaseModel
    {
        public int UserId { get; set; }
        public int Username { get; set; }
        public int Email { get; set; }
        public int Phone { get; set; }
        public int Role { get; set; }
    }

    public class UserDtoBasedOnLoginRequest:BaseModel
    {
        public int UserId { get; set; }
        public int Email { get; set; }
        public int UserName { get; set; }

        public int PhoneNo { get; set; }

    }
}
