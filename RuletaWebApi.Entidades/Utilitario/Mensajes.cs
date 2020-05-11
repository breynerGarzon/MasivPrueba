namespace RuletaWebApi.Entidades.Utilitario
{
    public static class Mensajes
    {
        public static string Ruleta_NoExiste = "El id de la ruleta suministrado no se encuentra registrado";
        public static string Ruleta_IdInválido = "El id de la ruleta suministrado es inválido";
        public static string Ruleta_Habilitada = "La ruleta {0} ha sido habilitada";
        public static string Ruleta_ErrorAlCrearRuleta = "Se ha generado un error al intentar crear la ruleta, intente nuevamente";
        public static string Ruleta_ErrorAlActualizarEstado = "Se ha generado un error al actualizar la ruleta {0}, intente nuevamente";
        public static string Ruleta_NoHabilitada = "La ruleta {0} actualmente no se encuentra disponible para realizar apuestas";
        public static string Ruleta_ErrorAlConsultar = "Se genero un error al consultar las ruletas";
        public static string Ruleta_YaEstaDeshabilitada = "La ruleta ya se encuentra deshabilitada";

        public static string Ruleta_YaEstaHabilitada = "La ruleta actualmente ya se encuentra habilitada";


        public static string Cliente_NoDisponible = "Actualmente el cliente {0} no registra en el sistema.";
        public static string Cliente_SaldoInSuficiente = "Actualmente el cliente {0} no posee el saldo suficiente para esta apuesta.";
        public static string Cliente_ErrorAlCrear = "Se genero un error al crear el cliente.";
        public static string Cliente_NombreInválidos = "Los datos de nombres y/o apellidos son inválidos para la creación del usuario.";
        public static string Cliente_SaldoInvalido = "El saldo suministrado es inválido.";
        public static string Apuesta_DatosGeneralesInválidos = "Puede que algún valor de la apuesta se encuentren erroneos, por favor vuelva a corroborar";
        public static string Apuesta_ValorApuestaInValido = "El valor de la apuesta es inválido, te recordamos que los montos de las apuestas entran entre {0} y {1}";
        public static string Apuesta_NumeroInválido = "El número seleccionado para apostar esta fuera del rango disponible";
        public static string Apuesta_ClienteInválido = "El id del cliente suministrado para la apuesta es inválido";
        public static string Apuesta_ErrorAlCrearApuesta = "Se ha generado un error al generar la apuesta, intente nuevamente por favor";
        public static string Apuesta_ErrorNoControlado = "Se ha generado un error al registrar la apuesta, intente nuevamente por favor";

        public static string Apuesta_AgregadaConExito = "La apuesta ha sido registrada exitosamente";
    }
}