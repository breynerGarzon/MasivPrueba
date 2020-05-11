

using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.Exepciones;
using RuletaWebApi.Entidades.Utilitario;

namespace RuletaWebApi.Negocio.UtilitarioNegocio
{
    public class ValidarDatosApuesta
    {
        public bool ApuestaEsValida { get; set; }
        public ApuestaSolicitud ApuestaAEvaluar { get; }

        public ValidarDatosApuesta(ApuestaSolicitud apuestaAEvaluar)
        {
            this.ApuestaAEvaluar = apuestaAEvaluar;
            if (!this.ValidarId(apuestaAEvaluar.ClienteId))
            {
                throw new ApuestaException(Mensajes.Apuesta_ClienteInválido);
            }

            if (!this.ValidarId(apuestaAEvaluar.RuletaId))
            {
                throw new ApuestaException(Mensajes.Ruleta_IdInválido);
            }

            var esValidaLaSeleccion = apuestaAEvaluar.ColorApuesta == Color.NoAsignado ? this.ValidarNumeroSeleccionado(apuestaAEvaluar.NumeroApuesta) : true;
            if (!esValidaLaSeleccion)
            {
                throw new ApuestaException(Mensajes.Apuesta_NumeroInválido);
            }

            var esValidoElSaldo = this.ValidarValorApuesta(apuestaAEvaluar.ValorApuesta);
            if (!esValidoElSaldo)
            {
                var mensaje = string.Format(Mensajes.Apuesta_ValorApuestaInValido,Util.ObtenerValorEnDinero(Util.VALOR_MÍNIMO_APUESTA), Util.ObtenerValorEnDinero(Util.VALOR_MÁXIMO_APUESTA));
                throw new ApuestaException(mensaje);
            }

            ApuestaEsValida = true;
        }

        private bool ValidarId(int id)
        {
            if (id > 0)
            {
                return true;
            }
            return false;
        }

        private bool ValidarNumeroSeleccionado(int numeroApuesta)
        {
            if (numeroApuesta >= Util.VALOR_NUMERO_MÍNIMO_APUESTA && numeroApuesta <= Util.VALOR_NUMERO_MÁXIMO_APUESTA)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidarValorApuesta(decimal ValorApuesta)
        {
            if (ValorApuesta > Util.VALOR_MÍNIMO_APUESTA && ValorApuesta <= Util.VALOR_MÁXIMO_APUESTA)
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