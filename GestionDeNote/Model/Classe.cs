using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeNote.Model;

public class Classe
{
    [Key]
    public int idClasse { get; set; }
    public string niveau { get; set; }
}