using lms_server.Helpers;
using lms_server.Models;

namespace lms_server.Interfaces;

public interface IAccountRepository
{
    Task<Account> GetAccountByIdAsync(int id);
    Task<List<Account>> GetAllAccountsAsync(QueryObject queryObject);
    Task<bool> CreateAccountAsync(Account account);
    Task<bool> UpdateAccountAsync(int id, Account account);
    Task<bool> AssignCourseToAccountAsync(int accountId, List<int> courseIds);
}
