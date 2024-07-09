using EsTacna.Models;

/**
* Clase que representa el modelo de vista para la visualización de información de establecimientos de salud.
*/

namespace EsTacna.ViewModels
{
    public class ClinicaViewModel
    {
        /**
        * Clinica a mostrar en la vista.
        */
        public EstablecimientoSalud clinica { get; set; }

        /**
        * Usuario asociado a la clinica.
        */
        public Usuario usuario { get; set; }

        /**
        * Calificación asignada a la clinica.
        */
        public Valoracion calificacion { get; set; }

        /**
        * Lista de valoraciones de la clinica.
        */
        public List<Valoracion> listValoracion { get; set; }

        /**
        * Total de valoraciones de la clinica.
        */
        public int totalValoraciones { get; set; }

        /**
        * Empresa Prestadora de Salud (EPS) asociada a la clinica.
        */
        public Ep eps { get; set; }

        /**
        * Lista de establecimientos de salud.
        */
        public List<EstablecimientoSalud> listClinica { get; set; }

        /**
        * Lista de EPS.
        */
        public List<Ep> listEps { get; set; }

        /**
        * Clasificación de la clinica.
        */
        public string clasificacion { get; set; }

        /**
        * Lista de establecimientos recomendados.
        */
        public List<EstablecimientoSalud> recoClinica { get; set; }
    }
}
