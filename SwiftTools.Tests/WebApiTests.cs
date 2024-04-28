using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using SwiftTools.WebApi;
using SwiftTools.WebApi.ViewModel;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTools.Tests
{
    public class WebApiTests
    {
        private StringContent GetJsonContent(string content)
        {
            var json = JsonConvert.SerializeObject(new MT101DataModel() { Content = content });
            return new StringContent(json, UTF8Encoding.UTF8, "application/json");
        }

        private async Task<string> SendAndReceive(string uriString, string contentString)
        {
            var factory = new WebApplicationFactory<Startup>();
            var Client = factory.CreateClient();
            var result = await Client.PostAsync(uriString, GetJsonContent(contentString));
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            return  await content.ReadAsStringAsync();
        }

        [Test]
        public async Task ValidateMT101_Correct_Test()
        {            
            var data = await SendAndReceive("http://localhost/api/swift/validate-format-mt101", "{1:}{2:}{3:}{4:\r\n-}{5:}}");
            Assert.AreEqual("0", data);
        }
      
        [Test]
        public async Task ValidateMT101_EmptyContent_Test()
        {
            var data = await SendAndReceive("http://localhost/api/swift/validate-format-mt101", "");
            Assert.AreEqual("1", data);
        }
      
        [Test]
        public async Task ValidateMT101_IncorrectBlock4_Test()
        {
            var data = await SendAndReceive("http://localhost/api/swift/validate-format-mt101", "{4: { -}");
            Assert.AreEqual("2", data);
        }

        [Test]
        public async Task ValidateMT101_EmptyLine_Test()
        {
            var data = await SendAndReceive("http://localhost/api/swift/validate-format-mt101", "{1:}{2:}{3:}{4:\r\n\r\n\r\n-}{5:}}");
            Assert.AreEqual("3", data);
        }

        [Test]
        public async Task ValidateMT101_IncorrectLines_Test()
        {
            var data = await SendAndReceive("http://localhost/api/swift/validate-format-mt101", "{1:}{2:}{3:}{4:\r\n-\r\n-}{5:}}");
            Assert.AreEqual("4", data);
        }
    }
}
