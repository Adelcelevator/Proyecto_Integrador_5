
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using capa_datos;
using capa_datos.objetos;

namespace capa_negocio
{
    public class cn_tipo_usuario
    {
        private cd_tipo_usuario tipos = new cd_tipo_usuario();
        /*private List<ob_tipo> listatipo = new List<ob_tipo>();
        */
        private List<ob_tipo> listatipo = new List<ob_tipo>();

        public List<ob_tipo> Todos_tipos_usu()
        {
            listatipo.Clear();
            DataTable tip = tipos.mostrar_tipos_usu();
            //DataTable tip = tipos.mostrar_usuarios();
            foreach (DataRow tp in tip.Rows)
            {
                ob_tipo descrip = new ob_tipo();
                descrip.tus_id = Convert.ToInt32(tp["ID TIPO"].ToString());
                descrip.tus_desc = tp["Descripcion"].ToString();
                listatipo.Add(descrip);
            }
            return listatipo;
        }


        /* public ob_usuario buscarxusu(string usa)
{

    ob_usuario us = new ob_usuario();
    cd_usuario cda = new cd_usuario();
    us = cda.buscarxusu(usa);
    if (us.usu_usu != null)
    {
        return us;
    }
    else
    {
        ob_usuario sinna = new ob_usuario();
        sinna.cli_id = 0;
        sinna.usu_id = 0;
        sinna.tus_id = 0;
        sinna.usu_pass = null;
        sinna.usu_pass = null;
        return sinna;
    }
}*/

        public void nuevo_tipo_usu(string desc)
        {
            tipos.nuevo_tipo_usuario(desc);
        }

        /*public void actualizar_usuario(int id, int cli_id, int tus_id, string usu_usu, string usu_pass)
        {
            cdusu.actualizar_usuario(id, cli_id, tus_id, usu_usu, usu_pass);
        }*/

        public void eliminar_tipo_usu(int tusid)
        {
            tipos.eliminar_tipo_usu(tusid);
        }

    }
}
