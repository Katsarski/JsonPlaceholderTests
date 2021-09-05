using RestSharp;
using System;

namespace JsonPlaceholderTests
{
    public class BaseApi
    {

        public RestClient _client = new RestClient();
        public RestRequest _request = new RestRequest();
        public TestContext testContext = new TestContext();

        public BaseApi(string endpointUrl)
        {
            _client.BaseUrl = new Uri(endpointUrl);
        }

        public void Get(string[] queryStringKey = null, string[] queryStringValue = null)
        {
            _request = new RestRequest();
            queryStringKey = queryStringKey ?? new string[0];
            for (int i = 0; i < queryStringKey.Length; i++)
            {
                //Remove duplicated qery params (this happens when we have two same requests send one after the other)
                _request.Parameters.RemoveAll(x => x.Name.Equals(queryStringKey[i]));
                _request.AddParameter($"{queryStringKey[i]}", $"{queryStringValue[i]}");
            }

            _request.Method = Method.GET;
            IRestResponse response = _client.Execute(_request);
            testContext.response = response;
        }

        public void Post(string body)
        {
            _request = new RestRequest();
            _request.Method = Method.POST;
            _request.Parameters.RemoveAll(x => x.Type.Equals(ParameterType.RequestBody));
            _request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = _client.Execute(_request);
            testContext.response = response;
        }
    }
}

