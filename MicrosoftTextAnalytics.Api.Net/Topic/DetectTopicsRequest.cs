using MicrosoftTextAnalyticsApi.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.Topic
{
    public class DetectTopicsRequest
    {
        public List<DocumentInput> Documents { get; set; }

        public List<string> StopWords { get; set; }

        public List<string> StopPhrases { get; set; }
    }
}
