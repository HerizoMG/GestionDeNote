using GestionDeNote.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeNote.Controllers;


[ApiController]
[Route("[Controller]")]
    
public class EtudiantController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EtudiantController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Etudiant>> GetEtudiant()
    {
        if (_context.Etudiants != null)
        {
            var etudiants = _context.Etudiants
                .Include(e=> e.Classe)
                .Include(e=> e.Serie).ToList();
            return Ok(etudiants);
        }

        return NoContent();
    }


    
    //create
    [HttpPost("create")]
    public IActionResult CreateEtudiant(Etudiant etudiant)
    {
        if (etudiant.Classe != null && !string.IsNullOrEmpty(etudiant.Classe.idClasse.ToString()))
        {
            _context.Attach(etudiant.Classe);
        }

        if (etudiant.Serie != null && !string.IsNullOrEmpty(etudiant.Serie.numSerie.ToString()))
        {
            _context.Attach(etudiant.Serie);
        }
        _context.Etudiants?.Add(etudiant);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEtudiant), new { id = etudiant.matricule});
        
    }
    //find 
    [HttpGet("{id}")]
    public IActionResult FindEtudiant(string id)
    {
        if (_context.Etudiants != null)
        {
            var etudiant = _context.Etudiants
                .Include(e=>e.Classe)
                .Include(e=>e.Serie)
                .FirstOrDefault(e=>e.matricule == id);
        
            if (etudiant == null)
            {
                return NotFound();
            }
            return Ok(etudiant);
        }

        return NotFound();
    }
    
    //update
    [HttpPut("update")]
    public async Task<IActionResult> UpdateEtudiant(string id, Etudiant updateEtudiant)
    {
        if (_context.Etudiants != null)
        {
            var existEtudiant = await _context.Etudiants
                .Include(e=>e.Classe)
                .Include(e=>e.Serie)
                .FirstOrDefaultAsync(e=>e.matricule == id);
        
            if (existEtudiant==null)
            {
                return NotFound();
            }

            existEtudiant.nom = updateEtudiant.nom;
            existEtudiant.prenoms = updateEtudiant.prenoms;
            existEtudiant.adresse = updateEtudiant.adresse;
            existEtudiant.mail = updateEtudiant.mail;
            existEtudiant.numSerie = updateEtudiant.numSerie;
            existEtudiant.idClasse = updateEtudiant.idClasse;
            await _context.SaveChangesAsync();
            return Ok(existEtudiant);
        }

        return NoContent();
    }
    //delete
    [HttpDelete("{id}")]
    public IActionResult DeleteEtudiant(string id)
    {
        if (_context.Etudiants != null)
        {
            var etudiant = _context.Etudiants
                .Include(e=>e.Classe)
                .Include(e=>e.Serie)
                .FirstOrDefault(e=>e.matricule == id);
            if (etudiant==null)
            {
                return NotFound();
            }

            if (_context.Notes != null)
            {
                var notes = _context.Notes
                    .Where(p => p.matricule.Contains(id)).ToList();
                _context.Notes.RemoveRange(notes);
            }

            _context.SaveChangesAsync();
        
            _context.Etudiants.Remove(etudiant);
        }

        _context.SaveChangesAsync();

        return NoContent();
    }
    
}