using System.Net;
using System.Threading.Tasks;
using Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Web.Pages
{
    [Authorize(Roles = "Administrator, Instructor")]
    public class CheckInsModel : PageModel
    {
        public CheckInsModel()
        {
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task OnGetAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
        }
    }
}