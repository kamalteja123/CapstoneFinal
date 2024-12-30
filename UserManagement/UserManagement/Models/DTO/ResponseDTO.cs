namespace UserManagement.Models.DTO
{
    public class ResponseDTO
    {
        public int UId {  get; set; }   
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
