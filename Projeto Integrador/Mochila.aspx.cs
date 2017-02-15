using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto_Integrador.Modelo;

namespace Projeto_Integrador
{
    public partial class Mochila : System.Web.UI.Page
    {
        int arquivo_id;
        string arquivo_idString;
        string arquivo_descricao;
        Modelo.Mochila arquivo;
        DAL.DALMochila mochila = new DAL.DALMochila();
        
       //page load
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarArquivos();
        }

        //protected void Upload_Click(object sender, EventArgs e)
        //{
        //    //Salva arquivo na pasta do usuário
        //    string directory = Request.PhysicalApplicationPath + Session["userId"] + "\\";
        //    //FileUpload1.SaveAs(directory + FileUpload1.FileName);

        //    //Insere arquivo no BD
        //   // arquivo = new Modelo.Mochila(0, FileUpload1.FileName, directory, "", Session["userId"].ToString());
        //    mochila.Insert(arquivo);

        //    //Response.Redirect("~\\Mochila.aspx");
        //}

        protected void LinkButtonDownloadArquivo(object sender, EventArgs e)
        {
            string path = Request.PhysicalApplicationPath.ToString() + Session["userId"].ToString() + "\\" + (sender as LinkButton).Text;
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
            }
        }
        protected void LinkButtonDownloadArquivo_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = arquivo_id.ToString();
        }
        
        
        //lista arquivos

        protected void MostrarArquivos()
        {
            List<Modelo.Mochila> Arquivos;
            Arquivos = mochila.SelectAll(Session["userId"].ToString());

            TableRow tr;
            TableCell tc;

            //Le lista com arquivos
            if (Arquivos.Count > 0)
            {
                foreach (Modelo.Mochila arquivo in Arquivos)
                {
                    tr = new TableRow();
                    tc = new TableCell();
                    tr.Cells.Add(tc);
                }
            }
        }
        //excluir arquivo
        protected void LinkButtonExcluirArquivo(object sender, EventArgs e)
        {
            DAL.DALMochila DALMochila = new DAL.DALMochila();
            Modelo.Mochila mochila = new Modelo.Mochila(int.Parse((sender as LinkButton).CommandName));
            DALMochila.Delete(mochila);
            Response.Redirect("~\\Mochila.aspx");
        }

        protected void LinkButtonExcluirArquivo_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = arquivo_id.ToString();
        }

        protected void LinkButtonEditarDescricaoArquivo_Click(object sender, EventArgs e)
        {
           // TextBoxDescricaoArquivoEditar.Visible = true;
            //ButtonSalvarDescricaoArquivo.Visible = true;
            //string[] file = (sender as LinkButton).CommandArgument.Split(';');
            //int id = Convert.ToInt32(file[0]);
            //string descricao = file[1];
            //arquivo = new Modelo.Mochila(id, descricao);
            //mochila.Update(arquivo);
            //Response.Redirect("~\\Mochila.aspx");
        }
        protected void LinkButtonEditarDescricaoArquivo_PreRender(object sender, EventArgs e)
        {
            (sender as LinkButton).CommandName = arquivo_idString + ';' + arquivo_descricao;
        }
        //protected void LinkButtonEditarDescricaoArquivo_Click(object sender, EventArgs e)
        //{
        //    TextBoxDescricaoArquivoEditar.Visible = true;

        //    DAL.DALMochila DALMochila = new DAL.DALMochila();
        //    TextBoxDescricaoArquivoEditar.Text = DALMochila.SelectOne((sender as LinkButton).CommandName).descricao.ToString();
        //    arquivo_idString = DALMochila.SelectOne((sender as LinkButton).CommandName).id.ToString();
        //}

        //upload de arquivo
        protected void ButtonEnviarArquivo_Click(object sender, EventArgs e)
        {
            string endereco;
            // Salva arquivo na pasta ArquivosInseridos
            endereco = Request.PhysicalApplicationPath + "ArquivosInseridos\\" +
                          FileUploadMochila.FileName;

            string enderecoInsert = FileUploadMochila.FileName;
            FileUploadMochila.SaveAs(endereco);
            string descricao = FileUploadMochila.FileName;
            string tamanhoDoArquivo = FileUploadMochila.FileBytes.ToString();

            string guidString = Session["userId"].ToString().Trim();
            Guid myGuid = new Guid(guidString);

            arquivo = new Modelo.Mochila(descricao, enderecoInsert, tamanhoDoArquivo, myGuid);
            mochila.Insert(arquivo);

            Response.Redirect("~\\Mochila.aspx");
        }

        protected void DataListMochila_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Projeto_Integrador.Modelo.Mochila m = (e.Item.DataItem as Projeto_Integrador.Modelo.Mochila);
            arquivo_idString = m.id.ToString();
            arquivo_descricao = m.descricao;
        }

        protected void DataListMochila_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string[] file = e.CommandName.ToString().Split(';'); // Split(';');
            int id = Convert.ToInt32(file[0]);
            string descricao = file[1];
            DAL.DALMochila dm = new DAL.DALMochila();
            arquivo = dm.SelectOne(id.ToString());
            //arquivo = new Modelo.Mochila(id, descricao);
            //mochila.Update(arquivo);
            Response.Redirect("~\\Mochila.aspx");
        }


    }
}