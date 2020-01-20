using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capa_datos;
using System.Data;
using capa_datos.objetos;

namespace capa_negocio
{
   public class cn_sala
    {
        private cd_sala cdsal = new cd_sala();
        private List<ob_sala> listasl = new List<ob_sala>();

        public List<ob_sala> Todos_sala()
        {
            listasl.Clear();
            DataTable dt = cdsal.mostrar_salas();
            foreach (DataRow dr in dt.Rows)
            {
                ob_sala sala = new ob_sala();
                sala.sal_id = Convert.ToInt32(dr["ID Sala"].ToString());
                sala.sal_nom = dr["Sala"].ToString();
                sala.sal_cap = Convert.ToInt32(dr["Capacidad"].ToString());
                listasl.Add(sala);
            }
            return listasl;
        }
        public ob_sala buscarxsala(string sal)
        {

            ob_sala sl = new ob_sala();
            cd_sala cds = new cd_sala();
            sl = cds.buscarxsala(sal);
            if (sl.sal_nom != null)
            {
                return sl;
            }
            else
            {
                ob_sala ssla = new ob_sala();
                ssla.sal_id = 0;
                ssla.sal_nom = null;
                ssla.sal_cap = 0;
                return ssla;
            }
        }
        public void nuevo_sala( string sal_nom, int sal_cap)
        {
            cdsal.nuevo_sala( sal_nom, sal_cap);
        }

        public void actualizar_sala(int id, string sal_nom, int sal_cap)
        {
            cdsal.actualizar_sala(id, sal_nom, sal_cap);
        }

        public void eliminar_sala(int id)
        {
            cdsal.eliminar_sala(id);
        }

    }
}
