using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Common
{
    public class Json
    {
        /// <summary>
        /// GetJson
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  String GetJson(String strUrl)
        {
            try
            {
                string strJson = "";
                try
                {
                    strJson = new HttpClient().GetStringAsync(strUrl).Result;
                }
                catch (Exception ex2)
                {
                    return ex2.InnerException.Message.ToString();
                }

                JObject objJson = JObject.Parse(strJson);

                return  JsonConvert.SerializeObject(objJson, Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}