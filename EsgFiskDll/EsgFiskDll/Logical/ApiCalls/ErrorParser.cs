using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsgFiskDll.Logical.ApiCalls
{
    public class ErrorParser<T>
    {
        public static string ParseError(IRestResponse<T> resp)
        {

            string EsgMessage = "";
            string ErrorMessage = "";
            string code = "";
            string responseUUID = "";
            string requestUUID = "";

            try
            {
                try { ErrorMessage = resp.Content.Substring(resp.Content.IndexOf("<faultstring>") + 13, resp.Content.IndexOf("</faultstring>") - resp.Content.IndexOf("<faultstring>") - 13); } catch { };
                try { code = resp.Content.Substring(resp.Content.IndexOf("<code>") + 6, resp.Content.IndexOf("</code>") - resp.Content.IndexOf("<code>") - 6); }catch { };
                try { responseUUID = resp.Content.Substring(resp.Content.IndexOf("<responseUUID>") + 14, resp.Content.IndexOf("</responseUUID>") - resp.Content.IndexOf("<responseUUID>") - 14); } catch { };
                try { requestUUID = resp.Content.Substring(resp.Content.IndexOf("<requestUUID>") + 13, resp.Content.IndexOf("</requestUUID>") - resp.Content.IndexOf("<requestUUID>") - 13); } catch { };

                if (resp.StatusCode.ToString() == "400")
                {
                    EsgMessage = "400 - Gabim ne objektin e derguar.";
                }
                else if(resp.StatusCode.ToString() == "500")
                {
                    EsgMessage = "500 - Gabim ne sistemin e taksave.";
                }
                else
                {
                    EsgMessage = "600 - Gabim i panjohur.";
                }
  
                string errorString = @"{" + "\n" +
                @"  ""EsgMessage"": """ + EsgMessage + @"""," + "\n" +
                @"  ""ErrorCode"": """ + code + @"""," + "\n" +
                @"  ""ErrorMessage"": """ + ErrorMessage + @"""," + "\n" +
                @"  ""requestUUID"": """ + requestUUID + @"""," + "\n" +
                @"  ""responseUUID"": """ + responseUUID + @"""," + "\n" +
                //@"  ""content"": """ + resp.Content + @"""," + "\n" +
                @"}";

                return errorString;
            }catch (Exception)
            {
                throw new Exception(resp.StatusCode + "\n" + resp.StatusDescription);
            }

        }
        
    }
}
