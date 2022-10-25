using Newtonsoft.Json;

namespace RestSharpAPIAutomation.DataModels
{
    public class TokenAuthJsonModel
    {
        [JsonProperty("username")]
        public string Username { get; set; } = default!;

        [JsonProperty("password")]
        public string Password { get; set; } = default!;
    }
}
