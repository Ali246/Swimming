using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
{
    public class PartiWLastResult
    {
        public int Id { get; set; }
        public string CaptainOrOrganization { get; set; }
        public DateTime? Birthday { get; set; }
        public string Name { get; set; }
        public double Result { get; set; }
        public string GenderName { get; set; }
    }
}
