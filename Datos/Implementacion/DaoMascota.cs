using CRUDveterinaria.Datos.Interfaz;
using CRUDveterinaria.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDveterinaria.Datos.Implementacion
{
     class DaoMascota : IDaoMascota
    {
        public int ObtenerProximo()
        {
            string sp_nombre = "sp_ObtenerProximo";
            string OutPut = "@Next";
            return Helper.ObtenerInstancia().ObtenerProximo(sp_nombre,OutPut);
        }
        public List<TipoMascota> ObtenerTipos()
        {
            List<TipoMascota> lst = new List<TipoMascota>();
            string sp_nombre = "sp_cargar_tipos";
            DataTable tabla = Helper.ObtenerInstancia().CargarCombo(sp_nombre);
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_tipo"].ToString());
                string tipo = dr["descripcion"].ToString();

                TipoMascota aux = new TipoMascota(id, tipo);

                lst.Add(aux);
            }
            return lst;
        }
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lst = new List<Cliente>();
            string sp_nombre = "sp_cargar_clientes";
            DataTable table = Helper.ObtenerInstancia().CargarCombo(sp_nombre);
            foreach (DataRow dr in table.Rows)
            {
                int id = int.Parse(dr["id_cliente"].ToString());
                string nombre = dr["nombre"].ToString();
                Cliente aux = new Cliente(id, nombre);
                lst.Add(aux);
            }
            return lst;
        }
    }
}
