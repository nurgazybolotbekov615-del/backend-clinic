
using System.ComponentModel.DataAnnotations;

namespace MedicalApi.Models;

public class Appointment
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Необходимо указать ID пациента")]
    [Range(1, int.MaxValue,
        ErrorMessage = "ID пациента должен быть больше нуля")]
    public int PatientId { get; set; }

    [Required(ErrorMessage = "Имя врача обязательно")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Имя врача должно содержать от 2 до 100 символов")]
    public string DoctorName { get; set; } = "";

    [Required(ErrorMessage = "Дата приёма обязательна")]
    public DateTime? AppointmentDate { get; set; }

    [Required(ErrorMessage = "Причина обращения обязательна")]
    [StringLength(300, MinimumLength = 3,
        ErrorMessage = "Причина должна содержать от 3 до 300 символов")]
    public string Reason { get; set; } = "";

    public string Status { get; set; } = "Запланирована";
}
