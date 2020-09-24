using Microsoft.AspNetCore.Mvc;
using QualcoApp.Models;
using System.Linq;

namespace QualcoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericEntityActionsController : ControllerBase
    {
        private DataContext context;
        public GenericEntityActionsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public string[] GetListActions([FromQuery] string entityTypeName) => GetEntityListActions(entityTypeName);

        public static string[] GetEntityListActions(string entityTypeName)
        {
            var types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().ToList();
            var type = System.Reflection.Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == entityTypeName);
            return type == null
                ? new string[] { }
                : GenericEntityDescriptor.GetListActions(type);
        }

        [HttpPost]
        [Route("entity")]
        public IActionResult EntityAction([FromQuery] string entityTypeName, [FromQuery] string actionName, [FromQuery] int id)
        {
            // TODO implement 
            return Ok();
        }

        [HttpPost]
        [Route("list")]
        public IActionResult ListAction([FromQuery] string entityTypeName, [FromQuery] string actionName)
        {
            // TODO implement 
            return Ok();
        }
    }
}
