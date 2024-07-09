using System;
using System.Collections.Generic;

namespace EsTacna.Models;

/**
* Clase que representa una valoración realizada por un usuario a un establecimiento de salud.
*/

public partial class Valoracion
{
    /**
    * Id de la valoración.
    */
    public int Id { get; set; }

    /**
    * Id del establecimiento de salud valorado.
    */
    public int EstablecimientoId { get; set; }

    /**
    * Id del usuario que realiza la valoración.
    */
    public int UsuarioId { get; set; }

    /**
    * Comentario asociado a la valoración.
    */
    public string? Comentario { get; set; }

    /**
    * Calificación asignada en la valoración.
    */
    public int Calificacion { get; set; }

    /**
    * Establecimiento de salud asociado a la valoración.
    */
    public virtual EstablecimientoSalud Establecimiento { get; set; } = null!;

    /**
    * Usuario que realiza la valoración.
    */
    public virtual Usuario Usuario { get; set; } = null!;
}
