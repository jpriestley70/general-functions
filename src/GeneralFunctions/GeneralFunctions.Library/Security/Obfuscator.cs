/******************************************************************************
 *                                                                            *
 * Obfuscator                                                                 *
 *                                                                            *
 * Basic premise of the Obfuscator is to "hide" an integer in a Guid.         *
 * This is so that any web application that has integers in the url           *
 * parameters which are identification numbers (like primary keys)            *
 * can be obfuscated so that people don't try to do stuff they are not        *
 * suppose to by modifying the url. Like incrementing the number until they   *
 * see something they not supposed to.                                        *
 *                                                                            *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralFunctions.Library.Security
{
    public class Obfuscator
    {
        /// <summary>
        /// Obfuscate Integer To Guid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid IntegerToGuid(int value)
        {
            // Convert Integer to Byte Array and reverse the order
            byte[] intArray = BitConverter.GetBytes(value);
            Array.Reverse(intArray);

            // New Guid to Byte Array and copy Int into positions 11,12,13 and 14
            byte[] guidArray = Guid.NewGuid().ToByteArray();
            Array.Copy(intArray, 0, guidArray, 11, 4);

            // Obfuscate Integer
            guidArray[11] ^= (byte)(guidArray[1] ^ 0xAA);
            guidArray[12] ^= (byte)(guidArray[3] ^ 0x55);
            guidArray[13] ^= (byte)(guidArray[5] ^ 0xAA);
            guidArray[14] ^= (byte)(guidArray[7] ^ 0x55);

            // Checksum in position 15
            guidArray[15] = 0;
            for(int i = 0; i < 15; i++)
            {
                if ((i & 1) == 0) { guidArray[15] <<= 1; } else { guidArray[15] >>= 1; }
                guidArray[15] ^= guidArray[i];
            }

            // Result
            return new Guid(guidArray);
        }

        /// <summary>
        /// Unobfuscate Guid To Integer
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static int GuidToInteger(Guid guid)
        {
            byte[] guidArray = guid.ToByteArray();

            // Checksum Test
            byte checksum = 0;
            for (int i = 0; i < 15; i++)
            {
                if ((i & 1) == 0) { checksum <<= 1; } else { checksum >>= 1; }
                checksum ^= guidArray[i];
            }

            if (checksum != guidArray[15]) { throw new ArgumentException("Invalid Guid"); }

            // Unobfuscate Integer
            guidArray[11] ^= (byte)(guidArray[1] ^ 0xAA);
            guidArray[12] ^= (byte)(guidArray[3] ^ 0x55);
            guidArray[13] ^= (byte)(guidArray[5] ^ 0xAA);
            guidArray[14] ^= (byte)(guidArray[7] ^ 0x55);

            // Copy Int Array from Guid Array
            byte[] intArray = new byte[4];
            Array.Copy(guidArray, 11, intArray, 0, 4);

            // Reverse Int Array
            Array.Reverse(intArray);

            // Result
            return BitConverter.ToInt32(intArray);
        }

        /// <summary>
        /// Is the obfuscated integer valid?
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static bool IsValidGuid(Guid guid)
        {
            byte[] guidArray = guid.ToByteArray();

            // Checksum Test
            byte checksum = 0;
            for (int i = 0; i < 15; i++)
            {
                if ((i & 1) == 0) { checksum <<= 1; } else { checksum >>= 1; }
                checksum ^= guidArray[i];
            }

            return checksum == guidArray[15];
        }
    }
}
