using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Detalle_de_ventas
    {
        private int id_venta;
        private int id_producto;
        private int id_cliente;
        private int cantidad;
        private float precio_unitario;

        public Detalle_de_ventas()
        { }

        public int getid_venta()
        {
            return id_venta;
        }
        public void setid_venta(int id_Venta)
        {
            id_venta = id_Venta;
        }
        //***
        public int getid_producto()
        {
            return id_producto;
        }
        public void setid_producto(int id_Producto)
        {
            id_producto = id_Producto;
        }
        //***
        public int getid_cliente()
        {
            return id_cliente;
        }
        public void setid_cliente(int id_Cliente)
        {
            id_cliente = id_Cliente;
        }
        //****
        public int getcantidad()
        {
            return cantidad;
        }
        public void setcantidad(int Cantidad)
        {
            cantidad = Cantidad;
        }
        //****
        public float getprecio_unitario()
        {
            return precio_unitario;
        }
        public void setprecio_unitario(float Precio_unitario)
        {
            precio_unitario = Precio_unitario;
        }


    }
}
