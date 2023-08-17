using System.ComponentModel.DataAnnotations;

namespace GestionDeNote.Model;

public class Trimestre
{
    [Key]
    public string iDtrimestre { get; set; }
    public string nom_trimestre { get; set; }
    public static Trimestre annee { get; set; }
}