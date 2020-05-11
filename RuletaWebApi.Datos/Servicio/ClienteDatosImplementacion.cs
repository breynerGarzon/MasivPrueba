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
    public class ClienteDatosImplementacion : ClienteDatos
    {
        readonly Configuracion AppSettings;
        public ClienteDatosImplementacion(IOptions<Configuracion> appSettingsOptions)
        {
            this.AppSettings = appSettingsOptions.Value;
        }
        public bool ActualizarSaldo(int idCliente, decimal valorApuesta)
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                using (var transaccion = contextodb.Database.BeginTransaction())
                {
                    var cliente =  contextodb.Clientes.Where(clienteTempo=>clienteTempo.Id == idCliente).FirstOrDefault();
                    cliente.Saldo = cliente.Saldo-valorApuesta;
                    var registros = contextodb.SaveChanges();
                    if (Util.SeAlteraronRegistros(registros))
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

        public int CrearCliente(Cliente nuevoCliente)
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                using (var transaccion = contextodb.Database.BeginTransaction())
                {
                    contextodb.Clientes.Add(nuevoCliente);
                    var registros = contextodb.SaveChanges();
                    if (Util.SeAlteraronRegistros(registros))
                    {
                        transaccion.Commit();
                        return nuevoCliente.Id;
                    }
                    else
                    {
                        transaccion.Rollback();
                        return nuevoCliente.Id;
                    }
                }
            }
        }

        public bool ExisteCliente(int idCliente)
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                return contextodb.Clientes.Where(clienteTempo=>clienteTempo.Id == idCliente).Any();
            }
        }

        public bool ExisteSaldoParaApostar(int idCliente, decimal valorApuesta)
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                return contextodb.Clientes.Where(clienteTempo=>clienteTempo.Id == idCliente && 
                                                                (clienteTempo.Saldo>0 && clienteTempo.Saldo>=valorApuesta))
                                            .Any();
            }
        }

        public List<Cliente> ObtenerClientesRegistrados()
        {
            using (var contextodb = new RuletaContexto() { CadenaConexion = AppSettings.CadenaConexion })
            {
                return contextodb.Clientes.ToList();
            }
        }
    }
}