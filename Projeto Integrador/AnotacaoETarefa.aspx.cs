﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador
{
    public partial class AnotacoesETarefa : System.Web.UI.Page
    {
        int anotacao_id;
        int tarefa_id;
        string anotacao_idString;
        bool visibilidade;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //ANOTAÇÃO
        protected void ButtonAnotacoes_Click(object sender, EventArgs e)
        {
            LabelAnotacoesDescricao.Visible = true;
            LabelAnotacoesTitulo.Visible = true;
            TextBoxAnotacoesTitulo.Visible = true;
            TextBoxAnotacoesDescricao.Visible = true;
            ButtonSalvarAnotacoes.Visible = true;
        }
            //salva anotação
        protected void ButtonSalvarAnotacoes_Click(object sender, EventArgs e)
        {
            DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
            Modelo.Anotacao anotacao = new Modelo.Anotacao(TextBoxAnotacoesTitulo.Text, TextBoxAnotacoesDescricao.Text, false, Session["userID"].ToString());
            DALAnotacao.Insert(anotacao);

            Response.Redirect("~/AnotacaoETarefa.aspx");

            LabelAnotacoesDescricao.Visible = false;
            LabelAnotacoesTitulo.Visible = false;
            TextBoxAnotacoesTitulo.Visible = false;
            TextBoxAnotacoesDescricao.Visible = false;
        }
            // atualiza a anotação
        protected void LabelAnotacoesId_PreRender(object sender, EventArgs e)
        {
            anotacao_id = int.Parse((sender as Label).Text);
            (sender as Label).Visible = false;
            DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
            visibilidade = DALAnotacao.SelectValidarFavorito(int.Parse((sender as Label).Text));
        }
                //edita anotação
        protected void LinkButtonEditarAnotacoes_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = anotacao_id.ToString();
        }
                //atualiza exclui anotação  
        protected void LinkButtonExcluirAnotacoes_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = anotacao_id.ToString();
        }

        protected void ImageButtonFavoritarAnotacoes_PreRender(object sender, EventArgs e)
        {
            (sender as ImageButton).CommandName = anotacao_id.ToString();
        }

        protected void ImageFavorito_PreRender(object sender, EventArgs e)
        {
            (sender as Image).Visible = visibilidade;
        }
                //favorita anotação
        protected void ImageButtonFavoritarAnotacoes_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
            bool validar = DALAnotacao.SelectValidarFavorito(int.Parse((sender as ImageButton).CommandName));
            if (validar == false) 
            {
                DALAnotacao.UpdateFavorito(1, int.Parse((sender as ImageButton).CommandName));
            }
            else DALAnotacao.UpdateFavorito(0, int.Parse((sender as ImageButton).CommandName));
            Response.Redirect("~/AnotacaoETarefa.aspx");
        }
                //exclui anotação
        protected void LinkButtonExcluirAnotacoes_Click(object sender, EventArgs e)
        {
            DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
            Modelo.Anotacao anotacao = new Modelo.Anotacao(int.Parse((sender as LinkButton).CommandName));
            DALAnotacao.Delete(anotacao);
            Response.Redirect("~/AnotacaoETarefa.aspx");
        }

        protected void LinkButtonEditarAnotacoes_Click(object sender, EventArgs e)
        {
            LabelAnotacoesDescricao.Visible = true;
            LabelAnotacoesTitulo.Visible = true;
            TextBoxAnotacoesTitulo.Visible = true;
            TextBoxAnotacoesDescricao.Visible = true;
            ButtonSalvarAnotacoes.Visible = true;


            DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
            TextBoxAnotacoesTitulo.Text = DALAnotacao.SelectOne((sender as LinkButton).CommandName).titulo.ToString();
            TextBoxAnotacoesDescricao.Text = DALAnotacao.SelectOne((sender as LinkButton).CommandName).descricao.ToString();
            anotacao_idString = DALAnotacao.SelectOne((sender as LinkButton).CommandName).id.ToString();
        }
            //editar anotações
        protected void ButtonEditarAnotacoes_Click(object sender, EventArgs e)
        {
            string tituloAnotacao = TextBoxAnotacoesTitulo.Text;
            string descricaoAnotacao = TextBoxAnotacoesDescricao.Text;
            DateTime horarioDeEnvio = DateTime.Now;
            Modelo.Anotacao anotacao = new Modelo.Anotacao(int.Parse((sender as LinkButton).CommandName), TextBoxAnotacoesTitulo.Text, TextBoxAnotacoesDescricao.Text, horarioDeEnvio);
            DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
            DALAnotacao.Update(anotacao);
        }
        protected void ButtonEditarAnotacoes_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = anotacao_idString;
        }
        //TAREFA
        protected void ButtonTarefas_Click(object sender, EventArgs e)
        {
            LabelTarefaDescricao.Visible = true;
            TextBoxTarefaDescricao.Visible = true;
            ButtonSalvarTarefas.Visible = true;
        }
                    //Salvar tarefas
        protected void ButtonSalvarTarefa_Click(object sender, EventArgs e)
        {
            DAL.DALTarefa DALTarefa = new DAL.DALTarefa();
            Modelo.Tarefa tarefa = new Modelo.Tarefa(TextBoxTarefaDescricao.Text, false, false, Session["userID"].ToString());
            DALTarefa.Insert(tarefa);
            Response.Redirect("~/AnotacaoETarefa.aspx");
            TextBoxTarefaDescricao.Visible = false;
        }
                // atualiza id tarefas
        protected void LabelTarefasId_PreRender(object sender, EventArgs e)
        {
            tarefa_id = int.Parse((sender as Label).Text);
            (sender as Label).Visible = false;
            DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
            visibilidade = DALAnotacao.SelectValidarFavorito(int.Parse((sender as Label).Text));
        }
        //atualiza exclui tarefas
        protected void LinkButtonExcluirTarefas_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = tarefa_id.ToString();
        }
            //exclui tarefas
        protected void LinkButtonExcluirTarefas_Click(object sender, EventArgs e)
        {
            DAL.DALTarefa DALTarefa = new DAL.DALTarefa();
            Modelo.Tarefa tarefa = new Modelo.Tarefa(int.Parse((sender as LinkButton).CommandName));
            DALTarefa.Delete(tarefa);
            Response.Redirect("~/AnotacaoETarefa.aspx");
        }
            //editar tarefas
        //protected void ButtonEditarTarefas_Click(object sender, EventArgs e)
        //{
        //    string descricaoTarefa = TextBoxTarefaDescricao.Text;
   
        //    DateTime horarioDeEnvio = DateTime.Now;
        //    Modelo.Anotacao anotacao = new Modelo.Anotacao(int.Parse((sender as LinkButton).CommandName), TextBoxAnotacoesTitulo.Text, TextBoxAnotacoesDescricao.Text, horarioDeEnvio);
        //    DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
        //    DALAnotacao.Update(anotacao);
        //}


      
    }
}