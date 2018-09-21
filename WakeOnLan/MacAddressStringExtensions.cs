using System;
using System.Text.RegularExpressions;

namespace Therezin.WakeOnLan
{
    public static class MacAddressStringExtensions
    {
        const string MacPattern = @"([0-9a-fA-F]{2}[-:.]?){5}[0-9a-fA-F]{2}|([0-9a-fA-F]{4}[-:.]){2}[0-9a-fA-F]{4}";

        public static bool ValidateMacAddress(this string inputString)
        {
            Regex Comparer = new Regex(MacPattern, RegexOptions.IgnoreCase);
            return Comparer.IsMatch(inputString);
        }

        public static byte[] ToMacAddress(this string inputString)
        {
            // Validate and fail early.
            if (!inputString.ValidateMacAddress())
            {
                throw new ArgumentException(string.Format("{0} is not a valid MAC address.", inputString));
            }

            // Remove separators. Address is now 12 hex characters.
            string CleanAddress = Regex.Replace(inputString, "[-:.]", "");

            byte[] Bytes = new byte[6];
            int ByteCounter = 0;
            for (int i = 0; i < 12; i = i + 2)
            {
                Bytes[ByteCounter] = byte.Parse(CleanAddress.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                ByteCounter++;
            }

            return Bytes;
        }
    }
}
