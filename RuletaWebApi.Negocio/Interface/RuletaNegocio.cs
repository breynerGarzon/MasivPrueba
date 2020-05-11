using System.Collections.Generic;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;

namespace RuletaWebApi.Negocio.Interface
{
    public interface RuletaNegocio
    {
         int CrearRuleta();
         string Habilitar(int idRuleta);
         List<ApuestasPorRuleta> DesHabilitar(int idRuleta);
         List<RuletaEstado> ObtenerRuletas();
    }
}