
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
   public class cd_hpeli
    {

        cd_conexion conexion = new cd_conexion();
        public ob_hpeli obhp = new ob_hpeli();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_hpelis()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_hpelis";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_hpeli buscarxhpeli(string hpel)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_hpeli_x_hpeli";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@pel_id", hpel);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow hp = tabla.Rows[0];
                    obhp.pel_id = Convert.ToInt32(hp["ID Pelicula"].ToString());
                    obhp.hor_id = Convert.ToInt32(hp["ID Horario"].ToString());
                    conexion.cerrar_conexion();
                    return obhp;
                }
                return obhp;
            }
            catch (Exception)
            {
                obhp.pel_id = 0;
                return obhp;
            }

        }

        public ob_hpeli mostrar_todo_hpeli(string hpel)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_hpeli";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow hp = tabla.Rows[0];
            obhp.pel_id = Convert.ToInt32(hp["ID Pelicula"].ToString());
            obhp.hor_id = Convert.ToInt32(hp["ID Horaraio"].ToString());
            conexion.cerrar_conexion();
            return obhp;
        }

        public void eliminar_hpeli(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_hpeli";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("pel_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_hpeli(int id, int hor_id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_hpeli";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("pel_id", id);
            comando.Parameters.AddWithValue("@hor_id", hor_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_hpeli(int hor_id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_hpeli";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("pel_id", 0);
            comando.Parameters.AddWithValue("@hor_id", hor_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }
    }
}
