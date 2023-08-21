using GestionDeNote.Data;
using GestionDeNote.Model;
using Google.Protobuf.WellKnownTypes;
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
    
    /*
    [HttpGet("maths")]
    public ActionResult<IEnumerable<Note>> GetNoteByMatiere(int idSerie)
    {
        if (_context.Notes != null)
        {
            var noteEtudiant = _context.Notes
                .Include(e => e.Etudiant)
                .Include(n=>n.Matiere)
                .Where(m => m.Etudiant.idSerie == idSerie 
                            && m.idMatiere == 1)
                .ToList();
            return Ok(noteEtudiant);
        }
        throw new InvalidOperationException();
    }*/
    
    [HttpGet("matieres/{idMatiere}/series/{idSerie}/periodes/{idPeriode}")]
    public ActionResult<IEnumerable<Note>> GetNoteByMatiere(int idMatiere, int idSerie, int idPeriode)
    {
        var noteEtudiant = _context.Notes
            .Include(e => e.Etudiant)
            .Include(n => n.Matiere)
            .Where(n => n.Etudiant.idSerie == idSerie
                        && n.idMatiere == idMatiere
                        && n.idPeriode == idPeriode)
            .ToList();

        return Ok(noteEtudiant);
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
    
    [HttpGet("series/{idSerie}/trimestres/{idTrimestre}")]
    public IActionResult GetMoyenSeconde(int idSerie, int idTrimestre)
    {
        var moyennes = _context.Etudiants
            .Where(e => e.idSerie == idSerie)
            .Select(e => new
            {
                e.matricule,
                e.nom,
                e.prenoms,
                moyenne = _context.Notes
                    .Where(n => n.matricule == e.matricule && n.Etudiant.idSerie == idSerie && n.Periode.idTrimestre == idTrimestre)
                    .GroupBy(n => n.matricule)
                    .Select(g => g.Sum(n => n.note * _context.Coefficients.FirstOrDefault(c => c.idMatiere == n.idMatiere && c.idSerie == idSerie).coeff) /
                                 g.Sum(n => _context.Coefficients.FirstOrDefault(c => c.idMatiere == n.idMatiere && c.idSerie == idSerie).coeff))
                    .FirstOrDefault()
            })
            .OrderByDescending(e => e.moyenne)
            .ToList();

        if (moyennes.Count == 0)
        {
            return NotFound();
        }

        return Ok(moyennes);
    }



    /*
    [HttpGet("{idSerie}")]
    public IActionResult GetMoyenSeconde(int idSerie)
    {
        var moyennes = _context.Etudiants
            .Where(e => e.Serie.idSerie == 1 &&  e.idSerie == idSerie)
            .Select(e => new
            {
                e.matricule,
                e.nom,
                e.prenoms,
                Serie = e.Serie.nomSerie,
                MoyennesTrimestres = _context.Periodes
                    .Select(p => new
                    {
                        Trimestre = p.Trimestre.nomTrimestre,
                        Moyenne = _context.Notes
                                      .Where(n => n.matricule == e.matricule && n.Periode.idTrimestre == p.idTrimestre)
                                      .Sum(n => n.note * GetCoefficient(e.idSerie, n.idMatiere))
                                  / _context.Notes
                                      .Where(n => n.matricule == e.matricule && n.Periode.idTrimestre == p.idTrimestre)
                                      .Sum(n => GetCoefficient(e.idSerie, n.idMatiere))
                    })
            })
            .ToList();

        if (moyennes == null)
        {
            return NotFound();
        }

        return Ok(moyennes);
    }

    private double GetCoefficient(int idSerie, int idMatiere)
    {
        var coefficient = _context.Coefficients
            .FirstOrDefault(c => c.idSerie == idSerie && c.idMatiere == idMatiere);
    
        return coefficient != null ? coefficient.coeff : 1; // Default coefficient is 1 if not found.
    }


    
    [HttpGet("{idSerie}")]
    public IActionResult GetMoyenPremiere(string idSerie)
    {
        var notes = _context.Notes
            .Where(p => p.matricule.Contains(idSerie) ||
                        p.idNote.ToString().Contains(idSerie));
        if (notes == null)
        {
            return NotFound();
        }
        return Ok(notes);
    }
    
    [HttpGet("{idSerie}")]
    public IActionResult GetMoyenTerminal(string idSerie)
    {
        var notes = _context.Notes
            .Where(p => p.matricule.Contains(idSerie) ||
                        p.idNote.ToString().Contains(idSerie));
        if (notes == null)
        {
            return NotFound();
        }
        return Ok(notes);
    }
    */
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
            // verifie s'il deja existé
            List<Note> note = _context.Notes
                .Where(m => m.matricule == notes.matricule &&
                            m.idMatiere == notes.idMatiere && 
                            m.idPeriode == notes.idPeriode).ToList();
            
            if (note.Count() == 0)
            {
                _context.Notes?.Add(notes);
                await _context.SaveChangesAsync();
                return Ok("Note ajoutée avec succès pour l'étudiant avec le matricule " + notes.matricule);
            }
            
            return BadRequest(note.Count());

        }
        else
        {
            return BadRequest("Notes context is null.");
        }
    }


    [HttpPut("update")]
    public async Task<IActionResult> UpdateNote(int id, Note updateNote)
    {
        _context.Entry(updateNote).State = EntityState.Modified;
        _context.SaveChanges();
        
        if (_context.Etudiants != null)
        {
            var existNote = await _context.Notes
                .Include(e => e.Etudiant)
                .Include(n => n.Matiere)
                .FirstOrDefaultAsync(m => m.idNote == id);
        
            if (existNote==null)
            {
                return NotFound();
            }

            existNote.note = updateNote.note;
            await _context.SaveChangesAsync();
            return Ok(existNote);
        }

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