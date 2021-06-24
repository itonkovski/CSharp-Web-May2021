using System;
using System.ComponentModel.DataAnnotations;

namespace Panda.Data
{
    public class Receipt
    {
        //Id - a GUID String, Primary Key
        //Fee - a decimal number
        //Issued On - a DateTime object
        //RecipientId - GUID foreign key(required)
        //Recipient - a User object
        //PackageId - GUID foreign key(required)
        //Package – a Package object
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public decimal Free { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        public string RecipientId { get; set; }

        public virtual User Recipient { get; set; }

        [Required]
        public string PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}