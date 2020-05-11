using System;
using System.Drawing;
using RuletaWebApi.Entidades.Entidades;

namespace RuletaWebApi.Entidades.EntidadesBaseDeDatos
{
    public class Apuesta 
    {
        public int Id { get; set; }
        public int Color { get; set; }
        public Ruleta Ruleta { get; set; }
        public Cliente Cliente { get; set; }
        public int RuletaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public short NumeroApuesta { get; set; }
        public decimal ValorApuesta { get; set; }
    }
}