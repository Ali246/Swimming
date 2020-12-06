using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
{
    public class ChampionshipDetails
    {
        [Key]
        public int Id { get; set; }
        public int ChampionshipId { get; set; }
        public int ParticipantId { get; set; }    
    }
}
