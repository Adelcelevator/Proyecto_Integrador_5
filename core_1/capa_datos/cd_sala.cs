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
    public class cd_sala
    {
        cd_conexion conexion = new cd_conexion();
        public ob_sala obsal = new ob_sala();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_salas()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_salas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_sala buscarxsala(string sal)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_sala_x_sala";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@sala", sal);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow sl = tabla.Rows[0];
                    obsal.sal_id = Convert.ToInt32(sl["ID Sala"].ToString());
                    obsal.sal_nom = sl["Sala"].ToString();
                    obsal.sal_cap = Convert.ToInt32(sl["Capacidad"].ToString());
                    comando.Parameters.Clear();
                    conexion.cerrar_conexion();
                    return obsal;
                }
                return obsal;
            }
            catch (Exception)
            {
                obsal.sal_nom = null;
                return obsal;
            }

        }

        public ob_sala mostrar_todo_sala(string sal)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_salas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow sa = tabla.Rows[0];
            obsal.sal_id = Convert.ToInt32(sa["ID Sala"].ToString());
            obsal.sal_nom = sa["Sala"].ToString();
            obsal.sal_cap = Convert.ToInt32(sa["Capacidad"].ToString());
            conexion.cerrar_conexion();
            return obsal;
        }

        public void eliminar_sala(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_sala";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("sal_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_sala(int id, string sal_nom, int sal_cap)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_sala";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("sal_id", id);
            comando.Parameters.AddWithValue("@sal_nom", sal_nom);
            comando.Parameters.AddWithValue("@sal_cap", sal_cap);
            comando.Parameters.AddWithValue("@estado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_sala(string sal_nom, int sal_cap)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_sala";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("sal_id", 0);
            comando.Parameters.AddWithValue("@sal_nom", sal_nom);
            comando.Parameters.AddWithValue("@sal_cap", sal_cap);
            comando.Parameters.AddWithValue("@estado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }
    }
}
