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
    public class StarifaController : ApiController
    {
        private cn_starifa cn_usu = new cn_starifa();
        private ob_starifa obs = new ob_starifa();
        public IEnumerable<ob_starifa> GetAllStarifas()
        {
            List<ob_starifa> lisus = cn_usu.Todos_starifas();
            return lisus;
        }
        // metodo de ingreso
        public IHttpActionResult GetSstarifa(string suc_id)
        {
            try
            {
                obs = cn_usu.buscarxstarifa(suc_id);
                ob_starifa[] lisus2 = new ob_starifa[] {

                    new ob_starifa{suc_id=obs.suc_id,tar_id=obs.tar_id}

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
        public void Post(int suc_id)
        {
            cn_usu.nuevo_starifa(suc_id);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, int tar_id)
        {
            cn_usu.actualizar_starifa(id, tar_id);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_usu.eliminar_starifa(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }

    }
}
