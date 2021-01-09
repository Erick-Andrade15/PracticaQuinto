using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Rol
    {
        //Creamos Objetos de Producto
        private CD_Rol objetoCD = new CD_Rol();

        public List<Tbl_Rol> MostrarRoles()
        {
            return objetoCD.Mostrar();
        }

    }
}
