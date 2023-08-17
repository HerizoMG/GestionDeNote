using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;

public class Classe
{
    [Key]
    public int idClass { get; set; }
    public string niveau { get; set; }

}