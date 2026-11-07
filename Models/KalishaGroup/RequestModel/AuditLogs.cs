namespace UserManagement.Models.KalishaGroup.RequestModel
{
    public class AuditLogs
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public int Action { get; set; }
        public int IpAddress { get; set; }
        public int Details { get; set; }
        public int CreatedAt { get; set; }
    }
}
