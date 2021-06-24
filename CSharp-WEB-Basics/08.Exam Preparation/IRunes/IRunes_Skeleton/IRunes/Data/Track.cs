using System;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Data
{
    public class Track
    {
        //Id – a string (GuID), Primary key
        //Name – a string with min length 4 and max length 20 (inclusive) (required)
        //Link – a string (a link to a video) (required)
        //Price – a decimal (required)

        public Track()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}