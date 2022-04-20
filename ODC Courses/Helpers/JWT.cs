    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODC_Courses.Helpers
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issure { get; set; }
        public string Audience { get; set; }
        public double DurationInDays { get; set; }
    }
}
