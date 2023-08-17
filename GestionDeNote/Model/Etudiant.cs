using System.ComponentModel.DataAnnotations;
using GestionDeNote.Model;

public class Etudiant
{   
    [Key]
    public string num_matricule { get; set; }
    public string nom { get; set; }
    public string prenoms { get; set; }
    public string adresse { get; set; }
    public string mail { get; set; }

    public Serie Serie { get; set; }
    
    public Classe Classe { get; set; }
}