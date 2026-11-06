
using System.ComponentModel.DataAnnotations;

namespace MedicalApi.Models;

public class Spravka
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Необходимо указать ID типа справки")]
    [Range(1, int.MaxValue,
        ErrorMessage = "ID типа справки должен быть больше нуля")]
    public int SpravkaTypeId { get; set; }

    [Required(ErrorMessage = "Необходимо указать ID пациента")]
    [Range(1, int.MaxValue,
        ErrorMessage = "ID пациента должен быть больше нуля")]
    public int PatientId { get; set; }

    public string Name { get; set; } = "";

    public decimal Price { get; set; }
}
