namespace NSupport.Test {
    using System;
    using System.IO;
    using System.Text;
    using Xunit;

    public class StreamReaderTaskParallelismTest {
        [Fact]
        public void Test_ReadToEndAsync() {
            var fileName = "test.txt";
            File.Delete(fileName);
                        
            using (var fs = File.Open(fileName, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(fs)) {
                writer.Write(new string('A', 1024));
            }

            AssertReadToEndAsync(fileName);
        }

        private static void AssertReadToEndAsync(string fileName) {
            using (var fs = File.Open(fileName, FileMode.Open))
            using (var reader = new StreamReader(fs)) {
                var expected = reader.ReadToEnd();
                reader.BaseStream.Position = 0;

                reader
                    .ReadToEndAsync()
                    .ContinueWith(t => {
                        var actual = t.Result;
                        Assert.Equal(expected, actual);
                    })
                    .Wait();
            }
        }

        [Fact]
        public void Test_ReadToEndAsync_with_Encoding() {
            var fileName = "test_encoding.txt";
            File.Delete(fileName);

            using (var fs = File.Open(fileName, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(fs, Encoding.UTF8)) {
                writer.Write(new string('A', 1024));
            }

            using (var fs = File.Open(fileName, FileMode.Open))
            using (var reader = new StreamReader(fs)) {
                var expected = reader.ReadToEnd();
                reader.BaseStream.Position = 0;

                reader
                    .ReadToEndAsync()
                    .ContinueWith(t => {
                        var actual = t.Result;
                        Assert.Equal(expected, actual);
                    })
                    .Wait();
            }
        }

        [Fact]
        public void Test_ReadToEndAsync_with_MemoryStream() {
            var expected = "data for stream";
            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream)) {
                    writer.Write(expected);
                    writer.Flush();

                    stream.Position = 0;

                    using (var reader = new StreamReader(stream)) {
                        reader
                            .ReadToEndAsync()
                            .ContinueWith(t => {
                                var actual = t.Result;
                                Assert.Equal(expected, actual);
                            })
                            .Wait();
                    }
                }
            }
        }

        [Fact]
        public void Test_ReadToEndAysnc_with_exception() {
            var fileName = "test_exception.txt";
            File.Delete(fileName);

            using (var fs = File.Open(fileName, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(fs)) {
                writer.Write(new string('A', 1024));
            }

            using (var fs = File.Open(fileName, FileMode.Open))
            using (var reader = new StreamReader(fs)) {
                var expected = reader.ReadToEnd();
                reader.BaseStream.Position = 0;

                fs.Close();

                Assert.Throws<AggregateException>(() => {
                    var task = reader.ReadToEndAsync();
                    task.Wait();
                });
            }
        }
    }
}
