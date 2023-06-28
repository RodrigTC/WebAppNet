using System;
using System.Collections.Generic;

namespace TRABAJO_FINAL.Models;

public partial class Dium
{
    public int IdDia { get; set; }

    public string Dia { get; set; } = null!;

    public virtual ICollection<Citum> Cita { get; set; } = new List<Citum>();
}
