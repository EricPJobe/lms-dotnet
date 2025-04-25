using lms_server.database;
using lms_server.mapper;
using lms_server.dto.Account;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll() 
    {
        var accounts = _context.Account.Select(account => account.ToAccountDto()).ToList();
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var account = _context.Account.Find(id);

        if(account == null)
        {
            return NotFound();
        }
        
        return Ok(account.ToAccountDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateAccountRequest accountRequest)
    {
        var accountModel = accountRequest.ToAccountFromCreateDto();
        _context.Account.Add(accountModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = accountModel.Id }, accountModel.ToAccountDto());
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateAccountRequest accountRequest)
    {
        var accountModel = _context.Account.Find(id);

        if(accountModel == null)
        {
            return NotFound();
        }

        accountModel = accountRequest.ToAccountFromUpdateDto(accountModel);
        _context.Account.Update(accountModel);
        _context.SaveChanges();
        
        return Ok(accountModel.ToAccountDto());
    }
}