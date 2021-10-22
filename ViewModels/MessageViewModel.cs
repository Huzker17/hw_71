using hh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.ViewModels
{
    public class MessageViewModel
    {
        public Vacancy Vac { get; set; }
        public List<Message> Messages { get; set; }
    }
}
