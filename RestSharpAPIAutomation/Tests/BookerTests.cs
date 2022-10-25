using RestSharp;
using RestSharpAPIAutomation.DataModels;
using RestSharpAPIAutomation.Resources;
using RestSharpAPIAutomation.Helpers;
using RestSharpAPIAutomation.Tests.TestData;

using System.Net;
using System.Net.Http.Headers;

namespace RestSharpAPIAutomation.Tests
{
    [TestClass]
    public class BookerTests : ApiBaseTest
    {
        private static bool cleanUp = true;

        [TestInitialize]
        public async Task TestInitialize()
        {
            var helperResponse = await BookerHelper.PostBooker(RestClient);
            BookingDetails = helperResponse.Data;

            Assert.AreEqual(HttpStatusCode.OK, helperResponse.StatusCode);
        }

        public async Task TestCleanUp()
        {
            if (cleanUp == true) { await BookerHelper.DeleteBooker(RestClient, BookingDetails.Bookingid); }
        }

        [TestMethod]
        public async Task CreateBooker()
        {
            var createdData = await BookerHelper.GetBooker(RestClient, BookingDetails.Bookingid);
            var bookerData = GenerateBooker.newBooker();

            Assert.AreEqual(bookerData.Firstname, createdData.Data.Firstname);
            Assert.AreEqual(bookerData.Lastname, createdData.Data.Lastname);
            Assert.AreEqual(bookerData.Totalprice, createdData.Data.Totalprice);
            Assert.AreEqual(bookerData.Depositpaid, createdData.Data.Depositpaid);
            Assert.AreEqual(bookerData.Bookingdates.Checkin, createdData.Data.Bookingdates.Checkin);
            Assert.AreEqual(bookerData.Bookingdates.Checkout, createdData.Data.Bookingdates.Checkout);
            Assert.AreEqual(bookerData.Additionalneeds, createdData.Data.Additionalneeds);
        }

        [TestMethod]
        public async Task UpdateBooker()
        {
            var createdData = await BookerHelper.GetBooker(RestClient, BookingDetails.Bookingid);
            var bookerData = new BookerJsonModel()
            {
                Firstname = "John",
                Lastname = "Smith",
                Totalprice = createdData.Data.Totalprice,
                Depositpaid = createdData.Data.Depositpaid,
                Bookingdates = createdData.Data.Bookingdates,
                Additionalneeds = createdData.Data.Additionalneeds
            };
            var putResponse = await BookerHelper.PutBooker(RestClient, bookerData, BookingDetails.Bookingid);

            Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode);

            var getResponse = await BookerHelper.GetBooker(RestClient, BookingDetails.Bookingid);

            Assert.AreEqual(bookerData.Firstname, getResponse.Data.Firstname);
            Assert.AreEqual(bookerData.Lastname, getResponse.Data.Lastname);
            Assert.AreEqual(bookerData.Totalprice, getResponse.Data.Totalprice);
            Assert.AreEqual(bookerData.Depositpaid, getResponse.Data.Depositpaid);
            Assert.AreEqual(bookerData.Bookingdates.Checkin, getResponse.Data.Bookingdates.Checkin);
            Assert.AreEqual(bookerData.Bookingdates.Checkout, getResponse.Data.Bookingdates.Checkout);
            Assert.AreEqual(bookerData.Additionalneeds, getResponse.Data.Additionalneeds);
        }

        [TestMethod]
        public async Task DeleteBooker()
        {
            var deleteResponse = await BookerHelper.DeleteBooker(RestClient, BookingDetails.Bookingid);
            cleanUp = false;

            Assert.AreEqual(HttpStatusCode.Created, deleteResponse.StatusCode);
        }

        [TestMethod]
        public async Task GetInvalidBooker()
        {
            int number = 553249857;
            var getResponse = await BookerHelper.GetBooker(RestClient, number);

            Assert.AreEqual(HttpStatusCode.NotFound, getResponse.StatusCode);
        }
    }
}