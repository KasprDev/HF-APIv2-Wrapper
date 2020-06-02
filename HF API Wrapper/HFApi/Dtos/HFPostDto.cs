using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFApi.Dtos
{
    class HFPostDto
    {
        [JsonProperty("author")]
        public HFUserDto Author { get; set; }

        [JsonProperty("pid")]
        public long PostID { get; set; }

        [JsonProperty("tid")]
        public long ThreadID { get; set; }

        [JsonProperty("fid")]
        public int ForumID { get; set; }

        [JsonProperty("dateline")]
        public long Dateline { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("edituid")]
        public int EditedBy { get; set; }

        [JsonProperty("edittime")]
        public long EditTime { get; set; }

        [JsonProperty("editreason")]
        public string EditReason { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
