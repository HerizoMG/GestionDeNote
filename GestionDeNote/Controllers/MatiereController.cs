
using GestionDeNote.Data;
using GestionDeNote.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeNote.Controllers;

[ApiController]
[Route("[Controller]")]

public class MatiereController : ControllerBase
{
   private readonly ApplicationDbContext _context;

   public MatiereController(ApplicationDbContext context)
   {
       _context = context;
   }
   

   [HttpGet]
   public ActionResult<IEnumerable<Matiere>>GetMatiere()
   {
       if (_context.Posseders != null)
       {
           var matiere = _context.Matieres;
           return Ok(matiere);
       }

       throw new InvalidOperationException();
   }
}