using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaQuinto
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {              
                lblNombreUsuario.Text = "Bienvenido: " + Session["Usuario"].ToString();
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            //Session.Remove("Usuario");
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}