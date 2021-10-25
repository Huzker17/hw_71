using hh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.ViewModels
{
    public class SummaryViewModel
    {
        public Summary Summary { get; set; }
        public List<WorkExp> ListOfWorks { get; set; }
    }
}
