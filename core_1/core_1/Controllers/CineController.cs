﻿using capa_datos.objetos;
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
 
    //insertar
    [HttpPost]
    public IHttpActionResult Post(string cin_nom)
    {
            cn_cin.nuevo_cine(cin_nom);
            return Ok();
        }


    //actualizar
    [HttpPut]
    public void Put(int cin_id, string cin_nom,string cin_est)
    {
            cn_cin.actualizar_cine(cin_id,cin_nom,cin_est);
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