namespace sistema_de_citas_medicas;

public class Doctor
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nombre { get; set; }

    public string Especialidad { get; set; }

    public string Email { get; set; }
}