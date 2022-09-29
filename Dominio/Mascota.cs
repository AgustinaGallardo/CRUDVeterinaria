using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDveterinaria.Dominio
{
    internal class Mascota
    {
        int CodMascota { get; set; }
        string Nombre { get; set; }
        int Edad { get; set; }
        TipoMascota Tipo { get; set; }
        Cliente Cliente { get; set; }
        List<Atencion> Atenciones { get; set; }

        public Mascota(int codMacota, string nombre, int edad, int tipo, Cliente cliente)
        {
            this.CodMascota=codMacota;
            this.Nombre=nombre;
            this.Tipo=tipo;
            this.Edad=edad;
            this.Cliente=cliente;
        }
        public Mascota()
        {
            CodMascota=0;
            Nombre="";
            Edad = 0;
            Tipo = 0;
            Cliente = new Cliente();
        }
        public override string ToString()
        {
            return "Mascota: " + Nombre + " Edad: " + Edad;
        }
    }
}
