using lms_server.dto.Account;
using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IAccountRepository
{
    Task<Account> GetAccountByIdAsync(int id);
    Task<List<Account>> GetAllAccountsAsync(QueryObject queryObject);
    Task<Account?> CreateAccountAsync(Account account);
    Task<Account?> UpdateAccountAsync(int id, UpdateAccountRequest account);
    Task<bool> AssignCourseToAccountAsync(int accountId, List<int> courseIds);
}
