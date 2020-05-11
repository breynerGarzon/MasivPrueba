

using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.Exepciones;
using RuletaWebApi.Entidades.Utilitario;

namespace RuletaWebApi.Negocio.UtilitarioNegocio
{
    public class ValidarDatosCliente
    {
        public bool InformacionEsValida { get; set; }
        public ApuestaSolicitud ApuestaAEvaluar { get; }

        public ValidarDatosCliente(ClienteSolicitud clienteAEvaluar)
        {
            var NombresYApellidoValidos = this.ValidarNombresYApellidos(clienteAEvaluar.Nombres, clienteAEvaluar.Apellidos);
            if (!NombresYApellidoValidos)
            {
                throw new ClienteException(Mensajes.Cliente_NombreInválidos);
            }
            var SaldoValido = this.ValidarSaldo(clienteAEvaluar.Saldo);
            if (!SaldoValido)
            {
                throw new ClienteException(Mensajes.Cliente_SaldoInvalido);
            }
            InformacionEsValida = true;
        }

        private bool ValidarNombresYApellidos(string nombres, string apellidos)
        {
            if (string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos))
            {
                return false;
            }
            return true;
        }
        private bool ValidarSaldo(decimal ValorApuesta)
        {
            if (ValorApuesta > Util.VALOR_MÍNIMO_APUESTA)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}