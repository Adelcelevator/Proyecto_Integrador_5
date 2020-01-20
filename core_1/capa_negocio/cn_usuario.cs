using core_1.Models.capa_datos;
using core_1.Models.objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace capa_negocio
{
    public class cn_usuario
    {
        private cd_usuario cdusu = new cd_usuario();
        private List<ob_usuario> listausu = new List<ob_usuario>();

        public List<ob_usuario> Todos_usuarios()
        {   
            listausu.Clear();
            DataTable dt = cdusu.mostrar_usuarios();
            foreach (DataRow dr in dt.Rows)
            {
                ob_usuario usuario = new ob_usuario();
                usuario.usu_id = Convert.ToInt32(dr["ID Usuario"].ToString());
                usuario.cli_id = Convert.ToInt32(dr["ID Cliente"].ToString());
                usuario.tus_id = Convert.ToInt32(dr["Tipo Usuario"].ToString());
                usuario.usu_usu = dr["Usuario"].ToString();
                usuario.usu_pass = dr["Password"].ToString();
                listausu.Add(usuario);
            }
            return listausu;
        }
        public ob_usuario buscarxusu(string usa)
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
        }
        public void nuevo_usuario(int clid, string usu, string contra)
        {
            cdusu.nuevo_usuario(clid,usu,contra);
        }

        public void actualizar_usuario(int id,int cli_id, int tus_id, string usu_usu, string usu_pass)
        {
            cdusu.actualizar_usuario(id,cli_id,tus_id,usu_usu,usu_pass);
        }

        public void eliminar_usuario(int id)
        {
            cdusu.eliminar_usuario(id);
        }

    }
}
