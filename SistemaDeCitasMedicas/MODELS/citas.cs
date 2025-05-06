namespace sistema_de_citas_medicas;
public class Cita
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime FechaHora { get; set; }

    public Guid DoctorId { get; set; }

    public Guid PacienteId { get; set; }

    public string Motivo { get; set; }
}