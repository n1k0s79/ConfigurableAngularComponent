using Microsoft.AspNetCore.Mvc;
using QualcoApp.Models;
using System.Linq;

namespace QualcoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext context;

        public CustomerController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int customerId)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}
