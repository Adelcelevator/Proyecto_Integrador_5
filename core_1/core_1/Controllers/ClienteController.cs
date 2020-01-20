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
    public class ClienteController : ApiController
    {
        private cn_cliente cn_clie = new cn_cliente();
        private ob_cliente obs = new ob_cliente();

        public IEnumerable<ob_cliente> GetAllCliente()
        {
            List<ob_cliente> liscli = cn_clie.todos_clientes();
            return liscli;
        }
        // metodo de ingreso
        /*
        public IHttpActionResult GetCliente(string cli_id)
        {
            try
            {
                obs = cn_clie.buscar_cliente(cli_id);
                ob_cliente[] lisclie2 = new ob_cliente[] {

                    new ob_cliente{cli_id=obs.cli_id,cli_ruc=obs.cli_ruc,cli_nom=obs.cli_nom,cli_ape=obs.cli_ape,cli_dire=obs.cli_dire,cli_tel=obs.cli_tel,cli_corr=obs.cli_corr,cli_fnaci=obs.cli_fnaci,cli_est=obs.cli_est}

                };
                return Ok(lisclie2);
            }
            catch (Exception)
            {
                HttpResponseMessage mensaje = new HttpResponseMessage();
                return Ok(mensaje);
            }
             
        }
        */

        //insertar
        [HttpPost]
        public void Post(string cli_ruc, string cli_nom, string cli_ape, string cli_dire, int cli_tel, string cli_corr, string cli_fnaci)
        {
            cn_clie.nuevo_cliente(cli_ruc, cli_nom, cli_ape, cli_dire, cli_tel, cli_corr, cli_fnaci);
        }


        //actualizar
        [HttpPut]
        public void Put(int cli_id, string cli_ruc, string cli_nom, string cli_ape, string cli_dire, int cli_tel, string cli_corr, string cli_fnaci)
        {
            cn_clie.actualizar_cliente(cli_id, cli_ruc, cli_nom, cli_ape, cli_dire, cli_tel, cli_corr, cli_fnaci);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_clie.eliminar_cliente(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
