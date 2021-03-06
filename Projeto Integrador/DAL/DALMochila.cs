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
    public class DALMochila
    {
        string connectionString = "";

        public DALMochila()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2016TiiGrupo3ConnectionString"].ConnectionString;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Mochila> SelectAll(string user_id)
        {
            Modelo.Mochila aMochila;
            List<Modelo.Mochila> aListMochila = new List<Modelo.Mochila>();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select id, descricao, endereco, tamanhoArquivo, usuario_id from Arquivo where usuario_id = @usuario_id", conn);
            cmd.Parameters.AddWithValue("@usuario_id", user_id);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string descricao = dr.GetString(1);
                    string endereco = dr[2].ToString();

                    string tamanhoArquivo = dr.GetString(3);
                    Guid usuario_id = dr.GetGuid(4);
                    aMochila = new Modelo.Mochila(
                        id,
                        descricao,
                        endereco, //(dr[2] as Nullable<Guid>).ToString(),
                        tamanhoArquivo,
                        usuario_id
                        );
                    aListMochila.Add(aMochila);
                }
            }

            dr.Close();
            conn.Close();

            return aListMochila;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Modelo.Mochila SelectOne(string id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_listarUmArquivo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = cmd.ExecuteReader();

            Modelo.Mochila aMochila = new Modelo.Mochila();
            if(dr.Read()){
                        aMochila = new Modelo.Mochila(
                            dr.GetInt32(0),
                            dr.GetString(1),
                            dr.GetString(2),
                            dr.GetString(3),
                            dr.GetDateTime(4),
                            dr.GetGuid(5)
                            //Convert.ToInt32(dr["id"]),
                            //dr["descricao"].ToString(),
                            //dr["endereco"].ToString(),
                            //dr["tamanhoArquivo"].ToString(),
                        );
            }

            dr.Close();
            conn.Close();

            return aMochila;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Mochila obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_deletarUmArquivo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.id);

            cmd.ExecuteNonQuery();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Mochila obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_inserirArquivo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@endereco", "~/ArquivosInseridos/" + obj.endereco);
            cmd.Parameters.AddWithValue("@tamanhoArquivo", obj.tamanhoArquivo);
            cmd.Parameters.AddWithValue("@usuario_id", obj.usuario_id);

            cmd.ExecuteNonQuery();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Mochila obj)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_editarArquivo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@descricao", obj.descricao);
            cmd.Parameters.AddWithValue("@horarioDeEnvio", obj.horarioDeEnvio);
            //cmd.Parameters.AddWithValue("@endereco", obj.endereco);
            //cmd.Parameters.AddWithValue("@tamanhoArquivo", obj.tamanhoArquivo);

            cmd.ExecuteNonQuery();
        }
    }
}