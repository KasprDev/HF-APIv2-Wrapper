using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HFApi.Dtos
{
    class HFPostResultDto
    {
        [JsonProperty("posts")]
        public IList<HFPostDto> Posts { get; set; }
    }
}
