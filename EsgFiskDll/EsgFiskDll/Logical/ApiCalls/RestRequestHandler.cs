using EsgFiskDll.Classes;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Logical.ApiCalls
{
    class RestRequestHandler<ReqType,RespType>
    {
        //internal static IRestResponse<RespType> MakeResquest(IRestClient restClient , IRestRequest restRequest, ReqType Body, FiskConfigs Configs)
        internal static IRestResponse<RespType> MakeResquest(IRestClient restClient, IRestRequest restRequest, ReqType Body, FiskConfigs Configs)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                     | SecurityProtocolType.Tls11
                                     | SecurityProtocolType.Tls12;
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Accept", "*/*");
                restRequest.AddHeader("Connection", "keep-alive");
                restRequest.AddJsonBody(Body);
                HttpBasicAuthenticator authenticator = new HttpBasicAuthenticator(Configs.ApiUsername, Configs.ApiPassword);
                authenticator.Authenticate(restClient, restRequest);
                return restClient.Post<RespType>(restRequest);

            }
            catch(Exception ex)
            {
                throw new Exception("Gabim ne dergim te kerkeses: " + ex.Message.ToString());
            }
            
        }
    }
}
