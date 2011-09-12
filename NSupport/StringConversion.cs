namespace NSupport {
    using System;
    using System.Globalization;

    /// <summary>
    /// Provides extension methods for <see cref="String"/> for conversion and checking to other types.
    /// </summary>
    public static class StringConversion {

        /// <summary>
        /// Return whether the provided <see cref="String"/> is number.
        /// It call overload method with this combination of <see cref="NumberStyles"/> (NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;).
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <returns>Returns true if the <see cref="String"/> can be convert to number, otherwise false.</returns>
        public static bool IsNumber(this string source) {
            var style = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | 
                NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | 
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;

            return source.IsNumber(style);
        }

        /// <summary>
        /// Return whether the provided <see cref="String"/> is number with provided <see cref=" NumberStyles"/>.
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to check against <paramref name="source"/>.</param>
        /// <returns>Returns true if the <see cref="String"/> can be convert to number with provided <see cref=" NumberStyles"/>, otherwise false.</returns>
        public static bool IsNumber(this string source, NumberStyles style) {
            decimal parseValue;
            return decimal.TryParse(source, style, CultureInfo.CurrentCulture, out parseValue);
        }
    }
}
