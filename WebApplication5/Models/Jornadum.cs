using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Jornadum
{
    public int IdJornada { get; set; }

    public string Tipo { get; set; } = null!;

    public TimeOnly HoraEntrada { get; set; }

    public TimeOnly HoraSalida { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
