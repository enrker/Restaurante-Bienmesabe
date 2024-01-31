using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Menu
{
    public int IdMenu { get; set; }

    public int IdProducto { get; set; }

    public string? Descripcion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
