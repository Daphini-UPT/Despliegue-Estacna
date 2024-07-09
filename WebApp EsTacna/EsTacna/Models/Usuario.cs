using System;
using System.Collections.Generic;

namespace EsTacna.Models;

/**
* Clase que representa un usuario en el sistema.
*/

public partial class Usuario
{
    /**
    * Id del usuario.
    */
    public int Id { get; set; }

    /**
    * Nombre del usuario.
    */
    public string Nombre { get; set; } = null!;

    /**
    * Apellido del usuario.
    */
    public string Apellido { get; set; } = null!;

    /**
    * Correo electrónico del usuario.
    */
    public string Email { get; set; } = null!;

    /**
    * Contraseña del usuario.
    */
    public string Contrasena { get; set; } = null!;

    /**
    * Colección de búsquedas realizadas por el usuario.
    */
    public virtual ICollection<Busquedum> Busqueda { get; set; } = new List<Busquedum>();

    /**
    * Colección de valoraciones realizadas por el usuario.
    */
    public virtual ICollection<Valoracion> Valoracions { get; set; } = new List<Valoracion>();
}
