using AdminEsTacna.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminEsTacna.Repositories
{
    public interface EstablecimientoSaludRepository
    {
        void Registrar(EstablecimientoSalud objClinica);
        List<EstablecimientoSalud> Buscar(string criterio, int epsId);
        EstablecimientoSalud BuscarId(int establecimientoId);
        List<EstablecimientoSalud> Listar(int epsId);
        List<EstablecimientoSalud> ListarMap();
        void Borrar(int establecimientoId);


    }

    public class EstablecimientoSaludRepositoryImpl : EstablecimientoSaludRepository
    {
        private readonly EsTacnaContext _dbContext;

        public EstablecimientoSaludRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Registrar(EstablecimientoSalud objClinica)
        {
            try
            {
                if (objClinica.Id > 0)
                {
                    _dbContext.Entry(objClinica).State = EntityState.Modified;
                }
                else
                {
                    _dbContext.Entry(objClinica).State = EntityState.Added;
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al registrar la clinica.", ex);
            }
        }

        public List<EstablecimientoSalud> Buscar(string criterio, int epsId)
        {
            List<EstablecimientoSalud> listEstablecimiento = new List<EstablecimientoSalud>();
            try
            {
                var establecimientoDatos = from datos in _dbContext.EstablecimientoSaluds
                                           join epsEstablecimiento in _dbContext.EpsEstablecimientoSaluds on datos.Id equals epsEstablecimiento.EstablecimientoId
                                           where epsEstablecimiento.EpsId == epsId &&
                                                 (datos.Nombre.ToLower().Contains(criterio.ToLower()) || datos.Descripcion.ToLower().Contains(criterio.ToLower()))
                                           select datos;

                listEstablecimiento = establecimientoDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listEstablecimiento;
        }

        public EstablecimientoSalud BuscarId(int establecimientoId)
        {
            EstablecimientoSalud objEstablecimiento = new EstablecimientoSalud();
            try
            {
                objEstablecimiento = _dbContext.EstablecimientoSaluds
                    .Include(e => e.EpsEstablecimientoSaluds)
                    .FirstOrDefault(e => e.Id == establecimientoId);
            }
            catch (Exception ex)
            {
                throw;
            }

            return objEstablecimiento;
        }

        public List<EstablecimientoSalud> Listar(int epsId)
        {
            List<EstablecimientoSalud> listEstablecimiento = new List<EstablecimientoSalud>();
            try
            {
                var establecimientoDatos = from datos in _dbContext.EstablecimientoSaluds
                                           join epsEstablecimiento in _dbContext.EpsEstablecimientoSaluds on datos.Id equals epsEstablecimiento.EstablecimientoId
                                           where epsEstablecimiento.EpsId == epsId
                                           select datos;

                listEstablecimiento = establecimientoDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listEstablecimiento;
        }

        public List<EstablecimientoSalud> ListarClinicas()
        {
            List<EstablecimientoSalud> listEstablecimiento = new List<EstablecimientoSalud>();
            try
            {
                var establecimientoDatos = from datos in _dbContext.EstablecimientoSaluds
                                           select datos;
                listEstablecimiento = establecimientoDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listEstablecimiento;
        }

        public List<EstablecimientoSalud> ListarMap()
        {
            List<EstablecimientoSalud> listEstablecimiento = new List<EstablecimientoSalud>();
            try
            {
                var establecimientoDatos = from datos in _dbContext.EstablecimientoSaluds select datos;
                listEstablecimiento = establecimientoDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listEstablecimiento;
        }

        public void Borrar(int establecimientoId)
        {
            try
            {
                var clinica = _dbContext.EstablecimientoSaluds.Find(establecimientoId);
                if (clinica != null)
                {
                    _dbContext.EstablecimientoSaluds.Remove(clinica);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al borrar la clínica.", ex);
            }
        }
    }

    public interface IUnitOfWorkEst : IDisposable
    {
        EstablecimientoSaludRepository EstablecimientoSaludRepository { get; }
        void SaveChanges();
    }

    public class UnitOfWorkEst : IUnitOfWorkEst
    {
        private readonly EsTacnaContext _dbContext;

        private EstablecimientoSaludRepository _establecimientosaludrepository;

        public UnitOfWorkEst(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EstablecimientoSaludRepository EstablecimientoSaludRepository
        {
            get
            {
                if (_establecimientosaludrepository == null)
                {
                    _establecimientosaludrepository = new EstablecimientoSaludRepositoryImpl(_dbContext);
                }
                return _establecimientosaludrepository;
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
