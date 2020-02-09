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

            [HttpGet]
            public IHttpActionResult obtener(string ruc)
        {
            obs=cn_clie.buscar_cliente(ruc);
            return Ok(obs);
        }

        //insertar
        [HttpPost]
        public IHttpActionResult Post(string ruc, string nom, string ape, string dire, string tel, string corr, string fnaci)
        {
            cn_clie.nuevo_cliente(ruc, nom, ape, dire, tel, corr, fnaci);
            return Ok();
        }


        //actualizar
        [HttpPut]
        public IHttpActionResult Put(int id, string ruc, string nom, string ape, string dire, int tel, string corr, string fnaci, string est)
        {
            cn_clie.actualizar_cliente(id, ruc, nom, ape, dire, tel, corr, fnaci, est);
            return Ok();
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
