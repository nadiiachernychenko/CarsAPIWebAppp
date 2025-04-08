using System.ComponentModel.DataAnnotations;

namespace CarSharingAPI.Models
{
    public class CarSharingZone
    {
        [Key]
        public int CSZ_ID { get; set; }
        public string CSZ_TOWN { get; set; }
    }
}
