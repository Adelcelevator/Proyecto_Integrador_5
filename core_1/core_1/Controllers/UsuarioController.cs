using capa_negocio;
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
        private cn_usuario cn_usu = new cn_usuario();
        private ob_usuario obs = new ob_usuario();
        public IEnumerable<ob_usuario> GetAllUsuarios()
        {
            List<ob_usuario> lisus = cn_usu.Todos_usuarios();
            return lisus;
        }
        // metodo de ingreso
        public IHttpActionResult GetUsuario(string usu_id)
        {
            try
            {
            obs = cn_usu.buscarxusu(usu_id);
            ob_usuario[] lisus2 = new ob_usuario[] {

                    new ob_usuario{usu_id=obs.usu_id,cli_id=obs.cli_id,tus_id=obs.tus_id,usu_usu=obs.usu_usu,usu_pass=obs.usu_pass}

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
    public void Post(int clid, string usu, string contra)
    {
        cn_usu.nuevo_usuario(clid, usu, contra);
    }


    //actualizar
    [HttpPut]
    public void Put(int id,int cli_id, int tus_id, string usu_usu, string usu_pass)
    {
        cn_usu.actualizar_usuario(id,cli_id, tus_id, usu_usu, usu_pass);
    }


    //eliminar
    [HttpDelete]
    public IHttpActionResult DELETE(int id)
    {
        cn_usu.eliminar_usuario(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
    }
}
}