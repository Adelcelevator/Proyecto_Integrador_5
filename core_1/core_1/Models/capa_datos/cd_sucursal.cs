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
    public class cd_sucursal
    {
        cd_conexion conexion = new cd_conexion();
        public ob_sucursal obsuc = new ob_sucursal();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_sucursal()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_sucursal";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_sucursal buscarxsucursal(string sucu)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_sucursal_x_sucursal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@sucursal", sucu);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow suc = tabla.Rows[0];
                    obsuc.suc_id = Convert.ToInt32(suc["suc_id"].ToString());
                    obsuc.cin_id = Convert.ToInt32(suc["cin_id"].ToString());
                    obsuc.suc_nom = suc["suc_nom"].ToString();
                    obsuc.sec_id = Convert.ToInt32(suc["sec_id"].ToString());
                    obsuc.suc_ruc = suc["suc_ruc"].ToString();
                    obsuc.suc_dir = suc["suc_dir"].ToString();
                    obsuc.suc_tel = suc["suc_tel"].ToString();
                    obsuc.suc_cor = suc["suc_cor"].ToString();
                    obsuc.ciu_id = Convert.ToInt32(suc["suc_ciu"].ToString());
                    comando.Parameters.Clear();
                    conexion.cerrar_conexion();
                    return obsuc;
                }
                return obsuc;
            }
            catch (Exception)
            {
                obsuc.suc_nom = null;
                return obsuc;
            }

        }

        public DataTable buscarxcin(int sucu)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_sucs_x_cine";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@cin_id", sucu);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrar_conexion();
            return tabla;
        }

        public DataTable buscarxsuc(string suc_nom)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_suc_x_suc";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nom_suc", suc_nom);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrar_conexion();
            return tabla;
        }

        public ob_sucursal mostrar_todo_sucursal(string sucu)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_sucursales";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            DataRow suc = tabla.Rows[0];
            obsuc.suc_id = Convert.ToInt32(suc["ID Sucursal"].ToString());
            obsuc.cin_id = Convert.ToInt32(suc["ID Cine"].ToString());
            obsuc.suc_nom = suc["suc_nom"].ToString();
            obsuc.sec_id = Convert.ToInt32(suc["sec_id"].ToString());
            obsuc.suc_ruc = suc["suc_ruc"].ToString();
            obsuc.suc_dir = suc["suc_dir"].ToString();
            obsuc.suc_tel = suc["suc_tel"].ToString();
            obsuc.suc_cor = suc["suc_cor"].ToString();
            obsuc.ciu_id = Convert.ToInt32(suc["suc_ciu"].ToString());
            conexion.cerrar_conexion();
            return obsuc;
        }

        public void eliminar_sucursal(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_sucursal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("suc_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_sucursal(int id,int ciu_id,int sec_id, int cin_id, string suc_nom, string suc_sec, string suc_ruc, string suc_dir, int suc_tel, string suc_cor,string suc_esta)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_sucursal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("suc_id", id);
            comando.Parameters.AddWithValue("@cin_id", cin_id);
            comando.Parameters.AddWithValue("@suc_nom", suc_nom);
            comando.Parameters.AddWithValue("@suc_sec", suc_sec);
            comando.Parameters.AddWithValue("@suc_ruc", suc_ruc);
            comando.Parameters.AddWithValue("@suc_dir", suc_dir);
            comando.Parameters.AddWithValue("@suc_tel", suc_tel);
            comando.Parameters.AddWithValue("@suc_cor", suc_cor);
            comando.Parameters.AddWithValue("@ciu_id", ciu_id);
            comando.Parameters.AddWithValue("@sec_id", sec_id);
            comando.Parameters.AddWithValue("@suc_esta", suc_esta);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public bool nuevo_sucursal(int cin_id, int ciu_id, int sec_id, string suc_nom, string suc_ruc, string suc_dir,string suc_tel, string suc_cor)
        {
            try
            {
                comando.Connection = conexion.abrir_conexion();
                comando.CommandText = "crear_editar_sucursal";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@suc_id", 0);
                comando.Parameters.AddWithValue("@ciu_id", ciu_id);
                comando.Parameters.AddWithValue("@sec_id", sec_id);
                comando.Parameters.AddWithValue("@cin_id", cin_id);
                comando.Parameters.AddWithValue("@suc_nom", suc_nom);
                comando.Parameters.AddWithValue("@suc_ruc", suc_ruc);
                comando.Parameters.AddWithValue("@suc_dir", suc_dir);
                comando.Parameters.AddWithValue("@suc_tel", suc_tel);
                comando.Parameters.AddWithValue("@suc_cor", suc_cor);
                comando.Parameters.AddWithValue("@suc_esta", "activo");
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.cerrar_conexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
