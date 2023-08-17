using GestionDeNote.Data;
using GestionDeNote.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeNote.Controllers;


[ApiController]
[Route("[Controller]")]
    
public class PossedderController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PossedderController(ApplicationDbContext context)
    {
        _context = context;
    }
    

    [HttpGet]
    public ActionResult<IEnumerable<Etudiant>> GetNoteEtudiant()
    {
        if (_context.Posseders != null)
        {
            var noteEtudiant = _context.Posseders.Include(e => e.trimestres).ToList();
            return Ok(noteEtudiant);
        }

        throw new InvalidOperationException();
    }
    
    
    [HttpGet("{id}")]
    public IActionResult FindEtudiant(string id)
    {
        var posseder = _context.Posseders
            .Where(p => p.num_matricule.Contains(id) ||
                        p.id_note.Contains(id));
        if (posseder == null)
        {
            return NotFound();
        }
        return Ok(posseder);
        
    }
    
    
    
    [HttpPost("ajouterNote")]
    public async Task<ActionResult> AjouterNotePourEtudiant(String id,[FromBody] Note? posseder)
    {
        if (posseder == null)
        {
            return BadRequest("Les données de la note ne peuvent pas être nulles.");
        }

        // Recherche de l'étudiant par numéro de matricule
        
        var etudiant =_context.Etudiants?.Find(id);
        if (etudiant == null)
        {
            return NotFound("Étudiant non trouvé avec le matricule spécifié.");
        }
        
        // Ajout de la note à l'étudiant
        
        var note = new Note
        {
            id_note = posseder.id_note,
            num_matricule = etudiant.num_matricule,
            num_matiere = posseder.num_matiere,
            num_trimestre = posseder.num_trimestre,
            trimestres = Trimestre.annee_scolaire,
            note = posseder.note
        };
        
        _context.Posseders?.Add(note);
        await _context.SaveChangesAsync();

        return Ok("Note ajoutée avec succès pour l'étudiant avec le matricule " + posseder.num_matricule);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeletePosseder(string id)
    {
        var posseder = _context.Posseders
            .Where(p => p.num_matricule.Contains(id) || 
                        p.id_note.Contains(id)).ToList();
        if (posseder==null)
        {
            return NotFound();
        }
        _context.Posseders.RemoveRange(posseder);
        _context.SaveChanges();

        return NoContent();
    }
    
}    