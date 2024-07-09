using System;
using System.Collections.Generic;

namespace EsTacna.Models;

/**
* Clase que representa una Empresa Prestadora de Salud (EPS).
*/

public partial class Ep
{
    /**
    * Id de la EPS.
    */
    public int Id { get; set; }

    /**
    * Nombre de la EPS.
    */
    public string Nombre { get; set; } = null!;

    /**
    * Colección de relaciones entre la EPS y los establecimientos de salud.
    */
    public virtual ICollection<EpsEstablecimientoSalud> EpsEstablecimientoSaluds { get; set; } = new List<EpsEstablecimientoSalud>();
}
