using System.ComponentModel.DataAnnotations;

namespace GestionDeNote.Model;

public class Matiere
{
    [Key]
    public string num_matiere { get; set; }

    public string coefficient { get; set; }
    
    public string nom_matiere { get; set; }
        
}