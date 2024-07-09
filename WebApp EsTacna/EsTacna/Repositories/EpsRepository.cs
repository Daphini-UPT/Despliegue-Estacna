using EsTacna.Models;

/**
* Interface para el repositorio de EPS.
*/

namespace EsTacna.Repositories
{
    public interface EpsRepository
    {
        /**
        * Busca un EPS por su ID.
        * @param epsId ID del EPS.
        * @return Objeto Ep correspondiente al ID del EPS.
        */
        Ep BuscarId(int epsId);

        /**
        * Lista todos los EPS.
        * @return Lista de objetos Ep.
        */
        List<Ep> Listar();
    }

    /**
    * Implementación del repositorio de EPS.
    */
    public class EpsRepositoryImpl : EpsRepository
    {
        /** Contexto de base de datos de EsTacna */
        private readonly EsTacnaContext _dbContext;

        /**
        * Constructor que inicializa el contexto de base de datos.
        * @param dbContext Contexto de base de datos de EsTacna.
        */
        public EpsRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        /**
        * Busca un EPS por su ID.
        * @param epsId ID del EPS.
        * @return Objeto Ep correspondiente al ID del EPS.
        */
        public Ep BuscarId(int epsId)
        {
            Ep objEps = new Ep();
            try
            {
                /** Consulta los datos de Ep en la base de datos */
                var epsDatos = from datos in _dbContext.Eps select datos;

                /** Filtra por el ID del EPS y obtiene el primer resultado */
                objEps = epsDatos.Where(e => e.Id == epsId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEps;
        }

        /**
        * Lista todos los EPS.
        * @return Lista de objetos Ep.
        */
        public List<Ep> Listar()
        {
            List<Ep> listEps = new List<Ep>();
            try
            {
                /** Consulta todos los datos de Ep en la base de datos */
                var epsDatos = from datos in _dbContext.Eps select datos;

                /** Convierte la consulta en una lista */
                listEps = epsDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listEps;
        }
    }
}
