using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QualcoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QualcoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericEntityController : ControllerBase
    {
        private readonly DataContext context;

        public GenericEntityController(DataContext context) => this.context = context;

        [HttpGet]
        public GenericEntityDescriptor Get([FromQuery] string entityTypeName, [FromQuery] int id)
        {
            if (!EntityFetchers.ContainsKey(entityTypeName)) return null;
            var entity = EntityFetchers[entityTypeName](id);
            return entity.GetDescriptor();
        }

        private Dictionary<string, Func<int, GenericEntity>> EntityFetchers =>
            new Dictionary<string, Func<int, GenericEntity>>()
            {
                {"Customer", id => context.Customers.FirstOrDefault(c => c.Id == id) },
                {"Product", id => context.Products.FirstOrDefault(p => p.Id == id) }
                // ...
            };
    }
}
