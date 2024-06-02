using System.ComponentModel.DataAnnotations;

namespace Fitness_Application.Models;

public class Cereri
{
    [Key]
    public int Id { get; set; }
    public string categorie { get; set; }
    public string descriere { get; set; }
    public string? status { get; set; }
    public int idUtilizatorCerere { get; set; }
    public int? idUtilizatorRaportat { get; set; }
    public string? raspuns { get; set; }
}