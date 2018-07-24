using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Common
{
    public static class Json
    {
        /// <summary>
        /// GetJsonDictionary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static object GetJsonDictionary(String strUrl)
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
                    throw ex2;
                }

                JObject objJson = JObject.Parse(strJson);
                var area = JsonConvert.DeserializeObject<System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>>>(JsonConvert.SerializeObject(objJson, Formatting.Indented));

                //object a =  JsonConvert.DeserializeObject<J(JsonConvert.SerializeObject(objJson, Formatting.Indented));

                return area;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}