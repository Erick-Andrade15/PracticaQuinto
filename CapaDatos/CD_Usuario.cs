using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuario
    {
        LinqConexionDataContext con = new LinqConexionDataContext();

        Tbl_Usuario usuario = new Tbl_Usuario();


        //ValidarUsuario
        public List<Tbl_Usuario> UsuarioExiste(string Nom_Usuario)
        {
            var MostraSql = con.Tbl_Usuario.Where(usuario => usuario.usuario_usu.Equals(Nom_Usuario));
            return MostraSql.ToList();
        }

        //Validar Login Usuario
        public List<Tbl_Usuario> UsuarioLogin(string Nom_Usuario , string Contra_Usuario)
        {
            var MostraSql = con.Tbl_Usuario.Where(usuario => usuario.estado_usu == "Activo" & 
                            usuario.usuario_usu.Equals(Nom_Usuario) & 
                            usuario.contrasenia_usu.Equals(Contra_Usuario)) ;

            return MostraSql.ToList();
        }

        //Mostrar
        public List<Tbl_Usuario> ListarUsuarios()
        {
            var MostraSql = from usu in con.GetTable<Tbl_Usuario>()
                            select usu;
            return MostraSql.ToList();
        }


        //Insertar
        public void Insertar(string Cedula, string Nombre, string Direccion, string Telefono, string Correo, string Usuario, string Contrasenia, string Salt, int Rol,string Foto)
        {

            usuario.cedula_usu = Cedula;
            usuario.nombre_usu = Nombre;
            usuario.direccion_usu = Direccion;
            usuario.telefono_usu_ = Telefono;
            usuario.correo_usu = Correo;
            usuario.usuario_usu = Usuario;
            usuario.contrasenia_usu = Contrasenia;
            usuario.salt_contrasenia_usu = Salt;
            usuario.rol_usu = 1;
            usuario.foto_usu = Foto;
            usuario.fechacreacion_usu = DateTime.Now;
            usuario.estado_usu = "Activo";
            con.Tbl_Usuario.InsertOnSubmit(usuario);
            con.SubmitChanges();
        }

        //Editar CONTRASENIA (RECUPERAR)
        public void EditarContrasenia( string Contrasenia, string Salt, int Id)
        {
            usuario = con.Tbl_Usuario.FirstOrDefault(usuario => usuario.id_usuario.Equals(Id));
            usuario.contrasenia_usu = Contrasenia;
            usuario.salt_contrasenia_usu = Salt;
            usuario.recupero_contrasenia_usu = 1;
            con.SubmitChanges();
     
        }

        //CAMBIAR CONTRASENIA
        public void CambiarContrasenia(string Contrasenia, string Salt, int Id)
        {
            usuario = con.Tbl_Usuario.FirstOrDefault(usuario => usuario.id_usuario.Equals(Id));
            usuario.contrasenia_usu = Contrasenia;
            usuario.salt_contrasenia_usu = Salt;
            usuario.recupero_contrasenia_usu = 0;
            con.SubmitChanges();
        }
    }
}

