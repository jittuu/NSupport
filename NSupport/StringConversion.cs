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

        /// <summary>
        /// Return converted <see cref="Int32"/>.
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>        
        /// <returns>A converted <see cref="Int32"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="source"/> is null.</exception>
        /// <exception cref="FormatException">Throws when <paramref name="source"/> is not correct format.</exception>
        /// <exception cref="OverflowException">Throws when <paramref name="source"/> represents a number less than <see cref="Int32.MinValue"/> or greater than <see cref="Int32.MaxValue"/>.</exception>
        public static int ToInteger(this string source) {
            return int.Parse(source);
        }

        /// <summary>
        /// Return converted <see cref="Int32"/>.
        /// </summary>
        /// <param name="source">A <see cref="string"/> instance.</param>
        /// <param name="style">A <see cref="NumberStyles" /> to parse against <paramref name="source"/>.</param>
        /// <returns>Return converted <see cref="Int32"/>.</returns>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="source"/> is null.</exception>
        /// <exception cref="FormatException">Throws when <paramref name="source"/> is not correct format.</exception>
        /// <exception cref="OverflowException">Throws when <paramref name="source"/> represents a number less than <see cref="Int32.MinValue"/> or greater than <see cref="Int32.MaxValue"/>.</exception>
        /// <exception cref="ArgumentException">Throws when <paramref name="style"/> is not valid <see cref="NumberStyles"/></exception>
        public static int ToInteger(this string source, NumberStyles style) {
            return int.Parse(source, style);
        }
    }
}
