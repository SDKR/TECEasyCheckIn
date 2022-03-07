﻿using System.Threading.Tasks;
using Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Web.Pages
{
    [Authorize(Roles = "Administrator")]
    public class InsertModel : PageModel
    {
        public InsertModel()
        {
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task OnGetAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
        }
    }
}