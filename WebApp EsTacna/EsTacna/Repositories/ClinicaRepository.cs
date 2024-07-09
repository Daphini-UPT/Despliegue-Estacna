using EsTacna.Models;
using Microsoft.EntityFrameworkCore;

/**
* Interface para el repositorio de Clinicas.
*/

namespace EsTacna.Repositories
{
    public interface ClinicaRepository
    {
        /**
        * Busca Clinicas según un criterio y un ID de EPS.
        * @param criterio Criterio de búsqueda.
        * @param epsId ID del EPS.
        * @return Lista de Clinicas que cumplen con el criterio y el ID de EPS.
        */
        List<EstablecimientoSalud> Buscar(string criterio, int epsId);

        /**
        * Busca una clinica por su ID.
        * @param clinicaId ID de la clinica.
        * @return Objeto EstablecimientoSalud correspondiente al ID.
        */
        EstablecimientoSalud BuscarId(int clinicaId);

        /**
        * Lista los Clinicas asociados a un EPS específico.
        * @param epsId ID del EPS.
        * @return Lista de Clinicas asociados al EPS.
        */
        List<EstablecimientoSalud> Listar(int epsId);

        /**
        * Lista todos los Clinicas.
        * @return Lista de todos los Clinicas.
        */
        List<EstablecimientoSalud> ListarMap();
    }

    /**
    * Implementación del repositorio de Clinicas.
    */
    public class ClinicaRepositoryImpl : ClinicaRepository
    {
        /** Contexto de base de datos de EsTacna */
        private readonly EsTacnaContext _dbContext;

        /**
        * Constructor que inicializa el contexto de base de datos.
        * @param dbContext Contexto de base de datos de EsTacna.
        */
        public ClinicaRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        /**
        * Busca Clinicas según un criterio y un ID de EPS.
        * @param criterio Criterio de búsqueda.
        * @param epsId ID del EPS.
        * @return Lista de Clinicas que cumplen con el criterio y el ID de EPS.
        */
        public List<EstablecimientoSalud> Buscar(string criterio, int epsId)
        {
            List<EstablecimientoSalud> listClinica = new List<EstablecimientoSalud>();
            try
            {
                var clinicaDatos = from datos in _dbContext.EstablecimientoSaluds
                                           join epsClinica in _dbContext.EpsEstablecimientoSaluds on datos.Id equals epsClinica.EstablecimientoId
                                           where epsClinica.EpsId == epsId &&
                                                 (datos.Nombre.ToLower().Contains(criterio.ToLower()) || datos.Descripcion.ToLower().Contains(criterio.ToLower()))
                                           select datos;

                listClinica = clinicaDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listClinica;
        }

        /**
        * Busca una clinica por su ID.
        * @param clinicaId ID de la clinica.
        * @return Objeto EstablecimientoSalud correspondiente al ID.
        */
        public EstablecimientoSalud BuscarId(int clinicaId)
        {
            EstablecimientoSalud objClinica = new EstablecimientoSalud();
            try
            {
                objClinica = _dbContext.EstablecimientoSaluds
                    .Include(e => e.EpsEstablecimientoSaluds)
                    .FirstOrDefault(e => e.Id == clinicaId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return objClinica;
        }

        /**
        * Lista los Clinicas asociados a un EPS específico.
        * @param epsId ID del EPS.
        * @return Lista de Clinicas asociados al EPS.
        */
        public List<EstablecimientoSalud> Listar(int epsId)
        {
            List<EstablecimientoSalud> listClinica = new List<EstablecimientoSalud>();
            try
            {
                var clinicaDatos = from datos in _dbContext.EstablecimientoSaluds
                                           join epsClinica in _dbContext.EpsEstablecimientoSaluds on datos.Id equals epsClinica.EstablecimientoId
                                           where epsClinica.EpsId == epsId
                                           select datos;

                listClinica = clinicaDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listClinica;
        }

        /**
        * Lista todos los Clinicas.
        * @return Lista de todos los Clinicas.
        */
        public List<EstablecimientoSalud> ListarClinicas()
        {
            List<EstablecimientoSalud> listClinicas = new List<EstablecimientoSalud>();
            try
            {
                var clinicaDatos = from datos in _dbContext.EstablecimientoSaluds
                                           select datos;
                listClinicas = clinicaDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listClinicas;
        }

        /**
        * Lista todos los Clinicas.
        * @return Lista de todos los Clinicas.
        */
        public List<EstablecimientoSalud> ListarMap()
        {
            List<EstablecimientoSalud> listClinicas = new List<EstablecimientoSalud>();
            try
            {
                var clinicaDatos = from datos in _dbContext.EstablecimientoSaluds select datos;
                listClinicas = clinicaDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listClinicas;
        }
    }

    /**
    * Interface para el patrón UnitOfWork en el contexto de Clinicas.
    */
    public interface IUnitOfWorkEst : IDisposable
    {
        /**
        * Repositorio de Clinicas.
        * @return Instancia del repositorio de Clinicas.
        */
        ClinicaRepository ClinicaRepository { get; }
        void SaveChanges();
    }

    /**
    * Implementación del patrón UnitOfWork en el contexto de Clinicas.
    */
    public class UnitOfWorkCli : IUnitOfWorkEst
    {
        /** Contexto de base de datos de EsTacna */
        private readonly EsTacnaContext _dbContext;

        /** Repositorio de Clinicas */
        private ClinicaRepository _clinicarepository;

        /**
        * Constructor que inicializa el contexto de base de datos.
        * @param dbContext Contexto de base de datos de EsTacna.
        */
        public UnitOfWorkCli(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        /**
        * Repositorio de Clinicas.
        * @return Instancia del repositorio de Clinicas.
        */
        public ClinicaRepository ClinicaRepository
        {
            get
            {
                if (_clinicarepository == null)
                {
                    _clinicarepository = new ClinicaRepositoryImpl(_dbContext);
                }
                return _clinicarepository;
            }
        }

        /**
        * Guarda los cambios en el contexto de base de datos.
        */
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        /**
        * Libera los recursos utilizados por el contexto de base de datos.
        */
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
