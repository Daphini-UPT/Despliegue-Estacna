using System;
using System.Collections.Generic;

namespace EsTacna.Models;

/**
* Clase que representa una búsqueda realizada por un usuario.
*/

public partial class Busquedum
{
    /**
    * Id de la búsqueda.
    */
    public int Id { get; set; }

    /**
    * Id del usuario que realizó la búsqueda.
    */
    public int UsuarioId { get; set; }

    /**
    * Término de búsqueda utilizado por el usuario.
    */
    public string TerminoBusqueda { get; set; } = null!;

    /**
    * Fecha y hora en que se realizó la búsqueda.
    */
    public DateTime Fecha { get; set; }

    /**
    * Usuario que realizó la búsqueda.
    */
    public virtual Usuario Usuario { get; set; } = null!;
}
