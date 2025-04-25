using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lms_server.controllers;

[Route("api/v1/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public AccountController(ApplicationDBContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var accounts = await _context.Account.ToListAsync();
        var accountsDto = accounts.Select(account => account.ToAccountDto());
        return Ok(accountsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var account = await _context.Account.FindAsync(id);

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
        await _context.Account.AddAsync(accountModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = accountModel.Id }, accountModel.ToAccountDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAccountRequest accountRequest)
    {
        var accountModel = await _context.Account.FirstOrDefaultAsync(x => x.Id == id);

        if(accountModel == null)
        {
            return NotFound();
        }

        accountModel = accountRequest.ToAccountFromUpdateDto(accountModel);
        // _context.Account.Update(accountModel);
        await _context.SaveChangesAsync();
        
        return Ok(accountModel.ToAccountDto());
    }
}