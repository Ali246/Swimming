using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
{
    public class CaptainOrOrganization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CaptainOrOrganizName { get; set; }
        [Required]
        public string Mobile { get; set; }
        public int City { get; set; }
        public string CityName { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
