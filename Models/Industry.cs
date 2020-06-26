using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class Industry
    {
        public Industry()
        {
            IndustryList = new HashSet<IndustryList>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IndustryList> IndustryList { get; set; }
    }
}
