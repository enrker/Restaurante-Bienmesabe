using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class SuministroProveedor
{
    public int IdSuministroProveedor { get; set; }

    public int IdProveedor { get; set; }

    public int IdSuministro { get; set; }

    public DateOnly FechaEntrega { get; set; }

    public string? Descripcion { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual Suministro IdSuministroNavigation { get; set; } = null!;
}
