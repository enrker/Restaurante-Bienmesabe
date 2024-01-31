using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Suministro
{
    public int IdSuministro { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioUnitario { get; set; }

    public virtual ICollection<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<SuministroProveedor> SuministroProveedors { get; set; } = new List<SuministroProveedor>();
}
