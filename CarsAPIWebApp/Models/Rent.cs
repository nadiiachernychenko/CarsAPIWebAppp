using System;
using System.ComponentModel.DataAnnotations;

namespace CarSharingAPI.Models
{
    public class Rent
    {
        [Key]
        public int RN_ID { get; set; }
        public int RN_CAR_ID { get; set; }
        public DateTime RN_START_DATE { get; set; }
        public DateTime RN_FINISH_DATE { get; set; }
        public decimal RN_COST_PER_DAY { get; set; }
        public int RN_CS_ID { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
