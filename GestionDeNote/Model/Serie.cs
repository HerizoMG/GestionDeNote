using System.ComponentModel.DataAnnotations;

namespace GestionDeNote.Model;

public class Serie
{
    [Key]
    public int numSerie { get; set; }
    public string nomSerie { get; set; }
}