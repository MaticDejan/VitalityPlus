using System.ComponentModel.DataAnnotations;

namespace Fitness_Application.Models;

public class Produs
{
    [Key]
    public int Id { get; set; }

    public string Nume { get; set; }
    public string Categorie { get; set; }
    public int prajit { get; set; }
    public int fiert {  get; set; } 
    public float proteine { get; set; }
    public float carbohidrati { get; set; }
    public float grasimi { get; set; }
    public float zahar { get; set; }
    public float kcal {  get; set; }
    public float? proteineFiert { get; set; }
    public float? carbohidratiFiert { get; set; }
    public float? grasimiFiert { get; set; }
    public float? zaharFiert { get; set; }
    public float? kcalFiert { get; set; }
    public float? proteinePrajit { get; set; }
    public float? carbohidratiPrajit { get; set; }
    public float? grasimiPrajit { get; set; }
    public float? zaharPrajit { get; set; }
    public float? kcalPrajit { get; set; }
    public string? imagine {  get; set; } 
    public int? selectat { get; set; }

}
