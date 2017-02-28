using CalculatorApiApp.Helpers;
using CalculatorApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CalculatorApiApp.Controllers
{
    public class CalculatorController : ApiController
    {
        [HttpPost]
        [AllowCrossSiteJson]
        public int Calc(dynamic data)
        {
            Calculator c = new Calculator();
            int res = c.Calculate( (string) data["expression"]);
            return res;
        }

        public string Get()
        {
            return "1";
        }
 

    }
}
