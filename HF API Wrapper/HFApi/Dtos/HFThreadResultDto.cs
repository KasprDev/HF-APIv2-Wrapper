using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFApi.Dtos
{
    class HFThreadResultDto
    {
        [JsonProperty("threads")]
        public IList<HFThreadDto> Threads { get; set; }
    }
}
