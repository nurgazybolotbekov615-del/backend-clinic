
using System.ComponentModel.DataAnnotations;

namespace MedicalApi.Models;

public class SpravkaType
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Название типа справки обязательно")]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = "";

    [Range(0.01, 100000,
        ErrorMessage = "Цена должна быть больше нуля")]
    public decimal Price { get; set; }

    public string Description { get; set; } = "";
}
