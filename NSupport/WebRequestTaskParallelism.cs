namespace NSupport {
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
        /// <returns>The created <see cref="Task{TResult}"/> that represents the asynchronous operation.</returns>
        public static Task<WebResponse> GetResponseAsync(this WebRequest request) {
            return request.GetResponseAsync(null);
        }

        /// <summary>
        ///  When overridden in a descendant class, begins an asynchronous request for an Internet resource.
        /// </summary>
        /// <param name="request">A <see cref="WebRequest"/> instance.</param>
        /// <param name="state">An object containing state information for this asynchronous request.</param>
        /// <returns>The created <see cref="Task{TResult}"/> that represents the asynchronous operation.</returns>
        public static Task<WebResponse> GetResponseAsync(this WebRequest request, object state) {
            return Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, state);
        }
    }
}