using Newtonsoft.Json;

namespace RestSharpAPIAutomation.DataModels
{
    public class BookerIdJsonModel
    {
        [JsonProperty("bookingid")]
        public int Bookingid { get; set; } = default!;

        [JsonProperty("booking")]
        public BookerJsonModel Booking { get; set; } = default!;
    }
}
