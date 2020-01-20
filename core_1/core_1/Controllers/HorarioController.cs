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
    public class HorarioController : ApiController
    {
        private cn_horario cn_hor = new cn_horario();
        private ob_horario obs = new ob_horario();
        public IEnumerable<ob_horario> GetAllHorarios()
        {
            List<ob_horario> lisus = cn_hor.Todos_horarios();
            return lisus;
        }
        // metodo de ingreso
        public IHttpActionResult GetHorario(string hor_id)
        {
            try
            {
                obs = cn_hor.buscarxhorario(hor_id);
                ob_horario[] lisus2 = new ob_horario[] {

                    new ob_horario{hor_id=obs.hor_id,hor_hor=obs.hor_hor,hor_det=obs.hor_det}

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
        public void Post( string hor_hor, string hor_det)
        {
            cn_hor.nuevo_horario(hor_hor, hor_det);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, string hor_hor, string hor_det)
        {
            cn_hor.actualizar_horario(id, hor_hor, hor_det);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_hor.eliminar_horario(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
