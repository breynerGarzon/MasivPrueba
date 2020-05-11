namespace RuletaWebApi.Datos.Utilitario
{
    public static class Util
    {
        public static bool SeAlteraronRegistros(int registros)
        {
            if (registros > 0)
            {
                return true;
            }
            return false;
        }


        public static bool EsValidoIdRuleta(int registros)
        {
            if (registros > 0)
            {
                return true;
            }
            return false;
        }


    }
}