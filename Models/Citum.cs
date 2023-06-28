using System;
using System.Collections.Generic;

namespace TRABAJO_FINAL.Models;

public partial class Citum
{
    public int IdCita { get; set; }

    public int IdUser { get; set; }

    public string NomUser { get; set; } = null!;

    public int IdDoctor { get; set; }

    public string NomDoctor { get; set; } = null!;

    public int IdEspecialidad { get; set; }

    public string NomEspecialidad { get; set; } = null!;

    public int IdHorarios { get; set; }

    public TimeSpan Horario { get; set; }

    public int IdDia { get; set; }

    public string Dia { get; set; } = null!;

    public double Costo { get; set; }

    public virtual Dium IdDiaNavigation { get; set; } = null!;

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;

    public virtual Especialidad IdEspecialidadNavigation { get; set; } = null!;

    public virtual Horario IdHorariosNavigation { get; set; } = null!;

    public virtual Usuario IdUserNavigation { get; set; } = null!;
}
