using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Example.Infrastructure.Util.Extentions
{
    /// <summary>
    /// 一些字元處裡的擴充類別
    /// </summary>
    public static partial class StringExtensions
    {
        #region 正則表達式
        /// <summary>
        /// 使用RegularExpression在指定的字串是否有符合的項目
        /// </summary>
        /// <param name="value">來源字串</param>
        /// <param name="pattern">正則運算式</param>
        /// <param name="isContains">是否只是要包含而已，否則就是要全部準確符合</param>
        /// <returns>如果有符合就回傳 true</returns>
        public static bool IsMatch(this string value, string pattern, bool isContains = true)
        {
            if (value == null)
            {
                return false;
            }
            return isContains
                ? Regex.IsMatch(value, pattern)
                : Regex.Match(value, pattern).Success;
        }
        /// <summary>
        /// 回傳在正則運算式符合的第一個項目字串
        /// </summary>
        /// <param name="value">來源字串</param>
        /// <param name="pattern">正則運算式</param>
        /// <returns>回傳第一個有符合的項目</returns>
        public static string Match(this string value, string pattern)
        {
            if (value == null)
            {
                return null;
            }
            return Regex.Match(value, pattern).Value;
        }
        /// <summary>
        /// 在指定的輸入字元串中搜索指定的正則表達式的所有符合的字元集合
        /// </summary>
        /// <param name="value">來源字串</param>
        /// <param name="pattern">正則運算式</param>
        /// <returns>回傳符合的字串集合</returns>
        public static IEnumerable<string> Matches(this string value, string pattern)
        {
            if (value == null)
            {
                return new string[] { };
            }
            MatchCollection matches = Regex.Matches(value, pattern);
            return from Match match in matches select match.Value;
        }
        /// <summary>
        /// 判斷字串裡面是否有數字
        /// </summary>
        /// <param name="value">來源字串</param>
        /// <returns></returns>
        public static bool IsMatchNumber(this string value)
        {
            return IsMatch(value, @"\d");
        }
        /// <summary>
        /// 判斷字串裡面是否有數字，並且長度為指定的長度
        /// </summary>
        /// <param name="value">來源字串</param>
        /// <param name="length">指定長度</param>
        /// <returns></returns>
        public static bool IsMatchNumber(this string value, int length)
        {
            Regex regex = new Regex(@"^\d{" + length + "}$");
            return regex.IsMatch(value);
        }
        /// <summary>
        /// 是否為電子郵件
        /// </summary>
        /// <param name="value">來源字串</param>
        /// <returns></returns>
        public static bool IsEmail(this string value)
        {
            const string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return value.IsMatch(pattern);
        }
        /// <summary>
        /// 是否為IP Address
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIpAddress(this string value)
        {
            const string pattern = @"^((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))$";
            return value.IsMatch(pattern);
        }
        /// <summary>
        /// 是否為整數
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string value)
        {
            const string pattern = @"^\-?[0-9]+$";
            return value.IsMatch(pattern);
        }

        /// <summary>
        /// 是否是Unicode字串
        /// </summary>
        public static bool IsUnicode(this string value)
        {
            const string pattern = @"^[\u4E00-\u9FA5\uE815-\uFA29]+$";
            return value.IsMatch(pattern);
        }

        /// <summary>
        /// 是否為Url字串
        /// </summary>
        public static bool IsUrl(this string value)
        {
            const string pattern = @"^(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#!]*[\w\-\@?^=%&amp;/~\+#!])?$";
            return value.IsMatch(pattern);
        }
        #endregion

        #region 其他方法
        /// <summary>
        /// 判斷字串是否為Null或是空白
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool IsNull(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
        /// <summary>
        /// 判斷字串是否不為Null或空白
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static bool NotNull(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }
        /// <summary>
        /// 比較兩個字串是否相等，忽略大小寫
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            return s1.Equals(s2, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// 判斷檔案是否為圖片
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool IsImageFile(this string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            byte[] filedata = File.ReadAllBytes(filename);
            if (filedata.Length == 0)
            {
                return false;
            }
            ushort code = BitConverter.ToUInt16(filedata, 0);
            switch (code)
            {
                case 0x4D42: //bmp
                case 0xD8FF: //jpg
                case 0x4947: //gif
                case 0x5089: //png
                    return true;
                default:
                    return false;
            }
        }
        #endregion
    }
}
