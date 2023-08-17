using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;
public class Periode
{   
    [Key]
    public int idPeriode { get; set; }
    public int idAnnee { get; set; }
    public int idTrimestre { get; set; }
    
    [ForeignKey("idAnnee")]
    public Annee? Annee { get; set; }
    
    [ForeignKey("idTrimestre")]
    public Trimestre? Trimestre { get; set; }
}