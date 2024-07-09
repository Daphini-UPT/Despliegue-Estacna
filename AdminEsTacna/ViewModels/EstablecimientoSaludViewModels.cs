using AdminEsTacna.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

/**
* Clase que representa el modelo de vista para la visualización de información de establecimientos de salud.
*/

namespace AdminEsTacna.ViewModels
{
    public class EstablecimientoSaludViewModel
    {
        /**
        * Establecimiento de salud a mostrar en la vista.
        */
        public EstablecimientoSalud establecimientoSalud { get; set; }

        /**
        * Usuario asociado al establecimiento de salud.
        */
        public Usuario usuario { get; set; }

        /**
        * Calificación asignada al establecimiento de salud.
        */
        public Valoracion calificacion { get; set; }

        /**
        * Lista de valoraciones del establecimiento de salud.
        */
        public List<Valoracion> listValoracion { get; set; }

        /**
        * Total de valoraciones del establecimiento de salud.
        */
        public int TotalValoraciones { get; set; }

        /**
        * Empresa Prestadora de Salud (EPS) asociada al establecimiento de salud.
        */
        public Ep eps { get; set; }

        /**
        * Lista de establecimientos de salud.
        */
        public List<EstablecimientoSalud> listEstablecimiento { get; set; }

        /**
        * Lista de EPS.
        */
        public List<Ep> listEps { get; set; }

        /**
        * Clasificación del establecimiento de salud.
        */
        public string Clasificacion { get; set; }

        /**
        * Lista de establecimientos recomendados.
        */
        public List<EstablecimientoSalud> RecoEstablecimiento { get; set; }

        // Diccionario para almacenar los establecimientos agrupados por EPS
        public Dictionary<int, List<EstablecimientoSalud>> EstablishmentsByEps { get; set; }

        // Propiedades de paginación
        public int PaginaActual { get; set; }
        public int ElementosPorPagina { get; set; }
        public int TotalElementos { get; set; }

        // Propiedad para almacenar la selección del dropdown
        public Dictionary<int, int?> SeleccionDropdown { get; set; }

        // Nueva propiedad para almacenar los elementos del dropdown
        public List<SelectListItem> SelectListClinicas { get; set; }

        // Constructor para inicializar la propiedad
        public EstablecimientoSaludViewModel()
        {
            EstablishmentsByEps = new Dictionary<int, List<EstablecimientoSalud>>();
            ElementosPorPagina = 2; // Número de EPS por página
            SelectListClinicas = new List<SelectListItem>();
        }
    }
}
