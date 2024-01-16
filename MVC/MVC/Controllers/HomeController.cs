using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private String url = "http://localhost:5210/api/User/";
        private HttpClient client = new HttpClient();


        public IActionResult Index()
        {
            List<UserModel> emp = new List<UserModel>();
            HttpResponseMessage response = client.GetAsync(url + "Get").Result;
            if (response.IsSuccessStatusCode)
            {
                String data = response.Content.ReadAsStringAsync().Result;
                dynamic jsonObject = JsonConvert.DeserializeObject(data);
                var dataOfObject = jsonObject.data;
                var extDataJason = JsonConvert.SerializeObject(dataOfObject, Formatting.Indented);
                emp = JsonConvert.DeserializeObject<List<UserModel>>(extDataJason);

            }
            return View(emp);
        }

        public IActionResult Privacy(int? id)
        {
            UserModel user = new UserModel();

            if (id != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url + "Get/" + id).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        dynamic jsonobj = JsonConvert.DeserializeObject(data);
                        var dataofobject = jsonobj.data;
                        var extractedData = JsonConvert.SerializeObject(dataofobject, Formatting.Indented);
                        user = JsonConvert.DeserializeObject<UserModel>(extractedData);
                    }
                    else
                    {
                        // Handle error response
                        // Example: ViewBag.ErrorMessage = "Failed to fetch employees.";
                    }
                }
            }
            return View(user);
        }

        public IActionResult Save(UserModel userModel) {
           
                MultipartFormDataContent dataContent = new MultipartFormDataContent();

                dataContent.Add(new StringContent(userModel.UserName), "UserName");
                dataContent.Add(new StringContent(userModel.UserEmail), "UserEmail");
                dataContent.Add(new StringContent(userModel.UserContact), "UserContact");
                using (HttpClient client = new HttpClient())
                {
                if (ModelState.IsValid)
                {
                    if (userModel.UserId != 0)
                    {
                        dataContent.Add(new StringContent(userModel.UserId.ToString()), "UserId");
                        HttpResponseMessage response = client.PutAsync(url + "Put/" + userModel.UserId, dataContent).Result;
                    }
                    else
                    {
                        HttpResponseMessage response = client.PostAsync(url + "Post", dataContent).Result;
                    }
                }
                    

                }


            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response =client.DeleteAsync(url + "Delete/" +  id).Result;

            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
