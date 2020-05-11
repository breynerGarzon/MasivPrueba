using System.Collections.Generic;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;

namespace RuletaWebApi.Negocio.Interface
{
    public interface ClienteNegocio
    {
         int CrearCliente(ClienteSolicitud nuevaSolicitudCliente);
         bool ExisteElClienteConSaldo(int idCliente);
         bool ActualizarSaldo(ApuestaSolicitud apuestaHecha);
         List<Cliente> ObtenerClientes();

    }
}