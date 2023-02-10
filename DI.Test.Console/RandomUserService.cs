using DI.Test.Console.Models;
using Newtonsoft.Json;

namespace DI.Test.Console
{
    public class RandomUserService
    {
        private static readonly HttpClient httpClient;
        
        static RandomUserService()
        {
            httpClient = new HttpClient();
        }

        public static List<User> GetRandomUsers(int countUsers)
        {
            try
            {
                var serviceRequestResult = GetServiceRequest(countUsers);

                ServiceObject serviceObject = JsonConvert.DeserializeObject<ServiceObject>(value: serviceRequestResult.Result);

                if (serviceObject?.Error != null)
                    throw new Exception(serviceObject?.Error);

                return serviceObject?.Users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async static Task<byte[]> GetImage(string url)
        {
            return await httpClient.GetByteArrayAsync(url);
        }

        private async static Task<string> GetServiceRequest(int countUsers)
        {
            using HttpResponseMessage response = await httpClient.GetAsync($"https://randomuser.me/api/?&results={countUsers}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
