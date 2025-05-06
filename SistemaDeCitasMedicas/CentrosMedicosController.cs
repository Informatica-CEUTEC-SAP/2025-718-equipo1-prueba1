using Microsoft.AspNetCore.Mvc;

namespace SistemaDeCitasMedicas;

[ApiController]
[Route("api/[controller]")]

public class CentrosMedicosController : Controller
{
    private static List<CentrosMedicos> centrosmedicos = new()
    {
        new CentrosMedicos
        {
            Id = new Guid(),
            Nombre = "Por Salud",
            Ciudad = "SanPedro Sula",
            Direccion = "Calle 13, 11 avenida",
            Numero = 98890989,

        },
        new CentrosMedicos
        {
            Id = new Guid(),
            Nombre = "Catarino Rivas",
            Ciudad = "Choloma",
            Direccion = "Valle De sula",
            Numero = 48899024,

        },
        new CentrosMedicos
        {
            Id = new Guid(),
            Nombre = "Por Salud",
            Ciudad = "SanPedro Sula",
            Direccion = "Calle 13, 11 avenida",
            Numero = 86905890,

        },
    };
    
    [HttpGet]
    public IActionResult GeatAll()
    {
        return Ok(centrosmedicos);
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var centrosMedicos = centrosmedicos.FirstOrDefault(p => p.Id == id);
        if (centrosMedicos == null) return NotFound();
        return Ok(centrosMedicos);
    }

    [HttpPost]
    public IActionResult Create(CentrosMedicos nuevoCentromedico)
    {
        nuevoCentromedico.Id = Guid.NewGuid();
        centrosmedicos.Add(nuevoCentromedico);
        return CreatedAtAction(nameof(GetById), new { id = nuevoCentromedico.Id }, nuevoCentromedico);

    }
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, CentrosMedicos actualizado)
    {
        var centrosMedicos = centrosmedicos.FirstOrDefault(p => p.Id == id);
        if (centrosMedicos == null) return NotFound();

        centrosMedicos.Ciudad = actualizado.Ciudad;
        centrosMedicos.Direccion = actualizado.Direccion;
        centrosMedicos.Nombre = actualizado.Nombre;
        centrosMedicos.Numero = actualizado.Numero;


        return NoContent();
    }
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var centrosMedicos = centrosmedicos.FirstOrDefault(p => p.Id == id);
        if (centrosMedicos == null) return NotFound();

        centrosmedicos.Remove(centrosMedicos);
        return NoContent();
    }
    
    


}