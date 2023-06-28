using System;
using System.Collections.Generic;

namespace TRABAJO_FINAL.Models;

public partial class Especialidad
{
    public int IdEspecialidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
