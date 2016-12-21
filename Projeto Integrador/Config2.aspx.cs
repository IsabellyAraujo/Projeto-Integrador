using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador
{
    public partial class Config2 : System.Web.UI.Page
    {
        DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
        Modelo.Usuario Usuario;
        MembershipUser u;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario = DALUsuario.Select(Session["userId"].ToString());
                
                imagem_perfil.ImageUrl = Usuario.EnderecoFoto;
                if (Usuario.Nome != null)
                    nome.Text = Usuario.Nome;
                if (Usuario.DataDeNascimento != null)
                {
                    DateTime date = Convert.ToDateTime(Usuario.DataDeNascimento.ToString());
                    data.Text = date.ToString("yyyy-MM-dd");
                }
                email.Text = Usuario.Email;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario = DALUsuario.Select(Session["userId"].ToString());
                u = Membership.GetUser(Usuario.Usuario1);
                u.Email = email.Text;
                Membership.UpdateUser(u);
                string directory = Request.PhysicalApplicationPath + "Imagens\\perfil\\" + Session["userId"] + ".png";
                FileUpload1.SaveAs(directory);
                Usuario.Nome = nome.Text;
                Usuario.DataDeNascimento = Convert.ToDateTime(data.Text);
                Usuario.Email = email.Text;
                Usuario.EnderecoFoto = "~//Imagens//perfil//" + Session["userId"] + ".png";
                DALUsuario.Update(Usuario);
                Response.Redirect("~\\Config.aspx");
            }
            catch (Exception excecao)
            {
                erro.Visible = true;
                mensagem.InnerText = excecao.Message.ToString();
            }
        }
    }
}