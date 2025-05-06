using Microsoft.AspNetCore.Mvc;

namespace sistema_de_citas_medicas;

[ApiController]
[Route("api/[controller]")]
public class CitasController : ControllerBase
{
    private static readonly List<Cita> _citas = new();

    
    [HttpGet]
    public ActionResult<IEnumerable<Cita>> GetAll()
    {
        return Ok(_citas);
    }

    
    [HttpGet("doctor/{id}")]
    public ActionResult<IEnumerable<Cita>> GetByDoctor(Guid id)
    {
        var citasDoctor = _citas.Where(c => c.DoctorId == id).ToList();
        return Ok(citasDoctor);
    }

    
    [HttpPost]
    public ActionResult<Cita> Create([FromBody] Cita nuevaCita)
    {
        nuevaCita.Id = Guid.NewGuid();
        _citas.Add(nuevaCita);
        return CreatedAtAction(nameof(GetAll), null, nuevaCita);
    }

    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var cita = _citas.FirstOrDefault(c => c.Id == id);
        if (cita == null) return NotFound();

        _citas.Remove(cita);
        return NoContent();
    }
}