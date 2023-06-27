using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Carrito
    {

        private CD_Carrito objCapDato = new CD_Carrito();

        public bool ExisteCarrito(int idcliente, int idproducto)
        {
            return objCapDato.ExisteCarrito(idcliente, idproducto); 
        }


        public bool OperacionCarrito(int idcliente, int idproducto, bool sumar, out string Mensaje)
        {
            return objCapDato.OperacionCarrito(idcliente, idproducto, sumar, out Mensaje);
        }

        public int CantidadEnCarrito(int idcliente)
        {
            return objCapDato.CantidadEnCarrito(idcliente);
        }

        public List<Carrito> ListarProducto(int idcliente)
        {
            return objCapDato.ListarProducto(idcliente);
        }


        public bool EliminarCarrito(int idcliente, int idproducto)
        {
            return objCapDato.EliminarCarrito(idcliente, idproducto);
        }
    }
}
