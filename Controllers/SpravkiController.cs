
using Microsoft.AspNetCore.Mvc;
using MedicalApi.Models;

namespace MedicalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpravkiController : ControllerBase
{
    public static List<Spravka> Spravki = new List<Spravka>();

    // GET: api/Spravki
    [HttpGet]
    public List<Spravka> GetAll()
    {
        return Spravki;
    }

    // GET: api/Spravki/1
    [HttpGet("{id}")]
    public ActionResult<Spravka> GetById(int id)
    {
        Spravka? spravka = Spravki.FirstOrDefault(s => s.Id == id);

        if (spravka == null)
        {
            return NotFound();
        }

        return spravka;
    }

    // POST: api/Spravki
    [HttpPost]
    public ActionResult<Spravka> Create(Spravka request)
    {
        Patient? patient = PatientsController.Patients
            .FirstOrDefault(p => p.Id == request.PatientId);

        if (patient == null)
        {
            return BadRequest("Пациент не найден");
        }

        SpravkaType? type = SpravkaTypesController.Types
            .FirstOrDefault(t => t.Id == request.SpravkaTypeId);

        if (type == null)
        {
            return BadRequest("Тип справки не найден");
        }

        Spravka spravka = new Spravka
        {
            Id = Spravki.Count == 0 ? 1 : Spravki.Max(s => s.Id) + 1,
            PatientId = request.PatientId,
            SpravkaTypeId = type.Id,
            Name = type.Name,
            Price = type.Price
        };

        Spravki.Add(spravka);

        return CreatedAtAction(
            nameof(GetById),
            new { id = spravka.Id },
            spravka
        );
    }

    // PUT: api/Spravki/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Spravka request)
    {
        Spravka? spravka = Spravki.FirstOrDefault(s => s.Id == id);

        if (spravka == null)
        {
            return NotFound();
        }

        Patient? patient = PatientsController.Patients
            .FirstOrDefault(p => p.Id == request.PatientId);

        if (patient == null)
        {
            return BadRequest("Пациент не найден");
        }

        SpravkaType? type = SpravkaTypesController.Types
            .FirstOrDefault(t => t.Id == request.SpravkaTypeId);

        if (type == null)
        {
            return BadRequest("Тип справки не найден");
        }

        spravka.PatientId = request.PatientId;
        spravka.SpravkaTypeId = type.Id;
        spravka.Name = type.Name;
        spravka.Price = type.Price;

        return NoContent();
    }

    // DELETE: api/Spravki/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Spravka? spravka = Spravki.FirstOrDefault(s => s.Id == id);

        if (spravka == null)
        {
            return NotFound();
        }

        Spravki.Remove(spravka);

        return NoContent();
    }
}
