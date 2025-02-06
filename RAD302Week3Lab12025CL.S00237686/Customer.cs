using System.ComponentModel.DataAnnotations;

namespace RAD302Week3Lab12025CL.S00237686
{
    public class Customer
    {
        [Key]
        [Display(Name = "Customer Number")]
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name = "Credit Rating")]
        public float CreditRating { get; set; }
    }
}
