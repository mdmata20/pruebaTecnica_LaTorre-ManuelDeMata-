namespace CrudCompleto.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }

        public string? Nombre { get; set; }

        public string? sueldos { get; set; }

        public int? id_departamento { get; set; }


        public string? puesto { get; set; }

        public string? jerarquia { get; set; }

        public string? fecha_ingreso { get; set; }

        public string? fecha_aumento { get; set; }

        public string? fecha_baja { get; set; }
    }
}
