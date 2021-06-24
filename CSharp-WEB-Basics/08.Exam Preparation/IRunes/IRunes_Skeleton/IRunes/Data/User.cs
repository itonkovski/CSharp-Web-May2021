using System;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Data
{
    public class User
    {
        //Id – a string (GuID), Primary key
        //Username – a string with min length 4 and max length 10 (inclusive) (required)
        //Password – a string with min length 6 and max length 20 (inclusive)  - hashed in the database(required)
        //Email – a string (required)

        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
