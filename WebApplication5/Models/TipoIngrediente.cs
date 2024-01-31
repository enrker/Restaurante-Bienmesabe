using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class TipoIngrediente
{
    public int IdTipo { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
}
