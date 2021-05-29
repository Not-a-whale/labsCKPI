using System.ComponentModel.DataAnnotations;

namespace Real_Estate_Management_System.Models
{
    public class PropertyRight
    {
        [Key]
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}