using EsgFiskDll.Classes;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Logical.ApiCalls
{
    class RestRequestHandler<ReqType,RespType>
    {
        internal static IRestResponse<RespType> MakeResquest(IRestClient restClient , IRestRequest restRequest, ReqType Body, FiskConfigs Configs)
        {
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "*/*");
            restRequest.AddHeader("Connection", "keep-alive");
            restRequest.AddJsonBody(Body);
            HttpBasicAuthenticator authenticator = new HttpBasicAuthenticator(Configs.ApiUsername, Configs.ApiPassword);
            authenticator.Authenticate(restClient, restRequest);
            return restClient.Post<RespType>(restRequest);
            
        }
    }
}
