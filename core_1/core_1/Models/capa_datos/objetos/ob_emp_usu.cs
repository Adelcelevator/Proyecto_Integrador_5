using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace core_1.Models.capa_datos.objetos
{
    public class ob_emp_usu
    {
        public Int32 usu_id { get; set; }
        public int emp_id { get; set; }
        public int tip_emp { get; set; }
        public int cin_id { get; set; }
        public string emp_usu { get; set; }
        public string emp_us_contra { get; set; }
        public string usu_emp_est { get; set; }
        public ob_emp_usu()
        {
        }

    }
}