using System;

namespace RuletaWebApi.Entidades.Entidades
{
    public class ApuestaSolicitud
    {
        public int RuletaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public Color ColorApuesta { get; set; }
        public short NumeroApuesta { get; set; }
        public decimal ValorApuesta { get; set; }

        public ApuestaSolicitud()
        {
            this.Fecha =DateTime.Now;
        }
    }
}