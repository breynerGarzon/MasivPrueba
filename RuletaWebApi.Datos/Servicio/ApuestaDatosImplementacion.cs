using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using RuletaWebApi.Datos.ContextoBaseDeDatos;
using RuletaWebApi.Datos.Interface;
using RuletaWebApi.Datos.Utilitario;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;

namespace RuletaWebApi.Datos.Servicio
{
    public class ApuestaDatosImplementacion : ApuestaDatos
    {

        readonly Configuracion AppSettings;
        public ApuestaDatosImplementacion(IOptions<Configuracion> appSettingsOptions)
        {
            this.AppSettings = appSettingsOptions.Value;
        }
        public bool AgregarApuesta(ApuestaSolicitud nuevaApuesta)
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                using (var transaccion = contextodb.Database.BeginTransaction())
                {
                    try
                    {
                        var nuevaApuestaDB = new Apuesta()
                        {
                            ClienteId = nuevaApuesta.ClienteId,
                            Color = (int)nuevaApuesta.ColorApuesta,
                            RuletaId = nuevaApuesta.RuletaId,
                            Fecha = nuevaApuesta.Fecha,
                            ValorApuesta = nuevaApuesta.ValorApuesta,
                            NumeroApuesta = nuevaApuesta.NumeroApuesta
                        };
                        contextodb.Apuestas.Add(nuevaApuestaDB);
                        var registros = contextodb.SaveChanges();
                        if (Util.SeAlteraronRegistros(registros))
                        {
                            transaccion.Commit();
                            return true;
                        }
                        else
                        {
                            transaccion.Rollback();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        transaccion.Rollback();
                        return false;
                    }
                    return false;
                }
            }
        }
        public List<ApuestasPorRuleta> ObtenerApuestasPorIdRuleta(int IdRuleta)
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                var ruletasConsultada = contextodb.Apuestas
                                                .Where(apuestaTempo => apuestaTempo.RuletaId == IdRuleta)
                                                .GroupBy(apuestaTempo => new { apuestaTempo.Fecha, apuestaTempo.RuletaId })
                                                .Select(apuestaTempo => new ApuestasPorRuleta()
                                                {
                                                    Id_Ruleta = apuestaTempo.Key.RuletaId,
                                                    Fecha = apuestaTempo.Key.Fecha,
                                                    ValorApuesta = apuestaTempo.Sum(x => x.ValorApuesta),
                                                    CantidadApuesta = apuestaTempo.Count()
                                                })
                                                .ToList();
                return ruletasConsultada;
            }

        }
    }
}