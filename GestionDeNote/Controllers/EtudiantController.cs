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
                .Include(e=> e.Periode!.Annee)
                .Include(e=> e.Periode!.Trimestre)
                .Include(e=> e.Serie!.Classe).ToList();
            return Ok(etudiants);
        }

        return NoContent();
    }
    
    [HttpGet("seconde")]
    public ActionResult<IEnumerable<Etudiant>> GetEtudiantSeconde()
    {
        if (_context.Etudiants != null)
        {
            var etudiants = _context.Etudiants
                .Include(e=> e.Periode!.Annee)
                .Include(e=> e.Periode!.Trimestre)
                .Include(e=> e.Serie!.Classe)
                .Where(e => e.Serie!.Classe!.idClasse == 1)
                .ToList();
            return Ok(etudiants);
        }

        return NoContent();
    }
    
    
    [HttpGet("terminale")]
    public ActionResult<IEnumerable<Etudiant>> GetEtudiantTerminale(int id)
    {
        if (_context.Etudiants != null)
        {
            var etudiants = _context.Etudiants
                .Include(e=> e.Periode!.Annee)
                .Include(e=> e.Periode!.Trimestre)
                .Include(e=> e.Serie!.Classe)
                .Where(e => (e.Serie!.Classe!.idClasse == 3 && 
                             e.idSerie == id))
                .ToList();
            return Ok(etudiants);
        }

        return NoContent();
    }
    
    [HttpGet("premiereL")]
    public ActionResult<IEnumerable<Etudiant>> GetEtudiantPremiereL()
    {
        if (_context.Etudiants != null)
        {
            var etudiants = _context.Etudiants
                .Include(e=> e.Periode!.Annee)
                .Include(e=> e.Periode!.Trimestre)
                .Include(e=> e.Serie!.Classe)
                .Where(e => (e.Serie!.Classe!.idClasse == 2 && 
                             e.idSerie ==  3))
                .ToList();
            return Ok(etudiants);
        }

        return NoContent();
    }
    
    [HttpGet("premiereS")]
    public ActionResult<IEnumerable<Etudiant>> GetEtudiantPremiereS()
    {
        if (_context.Etudiants != null)
        {
            var etudiants = _context.Etudiants
                .Include(e=> e.Periode!.Annee)
                .Include(e=> e.Periode!.Trimestre)
                .Include(e=> e.Serie!.Classe)
                .Where(e => (e.Serie!.Classe!.idClasse == 2 && 
                             e.idSerie ==  2))
                .ToList();
            return Ok(etudiants);
        }

        return NoContent();
    }
    
    private string GenererNextId()
    {
        var lastId = _context.Etudiants.OrderByDescending(n => n.matricule)
            .Select(n => n.matricule)
            .FirstOrDefault();
      
        if (lastId == null)
        {
            return "001";
        }

        int lastNumber = int.Parse(lastId);
        string nexNumber = (lastNumber + 1).ToString("D3");
        string nextId = nexNumber;
        return nextId;
    }
    
    //create
    [HttpPost("create")]
    public IActionResult CreateEtudiant(Etudiant etudiant)
    {

        etudiant.matricule = GenererNextId();
        
        if (etudiant.Serie != null && !string.IsNullOrEmpty(etudiant.Serie.idClasse.ToString()))
        {
            _context.Attach(etudiant.Serie);
        }

        if (etudiant.Serie != null && !string.IsNullOrEmpty(etudiant.Serie.idSerie.ToString()))
        {
            _context.Attach(etudiant.Serie);
        }
        _context.Etudiants?.Add(etudiant);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEtudiant), new { name = etudiant.nom + " " + etudiant.prenoms});
    }
    
    //find 
    [HttpGet("{id}")]
    public IActionResult FindEtudiant(string id)
    {
        if (_context.Etudiants != null)
        {
            var etudiant = _context.Etudiants
                .Include(e=> e.Periode!.Annee)
                .Include(e=> e.Periode!.Trimestre)
                .Include(e=> e.Serie!.Classe)
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
                .Include(e=> e.Periode!.Annee)
                .Include(e=> e.Periode!.Trimestre)
                .Include(e=> e.Serie!.Classe)
                .FirstOrDefaultAsync(e=>e.matricule == id);
        
            if (existEtudiant==null)
            {
                return NotFound();
            }

            existEtudiant.nom = updateEtudiant.nom;
            existEtudiant.prenoms = updateEtudiant.prenoms;
            existEtudiant.adresse = updateEtudiant.adresse;
            existEtudiant.email = updateEtudiant.email;
            existEtudiant.idSerie = updateEtudiant.idSerie;
            existEtudiant.idPeriode = updateEtudiant.idPeriode;
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
                .Include(e=>e.Periode)
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