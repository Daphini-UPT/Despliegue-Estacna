using EsTacna.Models;
using Microsoft.EntityFrameworkCore;

/**
* Interface para el repositorio de valoraciones.
*/

namespace EsTacna.Repositories
{
    public interface IValoracionRepository
    {
        /**
        * Guarda una nueva valoración.
        * @param objValoracion Objeto Valoracion a guardar.
        */
        void Guardar(Valoracion objValoracion);

        /**
        * Lista las valoraciones por el ID de la clinica.
        * @param clinicaId ID de la clinica.
        * @return Lista de valoraciones correspondientes a la clinica proporcionada.
        */
        List<Valoracion> ListarPorClinicaId(int clinicaId);
    }

    /**
    * Implementación del repositorio de valoraciones.
    */
    public class ValoracionRepositoryImpl : IValoracionRepository
    {
        /** Contexto de base de datos de EsTacna */
        private readonly EsTacnaContext _context;

        /**
        * Constructor que inicializa el contexto de base de datos.
        * @param context Contexto de base de datos de EsTacna.
        */
        public ValoracionRepositoryImpl(EsTacnaContext context)
        {
            _context = context;
        }

        /**
        * Guarda una nueva valoración.
        * @param objValoracion Objeto Valoracion a guardar.
        */
        public void Guardar(Valoracion objValoracion)
        {
            try
            {
                _context.Entry(objValoracion).State = EntityState.Added;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la valoración", ex);
            }
        }

        /**
        * Lista las valoraciones por el ID de la clinica.
        * @param clinicaId ID de la clinica.
        * @return Lista de valoraciones correspondientes a la clinica proporcionada.
        */
        public List<Valoracion> ListarPorClinicaId(int clinicaId)
        {
            try
            {
                return _context.Valoracions.Include(valoraciones => valoraciones.Usuario).Where(v => v.EstablecimientoId == clinicaId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las valoraciones", ex);
            }
        }
    }
}
