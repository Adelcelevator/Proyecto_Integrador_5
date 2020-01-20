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
    public class GeneroController : ApiController
    {
        private cn_genero cn_gen = new cn_genero();
        private ob_genero obs = new ob_genero();
        public IEnumerable<ob_genero> GetAllGeneros()
        {
            List<ob_genero> lisgen = cn_gen.Todos_genero();
            return lisgen;
        }
        // metodo de ingreso
        public IHttpActionResult GetGeneros(string gen_id)
        {
            try
            {
                obs = cn_gen.buscarxgenero(gen_id);
                ob_genero[] lisgen2 = new ob_genero[] {

                    new ob_genero{gen_id=obs.gen_id,gen_nom=obs.gen_nom}

                };
                return Ok(lisgen2);
            }
            catch (Exception)
            {
                HttpResponseMessage mensaje = new HttpResponseMessage();
                return Ok(mensaje);
            }

        }


        //insertar
        [HttpPost]
        public void Post(int gen_id, string gen_nom)
        {
            cn_gen.nuevo_genero(gen_id, gen_nom);
        }


        //actualizar
        [HttpPut]
        public void Put(int gen_id, string gen_nom)
        {
            cn_gen.actualizar_genero(gen_id, gen_nom);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int gen_id)
        {
            cn_gen.eliminar_genero(gen_id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
