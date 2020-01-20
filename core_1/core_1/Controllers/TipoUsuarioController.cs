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
    public class TipoUsuarioController : ApiController
    {

        private cn_tipo_usuario cn_tipo_usu = new cn_tipo_usuario();
        private ob_tipo ob = new ob_tipo();
        public IEnumerable<ob_tipo> GetAllTipo_Usuario()
        {
            List<ob_tipo> lisus = cn_tipo_usu.Todos_tipos_usu();
            return lisus;
        }
        // metodo de ingreso
        /*  public IHttpActionResult GetUsuario(string tus_id)
          {
              try
              {
                  obs = cn_tipo_usu.buscarxusu(tus_id);
                  ob_tipo[] lisus2 = new ob_tipo[] {

                      new ob_tipo{tus_id=obs.tus_id,tus_desc=obs.tus_desc}

                  };
                  return Ok(lisus2);
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
        public IHttpActionResult Ingresar(string desc)
        {
            cn_tipo_usu.nuevo_tipo_usu(desc);
            return Ok();
        }

        /*
        //actualizar
        [HttpPut]
        public void Put(int id, int cli_id, int tus_id, string usu_usu, string usu_pass)
        {
            cn_usu.actualizar_usuario(id, cli_id, tus_id, usu_usu, usu_pass);
        }

        */
        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int tusid)
        {
            cn_tipo_usu.eliminar_tipo_usu(tusid);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
