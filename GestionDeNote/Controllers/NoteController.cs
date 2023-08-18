using GestionDeNote.Data;
using GestionDeNote.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeNote.Controllers;


[ApiController]
[Route("[Controller]")]
    
public class NoteController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public NoteController(ApplicationDbContext context)
    {
        _context = context;
    }
    

    [HttpGet]
    public ActionResult<IEnumerable<Note>> GetNote()
    {
        if (_context.Notes != null)
        {
            var noteEtudiant = _context.Notes
                .Include(e => e.Etudiant)
                .Include(n=>n.Matiere)
                .ToList();
            return Ok(noteEtudiant);
        }

        throw new InvalidOperationException();
    }
    
    
    [HttpGet("{id}")]
    public IActionResult FindEtudiant(string id)
    {
        var notes = _context.Notes
            .Where(p => p.matricule.Contains(id) ||
                        p.idNote.ToString().Contains(id));
        if (notes == null)
        {
            return NotFound();
        }
        return Ok(notes);
        
    }
    
    private int GenererNextId()
    {
      var lastId = _context.Notes.OrderByDescending(n => n.idNote)
          .Select(n => n.idNote)
          .FirstOrDefault();
      
      if (lastId == null)
      {
          return 1;
      }
      return lastId + 1;
    }
    
    
    
    [HttpPost("ajouterNote")]
    public async Task<ActionResult> AjouterNote(Note notes)
    {
        if (notes == null)
        {
            return BadRequest("Invalid Note data.");
        }

        notes.idNote = GenererNextId();
    
        if (notes.Etudiant != null && !string.IsNullOrEmpty(notes.matricule))
        {
            _context.Attach(notes.Etudiant);
        }
    
        if (notes.Matiere != null && !string.IsNullOrEmpty(notes.idMatiere.ToString()))
        {
            _context.Attach(notes.Matiere);
        }
    
        if (_context.Notes != null)
        {
            _context.Notes.Add(notes);
            await _context.SaveChangesAsync();
            return Ok("Note ajoutée avec succès pour l'étudiant avec le matricule " + notes.matricule);
        }
        else
        {
            return BadRequest("Notes context is null.");
        }
    }


    [HttpPut("update")]
    public async Task<IActionResult> UpdateNote(string id, Note updateNote)
    {
        _context.Entry(updateNote).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }
    
    
    [HttpDelete("{id}")]
    public IActionResult DeleteNote(string id)
    {
        var posseder = _context.Notes
            .Where(p => p.matricule.Contains(id) || 
                        p.idNote.ToString().Contains(id)
            ).ToList();
        if (posseder==null)
        {
            return NotFound();
        }
        _context.Notes.RemoveRange(posseder);
        _context.SaveChanges();

        return NoContent();
    }
    
}    