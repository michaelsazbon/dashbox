using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DashBox
{
    public partial class Login : System.Web.UI.Page
    {

        private Data.DashBoxDataContext _context = new Data.DashBoxDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Session.Clear();
                    Session.Abandon();
                }
                catch { }
            }
        }

        protected bool LoginUser(string username, string password, ref string errormessage)
        {
            var User = _context.Users.Where(i => (i.Username == username && i.Password == password)).FirstOrDefault();

            if (User != null)
            {
                Session["username"] = username;
                return true;
            }
            else
            {
                errormessage = "Nom d'utilisateur ou password incorrect";
                return false;
            }

        }

        protected void ConnexionBtn_Click(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;
            ErrorMessageLbl.Text = "";

            PasswordValidator.Visible = false;
            PasswordError.Text = "";

            UsernameValidator.Visible = false;
            UsernameError.Text = "";





            string error = "";
            if (!string.IsNullOrEmpty(UsernameTxt.Text))
            {
                if (!string.IsNullOrEmpty(PasswordTxt.Text))
                {
                    if (!LoginUser(UsernameTxt.Text.Trim(), PasswordTxt.Text.Trim(), ref error))
                    {
                        ErrorMessage.Visible = true;
                        ErrorMessageLbl.Text = error;
                        return;
                    }
                    else
                    {
                        Response.Redirect("~/Dashboard.aspx");
                    }
                }
                else
                {
                    PasswordValidator.Visible = true;
                    PasswordError.Text = "Le mot de passe est requis";
                    return;
                }
            }
            else
            {
                UsernameValidator.Visible = true;
                UsernameError.Text = "Le nom d'utilisateur est requis";
                return;
            }




        }

        protected void deconnexionlink_Click(object sender, EventArgs e)
        {

            SuccesMessage.Visible = false;
            SuccessMessageLbl.Text = "";

            ErrorMessage.Visible = false;
            ErrorMessageLbl.Text = "";

        }
    }
}