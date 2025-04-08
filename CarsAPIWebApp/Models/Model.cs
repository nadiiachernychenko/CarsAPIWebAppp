using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSharingAPI.Models
{
    public class Model
    {
        public Model()
        {
            Cars = new List<Car>();
        }

        [Key]
        public int MD_ID { get; set; }
        public string MD_MODEL_NAME { get; set; }
        public int MD_NUM_OF_SEATS { get; set; }
        public bool MD_IS_AUTOMATIC { get; set; }
        public double MD_ENGINE_VOLUME { get; set; }
        public string MD_BRAND { get; set; }
        public string MD_TYPE { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
