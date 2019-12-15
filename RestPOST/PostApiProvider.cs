using Newtonsoft.Json;
using RestPOST.Models;
using System.IO;
using System.Net;
using System.Text;

namespace RestPOST
{
	public class PostApiProvider
	{
        public SearchResponse Search(InputParameters inputParameters)
        {
            string apiEndpoint = "https://localhost:44309/api/demo";
            WebRequest request = CreateWebResut(apiEndpoint, inputParameters);
            UpdateRequestHeaders(request, inputParameters);
            return ExecuteRequest(request);
        }

		private WebRequest CreateWebResut(string apiEndpoint, InputParameters inputParameters)
		{
            WebRequest request = WebRequest.Create(apiEndpoint);
            // Set the Method property of the request to POST.  
            request.Method = "POST";

            // Create POST data and convert it to a byte array.  
            SearchRequest bodyObject = new SearchRequest()
            {
                Search = inputParameters.Search,
                LocaleCode = inputParameters.LocaleCode,
                Timezone = inputParameters.Timezone
            };

            string postBodyInString = JsonConvert.SerializeObject(bodyObject);
            byte[] byteArray = Encoding.UTF8.GetBytes(postBodyInString);

            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/json";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;

            // Get the request stream.  
            using(Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }

            return request;
        }

        private SearchResponse ExecuteRequest(WebRequest request)
        {
            SearchResponse result = null;
            // Get the response.  
            using (WebResponse response = request.GetResponse())
            {
                // Get the stream containing content returned by the server.  
                // The using block ensures the stream is automatically closed.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    string responseFromServer = reader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<SearchResponse>(responseFromServer);
                }

                // Close the response.  
                response.Close();
            }

            return result;
        }

        private void UpdateRequestHeaders(WebRequest request, InputParameters inputParameters)
        {
            request.Headers["organization-id"] = inputParameters.OrganizationId.ToString();
        }
	}
}
