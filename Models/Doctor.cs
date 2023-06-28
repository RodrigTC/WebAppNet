using System;
using System.Collections.Generic;

namespace TRABAJO_FINAL.Models;

public partial class Doctor
{
    public int IdDoctor { get; set; }

    public string NombreD { get; set; } = null!;

    public string ApellidoD { get; set; } = null!;

    public int IdEspecialidad { get; set; }

    public string CorreoD { get; set; } = null!;

    public string ContraseñaD { get; set; } = null!;

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual Especialidad IdEspecialidadNavigation { get; set; } = null!;
}
