using capa_datos.objetos;
using capa_negocio;
using core_1.Models.capa_datos.objetos;
using core_1.Models.capa_negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace core_1.Controllers
{
    public class CiudadController : ApiController
    {
        List<ob_ciudad> lista = new List<ob_ciudad>();
        cn_ciudad cnci = new cn_ciudad();
        ob_ciudad obci = new ob_ciudad();

        [HttpGet]
        public IEnumerable<ob_ciudad> todas()
        {
            lista = cnci.tod();
            return lista;
        }

        [HttpGet]
        public IHttpActionResult ciudad(string nomciu)
        {
            obci = cnci.una(nomciu);
            return Ok(obci);
        }
    }
}
