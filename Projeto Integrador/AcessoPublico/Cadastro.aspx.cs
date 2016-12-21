using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto_Integrador.Acesso_Público
{
    public partial class Cadastro1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CompleteWizardStep1_Activate(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            string UserId = Membership.GetUser(CreateUserWizard1.UserName).ProviderUserKey.ToString();
            Directory.CreateDirectory(Request.PhysicalApplicationPath + UserId);
            Session["userId"] = UserId;
        }

        protected void CreateUserWizard1_Click(Object sender, EventArgs e)
        {
            string senha = CreateUserWizard1.Password.ToString();
            string confirmacao = CreateUserWizard1.ConfirmPassword.ToString();
            if (senha != confirmacao)
            {
                CreateUserWizard1.Dispose();
                CreateUserWizard1_CreateUserError(sender, new CreateUserErrorEventArgs(MembershipCreateStatus.InvalidPassword));
            }
        }

        protected void CreateUserWizard1_CreateUserError(object sender, CreateUserErrorEventArgs e)
        {
            var div = CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("erro");
            div.Visible = true;
        }
    }
}