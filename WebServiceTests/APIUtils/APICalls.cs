namespace TestWebService.APIUtils
{
    using System.Net;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class APICalls
    {
        static readonly string serverUri = "https://jsonplaceholder.typicode.com/";

        public static int ExecuteGetAndGetStatusCode(string endpointName)
        {
            using (var client = new WebClient())
            {
                client.DownloadString(serverUri + endpointName);
                return GetStatusCode(client);
            }
        }

        public static string ExecuteGetAndGetContentTypeHeader(string endpointName)
        {
            using (var client = new WebClient())
            {
                client.DownloadString(serverUri + endpointName);
                return client.ResponseHeaders.Get("Content-Type");
            }
        }

        public static int ExecuteGetAndGetUsersCount(string endpointName)
        {
            using (var client = new WebClient())
            {
                var responseString = client.DownloadString(serverUri + endpointName);
                JArray json = JsonConvert.DeserializeObject<JArray>(responseString);
                return json.Count;
            }
        }

        private static int GetStatusCode(WebClient client)
        {
            FieldInfo responseField = client.GetType().GetField("m_WebResponse", BindingFlags.Instance | BindingFlags.NonPublic);

            if (responseField != null)
            {
                HttpWebResponse response = responseField.GetValue(client) as HttpWebResponse;

                if (response != null)
                {
                    return (int)response.StatusCode;
                }
            }
            return 0;
        }
    }
}
