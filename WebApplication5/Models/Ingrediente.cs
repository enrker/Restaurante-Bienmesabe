using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Ingrediente
{
    public int IdIngrediente { get; set; }

    public int IdTipo { get; set; }

    public int IdSuministro { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public virtual Suministro IdSuministroNavigation { get; set; } = null!;

    public virtual TipoIngrediente IdTipoNavigation { get; set; } = null!;

    public virtual ICollection<ProductoIngrediente> ProductoIngredientes { get; set; } = new List<ProductoIngrediente>();
}
