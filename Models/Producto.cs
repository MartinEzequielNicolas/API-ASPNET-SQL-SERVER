using System.ComponentModel.DataAnnotations;

namespace app.Models
{
    public class Producto
    {
        public  int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; } = null!;

        [MaxLength(500)]
        public string Descripcion { get; set; } = null!;

        public decimal Precio { get; set;}
    }
}
