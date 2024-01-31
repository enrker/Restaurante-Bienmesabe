using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class ProductoIngrediente
{
    public int IdProductoIngrediente { get; set; }

    public int IdProducto { get; set; }

    public int IdIngrediente { get; set; }

    public virtual Ingrediente IdIngredienteNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
