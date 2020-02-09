using core_1.Models.capa_datos.objetos;
using core_1.Models.capa_negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace core_1.Controllers
{
    public class EmpleadoController : ApiController
    {
        private List<ob_empleado> lista = new List<ob_empleado>();
        private cn_empleado emp = new cn_empleado();


        [HttpGet]
        public IEnumerable<ob_empleado> todos_emp()
        {
            lista = emp.tods();
            return lista;
        }

        [HttpPost]
        public IHttpActionResult nuevo(string ci, string nombre, string ape, string naci, string dire, string tele, string cel)
        {

            bool respuesta = emp.nuevo(ci,nombre,ape,naci,dire,tele,cel);
            if (respuesta.Equals(true))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
