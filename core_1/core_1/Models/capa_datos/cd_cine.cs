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
    public class cd_cine
    {
        cd_conexion conexion = new cd_conexion();
        public ob_cine obci = new ob_cine();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_cine()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_cine";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public DataTable buscar_cine(string cine)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_cine_x_cine";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cine", cine);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrar_conexion();
            return tabla;

        }

        public void eliminar_cine(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_Cine";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cin_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_cine(int cin_id, string cin_nom, string cin_est)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_cine";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cin_id", cin_id);
            comando.Parameters.AddWithValue("@cin_nom", cin_nom);
            comando.Parameters.AddWithValue("@cin_est", cin_est);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public bool nuevo_cine(string cin_nom)
        {
            try
            {
                comando.Connection = conexion.abrir_conexion();
                comando.CommandText = "crear_editar_cine";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("cin_id", 0);
                comando.Parameters.AddWithValue("@cin_nom", cin_nom);
                comando.Parameters.AddWithValue("@cin_est", "Activo");
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.cerrar_conexion();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
