using System.ComponentModel.DataAnnotations;

namespace GestionDeNote.Model;

public class Trimestre
{
    [Key]
    public string num_trimestre { get; set; }
    public static Trimestre annee_scolaire { get; set; }
}