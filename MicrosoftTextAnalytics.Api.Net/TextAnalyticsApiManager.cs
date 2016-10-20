using MicrosoftTextAnalyticsApi.KeyPhrase;
using MicrosoftTextAnalyticsApi.Language;
using MicrosoftTextAnalyticsApi.RequestModels;
using MicrosoftTextAnalyticsApi.Sentiment;
using MicrosoftTextAnalyticsApi.Topic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicrosoftTextAnalyticsApi
{
    public class TextAnalyticsApiManager
    {
        private string ApiKey { get; set; }

        private string Endpoint { get; set; }

        public TextAnalyticsApiManager(string endpoint, string apiKey)
        {
            Endpoint = endpoint;
            ApiKey = apiKey;
        }

        public async Task<DetectLanguageResult> GetLanguages(List<DocumentInput> documents)
        {
            var input = new DetectLanguageRequest
            {
                Documents = documents
            };

            var json = JsonConvert.SerializeObject(input);
            var result = await RequestMicrosoftApi<DetectLanguageResult>("/languages", json);

            return result;
        }

        public async Task<DetectSentimentResult> GetSentiment(List<DocumentInput> documents)
        {
            var input = new DetectSentimentRequest
            {
                Documents = documents
            };

            var json = JsonConvert.SerializeObject(input);
            var result = await RequestMicrosoftApi<DetectSentimentResult>("/sentiment", json);

            return result;
        }

        public async Task<DetectKeyPhrasesResult> GetKeyPhrases(List<DocumentInput> documents)
        {
            var input = new DetectKeyPhrasesRequest
            {
                Documents = documents
            };

            var json = JsonConvert.SerializeObject(input);
            var result = await RequestMicrosoftApi<DetectKeyPhrasesResult>("/keyPhrases", json);

            return result;
        }

        public async Task<DetectTopicsResult> GetTopics(List<DocumentInput> documents, List<string> stopWords = null, List<string> stopPhrases = null, int tryCount = 10, int tryPauseSeconds = 30)
        {
            if(documents.Count < 100)
            {
                throw new ArgumentException("At least 100 documents is required to get topics");
            }

            stopWords = stopWords ?? new List<string>();
            stopPhrases = stopPhrases ?? new List<string>();

            var input = new DetectTopicsRequest
            {
                Documents = documents,
                StopWords = stopWords,
                StopPhrases = stopPhrases
            };

            var json = JsonConvert.SerializeObject(input);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var result = await client.PostAsync(String.Format("{0}/topics", Endpoint), new StringContent(json, Encoding.UTF8, "application/json"));
            var operationUrl = String.Format("{0}?subscription-key={1}", result.Headers.Location, ApiKey);

            int numCount = tryCount;
            while(numCount > 0)
            {
                var operationResult = await client.GetAsync(operationUrl);
                var rawResponse = await operationResult.Content.ReadAsStringAsync();
                var parsedResult = JsonConvert.DeserializeObject<DetectTopicsResult>(rawResponse);
                if (parsedResult != null && parsedResult.Status == "succeeded")
                {
                    return parsedResult;
                }
                else
                {
                    numCount--;
                    Thread.Sleep(tryPauseSeconds * 1000);
                }
            }

            return null;
        }

        private async Task<T> RequestMicrosoftApi<T>(string endpoint, string json)
        {
            try
            {
                string requestEndpoint = String.Format("{0}/{1}?minDocumentsPerWord=1&maxDocumentsPerWord=3", Endpoint, endpoint);

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ApiKey);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var result = await client.PostAsync(requestEndpoint, new StringContent(json, Encoding.UTF8, "application/json"));
                var rawResponse = await result.Content.ReadAsStringAsync();
                var parsedResult = JsonConvert.DeserializeObject<T>(rawResponse);

                return parsedResult;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
