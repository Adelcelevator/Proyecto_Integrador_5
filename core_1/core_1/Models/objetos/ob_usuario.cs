using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace core_1.Models.objetos
{
    public class ob_usuario
    {
        public Int32 usu_id { get; set; }
        public int cli_id { get; set; }
        public int tus_id { get; set; }
        public string usu_usu { get; set; }
        public string usu_pass { get; set; }
        public string datop { get; set; }
        public ob_usuario()
        {
        }

    }
}