using lms_server.Models;

namespace lms_server.Interfaces;

public interface IMyTokenService
{
    string CreateToken(AppUser user);
}