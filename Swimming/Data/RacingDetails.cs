using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
{
    public class RacingDetails
    {
        [Key]
        public int Id { get; set; }        
        public int RacingId { get; set; }
        public int Year { get; set; }
    }
}
