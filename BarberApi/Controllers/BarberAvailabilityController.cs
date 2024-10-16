
using BarberApi.Models;
using BarberApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BarberAvailabilityController : ControllerBase
{
    private readonly BarberAvailabilityService _barberAvailabityService;

    public BarberAvailabilityController(BarberAvailabilityService barberAvailabilityService) =>
    _barberAvailabityService = barberAvailabilityService;

    [HttpGet]
    public async Task<List<BarberAvailability>> Get() =>
    await _barberAvailabityService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<BarberAvailability>> Get(string id)
    {
        var barberAvailability = await _barberAvailabityService.GetAsync(id);

        if (barberAvailability is null)
        {
            return NotFound();
        }

        return barberAvailability;
    }

    [HttpPost]
    public async Task<IActionResult> Post(BarberAvailability newBarberAvailability)
    {
        await _barberAvailabityService.CreateAsync(newBarberAvailability);

        return CreatedAtAction(nameof(Get), new { id = newBarberAvailability.Id }, newBarberAvailability);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, BarberAvailability updatedBarberAvailability)
    {
        var barberAvailability = await _barberAvailabityService.GetAsync(id);

        if (barberAvailability is null)
        {
            return NotFound();
        }

        updatedBarberAvailability.Id = barberAvailability.Id;

        await _barberAvailabityService.UpdateAsync(id, updatedBarberAvailability);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var barberAvailability = await _barberAvailabityService.GetAsync(id);

        if (barberAvailability is null)
        {
            return NotFound();
        }

        await _barberAvailabityService.RemoveAsync(id);

        return NoContent();
    }
}