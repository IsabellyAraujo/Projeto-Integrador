using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador
{
    public partial class CriarSala : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCriarSala_Click(object sender, EventArgs e)
        {
            Modelo.Sala Sala = new Modelo.Sala(0, Name.Text, Password.Text);
            DAL.DALSala aSala = new DAL.DALSala();

            aSala.Insert(Sala);

            Session["sala"] = Name.Text;

            Response.Redirect("~/Sala.aspx");
        }
    }
}