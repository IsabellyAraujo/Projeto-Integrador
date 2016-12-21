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
    public class DALSala
    {
        string connectionString = "";

        public DALSala()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo3ConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Sala> SelectAll()
        {
            Modelo.Sala aSala;
            List<Modelo.Sala> aListSala = new List<Modelo.Sala>();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_listarTodasSalas", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aSala = new Modelo.Sala(
                        dr.GetInt32(0),
                        dr.GetString(1),
                        dr.GetString(2)
                        );
                    aListSala.Add(aSala);
                }
            }

            dr.Close();
            conn.Close();

            return aListSala;
        }

        public bool ProcurarSala(Modelo.Sala obj)
        {
            bool existe = false;
            List<Modelo.Sala> Salas = SelectAll();
            foreach (Modelo.Sala sala in Salas)
            {
                if (sala.descricao == obj.descricao && sala.senha == obj.senha) existe = true;
            }
            return existe;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Sala obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_deletarSala", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.id);

            cmd.ExecuteNonQuery();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Sala obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_inserirSala", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@senha", obj.senha);

            cmd.ExecuteNonQuery();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Sala obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_editarSala", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@senha", obj.senha);

            cmd.ExecuteNonQuery();
        }
    }
}