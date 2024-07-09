using EsTacna.Models;
using Microsoft.EntityFrameworkCore;

/**
* Interface para el repositorio de EPS y Establecimientos de Salud.
*/

namespace EsTacna.Repositories
{
    public interface EpsClinicaRepository
    {
        /**
        * Busca una EPS por el ID de la clinica.
        * @param clinicaId ID de la clinica.
        * @return Objeto EpsEstablecimientoSalud correspondiente al ID de la clinica.
        */
        EpsEstablecimientoSalud BuscarId(int clinicaId);

        /**
        * Busca la EPS asociada a una clinica por el ID de la clinica.
        * @param clinicaId ID de la clinica.
        * @return Objeto Ep correspondiente al ID de la clinica.
        */
        Ep BuscarIdEps(int clinicaId);
    }

    /**
    * Implementación del repositorio de EPS y Clinicas.
    */
    public class EpsClinicaRepositoryImpl : EpsClinicaRepository
    {
        /** Contexto de base de datos de EsTacna */
        private readonly EsTacnaContext _dbContext;

        /**
        * Constructor que inicializa el contexto de base de datos.
        * @param dbContext Contexto de base de datos de EsTacna.
        */
        public EpsClinicaRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        /**
        * Busca una EPS por el ID de la clinica.
        * @param clinicaId ID de la clinica.
        * @return Objeto EpsEstablecimientoSalud correspondiente al ID de la clinica.
        */
        public EpsEstablecimientoSalud BuscarId(int clinicaId)
        {
            EpsEstablecimientoSalud objEpsClinica = new EpsEstablecimientoSalud();
            try
            {
                /** Consulta los datos de EpsEstablecimientoSalud en la base de datos */
                var clinicaDatos = from datos in _dbContext.EpsEstablecimientoSaluds select datos;

                /** Filtra por el ID de la clinica y obtiene el primer resultado */
                objEpsClinica = clinicaDatos.Where(e => e.EstablecimientoId == clinicaId).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
            return objEpsClinica;
        }

        /**
        * Busca el EPS asociado a una clinica por el ID de la clinica.
        * @param clinicaId ID de la clinica.
        * @return Objeto Ep correspondiente al ID de la clinica.
        */
        public Ep BuscarIdEps(int clinicaId)
        {
            Ep objEps = new Ep();
            try
            {
                /** Incluye la relación Eps en la consulta y filtra por el ID de la clinica */
                objEps = _dbContext.EpsEstablecimientoSaluds
                        .Include(e => e.Eps)
                        .FirstOrDefault(e => e.EstablecimientoId == clinicaId)?.Eps;
            }
            catch (Exception ex)
            {

                throw;
            }
            return objEps;
        }
    }
}
