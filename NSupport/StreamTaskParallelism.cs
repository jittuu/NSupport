namespace NSupport {
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides Task Parallel Library usage to wrap Asynchronous Programming Model pattern.
    /// </summary>
    public static class StreamTaskParallelism {
        /// <summary>
        /// Begins an asynchronous read operation.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> instance.</param>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>The created <see cref="Task{WebResponse}"/> that represents the asynchronous operation.</returns>
        public static Task<int> ReadAsync(this Stream stream, byte[] buffer, int offset, int count) {
            return stream.ReadAsync(buffer, offset, count, null);
        }

        /// <summary>
        /// Begins an asynchronous read operation.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> instance.</param>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing data read from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="state">An object containing state information for this asynchronous operation.</param>
        /// <returns>The created <see cref="Task{WebResponse}"/> that represents the asynchronous operation.</returns>
        public static Task<int> ReadAsync(this Stream stream, byte[] buffer, int offset, int count, object state) {
            return Task.Factory.FromAsync<byte[], int, int, int>(stream.BeginRead, stream.EndRead, buffer, offset, count, state);
        }

        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The byte offset in buffer from which to begin writing.</param>
        /// <param name="count">The maximum number of bytes to write.</param>        
        /// <returns>The created <see cref="Task{WebResponse}"/> that represents the asynchronous operation.</returns>
        public static Task WriteAsync(this Stream stream, byte[] buffer, int offset, int count) {
            return stream.WriteAsync(buffer, offset, count, null);
        }

        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The byte offset in buffer from which to begin writing.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        /// <param name="state">An object containing state information for this asynchronous operation.</param>
        /// <returns>The created <see cref="Task{WebResponse}"/> that represents the asynchronous operation.</returns>
        public static Task WriteAsync(this Stream stream, byte[] buffer, int offset, int count, object state) {
            return Task.Factory.FromAsync<byte[], int, int>(stream.BeginWrite, stream.EndWrite, buffer, offset, count, state);
        }
    }
}
