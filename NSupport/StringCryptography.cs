namespace NSupport {
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Provides extension methods to <see cref="string"/> for Crytography services.
    /// </summary>
    public static class StringCryptography {
        /// <summary>
        /// Hash the given <paramref name="source"/> and <paramref name="salt"/> with SHA256 algorithm.
        /// </summary>
        /// <param name="source">An instance of <see cref="String"/>.</param>
        /// <param name="salt">An instance of <see cref="String"/> for salting before hashing.</param>
        /// <returns>A hash string.</returns>
        public static string ToHashString(this string source, string salt) {
            var sourceBytes = Encoding.UTF8.GetBytes(source);
            var saltBytes = Encoding.UTF8.GetBytes(salt);
                        
            var sourceWithSalt = sourceBytes.Concat(saltBytes).ToArray();
            var hash = new SHA256Managed().ComputeHash(sourceWithSalt);

            return Convert.ToBase64String(hash);
        }
    }
}
