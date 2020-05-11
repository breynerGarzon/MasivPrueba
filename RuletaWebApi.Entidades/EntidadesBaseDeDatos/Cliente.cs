using System.Collections.Generic;
using RuletaWebApi.Entidades.Entidades;

namespace RuletaWebApi.Entidades.EntidadesBaseDeDatos
{
    public class Cliente : ClienteSolicitud
    {
        public int Id { get; set; }
        public List<Apuesta> Apuestas { get; set; }
    }
}