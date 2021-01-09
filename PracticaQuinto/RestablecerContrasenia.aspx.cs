using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaQuinto
{
    public partial class RestablecerContrasenia : System.Web.UI.Page
    {
        string Mensaje = null;
        string[] TipoAlerta = { "Error", "Exitoso", "Informativo" };

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {            
            if (txtContrasenia.Text == txtConfirmarContrasenia.Text)
            {
                CN_Usuario objetoCN = new CN_Usuario();
                objetoCN.CambiarContrasenia(txtContrasenia.Text, Session["Codigo"].ToString());

                Mensaje = "Se Realizo el Cambio de Contrasenia Correctamente";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[1] + "');", true);

                txtContrasenia.Text = "";
                txtConfirmarContrasenia.Text = "";

                //Redireccionar A INICIO.ASPX
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Redireccionar", "setTimeout(function(){ window.location.href = 'Inicio.aspx'}, 4000);", true);

            }
            else
            {
                Mensaje = "Las Contrasenia no Coinciden";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[0] + "');", true);
            }

        }
    }
}