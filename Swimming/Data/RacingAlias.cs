using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
    {
        public class RacingAlias
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string RacingName { get; set; }
            [Required]
            public string RacingType { get; set; }
            public DateTime? DeleteDate { get; set; }
        }
    }

