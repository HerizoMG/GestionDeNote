using System.ComponentModel.DataAnnotations;

namespace GestionDeNote.Model;

public class Trimestre
{
    [Key]
    public int idTrimestre { get; set; }
    public string nomTrimestre { get; set; }
}