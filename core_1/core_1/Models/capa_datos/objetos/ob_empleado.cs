using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace core_1.Models.capa_datos.objetos
{
    public class ob_empleado
    {
        public Int32 emp_id { get; set; }
        public string emp_nom { get; set; }
        public string emp_ape { get; set; }
        public string emp_fnac { get; set; }
        public string emp_freg { get; set; }
        public string emp_dire { get; set; }
        public string emp_tele { get; set; }
        public string emp_cel { get; set; }
        public string emp_ci { get; set; }
        public string emp_est { get; set; }

        public ob_empleado()
        {
        }
    }
}