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
            DataTable dt = new DataTable();
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
            return us;
        }
        public void nuevo_usuario(int id,int clid,int tus,string usu,string contra)
        {

        }

        public void actualizar_usuario(int id,int tus_id,string usu_usu,string usu_pass)
        {

        }

        public void eliminar_usuario(int id)
        {

        }

    }
}
