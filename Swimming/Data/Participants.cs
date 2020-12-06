using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
{
    public class Participants
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? Birthday { get; set; }
        [Required]
        public int Gender { get; set; }
        public string GenderName { get; set; }
        public string CaptainOrOrganization { get; set; }
        [Required]
        public int CaptainOrOrganizationId { get; set; }
        public int TypeOfParticipant { get; set; }
        public string TypeOfParticipantName { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
