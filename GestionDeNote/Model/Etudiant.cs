using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionDeNote.Model;

public class Etudiant
{   
    [Key]
    public string matricule { get; set; }
    public string nom { get; set; }
    public string prenoms { get; set; }
    public string adresse { get; set; }
    public string mail { get; set; }

    public int idClasse { get; set; }
    
    public int numSerie { get; set; }
    [ForeignKey("numSerie")]
    public Serie? Serie { get; set; }
    [ForeignKey("idClasse")]
    public Classe? Classe { get; set; }
    
}