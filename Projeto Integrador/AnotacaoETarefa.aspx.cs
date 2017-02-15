using System;
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
        string tarefa_idString;
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
                //edita anotação att
        protected void LinkButtonEditarAnotacoes_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = anotacao_id.ToString();
        }
                //atualiza exclui anotação  
        protected void LinkButtonExcluirAnotacoes_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = anotacao_id.ToString();
        }
                //atualiza fav anotação  
        protected void ImageButtonFavoritarAnotacoes_PreRender(object sender, EventArgs e)
        {
            (sender as ImageButton).CommandName = anotacao_id.ToString();
        }
                    //atualiza imgfav anotação  
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
               //editar anotações
        protected void LinkButtonEditarAnotacoes_Click(object sender, EventArgs e)
        {
            LabelAnotacoesDescricao.Visible = true;
            LabelAnotacoesTitulo.Visible = true;
            TextBoxAnotacoesTitulo.Visible = true;
            TextBoxAnotacoesDescricao.Visible = true;
            ButtonEditarSalvar.Visible = true;
            ButtonSalvarAnotacoes.Visible = false;

            DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
            TextBoxAnotacoesTitulo.Text = DALAnotacao.SelectOne((sender as LinkButton).CommandName).titulo.ToString();
            TextBoxAnotacoesDescricao.Text = DALAnotacao.SelectOne((sender as LinkButton).CommandName).descricao.ToString();
            anotacao_idString = DALAnotacao.SelectOne((sender as LinkButton).CommandName).id.ToString();
        }
        //    //editar anotações
        protected void ButtonEditarSalvar_Click(object sender, EventArgs e)
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
            DAL.DALTarefa DALTarefa = new DAL.DALTarefa();
            visibilidade = DALTarefa.SelectValidarPrioridade(int.Parse((sender as Label).Text));
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
        protected void LinkButtonEditarTarefas_Click(object sender, EventArgs e)
        {
            LabelTarefaDescricao.Visible = true;
            TextBoxTarefaDescricao.Visible = true;
            ButtonSalvarTarefas.Visible = true;
            DAL.DALTarefa DALTarefa = new DAL.DALTarefa();
            TextBoxTarefaDescricao.Text = DALTarefa.SelectOne((sender as LinkButton).CommandName).descricao.ToString();
            tarefa_idString = DALTarefa.SelectOne((sender as LinkButton).CommandName).id.ToString();
        }
        //protected void LinkButtonEditarTarefas_Click(object sender, EventArgs e)
        //{
            
        //    string descricaoTarefa = TextBoxTarefaDescricao.Text;
        //    DateTime horarioDeEnvio = DateTime.Now;
        //    Modelo.Tarefa tarefa = new Modelo.Tarefa(int.Parse((sender as LinkButton).CommandName), TextBoxTarefaDescricao.Text);
        //    DAL.DALTarefa DALTarefa = new DAL.DALTarefa();
        //    DALTarefa.Update(tarefa);
        //    DAL.DALAnotacao DALAnotacao = new DAL.DALAnotacao();
           
        //}
        
        
        //atualiza editar tarefas
        protected void LinkButtonEditarTarefas_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = tarefa_id.ToString();
        }
        //PRIORIDADE
        protected void ImageButtonPriorizarTarefa_Click(object sender, ImageClickEventArgs e)
        {
            DAL.DALTarefa DALTarefa = new DAL.DALTarefa();
            bool validar = DALTarefa.SelectValidarPrioridade(int.Parse((sender as ImageButton).CommandName));
            if (validar == false)
            {
                DALTarefa.UpdatePrioridade(1, int.Parse((sender as ImageButton).CommandName));
            }
            else DALTarefa.UpdatePrioridade(0, int.Parse((sender as ImageButton).CommandName));
            Response.Redirect("~/AnotacaoETarefa.aspx");
        }
        protected void ImageButtonPriorizarTarefa_PreRender(object sender, EventArgs e)
        {
            (sender as ImageButton).CommandName = tarefa_id.ToString();
        }
        protected void ImagePrioridade_PreRender(object sender, EventArgs e)
        {
            (sender as Image).Visible = visibilidade;
        }
    }
}