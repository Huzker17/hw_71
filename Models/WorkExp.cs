using System;
using System.Text.Json.Serialization;

namespace hh.Models
{
    public class WorkExp
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