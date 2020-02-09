using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using core_1.Models.capa_datos;
using capa_datos.objetos;

namespace capa_datos
{
    public class cd_tiket
    {

        cd_conexion conexion = new cd_conexion();
        public ob_tiket obtik = new ob_tiket();
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;

        public DataTable mostrar_tikets()
        {
            DataTable tabla1 = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_tikets";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla1.Load(leer);
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
            return tabla1;
        }

        public ob_tiket buscarxtiket(string tike)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_tiket_x_tiket";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@tiket", tike);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            try
            {
                if (tabla.Rows[0] != null)
                {
                    DataRow ti = tabla.Rows[0];
                    obtik.tik_id = Convert.ToInt32(ti["ID Tiket"].ToString());
                    obtik.usu_id = Convert.ToInt32(ti["ID USUARIO"].ToString());
                    obtik.pel_id = Convert.ToInt32(ti["ID Pelicula"].ToString());
                    obtik.sal_id = Convert.ToInt32(ti["ID Sala"].ToString());
                    obtik.tpag_id = Convert.ToInt32(ti["ID Tipo_Pago"].ToString());
                    obtik.tar_id = Convert.ToInt32(ti["ID Tarifa"].ToString());
                    obtik.tik_asien = ti["Asiento"].ToString();
                    obtik.tik_fec = ti["Fecha"].ToString();
                    comando.Parameters.Clear();
                    conexion.cerrar_conexion();
                    return obtik;
                }
                return obtik;
            }
            catch (Exception)
            {
                obtik.tik_asien = null;
                return obtik;
            }

        }

        public ob_tiket mostrar_todo_tiket(string tike)
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "mostrar_tiket";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            DataRow ti = tabla.Rows[0];
            obtik.tik_id = Convert.ToInt32(ti["ID Tiket"].ToString());
            obtik.usu_id = Convert.ToInt32(ti["ID USUARIO"].ToString());
            obtik.pel_id = Convert.ToInt32(ti["ID Pelicula"].ToString());
            obtik.sal_id = Convert.ToInt32(ti["ID Sala"].ToString());
            obtik.tpag_id = Convert.ToInt32(ti["ID Tipo_Pago"].ToString());
            obtik.tar_id = Convert.ToInt32(ti["ID Tarifa"].ToString());
            obtik.tik_asien = ti["Asiento"].ToString();
            obtik.tik_fec = ti["Fecha"].ToString();
            conexion.cerrar_conexion();
            return obtik;
        }

        public void eliminar_tiket(int id)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "eliminar_tiket";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tik_id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void actualizar_tiket(int id, int usu_id, int pel_id, int sal_id, int tpag_id, int tar_id, string tik_asien, string tik_fec)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_tiket";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tik_id", id);
            comando.Parameters.AddWithValue("@usu_id", usu_id);
            comando.Parameters.AddWithValue("@pel_id", pel_id);
            comando.Parameters.AddWithValue("@sal_id", sal_id);
            comando.Parameters.AddWithValue("@tpag_id", tpag_id);
            comando.Parameters.AddWithValue("@tar_id", tar_id);
            comando.Parameters.AddWithValue("@tik_asien", tik_asien);
            comando.Parameters.AddWithValue("@tik_fec", tik_fec);
            comando.Parameters.AddWithValue("@estado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }

        public void nuevo_tiket(int usu_id, int pel_id, int sal_id, int tpag_id, int tar_id, string tik_asien, string tik_fec)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "crear_editar_tiket";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("tik_id", 0);
            comando.Parameters.AddWithValue("@usu_id", usu_id);
            comando.Parameters.AddWithValue("@pel_id", pel_id);
            comando.Parameters.AddWithValue("@sal_id", sal_id);
            comando.Parameters.AddWithValue("@tpag_id", tpag_id);
            comando.Parameters.AddWithValue("@tar_id", tar_id);
            comando.Parameters.AddWithValue("@tik_asien", tik_asien);
            comando.Parameters.AddWithValue("@tik_fec", tik_fec);
            comando.Parameters.AddWithValue("@stado", "a");
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.cerrar_conexion();
        }


    }
}
