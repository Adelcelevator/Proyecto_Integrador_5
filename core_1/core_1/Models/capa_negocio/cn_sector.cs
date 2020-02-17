using core_1.Models.capa_datos.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using core_1.Models.capa_datos;

namespace core_1.Models.capa_negocio
{
    public class cn_sector
    {
        ob_sector obsec = new ob_sector();
        List<ob_sector> lissec = new List<ob_sector>();
        cd_sector cdsec = new cd_sector();

        public List<ob_sector> tod()
        {
            lissec.Clear();
            DataTable tabl = cdsec.todas();
            foreach (DataRow dr in tabl.Rows)
            {
                obsec.sec_id = Convert.ToInt16(dr["sec_id"].ToString());
                obsec.ciu_id = Convert.ToInt16(dr["ciu_id"].ToString());
                obsec.sec_nom = dr["sec_nom"].ToString();
                obsec.sec_est = dr["sec_est"].ToString();
                lissec.Add(obsec);
            }
            return lissec;
        }


        public ob_sector secto(string nom)
        {
            DataTable tab = cdsec.sector(nom);
            if (tab.Rows.Count != 0)
            {
                DataRow drt = tab.Rows[0];
                obsec.sec_id = Convert.ToInt16(drt["sec_id"].ToString());
                obsec.ciu_id = Convert.ToInt16(drt["ciu_id"].ToString());
                obsec.sec_nom = drt["sec_nom"].ToString();
                obsec.sec_est = drt["sec_est"].ToString();
                return obsec;
            }
            else
            {
                return obsec;
            }
        }
    }
}