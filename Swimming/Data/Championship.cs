using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
{
    public class Championship
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ChampionshipName { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
