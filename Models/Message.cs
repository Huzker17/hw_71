using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public DateTime SentTime { get; set; }
        public User User { get; set; }
        public string CompId { get; set; }
        public User Comp { get; set; }
    }
}
