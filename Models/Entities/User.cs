using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models.Entities
{
    public class User:IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[StringLength(100)]
        //[Required]
        public int ID { get; set; }

        public string username { get; set; }
        public string name { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
