using System.ComponentModel.DataAnnotations;

namespace GestionDeNote.Model;

public class Matiere
{
    [Key]
    public int idMatiere { get; set; }

    public string coefficient { get; set; }
        
}