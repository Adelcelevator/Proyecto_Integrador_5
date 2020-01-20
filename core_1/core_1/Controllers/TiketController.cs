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
    public class TiketController : ApiController
    {
        private cn_tiket cn_tik = new cn_tiket();
        private ob_tiket obt = new ob_tiket();
        public IEnumerable<ob_tiket> GetAllUsuarios()
        {
            List<ob_tiket> listk = cn_tik.Todos_tikets();
            return listk;
        }
        // metodo de ingreso
        public IHttpActionResult GetTiket(string tik_id)
        {
            try
            {
                obt = cn_tik.buscarxtiket(tik_id);
                ob_tiket[] listk2 = new ob_tiket[] {

                    new ob_tiket{tik_id=obt.tik_id,usu_id=obt.usu_id,pel_id=obt.pel_id,sal_id=obt.sal_id,tpag_id=obt.tpag_id,tar_id=obt.tar_id,tik_asien=obt.tik_asien,tik_fec=obt.tik_fec}

                };
                return Ok(listk2);
            }
            catch (Exception)
            {
                HttpResponseMessage mensaje = new HttpResponseMessage();
                return Ok(mensaje);
            }

        }


        //insertar
        [HttpPost]
        public void Post(int usu_id, int pel_id, int sal_id, int tpag_id, int tar_id, string tik_asien, string tik_fec)
        {
            cn_tik.nuevo_tiket(usu_id, pel_id, sal_id, tpag_id, tar_id, tik_asien, tik_fec);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, int usu_id, int pel_id, int sal_id, int tpag_id, int tar_id, string tik_asien, string tik_fec)
        {
            cn_tik.actualizar_tiket(id,usu_id, pel_id, sal_id, tpag_id, tar_id, tik_asien, tik_fec);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_tik.eliminar_tiket(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
