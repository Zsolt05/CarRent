using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int SaleID { get; set; }
        public Sale Sale { get; set; }

        public string brand { get; set; }
        public string model { get; set; }
        public int daily_price { get; set; }

        public ICollection<Rental> Rentals { get; set; }


    }
}
