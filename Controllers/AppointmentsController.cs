
using Microsoft.AspNetCore.Mvc;
using MedicalApi.Models;

namespace MedicalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    public static List<Appointment> Appointments = new List<Appointment>();

    // GET: api/Appointments
    [HttpGet]
    public List<Appointment> GetAll()
    {
        return Appointments;
    }

    // GET: api/Appointments/1
    [HttpGet("{id}")]
    public ActionResult<Appointment> GetById(int id)
    {
        Appointment? appointment = Appointments
            .FirstOrDefault(a => a.Id == id);

        if (appointment == null)
        {
            return NotFound("Запись не найдена");
        }

        return appointment;
    }

    // POST: api/Appointments
    [HttpPost]
    public ActionResult<Appointment> Create(Appointment appointment)
    {
        Patient? patient = PatientsController.Patients
            .FirstOrDefault(p => p.Id == appointment.PatientId);

        if (patient == null)
        {
            return BadRequest("Пациент не найден");
        }

        appointment.Id = Appointments.Count == 0
            ? 1
            : Appointments.Max(a => a.Id) + 1;

        Appointments.Add(appointment);

        return CreatedAtAction(
            nameof(GetById),
            new { id = appointment.Id },
            appointment
        );
    }

    // PUT: api/Appointments/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Appointment updatedAppointment)
    {
        Appointment? appointment = Appointments
            .FirstOrDefault(a => a.Id == id);

        if (appointment == null)
        {
            return NotFound("Запись не найдена");
        }

        Patient? patient = PatientsController.Patients
            .FirstOrDefault(p => p.Id == updatedAppointment.PatientId);

        if (patient == null)
        {
            return BadRequest("Пациент не найден");
        }

        appointment.PatientId = updatedAppointment.PatientId;
        appointment.DoctorName = updatedAppointment.DoctorName;
        appointment.AppointmentDate = updatedAppointment.AppointmentDate;
        appointment.Reason = updatedAppointment.Reason;
        appointment.Status = updatedAppointment.Status;

        return NoContent();
    }

    // DELETE: api/Appointments/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Appointment? appointment = Appointments
            .FirstOrDefault(a => a.Id == id);

        if (appointment == null)
        {
            return NotFound("Запись не найдена");
        }

        Appointments.Remove(appointment);

        return NoContent();
    }
}
