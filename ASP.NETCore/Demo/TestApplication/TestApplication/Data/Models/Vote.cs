using System;

namespace TestApplication.Data.Models
{
    public class Vote
    {
        public Vote()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public int BikeId { get; set; }

        public virtual Bike Bike { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}