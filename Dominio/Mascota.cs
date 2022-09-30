using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDveterinaria.Dominio
{
     class Mascota
    {
        public int IdMascota { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public TipoMascota Tipo { get; set; }
        public Cliente Cliente { get; set; }
        public List<Atencion> Atenciones { get; set; }

        public Mascota(int IdMascota, string nombre, int edad, TipoMascota tipo, Cliente cliente,List<Atencion> atenciones)
        {
            this.IdMascota = IdMascota;
            this.Nombre = nombre;
            this.Tipo = null;
            this.Edad = edad;
            this.Cliente = cliente;
            Atenciones = atenciones;
        }
        public Mascota()
        {
            IdMascota=0;
            Nombre="";
            Edad = 0;
            Tipo = null;
            Cliente = null;
            Atenciones = new List<Atencion>();
        }
        public void AgregarAtencion(Atencion atencion)
        {
            Atenciones.Add(atencion);
        }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (Atencion item in Atenciones)
            {
                total += item.Importe;
            }
            return total;
        }
        public void QuitarDetalle(int indice_detalle)
        {
            Atenciones.RemoveAt(indice_detalle);
        }
        public override string ToString()
        {
            return "Mascota: " + Nombre + " Edad: " + Edad;
        }
    }
}
