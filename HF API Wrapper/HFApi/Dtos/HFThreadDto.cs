using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFApi.Dtos
{
    class HFThreadDto
    {
        [JsonProperty("tid")]
        public long ThreadID { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("dateline")]
        public long Dateline { get; set; }

        [JsonProperty("firstpost")]
        public HFPostDto Post {get; set;}

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }
}
