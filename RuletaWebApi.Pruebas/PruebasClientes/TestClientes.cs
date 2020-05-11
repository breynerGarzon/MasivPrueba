using System;
using Microsoft.Extensions.Options;
using RuletaWebApi.Datos.Servicio;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;
using RuletaWebApi.Pruebas.Utilitario;
using Xunit;

namespace RuletaWebApi.Pruebas.PruebasClientes
{
    public class TestClientes
    {
        public IOptions<Configuracion> Opciones { get; set; }
        public ClienteDatosImplementacion ServicioClienteDatos { get; set; }

        public void InicializarAppSetting()
        {
            var appSettings = new Configuracion() { CadenaConexion = Util.cadenaConexion };
            Opciones = Options.Create(appSettings);
        }

        private void InicializarServicioClienteDatos()
        {
            ServicioClienteDatos = new ClienteDatosImplementacion(Opciones);
        }

        [Theory]
        [InlineData("Breyner Stihuar", "Garzón Torres", 115000)]
        [InlineData("Marcela Benites", "Uribe Torres", 200000)]
        [InlineData("Juan Camilo", "Garzón Rodriguez", 500000)]
        [InlineData("Oscar Juanito", "Tores Paez", 350000)]
        [InlineData("Eduardo Misael", "Sandoval Jimenez", 90000)]
        public void CrearUsuario(string NombreCliente, string ApellidoCliente, decimal SaldoCliente)
        {
            InicializarAppSetting();
            InicializarServicioClienteDatos();
            var nuevoCliente = new Cliente() { Nombres = NombreCliente, Apellidos = ApellidoCliente, Saldo = SaldoCliente };
            var idNuevoCliente = ServicioClienteDatos.CrearCliente(nuevoCliente);
            var seCreoElUsuario = ServicioClienteDatos.ExisteCliente(idNuevoCliente);
            Assert.True(seCreoElUsuario);
        }


        [Theory]
        [InlineData(2, 115000)]
        [InlineData(5, 200000)]
        [InlineData(3, 500000)]
        [InlineData(4, 350000)]
        [InlineData(1, 90000)]
        public void ValidarSiClientePoseeSaldoParaApostar(int IdCliente, decimal valorApuesta)
        {
            InicializarAppSetting();
            InicializarServicioClienteDatos();
            var TieneSaldoParaApostar = ServicioClienteDatos.ExisteSaldoParaApostar(IdCliente, valorApuesta);
            Assert.True(TieneSaldoParaApostar);
        }


        [Theory]
        [InlineData(1, 80000)]
        [InlineData(2, 15000)]
        [InlineData(3, 400000)]
        [InlineData(4, 50000)]
        [InlineData(5, 300000)]
        public void ValidarSiSeActualizaElSaldo(int IdCliente, decimal valorApuesta)
        {
            InicializarAppSetting();
            InicializarServicioClienteDatos();
            var SeActualizoSaldo = ServicioClienteDatos.ActualizarSaldo(IdCliente, valorApuesta);
            Assert.True(SeActualizoSaldo);
        }


    }
}