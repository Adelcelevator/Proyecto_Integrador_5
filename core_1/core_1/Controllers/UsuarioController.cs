using core_1.Models.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace core_1.Controllers
{
    public class UsuarioController : ApiController
    {

       ob_usuario[] lisus = new ob_usuario[] {
                new ob_usuario{usu_id=1,cli_id=1,tus_id=1,usu_usu="adel",usu_pass="hola",datop="otra"}
            };
        public IEnumerable<ob_usuario> GetAllUsuarios()
        {

            return lisus;
        }
        
        public IHttpActionResult GetUsuario(string id)
        {
            ob_usuario[] lisus2 = new ob_usuario[] {
                new ob_usuario{usu_id=1,cli_id=1,tus_id=1,usu_usu="adelcelevator",usu_pass="hola123",datop=id}
            };
            return Ok(lisus2);
        }
    }
}
