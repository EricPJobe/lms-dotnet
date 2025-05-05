using lms_server.database;
using lms_server.dto.Profile;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly ApplicationDBContext _context;
    
    public ProfileRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Profile?> CreateProfileAsync(Profile profile)
    {
        await _context.Profile.AddAsync(profile);
        await _context.SaveChangesAsync();
        return profile;
    }

    public async Task<List<Profile>> GetAllProfilesAsync(QueryObject queryObject)
    {
        return await _context.Profile.ToListAsync();
    }

    public async Task<Profile> GetProfileByIdAsync(int id)
    {
        var profile = await _context.Profile.FirstOrDefaultAsync(x => x.Id == id);
        if (profile == null)
        {
            throw new KeyNotFoundException("Profile not found");
        }
        return profile;
    }

    public async Task<Profile?> UpdateProfileAsync(int id, UpdateProfileRequest profile)
    {
        var profileModel = await _context.Profile.FirstOrDefaultAsync(x => x.Id == id);
        if (profileModel == null)
        {
            return null;
        }
        profileModel.Location = profile.Location;
        profileModel.Bio = profile.Bio;
        profileModel.AppUserId = profile.AppUserId;
        profileModel.IsActive = profile.IsActive;
        // profileModel.UpdatedTS = DateTime.UtcNow;

        _context.Profile.Update(profileModel);
        await _context.SaveChangesAsync();
        return profileModel;
    }
}
