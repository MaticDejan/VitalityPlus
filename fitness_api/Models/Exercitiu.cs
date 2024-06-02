using System.ComponentModel.DataAnnotations;

namespace Fitness_Application.Models;

public class Exercitiu
{
    [Key]
    public int Id { get; set; }

    public string Nume { get; set; }
    public string Categorie { get; set; }
    public string Descriere { get; set; }
    public float? caloriiPer10Minute { get; set; }
    public float? caloriiPerRepetare { get; set; }
    public byte[]? imagine { get; set; }
    public int? selectat { get; set; }
    public int? greutati { get; set; }
    public int? anduranta { get; set; }
}