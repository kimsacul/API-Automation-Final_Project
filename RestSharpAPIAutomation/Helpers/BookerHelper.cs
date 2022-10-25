using Newtonsoft.Json;
using RestSharp;
using RestSharpAPIAutomation.Tests.TestData;
using RestSharpAPIAutomation.Resources;
using RestSharpAPIAutomation.DataModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Helpers
{
    public class BookerHelper
    {
        public static async Task<RestResponse<BookerIdJsonModel>> PostBooker(RestClient client)
        {
            //arrange
            client = new RestClient();
            client.AddDefaultHeader("Accept","application/json");

            var postRequest = new RestRequest(Endpoints.BaseBookingMethod).AddJsonBody(GenerateBooker.newBooker());

            //act
            var postResponse = await client.ExecutePostAsync<BookerIdJsonModel>(postRequest);

            return postResponse;
        }

        public static async Task<RestResponse<BookerJsonModel>> GetBooker(RestClient client, int bookingId)
        {
            //arrange
            client = new RestClient();
            client.AddDefaultHeader("Accept","application/json");

            var getRequest = new RestRequest(Endpoints.GeneralEndpointById(bookingId));

            //act
            var getResponse = await client.ExecuteGetAsync<BookerJsonModel>(getRequest);

            return getResponse;
        }

        public static async Task<RestResponse<BookerJsonModel>> PutBooker(RestClient client, BookerJsonModel booking, int bookingId)
        {
            //arrange
            var token = await PostToken(client);
            client = new RestClient();
            client.AddDefaultHeader("Accept","application/json");
            client.AddDefaultHeader("Cookie","token=" + token);

            var putRequest = new RestRequest(Endpoints.GeneralEndpointById(bookingId)).AddJsonBody(booking);

            //act
            var putResponse = await client.ExecutePutAsync<BookerJsonModel>(putRequest);

            return putResponse;
        }

        public static async Task<RestResponse> DeleteBooker(RestClient client, int bookingId)
        {
            //arrange
            var token = await PostToken(client);
            client = new RestClient();
            client.AddDefaultHeader("Accept", "application/json");
            client.AddDefaultHeader("Cookie", "token=" + token);

            var deleteRequest = new RestRequest(Endpoints.GeneralEndpointById(bookingId));

            //act
            var deleteResponse = await client.DeleteAsync(deleteRequest);

            return deleteResponse;
        }

        private static async Task<string> PostToken(RestClient client)
        {
            //arrange
            client = new RestClient();
            client.AddDefaultHeader("Accept","application/json");

            var postRequest = new RestRequest(Endpoints.GenerateToken).AddJsonBody(GenerateAuth.userCredentials());

            //act
            var postResponse = await client.ExecutePostAsync<TokenJsonModel>(postRequest);
            var createdData = postResponse.Data;

            return createdData.Token;
        }
    }
}
