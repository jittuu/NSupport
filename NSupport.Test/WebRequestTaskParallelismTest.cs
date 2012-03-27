namespace NSupport.Test {    
    using Xunit;
    using System.Net;
    using System.IO;

    public class WebRequestTaskParallelismTest {
        [Fact]
        public void Test_GetResponseAsync() {
            // Create a request for the URL. 		
            var request = WebRequest.Create("http://www.contoso.com/default.html");

            request.GetResponseAsync()
                        .ContinueWith(t => {
                            using (var stream = t.Result.GetResponseStream())
                            using (var reader = new StreamReader(stream)) {
                                var responseFromServer = reader.ReadToEnd();
                                Assert.NotNull(responseFromServer);
                                Assert.NotEqual("", responseFromServer);
                            }
                        })
                        .Wait();
        }

        [Fact]
        public void Test_GetRequestStreamAsync() {
            // Create a request for the URL. 		
            var request = WebRequest.Create("http://www.contoso.com/default.html");
            request.Method = "POST";
            request.GetRequestStreamAsync()
                        .ContinueWith(t => {
                            Assert.NotNull(t.Result);
                        })
                        .Wait();
        }
    }
}
