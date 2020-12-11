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
        public double? Race21 { get; set; }
        public double? Race22 { get; set; }
        public double? Race23 { get; set; }
        public double? Race24 { get; set; }
        public double? Race25 { get; set; }
    }
}
