using System.Reflection.Metadata.Ecma335;
using Core.Enums;

namespace Core.Extensions
{
    public static class LanguageEnumExtensions
    {
        public static string Code(this LanguageEnum languageEnum) =>
            languageEnum.ToString().ToLower();
        
        public static string ToNumberString(this LanguageEnum languageEnum) =>
            ((int)languageEnum).ToString();
    }
}