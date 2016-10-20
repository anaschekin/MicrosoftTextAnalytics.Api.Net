using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.Language
{
    public class DocumentLanguage
    {
        [JsonProperty(PropertyName = "id")]
        public int DocumentId { get; set; }

        public List<LanguageInfo> DetectedLanguages { get; set; }
    }
}
