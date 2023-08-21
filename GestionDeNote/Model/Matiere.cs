using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;

public class Matiere
{
    [Key]
    public int idMatiere { get; set; }
    public string nomMatiere { get; set; }
    
}