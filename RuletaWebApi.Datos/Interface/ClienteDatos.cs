using System.Collections.Generic;
using RuletaWebApi.Entidades.EntidadesBaseDeDatos;

namespace RuletaWebApi.Datos.Interface
{
    public interface ClienteDatos
    {
         int CrearCliente(Cliente nuevoCliente);

         bool ExisteCliente(int idCliente);
         bool ExisteSaldoParaApostar(int id, decimal valorApuesta);
         bool ActualizarSaldo(int id, decimal valorApuesta);
         List<Cliente> ObtenerClientesRegistrados();
    }
}