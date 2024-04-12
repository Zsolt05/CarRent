using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models.Entities
{
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }
        public DateTime created { get; set; } = DateTime.Now;

        public int UserID { get; set; }
        public User User { get; set; }

        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
