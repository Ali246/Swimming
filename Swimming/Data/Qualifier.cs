using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
{
    public class Qualifier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChampionId { get; set; }
        public int RacingId { get; set; }

    }
}
