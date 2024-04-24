using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models.Entities
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int CarID { get; set; }
        public Car Car { get; set; }

        public string description { get; set; }
        public int percent { get; set; }

    }
}
