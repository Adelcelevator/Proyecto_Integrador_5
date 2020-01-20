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
    public class SalaController : ApiController
    {
        private cn_sala cn_sa = new cn_sala();
        private ob_sala obsa = new ob_sala();
        public IEnumerable<ob_sala> GetAllUsuarios()
        {
            List<ob_sala> lisa = cn_sa.Todos_sala();
            return lisa;
        }
        // metodo de ingreso
        public IHttpActionResult GetSala(string sal_id)
        {
            try
            {
                obsa = cn_sa.buscarxsala(sal_id);
                ob_sala[] lisa2 = new ob_sala[] {

                    new ob_sala{sal_id=obsa.sal_id, sal_nom=obsa.sal_nom, sal_cap=obsa.sal_cap}

                };
                return Ok(lisa2);
            }
            catch (Exception)
            {
                HttpResponseMessage mensaje = new HttpResponseMessage();
                return Ok(mensaje);
            }

        }


        //insertar
        [HttpPost]
        public void Post( string sal_nom, int sal_cap)
        {
            cn_sa.nuevo_sala(sal_nom, sal_cap);
        }


        //actualizar
        [HttpPut]
        public void Put(int id, string sal_nom, int sal_cap)
        {
            cn_sa.actualizar_sala(id, sal_nom, sal_cap);
        }


        //eliminar
        [HttpDelete]
        public IHttpActionResult DELETE(int id)
        {
            cn_sa.eliminar_sala(id);
            HttpResponseMessage respuesta = new HttpResponseMessage();
            return Ok(respuesta);
        }
    }
}
