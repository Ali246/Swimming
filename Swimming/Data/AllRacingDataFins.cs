using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swimming.Data
{
    public class AllRacingDataFins
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CaptainOrOrganization { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Race21 { get; set; }
        public int? Race22 { get; set; }
        public int? Race23 { get; set; }
        public int? Race24 { get; set; }
        public int? Race25 { get; set; }
    }
}
