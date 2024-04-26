using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string username { get; set; }
        public string name { get; set; }
        public string password { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
