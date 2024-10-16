
using BarberApi.Models;
using BarberApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentService _appointmentService;

    public AppointmentController(AppointmentService appointmentService) =>
    _appointmentService = appointmentService;

    [HttpGet]
    public async Task<List<Appointment>> Get() =>
    await _appointmentService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Appointment>> Get(string id)
    {
        var Services = await _appointmentService.GetAsync(id);

        if (Services is null)
        {
            return NotFound();
        }

        return Services;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Appointment newServices)
    {
        await _appointmentService.CreateAsync(newServices);

        return CreatedAtAction(nameof(Get), new { id = newServices.Id }, newServices);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Appointment updatedServices)
    {
        var Services = await _appointmentService.GetAsync(id);

        if (Services is null)
        {
            return NotFound();
        }

        updatedServices.Id = Services.Id;

        await _appointmentService.UpdateAsync(id, updatedServices);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Services = await _appointmentService.GetAsync(id);

        if (Services is null)
        {
            return NotFound();
        }

        await _appointmentService.RemoveAsync(id);

        return NoContent();
    }
}