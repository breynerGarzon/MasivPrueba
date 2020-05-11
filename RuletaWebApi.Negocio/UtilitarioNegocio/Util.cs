using System.Globalization;

namespace RuletaWebApi.Negocio.UtilitarioNegocio
{
    public static class Util
    {
        public static decimal VALOR_MÁXIMO_APUESTA = 10000M;
        public static decimal VALOR_MÍNIMO_APUESTA = 0M;
        public static decimal VALOR_NUMERO_MÁXIMO_APUESTA = 36;
        public static decimal VALOR_NUMERO_MÍNIMO_APUESTA = 0;

        public static string ObtenerValorEnDinero(decimal monto)
        {
            return monto.ToString("C0", CultureInfo.CurrentCulture);
        }

        public static bool EsValidoElId(int idSuministrado)
        {
            if (idSuministrado > 0)
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