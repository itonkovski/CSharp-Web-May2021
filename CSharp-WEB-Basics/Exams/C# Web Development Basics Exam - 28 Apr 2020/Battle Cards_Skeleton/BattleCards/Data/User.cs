using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SIS.MvcFramework;

namespace BattleCards.Data
{
    public class User : IdentityUser<string>
    {
        //Has an Id – a string, Primary Key
        //Has a Username – a string with min length 5 and max length 20 (required)
        //Has an Email - a string (required)
        //Has a Password – a string with min length 6 and max length 20  - hashed in the database(required)
        //Has UserCard collection

        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Role = IdentityRole.User;
            this.Cards = new HashSet<UserCard>();
        }

        public virtual ICollection<UserCard> Cards { get; set; }
    }
}
