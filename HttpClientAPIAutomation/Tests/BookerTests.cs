using HttpClientAPIAutomation.DataModels;
using HttpClientAPIAutomation.Resources;
using HttpClientAPIAutomation.Helpers;
using HttpClientAPIAutomation.Tests.TestData;

using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HttpClientAPIAutomation.Tests
{
    [TestClass]
    public class BookerTests : ApiBaseTest
    {
        private BookerHelper bookerHelper;
        private static int bookerCleanUpId = 0;

        [TestInitialize]
        public async Task TestInitialize()
        {
            bookerHelper = new BookerHelper();
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            if (bookerCleanUpId != 0) { await bookerHelper.DeleteBooker(bookerCleanUpId); }
        }

        [TestMethod]
        public async Task CreateBooker()
        {
            var postRequest = await bookerHelper.PostBooker();
            var postResponse = JsonConvert.DeserializeObject<BookerIdJsonModel>(postRequest.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(HttpStatusCode.OK, postRequest.StatusCode);

            var getRequest = await bookerHelper.GetBooker(postResponse.Bookingid);
            var getResponse = JsonConvert.DeserializeObject<BookerJsonModel>(getRequest.Content.ReadAsStringAsync().Result);
            var bookerData = GenerateBooker.newBooker();

            bookerCleanUpId = postResponse.Bookingid;

            Assert.AreEqual(bookerData.Firstname, getResponse.Firstname);
            Assert.AreEqual(bookerData.Lastname, getResponse.Lastname);
            Assert.AreEqual(bookerData.Totalprice, getResponse.Totalprice);
            Assert.AreEqual(bookerData.Depositpaid, getResponse.Depositpaid);
            Assert.AreEqual(bookerData.Bookingdates.Checkin, getResponse.Bookingdates.Checkin);
            Assert.AreEqual(bookerData.Bookingdates.Checkout, getResponse.Bookingdates.Checkout);
            Assert.AreEqual(bookerData.Additionalneeds, getResponse.Additionalneeds);
        }

        [TestMethod]
        public async Task UpdateBooker()
        {
            var postRequest = await bookerHelper.PostBooker();
            var postResponse = JsonConvert.DeserializeObject<BookerIdJsonModel>(postRequest.Content.ReadAsStringAsync().Result);

            var getRequest = await bookerHelper.GetBooker(postResponse.Bookingid);
            var getResponse = JsonConvert.DeserializeObject<BookerJsonModel>(getRequest.Content.ReadAsStringAsync().Result);
            var bookerDataModified = new BookerJsonModel()
            {
                Firstname = "John",
                Lastname = "Smith",
                Totalprice = getResponse.Totalprice,
                Depositpaid = getResponse.Depositpaid,
                Bookingdates = getResponse.Bookingdates,
                Additionalneeds = getResponse.Additionalneeds
            };
            var putRequest = await bookerHelper.PutBooker(bookerDataModified, postResponse.Bookingid);
            var putResponse = JsonConvert.DeserializeObject<BookerJsonModel>(putRequest.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(HttpStatusCode.OK, putRequest.StatusCode);

            var getRequestModified = await bookerHelper.GetBooker(postResponse.Bookingid);
            var getResponseModified = JsonConvert.DeserializeObject<BookerJsonModel>(getRequestModified.Content.ReadAsStringAsync().Result);

            bookerCleanUpId = postResponse.Bookingid;

            Assert.AreEqual(bookerDataModified.Firstname, getResponseModified.Firstname);
            Assert.AreEqual(bookerDataModified.Lastname, getResponseModified.Lastname);
            Assert.AreEqual(bookerDataModified.Totalprice, getResponseModified.Totalprice);
            Assert.AreEqual(bookerDataModified.Depositpaid, getResponseModified.Depositpaid);
            Assert.AreEqual(bookerDataModified.Bookingdates.Checkin, getResponseModified.Bookingdates.Checkin);
            Assert.AreEqual(bookerDataModified.Bookingdates.Checkout, getResponseModified.Bookingdates.Checkout);
            Assert.AreEqual(bookerDataModified.Additionalneeds, getResponseModified.Additionalneeds);
        }

        [TestMethod]
        public async Task DeleteBooker()
        {
            var postRequest = await bookerHelper.PostBooker();
            var postResponse = JsonConvert.DeserializeObject<BookerIdJsonModel>(postRequest.Content.ReadAsStringAsync().Result);

            var deleteBooking = await bookerHelper.DeleteBooker(postResponse.Bookingid);

            Assert.AreEqual(HttpStatusCode.Created, deleteBooking.StatusCode);
        }

        [TestMethod]
        public async Task GetInvalidBooker()
        {
            int number = 553249857;
            var getRequest = await bookerHelper.GetBooker(number);

            Assert.AreEqual(HttpStatusCode.NotFound, getRequest.StatusCode);
        }
    }
}