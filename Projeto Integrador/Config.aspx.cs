using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador
{
    public partial class Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
            Modelo.Usuario Usuario =  DALUsuario.Select(Session["userId"].ToString());
            Nome.Text = Usuario.Nome;
            if (Usuario.DataDeNascimento != null)
            {
                DateTime data = Convert.ToDateTime(Usuario.DataDeNascimento.ToString());
                DataNascimento.Text = data.ToShortDateString();
            }
            Email.Text = Usuario.Email;
            NomeUsuario.Text = Usuario.Usuario1;
            Senha.Text = "*******";
            FotoPerfil.ImageUrl = Usuario.EnderecoFoto;
        }
    }
}