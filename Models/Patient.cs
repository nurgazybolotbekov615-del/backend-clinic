
using System.ComponentModel.DataAnnotations;

namespace MedicalApi.Models;

public class Patient
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Имя пациента обязательно")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Имя должно содержать от 2 до 100 символов")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Дата рождения обязательна")]
    public DateTime? BirthDate { get; set; }

    [Required(ErrorMessage = "Телефон обязателен")]
    public string Phone { get; set; } = "";

    [Required(ErrorMessage = "Адрес обязателен")]
    public string Address { get; set; } = "";

    public bool IsActive { get; set; } = true;
}
