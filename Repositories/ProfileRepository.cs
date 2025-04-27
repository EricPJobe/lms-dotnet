using lms_server.database;
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

    public async Task<bool> CreateProfileAsync(Profile profile)
    {
        var succeeded = await _context.Profile.AddAsync(profile);
        await _context.SaveChangesAsync();
        return succeeded != null;
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

    public async Task<bool> UpdateProfileAsync(int id, Profile profile)
    {
        var profileModel = await _context.Profile.FirstOrDefaultAsync(x => x.Id == id);
        if (profileModel == null)
        {
            return false;
        }
        profileModel.Location = profile.Location;
        profileModel.Bio = profile.Bio;
        profileModel.UserID = profile.UserID;
        profileModel.IsActive = profile.IsActive;
        profileModel.UpdatedTS = DateTime.UtcNow;

        _context.Profile.Update(profileModel);
        await _context.SaveChangesAsync();
        return true;
    }
}
