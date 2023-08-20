using FirstWebApi.EmployeeData;
using FirstWebApi.Json;
using FirstWebApi.Models;
using System.Collections.Generic;
using System.Net;

namespace FirstWebApi.Services
{
    public class UserService
    {
        public Employee GetEmployee(int id)
        {
            var employeeList = StoreData.GetEmployeeData();
            var employee = employeeList.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                throw new Exception("Data not found");
            }
            return employee;
        }

        public Response CreateUser(InputRequest inputRequest) 
        {
            var userList = StoreData.GetUserData();
            var flag = userList.FirstOrDefault(item => item.UserId == inputRequest.UserId);
            if (flag != null)
            {
                throw new Exception("Already exist id");
            }
            //Random random = new Random();
            var userDetailsList=StoreData.GetUserDetailsData();
            userList.Add(new UserModel() 
            { 
                UserId = inputRequest.UserId, 
                UserName = inputRequest.UserName 
            });
            var idVal = userDetailsList.Count>0 ? userDetailsList[userDetailsList.Count - 1].Id+1:0;
            userDetailsList.Add(new UserDeatilsModel()
            {
                UserId = inputRequest.UserId,
                UserName = inputRequest.UserName,
                Address = inputRequest.Address,
                IsEmployee = inputRequest.IsEmployee,
                IsActive = true,
                Specilization = inputRequest.Specilization,
                Id = idVal
            }) ;
            StoreData.WriteUserData(userList);
            StoreData.WriteUserDetailsData(userDetailsList);
            return new Response() { StatusCode = HttpStatusCode.OK, Message = "Successfully Created" };
        }
        public Response DeleteUser(int id) 
        {
            var userDetailsList = StoreData.GetUserDetailsData();
            var flag = userDetailsList.FirstOrDefault(item => item.UserId == id);
            if (flag == null)
            {
                throw new Exception("User Id doesn't exist");
            }
            if (flag.IsActive)
            {
                flag.IsActive= false;
                StoreData.WriteUserDetailsData(userDetailsList);
                return new Response() { StatusCode = HttpStatusCode.OK, Message = "Successfully Deleted" };
            }
            return new Response() { StatusCode = HttpStatusCode.OK, Message = "Already Deleted" };

        }
    }
}
