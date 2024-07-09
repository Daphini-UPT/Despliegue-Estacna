using AdminEsTacna.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminEsTacna.Repositories
{
    public interface EpsEstablecimientoSaludRepository
    {

        void Registrar(EpsEstablecimientoSalud objEpsClinica);

        EpsEstablecimientoSalud BuscarId(int establecimientoId);

        Ep BuscarIdEps(int establecimientoId);

        List<EpsEstablecimientoSalud> Listar();
        void BorrarPorClinicaId(int establecimientoId);
        void BorrarPorEpsId(int epsId);
    }


    public class EpsEstablecimientoSaludRepositoryImpl : EpsEstablecimientoSaludRepository
    {

        private readonly EsTacnaContext _dbContext;

        public EpsEstablecimientoSaludRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Registrar(EpsEstablecimientoSalud objEpsClinica)
        {
            try
            {
                if (objEpsClinica.Id > 0)
                {
                    _dbContext.Entry(objEpsClinica).State = EntityState.Modified;
                }
                else
                {
                    _dbContext.Entry(objEpsClinica).State = EntityState.Added;
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al agregar la clinica a la eps.", ex);
            }
        }

        public EpsEstablecimientoSalud BuscarId(int establecimientoId)
        {
            EpsEstablecimientoSalud objEpsEstablecimiento = new EpsEstablecimientoSalud();
            try
            {

                var establecimientoDatos = from datos in _dbContext.EpsEstablecimientoSaluds select datos;

                objEpsEstablecimiento = establecimientoDatos.Where(e => e.EstablecimientoId == establecimientoId).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
            return objEpsEstablecimiento;
        }

        public Ep BuscarIdEps(int establecimientoId)
        {
            Ep objEps = new Ep();
            try
            {
                objEps = _dbContext.EpsEstablecimientoSaluds
                        .Include(e => e.Eps)
                        .FirstOrDefault(e => e.EstablecimientoId == establecimientoId)?.Eps;
            }
            catch (Exception ex)
            {

                throw;
            }
            return objEps;
        }

        public List<EpsEstablecimientoSalud> Listar()
        {
            List<EpsEstablecimientoSalud> listEpsClinica = new List<EpsEstablecimientoSalud>();
            try
            {

                var epsClinicaDatos = from datos in _dbContext.EpsEstablecimientoSaluds select datos;

                listEpsClinica = epsClinicaDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listEpsClinica;
        }

        public void BorrarPorClinicaId(int establecimientoId)
        {
            try
            {
                var enlaces = _dbContext.EpsEstablecimientoSaluds
                    .Where(e => e.EstablecimientoId == establecimientoId)
                    .ToList();

                _dbContext.EpsEstablecimientoSaluds.RemoveRange(enlaces);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al borrar los enlaces de la clínica.", ex);
            }
        }

        public void BorrarPorEpsId(int epsId)
        {
            try
            {
                var eps = _dbContext.EpsEstablecimientoSaluds
                    .Where(e => e.EpsId == epsId)
                    .ToList();

                _dbContext.EpsEstablecimientoSaluds.RemoveRange(eps);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al borrar los enlaces de la clínica.", ex);
            }
        }

    }

    public interface IUnitOfWorkEpsCli : IDisposable
    {
        EpsEstablecimientoSaludRepository EpsEstablecimientoSaludRepository { get; }
        void SaveChanges();
    }

    public class UnitOfWorkEpsCli : IUnitOfWorkEpsCli
    {

        private readonly EsTacnaContext _dbContext;

        private EpsEstablecimientoSaludRepository _epsestablecimientosaludrepository;

        public UnitOfWorkEpsCli(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EpsEstablecimientoSaludRepository EpsEstablecimientoSaludRepository
        {
            get
            {
                if (_epsestablecimientosaludrepository == null)
                {
                    _epsestablecimientosaludrepository = new EpsEstablecimientoSaludRepositoryImpl(_dbContext);
                }
                return _epsestablecimientosaludrepository;
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
