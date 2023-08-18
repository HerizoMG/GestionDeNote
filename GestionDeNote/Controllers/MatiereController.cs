
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
       if (_context.Notes != null)
       {
           var matiere = _context.Coefficients
               .Include(c =>c.Matiere)
               .Include(c=>c.Serie)
               .ToList();
           return Ok(matiere);
       }
       throw new InvalidOperationException();
   }
   
   [HttpPost("create")]
    public IActionResult CreateMatiere(Matiere matiere)
    {
         _context.Matieres?.Add(matiere);
         _context.SaveChanges();
         return CreatedAtAction(nameof(GetMatiere), new { id = matiere.idMatiere});
    }
    
    [HttpGet("{id}")]
    public IActionResult FindMatiere(int id)
    {
        if (_context.Matieres != null)
        {
            var matiere = _context.Matieres.Find(id);
            return Ok(matiere);
        }
        throw new InvalidOperationException();
    }
    
    [HttpPut("{update}")]
    public IActionResult UpdateMatiere(Matiere matiere)
    {
        _context.Entry(matiere).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete("{delete}")]
    public IActionResult DeleteMatiere(int id)
    {
        var matiere = _context.Matieres.Find(id);
        _context.Matieres?.Remove(matiere);
        _context.SaveChanges();
        return NoContent();
    }
   
}