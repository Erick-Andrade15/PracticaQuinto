using CapaDatos;
using CapaNegocio;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaQuinto
{
    public partial class OlvidasteContrasenia : System.Web.UI.Page
    {
        string Mensaje = null;
        string[] TipoAlerta = { "Error", "Exitoso", "Informativo" };

        string CorreoUsuario = null;
        string CodigoUsu = null;
        string NombreUsu = null;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string Usuario = txtUsuario.Text.Trim();

            CN_Usuario objetoCN = new CN_Usuario();
            List<Tbl_Usuario> usu = new List<Tbl_Usuario>();

            usu = objetoCN.ValidarUsuario(Usuario);//Validar Usuario si Existe

            if (usu.Count > 0) //Validar Usuario
            {

                //Generar Contrasenia Random
                ICryptoService cryptoService = new PBKDF2();
                string ContraseniaNueva = RandomPassword.Generate(16, PasswordGroup.Lowercase, PasswordGroup.Numeric,
                                                                   PasswordGroup.Special, PasswordGroup.Uppercase);

                foreach (var item in usu) //LLenar datos de la BDD a variables
                {
                    CorreoUsuario = item.correo_usu;
                    CodigoUsu = item.id_usuario.ToString();
                    NombreUsu = item.nombre_usu;
                }

                objetoCN.RecuperarContrasenia(ContraseniaNueva,CodigoUsu);
                

                EnviarCorreo Correo = new EnviarCorreo();

                var Enviar = Correo.EnviarCorreoElectronico(CorreoUsuario, ContraseniaNueva, NombreUsu);

                if (Enviar) //Enviar Correo Electronico
                {

                    Mensaje = "Se envio correctamente su nueva contraseña al correo electronico: " + CorreoUsuario + ".";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[1] + "');", true);


                    Mensaje = "Revisar el buzon de mensajes o en la seccion de spam.";

                    string AlertaTimeout = " function () { MostrarAlerta('" + Mensaje + "','" + TipoAlerta[2] + "'); } ";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta2", "setTimeout(" + AlertaTimeout + " ,2000)", true);

                    txtUsuario.Text = "";
                }
                else
                {
                    Mensaje = "Error al Enviar el Correo";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[0] + "');", true);

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