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
    public class cn_pelicula
    {
        private cd_pelicula cdpe= new cd_pelicula();
        private List<ob_pelicula> listape = new List<ob_pelicula>();

        public List<ob_pelicula> Todos_pelicula()
        {
            listape.Clear();
            DataTable dt = cdpe.
                mostrar_pelicula();
            foreach (DataRow dr in dt.Rows)
            {
                ob_pelicula pelicula = new ob_pelicula();
                pelicula.pel_id = Convert.ToInt32(dr["pel_id"].ToString());
                pelicula.pel_nom = dr["pel_nom"].ToString();
                pelicula.pel_pro = dr["pel_pro"].ToString();
                pelicula.pel_dire = dr["pel_dire"].ToString();
                pelicula.pel_cla= dr["pel_cla"].ToString();
                pelicula.pel_est = dr["pel_est"].ToString();
                pelicula.pel_linkv = dr["pel_linkv"].ToString();
                pelicula.pel_linkba = dr["pel_linkba"].ToString();
                listape.Add(pelicula);
            }
            return listape;
        }
        public List<ob_pelicula> buscarxpelicula(string peli)
        {

            listape.Clear();
            DataTable dt = cdpe.buscarxpelicula(peli);
            foreach (DataRow dr in dt.Rows)
            {
                ob_pelicula pelicula = new ob_pelicula();
                pelicula.pel_id = Convert.ToInt32(dr["pel_id"].ToString());
                pelicula.pel_nom = dr["pel_nom"].ToString();
                pelicula.pel_pro = dr["pel_pro"].ToString();
                pelicula.pel_dire = dr["pel_dire"].ToString();
                pelicula.pel_cla = dr["pel_cla"].ToString();
                pelicula.pel_est = dr["pel_est"].ToString();
                pelicula.pel_linkv = dr["pel_linkv"].ToString();
                pelicula.pel_linkba = dr["pel_linkba"].ToString();
                listape.Add(pelicula);
            }
            return listape;
        }
        public void nuevo_pelicula(string pel_nom, string pel_pro, string pel_dire, string pel_cla,string pel_est,string pel_linkv, string pel_linkba)
        {
            cdpe.nuevo_pelicula( pel_nom, pel_pro, pel_dire, pel_cla,pel_est, pel_linkv, pel_linkba);
        }

        public void actualizar_pelicula(int id, string pel_nom, string pel_pro,string est ,string pel_dire, string pel_cla, string pel_linkv, string pel_linkba)
        {
            cdpe.actualizar_pelicula(id, pel_nom, pel_pro, pel_dire,est, pel_cla, pel_linkv, pel_linkba);
        }

        public void eliminar_pelicula(int id)
        {
            cdpe.eliminar_pelicula(id);
        }
    }
}
