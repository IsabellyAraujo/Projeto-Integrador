using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador
{
    public partial class EntrarSala : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Modelo.Sala Sala = new Modelo.Sala(0, Nome.Text, Senha.Text);
            DAL.DALSala aSala = new DAL.DALSala();

            if (aSala.ProcurarSala(Sala))
            {
                Session["sala"] = Nome.Text;
                Response.Redirect("~/Sala.aspx");
            }
            else Response.Redirect("~/CriarSala.aspx");
        }
    }
}