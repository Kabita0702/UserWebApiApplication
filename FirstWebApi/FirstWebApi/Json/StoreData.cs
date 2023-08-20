using FirstWebApi.Models;
using Newtonsoft.Json;
using System.Net;
using System.Xml;

namespace FirstWebApi.Json
{
    public  static class StoreData
    {
        public static void WriteEmployeeData(List<Employee> _jsonData)
        {
            //string json = JsonConvert.SerializeObject(_jsonData.ToArray());

            File.WriteAllText(@".\Json\EmployeeJson.json", JsonConvert.SerializeObject(_jsonData.ToArray(), Newtonsoft.Json.Formatting.Indented));
        }
        public static List<Employee> GetEmployeeData()
        {
            var _jsonData = new WebClient().DownloadString(@".\Json\EmployeeJson.json");
            return JsonConvert.DeserializeObject<List<Employee>>(_jsonData);
        }
        public static void WriteUserData(List<UserModel> _jsonData)
        {
            //string json = JsonConvert.SerializeObject(_jsonData.ToArray());

            File.WriteAllText(@".\Json\User.json", JsonConvert.SerializeObject(_jsonData.ToArray(), Newtonsoft.Json.Formatting.Indented));
        }
        public static List<UserModel> GetUserData()
        {
            var _jsonData = new WebClient().DownloadString(@".\Json\User.json");
            return JsonConvert.DeserializeObject<List<UserModel>>(_jsonData);
        }
        public static void WriteUserDetailsData(List<UserDeatilsModel> _jsonData)
        {
            //string json = JsonConvert.SerializeObject(_jsonData.ToArray());

            File.WriteAllText(@".\Json\UserDetails.json", JsonConvert.SerializeObject(_jsonData.ToArray(), Newtonsoft.Json.Formatting.Indented));
        }
        public static List<UserDeatilsModel> GetUserDetailsData()
        {
            var _jsonData = new WebClient().DownloadString(@".\Json\UserDetails.json");
            return JsonConvert.DeserializeObject<List<UserDeatilsModel>>(_jsonData);
        }
    }
}
