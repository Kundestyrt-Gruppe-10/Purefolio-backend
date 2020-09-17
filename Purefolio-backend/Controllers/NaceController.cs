using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend.Controllers
{
    [ApiController]
    [Route("/naces")]
    public class NaceController : ControllerBase
    {

        private readonly ILogger<NaceController> _logger;

        public NaceController(ILogger<NaceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Nace> Get()
        {
            return new List<Nace>() {
                new Nace() { NaceId = 0, NaceCode = "A", NaceName = "Agriculture, forestry and fishing" },
                new Nace() { NaceId = 1, NaceCode = "B", NaceName = "Mining and quarrying" },
                new Nace() { NaceId = 2, NaceCode = "C", NaceName = "Manufacturing" },
                new Nace() { NaceId = 3, NaceCode = "D", NaceName = "Electricity, gas, steam and air conditioning supply" },
                new Nace() { NaceId = 2, NaceCode = "E", NaceName = "Water supply; sewerage, waste management and remediation activities" },
                new Nace() { NaceId = 4, NaceCode = "F", NaceName = "Construction" },
                new Nace() { NaceId = 5, NaceCode = "G", NaceName = "Wholesale and retail trade; repair of motor vehicles and motorcycles"  },
                new Nace() { NaceId = 6, NaceCode = "H", NaceName = "Transportation and storage" },
                new Nace() { NaceId = 7, NaceCode = "I", NaceName = "Accommodation and food service activities" },
                new Nace() { NaceId = 8, NaceCode = "J", NaceName = "Information and communication" },
                new Nace() { NaceId = 9, NaceCode = "K", NaceName = "Financial and insurance activities" },
                new Nace() { NaceId = 10, NaceCode = "L", NaceName = "Real estate activities" },
                new Nace() { NaceId = 11, NaceCode = "M", NaceName = "Professional, scientific and technical activities" },
                new Nace() { NaceId = 12, NaceCode = "N", NaceName = "Administrative and support service activities" },
                new Nace() { NaceId = 13, NaceCode = "O", NaceName = "Public administration and defence; compulsory social security" },
                new Nace() { NaceId = 14, NaceCode = "P", NaceName = "Education" },
                new Nace() { NaceId = 15, NaceCode = "Q", NaceName = "Human health and social work activities" },
                new Nace() { NaceId = 16, NaceCode = "R", NaceName = "Arts, entertainment and recreation" },
                new Nace() { NaceId = 17, NaceCode = "S", NaceName = "Other service activities" },
                new Nace() { NaceId = 18, NaceCode = "T", NaceName = "Activities of household as employers; undifferentiated goods- and services-producing activities of households for own account" },
                new Nace() { NaceId = 19, NaceCode = "U", NaceName = "Activities of extraterritorial organisations and bodies" },
            };
        }
        public string Test()
        {
            return "hei";
        }
    }
}