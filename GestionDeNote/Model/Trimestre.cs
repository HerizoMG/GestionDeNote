using System.ComponentModel.DataAnnotations;

namespace GestionDeNote.Model;

public class Trimestre
{
    [Key]
    public int numTrimestre { get; set; }
    public string nomTrimestre { get; set; }
    public string anneeSColaire { get; set; }
}