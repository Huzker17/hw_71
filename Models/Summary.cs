using System;
using System.Collections.Generic;
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
        public DateTime BirthDay { get; set; }
        public DateTime PostTime { get; set; }
        public DateTime UpdateTime { get; set; }


        public bool Gender { get; set; }
        public string Citizen { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }


    }
}
