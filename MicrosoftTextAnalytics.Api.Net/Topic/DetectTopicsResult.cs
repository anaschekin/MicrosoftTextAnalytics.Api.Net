using Newtonsoft.Json;

namespace MicrosoftTextAnalyticsApi.Topic
{
    public class DetectTopicsResult
    {
        public string Status { get; set; }

        [JsonProperty(PropertyName = "operationProcessingResult")]
        public TopicResults Results { get; set; }
    }
}
