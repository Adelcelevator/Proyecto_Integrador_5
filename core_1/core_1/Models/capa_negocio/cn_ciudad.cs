using core_1.Models.capa_datos;
using core_1.Models.capa_datos.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace core_1.Models.capa_negocio
{
    public class cn_ciudad
    {
        List<ob_ciudad> lis = new List<ob_ciudad>();
        ob_ciudad obci = new ob_ciudad();
        cd_ciudad cdci = new cd_ciudad();

        public List<ob_ciudad> tod()
        {
            lis.Clear();
            DataTable tabla = cdci.todas();
            if (tabla.Rows.Count != 0)
            {
                foreach(DataRow dr in tabla.Rows)
                {
                    ob_ciudad nuevo = new ob_ciudad();
                    nuevo.ciu_id = Convert.ToInt16(dr["ciu_id"].ToString());
                    nuevo.ciu_nom = dr["ciu_nom"].ToString();
                    nuevo.ciu_est = dr["ciu_est"].ToString();
                    lis.Add(nuevo);
                }
                return lis;
            }
            else
            {
                return lis;
            }
        }
    }
}