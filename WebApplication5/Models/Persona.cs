using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Direccion { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string Sexo { get; set; } = null!;

    public string NumeroTelf { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
