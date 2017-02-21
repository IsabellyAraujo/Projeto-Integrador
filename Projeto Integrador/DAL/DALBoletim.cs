using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.DAL
{
    public class DALBoletim
    {
        string connectionString = "";

        public DALBoletim()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo3ConnectionString"].ConnectionString;
        }
        //[DataObjectMethod(DataObjectMethodType.Insert)]
        //public void Insert(Modelo.Anotacao obj)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand("Insert ", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@titulo", obj.titulo);
        //    cmd.Parameters.AddWithValue("@descricao", obj.descricao);
        //    cmd.Parameters.AddWithValue("@favorito", obj.favorito);
        //    cmd.Parameters.AddWithValue("@usuario_id", obj.usuario_id);

        //    cmd.ExecuteNonQuery();
        }
    }
