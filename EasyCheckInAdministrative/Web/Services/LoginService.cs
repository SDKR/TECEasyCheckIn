using Core.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Services.Base;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Web.Services
{
    public class LoginService : BaseService
    {
        public LoginService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Instructor> AttemptLogin(string initals)
        {
            Instructor instructor = new Instructor();
            instructor.Initials = initals;
            using (var client = new HttpClient())
            {
                var endPoint = ApiIP + "/api/Login/Login";
                var content = new StringContent(JsonConvert.SerializeObject(instructor), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(endPoint, content);
                //var endPoint = ApiIP + "/api/Test/";
                //var content = await client.GetStringAsync(endPoint);
                
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var LoggedInInstructor = JsonConvert.DeserializeObject<Instructor>(result);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, LoggedInInstructor.Initials),
                        new Claim(ClaimTypes.Role, "Administrator"),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
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

                    //await HttpContext.SignInAsync(
                    //CookieAuthenticationDefaults.AuthenticationScheme, 
                    //new ClaimsPrincipal(claimsIdentity), 
                    //authProperties);

                }
                Instructor ins = new Instructor();
                return ins;
            }

            /* 
                var endPoint = ApiIP + "/api/students/" + student.Id;
                var content = new StringContent(JsonConvert.SerializeObject(student), System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync(endPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Student>(result);
                }

                return null;
             * */
        }

    }
}
