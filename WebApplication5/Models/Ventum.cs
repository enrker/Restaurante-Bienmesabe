using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int IdCliente { get; set; }

    public int IdTipoConsumo { get; set; }

    public DateOnly FechaVenta { get; set; }

    public TimeOnly HoraVenta { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual TipoConsumo IdTipoConsumoNavigation { get; set; } = null!;

    public virtual ICollection<VentaProducto> VentaProductos { get; set; } = new List<VentaProducto>();
}
