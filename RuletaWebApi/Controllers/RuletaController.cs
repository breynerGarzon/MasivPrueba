using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RuletaWebApi.Negocio.Interface;

namespace RuletaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RuletaController : ControllerBase
    {
        private readonly RuletaNegocio ServicioRuleta;
        public RuletaController(RuletaNegocio servicioRuleta)
        {
            this.ServicioRuleta = servicioRuleta;
        }

        [HttpPost("Crear")]
        public IActionResult CrearRuleta()
        {
            try
            {
                var idRuleta = this.ServicioRuleta.CrearRuleta();
                return new JsonResult(idRuleta) { StatusCode = (int)HttpStatusCode.Created };
            }
            catch (System.Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }


        [HttpPut("Habilitar/{idRuleta}")]
        public IActionResult HabilitarRuleta(int idRuleta)
        {
            try
            {
                var estado = this.ServicioRuleta.Habilitar(idRuleta);
                return new JsonResult(estado) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (System.Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }


        [HttpPut("DesHabilitar/{idRuleta}")]
        public IActionResult DesHabilitar(int idRuleta)
        {
            try
            {
                var estado = this.ServicioRuleta.DesHabilitar(idRuleta);
                return new JsonResult(estado) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (System.Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }


        [HttpGet("Obtener")]
        public IActionResult ObtenerRuletas()
        {
            try
            {
                var listadoRuletaas = this.ServicioRuleta.ObtenerRuletas();
                return new JsonResult(listadoRuletaas) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (System.Exception ex)
            {
                return new JsonResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
    }
}
