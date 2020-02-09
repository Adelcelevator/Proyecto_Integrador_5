using core_1.Models.capa_datos.objetos;
using core_1.Models.capa_negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace core_1.Controllers
{
    public class EmpleadoUsController : ApiController
    {
        cn_emp_usu cap = new cn_emp_usu();
        ob_emp_usu emp = new ob_emp_usu();
        [HttpGet]
        public IEnumerable<ob_emp_usu> Todo()
        {
            List<ob_emp_usu> list = cap.todos();
            return list;
        }

        [HttpGet]
        public IHttpActionResult mostrar(string emp_us)
        {
            emp = cap.busq(emp_us);
            return Ok(emp);
        }
    }
}
