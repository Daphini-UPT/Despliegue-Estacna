using EsTacna.Controllers;
using EsTacna.Models;
using EsTacna.Repositories;
using EsTacna.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EsTacnaTest
{
    public class EstablecimientoSaludTest
    {
        private readonly EstablecimientoSaludRepositoryImpl objEstablecimientoSaludrepo = new EstablecimientoSaludRepositoryImpl(new EsTacnaContext());
        private readonly EpsEstablecimientoSaludRepositoryImpl objEpsEstablecimientoSaludrepo = new EpsEstablecimientoSaludRepositoryImpl(new EsTacnaContext());
        private readonly ValoracionRepositoryImpl objValoracionrepo = new ValoracionRepositoryImpl(new EsTacnaContext());

        /*Prueba Unitaria
         CP-04 Buscar Establecimientos de Salud CP01*/

        [Fact]
        public void BuscarTest()
        {
            // Arrange
            var criterio = "hospitalizacion";
            var epsid = 1; // Id de la EPS La Positiva

            // Act
            var resultado = objEstablecimientoSaludrepo.Buscar(criterio, epsid);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count);
            Assert.Contains(resultado, e => e.Id == 1);
            Assert.Contains(resultado, e => e.Id == 5);
        }

        /*Prueba Unitaria - Exito
         CP-22 Visualizar Establecimientos de Salud CP01*/

        [Fact]
        public void ListarTest()
        {
            var resultado = objEstablecimientoSaludrepo.ListarClinicas();
            Assert.True(resultado.Count > 0);
        }


        /*Prueba Unitaria - Exito
         CP-25 Visualizar Detalle del Establecimiento de Salud CP01*/

        [Fact]
        public void VisualizarDetalle()
        {
            EstablecimientoSaludViewModel objEstablecimientoVm = new EstablecimientoSaludViewModel();
            // Arrange
            var establecimientoId = objEstablecimientoSaludrepo.BuscarId(1);
            var epsid = objEpsEstablecimientoSaludrepo.BuscarIdEps(1);
            objEstablecimientoVm.listValoracion = objValoracionrepo.ListarPorEstablecimientoId(1);
            objEstablecimientoVm.TotalValoraciones = (objEstablecimientoVm.listValoracion.Count() == 0) ? 0 : Convert.ToInt32(objEstablecimientoVm.listValoracion.Sum(x => x.Calificacion) / objEstablecimientoVm.listValoracion.Count());
            var totalValoracion = objEstablecimientoVm.TotalValoraciones;

            // Assert
            Assert.Equal(1, establecimientoId.Id);
            Assert.Equal(1, epsid.Id);
            Assert.True(objEstablecimientoVm.listValoracion.Count>0);
            Assert.Equal(4, totalValoracion);
        }
    }
}
