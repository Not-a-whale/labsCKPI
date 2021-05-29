using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Real_Estate_Management_System.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<PropertyRight> PropertyRights { get; set; } = new List<PropertyRight>();
    }
}