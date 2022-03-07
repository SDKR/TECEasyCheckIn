using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services.Base
{
    public class BaseService
    {
        protected readonly string ApiIP;
        protected readonly string IS4IP;

        public BaseService(IConfiguration configuration)
        {
            ApiIP = configuration["IP:API"];
            IS4IP = configuration["IP:IS4"];
        }
    }
}
