using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using MvcClient.Models;
using System;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _httpClient = new HttpClient();
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
            _httpClient.BaseAddress = new Uri((Configuration.GetSection("Endpoints")["Authority"]).ToString());
        }

        public IActionResult Index()
        {
            var userClaims = (User as ClaimsPrincipal).Claims;
            string bc_address = userClaims
                          .Where(c => c.Type == "BC_Address")
                          .Select(c => c.Value)
                          .FirstOrDefault();
            string user_name = userClaims
                           .Where(c => c.Type == "given_name")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            ViewData["UserName"] = user_name;

            ViewData["BC_Address"] = bc_address;
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            var userClaims = (User as ClaimsPrincipal).Claims;
            string bc_address = userClaims
                          .Where(c => c.Type == "BC_Address")
                          .Select(c => c.Value)
                          .FirstOrDefault();
            string user_name = userClaims
                           .Where(c => c.Type == "given_name")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            ViewData["UserName"] = user_name;

            ViewData["BC_Address"] = bc_address;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> CallIdentity()
        {
            var userClaims = (User as ClaimsPrincipal).Claims;
            string bc_address = userClaims
                          .Where(c => c.Type == "BC_Address")
                          .Select(c => c.Value)
                          .FirstOrDefault();
            string user_name = userClaims
                           .Where(c => c.Type == "given_name")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            ViewData["UserName"] = user_name;

            ViewData["BC_Address"] = bc_address;

            string accessToken = userClaims
                             .Where(c => c.Type == "access_token")
                             .Select(c => c.Value)
                             .FirstOrDefault();

            ViewData["BC_Address"] = bc_address;
            //_httpClient.SetBearerToken(accessToken);
            SimpleResponse simpleResponse = new SimpleResponse() { BC_Address = "", UserName = "Not found" };
            HttpResponseMessage egsResponse = await _httpClient.GetAsync("/ApplicationUser/GetResult?bc_address=" + bc_address);
            if (egsResponse.IsSuccessStatusCode)
            {
                string content = await egsResponse.Content.ReadAsStringAsync();
                simpleResponse = JsonConvert.DeserializeObject<SimpleResponse>(content);
                ViewData["UserInfo"] = simpleResponse;
            }

            return View(simpleResponse);
        }

        public IActionResult Error()
        {
            var userClaims = (User as ClaimsPrincipal).Claims;
            string bc_address = userClaims
                          .Where(c => c.Type == "BC_Address")
                          .Select(c => c.Value)
                          .FirstOrDefault();
            string user_name = userClaims
                           .Where(c => c.Type == "given_name")
                           .Select(c => c.Value)
                           .FirstOrDefault();
            ViewData["UserName"] = user_name;

            ViewData["BC_Address"] = bc_address;

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
