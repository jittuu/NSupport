namespace NSupport {
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides Task Parallel Library usage to wrap Asynchronous Programming Model pattern.
    /// </summary>
    public static class WebRequestTaskParallelism {
        /// <summary>
        /// When overridden in a descendant class, begins an asynchronous request for an Internet resource.
        /// </summary>
        /// <param name="request">A <see cref="WebRequest"/> instance.</param>
        /// <returns>The created <see cref="Task{WebResponse}"/> that represents the asynchronous operation.</returns>
        public static Task<WebResponse> GetResponseAsync(this WebRequest request) {
            return Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, state: null);
        }

        /// <summary>
        /// When overridden in a descendant class, provides an asynchronous version of the <see cref="WebRequest.BeginGetRequestStream"/> method.
        /// </summary>
        /// <param name="request">A <see cref="WebRequest"/> instance.</param>
        /// <returns>The created <see cref="Task{Stream}"/> that represents the asynchronous operation.</returns>
        public static Task<Stream> GetRequestStreamAsync(this WebRequest request) {
            return Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, state: null);
        }
    }
}