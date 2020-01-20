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
    public class HpeliController : ApiController
    {
        private cn_hpeli cn_usu = new cn_hpeli();
        private ob_hpeli obs = new ob_hpeli();
        public IEnumerable<ob_hpeli> GetAllHpelis()
        {
            List<ob_hpeli> lishp = cn_usu.Todos_hpelis();
            return lishp;
        }
        // metodo de ingreso
        public IHttpActionResult GetHpeli(string pel_id)
        {
            try
            {
                obs = cn_usu.buscarxhpeli(pel_id);
                ob_hpeli[] lisus2 = new ob_hpeli[] {

                    new ob_hpeli{pel_id=obs.pel_id,hor_id=obs.hor_id}

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
        public void Post(int hor_id)
        {
            cn_usu.nuevo_hpeli(hor_id);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, int hor_id)
        {
            cn_usu.actualizar_hpeli(id, hor_id);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_usu.eliminar_hpeli(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }

    }
}
