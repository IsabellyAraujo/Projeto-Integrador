﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto_Integrador.DAL
{
    public class DALTarefa
    {
        string connectionString = "";

        public DALTarefa()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo3ConnectionString"].ConnectionString;
        }
        //Modelo Tarefa LISTAR SELECT ALL
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Tarefa> SelectAll(string user_id)
        {
            Modelo.Tarefa aTarefa;
            List<Modelo.Tarefa> aListTarefa = new List<Modelo.Tarefa>();
            
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select id, descricao, cumprida, prioritaria, horarioDeEnvio, usuario_id from Tarefa where usuario_id = @usuario_id order by prioritaria desc", conn);
            cmd.Parameters.AddWithValue("@usuario_id", user_id);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                        aTarefa = new Modelo.Tarefa(
                            Convert.ToInt32(dr["id"]),
                            dr["descricao"].ToString(),
                            Convert.ToBoolean(dr["cumprida"]),
                            Convert.ToBoolean(dr["prioritaria"]),
                            Convert.ToDateTime(dr["horarioDeEnvio"]),
                            dr["usuario_id"].ToString());                    
                    aListTarefa.Add(aTarefa);
                    /* aTarefa = new Modelo.Tarefa(
                        dr.GetString(0),
                        dr.GetString(1),
                        dr.GetBoolean(2),
                        dr.GetBoolean(3),
                        dr.GetDateTime(4),
                        dr.GetString(5)
                        );
                    aListTarefa.Add(aTarefa);*/
                }
            }

            dr.Close();
            conn.Close();

            return aListTarefa;
        }
        //Listar Tarefas Select ONE
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Tarefa SelectOne(string id)
        {
            Modelo.Tarefa aTarefa = new Modelo.Tarefa();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select id, descricao from Tarefa where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = cmd.ExecuteReader();

           if (dr.HasRows)
            {
                while (dr.Read())
                {
                        aTarefa = new Modelo.Tarefa(
                            Convert.ToInt32(dr["id"]),
                            (dr["descricao"].ToString()));
                }
            }

           dr.Close();
           conn.Close();
           return aTarefa;
        }
        //Deletar
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Tarefa obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_deletarUmaTarefa", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.id);

            cmd.ExecuteNonQuery();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Tarefa obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_inserirTarefa", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@cumprida", obj.cumprida);
            cmd.Parameters.AddWithValue("@prioritaria", obj.prioritaria);
            cmd.Parameters.AddWithValue("@usuario_id", obj.usuario_id);

            cmd.ExecuteNonQuery();
        }

        //[DataObjectMethod(DataObjectMethodType.Update)]
        //public void Update(Modelo.Tarefa obj)
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    conn.Open();

        //    SqlCommand cmd = new SqlCommand("sp_editarTarefa", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@id", obj.id);
        //    cmd.Parameters.AddWithValue("@descricao", obj.descricao);
        //    cmd.Parameters.AddWithValue("@cumprida", obj.cumprida);
        //    cmd.Parameters.AddWithValue("@prioritaria", obj.prioritaria);

        //    cmd.ExecuteNonQuery();
        //}
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Tarefa obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Update Tarefa set descricao = @descricao where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
          //  cmd.Parameters.AddWithValue("@horarioDeEnvio", obj.horarioDeEnvio);
            cmd.ExecuteNonQuery();
        }
        //favorito
        [DataObjectMethod(DataObjectMethodType.Select)]
        public bool SelectValidarPrioridade(int id)
        {
            bool validar = true;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("Select prioritaria FROM Tarefa where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["prioritaria"]) == 0)
                    {
                        validar = false;
                    }
                }
            }
            dr.Close();
            conn.Close();
            return validar;
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdatePrioridade(int prioritaria, int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Update Tarefa set prioritaria = @prioritaria where id = @id", conn);
            cmd.Parameters.AddWithValue("@prioritaria", prioritaria);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}