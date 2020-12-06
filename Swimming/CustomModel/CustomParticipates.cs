using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.CustomModel
{
    public class CustomParticipates
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public int Gender { get; set; }
        public string GenderName { get; set; }
        public string CaptainOrOrganization { get; set; }
        public int TypeOfParticipant { get; set; }
        public string TypeOfParticipantName { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
