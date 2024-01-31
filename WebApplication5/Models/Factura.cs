using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int IdVenta { get; set; }

    public int NumeroFactura { get; set; }

    public DateOnly FechaEmision { get; set; }

    public int IdTipoPago { get; set; }

    public int IdEmpleado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual TipoPago IdTipoPagoNavigation { get; set; } = null!;

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
