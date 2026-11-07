namespace UserManagement.Models.KalishaGroup.RequestModel
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string AssignedAt { get; set; }
        public int AssignedBy { get; set; }
    }
}
