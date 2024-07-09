using System;
using System.Collections.Generic;

namespace AdminEsTacna.Models;

public partial class EpsEstablecimientoSalud
{
    public int Id { get; set; }

    public int EpsId { get; set; }

    public int EstablecimientoId { get; set; }

    public virtual Ep Eps { get; set; } = null!;

    public virtual EstablecimientoSalud Establecimiento { get; set; } = null!;
}
