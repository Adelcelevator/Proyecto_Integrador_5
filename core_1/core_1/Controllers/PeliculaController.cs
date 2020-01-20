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
    public class PeliculaController : ApiController
    {
        private cn_pelicula cn_pel = new cn_pelicula();
        private ob_pelicula obs = new ob_pelicula();
        public IEnumerable<ob_pelicula> GetAllPelicula()
        {
            List<ob_pelicula> lispe = cn_pel.Todos_pelicula();
            return lispe;
        }
        // metodo de ingreso
        public IHttpActionResult GetPelicula(string pel_id)
        {
            try
            {
                List<ob_pelicula> lispe = cn_pel.buscarxpelicula(pel_id);
                return Ok(lispe);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }


        //insertar
        [HttpPost]
        public IHttpActionResult nueva_pel(string pel_nom, string pel_pro, string pel_dire, string pel_cla,string pel_est ,string pel_linkv, string pel_linkba)
        {
            cn_pel.nuevo_pelicula(pel_nom, pel_pro,pel_dire, pel_cla, pel_est, pel_linkv, pel_linkba);
            return Ok();    
        }
            

        //actualizar
        [HttpPut]
        public IHttpActionResult Put(int id, string pel_nom, string pel_pro, string est,string pel_dire, string pel_cla, string pel_linkv, string pel_linkba)
        {
            cn_pel.actualizar_pelicula(id, pel_nom, pel_pro,est, pel_dire, pel_cla, pel_linkv, pel_linkba);
            return Ok();
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_pel.eliminar_pelicula(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
