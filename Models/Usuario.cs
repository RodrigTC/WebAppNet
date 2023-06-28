using System;
using System.Collections.Generic;

namespace TRABAJO_FINAL.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string Nombreu { get; set; } = null!;

    public string Apellidou { get; set; } = null!;

    public string Correou { get; set; } = null!;

    public string Contraseñau { get; set; } = null!;

    public DateTime Nacimiento { get; set; }

    public string Genero { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();
}
