using lms_server.Models;
using lms_server.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace lms_server.Services;

public class MyTokenService : IMyTokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;

    public MyTokenService(IConfiguration config)
    {
        _config = config;
       
        var signingKey = _config["JWT:SigningKey"];
        if (string.IsNullOrEmpty(signingKey))
        {
            throw new ArgumentNullException("JWT:SigningKey", "Signing key cannot be null or empty");
        }
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
    }

    public string CreateToken(AppUser user)
    {
         if(string.IsNullOrEmpty(user.Email))
         {
             throw new ArgumentNullException("user.Email", "Email cannot be null or empty");
         }
         if(string.IsNullOrEmpty(user.UserName))
         {
             throw new ArgumentNullException("user.UserName", "UserName cannot be null or empty");
         }

            // Create claims based on user information
         var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
    }
}
