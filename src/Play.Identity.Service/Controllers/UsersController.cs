using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Play.Identity.Service.Entities;
using static Duende.IdentityServer.IdentityServerConstants;

namespace Play.Identity.Service.Controllers;

[ApiController]
[Route("api/users")]
[Authorize(Policy = LocalApi.PolicyName)]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UsersController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = _userManager.Users.ToList().Select(user => user.AsDto());
        return await Task.FromResult(Ok(users));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null) return NotFound();
        return Ok(user.AsDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateUserDto userDto)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null) return NotFound();
        user.Email = userDto.Email;
        user.UserName = userDto.Email;
        user.Gil = userDto.Gil;
        await _userManager.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, UpdateUserDto userDto)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null) return NotFound();
        await _userManager.DeleteAsync(user);
        return NoContent();
    }
}
