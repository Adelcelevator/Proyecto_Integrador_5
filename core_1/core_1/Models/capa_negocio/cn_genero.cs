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
    public class cn_genero
    {
        private cd_genero cdgen = new cd_genero();
        private List<ob_genero> listagen = new List<ob_genero>();

        public List<ob_genero> Todos_genero()
        {
            listagen.Clear();
            DataTable dt = cdgen.mostrar_genero();
            foreach (DataRow dr in dt.Rows)
            {
                ob_genero genero = new ob_genero();
                genero.gen_id = Convert.ToInt32(dr["gen_id"].ToString());
                genero.gen_nom = dr["gen_nom"].ToString();
                listagen.Add(genero);
            }
            return listagen;
        }
        public ob_genero buscarxgenero(string nom)
        {

            ob_genero ge = new ob_genero();
            cd_genero cgen = new cd_genero();
            ge = cgen.buscarxgenero(nom);
            if (ge.gen_nom != null)
            {
                return ge;
            }
            else
            {
                ob_genero lbgen = new ob_genero();
                lbgen.gen_id = 0;
                lbgen.gen_nom = null;
                return lbgen;
            }
        }
        public void nuevo_genero(string gen_nom)
        {
            cdgen.nuevo_genero(gen_nom);
        }

        public void actualizar_genero(int gen_id, string gen_nom )
        {
            cdgen.actualizar_genero(gen_id, gen_nom);
        }

        public void eliminar_genero(int gen_id)
        {
            cdgen.eliminar_genero(gen_id);
        }
    }
}
