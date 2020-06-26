using System;
using System.Collections.Generic;

namespace CrunchBaseAPITest.Models
{
    public partial class IndustryList
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? IndustryId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Industry Industry { get; set; }
    }
}
