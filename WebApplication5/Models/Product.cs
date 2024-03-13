using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите имя")]
    [Display(Name = " Имя")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Введите цену")]
    [Range(0.1, double.MaxValue, ErrorMessage = "Введите положительное число")]
    [Display(Name = "Цена")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Введите вес")]
    [Range(0.1, double.MaxValue, ErrorMessage = "Введите положительное число")]
    [Display(Name = " Вес")]
    public decimal? Weight { get; set; }
}