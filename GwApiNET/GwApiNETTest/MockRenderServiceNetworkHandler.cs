using System;
using RestSharp;
using System.Net;
using System.IO;
using System.Drawing;

namespace GwApiNET
{
    public class MockRenderServiceNetworkHandler : INetworkHandler
    {
        string _baseDir;
        private NetworkHandler handler;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MockRenderServiceNetworkHandler(string basePath = @"..\..\..\TestData\file\")
        {
            _baseDir = basePath;
            handler = new NetworkHandler(Language.English, Constants.RenderServiceBaseUri);
        }

        public object GetResponse(IApiRequest request)
        {
            string url = BuildUri(request);
            string fPath = Path.GetFileName(url);
            IRestResponse response = new RestResponse();
            string path = Path.Combine(_baseDir, fPath);
            if (File.Exists(path))
            {
                Console.WriteLine("File Found - " + path);
                Console.WriteLine();
                response.RawBytes = File.ReadAllBytes(path);
            }
            else
            {   // If the image isn't stored in our test bed,
                // attempt to get a real response from the real api
                // Save the response to our test bed
                Console.WriteLine("File not Found - " + path);
                Console.WriteLine("Getting real api response");
                Console.WriteLine(url);
                Console.WriteLine();
                response = handler.GetResponse<IRestResponse>(request);
                File.WriteAllBytes(path, response.RawBytes);
            }
            return response;
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
    }
}
