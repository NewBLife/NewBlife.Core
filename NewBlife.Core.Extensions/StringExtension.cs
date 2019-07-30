using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace NewBlife.Core.Extensions
{
    /// <summary>
    /// String extension methods
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// whether the string object is　NullOrEmpty.
        /// </summary>
        /// <param name="value">string object</param>
        /// <returns>
        ///   <c>true</c> NullOrEmpty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Convert string object to integer object
        /// </summary>
        /// <param name="value">string object</param>
        /// <returns>integer object(Fail:0)</returns>
        public static int ToInt(this string value)
        {
            int result = 0;
            if (!value.IsNullOrEmpty())
            {
                int.TryParse(value, out result);
            }

            return result;
        }

        /// <summary>
        /// Convert string object to long object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>long object(Fail:0)</returns>
        public static long ToLong(this string value)
        {
            long result = 0;
            if (!value.IsNullOrEmpty())
            {
                long.TryParse(value, out result);
            }

            return result;
        }

        /// <summary>
        /// Convert string object to double object
        /// </summary>
        /// <param name="value">string object</param>
        /// <returns>double object(Fail:0)</returns>
        public static double ToDouble(this string value)
        {
            double result = 0;
            if (!value.IsNullOrEmpty())
            {
                double.TryParse(value, out result);
            }

            return result;
        }

        /// <summary>
        /// Convert string object to DateTime object
        /// </summary>
        /// <param name="value">string object</param>
        /// <returns>DateTime object(Fail:DateTime.UtcNow)</returns>
        public static DateTime ToDateTime(this string value)
        {
            DateTime result = DateTime.Now;
            if (!value.IsNullOrEmpty())
            {
                DateTime.TryParse(value, out result);
            }

            return result;
        }

        /// <summary>
        /// Convert string object to DateTime object using the format
        /// </summary>
        /// <param name="value">string object</param>
        /// <param name="format">datetime format</param>
        /// <returns>DateTime object(Fail:DateTime.UtcNow)</returns>
        public static DateTime ToDateTime(this string value, string format)
        {
            DateTime result = DateTime.Now;
            if (!value.IsNullOrEmpty() && !format.IsNullOrEmpty())
            {
                DateTime.TryParseExact(value, format, null, DateTimeStyles.None, out result);
            }

            return result;
        }

        /// <summary>
        /// Convert string object to Enum object
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <param name="value">string object</param>
        /// <returns>Enum object</returns>
        public static T ToEnum<T>(this string value) where T : struct
        {
            T result = default(T);
            if (!value.IsNullOrEmpty())
            {
                Enum.TryParse<T>(value, out result);
            }

            return result;
        }

        /// <summary>
        /// Get Password Hash
        /// </summary>
        /// <param name="password">password string</param>
        /// <param name="salt">salt value</param>
        /// <returns>password hash</returns>
        public static string ToPasswordHash(this string password, string salt)
        {
            SHA512 sha512 = SHA512.Create();

            byte[] byteValue = Encoding.UTF8.GetBytes(password + salt);

            byte[] hash = sha512.ComputeHash(byteValue);

            StringBuilder result = new StringBuilder();
            foreach (byte charByte in hash)
            {
                result.Append(charByte.ToString("x2"));
            }

            return result.ToString();
        }

        /// <summary>
        /// Get object file name without extension
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="obj">object value</param>
        /// <returns>file name</returns>
        public static string GetFileName<T>(this T obj)
        {
            return GetFileName();
        }

        /// <summary>
        /// Get file name without extension
        /// </summary>
        /// <param name="filePath">filepath</param>
        /// <returns>file name</returns>
        internal static string GetFileName([CallerFilePath] string filePath = "")
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public static IEnumerable<string> GetFiles(this string path, string pattern = "*.*", SearchOption option = SearchOption.AllDirectories)
        {
            if (path.IsNullOrEmpty())
            {
                return null;
            }

            var folder = new DirectoryInfo(path);
            if (folder.Exists)
            {
                var list = folder.EnumerateFiles(pattern, option);
                if (!list.IsNullOrEmpty())
                {
                    var ret = new List<string>();
                    foreach (var item in list)
                    {
                        if (item.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            continue;
                        }
                        ret.Add(item.FullName);
                    }

                    return ret;
                }
            }

            return null;
        }
    }
}
