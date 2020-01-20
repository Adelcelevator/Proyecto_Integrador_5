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
    public class SucursalController : ApiController
    {
        private cn_sucursal cn_suc = new cn_sucursal();
        private ob_sucursal obsu = new ob_sucursal();
        public IEnumerable<ob_sucursal> GetAllSucursal()
        {
            List<ob_sucursal> lisuc = cn_suc.Todos_sucursal();
            return lisuc;
        }
        // metodo de ingreso
        public IHttpActionResult GetSucursal(string suc_id)
        {
            try
            {
                obsu = cn_suc.buscarxsucursal(suc_id);
                ob_sucursal[] lisuc2 = new ob_sucursal[] {

                    new ob_sucursal{suc_id=obsu.suc_id,cin_id=obsu.cin_id,suc_nom=obsu.suc_nom,suc_sec=obsu.suc_sec,suc_ruc=obsu.suc_ruc,suc_dir=obsu.suc_dir,suc_tel=obsu.suc_tel,suc_cor=obsu.suc_cor,suc_ciu=obsu.suc_ciu}

                };
                return Ok(lisuc2);
            }
            catch (Exception)
            {
                HttpResponseMessage mensaje = new HttpResponseMessage();
                return Ok(mensaje);
            }

        }


        //insertar
        [HttpPost]
        public void Post(int cin_id, string suc_nom, string suc_sec, string suc_ruc, string suc_dir, int suc_tel, string suc_cor, string suc_ciu)
        {
            cn_suc.nuevo_sucursal(cin_id, suc_nom, suc_sec, suc_ruc, suc_dir, suc_tel, suc_cor, suc_ciu);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, int cin_id, string suc_nom, string suc_sec, string suc_ruc, string suc_dir, int suc_tel, string suc_cor, string suc_ciu)
        {
            cn_suc.actualizar_sucursal(id, cin_id, suc_nom, suc_sec, suc_ruc, suc_dir, suc_tel, suc_cor, suc_ciu);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_suc.eliminar_sucursal(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
