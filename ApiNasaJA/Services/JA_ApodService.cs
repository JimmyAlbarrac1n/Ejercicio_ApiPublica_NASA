using ApiNasaJA.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNasaJA.Services
{
    public class JA_ApodService
    {
        public async Task<JA_Apod> GetImage(DateTime dt)
        {
            JA_Apod dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://api.nasa.gov/planetary/apod?date={dt.ToString("yyyy-MM-dd")}&api_key=ie2HIV4OKOGB0mZF3tskgDQ9Tnxd6Yyw6Fo5Lbax";
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpClient client = new HttpClient();
                response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<JA_Apod>(json);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return dto;
        }
    }
}
