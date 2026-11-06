
using Microsoft.AspNetCore.Mvc;
using MedicalApi.Models;

namespace MedicalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpravkaTypesController : ControllerBase
{
    public static List<SpravkaType> Types = new List<SpravkaType>
    {
        new SpravkaType
        {
            Id = 1,
            Name = "Справка в бассейн",
            Price = 200,
            Description = "Медицинская справка для посещения бассейна"
        },
        new SpravkaType
        {
            Id = 2,
            Name = "Медицинская справка",
            Price = 300,
            Description = "Общая медицинская справка"
        },
        new SpravkaType
        {
            Id = 3,
            Name = "Справка для учёбы",
            Price = 250,
            Description = "Справка для учебного заведения"
        },
        new SpravkaType
        {
            Id = 4,
            Name = "Справка для работы",
            Price = 400,
            Description = "Справка для предоставления работодателю"
        }
    };

    // GET: api/SpravkaTypes
    [HttpGet]
    public List<SpravkaType> GetAll()
    {
        return Types;
    }

    // GET: api/SpravkaTypes/1
    [HttpGet("{id}")]
    public ActionResult<SpravkaType> GetById(int id)
    {
        SpravkaType? type = Types.FirstOrDefault(t => t.Id == id);

        if (type == null)
        {
            return NotFound();
        }

        return type;
    }

    // POST: api/SpravkaTypes
    [HttpPost]
    public ActionResult<SpravkaType> Create(SpravkaType type)
    {
        type.Id = Types.Count == 0 ? 1 : Types.Max(t => t.Id) + 1;

        Types.Add(type);

        return CreatedAtAction(
            nameof(GetById),
            new { id = type.Id },
            type
        );
    }

    // PUT: api/SpravkaTypes/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, SpravkaType updatedType)
    {
        SpravkaType? type = Types.FirstOrDefault(t => t.Id == id);

        if (type == null)
        {
            return NotFound();
        }

        type.Name = updatedType.Name;
        type.Price = updatedType.Price;
        type.Description = updatedType.Description;

        return NoContent();
    }

    // DELETE: api/SpravkaTypes/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        SpravkaType? type = Types.FirstOrDefault(t => t.Id == id);

        if (type == null)
        {
            return NotFound();
        }

        Types.Remove(type);

        return NoContent();
    }
}
