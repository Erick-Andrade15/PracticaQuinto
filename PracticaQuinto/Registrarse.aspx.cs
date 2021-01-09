using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using SimpleCrypto;

namespace PracticaQuinto
{
    public partial class Registrarse : System.Web.UI.Page
    {
        string Mensaje = null;
        string[] TipoAlerta = { "Error", "Exitoso", "Informativo" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarRoles();
                
            }
        }

        [System.Web.Services.WebMethod]
        public static bool ValidarUsuario(string Nombre)
        {
            CN_Usuario objetoCN = new CN_Usuario();
            List<Tbl_Usuario> usu = new List<Tbl_Usuario>();

            usu = objetoCN.ValidarUsuario(Nombre);//Validar Usuario si Existe

            if (usu.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //  Listar Proveedore Drowlist
        protected void ListarRoles()
        {
            CN_Rol objetoCN = new CN_Rol();

            Drp_Rol.DataSource = objetoCN.MostrarRoles();
            Drp_Rol.DataTextField = "nombre_rol";
            Drp_Rol.DataValueField = "id_rol";
            Drp_Rol.DataBind();
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

            if (txtCedula.Text == "" || txtNombre.Text == "" || txtDireccion.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == "" || txtUsuario.Text == "" || txtContrasenia.Text == "" || Drp_Rol.SelectedItem == null)
            {
                Mensaje = "Campos Vacios. Llene todo los campos";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[0] + "');", true);
            }
            else
            {
                if (hdf_Cedula.Value == "1")
                {

                    CN_Usuario objetoCN = new CN_Usuario();
                    List<Tbl_Usuario> usu = new List<Tbl_Usuario>();

                    usu = objetoCN.ValidarUsuario(txtUsuario.Text);//Validar Usuario si Existe

                    if (usu.Count > 0)
                    {
                        Mensaje = "El Nombre de Usuario ya Existe.";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[2] + "');", true);
                        txtUsuario.Text = "";
                    }
                    else
                    {
                        objetoCN.InsertarUsuario(txtCedula.Text, txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, txtUsuario.Text, txtContrasenia.Text, "1", "s");


                        Mensaje = "Usuario Agregado Correctamente";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[1] + "');", true);

                        Limpiar();
                    }

                }
                else
                {
                    Mensaje = "Cedula Incorrecta";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarAlerta", "MostrarAlerta('" + Mensaje + "','" + TipoAlerta[0] + "');", true);
                }
            }
        }

        private void Limpiar()
        {
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
        }



    }
}