using core_1.Models.capa_datos;
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
        private cd_usuario cd_usu = new cd_usuario();
        ob_usuario obs = new ob_usuario();
        ob_usuario[] lisus = new ob_usuario[] {
                new ob_usuario{usu_id=1,cli_id=1,tus_id=1,usu_usu="otra",usu_pass="otra"}
            };
        public IEnumerable<ob_usuario> GetAllUsuarios()
        {

            return lisus;
        }
        // metodo de ingreso
        public IHttpActionResult GetUsuario(string id)
        {
            try { 
                obs = cd_usu.buscarxusu(id);
                ob_usuario[] lisus2 = new ob_usuario[] {

                    new ob_usuario{usu_id=obs.usu_id,cli_id=obs.cli_id,tus_id=obs.tus_id,usu_usu=obs.usu_usu,usu_pass=obs.usu_pass}

                };
                return Ok(lisus2);
            }
            catch (Exception)
            {
                HttpResponseMessage mensaje =new HttpResponseMessage();
                return Ok(mensaje);
            }

        }

        
        //insertar
        public IHttpActionResult Post(string lol)
        {
            try
            {
                obs = cd_usu.buscarxusu(lol);
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


        //actualizar
        public IHttpActionResult Put(string lol)
        {
            try
            {
                obs = cd_usu.buscarxusu(lol);
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


        //eliminar
        public IHttpActionResult Delete(string lol)
        {
            try
            {
                obs = cd_usu.buscarxusu(lol);
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
    }
}
