using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestionDeNote.Model;

public class Serie
{
    [Key]
    public int num_serie { get; set; }
    public string nom_serie { get; set; }
    

}