using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCrypto;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        //Creamos Objetos de Producto
        private CD_Usuario objetoCD = new CD_Usuario();
        List<Tbl_Usuario> usu = new List<Tbl_Usuario>();
        string SaltEncriptar = null;

        public void InsertarUsuario(string cedula, string nombre, string direccion, string telefono, string correo, string usuario, string contrasenia, string rol, string foto)
        {
            //Encriptar Contraseña
            ICryptoService cryptoService = new PBKDF2();
            string Salt_Contrasenia = cryptoService.GenerateSalt();
            string Contrasenia_Encriptada = cryptoService.Compute(contrasenia);

            objetoCD.Insertar(cedula, nombre, direccion, telefono, correo, usuario, Contrasenia_Encriptada, Salt_Contrasenia, Convert.ToInt32(rol), foto);
        }

        public List<Tbl_Usuario> ValidarUsuario(string usuario)
        {            
            usu = objetoCD.UsuarioExiste(usuario);

            foreach (var item in usu)
            {
                SaltEncriptar = item.salt_contrasenia_usu;
            }

            return usu; 
        }

        public List<Tbl_Usuario> IniciarSesion(string usuario , string contrasenia)
        {
            //Encriptar Contraseña
            ICryptoService cryptoService = new PBKDF2();
            string ContraseniaEncriptada = cryptoService.Compute(contrasenia, SaltEncriptar);

            return objetoCD.UsuarioLogin(usuario, ContraseniaEncriptada);
        }

        public void RecuperarContrasenia(string NuevaContrasenia, string IdUsuario)
        {
            //Encriptar Contraseña
            ICryptoService cryptoService = new PBKDF2();
            string Salt_Contrasenia = cryptoService.GenerateSalt();
            string Contrasenia_Encriptada = cryptoService.Compute(NuevaContrasenia);

            objetoCD.EditarContrasenia(Contrasenia_Encriptada, Salt_Contrasenia, Convert.ToInt32(IdUsuario));
        }

        public void CambiarContrasenia(string NuevaContrasenia, string IdUsuario)
        {
            //Encriptar Contraseña
            ICryptoService cryptoService = new PBKDF2();
            string Salt_Contrasenia = cryptoService.GenerateSalt();
            string Contrasenia_Encriptada = cryptoService.Compute(NuevaContrasenia);

            objetoCD.CambiarContrasenia(Contrasenia_Encriptada, Salt_Contrasenia, Convert.ToInt32(IdUsuario));
        }
    }
}
