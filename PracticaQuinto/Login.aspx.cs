using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaQuinto
{
    public partial class Login : System.Web.UI.Page
    {
        string Mensaje = null;
        string[] TipoAlerta = { "Error", "Exitoso", "Informativo" };
        int Contador = 1;
        int Intentos = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ContadorIntentos"] = Session["Intentos"];

            if (Session["Usuario"] != null)
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Usuario objetoCN = new CN_Usuario();
            List<Tbl_Usuario> usu = new List<Tbl_Usuario>();

            string Usuario = txtUsuario.Text.Trim();
            string Contrasenia = txtContrasenia.Text.Trim();

            usu = objetoCN.ValidarUsuario(Usuario);//Validar Usuario si Existe

            if (usu.Count > 0) //Usuario Existe
            {

                usu = objetoCN.IniciarSesion(Usuario, Contrasenia);//Validar Usuario y Contrasenia

                if (usu.Count > 0)//Contrasenia Correcta
                {
                    string NombreUsuario = null;
                    string RolUsuario = null;
                    string IdUsuario = null;
                    string RecuperoContrasenia = null;

                    txtUsuario.Text = "";//Vaciar Campos
                    txtContrasenia.Text = "";

                    foreach (var item in usu) //LLenar datos de la BDD a variables
                    {
                        NombreUsuario = item.nombre_usu;
                        RolUsuario = item.rol_usu.ToString();
                        IdUsuario = item.id_usuario.ToString();
                        RecuperoContrasenia = item.recupero_contrasenia_usu.ToString();
                    }
                    
                    Session["Codigo"] = IdUsuario;
                    Session["Usuario"] = NombreUsuario; //Asignar valor a las variables
                    Session["Rol"] = RolUsuario;

                    if (RecuperoContrasenia == "1")
                    {
                        Response.Redirect("RestablecerContrasenia.aspx");
                    }
                    else
                    {
                        Response.Redirect("Inicio.aspx");
                    }

                }
                else
                {
                    Mensaje = "Contrasenia Incorrecta";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[0] + "');", true);

                    Intentos = (Contador) + ((Convert.ToInt32(Session["ContadorIntentos"])));


                    if (Intentos == 3)
                    {

                        Mensaje = "Haz Excedido el Limite de Intentos.";                        
                        string AlertaTimeout = " function () { MostrarAlerta('" + Mensaje + "','" + TipoAlerta[2] + "'); } ";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta2", "setTimeout(" + AlertaTimeout + " ,2000)", true);
                    }
                    else
                    {
                        //Hacer Conteo de Intentos
                        Mensaje = "Intento Numero: " + Intentos.ToString();

                        string AlertaTimeout = " function () { MostrarAlerta('" + Mensaje + "','" + TipoAlerta[2] + "'); } ";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta3", "setTimeout(" + AlertaTimeout + " ,2000)", true);

                        Session["Intentos"] = Intentos;
                    }

                }
            }
            else
            {
                Mensaje = "El Usuario no Existe";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[2] + "');", true);

            }
        }
    }
}