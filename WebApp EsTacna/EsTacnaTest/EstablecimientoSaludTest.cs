using EsTacna.Controllers;
using EsTacna.Models;
using EsTacna.Repositories;
using EsTacna.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EsTacnaTest
{
    // PRUEBAS UNITARIAS
    public class EstablecimientoSaludUnitTest
    {
        private readonly ClinicaRepositoryImpl objEstablecimientoSaludrepo = new ClinicaRepositoryImpl(new EsTacnaContext());
        private readonly EpsClinicaRepositoryImpl objEpsEstablecimientoSaludrepo = new EpsClinicaRepositoryImpl(new EsTacnaContext());
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
            ClinicaViewModel objEstablecimientoVm = new ClinicaViewModel();
            // Arrange
            var establecimientoId = objEstablecimientoSaludrepo.BuscarId(1);
            var epsid = objEpsEstablecimientoSaludrepo.BuscarIdEps(1);
            objEstablecimientoVm.listValoracion = objValoracionrepo.ListarPorClinicaId(1);
            objEstablecimientoVm.totalValoraciones = (objEstablecimientoVm.listValoracion.Count() == 0) ? 0 : Convert.ToInt32(objEstablecimientoVm.listValoracion.Sum(x => x.Calificacion) / objEstablecimientoVm.listValoracion.Count());
            var totalValoracion = objEstablecimientoVm.totalValoraciones;

            // Assert
            Assert.Equal(1, establecimientoId.Id);
            Assert.Equal(1, epsid.Id);
            Assert.True(objEstablecimientoVm.listValoracion.Count>0);
            Assert.Equal(4, totalValoracion);
        }
    }

    // PRUEBAS DE INTEGRACIÓN
    public class EstablecimientoSaludIntegrationTest
    {
        private readonly ClinicaRepositoryImpl objEstablecimientoSaludrepo = new ClinicaRepositoryImpl(new EsTacnaContext());
        private readonly EpsClinicaRepositoryImpl objEpsEstablecimientoSaludrepo = new EpsClinicaRepositoryImpl(new EsTacnaContext());
        private readonly ValoracionRepositoryImpl objValoracionrepo = new ValoracionRepositoryImpl(new EsTacnaContext());
        private readonly ValoracionRepositoryImpl objValoracionRepo = new ValoracionRepositoryImpl(new EsTacnaContext());

        /*Prueba de Integración
         * CP-06 Buscar Establecimientos de Salud CP03
         * CP-27 Visualizar Detalle de las Clínicas CP03
         * CP-30 Calificar Clínicas CP03*/

        [Fact]
        public void TestIntegracionBuscaryCalificar()
        {

            ClinicaViewModel objEstablecimientoVm = new ClinicaViewModel();
            // Arrange
            var criterio = "hospitalizacion";
            var epsid = 1; // Id de la EPS La Positiva
            var establecimientoId = objEstablecimientoSaludrepo.BuscarId(1);
            var epsId = objEpsEstablecimientoSaludrepo.BuscarIdEps(1);
            objEstablecimientoVm.listValoracion = objValoracionrepo.ListarPorClinicaId(1);
            objEstablecimientoVm.totalValoraciones = (objEstablecimientoVm.listValoracion.Count() == 0) ? 0 : Convert.ToInt32(objEstablecimientoVm.listValoracion.Sum(x => x.Calificacion) / objEstablecimientoVm.listValoracion.Count());
            var totalValoracion = objEstablecimientoVm.totalValoraciones;
            // Act
            var resultado = objEstablecimientoSaludrepo.Buscar(criterio, epsid);
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
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count);
            Assert.Contains(resultado, e => e.Id == 1);
            Assert.Contains(resultado, e => e.Id == 5);
            Assert.Equal(1, establecimientoId.Id);
            Assert.Equal(1, epsId.Id);
            Assert.True(objEstablecimientoVm.listValoracion.Count > 0);
            Assert.Equal(4, totalValoracion);
            Assert.NotEqual(0, valoracion.Id);
        }

        /*Prueba de Integración
         * CP-24 Visualizar Clínicas CP03
         * CP-27 Visualizar Detalle de las Clinicas CP03*/

        [Fact]
        public void TestIntegracionVisualizarClinicas()
        {
            ClinicaViewModel objEstablecimientoVm = new ClinicaViewModel();

            // Arrange
            var resultado = objEstablecimientoSaludrepo.ListarClinicas();
            var establecimientoId = objEstablecimientoSaludrepo.BuscarId(1);
            var epsid = objEpsEstablecimientoSaludrepo.BuscarIdEps(1);
            objEstablecimientoVm.listValoracion = objValoracionrepo.ListarPorClinicaId(1);
            objEstablecimientoVm.totalValoraciones = (objEstablecimientoVm.listValoracion.Count() == 0) ? 0 : Convert.ToInt32(objEstablecimientoVm.listValoracion.Sum(x => x.Calificacion) / objEstablecimientoVm.listValoracion.Count());
            var totalValoracion = objEstablecimientoVm.totalValoraciones;

            // Assert
            Assert.True(resultado.Count > 0);
            Assert.Equal(1, establecimientoId.Id);
            Assert.Equal(1, epsid.Id);
            Assert.True(objEstablecimientoVm.listValoracion.Count > 0);
            Assert.Equal(4, totalValoracion);
        }
    }
}
