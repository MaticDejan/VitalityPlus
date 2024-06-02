using System.ComponentModel.DataAnnotations;

namespace Fitness_Application.Models;

public class ProdusGramaj
{
    [Key]
    public int Id { get; set; }
    public int idProdus {  get; set; }
    public float gramaj {  get; set; }
    public int idMeniu {  get; set; }
    public int prajit {  get; set; }
    public int fiert {  get; set; }
    public int crud { get; set; }

}