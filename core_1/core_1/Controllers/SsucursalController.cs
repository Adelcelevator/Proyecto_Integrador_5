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
    public class SsucursalController : ApiController
    {
        private cn_ssucursal cn_ss = new cn_ssucursal();
        private ob_ssucursal obs = new ob_ssucursal();
        public IEnumerable<ob_ssucursal> GetAllSsucursales()
        {
            List<ob_ssucursal> lisus = cn_ss.Todos_ssucursales();
            return lisus;
        }
        // metodo de ingreso
        public IHttpActionResult GetSsucursal(string sal_id)
        {
            try
            {
                obs = cn_ss.buscarxssucursal(sal_id);
                ob_ssucursal[] lisus2 = new ob_ssucursal[] {

                    new ob_ssucursal{sal_id=obs.sal_id,suc_id=obs.suc_id}

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
            cn_ss.nuevo_ssucursal(suc_id);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, int suc_id)
        {
            cn_ss.actualizar_ssucursal(id, suc_id);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_ss.eliminar_ssucursal(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
    }
