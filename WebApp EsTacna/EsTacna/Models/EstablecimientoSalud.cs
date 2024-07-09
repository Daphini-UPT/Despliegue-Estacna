using System;
using System.Collections.Generic;

namespace EsTacna.Models;

/**
* Clase que representa un Establecimiento de Salud.
*/

public partial class EstablecimientoSalud
{
    /**
    * Id del establecimiento de salud.
    */
    public int Id { get; set; }

    /**
    * Nombre del establecimiento de salud.
    */
    public string Nombre { get; set; } = null!;

    /**
    * Ciudad donde se encuentra el establecimiento de salud.
    */
    public string Ciudad { get; set; } = null!;

    /**
    * Dirección del establecimiento de salud.
    */
    public string Direccion { get; set; } = null!;

    /**
    * Longitud geográfica del establecimiento de salud.
    */
    public decimal Longitud { get; set; }

    /**
    * Latitud geográfica del establecimiento de salud.
    */
    public decimal Latitud { get; set; }

    /**
    * Descripción del establecimiento de salud.
    */
    public string? Descripcion { get; set; }

    /**
    * URL de la imagen del establecimiento de salud.
    */
    public string? Imagen { get; set; }

    /**
    * Colección de relaciones entre la EPS y el establecimiento de salud.
    */
    public virtual ICollection<EpsEstablecimientoSalud> EpsEstablecimientoSaluds { get; set; } = new List<EpsEstablecimientoSalud>();

    /**
    * Colección de valoraciones del establecimiento de salud.
    */
    public virtual ICollection<Valoracion> Valoracions { get; set; } = new List<Valoracion>();
}
