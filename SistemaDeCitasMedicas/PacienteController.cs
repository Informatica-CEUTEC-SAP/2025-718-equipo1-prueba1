using Microsoft.AspNetCore.Mvc;

namespace SistemaDeCitasMedicas;

[ApiController]
[Route("api/[controller]")]

public class PacienteController : ControllerBase
{
    private static List <Pacientes> pacientes = new()
    {
        new Pacientes
        {
            ID = Guid.NewGuid(),
            Nombre = "Julio",
            Fechadenacimiento = 05/3-2020,
            email = "JulioMaster@gmail.com"
            
            
        },
        new Pacientes
        {
        ID = Guid.NewGuid(),
        Nombre = "Julio",
        Fechadenacimiento = 05/3-2020,
        email = "Karinamartez@gmail.com"
            
            
    },
    new Pacientes
    {
        ID = Guid.NewGuid(),
        Nombre = "Marta",
        Fechadenacimiento = 04/9-2190,
        email = "MartaHabla@gmail.com"
            
            
    }
    
       
    };

    [HttpGet]
    public IActionResult GeatAll()
    {
        return Ok(pacientes);
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var Pacientes = pacientes.FirstOrDefault(p => p.ID == id);
        if (Pacientes == null) return NotFound();
        return Ok(Pacientes);
    }

    [HttpPost]
    public IActionResult Create(Pacientes nuevoPacientes)
    {
        nuevoPacientes.ID = Guid.NewGuid();
        pacientes.Add(nuevoPacientes);
        return CreatedAtAction(nameof(GetById), new { id = nuevoPacientes.ID }, nuevoPacientes);

    }
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, Pacientes actualizado)
    {
        var Pacientes = pacientes.FirstOrDefault(p => p.ID == id);
        if (Pacientes == null) return NotFound();

        Pacientes.Nombre = actualizado.Nombre;
        Pacientes.Fechadenacimiento = actualizado.Fechadenacimiento;
        Pacientes.email = actualizado.email;

        return NoContent();
    }
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var Pacientes = pacientes.FirstOrDefault(p => p.ID == id);
        if (Pacientes == null) return NotFound();

        pacientes.Remove(Pacientes);
        return NoContent();
    }
    

}