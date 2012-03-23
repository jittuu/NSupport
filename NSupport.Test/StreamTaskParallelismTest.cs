namespace NSupport.Test {
    using System;
    using Xunit;
    using System.IO;
    using System.Text;

    public class StreamTaskParallelismTest {
        [Fact]
        public void Test_ReadAsync() {
            var expected = "data for stream";
            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream)) {
                    writer.Write(expected);
                    writer.Flush();

                    stream.Position = 0;
                    var buffer = new byte[stream.Length];

                    stream
                        .ReadAsync(buffer, 0, (int)stream.Length)
                        .ContinueWith(t => {
                            var actual = Encoding.UTF8.GetString(buffer, 0, t.Result);

                            Assert.Equal(expected, actual);
                        })
                        .Wait();
                }
            }
        }

        [Fact]
        public void Test_WriteAsync() {
            var expected = "data for stream";
            var buffer = Encoding.UTF8.GetBytes(expected);

            using (var stream = new MemoryStream()) {
                stream
                    .WriteAsync(buffer, 0, buffer.Length)
                    .ContinueWith(t => {
                        stream.Position = 0;
                        using (var reader = new StreamReader(stream)) {
                            var actual = reader.ReadToEnd();

                            Assert.Equal(expected, actual);
                        }
                    })
                    .Wait();
            }
        }
    }
}
