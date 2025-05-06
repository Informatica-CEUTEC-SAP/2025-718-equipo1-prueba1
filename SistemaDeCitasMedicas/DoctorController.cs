using Microsoft.AspNetCore.Mvc;

namespace sistema_de_citas_medicas;

[ApiController]
[Route("api/[controller]")]
public class DoctoresController : ControllerBase
{
    private static readonly List<Doctor> _doctores = new();

   
    [HttpGet]
    public ActionResult<IEnumerable<Doctor>> GetAll()
    {
        return Ok(_doctores);
    }
    
    [HttpGet("{id}")]
    public ActionResult<Doctor> GetById(Guid id)
    {
        var doctor = _doctores.FirstOrDefault(d => d.Id == id);
        if (doctor == null) return NotFound();
        return Ok(doctor);
    }

   
    [HttpPost]
    public ActionResult<Doctor> Create([FromBody] Doctor nuevoDoctor)
    {
        nuevoDoctor.Id = Guid.NewGuid();
        _doctores.Add(nuevoDoctor);
        return CreatedAtAction(nameof(GetById), new { id = nuevoDoctor.Id }, nuevoDoctor);
    }
    
    [HttpPut("{id}")]
    public ActionResult<Doctor> Update(Guid id, [FromBody] Doctor doctorActualizado)
    {
        var index = _doctores.FindIndex(d => d.Id == id);
        if (index == -1) return NotFound();

        doctorActualizado.Id = id;
        _doctores[index] = doctorActualizado;
        return Ok(doctorActualizado);
    }

    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var doctor = _doctores.FirstOrDefault(d => d.Id == id);
        if (doctor == null) return NotFound();

        _doctores.Remove(doctor);
        return NoContent();
    }
}