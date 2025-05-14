using lms_server.database;
using lms_server.dto.Account;
using lms_server.Helpers;
using lms_server.Interfaces;
using lms_server.Models;
using Microsoft.EntityFrameworkCore;

namespace lms_server.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDBContext _context;
    
    public AccountRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<bool> AssignCourseToAccountAsync(int accountId, List<int> courseIds)
    {
        await _context.AccountCourses.AddRangeAsync(courseIds.Select(courseId => new AccountCourses
        {
            AccountId = accountId,
            CourseId = courseId
        }));
    
        return await _context.SaveChangesAsync() != 0 ? true : false;  
    }

    public async Task<Account?> CreateAccountAsync(Account account)
    {
        await _context.Account.AddAsync(account);
        await _context.SaveChangesAsync();
        return account ;
    }

    public async Task<Account> GetAccountByIdAsync(string id)
    {
        var account = await _context.Account.FirstOrDefaultAsync(x => x.AppUserId == id);
        if (account == null)
        {
            throw new KeyNotFoundException("Account not found");
        }
        return account;
    }

    public Task<List<Account>> GetAllAccountsAsync(QueryObject queryObject)
    {
        return _context.Account.ToListAsync();
    }

    public async Task<Account?> UpdateAccountAsync(int id, UpdateAccountRequest account)
    {
        var accountModel = await _context.Account.FirstOrDefaultAsync(x => x.Id == id);

        if (accountModel == null)
        {
            return null;
        }

        accountModel.SubscriptionType = account.SubscriptionType;
        // accountModel.UserID = account.UserID;
        accountModel.AccountDueTS = account.AccountDueTS;
        accountModel.IsActive = account.IsActive;
        // accountModel.UpdatedTS = DateTime.UtcNow;

        _context.Account.Update(accountModel);
        await _context.SaveChangesAsync();
        return accountModel;
    }
    public async Task<Account?> GetAccountByUserNameAsync(string userName)
    {
        var account = await _context.Account.FirstOrDefaultAsync(x => x.UserName == userName);
        if (account == null)
        {
            throw new KeyNotFoundException("Account not found");
        }
        Console.WriteLine($"Account found: {account.UserName}");
        return account;
    }
}
