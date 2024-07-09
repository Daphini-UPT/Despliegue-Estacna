using AdminEsTacna.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminEsTacna.Repositories
{
    public interface UsuarioRepository
    {
        void Registrar(Usuario objUsuario);
        Usuario IniciarSesion(string usuarioCuenta, string contrasenaCuenta);
        Usuario BuscarId(int usuarioId);
        List<Usuario> ListarUsuarios();
        void Borrar(int usuarioId);
    }

    public class UsuarioRepositoryImpl : UsuarioRepository
    {
        private readonly EsTacnaContext _dbContext;

        public UsuarioRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Registrar(Usuario objUsuario)
        {
            try
            {
                if (objUsuario.Id > 0)
                {
                    _dbContext.Entry(objUsuario).State = EntityState.Modified;
                }
                else
                {
                    _dbContext.Entry(objUsuario).State = EntityState.Added;
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al registrar el usuario.", ex);
            }
        }

        public Usuario IniciarSesion(string usuarioCuenta, string contrasenaCuenta)
        {
            Usuario objUsuario = new Usuario();
            try
            {
                var usuarioDatos = from datos in _dbContext.Usuarios select datos;
                objUsuario = usuarioDatos.Where(u => u.Email == usuarioCuenta && u.Contrasena == contrasenaCuenta).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("El usuario y/o la contraseña son incorrectos", ex);
            }
            return objUsuario;
        }

        public Usuario BuscarId(int usuarioId)
        {
            Usuario objUsuario = new Usuario();
            try
            {
                var usuarioDatos = from datos in _dbContext.Usuarios select datos;
                objUsuario = usuarioDatos.Where(e => e.Id == usuarioId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> listUsuario = new List<Usuario>();
            try
            {
                var usuarioDatos = from datos in _dbContext.Usuarios
                                   select datos;
                listUsuario = usuarioDatos.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listUsuario;
        }
        
        public void Borrar(int usuarioId)
        {
            try
            {
                var usuario = _dbContext.Usuarios.Find(usuarioId);
                if (usuario != null)
                {
                    _dbContext.Usuarios.Remove(usuario);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al borrar el usuario.", ex);
            }
        }
    }

    public interface IUnitOfWork : IDisposable
    {
        UsuarioRepository UsuarioRepositoryimpl { get; }

        void SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EsTacnaContext _dbContext;

        private UsuarioRepository _usuarioRepository;

        public UnitOfWork(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UsuarioRepository UsuarioRepositoryimpl
        {
            get
            {
                if (_usuarioRepository == null)
                {
                    _usuarioRepository = new UsuarioRepositoryImpl(_dbContext);
                }
                return _usuarioRepository;
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
