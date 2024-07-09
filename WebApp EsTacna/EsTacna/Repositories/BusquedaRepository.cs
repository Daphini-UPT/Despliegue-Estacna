using EsTacna.Models;
using Microsoft.EntityFrameworkCore;

/**
* Interface para el repositorio de búsquedas.
*/

namespace EsTacna.Repositories
{
    public interface BusquedaRepository
    {
        /**
        * Registra una nueva búsqueda en el sistema.
        * @param objBusqueda Objeto de búsqueda a registrar.
        */
        void Registrar(Busquedum objBusqueda);

        /**
        * Lista todas las búsquedas registradas.
        * @return Lista de objetos de búsqueda.
        */
        List<Busquedum> ListarBusqueda();
    }

    /**
    * Implementación del repositorio de búsquedas.
    */
    public class BusquedaRepositoryImpl : BusquedaRepository
    {
        /** Contexto de base de datos de EsTacna */
        private readonly EsTacnaContext _dbContext;

        /**
        * Constructor que inicializa el contexto de base de datos.
        * @param dbContext Contexto de base de datos de EsTacna.
        */
        public BusquedaRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        /**
        * Registra una nueva búsqueda en la base de datos.
        * @param objBusqueda Objeto de búsqueda a registrar.
        */
        public void Registrar(Busquedum objBusqueda)
        {
            try
            {
                /** Establece el estado de la entrada de búsqueda como agregado */
                _dbContext.Entry(objBusqueda).State = EntityState.Added;

                /** Guarda los cambios en la base de datos */
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /**
        * Lista todas las búsquedas registradas en la base de datos.
        * @return Lista de objetos de búsqueda.
        */
        public List<Busquedum> ListarBusqueda()
        {
            List<Busquedum> listBusqueda = new List<Busquedum>();
            try
            {
                /** Consulta todas las entradas de búsqueda de la base de datos */
                var busquedaDatos = from datos in _dbContext.Busqueda select datos;

                /** Convierte los resultados de la consulta a una lista */
                listBusqueda = busquedaDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listBusqueda;
        }
    }
}
