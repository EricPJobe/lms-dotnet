using lms_server.Models;

namespace lms_server.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}