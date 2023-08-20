using System.Net;

namespace FirstWebApi.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
    public class UserDeatilsModel
    {
        public int Id { get; set; }
        public int UserId { get; set;}
        public string UserName { get; set; }
        public string Specilization { get; set; }
        public bool IsEmployee { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; } 
        
    }
    public class InputRequest
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Specilization { get; set; }
        public bool IsEmployee { get; set; }
        public string Address { get; set; }
    }
    public class Response
    { 
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

    }

}
