using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace Console_Analyze.Analyze
{
    class AnalyzeSocket
    {
        static readonly string url_format =
            "https://api.projectoxford.ai/luis/v2.0/apps/17ddee34-fad7-4448-bd72-0344fb2a14ef?subscription-key=b935c555d7cb4dc7b7be132c0425afef&verbose=true&q={0}";

        public async static Task<result_class> query(string query_string)
        {
            var http = new HttpClient();
            var response = await http.GetAsync(string.Format(url_format, query_string));
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(result_class));

            var memstream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (result_class)serializer.ReadObject(memstream);

            return data;
        }
    }

    [DataContract]
    public class intent_action_class
    {
        [DataMember]
        public bool triggered { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string[] parameters { get; set; }
    }

    [DataContract]
    public class intent_class
    {
        [DataMember]
        public string intent { get; set; }
        [DataMember]
        public double score { get; set; }
        [DataMember]
        public intent_action_class[] actions { get; set; }
    }

    [DataContract]
    public class entity_resolution_class
    {
        [DataMember]
        public string date { get; set; }
    }

    [DataContract]
    public class entity_class
    {
        [DataMember]
        public string entity { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public int startIndex { get; set; }
        [DataMember]
        public int endIndex { get; set; }
        [DataMember]
        public double score { get; set; }
        [DataMember]
        public entity_resolution_class resolution { get; set; }
    }

    [DataContract]
    public class result_class
    {
        [DataMember]
        public string query { get; set; }
        [DataMember]
        public intent_class topScoringIntent { get; set; }
        [DataMember]
        public intent_class[] intents { get; set; }
        [DataMember]
        public entity_class[] entities { get; set; }
    }
}
