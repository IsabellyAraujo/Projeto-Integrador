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
        //Modelo Anotação
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Anotacao> SelectAll(string user_id)
        {
            Modelo.Anotacao aAnotacao;
            List<Modelo.Anotacao> aListAnotacao = new List<Modelo.Anotacao>();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select id, titulo, descricao, favorito, usuario_id from Anotacao where usuario_id = @usuario_id order by favorito desc", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario_id", user_id);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aAnotacao = new Modelo.Anotacao( 
                        Convert.ToInt32(dr["id"]), 
                        dr["titulo"].ToString(), 
                        dr["descricao"].ToString(), 
                        Convert.ToBoolean(dr["favorito"]),
                        dr["usuario_id"].ToString());                    
                    aListAnotacao.Add(aAnotacao);
                }
            }

            dr.Close();
            conn.Close();

            return aListAnotacao;
        }
        //Listar Anotações
        


        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Anotacao SelectOne(string id)
        {
            Modelo.Anotacao aAnotacao = new Modelo.Anotacao();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select id, titulo, descricao from Anotacao where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aAnotacao = new Modelo.Anotacao(
                        Convert.ToInt32(dr["id"]),
                        dr["titulo"].ToString(),
                        dr["descricao"].ToString()
                        );
                }
            }

            dr.Close();
            conn.Close();
            return aAnotacao;
        }

        //favorito
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool SelectValidarFavorito(int id)
        {
            bool validar = true;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("Select favorito FROM Anotacao where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["favorito"]) == 0)
                    {
                        validar = false;
                    }
                }
            }
            dr.Close();
            conn.Close();
            return validar;
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

            //SqlCommand cmd = new SqlCommand("sp_editarAnotacao", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlCommand cmd = new SqlCommand("Update Anotacao set titulo = @titulo and descricao = @descricao and horarioDeEnvio = @horarioDeEnvio where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@titulo", obj.titulo);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);

            cmd.ExecuteNonQuery();
        }



        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateFavorito(int favorito, int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Update Anotacao set favorito = @favorito where id = @id", conn);
            cmd.Parameters.AddWithValue("@favorito", favorito);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}