using capa_datos;
using capa_datos.objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_negocio
{
    public class cn_horario
    {
        private cd_horario cdhor = new cd_horario();
        private List<ob_horario> listahor = new List<ob_horario>();

        public List<ob_horario> Todos_horarios()
        {
            listahor.Clear();
            DataTable dt = cdhor.mostrar_horarios();
            foreach (DataRow dr in dt.Rows)
            {
                ob_horario horario = new ob_horario();
                horario.hor_id = Convert.ToInt32(dr["ID Horario"].ToString());
                horario.hor_hor = dr["hor_hor"].ToString();
                horario.hor_hor = dr["hor_det"].ToString();
                listahor.Add(horario);
            }
            return listahor;
        }
        public ob_horario buscarxhorario(string hora)
        {

            ob_horario us = new ob_horario();
            cd_horario cda = new cd_horario();
            us = cda.buscarxhorario(hora);
            if (us.hor_hor != null)
            {
                return us;
            }
            else
            {
                ob_horario sinna = new ob_horario();
                sinna.hor_id = 0;
                sinna.hor_hor = null;
                sinna.hor_det = null;
                return sinna;
            }
        }
        public void nuevo_horario( string hor_hor, string hor_det)
        {
            cdhor.nuevo_horario(hor_hor, hor_det);
        }

        public void actualizar_horario(int id, string hor_hor, string hor_det)
        {
            cdhor.actualizar_horario(id, hor_hor, hor_det);
        }

        public void eliminar_horario(int id)
        {
            cdhor.eliminar_horario(id);
        }

    }
}
