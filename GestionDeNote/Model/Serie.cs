using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;

public class Serie
{
    [Key]
    public int idSerie { get; set; }
    public string nomSerie { get; set; }
    public int idClasse { get; set; }
    
    [ForeignKey("idClasse")]
    public Classe? Classe { get; set; }
}