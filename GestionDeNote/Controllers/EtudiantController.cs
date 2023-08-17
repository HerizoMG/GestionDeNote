using GestionDeNote.Data;
using GestionDeNote.Model;
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
        var etudiants = _context.Etudiants
            .Include(e=> e.Classe)
            .Include(e=> e.Serie).ToList();
        return Ok(etudiants);
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
        _context.Etudiants.Add(etudiant);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEtudiant), new { id = etudiant.matricule});
        
    }
    //find 
    [HttpGet("{id}")]
    public IActionResult FindEtudiant(string id)
    {
        var etudiant = _context.Etudiants.Find(id);
        if (etudiant == null)
        {
            return NotFound();
        }
        return Ok(etudiant);
        
    }
    
    //update
    [HttpPut("update")]
    public IActionResult UpdateEtudiant(string id, Etudiant updateEtudiant)
    {
        var existEtudiant = _context.Etudiants.Find(id);
        if (existEtudiant==null)
        {
            return NotFound();
        }

        existEtudiant.nom = updateEtudiant.nom;
        existEtudiant.prenoms = updateEtudiant.prenoms;
        existEtudiant.adresse = updateEtudiant.adresse;
        existEtudiant.mail = updateEtudiant.mail;
        _context.SaveChanges();
        return Ok(existEtudiant);
    }
    //delete
    [HttpDelete("{id}")]
    public IActionResult DeleteEtudiant(string id)
    {
        var etudiant = _context.Etudiants.Find(id);
        if (etudiant==null)
        {
            return NotFound();
        }
        var notes = _context.Notes
            .Where(p => p.matricule.Contains(id)).ToList();
        if (notes==null)
        {
            return NotFound();
        }
        _context.Notes.RemoveRange(notes);
        _context.SaveChanges();
        _context.Etudiants.Remove(etudiant);
        _context.SaveChanges();

        return NoContent();
    }
    
}