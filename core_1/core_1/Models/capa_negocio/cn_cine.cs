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
        private ob_cine cine = new ob_cine();

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
       
        public ob_cine buscado(string nom)
        {
            DataTable tas = cdcin.buscar_cine(nom);
            if (tas.Rows.Count != 0)
            {
                DataRow dr = tas.Rows[0];
                cine.cin_id = Convert.ToInt32(dr["cin_id"].ToString());
                cine.cin_nom = dr["cin_nom"].ToString();
                cine.cin_est = dr["cin_est"].ToString();
                return cine;
            }
            else
            {
                return cine;
            }
        }

        public bool nuevo(string nom)
        {
            if(cdcin.nuevo_cine(nom).Equals(true))
            {
                return true;
            }
            else
            {
                return false;
            }
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
