using System.Diagnostics.CodeAnalysis;
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
    [SuppressMessage("ReSharper.DPA", "DPA0009: High execution time of DB command", MessageId = "time: 983ms")]
    public ActionResult<IEnumerable<Etudiant>> GetEtudiant()
    {
        if (_context.Etudiants != null)
        {
            var etudiants = _context.Etudiants
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
                .Include(e=> e.Serie!.Classe)
                .Where(e => e.Serie!.Classe!.idClasse == 1)
                .ToList();
            return Ok(etudiants);
        }

        return NoContent();
    }
    
    [HttpGet("classes/{idClasse}/trimestres/{idTrimestre}")]
    public IActionResult GetMoyenneGeneraleParClasse(int idClasse, int idTrimestre)
    {
        var moyennesParClasse = _context.Etudiants
            .Where(e => e.Serie.idClasse == idClasse)
            .GroupBy(e => e.Serie.idClasse)
            .Select(g => new
            {
                Classe = _context.Classes.FirstOrDefault(c => c.idClasse == idClasse).niveau,
                MoyenneGenerale = g.SelectMany(s => _context.Notes
                                          .Where(n => n.matricule == s.matricule && n.Etudiant.Serie.idClasse == idClasse && n.Periode.idTrimestre == idTrimestre)
                                          .Select(n => n.note * _context.Coefficients.FirstOrDefault(c => c.idMatiere == n.idMatiere && c.idSerie == s.idSerie).coeff))
                                      .Sum() /
                                  g.SelectMany(s => _context.Notes
                                          .Where(n => n.matricule == s.matricule && n.Etudiant.Serie.idClasse == idClasse && n.Periode.idTrimestre == idTrimestre)
                                          .Select(n => _context.Coefficients.FirstOrDefault(c => c.idMatiere == n.idMatiere && c.idSerie == s.idSerie).coeff))
                                      .Sum()
            })
            .ToList();

        if (moyennesParClasse.Count == 0)
        {
            return NotFound();
        }

        return Ok(moyennesParClasse);
    }

    
    [HttpGet("classes/etudiants")]
    public IActionResult GetNombreEtudiantsParClasse()
    {
        var classes = _context.Classes.ToList();

        var nomsClasses = classes.Select(c => c.niveau).ToList();

        var nombresEtudiants = classes.Select(c => _context.Etudiants
                .Where(e => e.Serie.idClasse == c.idClasse)
                .Count())
            .ToList();

        var resultat = new
        {
            NomsClasses = nomsClasses,
            NombresEtudiants = nombresEtudiants
        };

        return Ok(resultat);
    }

    
    [HttpGet("series/{idSerie}/etudiants")]
    public IActionResult GetEtudiantsBySerie(int idSerie)
    {
        var etudiants = _context.Etudiants
            .Where(e => e.idSerie == idSerie)
            .ToList();

        if (etudiants.Count == 0)
        {
            return NotFound();
        }

        return Ok(etudiants);
    }

    
    [HttpGet("terminale")]
    public ActionResult<IEnumerable<Etudiant>> GetEtudiantTerminale(int id)
    {
        if (_context.Etudiants != null)
        {
            var etudiants = _context.Etudiants
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