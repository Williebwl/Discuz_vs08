using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Discuz.Common
{
    public class ValidatorHelper
    {
        /// <summary>
        /// 时间格式化
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string CheckDateTime(object value, string format)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                return DateTime.Parse(value.ToString()).ToString(format);
            }
            else
            {
                return "";
            }
        }
        /// 
        /// 判断字符串是否与指定正则表达式匹配
        /// 
        /// 要验证的字符串
        /// 正则表达式
        /// 验证通过返回true
        public static bool IsMatch(string input, string regularExp)
        {
            return Regex.IsMatch(input, regularExp);
        }
        /// 
        /// 验证非负整数（正整数 + 0）
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsUnMinusInt(string input)
        {
            return Regex.IsMatch(input, RegularExp.UnMinusInteger);
        }
        /// 
        /// 验证正整数
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsPlusInt(string input)
        {
            return Regex.IsMatch(input, RegularExp.PlusInteger);
        }
        /// 
        /// 验证非正整数（负整数 + 0） 
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsUnPlusInt(string input)
        {
            return Regex.IsMatch(input, RegularExp.UnPlusInteger);
        }
        /// 
        /// 验证负整数
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsMinusInt(string input)
        {
            return Regex.IsMatch(input, RegularExp.MinusInteger);
        }
        /// 
        /// 验证整数
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsInt(string input)
        {
            return Regex.IsMatch(input, RegularExp.Integer);
        }
        /// 
        /// 验证非负浮点数（正浮点数 + 0）
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsUnMinusFloat(string input)
        {
            return Regex.IsMatch(input, RegularExp.UnMinusFloat);
        }
        /// 
        /// 验证正浮点数
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsPlusFloat(string input)
        {
            return Regex.IsMatch(input, RegularExp.PlusFloat);
        }
        /// 
        /// 验证非正浮点数（负浮点数 + 0）
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsUnPlusFloat(string input)
        {
            return Regex.IsMatch(input, RegularExp.UnPlusFloat);
        }
        /// 
        /// 验证负浮点数
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsMinusFloat(string input)
        {
            return Regex.IsMatch(input, RegularExp.MinusFloat);
        }
        /// 
        /// 验证浮点数
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsFloat(string input)
        {
            return Regex.IsMatch(input, RegularExp.Float);
        }
        /// 
        /// 验证由26个英文字母组成的字符串
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsLetter(string input)
        {
            return Regex.IsMatch(input, RegularExp.Letter);
        }
        /// 
        /// 验证由中文组成的字符串
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsChinese(string input)
        {
            return Regex.IsMatch(input, RegularExp.Chinese);
        }
        /// 
        /// 验证由26个英文字母的大写组成的字符串
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsUpperLetter(string input)
        {
            return Regex.IsMatch(input, RegularExp.UpperLetter);
        }
        /// 
        /// 验证由26个英文字母的小写组成的字符串
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsLowerLetter(string input)
        {
            return Regex.IsMatch(input, RegularExp.LowerLetter);
        }
        /// 
        /// 验证由数字和26个英文字母组成的字符串
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsNumericOrLetter(string input)
        {
            return Regex.IsMatch(input, RegularExp.NumericOrLetter);
        }
        /// 
        /// 验证由数字组成的字符串
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, RegularExp.Numeric);
        }
        /// 
        /// 验证由数字和26个英文字母或中文组成的字符串
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsNumericOrLetterOrChinese(string input)
        {
            return Regex.IsMatch(input, RegularExp.NumbericOrLetterOrChinese);
        }
        /// 
        /// 验证由数字、26个英文字母或者下划线组成的字符串
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsNumericOrLetterOrUnderline(string input)
        {
            return Regex.IsMatch(input, RegularExp.NumericOrLetterOrUnderline);
        }
        /// 
        /// 验证email地址
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsEmail(string input)
        {
            return Regex.IsMatch(input, RegularExp.Email);
        }
        /// 
        /// 验证URL
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsUrl(string input)
        {
            return Regex.IsMatch(input, RegularExp.Url);
        }
        /// 
        /// 验证电话号码
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsTelephone(string input)
        {
            return Regex.IsMatch(input, RegularExp.Telephone);
        }
        /// 
        /// 验证手机号码
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsMobile(string input)
        {
            return Regex.IsMatch(input, RegularExp.Mobile);
        }
        /// 
        /// 通过文件扩展名验证图像格式
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsImageFormat(string input)
        {
            return Regex.IsMatch(input, RegularExp.ImageFormat);
        }
        /// 
        /// 验证IP
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsIP(string input)
        {
            return Regex.IsMatch(input, RegularExp.IP);
        }
        /// 
        /// 验证日期（YYYY-MM-DD）
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsDate(string input)
        {
            return Regex.IsMatch(input, RegularExp.Date);
        }
        /// 
        /// 验证日期和时间（YYYY-MM-DD HH:MM:SS）
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsDateTime(string input)
        {
            return Regex.IsMatch(input, RegularExp.DateTime);
        }
        /// 
        /// 验证颜色（#ff0000）
        /// 
        /// 要验证的字符串
        /// 验证通过返回true
        public static bool IsColor(string input)
        {
            return Regex.IsMatch(input, RegularExp.Color);
        }
    }

    public struct RegularExp
    {
        public const string Chinese = @"^[\u4E00-\u9FA5\uF900-\uFA2D]+$";
        public const string Color = "^#[a-fA-F0-9]{6}";
        //public const string Date = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
        public const string Date = @"^(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)$";
        public const string DateTime = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$";
        public const string Email = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
        public const string Float = @"^(-?\d+)(\.\d+)?$";
        public const string ImageFormat = @"\.(?i:jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$";
        public const string Integer = @"^-?\d+$";
        public const string IP = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
        public const string Letter = "^[A-Za-z]+$";
        public const string LowerLetter = "^[a-z]+$";
        public const string MinusFloat = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";
        public const string MinusInteger = "^-[0-9]*[1-9][0-9]*$";
        public const string Mobile = "^0{0,1}1[358][0-9]{9}$";
        public const string NumbericOrLetterOrChinese = @"^[A-Za-z0-9\u4E00-\u9FA5\uF900-\uFA2D]+$";
        public const string Numeric = "^[0-9]+$";
        public const string NumericOrLetter = "^[A-Za-z0-9]+$";
        public const string NumericOrLetterOrUnderline = @"^\w+$";
        public const string PlusFloat = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
        public const string PlusInteger = "^[0-9]*[1-9][0-9]*$";
        public const string Telephone = @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?";
        public const string UnMinusFloat = @"^\d+(\.\d+)?$";
        public const string UnMinusInteger = @"\d+$";
        public const string UnPlusFloat = @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$";
        public const string UnPlusInteger = @"^((-\d+)|(0+))$";
        public const string UpperLetter = "^[A-Z]+$";
        public const string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
    }
}

