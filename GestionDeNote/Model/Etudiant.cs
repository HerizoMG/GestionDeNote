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
    public string email { get; set; }
    
    public int idSerie { get; set; }
    
    [ForeignKey("idSerie")]
    public Serie? Serie { get; set; }
    
    public int idPeriode { get; set; }
    
    [ForeignKey("idPeriode")]
    public Periode? Periode { get; set; }
    
}