using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Negocio.Interface;

namespace RuletaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteNegocio ServicioCliente;

        public ClienteController(ClienteNegocio servicioCliente)
        {
            this.ServicioCliente = servicioCliente;
        }
        
        [HttpPost("CrearCliente")]
        public IActionResult CrearCliente([FromBody] ClienteSolicitud solicitudNuevoCliente)
        {
            try
            {
                return new JsonResult(this.ServicioCliente.CrearCliente(solicitudNuevoCliente)){StatusCode=(int)HttpStatusCode.Created};
            }        
            catch (Exception ex)
            {
                return new JsonResult(ex.Message){StatusCode=(int)HttpStatusCode.BadRequest};
            }            
        }

        [HttpGet("ObtenerClientes")]
        public IActionResult ObtenerClientesRegistrado()
        {
            try
            {
                return new JsonResult(this.ServicioCliente.ObtenerClientes()){StatusCode=(int)HttpStatusCode.OK};
            }        
            catch (Exception ex)
            {
                return new JsonResult(ex.Message){StatusCode=(int)HttpStatusCode.BadRequest};
            }            
        }
    }
}
