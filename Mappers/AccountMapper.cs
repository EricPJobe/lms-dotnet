using lms_server.Models;
using lms_server.dto.Account;

namespace lms_server.mapper;

public static class AccountMapper
{
    public static AccountDto ToAccountDto(this Account accountModel)
    {
        return new AccountDto
        {
            Id = accountModel.Id,
            Title = accountModel.Title,
            FirstName = accountModel.FirstName,
            LastName = accountModel.LastName,
            SubscriptionType = accountModel.SubscriptionType,
            AppUserId = accountModel.AppUserId,
            AccountDueTS = accountModel.AccountDueTS,
            // CreatedTS = accountModel.CreatedTS,
            // UpdatedTS = accountModel.UpdatedTS,
            IsActive = accountModel.IsActive,
        };
    }

    public static Account ToAccountFromCreateDto(this CreateAccountRequest accountRequest)
    {
        return new Account
        {
            SubscriptionType = accountRequest.SubscriptionType,
            AppUserId = accountRequest.AppUserId,
            Title = accountRequest.Title,
            FirstName = accountRequest.FirstName,
            LastName = accountRequest.LastName,
            AccountDueTS = accountRequest.AccountDueTS,
            // CreatedTS = accountRequest.CreatedTS,
            // UpdatedTS = accountRequest.UpdatedTS,
            IsActive = accountRequest.IsActive,
        };
    }
    public static Account ToAccountFromUpdateDto(this UpdateAccountRequest accountRequest, Account accountModel)
    {
        accountModel.Id = accountRequest.Id;
        accountModel.SubscriptionType = accountRequest.SubscriptionType;
        accountModel.AppUserId = accountRequest.AppUserId;
        accountModel.Title = accountRequest.Title;
        accountModel.FirstName = accountRequest.FirstName;
        accountModel.LastName = accountRequest.LastName;
        accountModel.AccountDueTS = accountRequest.AccountDueTS;
        // accountModel.CreatedTS = accountRequest.CreatedTS;
        // accountModel.UpdatedTS = accountRequest.UpdatedTS;
        accountModel.IsActive = accountRequest.IsActive;

        return accountModel;
    }
}