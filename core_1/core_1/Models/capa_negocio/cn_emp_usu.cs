using core_1.Models.capa_datos;
using core_1.Models.capa_datos.objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace core_1.Models.capa_negocio
{
    public class cn_emp_usu
    {
        private cd_emp_usu emple = new cd_emp_usu();
        private List<ob_emp_usu> listsa = new List<ob_emp_usu>();
        private ob_emp_usu emp = new ob_emp_usu();

        public List<ob_emp_usu> todos()
        {
            listsa.Clear();
            DataTable tabl = emple.todos();
            foreach (DataRow dr in tabl.Rows)
            {
                ob_emp_usu nuevo = new ob_emp_usu();
                nuevo.usu_id = Convert.ToInt32(dr["usu_id"].ToString());
                nuevo.emp_id = Convert.ToInt32(dr["emp_id"].ToString());
                nuevo.tip_emp = Convert.ToInt32(dr["tip_emp"].ToString());
                nuevo.cin_id = Convert.ToInt32(dr["cin_id"].ToString());
                nuevo.emp_usu = dr["emp_usu"].ToString();
                nuevo.emp_us_contra = dr["emp_us_contra"].ToString();
                nuevo.usu_emp_est = dr["usu_emp_est"].ToString();
                listsa.Add(nuevo);
            }
            return listsa;
        }

        public ob_emp_usu busq(string usu_emp)
        {
            DataTable tablas = emple.busque(usu_emp);
            foreach (DataRow dr in tablas.Rows)
            {
                emp.usu_id = Convert.ToInt16(dr["usu_id"].ToString());
                emp.cin_id = Convert.ToInt16(dr["cin_id"].ToString());
                emp.emp_id = Convert.ToInt16(dr["emp_id"].ToString());
                emp.tip_emp = Convert.ToInt16(dr["tip_emp"].ToString());
                emp.emp_usu = dr["emp_usu"].ToString();
                emp.emp_us_contra = dr["emp_us_contra"].ToString();
                emp.usu_emp_est = dr["usu_emp_est"].ToString();
            }
            return emp;
        }
    }
}