using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Models
{
    public class User : IdentityUser
    {
        public string Photo { get; set; }
        public ICollection<Summary> Summaries { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
        public User()
        {
            Summaries = new Collection<Summary>();
            Vacancies = new Collection<Vacancy>();
        }
    }
}
