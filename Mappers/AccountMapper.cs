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
            AccountDueTS = accountRequest.AccountDueTS,
            // CreatedTS = accountRequest.CreatedTS,
            // UpdatedTS = accountRequest.UpdatedTS,
            IsActive = accountRequest.IsActive,
        };
    }
    public static Account ToAccountFromUpdateDto(this UpdateAccountRequest accountRequest, Account accountModel)
    {
        accountModel.SubscriptionType = accountRequest.SubscriptionType;
        accountModel.AppUserId = accountRequest.AppUserId;
        accountModel.AccountDueTS = accountRequest.AccountDueTS;
        // accountModel.CreatedTS = accountRequest.CreatedTS;
        // accountModel.UpdatedTS = accountRequest.UpdatedTS;
        accountModel.IsActive = accountRequest.IsActive;

        return accountModel;
    }
}