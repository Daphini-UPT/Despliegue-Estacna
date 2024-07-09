using System;
using System.Collections.Generic;

namespace EsTacna.Models;

/**
* Clase que representa la relación entre una Empresa Prestadora de Salud (EPS) y un Establecimiento de Salud.
*/
public partial class EpsEstablecimientoSalud
{
    /**
    * Id de la relación entre EPS y Establecimiento de Salud.
    */
    public int Id { get; set; }

    /**
    * Id de la EPS asociada a la relación.
    */
    public int EpsId { get; set; }

    /**
    * Id del Establecimiento de Salud asociado a la relación.
    */
    public int EstablecimientoId { get; set; }

    /**
    * EPS asociada a la relación.
    */
    public virtual Ep Eps { get; set; } = null!;

    /**
    * Establecimiento de Salud asociado a la relación.
    */
    public virtual EstablecimientoSalud Establecimiento { get; set; } = null!;
}
