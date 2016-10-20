using MicrosoftTextAnalyticsApi.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.Topic
{
    public class TopicResults : PossibleErrorModel
    {
        public List<Topic> Topics { get; set; }

        public List<TopicAssignment> TopicAssignments { get; set; }
    }
}
