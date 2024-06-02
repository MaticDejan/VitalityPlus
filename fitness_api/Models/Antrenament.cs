using System.ComponentModel.DataAnnotations;

namespace Fitness_Application.Models;

public class Antrenament
{
    [Key]
    public int Id { get; set; }
    public string Nume { get; set; }
    public string Descriere { get; set; }
    public float calorii { get; set; }
    public int idUtilizator { get; set; }
    public int idCreator { get; set; }
}