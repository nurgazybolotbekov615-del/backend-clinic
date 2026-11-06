using Microsoft.AspNetCore.Mvc;
using MedicalApi.Models;

namespace MedicalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    public static List<Patient> Patients = new List<Patient>();

    // GET: api/Patients
    [HttpGet]
    public List<Patient> GetAll()
    {
        return Patients;
    }

    // GET: api/Patients/1
    [HttpGet("{id}")]
    public ActionResult<Patient> GetById(int id)
    {
        Patient? patient = Patients.FirstOrDefault(p => p.Id == id);

        if (patient == null)
        {
            return NotFound("Пациент не найден");
        }

        return patient;
    }

    // POST: api/Patients
    [HttpPost]
    public ActionResult<Patient> Create(Patient patient)
    {
        patient.Id = Patients.Count == 0
            ? 1
            : Patients.Max(p => p.Id) + 1;

        Patients.Add(patient);

        return CreatedAtAction(
            nameof(GetById),
            new { id = patient.Id },
            patient
        );
    }

    // PUT: api/Patients/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Patient updatedPatient)
    {
        Patient? patient = Patients.FirstOrDefault(p => p.Id == id);

        if (patient == null)
        {
            return NotFound("Пациент не найден");
        }

        patient.Name = updatedPatient.Name;
        patient.BirthDate = updatedPatient.BirthDate;
        patient.Phone = updatedPatient.Phone;
        patient.Address = updatedPatient.Address;
        patient.IsActive = updatedPatient.IsActive;

        return NoContent();
    }

    // DELETE: api/Patients/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Patient? patient = Patients.FirstOrDefault(p => p.Id == id);

        if (patient == null)
        {
            return NotFound("Пациент не найден");
        }

        Patients.Remove(patient);

        return NoContent();
    }

    // GET: api/Patients/1/Spravki
    [HttpGet("{id}/Spravki")]
    public ActionResult<List<Spravka>> GetPatientSpravki(int id)
    {
        Patient? patient = Patients.FirstOrDefault(p => p.Id == id);

        if (patient == null)
        {
            return NotFound("Пациент не найден");
        }

        List<Spravka> patientSpravki = SpravkiController.Spravki
            .Where(s => s.PatientId == id)
            .ToList();

        return patientSpravki;
    }

    // GET: api/Patients/search?name=Алмаз
    [HttpGet("search")]
    public ActionResult<List<Patient>> Search(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest("Укажите имя для поиска");
        }

        List<Patient> results = Patients
            .Where(p => p.Name.Contains(
                name,
                StringComparison.OrdinalIgnoreCase))
            .ToList();

        return results;
    }
}
