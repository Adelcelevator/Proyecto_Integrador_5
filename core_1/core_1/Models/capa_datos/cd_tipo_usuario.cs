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
   public class cd_tipo_usuario
    {

        cd_conexion conexion = new cd_conexion();
        public ob_tipo tipo = new ob_tipo();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
  
        public DataTable mostrar_tipos_usu()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_tipos_usuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrar_conexion();
            return tabla;
        }
        
        public void eliminar_tipo_usu(int tusid)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_tipo_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tusid", tusid);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_tipo_usuario(string desc)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_tipo_usuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tusid", 0);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }
        /*public DataTable mostrar_tipo_usuario()
       {
           DataTable tabla1 = new DataTable();
           comando.Connection = conexion.abrir_conexion();
           comando.CommandText = "mostrar_tipo";
           comando.CommandType = CommandType.StoredProcedure;
           leer = comando.ExecuteReader();
           tabla1.Load(leer);
           comando.Parameters.Clear();
           conexion.cerrar_conexion();
           return tabla1;
       }*/

        /* public ob_tipo buscartipo(string des)
         {
             DataTable tabla = new DataTable();
             comando.Connection = conexion.abrir_conexion();
             comando.CommandText = "mostrar_usuario_x_usuario";
             comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("@usuario", usua);
             leer = comando.ExecuteReader();
             tabla.Load(leer);
             try
             {
                 if (tabla.Rows[0] != null)
                 {
                     DataRow usu = tabla.Rows[0];
                     obusu.usu_id = Convert.ToInt32(usu["ID Usuario"].ToString());
                     obusu.cli_id = Convert.ToInt32(usu["ID Cliente"].ToString());
                     obusu.tus_id = Convert.ToInt32(usu["Tipo Usuario"].ToString());
                     obusu.usu_usu = usu["Usuario"].ToString();
                     obusu.usu_pass = usu["Password"].ToString();
                     comando.Parameters.Clear();
                     conexion.cerrar_conexion();
                     return obusu;
                 }
                 return obusu;
             }
             catch (Exception)
             {
                 obusu.usu_usu = null;
                 return obusu;
             }

         }*/
        /*public void actualizar_usuario(int id, int cli_id, int tus_id, string usu_usu, string usu_pass)
       {
           comando.Connection = conexion.abrir_conexion();
           comando.CommandText = "crear_editar_usuario";
           comando.CommandType = CommandType.StoredProcedure;
           comando.Parameters.AddWithValue("usu_id", id);
           comando.Parameters.AddWithValue("@cli_id", cli_id);
           comando.Parameters.AddWithValue("@tus_id", tus_id);
           comando.Parameters.AddWithValue("@usuario", usu_usu);
           comando.Parameters.AddWithValue("@contra", usu_pass);
           comando.Parameters.AddWithValue("@estado", "a");
           comando.ExecuteNonQuery();
           comando.Parameters.Clear();
           conexion.cerrar_conexion();
       }*/
    }
}
