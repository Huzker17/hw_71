using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Requirments { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Category { get; set; }
        public bool Vision { get; set; }

    }
}
