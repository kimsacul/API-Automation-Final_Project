using Newtonsoft.Json;

namespace HttpClientAPIAutomation.DataModels
{
    public class TokenJsonModel
    {
        [JsonProperty("token")]
        public string Token { get; set; } = default!;
    }
}
