namespace NSupport {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides Task Parallel Library usage to wrap Asynchronous Programming Model pattern.
    /// </summary>
    public static class StreamReaderTaskParallelism {
        /// <summary>
        /// Reads all characters from the current position to the end of the <see cref="string"/> asynchronously and returns them as a single <see cref="string"/>.
        /// </summary>
        /// <param name="reader">An instance of <see cref="StreamReader"/>.</param>
        /// <returns>A task that represents the asynchronous read operation. The value of the Task parameter contains a string with the characters from the current position to the end of the string.</returns>
        public static Task<string> ReadToEndAsync(this StreamReader reader) {
            var stream = reader.BaseStream;

            if (stream is MemoryStream) {
                return Task.Factory.StartNew<string>(() => reader.ReadToEnd());
            }

            var ts = new TaskCompletionSource<string>();

            var writer = new MemoryStream();
            var enumerator = EnumerateReadAsync(stream, writer).GetEnumerator();
            Action action = null;
            action = delegate {
                try {
                    if (enumerator.MoveNext()) {
                        enumerator.Current.ContinueWith(delegate { action(); });
                    }
                    else {
                        using (var r = new StreamReader(writer)) {
                            writer.Position = 0;
                            var result = r.ReadToEnd();
                            ts.TrySetResult(result);
                        }
                        enumerator.Dispose();
                    }
                }
                catch (Exception ex) {
                    ts.TrySetException(ex);
                }
                
            };
            action();

            return ts.Task;
        }

        private static IEnumerable<Task<int>> EnumerateReadAsync(Stream stream, MemoryStream writer) {            
            var buffer = new byte[4 * 1024];

            while (true) {
                var pendingRead = stream.ReadAsync(buffer, 0, buffer.Length);
                yield return pendingRead;

                int bytesRead = pendingRead.Result;
                if (bytesRead <= 0) break;

                writer.Write(buffer, 0, bytesRead);
            }
        }
    }
}