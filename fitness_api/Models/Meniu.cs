using System.ComponentModel.DataAnnotations;

namespace Fitness_Application.Models;

public class Meniu
{
    [Key]
    public int Id { get; set; }

    public string Nume { get; set; }

    public string descriere { get; set; }
    public int idProduseGramaje { get; set; }
    public int idUtilizator { get; set; }
    public int idCreator { get; set; }
    public float kcal {  get; set; }
    public float proteine { get; set; }
    public float carboohidrati {  get; set; }
    public float zahar {  get; set; }
    public float grasimi { get; set; }
}