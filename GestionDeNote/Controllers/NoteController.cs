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
    public ActionResult<IEnumerable<Note>> GetNoteEtudiant()
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
    
    
    
    [HttpPost("ajouterNote")]
    public async Task<ActionResult> AjouterNotePourEtudiant(String id,[FromBody] Note? notes)
    {
        if (notes == null)
        {
            return BadRequest("Les données de la note ne peuvent pas être nulles.");
        }

        // Recherche de l'étudiant par numéro de matricule
        
        var etudiant =_context.Etudiants
            .Include(e=>e.Periode)
            .Include(e=>e.Serie)
            .FirstOrDefault(e=>e.matricule == id);
        
        if (etudiant == null)
        {
            return NotFound("Étudiant non trouvé avec le matricule spécifié.");
        }
        
        // Ajout de la note à l'étudiant

        
        var note = new Note
        {
            idNote = notes.idNote,
            matricule = etudiant.matricule,
            idMatiere = notes.idMatiere,
            note = notes.note,
            coeff = notes.coeff
        };
        
        _context.Notes?.Add(note);
        await _context.SaveChangesAsync();

        return Ok("Note ajoutée avec succès pour l'étudiant avec le matricule " + notes.matricule);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeletePosseder(string id)
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