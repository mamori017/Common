using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Common
{
    /// <summary>
    /// JSON
    /// 要nuget restore
    /// </summary>
    public static class Json
    {
        /// <summary>
        /// JSON情報取得(HTTP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static JObject GetJsonObject(String strUrl)
        {
            try
            {
                string strJson = "";
                try
                {
                    strJson = new HttpClient().GetStringAsync(strUrl).Result;
                }
                catch (Exception)
                {
                    throw;
                }

                JObject objJson = JObject.Parse(strJson);

                return objJson;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}