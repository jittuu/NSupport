namespace NSupport {
    using System;
    using System.IO;
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
            Guard.ArgumentNotNull("source", source);
            Guard.ArgumentNotNull("salt", salt);

            var sourceBytes = Encoding.UTF8.GetBytes(source);
            var saltBytes = Encoding.UTF8.GetBytes(salt);
                        
            var sourceWithSalt = sourceBytes.Concat(saltBytes).ToArray();
            var hash = new SHA256Managed().ComputeHash(sourceWithSalt);

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Encrypt the string with Rijndael Symmetric Algorithm
        /// </summary>
        /// <param name="source">The <see cref="String"/> to encrypt.</param>
        /// <param name="sharedSecret">A shared secret.</param>
        /// <returns>Encrypted <see cref="String"/>.</returns>
        public static string Encrypt(this string source, string sharedSecret) {
            Guard.ArgumentNotNull("source", source);
            Guard.StringNotEmpty("source", source);

            Guard.ArgumentNotNull("sharedSecret", sharedSecret);
            Guard.StringNotEmpty("sharedSecret", sharedSecret);

            // Create an Rijndael object with the specified key and IV.
            using (Rijndael rijndael = CreateRijndaelManaged(sharedSecret)) {

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream()) {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)) {

                            //Write all data to the stream.
                            swEncrypt.Write(source);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }
        
        /// <summary>
        /// Decrypt the string with Rijndael Symmetric Algorithm
        /// </summary>
        /// <param name="source">The <see cref="String"/> to decrypt.</param>
        /// <param name="sharedSecret">A shared secret.</param>
        /// <returns>Decrypted <see cref="String"/>.</returns>
        public static string Decrypt(this string source, string sharedSecret) {
            Guard.ArgumentNotNull("source", source);
            Guard.StringNotEmpty("source", source);
            Guard.ArgumentNotNull("sharedSecret", sharedSecret);
            Guard.StringNotEmpty("sharedSecret", sharedSecret);

            // Create an Rijndael object with the specified key and IV.
            using (var rijndael = CreateRijndaelManaged(sharedSecret)) {                
                // Create a Decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

                byte[] buffer = Convert.FromBase64String(source);                
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(buffer)) {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt)) {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private static RijndaelManaged CreateRijndaelManaged(string sharedSecret) {
            var salt = Encoding.ASCII.GetBytes("fc24b719cd7FBFB8B7C628E");
            var rijndael = new RijndaelManaged();
            var key = new Rfc2898DeriveBytes(sharedSecret, salt);

            rijndael.Key = key.GetBytes(rijndael.KeySize / 8);
            rijndael.IV = key.GetBytes(rijndael.BlockSize / 8);

            return rijndael;
        }
    }
}
