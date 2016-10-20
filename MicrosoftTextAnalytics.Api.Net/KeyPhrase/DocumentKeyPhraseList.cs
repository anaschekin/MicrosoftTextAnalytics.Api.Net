using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi.KeyPhrase
{
    public class DocumentKeyPhraseList
    {
        public int Id { get; set; }

        public List<string> KeyPhrases { get; set; }
    }
}
