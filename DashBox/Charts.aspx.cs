using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DashBox
{
    public partial class Charts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //string error = "";
            //if (!IsUserLogged(ref error))
            //{
            //    Response.Redirect("~/Login.aspx");
            //}

            //usernamespan.InnerText = " " + Session["username"].ToString();

        }

        protected bool IsUserLogged(ref string errormessage)
        {
            try
            {
                if (Session["username"] != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                string erreur = (e.InnerException != null) ? e.Message + " [" + e.InnerException.Message + "] " : e.Message;
                errormessage = "Erreur lors de la vérification des accès utilisateur : " + erreur;

                return false;
            }
        }


        protected void LogoutUser()
        {
            try
            {

                Session.Clear();
                Session.Abandon();

            }
            catch
            {

            }
        }

        protected void deconnexionlink_Click(object sender, EventArgs e)
        {

            LogoutUser();

            Response.Redirect("~/Login.aspx");
            //if (LogoutUser(ref error))
            //{
            //    SuccesMessage.Visible = true;
            //    SuccessMessageLbl.Text = "Vous vous êtes correctement déconnecté";

            //    //Response.Redirect("~/Default.aspx");
            //    UserLoginSpace.Visible = false;
            //    usernamespan.InnerText = "";
            //    jumbotrondiv.Visible = false;
            //}
            //else
            //{
            //    ErrorMessage.Visible = true;
            //    ErrorMessageLbl.Text = error;
            //}

        }
    }
}