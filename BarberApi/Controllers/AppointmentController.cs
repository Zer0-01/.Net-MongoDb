
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
        var appointment = await _appointmentService.GetAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        return appointment;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Appointment newAppointment)
    {
        await _appointmentService.CreateAsync(newAppointment);

        return CreatedAtAction(nameof(Get), new { id = newAppointment.Id }, newAppointment);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Appointment updatedApointment)
    {
        var appointment = await _appointmentService.GetAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        updatedApointment.Id = appointment.Id;

        await _appointmentService.UpdateAsync(id, updatedApointment);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var appointment = await _appointmentService.GetAsync(id);

        if (appointment is null)
        {
            return NotFound();
        }

        await _appointmentService.RemoveAsync(id);

        return NoContent();
    }
}