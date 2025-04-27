using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IProfileRepository
{
    Task<Profile> GetProfileByIdAsync(int id);
    Task<List<Profile>> GetAllProfilesAsync(QueryObject queryObject);
    Task<bool> CreateProfileAsync(Profile profile);
    Task<bool> UpdateProfileAsync(int id, Profile profile);
}