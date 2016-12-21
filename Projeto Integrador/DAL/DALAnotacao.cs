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
    public class DALAnotacao
    {
        string connectionString = "";

        public DALAnotacao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo3ConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Anotacao> SelectAll(string user_id)
        {
            Modelo.Anotacao aAnotacao;
            List<Modelo.Anotacao> aListAnotacao = new List<Modelo.Anotacao>();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_listarTodasAnotacoesUsuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario_id", user_id);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aAnotacao = new Modelo.Anotacao(
                        dr.GetString(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetBoolean(3),
                        dr.GetDateTime(4),
                        dr.GetString(5)
                        );
                    aListAnotacao.Add(aAnotacao);
                }
            }

            dr.Close();
            conn.Close();

            return aListAnotacao;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Anotacao SelectOne(string id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_listarUmaAnotacao", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = cmd.ExecuteReader();

            Modelo.Anotacao aAnotacao = new Modelo.Anotacao(
                        dr.GetString(0),
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetBoolean(3),
                        dr.GetDateTime(4),
                        dr.GetString(5)
                        );

            dr.Close();
            conn.Close();

            return aAnotacao;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Anotacao obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_deletarUmaAnotacao", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.id);

            cmd.ExecuteNonQuery();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Anotacao obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_inserirAnotacao", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@titulo", obj.titulo);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@favorito", obj.favorito);
            cmd.Parameters.AddWithValue("@usuario_id", obj.usuario_id);

            cmd.ExecuteNonQuery();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Anotacao obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_editarAnotacao", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@titulo", obj.titulo);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@favorito", obj.favorito);

            cmd.ExecuteNonQuery();
        }
    }
}