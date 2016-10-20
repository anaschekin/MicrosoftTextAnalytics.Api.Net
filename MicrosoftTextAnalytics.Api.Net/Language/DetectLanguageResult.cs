using MicrosoftTextAnalyticsApi.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.Language
{
    public class DetectLanguageResult : PossibleErrorModel
    {
        [JsonProperty(PropertyName = "documents")]
        public List<DocumentLanguage> DocumentLanguages { get; set; }
    }
}
