namespace UserManagement.CommanFiles
{
    public class BaseModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public int Response { get; set; }
        public int statusCode { get; set; }
        public string? Message { get; set; }
        public string? ErrorMessage { get; set; }

    }
}
