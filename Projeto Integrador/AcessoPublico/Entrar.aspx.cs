using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador.Acesso_Público
{
    public partial class Entrar1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (IsValidEmail(Login1.UserName))
            {
                string username = Membership.GetUserNameByEmail(Login1.UserName);
                e.Authenticated = Membership.ValidateUser(username, Login1.Password);
                if (e.Authenticated == true) Session["userId"] = Membership.GetUser(username).ProviderUserKey.ToString();
            }
            else
            {
                e.Authenticated = Membership.ValidateUser(Login1.UserName, Login1.Password);
                if (e.Authenticated == true) Session["userId"] = Membership.GetUser(Login1.UserName).ProviderUserKey.ToString();
            }
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
            var div = Login1.FindControl("erro");
            div.Visible = true;
            
            var mensagem = Login1.FindControl("mensagem_erro");
            if (IsValidEmail(Login1.UserName)) (mensagem as Label).Text = "Email e/ou senha inválidos";
            else (mensagem as Label).Text = "Nome de usuário e/ou senha inválidos";
        }
    }
}