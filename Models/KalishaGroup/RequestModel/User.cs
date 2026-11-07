using System.ComponentModel.DataAnnotations;

namespace UserManagement.Models.KalishaGroup.RequestModel
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? AccountStatus { get; set; }
        public bool EmailVerified { get; set; }
        public bool PhoneVerified { get; set; } = true;
        public string CompanyName { get; set; }
        public string PanNumber { get; set; }
        public string BillingAddress { get; set; }
        public DateTime? LastLoginAt { get; set; } = DateTime.UtcNow;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
