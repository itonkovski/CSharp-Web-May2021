using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Data.Models
{
    using static DataConstants.Dealer;

    public class Dealer
    {
        public Dealer()
        {
            this.Bikes = new HashSet<Bike>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public IEnumerable<Bike> Bikes { get; set; }
    }
}
