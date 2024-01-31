using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class TipoConsumo
{
    public int IdTipoConsumo { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
