using EsTacna.Controllers;
using EsTacna.Models;
using EsTacna.Repositories;
using EsTacna.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EsTacnaTest
{
    // Mock implementation of ISession
    public class MockHttpSession : ISession
    {
        // Implementación de todos los métodos requeridos por la interfaz ISession

        private readonly Dictionary<string, object> _sessionStorage = new Dictionary<string, object>();

        public bool IsAvailable => true;

        public string Id => Guid.NewGuid().ToString();

        public IEnumerable<string> Keys => _sessionStorage.Keys;

        public void SetString(string key, string value)
        {
            _sessionStorage[key] = value;
        }

        public string GetString(string key)
        {
            return _sessionStorage.TryGetValue(key, out var value) ? value as string : null;
        }

        public void Set(string key, byte[] value)
        {
            _sessionStorage[key] = value;
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            if (_sessionStorage.TryGetValue(key, out var objectValue))
            {
                value = objectValue as byte[];
                return value != null;
            }

            value = null;
            return false;
        }

        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public void Remove(string key)
        {
            _sessionStorage.Remove(key);
        }

        public void Clear()
        {
            _sessionStorage.Clear();
        }
    }

    //PRUEBAS UNITARIAS
    public class UsuarioUnitTest
    {
        private readonly UsuarioRepositoryImpl objUsuarioRepo = new UsuarioRepositoryImpl(new EsTacnaContext());

        /*Prueba Unitaria
         CP-01 Visualizar Establecimientos de Salud Recomendados CP01*/

        [Fact]
        public void EstablecimientosRecomendados()
        {
            // Arrange
            var expectedusuario = new Usuario
            {
                Email = "alevaldiviag@upt.pe",
                Contrasena = "123456"
            };
            var resultado = objUsuarioRepo.Login(expectedusuario.Email, expectedusuario.Contrasena);

            var usuario = objUsuarioRepo.BuscarId(2);
            int usuarioid = usuario.Id;

            ClinicaViewModel objEstablecimientoVm = new ClinicaViewModel();
            ClinicaResponse objEstablecimientoResponse = new ClinicaResponse();
            objEstablecimientoVm.recoClinica = objEstablecimientoResponse.GetClinica(usuarioid).Result;

            // Assert
            Assert.Equal(2, usuarioid);
            Assert.True(objEstablecimientoVm.recoClinica.Count > 0);
        }

        /*Prueba Unitaria
         CP-07 Registrar Usuario CP01*/

        [Fact]
        public void RegistrarTest()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nombre = "Test",
                Apellido = "Test",
                Email = "Test@test.pe",
                Contrasena = "Test",
            };

            // Act
            objUsuarioRepo.Registrar(usuario);

            // Assert
            Assert.NotEqual(0, usuario.Id);
        }

        /*Prueba Unitaria
         CP-10 Iniciar Sesion CP01*/

        [Fact]
        public void IniciarSesionTest()
        {
            // Arrange
            var expectedusuario = new Usuario
            {
                Email = "Test@test.pe",
                Contrasena = "Test"
            };

            // Act
            var resultado = objUsuarioRepo.Login(expectedusuario.Email, expectedusuario.Contrasena);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(expectedusuario.Email, resultado.Email);
            Assert.Equal(expectedusuario.Contrasena, resultado.Contrasena);
        }

        /*Prueba Unitaria
         CP-19 Cerrar Sesion CP01*/

        [Fact]
        public void CerrarSesionTest()
        {
            // Arrange
            var logUsuario = new DefaultHttpContext();
            logUsuario.Session = new MockHttpSession();
            logUsuario.Session.SetString("UsuarioNombre", "NombreUsuario");
            logUsuario.Session.SetString("UsuarioId", "1");

            var controller = new IniciarSesionController()
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = logUsuario
                }
            };

            // Act
            controller.Logout();

            // Assert
            Assert.Empty(logUsuario.Session.Keys);
        }

        /*Prueba Unitaria
         CP-13 Visualizar Perfil CP01*/

        [Fact]
        public void PerfilTest()
        {
            var usId = 2;
            // Arrange
            var expectedusuario = new Usuario
            {
                Nombre = "ALEJANDRA MARIA",
                Apellido = "VALDIVIA GUZMAN",
                Email = "alevaldiviag@upt.pe"
            };
            // Act
            var resultado = objUsuarioRepo.BuscarId(usId);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(expectedusuario.Nombre, resultado.Nombre);
            Assert.Equal(expectedusuario.Apellido, resultado.Apellido);
            Assert.Equal(expectedusuario.Email, resultado.Email);
        }

        /*Prueba Unitaria
         CP-16 Editar Perfil CP01*/

        [Fact]
        public void EditarPerfilTest()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = 3,
                Nombre = "JUANA MARIA",
                Apellido = "PEREZ MAMANI",
                Email = "modificar@perfil.pe",
                Contrasena = "modificarperfil123",
            };

            // Act
            objUsuarioRepo.Registrar(usuario);

            // Assert
            Assert.NotEqual(0, usuario.Id);
        }
    }

    //PRUEBAS DE INTEGRACIÓN
    public class UsuarioIntegrationTest
    {
        private readonly UsuarioRepositoryImpl objUsuarioRepo = new UsuarioRepositoryImpl(new EsTacnaContext());

        /*Prueba de Integración
         * CP-09 Registrar Usuario CP03
         * CP-12 Iniciar Sesion CP03
         * CP-15 Visualizar Perfil CP03
         * CP-18 Editar Perfil CP03
         * CP-21 Cerrar sesion CP03*/
        [Fact]
        public void TestIntegracionUsuarioNuevo()
        {
            
            // Arrange
            var usuario = new Usuario
            {
                Nombre = "NUEVO",
                Apellido = "USUARIO",
                Email = "nuevo@usuario.pe",
                Contrasena = "12345678",
            };

            var usuarioEditar = new Usuario
            {
                Nombre = "NUEVO",
                Apellido = "USUARIO",
                Email = "nuevo@usuario.pe",
                Contrasena = "12345678",
            };

            var logUsuario = new DefaultHttpContext();
            logUsuario.Session = new MockHttpSession();
            logUsuario.Session.SetString("NUEVO", "USUARIO");
            logUsuario.Session.SetString("UsuarioId", "1");
            var controller = new IniciarSesionController()
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = logUsuario
                }
            };

            // Act
            objUsuarioRepo.Registrar(usuario);
            var resultado = objUsuarioRepo.Login(usuario.Email, usuario.Contrasena); objUsuarioRepo.BuscarId(usuario.Id); objUsuarioRepo.Registrar(usuarioEditar); controller.Logout();


            // Assert
            Assert.Equal(usuario.Nombre, resultado.Nombre);
            Assert.Equal(usuario.Apellido, resultado.Apellido);
            Assert.Equal(usuario.Email, resultado.Email);
            Assert.Equal(usuarioEditar.Contrasena, resultado.Contrasena);
            Assert.Empty(logUsuario.Session.Keys);
        }

        /*Prueba de Integración
         * CP-12 Iniciar sesión CP03
         * CP-03 Visualizar Clínicas Recomendadas CP03
         * CP-21 Cerrar sesión CP03*/
        [Fact]
        public void TestIntegracionUsuario()
        {
            // Arrange
            var expectedusuario = new Usuario
            {
                Email = "alevaldiviag@upt.pe",
                Contrasena = "123456"
            };

            var logUsuario = new DefaultHttpContext();
            logUsuario.Session = new MockHttpSession();
            logUsuario.Session.SetString("ALEJANDRA MARIA", "VALDIVIA GUZMAN");
            logUsuario.Session.SetString("UsuarioId", "2");
            var controller = new IniciarSesionController()
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = logUsuario
                }
            };

            var resultado = objUsuarioRepo.Login(expectedusuario.Email, expectedusuario.Contrasena);

            var usuario = objUsuarioRepo.BuscarId(2);
            int usuarioid = usuario.Id;

            ClinicaViewModel objEstablecimientoVm = new ClinicaViewModel();
            ClinicaResponse objEstablecimientoResponse = new ClinicaResponse();
            objEstablecimientoVm.recoClinica = objEstablecimientoResponse.GetClinica(usuarioid).Result;
            controller.Logout();

            // Assert
            Assert.Equal(2, usuarioid);
            Assert.True(objEstablecimientoVm.recoClinica.Count > 0);
            Assert.Empty(logUsuario.Session.Keys);
        }
    }
}
