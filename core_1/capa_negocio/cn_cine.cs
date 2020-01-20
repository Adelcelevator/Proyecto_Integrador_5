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
    public class cn_cine
    {
        private cd_cine cdcin = new cd_cine();
        private List<ob_cine> listausu = new List<ob_cine>();

        public List<ob_cine> Todos_cines()
        {
            listausu.Clear();
            DataTable dt = cdcin.mostrar_cine();
            foreach (DataRow dr in dt.Rows)
            {
                ob_cine nombre = new ob_cine();
                nombre.cin_id = Convert.ToInt32(dr["cin_id"].ToString());
                nombre.cin_nom = dr["cin_nom"].ToString();
                nombre.cin_est = dr["cin_est"].ToString();
                listausu.Add(nombre);
            }
            return listausu;
        }
       /* public ob_cine buscar_cine(string nom)
        {

            ob_cine us = new ob_cine();
            cd_cine cda = new cd_cine();
            us = cda.buscar_cine(nom);
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
        */
        public void nuevo_cine(string cin_nom)
        {
            cdcin.nuevo_cine(0, cin_nom);
        }

        public void actualizar_cine(int cin_id, string cin_nom,string cin_est)
        {
            cdcin.actualizar_cine(cin_id, cin_nom,cin_est);
        }

        public void eliminar_cin(int id)
        {
            cdcin.eliminar_cine(id);
        }
    }
}
