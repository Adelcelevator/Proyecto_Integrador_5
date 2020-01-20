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
    public class GpeliController : ApiController
    {
        private cn_gpeli cn_usu = new cn_gpeli();
        private ob_gpeli obs = new ob_gpeli();
        public IEnumerable<ob_gpeli> GetAllGpelis()
        {
            List<ob_gpeli> lisus = cn_usu.Todos_gpelis();
            return lisus;
        }
        // metodo de ingreso
        public IHttpActionResult GetGpeli(string gen_id)
        {
            try
            {
                obs = cn_usu.buscarxgpeli(gen_id);
                ob_gpeli[] lisus2 = new ob_gpeli[] {

                    new ob_gpeli{gen_id=obs.gen_id,pel_id=obs.pel_id}

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
        public void Post(int pel_id)
        {
            cn_usu.nuevo_gpeli(pel_id);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, int pel_id)
        {
            cn_usu.actualizar_gpeli(id, pel_id);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_usu.eliminar_gpeli(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
