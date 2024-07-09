using AdminEsTacna.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminEsTacna.Repositories
{
    public interface EpsRepository
    {
        void Registrar(Ep objEps);
        Ep BuscarId(int epsId);
        List<Ep> ListarEps();
        void Borrar(int epsId);
    }

    public class EpsRepositoryImpl : EpsRepository
    {
        private readonly EsTacnaContext _dbContext;

        public EpsRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Registrar(Ep objEps)
        {
            try
            {
                if (objEps.Id > 0)
                {
                    _dbContext.Entry(objEps).State = EntityState.Modified;
                }
                else
                {
                    _dbContext.Entry(objEps).State = EntityState.Added;
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al registrar la EPS.", ex);
            }
        }

        public Ep BuscarId(int epsId)
        {
            Ep objEps = new Ep();
            try
            {
                var epsDatos = from datos in _dbContext.Eps select datos;

                objEps = epsDatos.Where(e => e.Id == epsId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEps;
        }

        public List<Ep> ListarEps()
        {
            List<Ep> listEps = new List<Ep>();
            try
            {
                var epsDatos = from datos in _dbContext.Eps select datos;

                listEps = epsDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listEps;
        }

        public void Borrar(int epsId)
        {
            try
            {
                var eps = _dbContext.Eps.Find(epsId);
                if (eps != null)
                {
                    _dbContext.Eps.Remove(eps);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al borrar la EPS.", ex);
            }
        }
    }

    public interface IUnitOfWorkEps : IDisposable
    {
        EpsRepository EpsRepository { get; }
        void SaveChanges();
    }

    public class UnitOfWorkEps : IUnitOfWorkEps
    {
        private readonly EsTacnaContext _dbContext;

        private EpsRepository _epsrepository;

        public UnitOfWorkEps(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EpsRepository EpsRepository
        {
            get
            {
                if (_epsrepository == null)
                {
                    _epsrepository = new EpsRepositoryImpl(_dbContext);
                }
                return _epsrepository;
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
