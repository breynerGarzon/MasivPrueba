using System.Collections.Generic;
using RuletaWebApi.Datos.Interface;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;
using RuletaWebApi.Entidades.Exepciones;
using RuletaWebApi.Entidades.Utilitario;
using RuletaWebApi.Negocio.Interface;
using RuletaWebApi.Negocio.UtilitarioNegocio;

namespace RuletaWebApi.Negocio.Servicio
{
    public class ClienteNegocioImplementacion : ClienteNegocio
    {
        private readonly ClienteDatos ServicioDatos;
        public ClienteNegocioImplementacion(ClienteDatos servicioDatos)
        {
            this.ServicioDatos = servicioDatos;
        }
        public bool ActualizarSaldo(ApuestaSolicitud apuestaHecha)
        {
            throw new System.NotImplementedException();
        }

        public List<Cliente> ObtenerClientes()
        {
            try
            {
                var clientesRegistrados = this.ServicioDatos.ObtenerClientesRegistrados();
                return clientesRegistrados;
            }
            catch (System.Exception)
            {
                return new List<Cliente>();
            }
        }

        public int CrearCliente(ClienteSolicitud nuevaSolicitudCliente)
        {
            try
            {
                var validacionUsuario = new ValidarDatosCliente(nuevaSolicitudCliente);
                if (validacionUsuario.InformacionEsValida)
                {
                    var nuevoCliente = new Cliente()
                    {
                        Nombres = nuevaSolicitudCliente.Nombres,
                        Apellidos = nuevaSolicitudCliente.Apellidos,
                        Saldo = nuevaSolicitudCliente.Saldo
                    };
                    var idCliente = this.ServicioDatos.CrearCliente(nuevoCliente);
                    return idCliente;
                }
                else
                {
                    throw new ClienteException(Mensajes.Cliente_ErrorAlCrear);
                }
            }
            catch (ClienteException exce)
            {
                throw new ClienteException(exce.Message);
            }
            catch (System.Exception)
            {
                throw new ClienteException(Mensajes.Cliente_ErrorAlCrear);
            }
        }

        public bool ExisteElClienteConSaldo(int idCliente)
        {
            throw new System.NotImplementedException();
        }
    }
}