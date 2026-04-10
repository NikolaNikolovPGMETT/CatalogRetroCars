using System.ComponentModel.DataAnnotations;

namespace CatalogRetroCars.Models;

public class RetroCar
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Марката е задължителна.")]
    [StringLength(50)]
    public string Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "Моделът е задължителен.")]
    [StringLength(80)]
    public string Model { get; set; } = string.Empty;

    [Range(1886, 2000, ErrorMessage = "Годината трябва да е между 1886 и 2000.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Държавата е задължителна.")]
    [StringLength(40)]
    public string Country { get; set; } = string.Empty;

    [Range(1, 10000, ErrorMessage = "Мощността трябва да е между 1 и 10000 к.с.")]
    public int HorsePower { get; set; }

    [StringLength(700)]
    public string Description { get; set; } = string.Empty;
}