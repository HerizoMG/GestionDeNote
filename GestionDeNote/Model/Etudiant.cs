using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestionDeNote.Model;

public class Etudiant
{   
    [Key]
    public string num_matricule { get; set; }
    public string nom { get; set; }
    public string prenoms { get; set; }
    public string adresse { get; set; }
    public string mail { get; set; }
    
    public int idClass { get; set; }
    
    public int num_serie { get; set; }
    
    [ForeignKey("num_serie")]
    public Serie Serie { get; set; }
    
    [ForeignKey("idClass")]
    public Classe Classe { get; set; }
}