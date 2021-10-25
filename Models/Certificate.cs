using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace hh.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("spec")]
        public string Specialization { get; set; }
        [JsonPropertyName("SummaryId")]

        public int SummaryId { get; set; }
        public Summary Summary { get; set; }
    }
}
