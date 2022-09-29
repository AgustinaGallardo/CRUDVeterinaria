using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDveterinaria.Dominio
{
    internal class TipoMascota
    {
        int IdTipo { get; set; }
        string NombreTipo { get; set; }
        public TipoMascota(int id, string nombre)
        {
            this.IdTipo = id;
            this.NombreTipo = nombre;
        }
    }
}
