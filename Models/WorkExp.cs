using System;

namespace hh.Models
{
    public class WorkExp
    {
            public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Name { get; set; }
            public string Specialization { get; set; }
        public string Working { get; set; }
            public int SummaryId { get; set; }
            public Summary Summary { get; set; }

    }
}