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

        [HttpGet]
        public IEnumerable<ob_sucursal> GetAllSucursal()
        {
            List<ob_sucursal> lisuc = cn_suc.Todos_sucursal();
            return lisuc;
        }

        [HttpGet]
        public IEnumerable<ob_sucursal> suc_x_cin(int id_ci)
        {
            List<ob_sucursal> lisuc = cn_suc.sucs_x_ci(id_ci);
            return lisuc;
        }

        [HttpGet]
        public IHttpActionResult suc_x_suc(string nom_suc)
        {
            ob_sucursal obs = cn_suc.buscarxsuc(nom_suc);
            return Ok(obs);
        }
        // metodo de ingreso
        [HttpGet]
        public IHttpActionResult GetSucursal(string suc_id)
        {
            try
            {
                obsu = cn_suc.buscarxsucursal(suc_id);
                ob_sucursal[] lisuc2 = new ob_sucursal[] {

                    new ob_sucursal{suc_id=obsu.suc_id,cin_id=obsu.cin_id,suc_nom=obsu.suc_nom,sec_id=obsu.sec_id,suc_ruc=obsu.suc_ruc,suc_dir=obsu.suc_dir,suc_tel=obsu.suc_tel,suc_cor=obsu.suc_cor,ciu_id=obsu.ciu_id}

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
        public IHttpActionResult Post(int cin_id, int ciu_id, int sec_id, string suc_nom, string suc_ruc, string suc_dir, string suc_tel, string suc_cor)
        {
            if (cn_suc.nuevo_sucursal(cin_id, ciu_id, sec_id, suc_nom, suc_ruc, suc_dir, suc_tel, suc_cor))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        //actualizar
        [HttpPut]
        public void Put(int id, int ciu_id, int sec_id, int cin_id, string suc_nom, string suc_sec, string suc_ruc, string suc_dir, int suc_tel, string suc_cor, string suc_esta)
        {
            cn_suc.actualizar_sucursal(id, ciu_id, sec_id, cin_id, suc_nom, suc_sec, suc_ruc, suc_dir, suc_tel, suc_cor, suc_esta);
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
