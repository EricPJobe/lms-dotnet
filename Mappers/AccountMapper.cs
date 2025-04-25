using lms_server.Models;
using lms_server.dto.Account;
using lms_server.dto.Course;
using lms_server.dto.Unit;

namespace lms_server.mapper;

public static class AccountMapper
{
    public static AccountDto ToAccountDto(this Account accountModel)
    {
        return new AccountDto
        {
            Id = accountModel.Id,
            SubType = accountModel.SubType,
            UserID = accountModel.UserID,
            AccountDueTS = accountModel.AccountDueTS,
            CreatedTS = accountModel.CreatedTS,
            UpdatedTS = accountModel.UpdatedTS,
            IsActive = accountModel.IsActive,
        };
    }

    public static Account ToAccountFromCreateDto(this CreateAccountRequest accountRequest)
    {
        return new Account
        {
            SubType = accountRequest.SubType,
            UserID = accountRequest.UserID,
            AccountDueTS = accountRequest.AccountDueTS,
            CreatedTS = accountRequest.CreatedTS,
            UpdatedTS = accountRequest.UpdatedTS,
            IsActive = accountRequest.IsActive,
        };
    }
    public static Account ToAccountFromUpdateDto(this UpdateAccountRequest accountRequest, Account accountModel)
    {
        accountModel.SubType = accountRequest.SubType;
        accountModel.UserID = accountRequest.UserID;
        accountModel.AccountDueTS = accountRequest.AccountDueTS;
        accountModel.CreatedTS = accountRequest.CreatedTS;
        accountModel.UpdatedTS = accountRequest.UpdatedTS;
        accountModel.IsActive = accountRequest.IsActive;

        return accountModel;
    }
}