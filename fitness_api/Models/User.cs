using System.ComponentModel.DataAnnotations;

namespace Fitness_Application.Models;

public class User{
    [Key]
    public int Id { get; set; }

    public string? Nume { get; set; }
    public string? Prenume { get; set; }
    public float? Greutate { get; set; }
    public int? Inaltime { get; set; }
    public int? Varsta { get; set; }
    public string? Activitate { get; set; }
    public int? Antrenor { get; set; }
    public int? idAntrenor { get; set; }
    public float? talie { get; set; }
    public float? gat { get; set; }
    public float? antebrat { get; set; }
    public float? coapsa { get; set; }
    public string? sex { get; set; }
    public float? indiceMasaCorporala { get; set; }
    public float? procentDeGrasime { get; set; }
    public float? greutateIdeala { get; set; }
    public float? necesarCaloric { get; set; }

    public bool? Admin { get; set; }
    [Required(AllowEmptyStrings = true)]
    public string Email { get; set; }
    [Required(AllowEmptyStrings = true)]
    public string Parola { get; set; }
    public bool? Activ { get; set; }
    public string imagine { get; set; }
}