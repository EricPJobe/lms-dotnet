using lms_server.dto.Login;
using lms_server.Models;
using lms_server.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lms_server.Helpers;
using lms_server.mapper;
using lms_server.dto.Account;

namespace lms_server.controllers;

[Route("api/v1/auth/")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signinManager;
    private readonly IAccountRepository _accountRepository;
    public AuthenticationController(UserManager<AppUser> userManager, 
                                    ITokenService tokenService, 
                                    SignInManager<AppUser> signInManager,
                                    IAccountRepository accountRepository)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signinManager = signInManager;
        _accountRepository = accountRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

        if (user == null) return Unauthorized("Invalid username!");

        var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        var account = new Account();

        if (result.Succeeded && user.UserName != null)
        { 
            account = await _accountRepository.GetAccountByUserNameAsync(user.UserName);
        }
        else
            return Unauthorized("Username not found and/or password incorrect");

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return Ok(
            new NewUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Title = account.Title,
                SubscriptionType = account.SubscriptionType,
                AccountDueTS = account.AccountDueTS,
                Token = _tokenService.CreateToken(user)
            }
        );
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8601 // Possible null reference assignment.
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            
            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                var accountModel = new Account
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Title = registerDto.Title,
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    AppUserId = appUser.Id,
                    SubscriptionType = registerDto.SubscriptionType,
                    AccountDueTS = registerDto.AccountDueTS,
                    IsActive = true
                };
                var account = await _accountRepository.CreateAccountAsync(accountModel);
                if (roleResult.Succeeded && account != null)
                {
                    return Ok(
                        new NewUserDto
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            FirstName = account.FirstName,
                            LastName = account.LastName,
                            Title = account.Title,
                            SubscriptionType = account.SubscriptionType,
                            AccountDueTS = account.AccountDueTS,
                            Token = _tokenService.CreateToken(appUser)
                        }
                    );
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject) 
    {
        var accounts = await _accountRepository.GetAllAccountsAsync(queryObject);
        var accountsDto = accounts.Select(account => account.ToAccountDto());
        return Ok(accountsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAccountRequest accountRequest)
    {
        var accountModel = await _accountRepository.UpdateAccountAsync(id, accountRequest);

        if(accountModel == null)
        {
            return NotFound();
        }
        
        return Ok(accountModel.ToAccountDto());
    }

    // [HttpGet("{userName}")]
    // public async Task<IActionResult> GetByUserName([FromRoute] string userName)
    // {
    //     var account = await _accountRepository.GetAccountByUserNameAsync(userName);
    //     if(account == null)
    //     {
    //         return NotFound();
    //     }
        
    //     return Ok(account.ToAccountDto());
    // }
}