using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace GraphApi.Facebook.Client.GraphApi
{
    internal class GraphApiRequestBuilder
    {
        private readonly string url;
        private readonly Dictionary<string, string> urlParameters;
        private HttpMethod httpMethod = HttpMethod.Get;

        private GraphApiRequestBuilder(string url)
        {
            this.url = url;
            this.urlParameters = new Dictionary<string, string>();
        }

        public GraphApiRequestBuilder WithUrlPatameter(string name, string value)
        {
            this.urlParameters.Add(name, value);
            return this;
        }

        public GraphApiRequestBuilder WithUrlParameters(IEnumerable<KeyValuePair<string, string>> urlParameters)
        {
            urlParameters.ToList().ForEach(item => this.urlParameters.Add(item.Key, item.Value));
            return this;
        }

        public GraphApiRequestBuilder WithAccessToken(string token)
        {
            this.urlParameters.Add("access_token", token);
            return this;
        }

        public GraphApiRequestBuilder WithClientIdAndClientSecret((string, string) appCreds)
        {
            this.urlParameters.Add("client_id", appCreds.Item1);
            this.urlParameters.Add("client_secret", appCreds.Item2);
            return this;
        }

        public GraphApiRequestBuilder WithAppSecretProof(string appSecret, string accessToken)
        {
            using (HMACSHA256 hash = new HMACSHA256(Encoding.Default.GetBytes(appSecret)))
            {
                var proof = hash.ComputeHash(Encoding.Default.GetBytes(accessToken));

                StringBuilder sbHash = new StringBuilder();

                for (int i = 0; i < proof.Length; i++)
                {
                    sbHash.Append(proof[i].ToString("x2"));
                }

                this.urlParameters.Add("appsecret_proof", sbHash.ToString());
            }
            return this;
        }

        public GraphApiRequestBuilder WithMethod(HttpMethod httpMethod)
        {
            this.httpMethod = httpMethod;
            return this;
        }

        public static GraphApiRequestBuilder BuildRequestTo(string url)
        {
            return new GraphApiRequestBuilder(url);
        }

        public HttpRequestMessage GetHttpRequestMessage()
        {
            var urlWithQuery = $"{url}?{string.Join("&", urlParameters.Select((k) => $"{k.Key}={k.Value}"))}";
            return new HttpRequestMessage(this.httpMethod, Uri.EscapeUriString(urlWithQuery));
        }
    }
}
