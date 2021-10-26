using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Models
{
    public class Summary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Salary { get; set; }
        public string Citizen { get; set; }
        public bool HaveExperinece { get; set; }
        public string TgName { get; set; }
        public string LinkedInUrl { get; set; }
        public string FacebookUrl { get; set; }
        public ICollection<WorkExp> Works { get; set; }
        public ICollection<Graduation> Graduations { get; set; }
        public ICollection<Certificate> Certificates { get; set; }

        public string Category { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }

        public Summary()
        {
            Works = new Collection<WorkExp>();
            Graduations = new Collection<Graduation>();
            Certificates = new Collection<Certificate>();
        }

    }
}
