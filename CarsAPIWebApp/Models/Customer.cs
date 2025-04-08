using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSharingAPI.Models
{
    public class Customer
    {
        public Customer()
        {
            Rents = new List<Rent>();
        }

        [Key]
        public int CS_ID { get; set; }
        public string CS_FIRST_NAME { get; set; }
        public string CS_LAST_NAME { get; set; }
        public string CS_PHONE { get; set; }
        public string CS_EMAIL { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }
}
