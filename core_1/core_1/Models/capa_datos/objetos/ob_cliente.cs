using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos.objetos
{
    public class ob_cliente
    {
        public Int32 cli_id { get; set; }
        public string cli_ruc { get; set; }
        public string cli_nom { get; set; }
        public string cli_ape { get; set; }
        public string cli_dire { get; set; }
        public string cli_tel { get; set; }
        public string cli_corr { get; set; }
        public string cli_fnaci { get; set; }
        public string cli_est { get; set; }

        public ob_cliente()
        {
        }
    }
}
