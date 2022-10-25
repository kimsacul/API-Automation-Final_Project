using Newtonsoft.Json;

namespace HttpClientAPIAutomation.DataModels
{
    public class BookerJsonModel
    {
        [JsonProperty("firstname")]
        public string Firstname { get; set; } = default!;

        [JsonProperty("lastname")]
        public string Lastname { get; set; } = default!;

        [JsonProperty("totalprice")]
        public long Totalprice { get; set; } = default!;

        [JsonProperty("depositpaid")]
        public bool Depositpaid { get; set; } = default!;

        [JsonProperty("bookingdates")]
        public Bookingdates Bookingdates { get; set; } = default!;

        [JsonProperty("additionalneeds")]
        public string Additionalneeds { get; set; } = default!;
    }

    public class Bookingdates
    {
        [JsonProperty("checkin")]
        public DateTime Checkin { get; set; } = default!;

        [JsonProperty("checkout")]
        public DateTime Checkout { get; set; } = default!;
    }
}
