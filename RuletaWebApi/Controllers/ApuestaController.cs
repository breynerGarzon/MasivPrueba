using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RuletaWebApi.Entidades.Entidades;
using RuletaWebApi.Entidades.Exepciones;
using RuletaWebApi.Negocio.Interface;

namespace RuletaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApuestaController : ControllerBase
    {
        private readonly ApuestaNegocio ServicioApuesta;

        public ApuestaController(ApuestaNegocio servicioApuesta)
        {
            this.ServicioApuesta = servicioApuesta;
        }

        [HttpPost("Crear")]
        public IActionResult CrearApuesta([FromHeader]string idUsuario ,
        [FromBody] ApuestaSolicitud solicitudNuevaApuesta)
        {
            try
            {
                return new JsonResult(this.ServicioApuesta.AgregarApuesta(solicitudNuevaApuesta, idUsuario)) { StatusCode = (int)HttpStatusCode.Created };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
    }
}
