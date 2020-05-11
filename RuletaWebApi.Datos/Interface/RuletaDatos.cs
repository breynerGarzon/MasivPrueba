using System.Collections.Generic;
using RuletaWebApi.Entidades.Entidades;

namespace RuletaWebApi.Datos.Interface
{
    public interface RuletaDatos
    {
         int CrearRuleta(RuletaSolicitud nuevaRuleta);
         bool ActualizarEstadoRuletaPorId(RuletaSolicitud ruletaAActualizar);
         bool EstaHabilitadaRuleta(int idRuleta);
         List<RuletaEstado> ObtenerRuletasRegistradas();

    }
}