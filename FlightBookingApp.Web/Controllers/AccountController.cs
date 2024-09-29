using FlightBookingApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

[Route("[controller]/[action]")]
public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Call your API to authenticate the user and get the JWT token
            var token = await AuthenticateUserAsync(model.Username, model.Password);

            if (token != null)
            {
                // Store the token in a cookie
                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true
                });

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        return View(model);
    }

    private async Task<string> AuthenticateUserAsync(string username, string password)
    {
        using (var httpClient = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7045/api/auth/login");
            request.Content = new StringContent(JsonConvert.SerializeObject(new { Username = username, Password = password }), Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<dynamic>(responseContent).Token;
                return token;
            }
        }

        return null;
    }

    [HttpPost]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return RedirectToAction("Login", "Account");
    }
}
