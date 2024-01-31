using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class TipoPago
{
    public int IdTipoPago { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
