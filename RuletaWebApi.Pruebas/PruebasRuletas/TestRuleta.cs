using Microsoft.Extensions.Options;
using RuletaWebApi.Datos.Servicio;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Pruebas.Utilitario;
using Xunit;

namespace RuletaWebApi.Pruebas.PruebasRuletas
{
    public class TestRuleta
    {
        public IOptions<Configuracion> Opciones { get; set; }
        public RuletaDatosImplementacion ServicioRuletaDatos { get; set; }

        public void InicializarAppSetting()
        {
            var appSettings = new Configuracion() { CadenaConexion = Util.cadenaConexion };
            Opciones = Options.Create(appSettings);
        }

        private void InicializarServicioRuletaDatos()
        {
            ServicioRuletaDatos = new RuletaDatosImplementacion(Opciones);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(false)]
        [InlineData(false)]
        public void CrearRuleta(bool EstadoRuleta)
        {
            InicializarAppSetting();
            InicializarServicioRuletaDatos();
            var nuevaRuleta =  new RuletaSolicitud(){Estado=EstadoRuleta};
            var idRuleta = ServicioRuletaDatos.CrearRuleta(nuevaRuleta);
            Assert.True(idRuleta>0);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void HabilitarRuleta(int idRuletaInput)
        {
            InicializarAppSetting();
            InicializarServicioRuletaDatos();
            var ruletaAActualizar =  new RuletaSolicitud(){Id= idRuletaInput ,Estado=true};
            var seActualizo = ServicioRuletaDatos.ActualizarEstadoRuletaPorId(ruletaAActualizar);
            Assert.True(seActualizo);
        }

    }
}