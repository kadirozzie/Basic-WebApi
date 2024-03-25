using System.ComponentModel.DataAnnotations;

namespace urunTakip.DataAccessLayer
{
    public class Product
    {
        [Key]
        public int Id { get; set; } // Birincil anahtar

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TaxRatio { get; set; }

        public string Description { get; set; }
    }
}
