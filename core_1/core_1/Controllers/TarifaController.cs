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
    public class TarifaController : ApiController
    {
        private cn_tarifa cn_tar = new cn_tarifa();
        private ob_tarifa obs = new ob_tarifa();
        public IEnumerable<ob_tarifa> GetAllTarifas()
        {
            List<ob_tarifa> lisus = cn_tar.Todos_tarifas();
            return lisus;
        }
        // metodo de ingreso
        public IHttpActionResult GetUsuario(string usu_id)
        {
            try
            {
                obs = cn_tar.buscarxtarifa(usu_id);
                ob_tarifa[] lisus2 = new ob_tarifa[] {

                    new ob_tarifa{tar_id=obs.tar_id,tar_val=obs.tar_val,tar_det=obs.tar_det}

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
        public void Post( float tar_val, string tar_det)
        {
            cn_tar.nuevo_tarifa(tar_val, tar_det);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, float tar_val, string tar_det)
        {
            cn_tar.actualizar_tarifa(id, tar_val, tar_det);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_tar.eliminar_tarifa(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
