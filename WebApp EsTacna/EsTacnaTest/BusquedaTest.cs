using EsTacna.Repositories;
using EsTacna.Models;

namespace EsTacnaTest
{
    public class BusquedaTest
    {
        private readonly BusquedaRepositoryImpl objBusquedaRepo = new BusquedaRepositoryImpl(new EsTacnaContext());

        [Fact]
        public void RegistrarTest()
        {
            //Arrange
            var objBusqueda = new Busquedum
            {
                UsuarioId = 1,
                TerminoBusqueda = "CLINICA LA LUZ",
                Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
            };

            // Act
            objBusquedaRepo.Registrar(objBusqueda);
            var listarBusqueda = objBusquedaRepo.ListarBusqueda().Where(x => x.Fecha == objBusqueda.Fecha).FirstOrDefault();
        }

        [Fact]
        public void ListarTest()
        {
            // Arrange
            var objBusqueda = new Busquedum
            {
                Id = 4,
                UsuarioId = 4,
                TerminoBusqueda = "RIMAC maternidad",
                Fecha = DateTime.Parse("2023-05-19 02:12:01.210")
            };

            //Act
            var resultado = objBusquedaRepo.ListarBusqueda();

            //Assert
            Assert.True(resultado.Count > 0);
            Assert.True(resultado.Where(x => x.Id == objBusqueda.Id).First().Id == objBusqueda.Id);
        }
    }
}

