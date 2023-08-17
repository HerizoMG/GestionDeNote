using System.ComponentModel.DataAnnotations;
namespace GestionDeNote.Model;

public class Annee
{
    [Key]
    public int idAnnee { get; set; }
    public string annee { get; set; }
}