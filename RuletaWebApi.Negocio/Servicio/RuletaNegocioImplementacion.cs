using System;
using System.Collections.Generic;
using RuletaWebApi.Datos.Interface;
using RuletaWebApi.Datos.Utilitario;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;
using RuletaWebApi.Entidades.Exepciones;
using RuletaWebApi.Entidades.Utilitario;
using RuletaWebApi.Negocio.Interface;

namespace RuletaWebApi.Negocio.Servicio
{
    public class RuletaNegocioImplementacion : RuletaNegocio
    {
        private readonly RuletaDatos ServicioDatosRuleta;
        private readonly ApuestaDatos ServicioDatosApuesta;

        public RuletaNegocioImplementacion(RuletaDatos servicioDatosRuleta, ApuestaDatos servicioDatosApuesta)
        {
            this.ServicioDatosApuesta = servicioDatosApuesta;
            this.ServicioDatosRuleta = servicioDatosRuleta;
        }
        public int CrearRuleta()
        {
            try
            {
                var nuevaRuleta = new RuletaSolicitud() { Estado = false };
                var idNuevaRuleta = this.ServicioDatosRuleta.CrearRuleta(nuevaRuleta);
                return idNuevaRuleta;
            }
            catch (RuletaException exce)
            {
                throw exce;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<ApuestasPorRuleta> DesHabilitar(int idRuleta)
        {
            try
            {
                if (Util.EsValidoIdRuleta(idRuleta))
                {
                    var EstaHabilitada = this.ServicioDatosRuleta.EstaHabilitadaRuleta(idRuleta);
                    if (EstaHabilitada)
                    {
                        var ruletaAActualizar = new RuletaSolicitud() { Id = idRuleta, Estado = false };
                        var seActulizoRuleta = this.ServicioDatosRuleta.ActualizarEstadoRuletaPorId(ruletaAActualizar);
                        if (seActulizoRuleta)
                        {
                            return this.ServicioDatosApuesta.ObtenerApuestasPorIdRuleta(idRuleta);
                        }
                        else
                        {
                            var mensaje = string.Format(Mensajes.Ruleta_ErrorAlActualizarEstado, idRuleta);
                            throw new RuletaException(mensaje);
                        }
                    }
                    else
                    {
                        throw new RuletaException(Mensajes.Ruleta_YaEstaDeshabilitada);
                    }
                }
                else
                {
                    throw new RuletaException(Mensajes.Ruleta_IdInválido);
                }
            }
            catch (RuletaException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new Exception(Mensajes.Apuesta_ErrorNoControlado);
            }
        }

        public string Habilitar(int idRuleta)
        {
            try
            {
                if (Util.EsValidoIdRuleta(idRuleta))
                {
                    var EstaHabilitada = this.ServicioDatosRuleta.EstaHabilitadaRuleta(idRuleta);
                    if (!EstaHabilitada)
                    {
                        var ruletaAActualizar = new RuletaSolicitud() { Id = idRuleta, Estado = true };
                        var seActualizoRuleta = this.ServicioDatosRuleta.ActualizarEstadoRuletaPorId(ruletaAActualizar);
                        if (seActualizoRuleta)
                        {
                            return string.Format(Mensajes.Ruleta_Habilitada, idRuleta);
                        }
                        else
                        {
                            return string.Format(Mensajes.Ruleta_ErrorAlActualizarEstado, idRuleta);
                        }
                    }
                    else
                    {
                        throw new RuletaException(Mensajes.Ruleta_YaEstaHabilitada);
                    }
                }
                else
                {
                    throw new RuletaException(Mensajes.Ruleta_IdInválido);
                }
            }
            catch (RuletaException exceptionRuleta)
            {
                throw exceptionRuleta;
            }
            catch (System.Exception)
            {
                throw new Exception(Mensajes.Apuesta_ErrorNoControlado);
            }
        }

        public List<RuletaEstado> ObtenerRuletas()
        {
            try
            {
                return this.ServicioDatosRuleta.ObtenerRuletasRegistradas();
            }
            catch (System.Exception ex)
            {
                throw new Exception(Mensajes.Ruleta_ErrorAlConsultar);
            }
        }

    }
}