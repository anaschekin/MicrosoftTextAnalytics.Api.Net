using MicrosoftTextAnalyticsApi.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.KeyPhrase 
{
    public class DetectKeyPhrasesResult : PossibleErrorModel
    {
        [JsonProperty(PropertyName = "documents")]
        public List<DocumentKeyPhraseList> DocumentsKeyPhrases { get; set; }
    }
}
