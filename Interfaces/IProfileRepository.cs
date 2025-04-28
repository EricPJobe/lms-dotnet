using lms_server.dto.Profile;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IProfileRepository
{
    Task<Profile> GetProfileByIdAsync(int id);
    Task<List<Profile>> GetAllProfilesAsync(QueryObject queryObject);
    Task<Profile?> CreateProfileAsync(Profile profile);
    Task<Profile?> UpdateProfileAsync(int id, UpdateProfileRequest profile);
}