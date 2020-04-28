using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Challenge15_APIUsage.Entities;
using Newtonsoft.Json;

namespace Challenge15_APIUsage
{
    class SWAPI
    {
        private const string _baseUrl = "https://swapi.py4e.com/api/";
        
        //Is there a reason we would want to store this per object?
        private static List<WebCache> _webCache = new List<WebCache>();

        string GetData(string url)
        {
            //Check if request has already been made.
            WebCache webCache = _webCache.Find(o => o.RequestUrl == url);
            if (webCache != null)
                return webCache.Reponse;

            try
            {
                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    string responseText = reader.ReadToEnd();

                    _webCache.Add(new WebCache { RequestUrl = url, Reponse = responseText });
                    return responseText;
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = e.Response as HttpWebResponse;
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        throw new ArgumentException("The entity you requested does not currently exist.");
                }
                else if (e.Status == WebExceptionStatus.Timeout)
                {
                    throw new TimeoutException("The server request timed out!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "";
        }
        public void ClearCache()
        {
            _webCache.Clear();
        }
        public People GetPerson(int id)
        {
            string url = $"{_baseUrl}/people/{id}";
            string data = GetData(url);

            return JsonConvert.DeserializeObject<People>(data);
        }

        public List<People> GetPeople()
        {
            List<People> people;

            string url = $"{_baseUrl}/people";
            string data = GetData(url);

            var page = JsonConvert.DeserializeObject<Page<People>>(data);
            people = page.Results;

            while (page.Next != null)
            {
                page = JsonConvert.DeserializeObject<Page<People>>(GetData(page.Next));
                people = people.Concat(page.Results).ToList();
            }

            for (int i = 1; i < people.Count; i++)
            {
                _webCache.Add(
                    new WebCache
                    {
                        RequestUrl = $"{_baseUrl}/people/{i}",
                        Reponse = JsonConvert.SerializeObject(people[i])
                    }
                );
            }

            return new List<People>(people);
        }
    }
}
