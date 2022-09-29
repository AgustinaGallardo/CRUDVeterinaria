using CRUDveterinaria.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDveterinaria.Servicios.Interfaz
{
    internal interface IServicio
    {
        int ObtenerProximo();
        List<TipoMascota> ObtenerTipos();

        List<Cliente> ObtenerClientes();
    }
}
