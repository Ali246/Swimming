using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
{
    public class Points
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int No { get; set; }
        [Required]
        public int point { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
