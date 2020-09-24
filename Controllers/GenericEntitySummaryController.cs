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
    public class GenericEntitySummaryController : ControllerBase
    {
        private readonly DataContext context;

        public GenericEntitySummaryController(DataContext context) => this.context = context;

        [HttpGet]
        public IEnumerable<GenericEntitySummary> Get([FromQuery] string listName, [FromQuery] string filter) =>
            ListFetchers.ContainsKey(listName)
            ? ListFetchers[listName](filter)
            : null;


        private Dictionary<string, Func<string, GenericEntitySummary[]>> ListFetchers =>
            new Dictionary<string, Func<string, GenericEntitySummary[]>>()
            {
                {"Customers", filter =>
                    {
                        var query = context.Customers.AsQueryable();
                        if (!string.IsNullOrWhiteSpace(filter)) query = query.Where(c => c.Lastname.Contains(filter));
                        return query.Select(c => c.ToSummary()).ToArray();
                    }
                },
                {"Products", filter => 
                    {
                        var query = context.Products.AsQueryable();
                        if (!string.IsNullOrWhiteSpace(filter)) query = query.Where(c => c.Description.Contains(filter));
                        return query.Select(c => c.ToSummary()).ToArray();
                    } 
                }
                // ...
            };

        [HttpPost]
        public IActionResult FillWithSampleData()
        {
            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer() { Lastname = "Ladoprakopoulos", Firstname = "Fontas" });
                context.Customers.Add(new Customer() { Lastname = "Basilopoulos", Firstname = "Nikos" });
                context.Customers.Add(new Customer() { Lastname = "Avgerinos", Firstname = "Vaggelis" });
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.Add(new Product() { CatalogueNr = "0012-434", Description = "Fakes", Unit = "kg", UnitPrice = 0.98M });
                context.Products.Add(new Product() { CatalogueNr = "5506-266", Description = "Revithia", Unit = "kg", UnitPrice = 1.2M });
                context.Products.Add(new Product() { CatalogueNr = "1778-999", Description = "Fasolia", Unit = "kg", UnitPrice = 1.4M });
                context.SaveChanges();
            }

            return Ok();
        }

    }
}
