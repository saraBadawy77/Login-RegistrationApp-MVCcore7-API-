using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegistrationApp.Models;
using System.Security.Policy;
using System.Text;

namespace RegistrationApp.Controllers
{
    public class RegistrationController : Controller
    {

        RegistrationDbcontext db = new RegistrationDbcontext();
        Uri baseAddress = new Uri("https://localhost:7189/api");
        private readonly HttpClient _Client;

        public RegistrationController()
        {
            _Client = new HttpClient();
            _Client.BaseAddress = baseAddress;

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Save(Registration user)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _Client.PostAsync(_Client.BaseAddress + "/APIRegistration/Register", content);

                if (response.IsSuccessStatusCode)
                {
                    // Registration successful
                    TempData["SuccessMessage"] = "Your registration has been successful!";
                    return View("Login");
                }
            }

            // If there are errors or registration fails, add an error message to TempData
            TempData["ErrorMessage"] = "There was an error processing your registration. Please check your information and try again.";

            // Return to the Index view with the model
            return View("Index", user);
        }

        [HttpGet]
        public IActionResult loginviwe()
        {
            return View("Login");
        }


        [HttpPost]
        public async Task<IActionResult> login(Login user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _Client.PostAsync(_Client.BaseAddress + "/APIRegistration/Login", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Login", user);
        }



    }
}
