using BarberApi.Models;
using BarberApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly BarberService _barberService;

    public UsersController(BarberService barberService) =>
    _barberService = barberService;

    [HttpGet]
    public async Task<List<User>> Get() =>
    await _barberService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _barberService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _barberService.CreateAsync(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, User updatedUser)
    {
        var user = await _barberService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        updatedUser.Id = user.Id;

        await _barberService.UpdateAsync(id, updatedUser);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _barberService.GetAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        await _barberService.RemoveAsync(id);

        return NoContent();
    }
}