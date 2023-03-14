using EsgFiskDll.Classes;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.DevPos.ApiCalls
{

    class OAuth2AuthenticateResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
    }

    class RestRequestHandler<ReqType,RespType>
    {
        internal static IRestResponse<RespType> MakeResquest(IRestClient restClient, IRestRequest restRequest, ReqType Body, FiskConfigs Configs)
        {
            try
            {

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;                
                OAuth2AuthenticateResponse OAuthTokenResponse = DevPosAuthenticate(Configs);


                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddHeader("Accept", "*/*");
                restRequest.AddHeader("Connection", "keep-alive");
                restRequest.AddHeader("Authorization", "Bearer " + OAuthTokenResponse.access_token );
                restRequest.AddJsonBody(Body);

                return restClient.Post<RespType>(restRequest);

            }
            catch(Exception ex)
            {
                throw new Exception("Gabim ne dergim te kerkeses: " + ex.Message.ToString());
            }
            
        }

        internal static OAuth2AuthenticateResponse DevPosAuthenticate(FiskConfigs configs)
        {
            var client = new RestClient(configs.CertificatePath);
            //var client = new RestClient("https://demo.devpos.al/connect/token");
            RestRequest request = new RestRequest();

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Basic " + configs.CertificatePassword);
            request.AddHeader("tenant", configs.IssuerNUIS);

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", configs.ApiUsername);
            request.AddParameter("password", configs.ApiPassword);


            IRestResponse<OAuth2AuthenticateResponse> response = client.Execute<OAuth2AuthenticateResponse>(request, Method.POST );

            return response.Data;
        }

    }
}
