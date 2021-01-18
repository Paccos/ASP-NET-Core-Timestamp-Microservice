using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeStampAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeStampAPI.Controllers
{
    [Route("api/[controller]")]
    public class TimestampController : Controller
    {
        // GET api/timestamp/{date_str-or-unix_epoch}
        [HttpGet("{dateStr}")]
        public ActionResult<Timestamp> Get(string dateStr) => new Timestamp(dateStr);
    }
}
