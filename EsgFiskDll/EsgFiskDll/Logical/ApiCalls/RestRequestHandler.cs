using EsgFiskDll.Classes;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EsgFiskDll.Logical.ApiCalls;
using Newtonsoft.Json;

namespace EsgFiskDll.Logical.ApiCalls
{
    class RestRequestHandler<ReqType, RespType>
    {
        //internal static IRestResponse<RespType> MakeResquest(IRestClient restClient , IRestRequest restRequest, ReqType Body, FiskConfigs Configs)
        internal static IRestResponse<RespType> MakeResquest(IRestClient restClient, IRestRequest restRequest, ReqType Body, FiskConfigs Configs, string filePath=null)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Accept", "*/*");
                restRequest.AddHeader("Connection", "keep-alive");
                restRequest.AddJsonBody(Body);

                string jsonBody = JsonConvert.SerializeObject(Body, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore // This will ignore null fields
                });

                // Add the serialized JSON body to the request
                restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

                // Store JSON body to a file
                if (!string.IsNullOrEmpty(filePath))
                {
                    Utils.SaveJsonBodyToFile(jsonBody, filePath + "_req.json");
                }
                HttpBasicAuthenticator authenticator = new HttpBasicAuthenticator(Configs.ApiUsername, Configs.ApiPassword);
                authenticator.Authenticate(restClient, restRequest);


                IRestResponse<RespType> resp = restClient.Post<RespType>(restRequest);
               

                if (!string.IsNullOrEmpty(filePath))
                {
                    var jsonRest = JsonConvert.SerializeObject(resp.Content);
                    Utils.SaveJsonBodyToFile(jsonRest, filePath + "_resp.json");
                }

                return resp;

            }
            catch(Exception ex)
            {
                throw new Exception("Gabim ne dergim te kerkeses: " + ex.Message.ToString());
            }
            
        }

        // Method to save the JSON body to a file

    }
}
