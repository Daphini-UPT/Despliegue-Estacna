using AdminEsTacna.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminEsTacna.Repositories
{
    public interface ValorarRepository
    {
        void BorrarPorUsuarioId(int usuarioId);
    }
    public class ValorarRepositoryImpl : ValorarRepository
    {
        private readonly EsTacnaContext _dbContext;

        public ValorarRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BorrarPorUsuarioId(int usuarioId)
        {
            try
            {
                var enlaces = _dbContext.Valoracions
                    .Where(e => e.UsuarioId == usuarioId).ToList();

                _dbContext.Valoracions.RemoveRange(enlaces);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al borrar los enlaces de las Valoraciones.", ex);
            }
        }
    }
    public interface IUnitOfWorkVal : IDisposable
    {
        ValorarRepository ValorarRepository { get; }
        void SaveChanges();
    }

    public class UnitOfWorkVal : IUnitOfWorkVal
    {

        private readonly EsTacnaContext _dbContext;

        private ValorarRepository _valorarrepository;

        public UnitOfWorkVal(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValorarRepository ValorarRepository
        {
            get
            {
                if (_valorarrepository == null)
                {
                    _valorarrepository = new ValorarRepositoryImpl(_dbContext);
                }
                return _valorarrepository;
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
