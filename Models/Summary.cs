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
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool Gender { get; set; }
        public string Citizen { get; set; }
        public bool HaveExperinece { get; set; }
        public ICollection<WorkExp> Works { get; set; }
        public List<string> GraduationLvl { get; set; }
        public ICollection<Graduation> Graduations { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public Summary()
        {
            Works = new Collection<WorkExp>();
            Graduations = new Collection<Graduation>();
        }

    }
}
