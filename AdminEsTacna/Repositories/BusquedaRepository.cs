using AdminEsTacna.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminEsTacna.Repositories
{
    public interface BusquedaRepository
    {
        void BorrarPorUsuarioId(int usuarioId);
    }
    public class BusquedaRepositoryImpl : BusquedaRepository
    {
        private readonly EsTacnaContext _dbContext;

        public BusquedaRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BorrarPorUsuarioId(int usuarioId)
        {
            try
            {
                var busquedas = _dbContext.Busqueda
                    .Where(e => e.UsuarioId == usuarioId).ToList();

                _dbContext.Busqueda.RemoveRange(busquedas);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al borrar los enlaces de las Busquedas.", ex);
            }
        }
    }
    public interface IUnitOfWorkBus : IDisposable
    {
        BusquedaRepository BusquedaRepository { get; }
        void SaveChanges();
    }

    public class UnitOfWorkBus : IUnitOfWorkBus
    {

        private readonly EsTacnaContext _dbContext;

        private BusquedaRepository _busquedarepository;

        public UnitOfWorkBus(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BusquedaRepository BusquedaRepository
        {
            get
            {
                if (_busquedarepository == null)
                {
                    _busquedarepository = new BusquedaRepositoryImpl(_dbContext);
                }
                return _busquedarepository;
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
