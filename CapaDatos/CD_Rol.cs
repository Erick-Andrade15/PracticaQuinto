using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Rol
    {
        LinqConexionDataContext con = new LinqConexionDataContext();

        Tbl_Rol rol = new Tbl_Rol();

        //Mostrar
        public List<Tbl_Rol> Mostrar()
        {
            var lista = con.Tbl_Rol;

            return lista.ToList();
        }
    }
}
