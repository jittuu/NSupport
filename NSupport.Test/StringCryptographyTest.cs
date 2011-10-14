namespace NSupport.Test {
    using System;
    using Xunit;

    public class StringCryptographyTest {
        [Fact]
        public void Test_ToHashString_for_null_string() {
            string nullString = null;

            var ex = Assert.Throws<ArgumentNullException>(() => nullString.ToHashString("sfdsfd"));

            Assert.Equal("source", ex.ParamName);
        }

        [Fact]
        public void Test_ToHashString_for_null_salt() {
            var ex = Assert.Throws<ArgumentNullException>(() => "MySecret".ToHashString(null));

            Assert.Equal("salt", ex.ParamName);
        }

        [Fact]
        public void Test_ToHashString_should_not_return_same_value() {
            var password = "MySecret";
            var salt = Guid.NewGuid().ToString("N");

            var hashedPassword = password.ToHashString(salt);

            Assert.NotEqual(hashedPassword, password);
        }

        [Fact]
        public void Test_ToHashString_should_not_contain_original_values() {
            var password = "MySecret";
            var salt = Guid.NewGuid().ToString("N");

            var hashedPassword = password.ToHashString(salt);

            Assert.DoesNotContain(password, hashedPassword);
            Assert.DoesNotContain(salt, hashedPassword);
        }

        [Fact]
        public void Test_ToHashString_two_different_salt_should_generate_different_hash_string() {
            var password = "MySecret";
            var salt = Guid.NewGuid().ToString("N");
            var anotherSalt = Guid.NewGuid().ToString("N");

            var hashedPassword = password.ToHashString(salt);
            var anotherHashedPassword = password.ToHashString(anotherSalt);

            Assert.NotEqual(hashedPassword, anotherHashedPassword);
        }

        [Fact]
        public void Test_ToHashString_two_different_string_should_generate_different_hash_string() {
            var password = "MySecret1";
            var anotherPassword = "MySecret2";
            var salt = Guid.NewGuid().ToString("N");

            var hashedPassword = password.ToHashString(salt);
            var hashedAnotherPassword = anotherPassword.ToHashString(salt);

            Assert.NotEqual(hashedAnotherPassword, hashedPassword);
        }

        [Fact]
        public void Test_Encrypt_Decrypt() {
            var text = "This is my text!.";
            var sharedSecret = "sharedSecret";

            var encryptedText = text.Encrypt(sharedSecret);

            Assert.DoesNotContain(text, encryptedText);
            Assert.DoesNotContain(sharedSecret, encryptedText);

            var decryptedText = encryptedText.Decrypt(sharedSecret);

            Assert.Equal(text, decryptedText);
        }
    }
}
