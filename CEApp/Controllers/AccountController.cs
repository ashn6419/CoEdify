using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CEApp.Controllers
{
    public class AccountController : Controller
    {
        HttpClient client;
        Uri uri = new Uri("http://localhost:56543/api/");

        public AccountController()
        {
            client = new HttpClient();
            client.BaseAddress = uri;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (TempData != null)
                TempData.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin loginModel)
        {
            if (ModelState.IsValid)
            {
                UserLogin user = GetUserLogin(loginModel);

                if (user.UserLoginId > 0)
                {

                    if (user.RoleName.Contains("Admin"))
                    {
                        return RedirectToAction("Dashboard", "Dashboard", new { @area = "Admin" });
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid data");
            }
            return View();
        }

        private UserLogin GetUserLogin(UserLogin model)
        {
            bool boo = false;
            UserLogin userLogin = new UserLogin();
            try
            {
                string str = JsonConvert.SerializeObject(model);

                StringContent content = new StringContent(str, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = client.PostAsync(client.BaseAddress + "login/dologin", content).Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        string outstr = httpResponse.Content.ReadAsStringAsync().Result;
                        userLogin = JsonConvert.DeserializeObject<UserLogin>(outstr);
                    }
                    if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        string outstr = httpResponse.Content.ReadAsStringAsync().Result;
                        userLogin = JsonConvert.DeserializeObject<UserLogin>(outstr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userLogin;
        }

        //public ActionResult Reset()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[Route("Get Password")]
        //public ActionResult Reset(LoginModel login)
        //{
        //    UserModel user = uow.UserRepo.GetUser(login.Username);
        //    if (user != null)
        //    {
        //        login.Password = user.Password;
        //        login.Username = user.UserName;
        //        ViewData["username"] = user.UserName;
        //        ViewData["password"] = user.Password;
        //    }
        //    return View(login);
        //}

        //public ActionResult SignOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Login");
        //}

        public ActionResult ForgetPassowrd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GetPassword(UserLogin userLogin)
        {
            UserLogin login = new UserLogin();
            string passsword;
            if (userLogin == null)
            {
                ModelState.AddModelError("", "parameter can not be null");
            }
            string str = JsonConvert.SerializeObject(userLogin);
            StringContent content = new StringContent(str, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "login/getuserlogin/" + userLogin.UserEmail).Result;

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string strout = response.Content.ReadAsStringAsync().Result;
                    login = JsonConvert.DeserializeObject<UserLogin>(strout);
                    passsword = login.Password;
                    TempData["psw"] = passsword;
                    TempData.Keep();
                    // return RedirectToAction("Login");
                }
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    TempData["psw"] = "No user found!";
                    TempData.Keep();
                }
            }
            return View("ForgetPassowrd");
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Qualifications = GetQualificationLists();
            return View();
        }

        private List<SelectListItem> GetQualificationLists()
        {
            List<Qualification> qualifications = new List<Qualification>();
            qualifications = GetQualifications();

            var selectListItems = qualifications.Select(x => new SelectListItem()
            {
                Text = x.QualificationName,
                Value = x.QualificationId.ToString()
            }).ToList();
            return selectListItems;
        }

        private List<Qualification> GetQualifications()
        {
            List<Qualification> qualifications = new List<Qualification>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "qualification").Result;
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string str = response.Content.ReadAsStringAsync().Result;
                    qualifications = JsonConvert.DeserializeObject<List<Qualification>>(str);
                }
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    qualifications = null;
                }
            }
            return qualifications;
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                string a = "";
            }
            else
            {
                string b = "";
            }

            if (user == null)
                ModelState.AddModelError("user", "parameter is null!");

            string str = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(str, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "user", content).Result;

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    TempData["msg"] = "User is registered.";
                    TempData.Keep();
                    //return RedirectToAction("Login");
                }

            }
            else
            {
                if (response.StatusCode == HttpStatusCode.Found)
                {
                    TempData["msg"] = "User is already registered.";
                    TempData.Keep();
                }
                if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    ModelState.AddModelError(string.Empty, "Server error.Please Try after sometime");
                }
            }
            ViewBag.Qualifications = GetQualificationLists();
            return View();
        }





    }
}

