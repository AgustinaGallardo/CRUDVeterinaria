using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CRUDveterinaria.Dominio;

namespace CRUDveterinaria.Datos
{
    internal class Helper
    {
        SqlConnection cnn = new SqlConnection(Properties.Resources.cnnCrudVet);
        private static Helper instancia;

        public static Helper ObtenerInstancia()
        {
            if(instancia == null)
                instancia = new Helper();
            return instancia;
        }
        public int ObtenerProximo(string sp_nombre,string OutPut)
        {
            cnn.Open();
            SqlCommand cmdNext = new SqlCommand();
            cmdNext.CommandText = sp_nombre;
            cmdNext.CommandType = CommandType.StoredProcedure;
            cmdNext.Connection = cnn;

            SqlParameter pOutPut = new SqlParameter();
            pOutPut.ParameterName = OutPut;
            pOutPut.Direction = ParameterDirection.Output;
            pOutPut.DbType = DbType.Int32;
            cmdNext.Parameters.Add(pOutPut);

            cmdNext.ExecuteNonQuery();
            cnn.Close();

            return (int)pOutPut.Value;
        }
        public DataTable CargarCombo(string sp_nombre)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmdCombo = new SqlCommand();
            cmdCombo.CommandText = sp_nombre;
            cmdCombo.CommandType = CommandType.StoredProcedure;
            cmdCombo.Connection = cnn;

            tabla.Load(cmdCombo.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public bool ConfirmarMascota(Mascota oMascota)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                SqlCommand cmdMestro = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();

                cmdMestro.Transaction = t;
                cmdMestro.Connection = cnn;
                cmdMestro.CommandText = "sp_insertMascota";
                cmdMestro.CommandType = CommandType.StoredProcedure;
               

                cmdMestro.Parameters.AddWithValue("@nombre", oMascota.Nombre);
                cmdMestro.Parameters.AddWithValue("@edad", oMascota.Edad);
                cmdMestro.Parameters.AddWithValue("@id_tipo", oMascota.Tipo.IdTipo);
                cmdMestro.Parameters.AddWithValue("@id_cliente", oMascota.Cliente.IdCliente);

                SqlParameter OutPut = new SqlParameter();
                OutPut.ParameterName= "@id_mascota";
                OutPut.DbType = DbType.Int32;
                OutPut.Direction= ParameterDirection.Output;

                cmdMestro.Parameters.Add(OutPut);

                cmdMestro.ExecuteNonQuery();

                int idMascota = (int)OutPut.Value;

                foreach (Atencion a in oMascota.Atenciones)
                {
                    SqlCommand cmdDetalle = new SqlCommand();

                    cmdDetalle.Connection = cnn;
                    cmdDetalle.Transaction = t;
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.CommandText = "sp_insertAtencion";

                    cmdDetalle.Parameters.AddWithValue("@fecha", a.Fecha);
                    cmdDetalle.Parameters.AddWithValue("@descripcion", a.Descripcion);
                    cmdDetalle.Parameters.AddWithValue("@importe", a.Importe);
                    cmdDetalle.Parameters.AddWithValue("@id_mascota", idMascota);

                    cmdDetalle.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception)
            {
                if (t != null)
                {
                    t.Rollback();
                    ok= false;
                }
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return ok;
        }
    }
}
