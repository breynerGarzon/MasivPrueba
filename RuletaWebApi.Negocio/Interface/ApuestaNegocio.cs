using RuletaWebApi.Entidades.Entidades;

namespace RuletaWebApi.Negocio.Interface
{
    public interface ApuestaNegocio
    {
         string AgregarApuesta(ApuestaSolicitud nuevaApuesta, string idUsuario);

         int ObtenerIdUsuarioNumerico(string idUsuario);
    }
}