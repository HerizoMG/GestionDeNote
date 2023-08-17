using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;
public class Periode
{   
    [Key]
    public int idAnneeScolaire { get; set; }
    public int idAnnee { get; set; }
    public int numTrimestre { get; set; }
    
    [ForeignKey("idAnnee")]
    public Annee? Annee { get; set; }
    
    [ForeignKey("numTrimestre")]
    public Trimestre? Trimestre { get; set; }
}