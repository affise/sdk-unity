using UnityEngine;

namespace AffiseAttributionLib.Extensions
{
    internal static class SystemLanguageExt
    {
        public static string ToCode(this SystemLanguage systemLanguage)
        {
            return systemLanguage switch
            {
                SystemLanguage.Afrikaans => "af-ZA",
                SystemLanguage.Arabic => "ar-SA",
                SystemLanguage.Basque => "eu-ES",
                SystemLanguage.Belarusian => "be-BY",
                SystemLanguage.Bulgarian => "bg-BG",
                SystemLanguage.Catalan => "ca-ES",
                SystemLanguage.Chinese => "zh-CN",
                SystemLanguage.Czech => "cs-CZ",
                SystemLanguage.Danish => "da-DK",
                SystemLanguage.Dutch => "nl-NL",
                SystemLanguage.English => "en-EN",
                SystemLanguage.Estonian => "et-EE",
                SystemLanguage.Faroese => "fo-FO",
                SystemLanguage.Finnish => "fi-FI",
                SystemLanguage.French => "fr-FR",
                SystemLanguage.German => "de-DE",
                SystemLanguage.Greek => "el-GR",
                SystemLanguage.Hebrew => "he-IL",
                SystemLanguage.Hungarian => "hu-HU",
                SystemLanguage.Icelandic => "is-IS",
                SystemLanguage.Indonesian => "id-ID",
                SystemLanguage.Italian => "it-IT",
                SystemLanguage.Japanese => "ja-JP",
                SystemLanguage.Korean => "ko-KR",
                SystemLanguage.Latvian => "lv-LV",
                SystemLanguage.Lithuanian => "lt-LT",
                SystemLanguage.Norwegian => "nb-NO",
                SystemLanguage.Polish => "pl-PL",
                SystemLanguage.Portuguese => "pt-PT",
                SystemLanguage.Romanian => "ro-RO",
                SystemLanguage.Russian => "ru-RU",
                SystemLanguage.SerboCroatian => "hr-HR",
                SystemLanguage.Slovak => "sk-SK",
                SystemLanguage.Slovenian => "sl-SI",
                SystemLanguage.Spanish => "es-ES",
                SystemLanguage.Swedish => "sv-SE",
                SystemLanguage.Thai => "th-TH",
                SystemLanguage.Turkish => "tr-TR",
                SystemLanguage.Ukrainian => "uk-UA",
                SystemLanguage.Vietnamese => "vi-VN",
                SystemLanguage.ChineseSimplified => "zh-CN",
                SystemLanguage.ChineseTraditional => "zh-TW",
                
                _ => "",
            };
        }
    }
}