using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.Topic
{
    public class Topic
    {        
        public string Id { get; set; }

        public double Score { get; set; }

        public string KeyPhrase { get; set; }
    }
}
