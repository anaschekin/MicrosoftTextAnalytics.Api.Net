using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.RequestModels
{
    public class DocumentInput
    {
        public int Id { get; set; }

        public string Language { get; set; }

        public string Text { get; set; }
    }
}
