using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador
{
    public partial class AlterarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePassword1_Click(Object sender, EventArgs e)
        {
            string nova_senha = ChangePassword1.NewPassword.ToString();
            string confirmacao = ChangePassword1.ConfirmNewPassword.ToString();
            if (nova_senha != confirmacao)
            {
                ChangePassword1.Dispose();
                ChangePassword1_ChangePasswordError(sender, e);
            }
        }

        protected void ChangePassword1_ChangePasswordError(object sender, EventArgs e)
        {
            var div = ChangePassword1.ChangePasswordTemplateContainer.FindControl("erro");
            div.Visible = true;
        }
    }
}