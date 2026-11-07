namespace UserManagement.Models.KalishaGroup.RequestModel
{
    public class RefreshTokens
    {
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public int Token { get; set; }
        public int JwtId { get; set; }
        public int IsRevoked { get; set; }
        public int IsUsed { get; set; }
        public int ExpiryDate { get; set; }
        public int CreatedDate { get; set; }
        public int CreatedByIp { get; set; }
    }
}
