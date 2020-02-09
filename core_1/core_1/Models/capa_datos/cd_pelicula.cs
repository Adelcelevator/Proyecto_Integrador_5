using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using core_1.Models.capa_datos;
using capa_datos.objetos;

namespace capa_datos
{
    public class cd_pelicula
    {
        cd_conexion conexion = new cd_conexion();
        public ob_pelicula obpe = new ob_pelicula();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_pelicula()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_pelicula";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public DataTable buscarxpelicula(string peli)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_pelicula_x_pelicula";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@pel_nom", peli);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla;
        }

        /*
        public ob_pelicula mostrar_todo_pelicula(string peli)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_peliculas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow pel = tabla.Rows[0];
            obpe.pel_id = Convert.ToInt32(pel["ID Pelicula"].ToString());
            obpe.pel_nom = pel["pel_nom"].ToString();
            obpe.pel_pro = pel["pel_pro"].ToString();
            obpe.pel_dire = pel["pel_dire"].ToString();
            obpe.pel_cla = pel["pel_cla"].ToString();
            obpe.pel_linkv = pel["pel_linkv"].ToString();
            obpe.pel_linkba = pel["pel_linkba"].ToString();
            conexion.cerrar_conexion();
            return obpe;
        }*/

        public void eliminar_pelicula(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_pelicula";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("pel_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_pelicula(int id, string pel_nom, string pel_pro, string pel_dire,string est, string pel_cla, string pel_linkv, string pel_linkba)
        {
                comando.Connection = conexion.abrir_conexion();
                comando.CommandText = "crear_editar_pelicula";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pel_id", id);
                comando.Parameters.AddWithValue("@pel_nom", pel_nom);
                comando.Parameters.AddWithValue("@pel_pro", pel_pro);
                comando.Parameters.AddWithValue("@pel_dire", pel_dire);
                comando.Parameters.AddWithValue("@pel_cla", pel_cla);
                comando.Parameters.AddWithValue("@estado", est);
                comando.Parameters.AddWithValue("@pel_linkv", pel_linkv);
                comando.Parameters.AddWithValue("@pel_linkba", pel_linkba);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.cerrar_conexion();
        }

        public void nuevo_pelicula(string pel_nom, string pel_pro, string pel_dire, string pel_cla, string pel_est, string pel_linkv, string pel_linkba)
        {
            try
            {
                comando.Connection = conexion.abrir_conexion();
                comando.CommandText = "crear_editar_pelicula";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pel_id", 0);
                comando.Parameters.AddWithValue("@pel_nom", pel_nom);
                comando.Parameters.AddWithValue("@pel_pro", pel_pro);
                comando.Parameters.AddWithValue("@pel_dire", pel_dire);
                comando.Parameters.AddWithValue("@pel_cla", pel_cla);
                comando.Parameters.AddWithValue("@estado", pel_est);
                comando.Parameters.AddWithValue("@pel_linkv", pel_linkv);
                comando.Parameters.AddWithValue("@pel_linkba", pel_linkba);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.cerrar_conexion();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("ERROR=====> "+ex);
            }
        }
    }
}
