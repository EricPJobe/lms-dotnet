namespace lms_server.dto.Login;
 
 public class NewUserDto
    {
        public string UserName { get; set; } = string.Empty;    
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string SubscriptionType { get; set; } = string.Empty;
        public DateTime? AccountDueTS { get; set; }
        public string Token { get; set; } = string.Empty;
    }