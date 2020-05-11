using System.Collections.Generic;
using RuletaWebApi.Entidades.Entidades;

namespace RuletaWebApi.Entidades.EntidadesBaseDeDatos
{
    public class Ruleta : RuletaSolicitud
    {
        public List<Apuesta> Apuestas { get; set; }
    }
}