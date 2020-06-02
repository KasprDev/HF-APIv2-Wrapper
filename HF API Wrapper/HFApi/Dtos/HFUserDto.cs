using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFApi.Dtos
{
    class HFUserDto
    {
        [JsonProperty("uid")]
        public long UserID { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("usergroup")]
        public int UserGroup { get; set; }

        [JsonProperty("displaygroup")]
        public int DisplayGroup { get; set; }

        [JsonProperty("additionalgroups")]
        public string AdditionalGroups { get; set; }

        [JsonProperty("postnum")]
        public int PostCount { get; set; }

        [JsonProperty("awards")]
        public string Awards { get; set; }

        [JsonProperty("myps")]
        public double Bytes { get; set; }

        [JsonProperty("avatar")]
        public string AvatarURL { get; set; }

        [JsonProperty("avatardimensions")]
        public string AvatarDimensions { get; set; }

        [JsonProperty("avatartype")]
        public string AvatarType { get; set; }

        [JsonProperty("usertitle")]
        public string UserTitle { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("timeonline")]
        public long TimeOnline { get; set; }

        [JsonProperty("reputation")]
        public int Popularity { get; set; }

        [JsonProperty("referrals")]
        public int Referrals { get; set; }

    }
}
