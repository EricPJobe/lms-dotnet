using Microsoft.AspNetCore.Identity;

namespace lms_server.Models;

public class AppUser : IdentityUser
{
   public Account? Account { get; set; }
   public Profile? Profile { get; set; }
}