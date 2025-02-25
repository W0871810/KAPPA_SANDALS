using System.ComponentModel.DataAnnotations;

namespace KAPPA_SANDALS.Models
{
    public class Sandal
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public string? Design { get; set; }
        public decimal Price { get; set; }
        public int Age { get; set; }
        public int Size { get; set; }
    }
}
