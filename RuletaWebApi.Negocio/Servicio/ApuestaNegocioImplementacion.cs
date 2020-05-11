using System;
using RuletaWebApi.Datos.Interface;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.Exepciones;
using RuletaWebApi.Entidades.Utilitario;
using RuletaWebApi.Negocio.UtilitarioNegocio;
using RuletaWebApi.Negocio.Interface;
using System.Linq;

namespace RuletaWebApi.Negocio.Servicio
{
    public class ApuestaNegocioImplementacion : ApuestaNegocio
    {
        private readonly ApuestaDatos ServicioApuestaDatos;
        private readonly ClienteDatos servicioClienteDatos;
        private readonly RuletaDatos servicioRuletaDatos;
        public ApuestaNegocioImplementacion(ApuestaDatos servicioApuestaDatos, ClienteDatos servicioClienteDatos, RuletaDatos servicioRuletaDatos)
        {
            this.servicioRuletaDatos = servicioRuletaDatos;
            this.servicioClienteDatos = servicioClienteDatos;
            this.ServicioApuestaDatos = servicioApuestaDatos;
        }
        
        public string AgregarApuesta(ApuestaSolicitud nuevaSolicitudDeApuesta, string idUsario)
        {
            try
            {
                nuevaSolicitudDeApuesta.ClienteId= this.ObtenerIdUsuarioNumerico(idUsario);
                var validacion = new ValidarDatosApuesta(nuevaSolicitudDeApuesta);
                if (validacion.ApuestaEsValida)
                {
                    var existeRuletaYEstaHabilitada = this.servicioRuletaDatos.EstaHabilitadaRuleta(nuevaSolicitudDeApuesta.RuletaId);
                    if (existeRuletaYEstaHabilitada)
                    {
                        var existeCliente = this.servicioClienteDatos.ExisteCliente(nuevaSolicitudDeApuesta.ClienteId);
                        if (existeCliente)
                        {
                            var existeSaldo = this.servicioClienteDatos.ExisteSaldoParaApostar(nuevaSolicitudDeApuesta.ClienteId, nuevaSolicitudDeApuesta.ValorApuesta);
                            if (existeSaldo)
                            {
                                var seRegistroApuesta = this.ServicioApuestaDatos.AgregarApuesta(nuevaSolicitudDeApuesta);
                                if (seRegistroApuesta)
                                {
                                    var seActulizoSaldo = this.servicioClienteDatos.ActualizarSaldo(nuevaSolicitudDeApuesta.ClienteId, nuevaSolicitudDeApuesta.ValorApuesta);
                                    if (seActulizoSaldo)
                                    {
                                        return Mensajes.Apuesta_AgregadaConExito;
                                    }
                                    else
                                    {
                                        seActulizoSaldo = this.servicioClienteDatos.ActualizarSaldo(nuevaSolicitudDeApuesta.ClienteId, nuevaSolicitudDeApuesta.ValorApuesta);
                                        return Mensajes.Apuesta_AgregadaConExito;
                                    }
                                }
                                else
                                {
                                    throw new ApuestaException(Mensajes.Apuesta_ErrorAlCrearApuesta);
                                }
                            }
                            else
                            {
                                var mensaje = string.Format(Mensajes.Cliente_SaldoInSuficiente, nuevaSolicitudDeApuesta.ClienteId);
                                throw new ApuestaException(mensaje);
                            }
                        }
                        else
                        {
                            var mensaje = string.Format(Mensajes.Cliente_NoDisponible, nuevaSolicitudDeApuesta.ClienteId);
                            throw new ApuestaException(mensaje);
                        }
                    }
                    else
                    {
                        var mensaje = string.Format(Mensajes.Ruleta_NoHabilitada, nuevaSolicitudDeApuesta.RuletaId);
                        throw new RuletaException(mensaje);
                    }
                }
                else
                {
                    throw new RuletaException(Mensajes.Apuesta_DatosGeneralesInválidos);
                }
            }
            catch (RuletaException exe)
            {
                throw exe;
            }
            catch (ApuestaException exe)
            {
                throw exe;
            }
            catch (System.Exception exce)
            {
                throw new Exception(Mensajes.Apuesta_ErrorNoControlado);
            }
        }

        public int ObtenerIdUsuarioNumerico(string idUsuario)
        {
            if (!string.IsNullOrEmpty(idUsuario) && idUsuario.All(char.IsDigit))
            {
                return Convert.ToInt32(idUsuario);
            }
            throw new ApuestaException(Mensajes.Apuesta_ClienteInválido);
        }
    }
}