using lms_server.Models;
using lms_server.dto.Profile;

namespace lms_server.mapper;

public static class ProfileMapper
{
    public static ProfileDto ToProfileDto(this Profile profileModel)
    {
        return new ProfileDto
        {
            Id = profileModel.Id,
            Location = profileModel.Location,
            Bio = profileModel.Bio,
            UserID = profileModel.UserID,
            CreatedTS = profileModel.CreatedTS,
            UpdatedTS = profileModel.UpdatedTS,
            IsActive = profileModel.IsActive,
        };
    }

    public static Profile ToProfileFromCreateDto(this CreateProfileRequest profileRequest)
    {
        return new Profile
        {
            Location = profileRequest.Location,
            Bio = profileRequest.Bio,
            UserID = profileRequest.UserID,
            CreatedTS = profileRequest.CreatedTS,
            UpdatedTS = profileRequest.UpdatedTS,
            IsActive = profileRequest.IsActive,
        };
    }
    public static Profile ToProfileFromUpdateDto(this UpdateProfileRequest profileRequest, Profile profileModel)
    {
        profileModel.Location = profileRequest.Location;
        profileModel.Bio = profileRequest.Bio;
        profileModel.UserID = profileRequest.UserID;
        profileModel.CreatedTS = profileRequest.CreatedTS;
        profileModel.UpdatedTS = profileRequest.UpdatedTS;
        profileModel.IsActive = profileRequest.IsActive;

        return profileModel;
    }
}