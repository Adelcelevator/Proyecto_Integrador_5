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
    public class cd_genero
    {
        cd_conexion conexion = new cd_conexion();
        public ob_genero obgen = new ob_genero();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_genero()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_generos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_genero buscarxgenero(string gen_nom)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_nombre_x_genero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@genero", gen_nom);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow gene = tabla.Rows[0];
                    obgen.gen_id = Convert.ToInt32(gene["ID Genero"].ToString());
                    obgen.gen_nom = gene["Genero"].ToString();
                    comando.Parameters.Clear();
                    conexion.cerrar_conexion();
                    return obgen;
                }
                return obgen;
            }
            catch (Exception)
            {
                obgen.gen_nom = null;
                return obgen;
            }

        }

        public ob_genero mostrar_todo_genero(string gen_nom)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_generos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow gene = tabla.Rows[0];
            obgen.gen_id = Convert.ToInt32(gene["ID Genero"].ToString());
            obgen.gen_nom = gene["Genero"].ToString();
            conexion.cerrar_conexion();
            return obgen;
        }

        public void eliminar_genero(int gen_id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_genero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("gen_id", gen_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_genero(int gen_id, string gen_nom)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_genero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("gen_id", gen_id);    
            comando.Parameters.AddWithValue("@gen_nom", gen_nom);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_genero(string gen_nom)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_genero";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@gen_id", 0);
            comando.Parameters.AddWithValue("@gen_nom",gen_nom);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }
    }
}
