using EsTacna.Models;
using Microsoft.EntityFrameworkCore;

/**
* Interface para el repositorio de usuarios.
*/

namespace EsTacna.Repositories
{
    public interface UsuarioRepository
    {
        /**
        * Registra un nuevo usuario o actualiza uno existente.
        * @param objUsuario Objeto Usuario a registrar o actualizar.
        */
        void Registrar(Usuario objUsuario);

        /**
        * Realiza el login de un usuario con su cuenta y contraseña.
        * @param usuarioCuenta Correo electrónico del usuario.
        * @param contrasenaCuenta Contraseña del usuario.
        * @return Objeto Usuario correspondiente a la cuenta y contraseña proporcionadas.
        */
        Usuario Login(string usuarioCuenta, string contrasenaCuenta);

        /**
        * Busca un usuario por su ID.
        * @param usuarioId ID del usuario.
        * @return Objeto Usuario correspondiente al ID proporcionado.
        */
        Usuario BuscarId(int usuarioId);
    }

    /**
    * Implementación del repositorio de usuarios.
    */
    public class UsuarioRepositoryImpl : UsuarioRepository
    {
        /** Contexto de base de datos de EsTacna */
        private readonly EsTacnaContext _dbContext;

        /**
        * Constructor que inicializa el contexto de base de datos.
        * @param dbContext Contexto de base de datos de EsTacna.
        */
        public UsuarioRepositoryImpl(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        /**
        * Registra un nuevo usuario o actualiza uno existente.
        * @param objUsuario Objeto Usuario a registrar o actualizar.
        */
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

        /**
        * Realiza el login de un usuario con su cuenta y contraseña.
        * @param usuarioCuenta Correo electrónico del usuario.
        * @param contrasenaCuenta Contraseña del usuario.
        * @return Objeto Usuario correspondiente a la cuenta y contraseña proporcionadas.
        */
        public Usuario Login(string usuarioCuenta, string contrasenaCuenta)
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

        /**
        * Busca un usuario por su ID.
        * @param usuarioId ID del usuario.
        * @return Objeto Usuario correspondiente al ID proporcionado.
        */
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
    }

    /**
    * Interface para el patrón UnitOfWork.
    */
    public interface IUnitOfWork : IDisposable
    {
        /**
        * Repositorio de usuarios.
        * @return Instancia del repositorio de usuarios.
        */
        UsuarioRepository UsuarioRepositoryimpl { get; }

        /**
        * Guarda los cambios en el contexto de base de datos.
        */
        void SaveChanges();
    }

    /**
    * Implementación del patrón UnitOfWork.
    */
    public class UnitOfWork : IUnitOfWork
    {
        /** Contexto de base de datos de EsTacna */
        private readonly EsTacnaContext _dbContext;

        /** Repositorio de usuarios */
        private UsuarioRepository _usuarioRepository;

        /**
        * Constructor que inicializa el contexto de base de datos.
        * @param dbContext Contexto de base de datos de EsTacna.
        */
        public UnitOfWork(EsTacnaContext dbContext)
        {
            _dbContext = dbContext;
        }

        /**
        * Repositorio de usuarios.
        * @return Instancia del repositorio de usuarios.
        */
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
