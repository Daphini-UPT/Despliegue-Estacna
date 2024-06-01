using EsTacna.Controllers;
using EsTacna.Models;
using EsTacna.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsTacnaTest
{
    public class ValoracionTest
    {
        private readonly ValoracionRepositoryImpl objValoracionRepo = new ValoracionRepositoryImpl(new EsTacnaContext());

        /*Prueba Unitaria
         CP-28 Calificar Establecimiento de Salud CP01*/

        [Fact]
        public void CalificarEstablecimiento()
        {
            // Arrange
            var valoracion = new Valoracion
            {
                EstablecimientoId = 5,
                UsuarioId = 4,
                Comentario = "Este es un comentario de prueba",
                Calificacion = 5
            };

            // Act
            objValoracionRepo.Guardar(valoracion);
            // Assert
            Assert.NotEqual(0, valoracion.Id);
        }
    }
}
