using EsTacna.Controllers;
using EsTacna.Models;
using EsTacna.Repositories;
using EsTacna.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using System;
using System.Diagnostics.CodeAnalysis;

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

    public class UsuarioTest
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

            EstablecimientoSaludViewModel objEstablecimientoVm = new EstablecimientoSaludViewModel();
            EstablecimientoResponse objEstablecimientoResponse = new EstablecimientoResponse();
            objEstablecimientoVm.RecoEstablecimiento = objEstablecimientoResponse.GetEstablecimiento(usuarioid).Result;

            // Assert
            Assert.Equal(2, usuarioid);
            Assert.True(objEstablecimientoVm.RecoEstablecimiento.Count > 0);
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

            var controller = new LoginController()
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
        public void ModificarPerfilTest()
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
}
