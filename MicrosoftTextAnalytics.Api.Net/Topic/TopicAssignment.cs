using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.Topic
{
    public class TopicAssignment
    {
        public string Id { get; set; }

        public int DocumentId { get; set; }

        public double Distance { get; set; }
    }
}
