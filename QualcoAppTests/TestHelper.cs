using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using QualcoApp.Models;

namespace QualcoAppTests
{
    public class TestHelper
    {
        internal static DataContext GetMockContext()
        {
            var mockContext = new Mock<DataContext>();
            var customers = new List<Customer>();
            var mockCustomersDbSet = MockDbSet(customers);
            mockContext.Setup(x => x.Customers).Returns(mockCustomersDbSet.Object);

            var products = new List<Product>();
            var mockProductsDbSet = MockDbSet(products);
            mockContext.Setup(x => x.Products).Returns(mockProductsDbSet.Object);
            return mockContext.Object;
        }

        internal static Mock<DbSet<T>> MockDbSet<T>(IList<T> list) where T : class
        {
            var queryableList = list.AsQueryable();
            var mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryableList.GetEnumerator());

            // mockDbSet.Setup(m => m.Include(It.IsAny<string>())).Returns(mockDbSet.Object);
            mockDbSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>((s) => list.Add(s));
            mockDbSet.Setup(m => m.Remove(It.IsAny<T>())).Callback<T>(i => list.Remove(i));
            mockDbSet.Setup(m => m.AddRange(It.IsAny<IEnumerable<T>>())).Callback<IEnumerable<T>>(x => ((List<T>)list).AddRange(x));
            // mockDbSet.Setup(m => m.AsNoTracking()).Returns(mockDbSet.Object);

            return mockDbSet;
        }
    }
}
