using capa_datos.objetos;
using capa_negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace core_1.Controllers
{
    public class TpagoController : ApiController
    {
        private cn_tpago cn_tp = new cn_tpago();
        private ob_tpago obs = new ob_tpago();
        public IEnumerable<ob_tpago> GetAllTpagos()
        {
            List<ob_tpago> lisus = cn_tp.Todos_tpagos();
            return lisus;
        }
        // metodo de ingreso
        public IHttpActionResult GetTpago(string tpag_id)
        {
            try
            {
                obs = cn_tp.buscarxtpago(tpag_id);
                ob_tpago[] lisus2 = new ob_tpago[] {

                    new ob_tpago{tpag_id=obs.tpag_id,tpag_nom=obs.tpag_nom}

                };
                return Ok(lisus2);
            }
            catch (Exception)
            {
                HttpResponseMessage mensaje = new HttpResponseMessage();
                return Ok(mensaje);
            }

        }


        //insertar
        [HttpPost]
        public void Post(string tpag_nom)
        {
            cn_tp.nuevo_tpago(tpag_nom);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, string tpag_nom)
        {
            cn_tp.actualizar_tpago(id, tpag_nom);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_tp.eliminar_tpago(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
