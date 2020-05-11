using System;
using System.Collections.Generic;
using System.Linq;

namespace RuletaWebApi.Entidades.EntidadesBaseDeDatos
{
    public class ApuestasPorRuleta
    {
        public int Id_Ruleta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ValorApuesta { get; set; }
        public int CantidadApuesta { get; set; }
    }
}