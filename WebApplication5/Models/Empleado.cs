using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int IdPersona { get; set; }

    public int IdCargo { get; set; }

    public int IdJornada { get; set; }

    public string Ci { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual Jornadum IdJornadaNavigation { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
