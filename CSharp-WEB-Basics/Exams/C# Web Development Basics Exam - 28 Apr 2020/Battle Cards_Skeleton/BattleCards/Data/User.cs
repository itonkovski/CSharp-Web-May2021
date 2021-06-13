using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Data
{
    public class User
    {
        //Has an Id – a string, Primary Key
        //Has a Username – a string with min length 5 and max length 20 (required)
        //Has an Email - a string (required)
        //Has a Password – a string with min length 6 and max length 20  - hashed in the database(required)
        //Has UserCard collection

        public User()
        {
            this.Users = new HashSet<UserCard>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserCard> Users { get; set; }
    }
}
