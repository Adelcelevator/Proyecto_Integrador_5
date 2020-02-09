using core_1.Models.capa_datos;
using core_1.Models.capa_datos.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace core_1.Models.capa_negocio
{
    public class cn_empleado
    {
        cd_empleado empe = new cd_empleado();
        List<ob_empleado> lista = new List<ob_empleado>();


        public List<ob_empleado> tods()
        {
            lista.Clear();
            DataTable tabla = empe.mostrar_empleado();
            foreach (DataRow dr in tabla.Rows)
            {
                ob_empleado nuevo = new ob_empleado();
                nuevo.emp_ci = dr["emp_ci"].ToString();
                nuevo.emp_id = Convert.ToInt16(dr["emp_id"].ToString());
                nuevo.emp_tele = dr["emp_tele"].ToString();
                nuevo.emp_nom = dr["emp_nom"].ToString();
                nuevo.emp_ape = dr["emp_ape"].ToString();
                nuevo.emp_cel = dr["emp_cel"].ToString();
                nuevo.emp_fnac = dr["emp_fnac"].ToString();
                nuevo.emp_freg = dr["emp_freg"].ToString();
                nuevo.emp_est = dr["emp_est"].ToString();
                nuevo.emp_dire = dr["emp_dire"].ToString();
                lista.Add(nuevo);
            }
            return lista;
        }
        public Boolean nuevo(string ci, string nombre, string ape, string naci, string dire, string tele, string cel)
        {
            bool respuesta = empe.nuevo_emplea(ci,nombre,ape,naci,dire,tele,cel);
            if (respuesta.Equals(true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}