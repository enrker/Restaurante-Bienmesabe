using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<ProductoIngrediente> ProductoIngredientes { get; set; } = new List<ProductoIngrediente>();

    public virtual ICollection<VentaProducto> VentaProductos { get; set; } = new List<VentaProducto>();
}
