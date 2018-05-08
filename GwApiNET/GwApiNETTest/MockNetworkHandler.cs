using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using RestSharp;

namespace GwApiNETTest
{

    public class MockNetworkHandler : INetworkHandler
    {
        string _baseDir;
        private NetworkHandler handler;
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MockNetworkHandler(string basePath = @"..\..\..\TestData")
        {
            _baseDir = basePath;
            handler = new NetworkHandler(Language.English);
        }

        public object GetResponse(IApiRequest request)
        {

            string url = GetFullResource(this, request);
            string fPath = url.Replace(".json?", ".json-");
            fPath = fPath.Replace("/", "\\");

            string path = Path.Combine(_baseDir, fPath);
            string jsonString = "{}";
            if (File.Exists(path))
            {
                Console.WriteLine("File Found - " + path);
                Console.WriteLine();
                jsonString = File.ReadAllText(path);
            }
            else
            {   // If the json string isn't stored in our test bed
                // attempt to get a real response from the real api
                // Save the response to our test bed
                Console.WriteLine("File not Found - " + path);
                Console.WriteLine("Getting real api response");
                Console.WriteLine(url);
                Console.WriteLine();
                jsonString = handler.GetResponse<IRestResponse>(request).Content;
                File.WriteAllText(path, jsonString);
            }
            return new RestResponse() {RawBytes = Encoding.UTF8.GetBytes(jsonString)};
        }

        public T GetResponse<T>(IApiRequest request)
        {
            return (T) GetResponse(request);
        }

        object INetworkHandler.GetResponse(IApiRequest request)
        {
            return GetResponse(request);
        }

        public string BaseUrl { get { return handler.BaseUrl; } }
        public string BuildUri(IApiRequest request)
        {
            return handler.BuildUri(request);
        }

        public string GetFullResource(INetworkHandler networkHandler, IApiRequest request)
        {
            string fullurl = networkHandler.BuildUri(request);
            string resource = fullurl.Replace(networkHandler.BaseUrl + "/", "");
            return networkHandler.BuildUri(request).Replace(networkHandler.BaseUrl + "/", "");
        }

    }
}
