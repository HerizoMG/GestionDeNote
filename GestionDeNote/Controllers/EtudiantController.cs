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
        var etudiants = _context.Etudiants;

        return Ok(etudiants);
    }


    
    //create
    [HttpPost("create")]
    public IActionResult CreateEtudiant(Etudiant etudiant)
    {
        _context.Etudiants.Add(etudiant);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEtudiant), new { id = etudiant.num_matricule});
        
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
        var posseder = _context.Posseders
            .Where(p => p.num_matricule.Contains(id)).ToList();
        if (posseder==null)
        {
            return NotFound();
        }
        _context.Posseders.RemoveRange(posseder);
        _context.SaveChanges();
        _context.Etudiants.Remove(etudiant);
        _context.SaveChanges();

        return NoContent();
    }
    
}