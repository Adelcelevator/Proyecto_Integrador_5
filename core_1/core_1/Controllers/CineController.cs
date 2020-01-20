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
    public class CineController : ApiController
    {


        private cn_cine cn_cin = new cn_cine();
        private ob_cine obs = new ob_cine();
        public IEnumerable<ob_cine> GetAllCine()
        {
          List<ob_cine> liscin = cn_cin.Todos_cines();
            return liscin;
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
    public void Post(string cin_nom)
    {
            cn_cin.nuevo_cine(cin_nom);
    }


    //actualizar
    [HttpPut]
    public void Put(int cin_id, string cin_nom)
    {
            cn_cin.actualizar_cine(cin_id,cin_nom);
    }


    //eliminar
    [HttpDelete]
    public IHttpActionResult DELETE(int id_cin)
    {
        cn_cin.eliminar_cin(id_cin);
        return Ok();
    }
}
}
