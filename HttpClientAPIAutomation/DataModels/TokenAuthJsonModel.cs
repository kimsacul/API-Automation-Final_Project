using Newtonsoft.Json;

namespace HttpClientAPIAutomation.DataModels
{
    public class TokenAuthJsonModel
    {
        [JsonProperty("username")]
        public string Username { get; set; } = default!;

        [JsonProperty("password")]
        public string Password { get; set; } = default!;
    }
}
