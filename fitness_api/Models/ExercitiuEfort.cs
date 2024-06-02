using System.ComponentModel.DataAnnotations;

namespace Fitness_Application.Models;

public class ExercitiuEfort
{
    [Key]
    public int Id { get; set; }
    public int idExercitiu { get; set; }
    public int idAntrenament { get; set; }    
    public int timp {  get; set; }
    public int serii { get; set; }
    public int repetari { get; set; }
    public int greutati { get; set; }
    public int anduranta { get; set; }
}