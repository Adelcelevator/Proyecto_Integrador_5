using capa_datos.objetos;
using core_1.Models.capa_datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos
{
   public class cd_gpeli
    {

        cd_conexion conexion = new cd_conexion();
        public ob_gpeli obusu = new ob_gpeli();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_gpelis()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_todo_genypel";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_gpeli buscarxgpeli(string gpel)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_gpeli_x_gpeli";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@gen_id", gpel);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow usu = tabla.Rows[0];
                    obusu.gen_id = Convert.ToInt32(usu["ID Genero"].ToString());
                    obusu.pel_id = Convert.ToInt32(usu["ID Pelicula"].ToString());
                    conexion.cerrar_conexion();
                    return obusu;
                }
                return obusu;
            }
            catch (Exception)
            {
                obusu.gen_id = 0;
                return obusu;
            }

        }

        public ob_gpeli mostrar_todo_gpeli(string gpel)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_gepli";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow usu = tabla.Rows[0];
            obusu.gen_id = Convert.ToInt32(usu["ID Genero"].ToString());
            obusu.pel_id = Convert.ToInt32(usu["ID Pelicula"].ToString());
            conexion.cerrar_conexion();
            return obusu;
        }

        public void eliminar_gpeli(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_gpeli";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("gen_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_gpeli(int id, int pel_id )
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_gpeli";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("gen_id", id);
            comando.Parameters.AddWithValue("@pel_id", pel_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_gpeli(int pel_id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_gpeli";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("gen_id", 0);
            comando.Parameters.AddWithValue("@pel_id", pel_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }
    }
}
