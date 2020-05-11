using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using RuletaWebApi.Datos.ContextoBaseDeDatos;
using RuletaWebApi.Datos.Interface;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;
using RuletaWebApi.Entidades.Exepciones;
using RuletaWebApi.Entidades.Utilitario;

namespace RuletaWebApi.Datos.Servicio
{
    public class RuletaDatosImplementacion : RuletaDatos
    {
        readonly Configuracion AppSettings;
        public RuletaDatosImplementacion(IOptions<Configuracion> appSettingsOptions)
        {
            this.AppSettings = appSettingsOptions.Value;
        }
        public int CrearRuleta(RuletaSolicitud nuevaRuleta)
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                using (var transaccion = contextodb.Database.BeginTransaction())
                {
                    var nuevaSolicitud = new Ruleta() { Estado = nuevaRuleta.Estado };
                    contextodb.Ruletas.Add(nuevaSolicitud);
                    var registrosAfectados = contextodb.SaveChanges();
                    if (Utilitario.Util.SeAlteraronRegistros(registrosAfectados))
                    {
                        transaccion.Commit();
                        return nuevaSolicitud.Id;
                    }
                    else
                    {
                        transaccion.Rollback();
                        throw new RuletaException(Mensajes.Ruleta_ErrorAlCrearRuleta);
                    }
                }
            }
        }
        public bool ActualizarEstadoRuletaPorId(RuletaSolicitud ruletaAActualizar)
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                using (var transaccion = contextodb.Database.BeginTransaction())
                {
                    var ruletaConsultada = contextodb.Ruletas.Where(ruletaTempo => ruletaTempo.Id == ruletaAActualizar.Id).First();
                    if (ruletaConsultada == null)
                    {
                        throw new RuletaException(Mensajes.Ruleta_NoExiste);//La excepcionNo existe
                    }
                    ruletaConsultada.Estado = ruletaAActualizar.Estado;
                    var registrosAfectados = contextodb.SaveChanges();
                    if (Utilitario.Util.SeAlteraronRegistros(registrosAfectados))
                    {
                        transaccion.Commit();
                        return true;
                    }
                    else
                    {
                        transaccion.Rollback();
                        return false;
                    }
                }
            }
        }
        public List<RuletaEstado> ObtenerRuletasRegistradas()
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                Console.WriteLine($"Ejecutando en: {AppSettings.CadenaConexion}");
                
                var ruletasConsultada = contextodb.Ruletas
                                                .Select(ruletaTempo => new RuletaEstado(ruletaTempo.Id, ruletaTempo.Estado)
                                                )
                                                .ToList();
                return ruletasConsultada;
            }
        }

        public bool EstaHabilitadaRuleta(int idRuleta)
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                var estadoRuleta = contextodb.Ruletas
                                                .Where(ruletaTempo=> ruletaTempo.Id==idRuleta && ruletaTempo.Estado==true)
                                                .Any();
                return estadoRuleta;
            }
        }
    }
}