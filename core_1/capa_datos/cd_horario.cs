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
   public class cd_horario
    {
        cd_conexion conexion = new cd_conexion();
        public ob_horario obhor = new ob_horario();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_horarios()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_horarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_horario buscarxhorario(string hora)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_horario_x_horario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@horario", hora);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow usu = tabla.Rows[0];
                    obhor.hor_id = Convert.ToInt32(usu["ID Horario"].ToString());
                    obhor.hor_hor = usu["hor_hor"].ToString();
                    obhor.hor_det = usu["hor_det"].ToString();
                    comando.Parameters.Clear();
                    conexion.cerrar_conexion();
                    return obhor;
                }
                return obhor;
            }
            catch (Exception)
            {
                obhor.hor_hor = null;
                return obhor;
            }

        }

        public ob_horario mostrar_todo_horario(string hora)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_horarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow hor = tabla.Rows[0];
            obhor.hor_id = Convert.ToInt32(hor["ID Horario"].ToString());
            obhor.hor_hor = hor["hor_hor"].ToString();
            obhor.hor_det = hor["hor_det"].ToString();
            conexion.cerrar_conexion();
            return obhor;
        }

        public void eliminar_horario(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_horario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("hor_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_horario(int id, string hor_hor, string hor_det)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_horario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("hor_id", id);
            comando.Parameters.AddWithValue("@hor_hor", hor_hor);
            comando.Parameters.AddWithValue("@hor_det", hor_det);
            comando.Parameters.AddWithValue("@estado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_horario(string hor_hor, string hor_det)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_horario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("hor_id", 0);
            comando.Parameters.AddWithValue("@hor_hor", hor_hor);
            comando.Parameters.AddWithValue("@hor_det", hor_det);
            comando.Parameters.AddWithValue("@estado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

    }
}
