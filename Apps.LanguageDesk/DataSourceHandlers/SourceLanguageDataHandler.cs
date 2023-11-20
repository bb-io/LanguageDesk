﻿using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.LanguageDesk.DataSourceHandlers
{
    public class SourceLanguageDataHandler : BaseInvocable, IDataSourceHandler
    {
        public SourceLanguageDataHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public Dictionary<string, string> GetData(DataSourceContext context)
        {
            var languages = new Dictionary<string, string>
            {
                {"af", "Afrikaans"},
                {"ar", "Arabic"},
                {"az", "Azerbaijani"},
                {"be", "Belarusian"},
                {"bg", "Bulgarian"},
                {"bn", "Bengali"},
                {"bs", "Bosnian"},
                {"ca", "Catalan"},
                {"cg-Cyrillic", "Montenegrin Cyrillic"},
                {"co", "Corsican"},
                {"cs", "Czech"},
                {"cy", "Welsh"},
                {"da", "Danish"},
                {"de", "German"},
                {"el", "Greek"},
                {"en", "English"},
                {"es", "Spanish"},
                {"et", "Estonian"},
                {"eu", "Basque"},
                {"fa", "Persian"},
                {"fi", "Finnish"},
                {"fl", "Flemish"},
                {"fr", "French"},
                {"ga", "Irish"},
                {"gl", "Galician"},
                {"gu", "Gujarati"},
                {"he", "Hebrew"},
                {"hi", "Hindi"},
                {"hr", "Croatian"},
                {"hu", "Hungarian"},
                {"id", "Indonesian"},
                {"is", "Icelandic"},
                {"it", "Italian"},
                {"ja", "Japanese"},
                {"ka", "Georgian"},
                {"kk", "Kazakh"},
                {"km", "Khmer"},
                {"kn", "Kannada"},
                {"ko", "Korean"},
                {"ku", "Kurdish"},
                {"ky", "Kirghiz"},
                {"lb", "Luxembourgish"},
                {"lo", "Lao"},
                {"lt", "Lithuanian"},
                {"lv", "Latvian"},
                {"mk", "Macedonian"},
                {"ml", "Malayalam"},
                {"mn", "Mongolian"},
                {"mo", "Moldavian"},
                {"mr", "Marathi"},
                {"ms", "Malay"},
                {"mt", "Maltese"},
                {"my", "Burmese"},
                {"ne", "Nepali"},
                {"nl", "Dutch"},
                {"no", "Norwegian"},
                {"or", "Oriya"},
                {"pa", "Panjabi"},
                {"pl", "Polish"},
                {"ps", "Pashto"},
                {"pt", "Portuguese"},
                {"rm", "Romansh"},
                {"ro", "Romanian"},
                {"ru", "Russian"},
                {"si", "Sinhala"},
                {"sk", "Slovak"},
                {"sl", "Slovenian"},
                {"sq", "Albanian"},
                {"sr", "Serbian"},
                {"sv", "Swedish"},
                {"sw", "Swahili"},
                {"ta", "Tamil"},
                {"te", "Telugu"},
                {"tg", "Tajik"},
                {"th", "Thai"},
                {"tk", "Turkmen"},
                {"tr", "Turkish"},
                {"uk", "Ukrainian"},
                {"uz", "Uzbek"},
                {"vi", "Vietnamese"},
                {"zh-CN", "Chinese (simpl., China)"},
                {"zh-TW", "Chinese (Traditional)"},
            };
            return languages
                .Where(s => context.SearchString == null || s.Value.Contains(context.SearchString))
                .ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
