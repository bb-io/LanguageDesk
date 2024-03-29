﻿using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.LanguageDesk.DataSourceHandlers;

public class TargetLanguageDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        {"af", "Afrikaans"},
        {"am", "Amharic"},
        {"ar-MSA", "Arabic (Modern Standard)"},
        {"ar-SA", "Arabic (Saudi-Arabia)"},
        {"az", "Azerbaijani"},
        {"be", "Belarusian"},
        {"bg", "Bulgarian"},
        {"bn", "Bengali, Bangla"},
        {"bn-BD", "Bengali (Bangladesh)"},
        {"bs-Cyrillic", "Bosnian Cyrillic"},
        {"bs-Latin", "Bosnian Latin"},
        {"ca-AD", "Catalan (Andorra)"},
        {"ca-ES", "Catalan (Spain)"},
        {"cg-Cyrillic", "Montenegrin (Cyrillic)"},
        {"cg-Latin", "Montenegrin (Latin)"},
        {"co", "Corsican"},
        {"cs", "Czech"},
        {"cy", "Welsh"},
        {"da", "Danish"},
        {"de-AT", "German (Austria)"},
        {"de-CH", "German (Switzerland)"},
        {"de-DE", "German (Germany)"},
        {"el", "Greek (modern)"},
        {"en-AU", "English (Australia)"},
        {"en-CA", "English (Canada)"},
        {"en-GB", "English (United Kingdom)"},
        {"en-IE", "English (Ireland)"},
        {"en-IN", "English (India)"},
        {"en-NZ", "English (New Zeland)"},
        {"en-SG", "English (Singapore)"},
        {"en-US", "English (United States)"},
        {"en-ZA", "English (South Africa)"},
        {"es-AR", "Spanish (Argentina)"},
        {"es-BO", "Spanish (Bolivia)"},
        {"es-CL", "Spanish (Chile)"},
        {"es-CO", "Spanish (Colombia)"},
        {"es-EC", "Spanish (Ecuador)"},
        {"es-ES", "Spanish (Spain)"},
        {"es-LA", "Spanish (Latin America)"},
        {"es-MX", "Spanish (Mexico)"},
        {"es-PE", "Spanish (Peru)"},
        {"es-PY", "Spanish (Paraguay)"},
        {"es-US", "Spanish (United States)"},
        {"es-UY", "Spanish (Uruguay)"},
        {"es-VE", "Spanish (Venezuela)"},
        {"es-XM", "International Spanish"},
        {"et", "Estonian"},
        {"eu", "Basque"},
        {"fa", "Persian (Farsi)"},
        {"fi", "Finnish"},
        {"fl", "Filipino"},
        {"fr-BE", "French (Belgium)"},
        {"fr-CA", "French (Canada)"},
        {"fr-CH", "French (Switzerland)"},
        {"fr-FR", "French (France)"},
        {"fr-LU", "French (Luxembourg)"},
        {"ga", "Irish"},
        {"gl", "Galician"},
        {"gu", "Gujarati"},
        {"ha", "Hausa"},
        {"he", "Hebrew (modern)"},
        {"hi", "Hindi"},
        {"hmn", "Hmong"},
        {"hr", "Croatian"},
        {"hu", "Hungarian"},
        {"hy", "Armenian"},
        {"id", "Indonesian"},
        {"is", "Icelandic"},
        {"it-CH", "Italian (Switzerland)"},
        {"it-IT", "Italian (Italy)"},
        {"ja", "Japanese"},
        {"ka", "Georgian"},
        {"kk", "Kazakh"},
        {"km", "Khmer"},
        {"kn", "Kannada"},
        {"ko", "Korean"},
        {"ku", "Kurdish"},
        {"ky", "Kyrgyz"},
        {"lb", "Luxembourgish, Letzeburgesh"},
        {"lo", "Lao"},
        {"lt", "Lithuanian"},
        {"lv", "Latvian"},
        {"mai", "Maithili"},
        {"mg", "Malagasy"},
        {"mk", "Macedonian"},
        {"ml", "Malayalam"},
        {"mn", "Mongolian"},
        {"mo", "Moldavan"},
        {"mr", "Marathi (Marathi)"},
        {"ms", "Malay"},
        {"mt", "Maltese"},
        {"my", "Burmese"},
        {"ne", "Nepali"},
        {"nl-BE", "Dutch (Belgium)"},
        {"nl-NL", "Dutch (Netherlands)"},
        {"no-nb", "Norwegian Bokmål"},
        {"no-nn", "Norwegian Nynorsk"},
        {"or", "Oriya"},
        {"pa", "Punjabi"},
        {"pas", "Pashto, Pushto"},
        {"pl", "Polish"},
        {"pt-BR", "Portuguese (Brasil)"},
        {"pt-PT", "Portuguese (Portugal)"},
        {"rm", "Romansh"},
        {"ro", "Romanian"},
        {"ru", "Russian"},
        {"si", "Sinhalese, Sinhala"},
        {"sk", "Slovak"},
        {"sl", "Slovenian"},
        {"so", "Somali"},
        {"sq", "Albanian"},
        {"sr-Cyrillic", "Serbian (Cyrillic)"},
        {"sr-Latin", "Serbian (Latin)"},
        {"sv-FI", "Swedish (Finland)"},
        {"sv-SE", "Swedish (Sweden)"},
        {"sw", "Swahili"},
        {"ta", "Tamil"},
        {"te", "Telugu"},
        {"tg", "Tajik"},
        {"th", "Thai"},
        {"tk", "Turkmen"},
        {"tr", "Turkish"},
        {"uk", "Ukrainian"},
        {"ur", "Urdu"},
        {"uz", "Uzbek"},
        {"vi", "Vietnamese"},
        {"zh-CN", "Chinese (simpl. China)"},
        {"zh-HK", "Chinese (Hong Kong)"},
        {"zh-TW", "Chinese (Traditional)"},
    };
}