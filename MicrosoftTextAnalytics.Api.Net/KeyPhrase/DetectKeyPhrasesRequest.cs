using MicrosoftTextAnalyticsApi.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.KeyPhrase
{
    public class DetectKeyPhrasesRequest
    {
        public List<DocumentInput> Documents { get; set; }
    }
}
