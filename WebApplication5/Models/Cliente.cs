using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ci { get; set; } = null!;

    public int IdEmpleado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
