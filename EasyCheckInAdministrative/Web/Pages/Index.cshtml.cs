using Core.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Services;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Initials { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public string ShowError { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            Instructor instructor = new Instructor();
            instructor.Initials = Input.Initials;
            instructor.Password = Input.Password;
            using (var client = new HttpClient())
            {
                var endPoint = "http://localhost:56903" + "/api/Login/Login";
                var content = new StringContent(JsonConvert.SerializeObject(instructor), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var LoggedInInstructor = JsonConvert.DeserializeObject<Instructor>(result);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, LoggedInInstructor.Initials),
                        new Claim(ClaimTypes.Role, LoggedInInstructor.Role),
                        new Claim("DepartmentID", LoggedInInstructor.DepartmentId.ToString()),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                    if(LoggedInInstructor.Role == "SystemAdministrator")
                    {
                        return Redirect("/Administration");
                    }

                    return Redirect("/Checkins");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ShowError = "Login Fejl. Tjek Initialer og Kodeord.";
                }
                else
                {
                    ShowError = "Login Fejl. Ingen forbindelse til API.";
                }

            }


                return null;
        }

        public IndexModel()
        {
        }

        public void OnGet()
        {
        }

        void Login_btn(Object sender, EventArgs e)
        {

        }
    }
}
