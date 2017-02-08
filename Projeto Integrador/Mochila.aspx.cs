using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador
{
    public partial class Mochila : System.Web.UI.Page
    {
        Modelo.Mochila arquivo;
        DAL.DALMochila mochila = new DAL.DALMochila();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarArquivos();
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            //Salva arquivo na pasta do usuário
            string directory = Request.PhysicalApplicationPath + Session["userId"] + "\\";
            //FileUpload1.SaveAs(directory + FileUpload1.FileName);

            //Insere arquivo no BD
           // arquivo = new Modelo.Mochila(0, FileUpload1.FileName, directory, "", Session["userId"].ToString());
            mochila.Insert(arquivo);

            //Response.Redirect("~\\Mochila.aspx");
        }

        protected void DownloadArquivo(object sender, EventArgs e)
        {
            string path = Request.PhysicalApplicationPath.ToString() + Session["userId"].ToString() + "\\" + (sender as Button).Text;
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
            }
        }

        protected void MostrarArquivos()
        {
            List<Modelo.Mochila> Arquivos;
            Arquivos = mochila.SelectAll(Session["userId"].ToString());

            TableRow tr;
            TableCell tc;
            Button botao;
            // TextBox texto;

            //Le lista com arquivos
            if (Arquivos.Count > 0)
            {
                foreach (Modelo.Mochila arquivo in Arquivos)
                {
                    tr = new TableRow();
                    tc = new TableCell();
                    botao = new Button();
                    botao.Text = arquivo.descricao;
                    botao.Click += DownloadArquivo;
                    tc.Controls.Add(botao);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    botao = new Button();
                    botao.Text = "Excluir";
                    botao.Click += DeletarArquivo;
                    botao.CommandArgument = arquivo.id + ";" + arquivo.descricao;
                    tc.Controls.Add(botao);
                    tr.Cells.Add(tc);

                    //Table1.Rows.Add(tr);
                    
                }
            }
        }

        protected void DeletarArquivo(object sender, EventArgs e)
        {
            string[] file = (sender as Button).CommandArgument.Split(';');
            int id = Convert.ToInt32(file[0]);
            string path = Request.PhysicalApplicationPath.ToString() + Session["userId"].ToString() + "\\" + file[1];
            arquivo = new Modelo.Mochila(id, "", "", "");
            mochila.Delete(arquivo);
            System.IO.File.Delete(path);
            Response.Redirect("~\\Mochila.aspx");
        }

        protected void AtualizarArquivo(object sender, EventArgs e)
        {
            string[] file = (sender as Button).CommandArgument.Split(';');
            int id = Convert.ToInt32(file[0]);
            string descricao = file[1];
            arquivo = new Modelo.Mochila(id, descricao, "", "");
            mochila.Update(arquivo);
            Response.Redirect("~\\Mochila.aspx");
        }

        protected void ButtonEnviarArquivo_Click(object sender, EventArgs e)
        {
           // string = Session["userId"];
           // Guid usuario_id;
            //usuario_id = Guid.TryParse(Session["userId"]);
          //  Guid usuario_id = Guid.NewGuid();
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

            
        }
    }
}