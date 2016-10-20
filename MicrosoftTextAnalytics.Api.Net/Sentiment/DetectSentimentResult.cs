using MicrosoftTextAnalyticsApi.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.Sentiment
{
    public class DetectSentimentResult : PossibleErrorModel
    {
        [JsonProperty(PropertyName = "documents")]
        public List<DocumentSentiment> DocumentSentiments { get; set; }
    }
}
