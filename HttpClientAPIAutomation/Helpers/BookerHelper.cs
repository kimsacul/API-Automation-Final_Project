using Newtonsoft.Json;
using HttpClientAPIAutomation.Tests.TestData;
using HttpClientAPIAutomation.Resources;
using HttpClientAPIAutomation.DataModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientAPIAutomation.Helpers
{
    public class BookerHelper
    {
        private HttpClient httpClient;

        public async Task<HttpResponseMessage> PostBooker()
        {
            //assign
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = JsonConvert.SerializeObject(GenerateBooker.newBooker());
            var postRequest = new StringContent(request, Encoding.UTF8, "application/json");

            //act
            var postResponse = await httpClient.PostAsync(Endpoints.GetUrl(Endpoints.BookerEndpoint), postRequest);

            return postResponse;
        }

        public async Task<HttpResponseMessage> GetBooker(int bookingId)
        {
            //assign
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            //act
            var getResponse = await httpClient.GetAsync(Endpoints.GetUri(Endpoints.BookerEndpoint) + "/" + bookingId);

            return getResponse;
        }

        public async Task<HttpResponseMessage> PutBooker(BookerJsonModel booking, int bookingId)
        {
            //assign
            var token = await PostToken();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Cookie", "token=" + token);

            var request = JsonConvert.SerializeObject(booking);
            var putRequest = new StringContent(request, Encoding.UTF8, "application/json");

            //act
            var putResponse = await httpClient.PutAsync(Endpoints.GetUrl(Endpoints.BookerEndpoint + "/" + bookingId), putRequest);

            return putResponse;
        }

        public async Task<HttpResponseMessage> DeleteBooker(int bookingId)
        {
            //assign
            var token = await PostToken();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Cookie", "token=" + token);

            //act
            var deleteResponse = await httpClient.DeleteAsync(Endpoints.GetUri(Endpoints.BookerEndpoint) + "/" + bookingId);

            return deleteResponse;
        }

        private async Task<string> PostToken()
        {
            //assign
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = JsonConvert.SerializeObject(GenerateAuth.userCredentials());
            var postRequest = new StringContent(request, Encoding.UTF8, "application/json");

            //act
            var postResponse = await httpClient.PostAsync(Endpoints.GetUrl(Endpoints.TokenEndpoint), postRequest);
            var token = JsonConvert.DeserializeObject<TokenJsonModel>(postResponse.Content.ReadAsStringAsync().Result);

            return token.Token;
        }
    }
}
