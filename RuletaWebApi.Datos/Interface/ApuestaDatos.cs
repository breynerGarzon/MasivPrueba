using System.Collections.Generic;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;

namespace RuletaWebApi.Datos.Interface
{
    public interface ApuestaDatos
    {
         bool AgregarApuesta(ApuestaSolicitud nuevaApuesta);

         List<ApuestasPorRuleta> ObtenerApuestasPorIdRuleta(int IdRuleta);
    }
}