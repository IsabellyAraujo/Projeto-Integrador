using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador.PaginasAjuda
{
    public partial class MasterPageAjuda : System.Web.UI.MasterPage
    {
        DAL.DALUsuario DALUsuario = new DAL.DALUsuario();
        Modelo.Usuario Usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = DALUsuario.Select(Session["userId"].ToString());
            ImageButton1.ImageUrl = Usuario.EnderecoFoto;
        }
    }
}