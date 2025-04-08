using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSharingAPI.Models
{
    public class Car
    {
        public Car()
        {
            Rents = new List<Rent>();
        }

        [Key]
        public int CR_ID { get; set; }

        public int CR_PRODUCE_YEAR { get; set; }
        public int CR_MODEL_ID { get; set; }
        public string CR_COLOR { get; set; }

        public virtual Model Model { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
