using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Account;
using lms_server.Repositories;
using lms_server.Interfaces;
using lms_server.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IAccountRepository _accountRepository;
    public AccountController(ApplicationDBContext context, IAccountRepository accountRepository) 
    {
        _accountRepository = accountRepository;
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject) 
    {
        var accounts = await _accountRepository.GetAllAccountsAsync(queryObject);
        var accountsDto = accounts.Select(account => account.ToAccountDto());
        return Ok(accountsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var account = await _accountRepository.GetAccountByIdAsync(id);
        if(account == null)
        {
            return NotFound();
        }
        
        return Ok(account.ToAccountDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccountRequest accountRequest)
    {
        var accountModel = accountRequest.ToAccountFromCreateDto();
        await _accountRepository.CreateAccountAsync(accountModel);
        return CreatedAtAction(nameof(GetById), new { id = accountModel.Id }, accountModel.ToAccountDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAccountRequest accountRequest)
    {
        var accountModel = await _accountRepository.UpdateAccountAsync(id, accountRequest);

        if(accountModel == null)
        {
            return NotFound();
        }
        
        return Ok(accountModel.ToAccountDto());
    }
}