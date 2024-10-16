
using BarberApi.Models;
using BarberApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ServicesController : ControllerBase
{
    private readonly ServicesService _barberService;

    public ServicesController(ServicesService barberService) =>
    _barberService = barberService;

    [HttpGet]
    public async Task<List<Service>> Get() =>
    await _barberService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Service>> Get(string id)
    {
        var service = await _barberService.GetAsync(id);

        if (service is null)
        {
            return NotFound();
        }

        return service;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Service newServices)
    {
        await _barberService.CreateAsync(newServices);

        return CreatedAtAction(nameof(Get), new { id = newServices.Id }, newServices);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Service updatedServices)
    {
        var service = await _barberService.GetAsync(id);

        if (service is null)
        {
            return NotFound();
        }

        updatedServices.Id = service.Id;

        await _barberService.UpdateAsync(id, updatedServices);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var service = await _barberService.GetAsync(id);

        if (service is null)
        {
            return NotFound();
        }

        await _barberService.RemoveAsync(id);

        return NoContent();
    }
}