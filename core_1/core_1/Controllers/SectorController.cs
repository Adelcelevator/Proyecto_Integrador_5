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
    public class SectorController : ApiController
    {
        ob_sector obsec = new ob_sector();
        List<ob_sector> lissec = new List<ob_sector>();
        cn_sector cnsec = new cn_sector();

        [HttpGet]
        public IEnumerable<ob_sector> tod()
        {
            lissec.Clear();
            lissec = cnsec.tod();
            return lissec;
        }

        [HttpGet]
        public IHttpActionResult sectors(string secto_nom)
        {
            obsec = cnsec.secto(secto_nom);
            return Ok(obsec);
        }
    }
}
